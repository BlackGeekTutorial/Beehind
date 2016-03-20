<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Save_SHSH
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
        Me.components = New System.ComponentModel.Container()
        Me.itunesname_var = New System.Windows.Forms.Label()
        Me.SHSHProgressBar = New System.Windows.Forms.ProgressBar()
        Me.SaveSHSHButton = New System.Windows.Forms.Button()
        Me.idle = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.DeviceIcon = New System.Windows.Forms.PictureBox()
        Me.CableIcon = New System.Windows.Forms.PictureBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.ChangeSavingPathBtn = New System.Windows.Forms.Button()
        Me.SavingPath = New System.Windows.Forms.TextBox()
        Me.SavingSHSH_label = New System.Windows.Forms.Label()
        Me.FetchOTABlobsCheckBox = New System.Windows.Forms.CheckBox()
        Me.FetchCydiaBlobsCheckBox = New System.Windows.Forms.CheckBox()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Type_label = New System.Windows.Forms.Label()
        Me.Version_label = New System.Windows.Forms.Label()
        Me.Version_var = New System.Windows.Forms.Label()
        Me.UDID_var = New System.Windows.Forms.Label()
        Me.ECID_var = New System.Windows.Forms.Label()
        Me.ECID_label = New System.Windows.Forms.Label()
        Me.Type_var = New System.Windows.Forms.Label()
        Me.UDID_label = New System.Windows.Forms.Label()
        Me.SHSHTabControl = New System.Windows.Forms.TabControl()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.DeviceChecker = New System.Windows.Forms.Timer(Me.components)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DeviceIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CableIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.SHSHTabControl.SuspendLayout()
        Me.SuspendLayout()
        '
        'itunesname_var
        '
        Me.itunesname_var.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.itunesname_var.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.itunesname_var.Location = New System.Drawing.Point(2, 7)
        Me.itunesname_var.Name = "itunesname_var"
        Me.itunesname_var.Size = New System.Drawing.Size(759, 16)
        Me.itunesname_var.TabIndex = 14
        Me.itunesname_var.Text = "Connect an iOS Device"
        Me.itunesname_var.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'SHSHProgressBar
        '
        Me.SHSHProgressBar.Location = New System.Drawing.Point(12, 470)
        Me.SHSHProgressBar.Name = "SHSHProgressBar"
        Me.SHSHProgressBar.Size = New System.Drawing.Size(659, 20)
        Me.SHSHProgressBar.TabIndex = 17
        '
        'SaveSHSHButton
        '
        Me.SaveSHSHButton.Location = New System.Drawing.Point(677, 469)
        Me.SaveSHSHButton.Name = "SaveSHSHButton"
        Me.SaveSHSHButton.Size = New System.Drawing.Size(74, 21)
        Me.SaveSHSHButton.TabIndex = 18
        Me.SaveSHSHButton.Text = "Save SHSH"
        Me.SaveSHSHButton.UseVisualStyleBackColor = True
        '
        'idle
        '
        Me.idle.AutoSize = True
        Me.idle.Location = New System.Drawing.Point(9, 454)
        Me.idle.Name = "idle"
        Me.idle.Size = New System.Drawing.Size(264, 13)
        Me.idle.TabIndex = 20
        Me.idle.Text = "Press ""Save SHSH"" button to backup ALL your blobs."
        '
        'PictureBox2
        '
        Me.PictureBox2.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(116, 311)
        Me.PictureBox2.TabIndex = 3
        Me.PictureBox2.TabStop = False
        '
        'DeviceIcon
        '
        Me.DeviceIcon.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DeviceIcon.Location = New System.Drawing.Point(2, 35)
        Me.DeviceIcon.Name = "DeviceIcon"
        Me.DeviceIcon.Size = New System.Drawing.Size(759, 256)
        Me.DeviceIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.DeviceIcon.TabIndex = 1
        Me.DeviceIcon.TabStop = False
        '
        'CableIcon
        '
        Me.CableIcon.Location = New System.Drawing.Point(2, 269)
        Me.CableIcon.Name = "CableIcon"
        Me.CableIcon.Size = New System.Drawing.Size(759, 89)
        Me.CableIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.CableIcon.TabIndex = 4
        Me.CableIcon.TabStop = False
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage2.Controls.Add(Me.ChangeSavingPathBtn)
        Me.TabPage2.Controls.Add(Me.SavingPath)
        Me.TabPage2.Controls.Add(Me.SavingSHSH_label)
        Me.TabPage2.Controls.Add(Me.FetchOTABlobsCheckBox)
        Me.TabPage2.Controls.Add(Me.FetchCydiaBlobsCheckBox)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(731, 96)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Options"
        '
        'ChangeSavingPathBtn
        '
        Me.ChangeSavingPathBtn.Location = New System.Drawing.Point(518, 69)
        Me.ChangeSavingPathBtn.Name = "ChangeSavingPathBtn"
        Me.ChangeSavingPathBtn.Size = New System.Drawing.Size(74, 21)
        Me.ChangeSavingPathBtn.TabIndex = 20
        Me.ChangeSavingPathBtn.Text = "Choose"
        Me.ChangeSavingPathBtn.UseVisualStyleBackColor = True
        '
        'SavingPath
        '
        Me.SavingPath.Location = New System.Drawing.Point(130, 70)
        Me.SavingPath.Name = "SavingPath"
        Me.SavingPath.ReadOnly = True
        Me.SavingPath.Size = New System.Drawing.Size(382, 20)
        Me.SavingPath.TabIndex = 4
        '
        'SavingSHSH_label
        '
        Me.SavingSHSH_label.AutoSize = True
        Me.SavingSHSH_label.Location = New System.Drawing.Point(6, 73)
        Me.SavingSHSH_label.Name = "SavingSHSH_label"
        Me.SavingSHSH_label.Size = New System.Drawing.Size(119, 13)
        Me.SavingSHSH_label.TabIndex = 3
        Me.SavingSHSH_label.Text = "SHSH Saving directory:"
        '
        'FetchOTABlobsCheckBox
        '
        Me.FetchOTABlobsCheckBox.AutoSize = True
        Me.FetchOTABlobsCheckBox.Location = New System.Drawing.Point(6, 29)
        Me.FetchOTABlobsCheckBox.Name = "FetchOTABlobsCheckBox"
        Me.FetchOTABlobsCheckBox.Size = New System.Drawing.Size(111, 17)
        Me.FetchOTABlobsCheckBox.TabIndex = 2
        Me.FetchOTABlobsCheckBox.Text = "Fetch OTA SHSH"
        Me.FetchOTABlobsCheckBox.UseVisualStyleBackColor = True
        '
        'FetchCydiaBlobsCheckBox
        '
        Me.FetchCydiaBlobsCheckBox.AutoSize = True
        Me.FetchCydiaBlobsCheckBox.Location = New System.Drawing.Point(6, 6)
        Me.FetchCydiaBlobsCheckBox.Name = "FetchCydiaBlobsCheckBox"
        Me.FetchCydiaBlobsCheckBox.Size = New System.Drawing.Size(154, 17)
        Me.FetchCydiaBlobsCheckBox.TabIndex = 0
        Me.FetchCydiaBlobsCheckBox.Text = "Request SHSH From Cydia"
        Me.FetchCydiaBlobsCheckBox.UseVisualStyleBackColor = True
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage1.Controls.Add(Me.Type_label)
        Me.TabPage1.Controls.Add(Me.Version_label)
        Me.TabPage1.Controls.Add(Me.Version_var)
        Me.TabPage1.Controls.Add(Me.UDID_var)
        Me.TabPage1.Controls.Add(Me.ECID_var)
        Me.TabPage1.Controls.Add(Me.ECID_label)
        Me.TabPage1.Controls.Add(Me.Type_var)
        Me.TabPage1.Controls.Add(Me.UDID_label)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(731, 96)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Infos"
        '
        'Type_label
        '
        Me.Type_label.AutoSize = True
        Me.Type_label.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Type_label.Location = New System.Drawing.Point(11, 8)
        Me.Type_label.Name = "Type_label"
        Me.Type_label.Size = New System.Drawing.Size(48, 16)
        Me.Type_label.TabIndex = 0
        Me.Type_label.Text = "Type:"
        '
        'Version_label
        '
        Me.Version_label.AutoSize = True
        Me.Version_label.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Version_label.Location = New System.Drawing.Point(11, 29)
        Me.Version_label.Name = "Version_label"
        Me.Version_label.Size = New System.Drawing.Size(65, 16)
        Me.Version_label.TabIndex = 5
        Me.Version_label.Text = "Version:"
        '
        'Version_var
        '
        Me.Version_var.AutoSize = True
        Me.Version_var.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Version_var.Location = New System.Drawing.Point(73, 29)
        Me.Version_var.Name = "Version_var"
        Me.Version_var.Size = New System.Drawing.Size(27, 16)
        Me.Version_var.TabIndex = 9
        Me.Version_var.Text = "n/a"
        '
        'UDID_var
        '
        Me.UDID_var.AutoSize = True
        Me.UDID_var.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UDID_var.Location = New System.Drawing.Point(57, 49)
        Me.UDID_var.Name = "UDID_var"
        Me.UDID_var.Size = New System.Drawing.Size(27, 16)
        Me.UDID_var.TabIndex = 13
        Me.UDID_var.Text = "n/a"
        '
        'ECID_var
        '
        Me.ECID_var.AutoSize = True
        Me.ECID_var.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ECID_var.Location = New System.Drawing.Point(55, 70)
        Me.ECID_var.Name = "ECID_var"
        Me.ECID_var.Size = New System.Drawing.Size(27, 16)
        Me.ECID_var.TabIndex = 11
        Me.ECID_var.Text = "n/a"
        '
        'ECID_label
        '
        Me.ECID_label.AutoSize = True
        Me.ECID_label.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ECID_label.Location = New System.Drawing.Point(11, 70)
        Me.ECID_label.Name = "ECID_label"
        Me.ECID_label.Size = New System.Drawing.Size(47, 16)
        Me.ECID_label.TabIndex = 7
        Me.ECID_label.Text = "ECID:"
        '
        'Type_var
        '
        Me.Type_var.AutoSize = True
        Me.Type_var.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Type_var.Location = New System.Drawing.Point(55, 8)
        Me.Type_var.Name = "Type_var"
        Me.Type_var.Size = New System.Drawing.Size(27, 16)
        Me.Type_var.TabIndex = 8
        Me.Type_var.Text = "n/a"
        '
        'UDID_label
        '
        Me.UDID_label.AutoSize = True
        Me.UDID_label.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UDID_label.Location = New System.Drawing.Point(11, 50)
        Me.UDID_label.Name = "UDID_label"
        Me.UDID_label.Size = New System.Drawing.Size(49, 16)
        Me.UDID_label.TabIndex = 12
        Me.UDID_label.Text = "UDID:"
        '
        'SHSHTabControl
        '
        Me.SHSHTabControl.Controls.Add(Me.TabPage1)
        Me.SHSHTabControl.Controls.Add(Me.TabPage2)
        Me.SHSHTabControl.Location = New System.Drawing.Point(12, 329)
        Me.SHSHTabControl.Name = "SHSHTabControl"
        Me.SHSHTabControl.SelectedIndex = 0
        Me.SHSHTabControl.Size = New System.Drawing.Size(739, 122)
        Me.SHSHTabControl.TabIndex = 19
        '
        'DeviceChecker
        '
        Me.DeviceChecker.Enabled = True
        Me.DeviceChecker.Interval = 3000
        '
        'Save_SHSH
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(763, 497)
        Me.Controls.Add(Me.SaveSHSHButton)
        Me.Controls.Add(Me.idle)
        Me.Controls.Add(Me.SHSHProgressBar)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.itunesname_var)
        Me.Controls.Add(Me.DeviceIcon)
        Me.Controls.Add(Me.SHSHTabControl)
        Me.Controls.Add(Me.CableIcon)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Save_SHSH"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Save_BB_SHSH"
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DeviceIcon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CableIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.SHSHTabControl.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DeviceIcon As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents CableIcon As System.Windows.Forms.PictureBox
    Friend WithEvents itunesname_var As System.Windows.Forms.Label
    Friend WithEvents SHSHProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents SaveSHSHButton As System.Windows.Forms.Button
    Friend WithEvents idle As System.Windows.Forms.Label
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents ChangeSavingPathBtn As System.Windows.Forms.Button
    Friend WithEvents SavingPath As System.Windows.Forms.TextBox
    Friend WithEvents SavingSHSH_label As System.Windows.Forms.Label
    Friend WithEvents FetchOTABlobsCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents FetchCydiaBlobsCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Type_label As System.Windows.Forms.Label
    Friend WithEvents Version_label As System.Windows.Forms.Label
    Friend WithEvents Version_var As System.Windows.Forms.Label
    Friend WithEvents UDID_var As System.Windows.Forms.Label
    Friend WithEvents ECID_var As System.Windows.Forms.Label
    Friend WithEvents ECID_label As System.Windows.Forms.Label
    Friend WithEvents Type_var As System.Windows.Forms.Label
    Friend WithEvents UDID_label As System.Windows.Forms.Label
    Friend WithEvents SHSHTabControl As System.Windows.Forms.TabControl
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents DeviceChecker As System.Windows.Forms.Timer
End Class
