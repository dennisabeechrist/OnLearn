Public Class Form1

    ' -------- GLOBALS --------
    Dim captchaValue As String = ""
    Dim attempts As Integer = 0
    Dim generatedOTP As String = ""

    ' -------- DELEGATES --------
    Public Delegate Function ValidateDelegate(username As String, password As String) As Boolean
    Public Delegate Sub DisplayDelegate(message As String, isSuccess As Boolean)

    ' -------- EVENTS --------
    Public Event LoginSuccess()
    Public Event LoginFailed()

    ' -------- Delegate Instances --------
    Private validateUser As ValidateDelegate
    Private displayResult As DisplayDelegate


    ' *******************************
    '           FORM LOAD
    ' *******************************
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        validateUser = AddressOf ValidateCredentials
        displayResult = AddressOf DisplayMessage

        Label5.Visible = False

        GenerateCaptcha()

    End Sub



    ' *******************************
    '           CAPTCHA
    ' *******************************
    Private Sub GenerateCaptcha()

        Dim chars As String = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789"

        Dim rand As New Random()

        captchaValue = ""

        For i As Integer = 1 To 5

            captchaValue &= chars(rand.Next(chars.Length))

        Next

        Label3.Text = captchaValue

    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        GenerateCaptcha()

    End Sub



    ' *******************************
    '       SHOW / HIDE PASSWORD
    ' *******************************
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged

        If CheckBox1.Checked Then

            TextBox2.PasswordChar = ""

        Else

            TextBox2.PasswordChar = "*"

        End If

    End Sub



    ' *******************************
    '       VALIDATION METHOD
    ' *******************************
    Private Function ValidateCredentials(username As String, password As String) As Boolean

        ' Host Login
        If username.ToLower() = "host" And password = "12345" Then
            Return True
        End If

        ' Student Login
        If username.ToLower() = "student" And password = "12345" Then
            Return True
        End If

        Return False

    End Function



    ' *******************************
    '       DISPLAY MESSAGE
    ' *******************************
    Private Sub DisplayMessage(msg As String, success As Boolean)

        Label5.Visible = True

        Label5.Text = msg

        If success Then

            Label5.ForeColor = Color.Green

        Else

            Label5.ForeColor = Color.Red

        End If

    End Sub



    ' *******************************
    '          OTP GENERATOR
    ' *******************************
    Private Function GenerateOTP() As String

        Dim rand As New Random()

        Return rand.Next(100000, 999999).ToString()

    End Function



    ' *******************************
    '        LOGIN BUTTON CLICK
    ' *******************************
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        ' ------ Login lock check ------
        If attempts >= 3 Then

            DisplayMessage("Too many failed attempts. Try again after 30 seconds.", False)

            Button1.Enabled = False

            Dim t As New Timer()

            t.Interval = 30000

            AddHandler t.Tick,
                Sub()

                    Button1.Enabled = True
                    attempts = 0
                    t.Stop()

                End Sub

            t.Start()

            Exit Sub

        End If



        ' ------ CAPTCHA validation ------
        If TextBox3.Text.Trim().ToUpper() <> captchaValue.ToUpper() Then

            attempts += 1

            DisplayMessage("Incorrect CAPTCHA!", False)

            GenerateCaptcha()

            Exit Sub

        End If



        ' ------ Username + Password validation ------
        Dim result As Boolean = validateUser.Invoke(TextBox1.Text, TextBox2.Text)



        If result Then

            RaiseEvent LoginSuccess()

            DisplayMessage("Login Successful!", True)



            ' ===== SET USER ROLE =====

            If TextBox1.Text.ToLower() = "host" Then

                UserSession.UserRole = "Host"

            Else

                UserSession.UserRole = "Student"

            End If



            ' --- OTP ---
            generatedOTP = GenerateOTP()

            MessageBox.Show("Your OTP is: " & generatedOTP, "Verification")



            Dim otpForm As New FormOTP(generatedOTP)

            otpForm.Show()

            Me.Hide()


        Else

            attempts += 1

            RaiseEvent LoginFailed()

            DisplayMessage("Invalid Username or Password", False)

        End If

    End Sub



    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub


    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub


    Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs) Handles Panel4.Paint

    End Sub


    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub


    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub


End Class