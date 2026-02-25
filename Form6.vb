Imports System.IO
Imports System.Text
Imports System.Diagnostics
Imports Microsoft.AspNetCore.SignalR.Client
Imports System.Drawing.Imaging
Imports AForge.Video
Imports AForge.Video.DirectShow
Imports System.Security.Cryptography
Imports MySql.Data.MySqlClient ' NEW: Required for the 5-Step Database connection

Public Class Form6

    '================ SIGNALR =================
    Private connection As HubConnection

    '================ FILE PATHS =================
    Dim videoPath As String = "F:\christ\sem 4\net\java_vid.mp4"
    Dim stressFile As String = "F:\christ\sem 4\net\stress.txt"
    Dim pythonScript As String = "F:\christ\sem 4\net\stress_monitor.py"
    Dim framePath As String = "F:\christ\sem 4\net\current_frame.jpg"

    '================ CAMERA =================
    Dim camera As VideoCaptureDevice
    Dim cameras As FilterInfoCollection
    Private isSendingFrame As Boolean = False
    Private lastCapturedFrame As Bitmap = Nothing

    '================ DEMO LOGIC =================
    Private justFinishedBreak As Boolean = False

    '================ FORM LOAD =================
    Private Async Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ButtonDownload.Enabled = False
        ButtonDownload.BackColor = Color.Gray
        LabelStatus.Text = "Status: Locked"

        If File.Exists(videoPath) Then
            AxWindowsMediaPlayer1.URL = videoPath
            AxWindowsMediaPlayer1.Ctlcontrols.play()
        End If

        If UserSession.UserRole = "Host" Then
            ButtonAI.Visible = True
            ButtonBreak.Visible = True
            LabelStress.Visible = True
            LabelStressLevel.Visible = True
        Else
            ButtonAI.Visible = False
            ButtonBreak.Visible = False
            LabelStress.Visible = False
            LabelStressLevel.Visible = False
        End If

        connection = New HubConnectionBuilder() _
            .WithUrl("https://localhost:7052/whiteboardHub") _
            .Build()

        AddHandler connection.Closed, Async Function(ex)
                                          Await Task.Delay(2000)
                                          Await connection.StartAsync()
                                      End Function

        connection.On(Of Byte())("ReceiveCamera",
            Sub(bytes)
                If UserSession.UserRole = "Host" Then
                    Try
                        Dim ms As New MemoryStream(bytes)
                        Dim bmp As New Bitmap(ms)
                        Me.Invoke(Sub()
                                      If PictureBoxHostView.Image IsNot Nothing Then PictureBoxHostView.Image.Dispose()
                                      PictureBoxHostView.Image = bmp
                                  End Sub)
                    Catch
                    End Try
                End If
            End Sub)

        connection.On("StartAIStudent", Sub() If UserSession.UserRole = "Student" Then Task.Run(Sub() RunAI()))

        connection.On(Of Integer, String)("ReceiveStress",
            Sub(percent, level)
                If UserSession.UserRole = "Host" Then
                    Me.Invoke(Sub()
                                  LabelStress.Text = "Stress : " & percent.ToString() & "%"
                                  LabelStressLevel.Text = level
                              End Sub)
                End If
            End Sub)

        connection.On("BreakStart",
            Sub()
                Me.Invoke(Sub()
                              AxWindowsMediaPlayer1.Ctlcontrols.pause()
                              If UserSession.UserRole = "Student" Then CameraOff()
                          End Sub)
            End Sub)

        connection.On("BreakEnd",
            Sub()
                Me.Invoke(Sub()
                              AxWindowsMediaPlayer1.Ctlcontrols.play()
                              If UserSession.UserRole = "Student" Then CameraOn()
                          End Sub)
            End Sub)

        Await connection.StartAsync()

        If UserSession.UserRole = "Student" Then
            Await Task.Delay(1000)
            CameraOn()
        End If
    End Sub

    '================ CAMERA ON / OFF =================
    Sub CameraOn()
        Try
            cameras = New FilterInfoCollection(FilterCategory.VideoInputDevice)
            If cameras.Count = 0 Then Exit Sub

            camera = New VideoCaptureDevice(cameras(0).MonikerString)

            If camera.VideoCapabilities.Length > 0 Then
                Dim resolutionSet As Boolean = False
                For Each cap In camera.VideoCapabilities
                    If cap.FrameSize.Width = 640 AndAlso cap.FrameSize.Height = 480 Then
                        camera.VideoResolution = cap
                        resolutionSet = True
                        Exit For
                    End If
                Next
                If Not resolutionSet Then camera.VideoResolution = camera.VideoCapabilities(camera.VideoCapabilities.Length - 1)
            End If

            isSendingFrame = False
            AddHandler camera.NewFrame, AddressOf CameraFrame
            camera.Start()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub CameraOff()
        Try
            If camera IsNot Nothing AndAlso camera.IsRunning Then
                RemoveHandler camera.NewFrame, AddressOf CameraFrame
                camera.SignalToStop()
                camera.WaitForStop()
                camera = Nothing
            End If
            isSendingFrame = False
            Me.Invoke(Sub() PictureBoxHostView.Image = Nothing)
        Catch
        End Try
    End Sub

    '================ CAMERA STREAM =================
    Sub CameraFrame(sender As Object, e As NewFrameEventArgs)
        If isSendingFrame Then Return

        Try
            Dim bmp As Bitmap = CType(e.Frame.Clone(), Bitmap)

            Me.Invoke(Sub()
                          If PictureBoxHostView.Image IsNot Nothing Then PictureBoxHostView.Image.Dispose()
                          PictureBoxHostView.Image = CType(bmp.Clone(), Bitmap)
                      End Sub)

            If connection IsNot Nothing AndAlso connection.State = HubConnectionState.Connected Then
                isSendingFrame = True

                If lastCapturedFrame IsNot Nothing Then lastCapturedFrame.Dispose()
                lastCapturedFrame = CType(bmp.Clone(), Bitmap)

                Dim ms As New MemoryStream()
                bmp.Save(ms, ImageFormat.Jpeg)
                Dim bytes() As Byte = ms.ToArray()

                connection.InvokeAsync("SendCamera", bytes).ContinueWith(Sub(t) isSendingFrame = False)
                ms.Dispose()
            End If
            bmp.Dispose()
        Catch
            isSendingFrame = False
        End Try
    End Sub

    '================ FORM CLOSE =================
    Private Sub Form6_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        CameraOff()
        Environment.Exit(0)
    End Sub

    '================ RUN AI =================
    Private Async Sub ButtonAI_Click(sender As Object, e As EventArgs) Handles ButtonAI.Click
        LabelStress.Text = "Calculating..."
        LabelStressLevel.Text = "--"
        ButtonAI.Enabled = False
        Await connection.InvokeAsync("StartAI")
        Await Task.Delay(3000)
        ButtonAI.Enabled = True
    End Sub

    Sub RunAI()
        Try
            If lastCapturedFrame IsNot Nothing Then
                Try
                    lastCapturedFrame.Save(framePath, ImageFormat.Jpeg)
                Catch
                End Try
            End If

            If File.Exists(stressFile) Then File.Delete(stressFile)

            Dim p As New Process()
            p.StartInfo.FileName = "cmd.exe"

            Dim breakFlag As String = If(justFinishedBreak, "1", "0")
            p.StartInfo.Arguments = "/c py """ & pythonScript & """ " & breakFlag

            p.StartInfo.UseShellExecute = False
            p.StartInfo.CreateNoWindow = True
            p.Start()
            p.WaitForExit()

            Threading.Thread.Sleep(500)

            If File.Exists(stressFile) Then
                Dim parts() = File.ReadAllText(stressFile).Trim().Split(",")
                connection.InvokeAsync("SendStress", CInt(parts(0).Trim()), parts(1).Trim()).Wait()
            End If

            justFinishedBreak = False

        Catch
        End Try
    End Sub

    '================ BREAK SYSTEM =================
    Private Async Sub ButtonBreak_Click(sender As Object, e As EventArgs) Handles ButtonBreak.Click
        Dim input As String = Microsoft.VisualBasic.Interaction.InputBox("Enter break duration in seconds:", "Assign Break Timer", "10")
        If String.IsNullOrWhiteSpace(input) Then Return

        Dim seconds As Integer
        If Integer.TryParse(input, seconds) AndAlso seconds > 0 Then
            AxWindowsMediaPlayer1.Ctlcontrols.pause()
            Await connection.InvokeAsync("SendBreakStart")
            StartBreak(seconds)
        Else
            MessageBox.Show("Please enter a valid number of seconds.")
        End If
    End Sub

    Private Async Sub StartBreak(seconds As Integer)
        Await Task.Delay(seconds * 1000)

        If MessageBox.Show("Break time is up! Resume Class?", "Host Panel", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            justFinishedBreak = True
            AxWindowsMediaPlayer1.Ctlcontrols.play()
            Await connection.InvokeAsync("SendBreakEnd")
        Else
            StartBreak(10)
        End If
    End Sub

    '================ 5-STEP SECURE ENCRYPTION MODULE =================
    Private Sub ButtonEncrypt_Click(sender As Object, e As EventArgs) Handles ButtonEncrypt.Click
        If String.IsNullOrWhiteSpace(TextBoxKey.Text) Then
            MessageBox.Show("Please enter a secret key/password first.")
            Return
        End If

        Try
            ' Step-1: Connect to database
            Dim connString As String = "server=localhost;user id=root;password=pulmyt;database=tbl;port=3306;"
            Using con As New MySqlConnection(connString)
                con.Open()

                ' Clean up old demo key (Optional, ensures we only have 1 active key for this demo)
                Dim cleanCmd As New MySqlCommand("DELETE FROM SecureKeys WHERE DemoID = 1", con)
                cleanCmd.ExecuteNonQuery()

                ' Step-2: Generate salt
                Dim saltBytes(15) As Byte
                Using rng As RandomNumberGenerator = RandomNumberGenerator.Create()
                    rng.GetBytes(saltBytes)
                End Using
                Dim saltString As String = Convert.ToBase64String(saltBytes)

                ' Step-3: Hash password securely
                Dim hashString As String = ""
                Using pbkdf2 As New Rfc2898DeriveBytes(TextBoxKey.Text, saltBytes, 100000, HashAlgorithmName.SHA256)
                    Dim hashBytes As Byte() = pbkdf2.GetBytes(32) ' 256-bit hash
                    hashString = Convert.ToBase64String(hashBytes)
                End Using

                ' Step-4: Insert securely using parameters
                Dim query As String = "INSERT INTO SecureKeys (DemoID, PassHash, PassSalt) VALUES (1, @hash, @salt)"
                Using cmd As New MySqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@hash", hashString)
                    cmd.Parameters.AddWithValue("@salt", saltString)
                    cmd.ExecuteNonQuery()
                End Using

                ' Step-5: Close connection
                con.Close()

                ' Update UI
                LabelStatus.Text = "Saved! Hash: " & hashString.Substring(0, Math.Min(hashString.Length, 10)) & "..."
                LabelStatus.ForeColor = Color.Blue
                TextBoxKey.Clear()
                MessageBox.Show("Password hashed and securely saved to database!")
            End Using

        Catch ex As Exception
            MessageBox.Show("Database Error: " & ex.Message & vbCrLf & vbCrLf & "Did you create the 'SecureKeys' table in MySQL?")
        End Try
    End Sub

    Private Sub ButtonDecrypt_Click(sender As Object, e As EventArgs) Handles ButtonDecrypt.Click
        If String.IsNullOrWhiteSpace(TextBoxKey.Text) Then
            MessageBox.Show("Please enter the secret key to unlock.")
            Return
        End If

        Try
            Dim fetchedHash As String = ""
            Dim fetchedSalt As String = ""

            ' Step-1: Connect to database
            Dim connString As String = "server=localhost;user id=root;password=pulmyt;database=tbl;port=3306;"
            Using con As New MySqlConnection(connString)
                con.Open()

                ' Fetch the stored hash and salt securely
                Dim query As String = "SELECT PassHash, PassSalt FROM SecureKeys WHERE DemoID = 1"
                Using cmd As New MySqlCommand(query, con)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            fetchedHash = reader("PassHash").ToString()
                            fetchedSalt = reader("PassSalt").ToString()
                        Else
                            MessageBox.Show("No saved key found in database. Please Encrypt one first.")
                            Return
                        End If
                    End Using
                End Using

                ' Step-5: Close connection
                con.Close()
            End Using

            ' --- VERIFICATION PROCESS ---
            ' Hash the user's input with the fetched salt to see if it matches
            Dim saltBytes As Byte() = Convert.FromBase64String(fetchedSalt)
            Dim inputHashString As String = ""

            Using pbkdf2 As New Rfc2898DeriveBytes(TextBoxKey.Text, saltBytes, 100000, HashAlgorithmName.SHA256)
                Dim hashBytes As Byte() = pbkdf2.GetBytes(32)
                inputHashString = Convert.ToBase64String(hashBytes)
            End Using

            If inputHashString = fetchedHash Then
                ' SUCCESS! Unlock the button.
                ButtonDownload.Enabled = True
                ButtonDownload.BackColor = Color.LightGreen
                ButtonDownload.ForeColor = Color.Black
                LabelStatus.Text = "Verified! Download Unlocked."
                LabelStatus.ForeColor = Color.Green
                MessageBox.Show("Database Verification successful! Download Unlocked.")
            Else
                LabelStatus.Text = "Access Denied: Incorrect Key."
                LabelStatus.ForeColor = Color.Red
            End If

        Catch ex As Exception
            LabelStatus.Text = "Database connection failed."
            LabelStatus.ForeColor = Color.Red
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub ButtonDownload_Click(sender As Object, e As EventArgs) Handles ButtonDownload.Click
        Dim sfd As New SaveFileDialog()
        sfd.Title = "Download Secure Resource"
        sfd.Filter = "Text Document|*.txt|PDF Document|*.pdf|All Files|*.*"
        sfd.FileName = "Workshop_Secret_Resource.txt"

        ' If the user clicks "Save" in the dialog
        If sfd.ShowDialog() = DialogResult.OK Then
            Try
                ' Simulate downloading by actually creating a file at their chosen location!
                File.WriteAllText(sfd.FileName, "CONGRATULATIONS! You successfully decrypted the database and downloaded the secure workshop resource.")

                MessageBox.Show("Resource Downloaded Successfully!")

                ' Re-lock the system after a successful download
                ButtonDownload.Enabled = False
                ButtonDownload.BackColor = Color.Gray
                ButtonDownload.ForeColor = Color.White
                LabelStatus.Text = "Status: Locked"
                LabelStatus.ForeColor = Color.Black
                TextBoxKey.Clear()

            Catch ex As Exception
                MessageBox.Show("Error downloading file: " & ex.Message)
            End Try
        End If
        ' If they click "Cancel" on the dialog, it just closes and stays unlocked so they can try again.
    End Sub

    '================ OTHER TOOLS =================
    Private Sub ButtonWhiteboard_Click(sender As Object, e As EventArgs) Handles ButtonWhiteboard.Click
        Dim f As New Form7()
        f.Show()
    End Sub

    Private Sub ButtonSaveNotes_Click(sender As Object, e As EventArgs) Handles ButtonSaveNotes.Click
        Dim s As New SaveFileDialog()
        s.Filter = "Text|*.txt|Rich|*.rtf"
        If s.ShowDialog() = DialogResult.OK Then
            RichTextBoxNotes.SaveFile(s.FileName)
        End If
    End Sub

    Private Sub ButtonRun_Click(sender As Object, e As EventArgs) Handles ButtonRun.Click
        Try
            Dim folder = "F:\christ\sem 4\net\JavaRun\"
            Directory.CreateDirectory(folder)
            Dim javaFile = folder & "Main.java"
            File.WriteAllText(javaFile, RichTextBoxCode.Text)
            Dim compile As New Process()
            compile.StartInfo.FileName = "cmd.exe"
            compile.StartInfo.Arguments = "/c cd """ & folder & """ && javac Main.java"
            compile.StartInfo.UseShellExecute = False
            compile.Start()
            compile.WaitForExit()
            Dim run As New Process()
            run.StartInfo.FileName = "cmd.exe"
            run.StartInfo.Arguments = "/c cd """ & folder & """ && java Main"
            run.StartInfo.RedirectStandardOutput = True
            run.StartInfo.UseShellExecute = False
            run.Start()
            Dim output = run.StandardOutput.ReadToEnd()
            MessageBox.Show(output)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

End Class