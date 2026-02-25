Imports System.IO
Imports System.Drawing

Public Class Form5

    '================ FORM LOAD =================
    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Keyboard shortcuts
        NewToolStripMenuItem.ShortcutKeys = Keys.Control Or Keys.N
        OpenToolStripMenuItem.ShortcutKeys = Keys.Control Or Keys.O
        SaveToolStripMenuItem.ShortcutKeys = Keys.Control Or Keys.S
        SaveAsToolStripMenuItem.ShortcutKeys = Keys.Control Or Keys.Shift Or Keys.S
        ExitToolStripMenuItem.ShortcutKeys = Keys.Alt Or Keys.F4

        ' Default theme → Light
        ApplyTheme(False)

        ' Create first tab
        CreateNewTab("New File")

    End Sub

    '================ HELPER METHODS =================
    Private Sub CreateNewTab(title As String)

        Dim tab As New TabPage(title)
        tab.Tag = "" ' file path

        Dim rtb As New RichTextBox()
        rtb.Dock = DockStyle.Fill
        rtb.Font = New Font("Segoe UI", 11)

        tab.Controls.Add(rtb)
        TabControl1.TabPages.Add(tab)
        TabControl1.SelectedTab = tab

        ' Apply current theme to new tab
        ApplyTheme(isDarkMode)

    End Sub

    Private Function GetEditor() As RichTextBox
        If TabControl1.TabPages.Count = 0 Then Return Nothing
        Return CType(TabControl1.SelectedTab.Controls(0), RichTextBox)
    End Function

    '================ THEME HANDLING =================
    Private isDarkMode As Boolean = False

    Private Sub ApplyTheme(dark As Boolean)
        isDarkMode = dark

        If dark Then
            Me.BackColor = Color.FromArgb(30, 30, 30)
            MenuStrip1.BackColor = Color.Black

            For Each item As ToolStripMenuItem In MenuStrip1.Items
                item.ForeColor = Color.White
            Next

            For Each tab As TabPage In TabControl1.TabPages
                Dim rtb = CType(tab.Controls(0), RichTextBox)
                rtb.BackColor = Color.Black
                rtb.ForeColor = Color.WhiteSmoke
            Next
        Else
            Me.BackColor = Color.WhiteSmoke
            MenuStrip1.BackColor = Color.SeaGreen

            For Each item As ToolStripMenuItem In MenuStrip1.Items
                item.ForeColor = Color.White
            Next

            For Each tab As TabPage In TabControl1.TabPages
                Dim rtb = CType(tab.Controls(0), RichTextBox)
                rtb.BackColor = Color.WhiteSmoke
                rtb.ForeColor = Color.Black
            Next
        End If
    End Sub

    '================ FILE MENU =================
    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles NewToolStripMenuItem.Click
        CreateNewTab("New File")
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles OpenToolStripMenuItem.Click

        Dim ofd As New OpenFileDialog()
        ofd.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"

        If ofd.ShowDialog() = DialogResult.OK Then
            CreateNewTab(Path.GetFileName(ofd.FileName))
            GetEditor().Text = File.ReadAllText(ofd.FileName)
            TabControl1.SelectedTab.Tag = ofd.FileName
        End If

    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles SaveToolStripMenuItem.Click

        Dim editor = GetEditor()
        If editor Is Nothing Then Exit Sub

        Dim path As String = TabControl1.SelectedTab.Tag.ToString()

        If path = "" Then
            SaveAsToolStripMenuItem_Click(sender, e)
        Else
            File.WriteAllText(path, editor.Text)
        End If

    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles SaveAsToolStripMenuItem.Click

        Dim sfd As New SaveFileDialog()
        sfd.Filter = "Text Files (*.txt)|*.txt"

        If sfd.ShowDialog() = DialogResult.OK Then
            File.WriteAllText(sfd.FileName, GetEditor().Text)
            TabControl1.SelectedTab.Text = Path.GetFileName(sfd.FileName)
            TabControl1.SelectedTab.Tag = sfd.FileName
        End If

    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub

    '================ EDIT MENU =================
    Private Sub CutToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles CutToolStripMenuItem.Click
        GetEditor()?.Cut()
    End Sub

    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles CopyToolStripMenuItem.Click
        GetEditor()?.Copy()
    End Sub

    Private Sub PasteToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles PasteToolStripMenuItem.Click
        GetEditor()?.Paste()
    End Sub

    Private Sub UndoToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles UndoToolStripMenuItem.Click
        GetEditor()?.Undo()
    End Sub

    Private Sub RedoToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles RedoToolStripMenuItem.Click
        GetEditor()?.Redo()
    End Sub

    Private Sub SelectAllToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles SelectAllToolStripMenuItem.Click
        GetEditor()?.SelectAll()
    End Sub

    '================ FORMAT MENU =================
    Private Sub FontToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles FontToolStripMenuItem.Click

        Dim fd As New FontDialog()
        If fd.ShowDialog() = DialogResult.OK Then
            GetEditor().Font = fd.Font
        End If

    End Sub

    Private Sub ColorToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles ColorToolStripMenuItem.Click

        Dim cd As New ColorDialog()
        If cd.ShowDialog() = DialogResult.OK Then
            GetEditor().ForeColor = cd.Color
        End If

    End Sub

    '================ VIEW MENU =================
    Private Sub DarkModeToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles DarkModeToolStripMenuItem.Click
        ApplyTheme(True)
    End Sub

    Private Sub LightModeToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles LightModeToolStripMenuItem.Click
        ApplyTheme(False)
    End Sub

End Class



