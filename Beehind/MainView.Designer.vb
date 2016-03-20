<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainView
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainView))
        Me.MagicButton = New System.Windows.Forms.Button()
        Me.BasebandCheckBox = New System.Windows.Forms.CheckBox()
        Me.BasebandComboBox = New System.Windows.Forms.ComboBox()
        Me.GeneralOptionsGroupBox = New System.Windows.Forms.GroupBox()
        Me.NoSysFlashCheckBox = New System.Windows.Forms.CheckBox()
        Me.NoNANDFlashCheckBox = New System.Windows.Forms.CheckBox()
        Me.AddCydiaCheckBox = New System.Windows.Forms.CheckBox()
        Me.AddSSHCheckBox = New System.Windows.Forms.CheckBox()
        Me.AddUntetherCheckBox = New System.Windows.Forms.CheckBox()
        Me.NewSizeUpDown = New System.Windows.Forms.NumericUpDown()
        Me.SizeTypeLabel = New System.Windows.Forms.Label()
        Me.HacktivateCheckBox = New System.Windows.Forms.CheckBox()
        Me.CustomBundleCheckBox = New System.Windows.Forms.CheckBox()
        Me.CustomSizeCheckBox = New System.Windows.Forms.CheckBox()
        Me.WelcomeLabel = New System.Windows.Forms.Label()
        Me.UpdateLabel = New System.Windows.Forms.Label()
        Me.LatestBuildLinkLabel = New System.Windows.Forms.LinkLabel()
        Me.InstructionsGroupBox = New System.Windows.Forms.GroupBox()
        Me.IntroductionLabel = New System.Windows.Forms.Label()
        Me.IPSWGroupBox = New System.Windows.Forms.GroupBox()
        Me.ChooseIPSWButton = New System.Windows.Forms.Button()
        Me.IPSWTextBox = New System.Windows.Forms.TextBox()
        Me.PathLabelIPSW = New System.Windows.Forms.Label()
        Me.SHSHGroupBox = New System.Windows.Forms.GroupBox()
        Me.CancelOTADWN = New System.Windows.Forms.Button()
        Me.ChooseSHSHButton = New System.Windows.Forms.Button()
        Me.SHSHTextBox = New System.Windows.Forms.TextBox()
        Me.PathLabelSHSH = New System.Windows.Forms.Label()
        Me.IPSWFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.SHSHFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.BasebandFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel3 = New System.Windows.Forms.LinkLabel()
        Me.DowngradeProgressBar = New System.Windows.Forms.ProgressBar()
        Me.ProgressLabel = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.MD5CheckerBW = New System.ComponentModel.BackgroundWorker()
        Me.GeneralOptionsGroupBox.SuspendLayout()
        CType(Me.NewSizeUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.InstructionsGroupBox.SuspendLayout()
        Me.IPSWGroupBox.SuspendLayout()
        Me.SHSHGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'MagicButton
        '
        Me.MagicButton.Enabled = False
        Me.MagicButton.Location = New System.Drawing.Point(648, 444)
        Me.MagicButton.Name = "MagicButton"
        Me.MagicButton.Size = New System.Drawing.Size(106, 23)
        Me.MagicButton.TabIndex = 0
        Me.MagicButton.Text = "Build IPSW!"
        Me.MagicButton.UseVisualStyleBackColor = True
        '
        'BasebandCheckBox
        '
        Me.BasebandCheckBox.AutoSize = True
        Me.BasebandCheckBox.Location = New System.Drawing.Point(9, 23)
        Me.BasebandCheckBox.Name = "BasebandCheckBox"
        Me.BasebandCheckBox.Size = New System.Drawing.Size(110, 17)
        Me.BasebandCheckBox.TabIndex = 3
        Me.BasebandCheckBox.Text = "Add baseband.tar"
        Me.BasebandCheckBox.UseVisualStyleBackColor = True
        '
        'BasebandComboBox
        '
        Me.BasebandComboBox.Enabled = False
        Me.BasebandComboBox.FormattingEnabled = True
        Me.BasebandComboBox.Items.AddRange(New Object() {"Manually select 'baseband.tar' file", "Dump it for me right now"})
        Me.BasebandComboBox.Location = New System.Drawing.Point(125, 21)
        Me.BasebandComboBox.Name = "BasebandComboBox"
        Me.BasebandComboBox.Size = New System.Drawing.Size(188, 21)
        Me.BasebandComboBox.TabIndex = 4
        '
        'GeneralOptionsGroupBox
        '
        Me.GeneralOptionsGroupBox.Controls.Add(Me.NoSysFlashCheckBox)
        Me.GeneralOptionsGroupBox.Controls.Add(Me.NoNANDFlashCheckBox)
        Me.GeneralOptionsGroupBox.Controls.Add(Me.AddCydiaCheckBox)
        Me.GeneralOptionsGroupBox.Controls.Add(Me.AddSSHCheckBox)
        Me.GeneralOptionsGroupBox.Controls.Add(Me.AddUntetherCheckBox)
        Me.GeneralOptionsGroupBox.Controls.Add(Me.NewSizeUpDown)
        Me.GeneralOptionsGroupBox.Controls.Add(Me.SizeTypeLabel)
        Me.GeneralOptionsGroupBox.Controls.Add(Me.HacktivateCheckBox)
        Me.GeneralOptionsGroupBox.Controls.Add(Me.CustomBundleCheckBox)
        Me.GeneralOptionsGroupBox.Controls.Add(Me.CustomSizeCheckBox)
        Me.GeneralOptionsGroupBox.Controls.Add(Me.BasebandComboBox)
        Me.GeneralOptionsGroupBox.Controls.Add(Me.BasebandCheckBox)
        Me.GeneralOptionsGroupBox.Location = New System.Drawing.Point(12, 192)
        Me.GeneralOptionsGroupBox.Name = "GeneralOptionsGroupBox"
        Me.GeneralOptionsGroupBox.Size = New System.Drawing.Size(742, 120)
        Me.GeneralOptionsGroupBox.TabIndex = 5
        Me.GeneralOptionsGroupBox.TabStop = False
        Me.GeneralOptionsGroupBox.Text = "Options:"
        '
        'NoSysFlashCheckBox
        '
        Me.NoSysFlashCheckBox.AutoSize = True
        Me.NoSysFlashCheckBox.Location = New System.Drawing.Point(547, 46)
        Me.NoSysFlashCheckBox.Name = "NoSysFlashCheckBox"
        Me.NoSysFlashCheckBox.Size = New System.Drawing.Size(129, 17)
        Me.NoSysFlashCheckBox.TabIndex = 19
        Me.NoSysFlashCheckBox.Text = "Avoid System flashing"
        Me.NoSysFlashCheckBox.UseVisualStyleBackColor = True
        '
        'NoNANDFlashCheckBox
        '
        Me.NoNANDFlashCheckBox.AutoSize = True
        Me.NoNANDFlashCheckBox.Location = New System.Drawing.Point(547, 23)
        Me.NoNANDFlashCheckBox.Name = "NoNANDFlashCheckBox"
        Me.NoNANDFlashCheckBox.Size = New System.Drawing.Size(122, 17)
        Me.NoNANDFlashCheckBox.TabIndex = 18
        Me.NoNANDFlashCheckBox.Text = "Avoid NOR Flashing"
        Me.NoNANDFlashCheckBox.UseVisualStyleBackColor = True
        '
        'AddCydiaCheckBox
        '
        Me.AddCydiaCheckBox.AutoSize = True
        Me.AddCydiaCheckBox.Location = New System.Drawing.Point(366, 71)
        Me.AddCydiaCheckBox.Name = "AddCydiaCheckBox"
        Me.AddCydiaCheckBox.Size = New System.Drawing.Size(82, 17)
        Me.AddCydiaCheckBox.TabIndex = 17
        Me.AddCydiaCheckBox.Text = "Install Cydia"
        Me.AddCydiaCheckBox.UseVisualStyleBackColor = True
        '
        'AddSSHCheckBox
        '
        Me.AddSSHCheckBox.AutoSize = True
        Me.AddSSHCheckBox.Location = New System.Drawing.Point(366, 47)
        Me.AddSSHCheckBox.Name = "AddSSHCheckBox"
        Me.AddSSHCheckBox.Size = New System.Drawing.Size(104, 17)
        Me.AddSSHCheckBox.TabIndex = 16
        Me.AddSSHCheckBox.Text = "Install OpenSSH"
        Me.AddSSHCheckBox.UseVisualStyleBackColor = True
        '
        'AddUntetherCheckBox
        '
        Me.AddUntetherCheckBox.AutoSize = True
        Me.AddUntetherCheckBox.Location = New System.Drawing.Point(366, 23)
        Me.AddUntetherCheckBox.Name = "AddUntetherCheckBox"
        Me.AddUntetherCheckBox.Size = New System.Drawing.Size(68, 17)
        Me.AddUntetherCheckBox.TabIndex = 15
        Me.AddUntetherCheckBox.Text = "Jailbreak"
        Me.AddUntetherCheckBox.UseVisualStyleBackColor = True
        '
        'NewSizeUpDown
        '
        Me.NewSizeUpDown.Location = New System.Drawing.Point(169, 46)
        Me.NewSizeUpDown.Maximum = New Decimal(New Integer() {5120, 0, 0, 0})
        Me.NewSizeUpDown.Minimum = New Decimal(New Integer() {1024, 0, 0, 0})
        Me.NewSizeUpDown.Name = "NewSizeUpDown"
        Me.NewSizeUpDown.Size = New System.Drawing.Size(49, 20)
        Me.NewSizeUpDown.TabIndex = 13
        Me.NewSizeUpDown.Value = New Decimal(New Integer() {1024, 0, 0, 0})
        '
        'SizeTypeLabel
        '
        Me.SizeTypeLabel.AutoSize = True
        Me.SizeTypeLabel.Location = New System.Drawing.Point(219, 50)
        Me.SizeTypeLabel.Name = "SizeTypeLabel"
        Me.SizeTypeLabel.Size = New System.Drawing.Size(23, 13)
        Me.SizeTypeLabel.TabIndex = 11
        Me.SizeTypeLabel.Text = "MB"
        '
        'HacktivateCheckBox
        '
        Me.HacktivateCheckBox.AutoSize = True
        Me.HacktivateCheckBox.Location = New System.Drawing.Point(9, 94)
        Me.HacktivateCheckBox.Name = "HacktivateCheckBox"
        Me.HacktivateCheckBox.Size = New System.Drawing.Size(78, 17)
        Me.HacktivateCheckBox.TabIndex = 9
        Me.HacktivateCheckBox.Text = "Hacktivate"
        Me.HacktivateCheckBox.UseVisualStyleBackColor = True
        '
        'CustomBundleCheckBox
        '
        Me.CustomBundleCheckBox.AutoSize = True
        Me.CustomBundleCheckBox.Location = New System.Drawing.Point(9, 71)
        Me.CustomBundleCheckBox.Name = "CustomBundleCheckBox"
        Me.CustomBundleCheckBox.Size = New System.Drawing.Size(127, 17)
        Me.CustomBundleCheckBox.TabIndex = 8
        Me.CustomBundleCheckBox.Text = "Install Custom Bundle"
        Me.CustomBundleCheckBox.UseVisualStyleBackColor = True
        '
        'CustomSizeCheckBox
        '
        Me.CustomSizeCheckBox.AutoSize = True
        Me.CustomSizeCheckBox.Location = New System.Drawing.Point(9, 48)
        Me.CustomSizeCheckBox.Name = "CustomSizeCheckBox"
        Me.CustomSizeCheckBox.Size = New System.Drawing.Size(162, 17)
        Me.CustomSizeCheckBox.TabIndex = 7
        Me.CustomSizeCheckBox.Text = "Custom System Partition Size"
        Me.CustomSizeCheckBox.UseVisualStyleBackColor = True
        '
        'WelcomeLabel
        '
        Me.WelcomeLabel.AutoSize = True
        Me.WelcomeLabel.Location = New System.Drawing.Point(12, 58)
        Me.WelcomeLabel.Name = "WelcomeLabel"
        Me.WelcomeLabel.Size = New System.Drawing.Size(517, 13)
        Me.WelcomeLabel.TabIndex = 6
        Me.WelcomeLabel.Text = "Welcome to Beehind! With this tool, you can downgrade a 32-bit iOS device (thanks" & _
    " to @winocm's kloader)!"
        '
        'UpdateLabel
        '
        Me.UpdateLabel.AutoSize = True
        Me.UpdateLabel.Location = New System.Drawing.Point(12, 9)
        Me.UpdateLabel.Name = "UpdateLabel"
        Me.UpdateLabel.Size = New System.Drawing.Size(108, 13)
        Me.UpdateLabel.TabIndex = 7
        Me.UpdateLabel.Text = "UPDATE_CHECKER"
        '
        'LatestBuildLinkLabel
        '
        Me.LatestBuildLinkLabel.AutoSize = True
        Me.LatestBuildLinkLabel.Location = New System.Drawing.Point(304, 8)
        Me.LatestBuildLinkLabel.Name = "LatestBuildLinkLabel"
        Me.LatestBuildLinkLabel.Size = New System.Drawing.Size(28, 13)
        Me.LatestBuildLinkLabel.TabIndex = 8
        Me.LatestBuildLinkLabel.TabStop = True
        Me.LatestBuildLinkLabel.Text = "here"
        Me.LatestBuildLinkLabel.Visible = False
        '
        'InstructionsGroupBox
        '
        Me.InstructionsGroupBox.Controls.Add(Me.IntroductionLabel)
        Me.InstructionsGroupBox.Location = New System.Drawing.Point(12, 83)
        Me.InstructionsGroupBox.Name = "InstructionsGroupBox"
        Me.InstructionsGroupBox.Size = New System.Drawing.Size(742, 92)
        Me.InstructionsGroupBox.TabIndex = 9
        Me.InstructionsGroupBox.TabStop = False
        Me.InstructionsGroupBox.Text = "Informations:"
        '
        'IntroductionLabel
        '
        Me.IntroductionLabel.AutoSize = True
        Me.IntroductionLabel.Location = New System.Drawing.Point(6, 17)
        Me.IntroductionLabel.Name = "IntroductionLabel"
        Me.IntroductionLabel.Size = New System.Drawing.Size(708, 65)
        Me.IntroductionLabel.TabIndex = 0
        Me.IntroductionLabel.Text = resources.GetString("IntroductionLabel.Text")
        '
        'IPSWGroupBox
        '
        Me.IPSWGroupBox.Controls.Add(Me.ChooseIPSWButton)
        Me.IPSWGroupBox.Controls.Add(Me.IPSWTextBox)
        Me.IPSWGroupBox.Controls.Add(Me.PathLabelIPSW)
        Me.IPSWGroupBox.Location = New System.Drawing.Point(12, 319)
        Me.IPSWGroupBox.Name = "IPSWGroupBox"
        Me.IPSWGroupBox.Size = New System.Drawing.Size(374, 100)
        Me.IPSWGroupBox.TabIndex = 10
        Me.IPSWGroupBox.TabStop = False
        Me.IPSWGroupBox.Text = "Browse for the IPSW"
        '
        'ChooseIPSWButton
        '
        Me.ChooseIPSWButton.Location = New System.Drawing.Point(9, 71)
        Me.ChooseIPSWButton.Name = "ChooseIPSWButton"
        Me.ChooseIPSWButton.Size = New System.Drawing.Size(353, 23)
        Me.ChooseIPSWButton.TabIndex = 12
        Me.ChooseIPSWButton.Text = "Choose"
        Me.ChooseIPSWButton.UseVisualStyleBackColor = True
        '
        'IPSWTextBox
        '
        Me.IPSWTextBox.Enabled = False
        Me.IPSWTextBox.Location = New System.Drawing.Point(9, 44)
        Me.IPSWTextBox.Name = "IPSWTextBox"
        Me.IPSWTextBox.Size = New System.Drawing.Size(353, 20)
        Me.IPSWTextBox.TabIndex = 1
        '
        'PathLabelIPSW
        '
        Me.PathLabelIPSW.AutoSize = True
        Me.PathLabelIPSW.Location = New System.Drawing.Point(6, 28)
        Me.PathLabelIPSW.Name = "PathLabelIPSW"
        Me.PathLabelIPSW.Size = New System.Drawing.Size(32, 13)
        Me.PathLabelIPSW.TabIndex = 0
        Me.PathLabelIPSW.Text = "Path:"
        '
        'SHSHGroupBox
        '
        Me.SHSHGroupBox.Controls.Add(Me.CancelOTADWN)
        Me.SHSHGroupBox.Controls.Add(Me.ChooseSHSHButton)
        Me.SHSHGroupBox.Controls.Add(Me.SHSHTextBox)
        Me.SHSHGroupBox.Controls.Add(Me.PathLabelSHSH)
        Me.SHSHGroupBox.Location = New System.Drawing.Point(392, 319)
        Me.SHSHGroupBox.Name = "SHSHGroupBox"
        Me.SHSHGroupBox.Size = New System.Drawing.Size(362, 100)
        Me.SHSHGroupBox.TabIndex = 11
        Me.SHSHGroupBox.TabStop = False
        Me.SHSHGroupBox.Text = "Browse for SHSH"
        '
        'CancelOTADWN
        '
        Me.CancelOTADWN.Location = New System.Drawing.Point(9, 56)
        Me.CancelOTADWN.Name = "CancelOTADWN"
        Me.CancelOTADWN.Size = New System.Drawing.Size(347, 23)
        Me.CancelOTADWN.TabIndex = 12
        Me.CancelOTADWN.Text = "Cancel OTA Downgrade"
        Me.CancelOTADWN.UseVisualStyleBackColor = True
        Me.CancelOTADWN.Visible = False
        '
        'ChooseSHSHButton
        '
        Me.ChooseSHSHButton.Enabled = False
        Me.ChooseSHSHButton.Location = New System.Drawing.Point(9, 71)
        Me.ChooseSHSHButton.Name = "ChooseSHSHButton"
        Me.ChooseSHSHButton.Size = New System.Drawing.Size(347, 23)
        Me.ChooseSHSHButton.TabIndex = 15
        Me.ChooseSHSHButton.Text = "Choose"
        Me.ChooseSHSHButton.UseVisualStyleBackColor = True
        '
        'SHSHTextBox
        '
        Me.SHSHTextBox.Enabled = False
        Me.SHSHTextBox.Location = New System.Drawing.Point(9, 44)
        Me.SHSHTextBox.Name = "SHSHTextBox"
        Me.SHSHTextBox.Size = New System.Drawing.Size(347, 20)
        Me.SHSHTextBox.TabIndex = 14
        '
        'PathLabelSHSH
        '
        Me.PathLabelSHSH.AutoSize = True
        Me.PathLabelSHSH.Location = New System.Drawing.Point(6, 28)
        Me.PathLabelSHSH.Name = "PathLabelSHSH"
        Me.PathLabelSHSH.Size = New System.Drawing.Size(32, 13)
        Me.PathLabelSHSH.TabIndex = 13
        Me.PathLabelSHSH.Text = "Path:"
        '
        'IPSWFileDialog
        '
        Me.IPSWFileDialog.FileName = "OpenFileDialog1"
        '
        'SHSHFileDialog
        '
        Me.SHSHFileDialog.FileName = "OpenFileDialog1"
        '
        'BasebandFileDialog
        '
        Me.BasebandFileDialog.FileName = "OpenFileDialog1"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(645, 479)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(113, 13)
        Me.LinkLabel1.TabIndex = 12
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Make me a donation :)"
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.Location = New System.Drawing.Point(350, 479)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(63, 13)
        Me.LinkLabel2.TabIndex = 13
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "My Website"
        '
        'LinkLabel3
        '
        Me.LinkLabel3.AutoSize = True
        Me.LinkLabel3.Location = New System.Drawing.Point(6, 479)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(56, 13)
        Me.LinkLabel3.TabIndex = 14
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Text = "My Twitter"
        '
        'DowngradeProgressBar
        '
        Me.DowngradeProgressBar.Location = New System.Drawing.Point(15, 444)
        Me.DowngradeProgressBar.Name = "DowngradeProgressBar"
        Me.DowngradeProgressBar.Size = New System.Drawing.Size(627, 23)
        Me.DowngradeProgressBar.TabIndex = 15
        '
        'ProgressLabel
        '
        Me.ProgressLabel.AutoSize = True
        Me.ProgressLabel.Location = New System.Drawing.Point(12, 428)
        Me.ProgressLabel.Name = "ProgressLabel"
        Me.ProgressLabel.Size = New System.Drawing.Size(38, 13)
        Me.ProgressLabel.TabIndex = 16
        Me.ProgressLabel.Text = "Ready"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(475, 13)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Copyright 2015 Andrea Bentivegna (BlackGeekTutorial). All rights reserved. Not fo" & _
    "r commercial use."
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "CustomBundleFileDialog"
        '
        'MainView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(763, 497)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ProgressLabel)
        Me.Controls.Add(Me.LinkLabel3)
        Me.Controls.Add(Me.LinkLabel2)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.SHSHGroupBox)
        Me.Controls.Add(Me.IPSWGroupBox)
        Me.Controls.Add(Me.InstructionsGroupBox)
        Me.Controls.Add(Me.LatestBuildLinkLabel)
        Me.Controls.Add(Me.UpdateLabel)
        Me.Controls.Add(Me.GeneralOptionsGroupBox)
        Me.Controls.Add(Me.WelcomeLabel)
        Me.Controls.Add(Me.MagicButton)
        Me.Controls.Add(Me.DowngradeProgressBar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "MainView"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MainView"
        Me.GeneralOptionsGroupBox.ResumeLayout(False)
        Me.GeneralOptionsGroupBox.PerformLayout()
        CType(Me.NewSizeUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        Me.InstructionsGroupBox.ResumeLayout(False)
        Me.InstructionsGroupBox.PerformLayout()
        Me.IPSWGroupBox.ResumeLayout(False)
        Me.IPSWGroupBox.PerformLayout()
        Me.SHSHGroupBox.ResumeLayout(False)
        Me.SHSHGroupBox.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MagicButton As System.Windows.Forms.Button
    Friend WithEvents BasebandCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents BasebandComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents GeneralOptionsGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents WelcomeLabel As System.Windows.Forms.Label
    Friend WithEvents UpdateLabel As System.Windows.Forms.Label
    Friend WithEvents LatestBuildLinkLabel As System.Windows.Forms.LinkLabel
    Friend WithEvents InstructionsGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents IntroductionLabel As System.Windows.Forms.Label
    Friend WithEvents IPSWGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents ChooseIPSWButton As System.Windows.Forms.Button
    Friend WithEvents IPSWTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PathLabelIPSW As System.Windows.Forms.Label
    Friend WithEvents SHSHGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents ChooseSHSHButton As System.Windows.Forms.Button
    Friend WithEvents SHSHTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PathLabelSHSH As System.Windows.Forms.Label
    Friend WithEvents IPSWFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SHSHFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents BasebandFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SizeTypeLabel As System.Windows.Forms.Label
    Friend WithEvents HacktivateCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents CustomBundleCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents CustomSizeCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents CancelOTADWN As System.Windows.Forms.Button
    Friend WithEvents NewSizeUpDown As System.Windows.Forms.NumericUpDown
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel3 As System.Windows.Forms.LinkLabel
    Friend WithEvents DowngradeProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents ProgressLabel As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents AddSSHCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents AddUntetherCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents AddCydiaCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents NoSysFlashCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents NoNANDFlashCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents MD5CheckerBW As System.ComponentModel.BackgroundWorker
End Class
