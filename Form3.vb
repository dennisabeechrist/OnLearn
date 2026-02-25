Imports System.IO
Imports MySql.Data.MySqlClient

Public Class Form3

    Dim con As New MySqlConnection("server=localhost;user id=root;password=pulmyt;database=tbl;port=3306;")

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' ===== APPLY SAVED SETTINGS =====
        ComboBox2.Text = AppSettings.Instance.DefaultCategory
        TextBox4.Text = AppSettings.Instance.LastSearchText

        LoadResources()
        AddButtons()
    End Sub

    ' ===================== BROWSE BUTTON ===================== '
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ofd As New OpenFileDialog
        ofd.Title = "Select Resource File"
        ofd.Filter = "All Files|*.*"

        ' Start in last browsed folder
        If AppSettings.Instance.LastBrowsePath <> "" Then
            ofd.InitialDirectory = Path.GetDirectoryName(AppSettings.Instance.LastBrowsePath)
        End If

        If ofd.ShowDialog() = DialogResult.OK Then
            TextBox3.Text = ofd.FileName

            ' SAVE LAST BROWSE PATH
            AppSettings.Instance.LastBrowsePath = ofd.FileName
            AppSettings.Instance.Save()
        End If
    End Sub

    ' ===================== UPLOAD BUTTON ===================== '
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        If TextBox1.Text = "" Or TextBox3.Text = "" Or ComboBox1.Text = "" Then
            MessageBox.Show("Please fill all fields!", "Warning")
            Exit Sub
        End If

        Try
            con.Open()

            Dim query As String =
                "INSERT INTO tblResources (Title, Description, Category, FilePath, UploadDate) 
                 VALUES (@Title, @Desc, @Cat, @Path, @Date)"

            Dim cmd As New MySqlCommand(query, con)
            cmd.Parameters.AddWithValue("@Title", TextBox1.Text)
            cmd.Parameters.AddWithValue("@Desc", TextBox2.Text)
            cmd.Parameters.AddWithValue("@Cat", ComboBox1.Text)
            cmd.Parameters.AddWithValue("@Path", TextBox3.Text)
            cmd.Parameters.AddWithValue("@Date", DateTime.Now)

            cmd.ExecuteNonQuery()
            con.Close()

            MessageBox.Show("Resource uploaded successfully!")

            LoadResources()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            con.Close()
        End Try

    End Sub

    ' ===================== LOAD DATA ===================== '
    Private Sub LoadResources()
        Try
            con.Open()
            Dim da As New MySqlDataAdapter("SELECT * FROM tblResources ORDER BY ResourceID DESC", con)
            Dim dt As New DataTable
            da.Fill(dt)
            DataGridView1.DataSource = dt
            con.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            con.Close()
        End Try
    End Sub

    ' ===================== ADD BUTTON COLUMNS ===================== '
    Private Sub AddButtons()

        If DataGridView1.Columns("ViewBtn") Is Nothing Then
            Dim viewBtn As New DataGridViewButtonColumn()
            viewBtn.HeaderText = "View"
            viewBtn.Name = "ViewBtn"
            viewBtn.Text = "View"
            viewBtn.UseColumnTextForButtonValue = True
            DataGridView1.Columns.Add(viewBtn)
        End If

        If DataGridView1.Columns("DownloadBtn") Is Nothing Then
            Dim dlBtn As New DataGridViewButtonColumn()
            dlBtn.HeaderText = "Download"
            dlBtn.Name = "DownloadBtn"
            dlBtn.Text = "Download"
            dlBtn.UseColumnTextForButtonValue = True
            DataGridView1.Columns.Add(dlBtn)
        End If

        If DataGridView1.Columns("DeleteBtn") Is Nothing Then
            Dim delBtn As New DataGridViewButtonColumn()
            delBtn.HeaderText = "Delete"
            delBtn.Name = "DeleteBtn"
            delBtn.Text = "Delete"
            delBtn.UseColumnTextForButtonValue = True
            DataGridView1.Columns.Add(delBtn)
        End If

    End Sub

    ' ===================== SEARCH BUTTON ===================== '
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Dim sql As String = "SELECT * FROM tblResources WHERE Title LIKE @search"

        If ComboBox2.Text <> "" And ComboBox2.Text <> "All Categories" Then
            sql &= " AND Category=@cat"
        End If

        Try
            con.Open()
            Dim cmd As New MySqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@search", "%" & TextBox4.Text & "%")

            If ComboBox2.Text <> "" And ComboBox2.Text <> "All Categories" Then
                cmd.Parameters.AddWithValue("@cat", ComboBox2.Text)
            End If

            Dim da As New MySqlDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)
            DataGridView1.DataSource = dt

            con.Close()

            ' ===== SAVE SEARCH SETTINGS =====
            AppSettings.Instance.LastSearchText = TextBox4.Text
            AppSettings.Instance.DefaultCategory = ComboBox2.Text
            AppSettings.Instance.Save()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            con.Close()
        End Try

    End Sub

    ' ===================== VIEW / DOWNLOAD / DELETE ===================== '
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Exit Sub

        Dim colName As String = DataGridView1.Columns(e.ColumnIndex).Name
        Dim row = DataGridView1.Rows(e.RowIndex)

        If row.Cells("FilePath").Value Is Nothing OrElse row.Cells("ResourceID").Value Is Nothing Then
            MessageBox.Show("Invalid resource data.")
            Exit Sub
        End If

        Dim filePath As String = row.Cells("FilePath").Value.ToString()
        Dim id As Integer = Convert.ToInt32(row.Cells("ResourceID").Value)

        ' ===== VIEW =====
        If colName = "ViewBtn" Then
            If File.Exists(filePath) Then
                Process.Start(filePath)
            Else
                MessageBox.Show("File not found!")
            End If

            ' ===== DOWNLOAD =====
        ElseIf colName = "DownloadBtn" Then
            Dim sfd As New SaveFileDialog()
            sfd.FileName = Path.GetFileName(filePath)

            If sfd.ShowDialog() = DialogResult.OK Then
                File.Copy(filePath, sfd.FileName, True)
                MessageBox.Show("File downloaded successfully!")
            End If

            ' ===== DELETE =====
        ElseIf colName = "DeleteBtn" Then
            If MessageBox.Show("Delete this resource?", "Confirm", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                Try
                    con.Open()
                    Dim cmd As New MySqlCommand("DELETE FROM tblResources WHERE ResourceID=@id", con)
                    cmd.Parameters.AddWithValue("@id", id)
                    cmd.ExecuteNonQuery()
                    con.Close()

                    LoadResources()
                    MessageBox.Show("Resource deleted!")

                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                    con.Close()
                End Try
            End If
        End If

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class
