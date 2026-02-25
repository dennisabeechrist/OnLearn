Public Class Form2

    Private f3 As Form3
    Private f4 As Form4
    Private f5 As Form5


    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        If f3 Is Nothing OrElse f3.IsDisposed Then
            f3 = New Form3()
        End If

        f3.Show()
        Me.Hide()

    End Sub



    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        If f5 Is Nothing OrElse f5.IsDisposed Then
            f5 = New Form5()
        End If

        f5.Show()
        Me.Hide()

    End Sub



    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        If f4 Is Nothing OrElse f4.IsDisposed Then
            f4 = New Form4()
        End If

        f4.Show()
        Me.Hide()

    End Sub


End Class