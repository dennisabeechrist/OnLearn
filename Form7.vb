Imports System.Drawing
Imports System.IO
Imports Microsoft.AspNetCore.SignalR.Client

Public Class Form7

    ' ========= WHITEBOARD VARIABLES =========
    Dim drawing As Boolean = False
    Dim startX, startY As Integer
    Dim lastPoint As Point

    Dim activeTool As String = "Pen" ' Tools: Pen, Pencil, Eraser, Rect
    Dim penColor As Color = Color.Black
    Dim penSize As Integer = 3

    Dim bmp As Bitmap
    Dim previewBmp As Bitmap
    Dim g As Graphics

    ' ========= SIGNALR =========
    Dim connection As HubConnection

    ' ========= FORM LOAD =========
    Private Async Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' ===== CREATE WHITEBOARD =====
        bmp = New Bitmap(PanelCanvas.Width, PanelCanvas.Height)
        g = Graphics.FromImage(bmp)
        g.Clear(Color.White)
        g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        PanelCanvas.BackgroundImage = bmp

        ' ===== LOAD SAVED WHITEBOARD =====
        Dim path As String = "F:\christ\sem 4\net\WhiteboardState.bmp"
        If File.Exists(path) Then
            Using temp As New Bitmap(path)
                bmp = New Bitmap(temp)
            End Using
            g = Graphics.FromImage(bmp)
            g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
            PanelCanvas.BackgroundImage = bmp
        End If

        ' ===== HOST OR STUDENT MODE =====
        If UserSession.UserRole = "Host" Then
            LabelMode.Text = "HOST MODE"
        Else
            LabelMode.Text = "VIEW ONLY MODE"
            DisableStudentControls()
        End If

        ' ===== SIGNALR CONNECTION =====
        connection = New HubConnectionBuilder() _
            .WithUrl("https://localhost:7052/whiteboardHub") _
            .Build()

        ' Receive Freehand Draw
        connection.On(Of Integer, Integer, Integer, Integer, Integer, Integer)("ReceiveDraw", AddressOf ReceiveDrawing)

        ' Receive Shapes
        connection.On(Of String, Integer, Integer, Integer, Integer, Integer, Integer)("ReceiveShape", AddressOf ReceiveShape)

        ' Receive Clear Board
        connection.On("ReceiveClear",
            Sub()
                PanelCanvas.Invoke(Sub()
                                       g.Clear(Color.White)
                                       PanelCanvas.Invalidate()
                                   End Sub)
            End Sub)

        Try
            Await connection.StartAsync()
        Catch ex As Exception
            MessageBox.Show("SignalR Error: " & ex.Message)
        End Try

    End Sub

    ' ========= DISABLE STUDENT CONTROLS =========
    Private Sub DisableStudentControls()
        ButtonPencil.Enabled = False
        ButtonPen.Enabled = False
        ButtonEraser.Enabled = False
        ButtonShape.Enabled = False
        ButtonClear.Enabled = False
        ButtonNew.Enabled = False
        ButtonSaveState.Enabled = False
        ButtonColor.Enabled = False
    End Sub

    ' ========= MOUSE DOWN =========
    Private Sub PanelCanvas_MouseDown(sender As Object, e As MouseEventArgs) Handles PanelCanvas.MouseDown
        If UserSession.UserRole = "Host" Then
            drawing = True
            startX = e.X
            startY = e.Y
            lastPoint = e.Location

            If activeTool = "Rect" Then
                previewBmp = CType(bmp.Clone(), Bitmap) ' Snapshot for live shape preview
            End If
        End If
    End Sub

    ' ========= MOUSE MOVE =========
    Private Async Sub PanelCanvas_MouseMove(sender As Object, e As MouseEventArgs) Handles PanelCanvas.MouseMove
        If Not drawing OrElse UserSession.UserRole <> "Host" Then Return

        If activeTool = "Pen" Or activeTool = "Pencil" Or activeTool = "Eraser" Then
            ' --- FREEHAND DRAWING ---
            g.DrawLine(New Pen(penColor, penSize) With {.StartCap = Drawing2D.LineCap.Round, .EndCap = Drawing2D.LineCap.Round}, lastPoint, e.Location)
            PanelCanvas.Invalidate()

            If connection IsNot Nothing AndAlso connection.State = HubConnectionState.Connected Then
                Await connection.InvokeAsync("SendDraw", lastPoint.X, lastPoint.Y, e.X, e.Y, penColor.ToArgb(), penSize)
            End If
            lastPoint = e.Location

        ElseIf activeTool = "Rect" Then
            ' --- SHAPE LIVE PREVIEW ---
            Dim temp As Bitmap = CType(previewBmp.Clone(), Bitmap)
            Using tempG As Graphics = Graphics.FromImage(temp)
                tempG.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
                Using p As New Pen(penColor, penSize)
                    Dim r = GetRectangle(startX, startY, e.X, e.Y)
                    tempG.DrawRectangle(p, r)
                End Using
            End Using
            PanelCanvas.BackgroundImage = temp
        End If
    End Sub

    ' ========= MOUSE UP =========
    Private Async Sub PanelCanvas_MouseUp(sender As Object, e As MouseEventArgs) Handles PanelCanvas.MouseUp
        If Not drawing Then Return
        drawing = False

        If activeTool = "Rect" Then
            Dim r = GetRectangle(startX, startY, e.X, e.Y)

            ' Draw Final Shape to the Real Board
            Using p As New Pen(penColor, penSize)
                g.DrawRectangle(p, r)
            End Using

            PanelCanvas.BackgroundImage = bmp
            PanelCanvas.Invalidate()

            ' Send Final Shape via SignalR
            If connection IsNot Nothing AndAlso connection.State = HubConnectionState.Connected Then
                Await connection.InvokeAsync("SendShape", activeTool, r.X, r.Y, r.Width, r.Height, penColor.ToArgb(), penSize)
            End If

            If previewBmp IsNot Nothing Then previewBmp.Dispose()
        End If
    End Sub

    ' Helper function to draw shapes backwards
    Private Function GetRectangle(x1 As Integer, y1 As Integer, x2 As Integer, y2 As Integer) As Rectangle
        Return New Rectangle(Math.Min(x1, x2), Math.Min(y1, y2), Math.Abs(x1 - x2), Math.Abs(y1 - y2))
    End Function

    ' ========= RECEIVE DATA FROM SIGNALR =========
    Private Sub ReceiveDrawing(x1 As Integer, y1 As Integer, x2 As Integer, y2 As Integer, colorArgb As Integer, size As Integer)
        Dim receivedColor As Color = Color.FromArgb(colorArgb)
        g.DrawLine(New Pen(receivedColor, size) With {.StartCap = Drawing2D.LineCap.Round, .EndCap = Drawing2D.LineCap.Round}, New Point(x1, y1), New Point(x2, y2))
        PanelCanvas.Invoke(Sub() PanelCanvas.Invalidate())
    End Sub

    Private Sub ReceiveShape(shapeType As String, sx As Integer, sy As Integer, w As Integer, h As Integer, colorArgb As Integer, size As Integer)
        Dim receivedColor As Color = Color.FromArgb(colorArgb)
        Using p As New Pen(receivedColor, size)
            Dim rect As New Rectangle(sx, sy, w, h)
            If shapeType = "Rect" Then
                g.DrawRectangle(p, rect)
            End If
        End Using
        PanelCanvas.Invoke(Sub() PanelCanvas.Invalidate())
    End Sub

    ' ========= TOOL BUTTONS =========
    Private Sub ButtonPencil_Click(sender As Object, e As EventArgs) Handles ButtonPencil.Click
        activeTool = "Pencil"
        penSize = 2
        penColor = Color.Black
    End Sub

    Private Sub ButtonPen_Click(sender As Object, e As EventArgs) Handles ButtonPen.Click
        activeTool = "Pen"
        penSize = 6
        penColor = Color.Black
    End Sub

    Private Sub ButtonEraser_Click(sender As Object, e As EventArgs) Handles ButtonEraser.Click
        activeTool = "Eraser"
        penSize = 25
        penColor = Color.White
    End Sub

    Private Sub ButtonShape_Click(sender As Object, e As EventArgs) Handles ButtonShape.Click
        activeTool = "Rect"
        penSize = 4
    End Sub

    Private Sub ButtonColor_Click(sender As Object, e As EventArgs) Handles ButtonColor.Click
        Dim cd As New ColorDialog()
        If cd.ShowDialog() = DialogResult.OK Then
            penColor = cd.Color
        End If
    End Sub

    ' ========= BOARD CONTROLS =========
    Private Async Sub ButtonClear_Click(sender As Object, e As EventArgs) Handles ButtonClear.Click
        g.Clear(Color.White)
        PanelCanvas.Invalidate()
        If connection IsNot Nothing AndAlso connection.State = HubConnectionState.Connected Then
            Await connection.InvokeAsync("SendClear")
        End If
    End Sub

    Private Sub ButtonNew_Click(sender As Object, e As EventArgs) Handles ButtonNew.Click
        g.Clear(Color.White)
        PanelCanvas.Invalidate()
    End Sub

    Private Sub ButtonSaveState_Click(sender As Object, e As EventArgs) Handles ButtonSaveState.Click
        Try
            Dim path As String = "F:\christ\sem 4\net\WhiteboardState.bmp"
            If File.Exists(path) Then File.Delete(path)
            bmp.Save(path, Imaging.ImageFormat.Bmp)
            MessageBox.Show("Whiteboard Saved Successfully")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ButtonSaveAs_Click(sender As Object, e As EventArgs) Handles ButtonSaveAs.Click
        Dim sfd As New SaveFileDialog()
        sfd.Filter = "PNG Image|*.png"
        If sfd.ShowDialog() = DialogResult.OK Then bmp.Save(sfd.FileName)
    End Sub

    Private Sub ButtonReturn_Click(sender As Object, e As EventArgs) Handles ButtonReturn.Click
        Me.Hide()
    End Sub

End Class