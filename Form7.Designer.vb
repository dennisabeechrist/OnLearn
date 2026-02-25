<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form7
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form7))
        Me.PanelCanvas = New System.Windows.Forms.Panel()
        Me.PanelTools = New System.Windows.Forms.Panel()
        Me.ButtonClear = New System.Windows.Forms.Button()
        Me.ButtonColor = New System.Windows.Forms.Button()
        Me.ButtonShape = New System.Windows.Forms.Button()
        Me.ButtonEraser = New System.Windows.Forms.Button()
        Me.ButtonPen = New System.Windows.Forms.Button()
        Me.ButtonPencil = New System.Windows.Forms.Button()
        Me.PanelTop = New System.Windows.Forms.Panel()
        Me.ButtonSaveState = New System.Windows.Forms.Button()
        Me.ButtonNew = New System.Windows.Forms.Button()
        Me.ButtonSaveAs = New System.Windows.Forms.Button()
        Me.LabelMode = New System.Windows.Forms.Label()
        Me.ButtonReturn = New System.Windows.Forms.Button()
        Me.PanelCanvas.SuspendLayout()
        Me.PanelTools.SuspendLayout()
        Me.PanelTop.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelCanvas
        '
        Me.PanelCanvas.BackColor = System.Drawing.Color.White
        Me.PanelCanvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelCanvas.Controls.Add(Me.PanelTools)
        Me.PanelCanvas.Controls.Add(Me.PanelTop)
        Me.PanelCanvas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelCanvas.Location = New System.Drawing.Point(0, 0)
        Me.PanelCanvas.Name = "PanelCanvas"
        Me.PanelCanvas.Size = New System.Drawing.Size(1193, 582)
        Me.PanelCanvas.TabIndex = 0
        '
        'PanelTools
        '
        Me.PanelTools.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PanelTools.Controls.Add(Me.ButtonClear)
        Me.PanelTools.Controls.Add(Me.ButtonColor)
        Me.PanelTools.Controls.Add(Me.ButtonShape)
        Me.PanelTools.Controls.Add(Me.ButtonEraser)
        Me.PanelTools.Controls.Add(Me.ButtonPen)
        Me.PanelTools.Controls.Add(Me.ButtonPencil)
        Me.PanelTools.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelTools.Location = New System.Drawing.Point(0, 60)
        Me.PanelTools.Name = "PanelTools"
        Me.PanelTools.Size = New System.Drawing.Size(1191, 63)
        Me.PanelTools.TabIndex = 1
        '
        'ButtonClear
        '
        Me.ButtonClear.BackgroundImage = CType(resources.GetObject("ButtonClear.BackgroundImage"), System.Drawing.Image)
        Me.ButtonClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ButtonClear.FlatAppearance.BorderSize = 0
        Me.ButtonClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonClear.Location = New System.Drawing.Point(374, 9)
        Me.ButtonClear.Name = "ButtonClear"
        Me.ButtonClear.Size = New System.Drawing.Size(38, 41)
        Me.ButtonClear.TabIndex = 5
        Me.ButtonClear.UseVisualStyleBackColor = True
        '
        'ButtonColor
        '
        Me.ButtonColor.BackgroundImage = CType(resources.GetObject("ButtonColor.BackgroundImage"), System.Drawing.Image)
        Me.ButtonColor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ButtonColor.FlatAppearance.BorderSize = 0
        Me.ButtonColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonColor.Location = New System.Drawing.Point(312, 9)
        Me.ButtonColor.Name = "ButtonColor"
        Me.ButtonColor.Size = New System.Drawing.Size(38, 41)
        Me.ButtonColor.TabIndex = 4
        Me.ButtonColor.UseVisualStyleBackColor = True
        '
        'ButtonShape
        '
        Me.ButtonShape.BackgroundImage = CType(resources.GetObject("ButtonShape.BackgroundImage"), System.Drawing.Image)
        Me.ButtonShape.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ButtonShape.FlatAppearance.BorderSize = 0
        Me.ButtonShape.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonShape.Location = New System.Drawing.Point(241, 9)
        Me.ButtonShape.Name = "ButtonShape"
        Me.ButtonShape.Size = New System.Drawing.Size(38, 41)
        Me.ButtonShape.TabIndex = 3
        Me.ButtonShape.UseVisualStyleBackColor = True
        '
        'ButtonEraser
        '
        Me.ButtonEraser.BackgroundImage = CType(resources.GetObject("ButtonEraser.BackgroundImage"), System.Drawing.Image)
        Me.ButtonEraser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ButtonEraser.FlatAppearance.BorderSize = 0
        Me.ButtonEraser.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonEraser.Location = New System.Drawing.Point(166, 9)
        Me.ButtonEraser.Name = "ButtonEraser"
        Me.ButtonEraser.Size = New System.Drawing.Size(38, 41)
        Me.ButtonEraser.TabIndex = 2
        Me.ButtonEraser.UseVisualStyleBackColor = True
        '
        'ButtonPen
        '
        Me.ButtonPen.BackgroundImage = CType(resources.GetObject("ButtonPen.BackgroundImage"), System.Drawing.Image)
        Me.ButtonPen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ButtonPen.FlatAppearance.BorderSize = 0
        Me.ButtonPen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonPen.Location = New System.Drawing.Point(93, 9)
        Me.ButtonPen.Name = "ButtonPen"
        Me.ButtonPen.Size = New System.Drawing.Size(38, 41)
        Me.ButtonPen.TabIndex = 1
        Me.ButtonPen.UseVisualStyleBackColor = True
        '
        'ButtonPencil
        '
        Me.ButtonPencil.BackgroundImage = CType(resources.GetObject("ButtonPencil.BackgroundImage"), System.Drawing.Image)
        Me.ButtonPencil.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ButtonPencil.FlatAppearance.BorderSize = 0
        Me.ButtonPencil.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonPencil.Location = New System.Drawing.Point(24, 9)
        Me.ButtonPencil.Name = "ButtonPencil"
        Me.ButtonPencil.Size = New System.Drawing.Size(38, 41)
        Me.ButtonPencil.TabIndex = 0
        Me.ButtonPencil.UseVisualStyleBackColor = True
        '
        'PanelTop
        '
        Me.PanelTop.BackColor = System.Drawing.Color.Lavender
        Me.PanelTop.Controls.Add(Me.ButtonSaveState)
        Me.PanelTop.Controls.Add(Me.ButtonNew)
        Me.PanelTop.Controls.Add(Me.ButtonSaveAs)
        Me.PanelTop.Controls.Add(Me.LabelMode)
        Me.PanelTop.Controls.Add(Me.ButtonReturn)
        Me.PanelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelTop.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.PanelTop.Location = New System.Drawing.Point(0, 0)
        Me.PanelTop.Name = "PanelTop"
        Me.PanelTop.Size = New System.Drawing.Size(1191, 60)
        Me.PanelTop.TabIndex = 0
        '
        'ButtonSaveState
        '
        Me.ButtonSaveState.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ButtonSaveState.Location = New System.Drawing.Point(93, 10)
        Me.ButtonSaveState.Name = "ButtonSaveState"
        Me.ButtonSaveState.Size = New System.Drawing.Size(101, 40)
        Me.ButtonSaveState.TabIndex = 8
        Me.ButtonSaveState.Text = "Save State"
        Me.ButtonSaveState.UseVisualStyleBackColor = True
        '
        'ButtonNew
        '
        Me.ButtonNew.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ButtonNew.Location = New System.Drawing.Point(198, 10)
        Me.ButtonNew.Name = "ButtonNew"
        Me.ButtonNew.Size = New System.Drawing.Size(80, 40)
        Me.ButtonNew.TabIndex = 7
        Me.ButtonNew.Text = "New"
        Me.ButtonNew.UseVisualStyleBackColor = True
        '
        'ButtonSaveAs
        '
        Me.ButtonSaveAs.BackgroundImage = CType(resources.GetObject("ButtonSaveAs.BackgroundImage"), System.Drawing.Image)
        Me.ButtonSaveAs.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ButtonSaveAs.FlatAppearance.BorderSize = 0
        Me.ButtonSaveAs.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonSaveAs.Location = New System.Drawing.Point(312, 10)
        Me.ButtonSaveAs.Name = "ButtonSaveAs"
        Me.ButtonSaveAs.Size = New System.Drawing.Size(38, 41)
        Me.ButtonSaveAs.TabIndex = 6
        Me.ButtonSaveAs.UseVisualStyleBackColor = True
        '
        'LabelMode
        '
        Me.LabelMode.AutoSize = True
        Me.LabelMode.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.LabelMode.Location = New System.Drawing.Point(1070, 23)
        Me.LabelMode.Name = "LabelMode"
        Me.LabelMode.Size = New System.Drawing.Size(88, 16)
        Me.LabelMode.TabIndex = 1
        Me.LabelMode.Text = "HOST MODE"
        '
        'ButtonReturn
        '
        Me.ButtonReturn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ButtonReturn.Location = New System.Drawing.Point(11, 11)
        Me.ButtonReturn.Name = "ButtonReturn"
        Me.ButtonReturn.Size = New System.Drawing.Size(80, 40)
        Me.ButtonReturn.TabIndex = 0
        Me.ButtonReturn.Text = "Return"
        Me.ButtonReturn.UseVisualStyleBackColor = True
        '
        'Form7
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1193, 582)
        Me.Controls.Add(Me.PanelCanvas)
        Me.Name = "Form7"
        Me.Text = "Form7"
        Me.PanelCanvas.ResumeLayout(False)
        Me.PanelTools.ResumeLayout(False)
        Me.PanelTop.ResumeLayout(False)
        Me.PanelTop.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelCanvas As Panel
    Friend WithEvents PanelTop As Panel
    Friend WithEvents PanelTools As Panel
    Friend WithEvents LabelMode As Label
    Friend WithEvents ButtonReturn As Button
    Friend WithEvents ButtonPencil As Button
    Friend WithEvents ButtonPen As Button
    Friend WithEvents ButtonClear As Button
    Friend WithEvents ButtonColor As Button
    Friend WithEvents ButtonShape As Button
    Friend WithEvents ButtonEraser As Button
    Friend WithEvents ButtonNew As Button
    Friend WithEvents ButtonSaveAs As Button
    Friend WithEvents ButtonSaveState As Button
End Class
