Imports System.Drawing.Drawing2D

Public Class CircularProgress
    Inherits Control

    Private _value As Integer = 70

    Public Property Value As Integer
        Get
            Return _value
        End Get
        Set(value As Integer)
            _value = value
            Me.Invalidate()
        End Set
    End Property

    Public Sub New()
        Me.DoubleBuffered = True
        Me.Size = New Size(150, 150)
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)

        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias

        Dim rect As New Rectangle(10, 10, Me.Width - 20, Me.Height - 20)

        Using backPen As New Pen(Color.LightGray, 12)
            e.Graphics.DrawArc(backPen, rect, -90.0F, 360.0F)
        End Using

        Using progressPen As New Pen(Color.MediumPurple, 12)
            e.Graphics.DrawArc(progressPen, rect, -90.0F, CSng(360.0F * _value / 100.0F))
        End Using

        Dim sf As New StringFormat()
        sf.Alignment = StringAlignment.Center
        sf.LineAlignment = StringAlignment.Center

        e.Graphics.DrawString(_value & "%",
                              New Font("Segoe UI", 14, FontStyle.Bold),
                              Brushes.Black,
                              Me.Width / 2,
                              Me.Height / 2,
                              sf)
    End Sub

End Class
