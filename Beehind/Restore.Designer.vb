<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Restore
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Restore))
        Me.RestoreIPSWPathTextBox = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.AdvancedOptionsGroupBox = New System.Windows.Forms.GroupBox()
        Me.LatestBootchainCheckBox = New System.Windows.Forms.CheckBox()
        Me.SkipNORCheckBox = New System.Windows.Forms.CheckBox()
        Me.TSSRestoreCheckBox = New System.Windows.Forms.CheckBox()
        Me.KloaderRestoreCheckBox = New System.Windows.Forms.CheckBox()
        Me.RawRestoreConsole = New System.Windows.Forms.RichTextBox()
        Me.StatusLabel = New System.Windows.Forms.Label()
        Me.WelcomeLabel = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.IPSWToRestoreFD = New System.Windows.Forms.OpenFileDialog()
        Me.RestoreConsoleLabel = New System.Windows.Forms.Label()
        Me.AdvancedOptionsGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'RestoreIPSWPathTextBox
        '
        Me.RestoreIPSWPathTextBox.Location = New System.Drawing.Point(12, 110)
        Me.RestoreIPSWPathTextBox.Name = "RestoreIPSWPathTextBox"
        Me.RestoreIPSWPathTextBox.Size = New System.Drawing.Size(592, 20)
        Me.RestoreIPSWPathTextBox.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(650, 110)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(101, 21)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Restore"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'AdvancedOptionsGroupBox
        '
        Me.AdvancedOptionsGroupBox.Controls.Add(Me.LatestBootchainCheckBox)
        Me.AdvancedOptionsGroupBox.Controls.Add(Me.SkipNORCheckBox)
        Me.AdvancedOptionsGroupBox.Controls.Add(Me.TSSRestoreCheckBox)
        Me.AdvancedOptionsGroupBox.Controls.Add(Me.KloaderRestoreCheckBox)
        Me.AdvancedOptionsGroupBox.Location = New System.Drawing.Point(12, 134)
        Me.AdvancedOptionsGroupBox.Name = "AdvancedOptionsGroupBox"
        Me.AdvancedOptionsGroupBox.Size = New System.Drawing.Size(739, 87)
        Me.AdvancedOptionsGroupBox.TabIndex = 3
        Me.AdvancedOptionsGroupBox.TabStop = False
        Me.AdvancedOptionsGroupBox.Text = "Advanced Restore Options:"
        '
        'LatestBootchainCheckBox
        '
        Me.LatestBootchainCheckBox.AutoSize = True
        Me.LatestBootchainCheckBox.Location = New System.Drawing.Point(203, 21)
        Me.LatestBootchainCheckBox.Name = "LatestBootchainCheckBox"
        Me.LatestBootchainCheckBox.Size = New System.Drawing.Size(251, 17)
        Me.LatestBootchainCheckBox.TabIndex = 7
        Me.LatestBootchainCheckBox.Text = "Download and flash the latest signed Bootchain"
        Me.LatestBootchainCheckBox.UseVisualStyleBackColor = True
        '
        'SkipNORCheckBox
        '
        Me.SkipNORCheckBox.AutoSize = True
        Me.SkipNORCheckBox.Location = New System.Drawing.Point(6, 67)
        Me.SkipNORCheckBox.Name = "SkipNORCheckBox"
        Me.SkipNORCheckBox.Size = New System.Drawing.Size(148, 17)
        Me.SkipNORCheckBox.TabIndex = 5
        Me.SkipNORCheckBox.Text = "Skip NOR/NAND Update"
        Me.SkipNORCheckBox.UseVisualStyleBackColor = True
        '
        'TSSRestoreCheckBox
        '
        Me.TSSRestoreCheckBox.AutoSize = True
        Me.TSSRestoreCheckBox.Location = New System.Drawing.Point(6, 21)
        Me.TSSRestoreCheckBox.Name = "TSSRestoreCheckBox"
        Me.TSSRestoreCheckBox.Size = New System.Drawing.Size(118, 17)
        Me.TSSRestoreCheckBox.TabIndex = 6
        Me.TSSRestoreCheckBox.Text = "Send TSS Request"
        Me.TSSRestoreCheckBox.UseVisualStyleBackColor = True
        '
        'KloaderRestoreCheckBox
        '
        Me.KloaderRestoreCheckBox.AutoSize = True
        Me.KloaderRestoreCheckBox.Location = New System.Drawing.Point(6, 44)
        Me.KloaderRestoreCheckBox.Name = "KloaderRestoreCheckBox"
        Me.KloaderRestoreCheckBox.Size = New System.Drawing.Size(102, 17)
        Me.KloaderRestoreCheckBox.TabIndex = 4
        Me.KloaderRestoreCheckBox.Text = "Kloader Restore"
        Me.KloaderRestoreCheckBox.UseVisualStyleBackColor = True
        '
        'RawRestoreConsole
        '
        Me.RawRestoreConsole.Location = New System.Drawing.Point(12, 250)
        Me.RawRestoreConsole.Name = "RawRestoreConsole"
        Me.RawRestoreConsole.ReadOnly = True
        Me.RawRestoreConsole.Size = New System.Drawing.Size(739, 235)
        Me.RawRestoreConsole.TabIndex = 4
        Me.RawRestoreConsole.Text = "STATUS: Waiting..."
        '
        'StatusLabel
        '
        Me.StatusLabel.AutoSize = True
        Me.StatusLabel.Location = New System.Drawing.Point(9, 92)
        Me.StatusLabel.Name = "StatusLabel"
        Me.StatusLabel.Size = New System.Drawing.Size(221, 13)
        Me.StatusLabel.TabIndex = 5
        Me.StatusLabel.Text = "Connect a new device in DFU Mode to begin"
        '
        'WelcomeLabel
        '
        Me.WelcomeLabel.AutoSize = True
        Me.WelcomeLabel.Location = New System.Drawing.Point(9, 9)
        Me.WelcomeLabel.Name = "WelcomeLabel"
        Me.WelcomeLabel.Size = New System.Drawing.Size(436, 39)
        Me.WelcomeLabel.TabIndex = 6
        Me.WelcomeLabel.Text = resources.GetString("WelcomeLabel.Text")
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(610, 110)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(34, 21)
        Me.Button2.TabIndex = 7
        Me.Button2.Text = "..."
        Me.Button2.UseVisualStyleBackColor = True
        '
        'RestoreConsoleLabel
        '
        Me.RestoreConsoleLabel.AutoSize = True
        Me.RestoreConsoleLabel.Location = New System.Drawing.Point(9, 234)
        Me.RestoreConsoleLabel.Name = "RestoreConsoleLabel"
        Me.RestoreConsoleLabel.Size = New System.Drawing.Size(152, 13)
        Me.RestoreConsoleLabel.TabIndex = 8
        Me.RestoreConsoleLabel.Text = "Beehind's Restore Console 1.0"
        '
        'Restore
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(763, 497)
        Me.Controls.Add(Me.RestoreConsoleLabel)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.WelcomeLabel)
        Me.Controls.Add(Me.StatusLabel)
        Me.Controls.Add(Me.RawRestoreConsole)
        Me.Controls.Add(Me.AdvancedOptionsGroupBox)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.RestoreIPSWPathTextBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Restore"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Restore"
        Me.AdvancedOptionsGroupBox.ResumeLayout(False)
        Me.AdvancedOptionsGroupBox.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RestoreIPSWPathTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents AdvancedOptionsGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents LatestBootchainCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents SkipNORCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents TSSRestoreCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents KloaderRestoreCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents RawRestoreConsole As System.Windows.Forms.RichTextBox
    Friend WithEvents StatusLabel As System.Windows.Forms.Label
    Friend WithEvents WelcomeLabel As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents IPSWToRestoreFD As System.Windows.Forms.OpenFileDialog
    Friend WithEvents RestoreConsoleLabel As System.Windows.Forms.Label
End Class
