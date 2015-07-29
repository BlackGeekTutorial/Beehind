<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class idevicerestoreGUI
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(idevicerestoreGUI))
        Me.EraseCheckBox = New System.Windows.Forms.CheckBox()
        Me.FetchSHSHCheckBox = New System.Windows.Forms.CheckBox()
        Me.idevicerestoreIntroLabel = New System.Windows.Forms.Label()
        Me.IPSWPathTextBox = New System.Windows.Forms.TextBox()
        Me.IPSWPathLabel = New System.Windows.Forms.Label()
        Me.limera1nCheckBox = New System.Windows.Forms.CheckBox()
        Me.BrowseIPSWButtin = New System.Windows.Forms.Button()
        Me.RestoreButton = New System.Windows.Forms.Button()
        Me.IPSWFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.TargetECIDCheckBox = New System.Windows.Forms.CheckBox()
        Me.TargetUDIDCheckBox = New System.Windows.Forms.CheckBox()
        Me.VerboseCheckBox = New System.Windows.Forms.CheckBox()
        Me.CustomFWCheckBox = New System.Windows.Forms.CheckBox()
        Me.LatestInstallCheckBox = New System.Windows.Forms.CheckBox()
        Me.SaurikModeCheckBox = New System.Windows.Forms.CheckBox()
        Me.SkipNORAndBBFlashingCheckBox = New System.Windows.Forms.CheckBox()
        Me.BeehindModeCheckBox = New System.Windows.Forms.CheckBox()
        Me.CacheDirCheckBox = New System.Windows.Forms.CheckBox()
        Me.UpgradeCheckBox = New System.Windows.Forms.CheckBox()
        Me.TargetECIDTextBox = New System.Windows.Forms.RichTextBox()
        Me.TargetUDIDTextBox = New System.Windows.Forms.RichTextBox()
        Me.CacheDirPath = New System.Windows.Forms.FolderBrowserDialog()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.RestoreOptionsGroupBox = New System.Windows.Forms.GroupBox()
        Me.RestoreOptionsGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'EraseCheckBox
        '
        Me.EraseCheckBox.AutoSize = True
        Me.EraseCheckBox.Location = New System.Drawing.Point(6, 19)
        Me.EraseCheckBox.Name = "EraseCheckBox"
        Me.EraseCheckBox.Size = New System.Drawing.Size(167, 17)
        Me.EraseCheckBox.TabIndex = 1
        Me.EraseCheckBox.Text = "Customer Erase Install (IPSW)"
        Me.EraseCheckBox.UseVisualStyleBackColor = True
        '
        'FetchSHSHCheckBox
        '
        Me.FetchSHSHCheckBox.AutoSize = True
        Me.FetchSHSHCheckBox.Location = New System.Drawing.Point(6, 180)
        Me.FetchSHSHCheckBox.Name = "FetchSHSHCheckBox"
        Me.FetchSHSHCheckBox.Size = New System.Drawing.Size(237, 17)
        Me.FetchSHSHCheckBox.TabIndex = 2
        Me.FetchSHSHCheckBox.Text = "Just save SHSH Blobs for the given firmware"
        Me.FetchSHSHCheckBox.UseVisualStyleBackColor = True
        '
        'idevicerestoreIntroLabel
        '
        Me.idevicerestoreIntroLabel.AutoSize = True
        Me.idevicerestoreIntroLabel.Location = New System.Drawing.Point(9, 9)
        Me.idevicerestoreIntroLabel.Name = "idevicerestoreIntroLabel"
        Me.idevicerestoreIntroLabel.Size = New System.Drawing.Size(733, 39)
        Me.idevicerestoreIntroLabel.TabIndex = 3
        Me.idevicerestoreIntroLabel.Text = resources.GetString("idevicerestoreIntroLabel.Text")
        '
        'IPSWPathTextBox
        '
        Me.IPSWPathTextBox.Location = New System.Drawing.Point(76, 437)
        Me.IPSWPathTextBox.Name = "IPSWPathTextBox"
        Me.IPSWPathTextBox.ReadOnly = True
        Me.IPSWPathTextBox.Size = New System.Drawing.Size(629, 20)
        Me.IPSWPathTextBox.TabIndex = 5
        '
        'IPSWPathLabel
        '
        Me.IPSWPathLabel.AutoSize = True
        Me.IPSWPathLabel.Location = New System.Drawing.Point(12, 444)
        Me.IPSWPathLabel.Name = "IPSWPathLabel"
        Me.IPSWPathLabel.Size = New System.Drawing.Size(63, 13)
        Me.IPSWPathLabel.TabIndex = 6
        Me.IPSWPathLabel.Text = "IPSW Path:"
        '
        'limera1nCheckBox
        '
        Me.limera1nCheckBox.AutoSize = True
        Me.limera1nCheckBox.Location = New System.Drawing.Point(6, 134)
        Me.limera1nCheckBox.Name = "limera1nCheckBox"
        Me.limera1nCheckBox.Size = New System.Drawing.Size(254, 17)
        Me.limera1nCheckBox.TabIndex = 7
        Me.limera1nCheckBox.Text = "Exploit with limera1n (only A4 and lower devices)"
        Me.limera1nCheckBox.UseVisualStyleBackColor = True
        '
        'BrowseIPSWButtin
        '
        Me.BrowseIPSWButtin.Location = New System.Drawing.Point(711, 437)
        Me.BrowseIPSWButtin.Name = "BrowseIPSWButtin"
        Me.BrowseIPSWButtin.Size = New System.Drawing.Size(40, 19)
        Me.BrowseIPSWButtin.TabIndex = 8
        Me.BrowseIPSWButtin.Text = "..."
        Me.BrowseIPSWButtin.UseVisualStyleBackColor = True
        '
        'RestoreButton
        '
        Me.RestoreButton.Enabled = False
        Me.RestoreButton.Location = New System.Drawing.Point(12, 463)
        Me.RestoreButton.Name = "RestoreButton"
        Me.RestoreButton.Size = New System.Drawing.Size(739, 23)
        Me.RestoreButton.TabIndex = 9
        Me.RestoreButton.Text = "Restore!"
        Me.RestoreButton.UseVisualStyleBackColor = True
        '
        'IPSWFileDialog
        '
        Me.IPSWFileDialog.FileName = "OpenFileDialog1"
        '
        'TargetECIDCheckBox
        '
        Me.TargetECIDCheckBox.AutoSize = True
        Me.TargetECIDCheckBox.Location = New System.Drawing.Point(367, 19)
        Me.TargetECIDCheckBox.Name = "TargetECIDCheckBox"
        Me.TargetECIDCheckBox.Size = New System.Drawing.Size(242, 17)
        Me.TargetECIDCheckBox.TabIndex = 11
        Me.TargetECIDCheckBox.Text = "Connect to the device with this spacific ECID:"
        Me.TargetECIDCheckBox.UseVisualStyleBackColor = True
        '
        'TargetUDIDCheckBox
        '
        Me.TargetUDIDCheckBox.AutoSize = True
        Me.TargetUDIDCheckBox.Location = New System.Drawing.Point(367, 42)
        Me.TargetUDIDCheckBox.Name = "TargetUDIDCheckBox"
        Me.TargetUDIDCheckBox.Size = New System.Drawing.Size(244, 17)
        Me.TargetUDIDCheckBox.TabIndex = 12
        Me.TargetUDIDCheckBox.Text = "Connect to the device with this spacific UDID:"
        Me.TargetUDIDCheckBox.UseVisualStyleBackColor = True
        '
        'VerboseCheckBox
        '
        Me.VerboseCheckBox.AutoSize = True
        Me.VerboseCheckBox.Location = New System.Drawing.Point(367, 65)
        Me.VerboseCheckBox.Name = "VerboseCheckBox"
        Me.VerboseCheckBox.Size = New System.Drawing.Size(165, 17)
        Me.VerboseCheckBox.TabIndex = 13
        Me.VerboseCheckBox.Text = "Show debugging informations"
        Me.VerboseCheckBox.UseVisualStyleBackColor = True
        '
        'CustomFWCheckBox
        '
        Me.CustomFWCheckBox.AutoSize = True
        Me.CustomFWCheckBox.Location = New System.Drawing.Point(6, 157)
        Me.CustomFWCheckBox.Name = "CustomFWCheckBox"
        Me.CustomFWCheckBox.Size = New System.Drawing.Size(163, 17)
        Me.CustomFWCheckBox.TabIndex = 14
        Me.CustomFWCheckBox.Text = "Restore to a custom firmware"
        Me.CustomFWCheckBox.UseVisualStyleBackColor = True
        '
        'LatestInstallCheckBox
        '
        Me.LatestInstallCheckBox.AutoSize = True
        Me.LatestInstallCheckBox.Location = New System.Drawing.Point(6, 65)
        Me.LatestInstallCheckBox.Name = "LatestInstallCheckBox"
        Me.LatestInstallCheckBox.Size = New System.Drawing.Size(230, 17)
        Me.LatestInstallCheckBox.TabIndex = 15
        Me.LatestInstallCheckBox.Text = "Download and restore to the latest firmware"
        Me.LatestInstallCheckBox.UseVisualStyleBackColor = True
        '
        'SaurikModeCheckBox
        '
        Me.SaurikModeCheckBox.AutoSize = True
        Me.SaurikModeCheckBox.Location = New System.Drawing.Point(6, 203)
        Me.SaurikModeCheckBox.Name = "SaurikModeCheckBox"
        Me.SaurikModeCheckBox.Size = New System.Drawing.Size(269, 17)
        Me.SaurikModeCheckBox.TabIndex = 16
        Me.SaurikModeCheckBox.Text = "Listen to Saurik's TSS server instead of Apple's one"
        Me.SaurikModeCheckBox.UseVisualStyleBackColor = True
        '
        'SkipNORAndBBFlashingCheckBox
        '
        Me.SkipNORAndBBFlashingCheckBox.AutoSize = True
        Me.SkipNORAndBBFlashingCheckBox.Location = New System.Drawing.Point(367, 88)
        Me.SkipNORAndBBFlashingCheckBox.Name = "SkipNORAndBBFlashingCheckBox"
        Me.SkipNORAndBBFlashingCheckBox.Size = New System.Drawing.Size(190, 17)
        Me.SkipNORAndBBFlashingCheckBox.TabIndex = 17
        Me.SkipNORAndBBFlashingCheckBox.Text = "Avoid baseband and NOR flashing"
        Me.SkipNORAndBBFlashingCheckBox.UseVisualStyleBackColor = True
        '
        'BeehindModeCheckBox
        '
        Me.BeehindModeCheckBox.AutoSize = True
        Me.BeehindModeCheckBox.Location = New System.Drawing.Point(6, 111)
        Me.BeehindModeCheckBox.Name = "BeehindModeCheckBox"
        Me.BeehindModeCheckBox.Size = New System.Drawing.Size(308, 17)
        Me.BeehindModeCheckBox.TabIndex = 18
        Me.BeehindModeCheckBox.Text = "Restore to a Beehind custom firmware (only if it's pre-signed)"
        Me.BeehindModeCheckBox.UseVisualStyleBackColor = True
        '
        'CacheDirCheckBox
        '
        Me.CacheDirCheckBox.AutoSize = True
        Me.CacheDirCheckBox.Location = New System.Drawing.Point(367, 111)
        Me.CacheDirCheckBox.Name = "CacheDirCheckBox"
        Me.CacheDirCheckBox.Size = New System.Drawing.Size(179, 17)
        Me.CacheDirCheckBox.TabIndex = 19
        Me.CacheDirCheckBox.Text = "Use a different caching directory"
        Me.CacheDirCheckBox.UseVisualStyleBackColor = True
        '
        'UpgradeCheckBox
        '
        Me.UpgradeCheckBox.AutoSize = True
        Me.UpgradeCheckBox.Location = New System.Drawing.Point(6, 42)
        Me.UpgradeCheckBox.Name = "UpgradeCheckBox"
        Me.UpgradeCheckBox.Size = New System.Drawing.Size(181, 17)
        Me.UpgradeCheckBox.TabIndex = 20
        Me.UpgradeCheckBox.Text = "Customer Upgrade Install (IPSW)"
        Me.UpgradeCheckBox.UseVisualStyleBackColor = True
        '
        'TargetECIDTextBox
        '
        Me.TargetECIDTextBox.Location = New System.Drawing.Point(606, 17)
        Me.TargetECIDTextBox.Name = "TargetECIDTextBox"
        Me.TargetECIDTextBox.Size = New System.Drawing.Size(124, 19)
        Me.TargetECIDTextBox.TabIndex = 22
        Me.TargetECIDTextBox.Text = ""
        '
        'TargetUDIDTextBox
        '
        Me.TargetUDIDTextBox.Location = New System.Drawing.Point(606, 41)
        Me.TargetUDIDTextBox.Name = "TargetUDIDTextBox"
        Me.TargetUDIDTextBox.Size = New System.Drawing.Size(124, 19)
        Me.TargetUDIDTextBox.TabIndex = 23
        Me.TargetUDIDTextBox.Text = ""
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(6, 88)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(231, 17)
        Me.CheckBox1.TabIndex = 24
        Me.CheckBox1.Text = "Download and update to the latest firmware"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'RestoreOptionsGroupBox
        '
        Me.RestoreOptionsGroupBox.Controls.Add(Me.CheckBox1)
        Me.RestoreOptionsGroupBox.Controls.Add(Me.EraseCheckBox)
        Me.RestoreOptionsGroupBox.Controls.Add(Me.TargetUDIDTextBox)
        Me.RestoreOptionsGroupBox.Controls.Add(Me.FetchSHSHCheckBox)
        Me.RestoreOptionsGroupBox.Controls.Add(Me.TargetECIDTextBox)
        Me.RestoreOptionsGroupBox.Controls.Add(Me.limera1nCheckBox)
        Me.RestoreOptionsGroupBox.Controls.Add(Me.UpgradeCheckBox)
        Me.RestoreOptionsGroupBox.Controls.Add(Me.TargetECIDCheckBox)
        Me.RestoreOptionsGroupBox.Controls.Add(Me.CacheDirCheckBox)
        Me.RestoreOptionsGroupBox.Controls.Add(Me.TargetUDIDCheckBox)
        Me.RestoreOptionsGroupBox.Controls.Add(Me.BeehindModeCheckBox)
        Me.RestoreOptionsGroupBox.Controls.Add(Me.VerboseCheckBox)
        Me.RestoreOptionsGroupBox.Controls.Add(Me.SkipNORAndBBFlashingCheckBox)
        Me.RestoreOptionsGroupBox.Controls.Add(Me.CustomFWCheckBox)
        Me.RestoreOptionsGroupBox.Controls.Add(Me.SaurikModeCheckBox)
        Me.RestoreOptionsGroupBox.Controls.Add(Me.LatestInstallCheckBox)
        Me.RestoreOptionsGroupBox.Location = New System.Drawing.Point(12, 85)
        Me.RestoreOptionsGroupBox.Name = "RestoreOptionsGroupBox"
        Me.RestoreOptionsGroupBox.Size = New System.Drawing.Size(739, 234)
        Me.RestoreOptionsGroupBox.TabIndex = 25
        Me.RestoreOptionsGroupBox.TabStop = False
        Me.RestoreOptionsGroupBox.Text = "Restore Options:"
        '
        'idevicerestoreGUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(763, 497)
        Me.Controls.Add(Me.RestoreButton)
        Me.Controls.Add(Me.BrowseIPSWButtin)
        Me.Controls.Add(Me.IPSWPathLabel)
        Me.Controls.Add(Me.IPSWPathTextBox)
        Me.Controls.Add(Me.idevicerestoreIntroLabel)
        Me.Controls.Add(Me.RestoreOptionsGroupBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "idevicerestoreGUI"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "idevicerestore"
        Me.RestoreOptionsGroupBox.ResumeLayout(False)
        Me.RestoreOptionsGroupBox.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents EraseCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents FetchSHSHCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents idevicerestoreIntroLabel As System.Windows.Forms.Label
    Friend WithEvents IPSWPathTextBox As System.Windows.Forms.TextBox
    Friend WithEvents IPSWPathLabel As System.Windows.Forms.Label
    Friend WithEvents limera1nCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents BrowseIPSWButtin As System.Windows.Forms.Button
    Friend WithEvents RestoreButton As System.Windows.Forms.Button
    Friend WithEvents IPSWFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents TargetECIDCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents TargetUDIDCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents VerboseCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents CustomFWCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents LatestInstallCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents SaurikModeCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents SkipNORAndBBFlashingCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents BeehindModeCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents CacheDirCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents UpgradeCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents TargetECIDTextBox As System.Windows.Forms.RichTextBox
    Friend WithEvents TargetUDIDTextBox As System.Windows.Forms.RichTextBox
    Friend WithEvents CacheDirPath As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents RestoreOptionsGroupBox As System.Windows.Forms.GroupBox
End Class
