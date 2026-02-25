Public Class Form4

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub


    ' Load Form6 when PictureBox2 is clicked
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click

        Dim f As New Form6()
        f.Show()

        Me.Hide()

    End Sub


    ' Optional Hover Effect (Can Keep or Remove)
    Private Sub PanelCourseJava_MouseEnter(sender As Object, e As EventArgs) Handles PanelCourseJava.MouseEnter

        PanelCourseJava.BackColor = Color.FromArgb(240, 240, 255)

    End Sub


End Class