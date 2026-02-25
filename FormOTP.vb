Public Class FormOTP

    Private expectedOTP As String

    Public Sub New(otp As String)
        ' This call is required by the designer.
        InitializeComponent()

        expectedOTP = otp
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text.Trim() = expectedOTP Then
            MessageBox.Show("OTP Verified Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Dim dash As New Form2()
            dash.Show()
            Me.Close()
        Else
            MessageBox.Show("Incorrect OTP! Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub FormOTP_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs)

    End Sub
End Class
