<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form6
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form6))
        Me.PanelVideo = New System.Windows.Forms.Panel()
        Me.PanelCamera = New System.Windows.Forms.Panel()
        Me.PictureBoxHostView = New System.Windows.Forms.PictureBox()
        Me.AxWindowsMediaPlayer1 = New AxWMPLib.AxWindowsMediaPlayer()
        Me.PanelContent = New System.Windows.Forms.Panel()
        Me.ButtonBreak = New System.Windows.Forms.Button()
        Me.LabelStressLevel = New System.Windows.Forms.Label()
        Me.LabelStress = New System.Windows.Forms.Label()
        Me.ButtonAI = New System.Windows.Forms.Button()
        Me.ButtonWhiteboard = New System.Windows.Forms.Button()
        Me.LabelDescription = New System.Windows.Forms.Label()
        Me.PanelDescription = New System.Windows.Forms.Panel()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.ButtonRun = New System.Windows.Forms.Button()
        Me.RichTextBoxCode = New System.Windows.Forms.RichTextBox()
        Me.LabelCode = New System.Windows.Forms.Label()
        Me.ButtonSaveNotes = New System.Windows.Forms.Button()
        Me.RichTextBoxNotes = New System.Windows.Forms.RichTextBox()
        Me.LabelNotes = New System.Windows.Forms.Label()
        Me.PanelResources = New System.Windows.Forms.Panel()
        Me.LabelStatus = New System.Windows.Forms.Label()
        Me.ButtonEncrypt = New System.Windows.Forms.Button()
        Me.ButtonDecrypt = New System.Windows.Forms.Button()
        Me.TextBoxKey = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ButtonDownload = New System.Windows.Forms.Button()
        Me.ResourceList = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PanelVideo.SuspendLayout()
        Me.PanelCamera.SuspendLayout()
        CType(Me.PictureBoxHostView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AxWindowsMediaPlayer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelContent.SuspendLayout()
        Me.PanelDescription.SuspendLayout()
        Me.PanelResources.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelVideo
        '
        Me.PanelVideo.Controls.Add(Me.PanelCamera)
        Me.PanelVideo.Controls.Add(Me.AxWindowsMediaPlayer1)
        Me.PanelVideo.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelVideo.Location = New System.Drawing.Point(0, 0)
        Me.PanelVideo.Name = "PanelVideo"
        Me.PanelVideo.Size = New System.Drawing.Size(1263, 350)
        Me.PanelVideo.TabIndex = 0
        '
        'PanelCamera
        '
        Me.PanelCamera.Controls.Add(Me.PictureBoxHostView)
        Me.PanelCamera.Location = New System.Drawing.Point(609, 0)
        Me.PanelCamera.Name = "PanelCamera"
        Me.PanelCamera.Size = New System.Drawing.Size(570, 350)
        Me.PanelCamera.TabIndex = 1
        '
        'PictureBoxHostView
        '
        Me.PictureBoxHostView.Location = New System.Drawing.Point(0, 0)
        Me.PictureBoxHostView.Name = "PictureBoxHostView"
        Me.PictureBoxHostView.Size = New System.Drawing.Size(567, 344)
        Me.PictureBoxHostView.TabIndex = 0
        Me.PictureBoxHostView.TabStop = False
        '
        'AxWindowsMediaPlayer1
        '
        Me.AxWindowsMediaPlayer1.Enabled = True
        Me.AxWindowsMediaPlayer1.Location = New System.Drawing.Point(0, 0)
        Me.AxWindowsMediaPlayer1.Name = "AxWindowsMediaPlayer1"
        Me.AxWindowsMediaPlayer1.OcxState = CType(resources.GetObject("AxWindowsMediaPlayer1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxWindowsMediaPlayer1.Size = New System.Drawing.Size(603, 350)
        Me.AxWindowsMediaPlayer1.TabIndex = 0
        '
        'PanelContent
        '
        Me.PanelContent.AutoScroll = True
        Me.PanelContent.AutoSize = True
        Me.PanelContent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PanelContent.Controls.Add(Me.ButtonBreak)
        Me.PanelContent.Controls.Add(Me.LabelStressLevel)
        Me.PanelContent.Controls.Add(Me.LabelStress)
        Me.PanelContent.Controls.Add(Me.ButtonAI)
        Me.PanelContent.Controls.Add(Me.ButtonWhiteboard)
        Me.PanelContent.Controls.Add(Me.LabelDescription)
        Me.PanelContent.Controls.Add(Me.PanelDescription)
        Me.PanelContent.Controls.Add(Me.ButtonRun)
        Me.PanelContent.Controls.Add(Me.RichTextBoxCode)
        Me.PanelContent.Controls.Add(Me.LabelCode)
        Me.PanelContent.Controls.Add(Me.ButtonSaveNotes)
        Me.PanelContent.Controls.Add(Me.RichTextBoxNotes)
        Me.PanelContent.Controls.Add(Me.LabelNotes)
        Me.PanelContent.Controls.Add(Me.PanelResources)
        Me.PanelContent.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.PanelContent.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelContent.Location = New System.Drawing.Point(0, 350)
        Me.PanelContent.Name = "PanelContent"
        Me.PanelContent.Size = New System.Drawing.Size(1263, 1533)
        Me.PanelContent.TabIndex = 1
        '
        'ButtonBreak
        '
        Me.ButtonBreak.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonBreak.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ButtonBreak.Location = New System.Drawing.Point(751, 14)
        Me.ButtonBreak.Name = "ButtonBreak"
        Me.ButtonBreak.Size = New System.Drawing.Size(132, 33)
        Me.ButtonBreak.TabIndex = 13
        Me.ButtonBreak.Text = "Assign Break"
        Me.ButtonBreak.UseVisualStyleBackColor = False
        '
        'LabelStressLevel
        '
        Me.LabelStressLevel.AutoSize = True
        Me.LabelStressLevel.Font = New System.Drawing.Font("Cascadia Code SemiBold", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelStressLevel.Location = New System.Drawing.Point(493, 10)
        Me.LabelStressLevel.Name = "LabelStressLevel"
        Me.LabelStressLevel.Size = New System.Drawing.Size(161, 37)
        Me.LabelStressLevel.TabIndex = 12
        Me.LabelStressLevel.Text = "Level: --"
        '
        'LabelStress
        '
        Me.LabelStress.AutoSize = True
        Me.LabelStress.Font = New System.Drawing.Font("Cascadia Code SemiBold", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelStress.Location = New System.Drawing.Point(239, 10)
        Me.LabelStress.Name = "LabelStress"
        Me.LabelStress.Size = New System.Drawing.Size(177, 37)
        Me.LabelStress.TabIndex = 11
        Me.LabelStress.Text = "Stress: --"
        '
        'ButtonAI
        '
        Me.ButtonAI.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonAI.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ButtonAI.Location = New System.Drawing.Point(131, 14)
        Me.ButtonAI.Name = "ButtonAI"
        Me.ButtonAI.Size = New System.Drawing.Size(90, 33)
        Me.ButtonAI.TabIndex = 10
        Me.ButtonAI.Text = "Start AI"
        Me.ButtonAI.UseVisualStyleBackColor = False
        '
        'ButtonWhiteboard
        '
        Me.ButtonWhiteboard.BackColor = System.Drawing.SystemColors.Control
        Me.ButtonWhiteboard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButtonWhiteboard.FlatAppearance.BorderSize = 0
        Me.ButtonWhiteboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonWhiteboard.Location = New System.Drawing.Point(150, 448)
        Me.ButtonWhiteboard.Name = "ButtonWhiteboard"
        Me.ButtonWhiteboard.Size = New System.Drawing.Size(151, 33)
        Me.ButtonWhiteboard.TabIndex = 9
        Me.ButtonWhiteboard.Text = "Open WhiteBoard" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.ButtonWhiteboard.UseVisualStyleBackColor = False
        '
        'LabelDescription
        '
        Me.LabelDescription.AutoSize = True
        Me.LabelDescription.Location = New System.Drawing.Point(25, 1095)
        Me.LabelDescription.Name = "LabelDescription"
        Me.LabelDescription.Size = New System.Drawing.Size(75, 16)
        Me.LabelDescription.TabIndex = 8
        Me.LabelDescription.Text = "Description"
        '
        'PanelDescription
        '
        Me.PanelDescription.BackColor = System.Drawing.SystemColors.Control
        Me.PanelDescription.Controls.Add(Me.RichTextBox1)
        Me.PanelDescription.Location = New System.Drawing.Point(3, 1131)
        Me.PanelDescription.Name = "PanelDescription"
        Me.PanelDescription.Size = New System.Drawing.Size(880, 399)
        Me.PanelDescription.TabIndex = 7
        '
        'RichTextBox1
        '
        Me.RichTextBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.RichTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.RichTextBox1.Location = New System.Drawing.Point(16, 21)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.ReadOnly = True
        Me.RichTextBox1.Size = New System.Drawing.Size(840, 352)
        Me.RichTextBox1.TabIndex = 0
        Me.RichTextBox1.Text = ""
        '
        'ButtonRun
        '
        Me.ButtonRun.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonRun.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ButtonRun.Location = New System.Drawing.Point(19, 995)
        Me.ButtonRun.Name = "ButtonRun"
        Me.ButtonRun.Size = New System.Drawing.Size(90, 33)
        Me.ButtonRun.TabIndex = 6
        Me.ButtonRun.Text = "Run"
        Me.ButtonRun.UseVisualStyleBackColor = False
        '
        'RichTextBoxCode
        '
        Me.RichTextBoxCode.Location = New System.Drawing.Point(19, 542)
        Me.RichTextBoxCode.Name = "RichTextBoxCode"
        Me.RichTextBoxCode.Size = New System.Drawing.Size(864, 424)
        Me.RichTextBoxCode.TabIndex = 5
        Me.RichTextBoxCode.Text = ""
        '
        'LabelCode
        '
        Me.LabelCode.AutoSize = True
        Me.LabelCode.Location = New System.Drawing.Point(16, 498)
        Me.LabelCode.Name = "LabelCode"
        Me.LabelCode.Size = New System.Drawing.Size(97, 16)
        Me.LabelCode.TabIndex = 4
        Me.LabelCode.Text = "Code Complier"
        '
        'ButtonSaveNotes
        '
        Me.ButtonSaveNotes.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonSaveNotes.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ButtonSaveNotes.Location = New System.Drawing.Point(19, 448)
        Me.ButtonSaveNotes.Name = "ButtonSaveNotes"
        Me.ButtonSaveNotes.Size = New System.Drawing.Size(90, 33)
        Me.ButtonSaveNotes.TabIndex = 3
        Me.ButtonSaveNotes.Text = "Save"
        Me.ButtonSaveNotes.UseVisualStyleBackColor = False
        '
        'RichTextBoxNotes
        '
        Me.RichTextBoxNotes.Location = New System.Drawing.Point(19, 55)
        Me.RichTextBoxNotes.Name = "RichTextBoxNotes"
        Me.RichTextBoxNotes.Size = New System.Drawing.Size(864, 375)
        Me.RichTextBoxNotes.TabIndex = 2
        Me.RichTextBoxNotes.Text = ""
        '
        'LabelNotes
        '
        Me.LabelNotes.AutoSize = True
        Me.LabelNotes.Font = New System.Drawing.Font("Cascadia Code SemiBold", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelNotes.Location = New System.Drawing.Point(12, 14)
        Me.LabelNotes.Name = "LabelNotes"
        Me.LabelNotes.Size = New System.Drawing.Size(97, 37)
        Me.LabelNotes.TabIndex = 1
        Me.LabelNotes.Text = "Notes"
        '
        'PanelResources
        '
        Me.PanelResources.BackColor = System.Drawing.Color.White
        Me.PanelResources.Controls.Add(Me.LabelStatus)
        Me.PanelResources.Controls.Add(Me.ButtonEncrypt)
        Me.PanelResources.Controls.Add(Me.ButtonDecrypt)
        Me.PanelResources.Controls.Add(Me.TextBoxKey)
        Me.PanelResources.Controls.Add(Me.Label2)
        Me.PanelResources.Controls.Add(Me.ButtonDownload)
        Me.PanelResources.Controls.Add(Me.ResourceList)
        Me.PanelResources.Controls.Add(Me.Label1)
        Me.PanelResources.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelResources.Location = New System.Drawing.Point(1013, 0)
        Me.PanelResources.Name = "PanelResources"
        Me.PanelResources.Size = New System.Drawing.Size(250, 1533)
        Me.PanelResources.TabIndex = 0
        '
        'LabelStatus
        '
        Me.LabelStatus.AutoSize = True
        Me.LabelStatus.Location = New System.Drawing.Point(82, 344)
        Me.LabelStatus.Name = "LabelStatus"
        Me.LabelStatus.Size = New System.Drawing.Size(48, 16)
        Me.LabelStatus.TabIndex = 7
        Me.LabelStatus.Text = "Label3"
        '
        'ButtonEncrypt
        '
        Me.ButtonEncrypt.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ButtonEncrypt.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ButtonEncrypt.Font = New System.Drawing.Font("Microsoft Tai Le", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonEncrypt.Location = New System.Drawing.Point(147, 298)
        Me.ButtonEncrypt.Name = "ButtonEncrypt"
        Me.ButtonEncrypt.Size = New System.Drawing.Size(100, 23)
        Me.ButtonEncrypt.TabIndex = 6
        Me.ButtonEncrypt.Text = "Encrypt"
        Me.ButtonEncrypt.UseVisualStyleBackColor = True
        '
        'ButtonDecrypt
        '
        Me.ButtonDecrypt.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ButtonDecrypt.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ButtonDecrypt.Font = New System.Drawing.Font("Microsoft Tai Le", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonDecrypt.Location = New System.Drawing.Point(19, 298)
        Me.ButtonDecrypt.Name = "ButtonDecrypt"
        Me.ButtonDecrypt.Size = New System.Drawing.Size(100, 23)
        Me.ButtonDecrypt.TabIndex = 5
        Me.ButtonDecrypt.Text = "Decrypt"
        Me.ButtonDecrypt.UseVisualStyleBackColor = True
        '
        'TextBoxKey
        '
        Me.TextBoxKey.Location = New System.Drawing.Point(39, 193)
        Me.TextBoxKey.Name = "TextBoxKey"
        Me.TextBoxKey.Size = New System.Drawing.Size(192, 22)
        Me.TextBoxKey.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(57, 148)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(157, 24)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Unlock Resourses"
        '
        'ButtonDownload
        '
        Me.ButtonDownload.BackColor = System.Drawing.Color.Beige
        Me.ButtonDownload.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ButtonDownload.Font = New System.Drawing.Font("Microsoft Tai Le", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonDownload.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.ButtonDownload.Location = New System.Drawing.Point(84, 259)
        Me.ButtonDownload.Name = "ButtonDownload"
        Me.ButtonDownload.Size = New System.Drawing.Size(100, 23)
        Me.ButtonDownload.TabIndex = 2
        Me.ButtonDownload.Text = "Download"
        Me.ButtonDownload.UseVisualStyleBackColor = False
        '
        'ResourceList
        '
        Me.ResourceList.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ResourceList.Font = New System.Drawing.Font("Century Gothic", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ResourceList.FormattingEnabled = True
        Me.ResourceList.ItemHeight = 17
        Me.ResourceList.Items.AddRange(New Object() {"* PDF", "", "* SPECIAL ITEMS"})
        Me.ResourceList.Location = New System.Drawing.Point(48, 67)
        Me.ResourceList.Name = "ResourceList"
        Me.ResourceList.Size = New System.Drawing.Size(120, 85)
        Me.ResourceList.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(80, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(109, 28)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Resources"
        '
        'Form6
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1284, 558)
        Me.Controls.Add(Me.PanelContent)
        Me.Controls.Add(Me.PanelVideo)
        Me.Name = "Form6"
        Me.Text = "Form6"
        Me.PanelVideo.ResumeLayout(False)
        Me.PanelCamera.ResumeLayout(False)
        CType(Me.PictureBoxHostView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AxWindowsMediaPlayer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelContent.ResumeLayout(False)
        Me.PanelContent.PerformLayout()
        Me.PanelDescription.ResumeLayout(False)
        Me.PanelResources.ResumeLayout(False)
        Me.PanelResources.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PanelVideo As Panel
    Friend WithEvents PanelContent As Panel
    Friend WithEvents AxWindowsMediaPlayer1 As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents PanelResources As Panel
    Friend WithEvents ResourceList As ListBox
    Friend WithEvents Label1 As Label
    Friend WithEvents ButtonDownload As Button
    Friend WithEvents TextBoxKey As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents LabelStatus As Label
    Friend WithEvents ButtonEncrypt As Button
    Friend WithEvents ButtonDecrypt As Button
    Friend WithEvents LabelNotes As Label
    Friend WithEvents ButtonSaveNotes As Button
    Friend WithEvents RichTextBoxNotes As RichTextBox
    Friend WithEvents ButtonRun As Button
    Friend WithEvents RichTextBoxCode As RichTextBox
    Friend WithEvents LabelCode As Label
    Friend WithEvents LabelDescription As Label
    Friend WithEvents PanelDescription As Panel
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents ButtonWhiteboard As Button
    Friend WithEvents PanelCamera As Panel
    Friend WithEvents ButtonBreak As Button
    Friend WithEvents LabelStressLevel As Label
    Friend WithEvents LabelStress As Label
    Friend WithEvents ButtonAI As Button
    Friend WithEvents PictureBoxHostView As PictureBox
End Class
