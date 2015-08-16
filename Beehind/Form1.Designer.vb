<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.BeehindMenuStrip = New System.Windows.Forms.MenuStrip()
        Me.InfoMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutBeehindToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FollowMeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DonationsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OriginalXPWNSourceToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator()
        Me.SeeXPWNOnGitHubToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectModeMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IPSWCreatorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.KloaderModeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RestoreModeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IdevicerestoreModeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CreditsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SeeIdevicerestoreOnGitHubToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SeeBeehindOnGitHubToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BeehindMenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'BeehindMenuStrip
        '
        Me.BeehindMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InfoMenuItem, Me.SelectModeMenuItem, Me.CreditsToolStripMenuItem})
        Me.BeehindMenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.BeehindMenuStrip.Name = "BeehindMenuStrip"
        Me.BeehindMenuStrip.Size = New System.Drawing.Size(767, 24)
        Me.BeehindMenuStrip.TabIndex = 1
        Me.BeehindMenuStrip.Text = "MenuStrip1"
        '
        'InfoMenuItem
        '
        Me.InfoMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutBeehindToolStripMenuItem, Me.FollowMeToolStripMenuItem, Me.DonationsToolStripMenuItem, Me.OriginalXPWNSourceToolStripMenuItem, Me.SeeXPWNOnGitHubToolStripMenuItem, Me.SeeIdevicerestoreOnGitHubToolStripMenuItem, Me.ToolStripSeparator1, Me.SeeBeehindOnGitHubToolStripMenuItem})
        Me.InfoMenuItem.Name = "InfoMenuItem"
        Me.InfoMenuItem.Size = New System.Drawing.Size(40, 20)
        Me.InfoMenuItem.Text = "Info"
        '
        'AboutBeehindToolStripMenuItem
        '
        Me.AboutBeehindToolStripMenuItem.Name = "AboutBeehindToolStripMenuItem"
        Me.AboutBeehindToolStripMenuItem.Size = New System.Drawing.Size(226, 22)
        Me.AboutBeehindToolStripMenuItem.Text = "About Beehind"
        '
        'FollowMeToolStripMenuItem
        '
        Me.FollowMeToolStripMenuItem.Name = "FollowMeToolStripMenuItem"
        Me.FollowMeToolStripMenuItem.Size = New System.Drawing.Size(226, 22)
        Me.FollowMeToolStripMenuItem.Text = "Follow Me"
        '
        'DonationsToolStripMenuItem
        '
        Me.DonationsToolStripMenuItem.Name = "DonationsToolStripMenuItem"
        Me.DonationsToolStripMenuItem.Size = New System.Drawing.Size(226, 22)
        Me.DonationsToolStripMenuItem.Text = "Donations :)"
        '
        'OriginalXPWNSourceToolStripMenuItem
        '
        Me.OriginalXPWNSourceToolStripMenuItem.Name = "OriginalXPWNSourceToolStripMenuItem"
        Me.OriginalXPWNSourceToolStripMenuItem.Size = New System.Drawing.Size(223, 6)
        '
        'SeeXPWNOnGitHubToolStripMenuItem
        '
        Me.SeeXPWNOnGitHubToolStripMenuItem.Name = "SeeXPWNOnGitHubToolStripMenuItem"
        Me.SeeXPWNOnGitHubToolStripMenuItem.Size = New System.Drawing.Size(226, 22)
        Me.SeeXPWNOnGitHubToolStripMenuItem.Text = "See XPWN on GitHub"
        '
        'SelectModeMenuItem
        '
        Me.SelectModeMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.IPSWCreatorToolStripMenuItem, Me.KloaderModeToolStripMenuItem, Me.RestoreModeToolStripMenuItem, Me.IdevicerestoreModeToolStripMenuItem})
        Me.SelectModeMenuItem.Name = "SelectModeMenuItem"
        Me.SelectModeMenuItem.Size = New System.Drawing.Size(84, 20)
        Me.SelectModeMenuItem.Text = "Select Mode"
        '
        'IPSWCreatorToolStripMenuItem
        '
        Me.IPSWCreatorToolStripMenuItem.Name = "IPSWCreatorToolStripMenuItem"
        Me.IPSWCreatorToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.IPSWCreatorToolStripMenuItem.Text = "IPSW Creator"
        '
        'KloaderModeToolStripMenuItem
        '
        Me.KloaderModeToolStripMenuItem.Name = "KloaderModeToolStripMenuItem"
        Me.KloaderModeToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.KloaderModeToolStripMenuItem.Text = "Kloader Mode"
        '
        'RestoreModeToolStripMenuItem
        '
        Me.RestoreModeToolStripMenuItem.Name = "RestoreModeToolStripMenuItem"
        Me.RestoreModeToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.RestoreModeToolStripMenuItem.Text = "Restore Mode"
        Me.RestoreModeToolStripMenuItem.Visible = False
        '
        'IdevicerestoreModeToolStripMenuItem
        '
        Me.IdevicerestoreModeToolStripMenuItem.Name = "IdevicerestoreModeToolStripMenuItem"
        Me.IdevicerestoreModeToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.IdevicerestoreModeToolStripMenuItem.Text = "idevicerestore Mode"
        '
        'CreditsToolStripMenuItem
        '
        Me.CreditsToolStripMenuItem.Name = "CreditsToolStripMenuItem"
        Me.CreditsToolStripMenuItem.Size = New System.Drawing.Size(56, 20)
        Me.CreditsToolStripMenuItem.Text = "Credits"
        '
        'SeeIdevicerestoreOnGitHubToolStripMenuItem
        '
        Me.SeeIdevicerestoreOnGitHubToolStripMenuItem.Name = "SeeIdevicerestoreOnGitHubToolStripMenuItem"
        Me.SeeIdevicerestoreOnGitHubToolStripMenuItem.Size = New System.Drawing.Size(226, 22)
        Me.SeeIdevicerestoreOnGitHubToolStripMenuItem.Text = "See idevicerestore on GitHub"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(223, 6)
        '
        'SeeBeehindOnGitHubToolStripMenuItem
        '
        Me.SeeBeehindOnGitHubToolStripMenuItem.Name = "SeeBeehindOnGitHubToolStripMenuItem"
        Me.SeeBeehindOnGitHubToolStripMenuItem.Size = New System.Drawing.Size(226, 22)
        Me.SeeBeehindOnGitHubToolStripMenuItem.Text = "See Beehind on GitHub"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(767, 525)
        Me.Controls.Add(Me.BeehindMenuStrip)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.BeehindMenuStrip
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Beehind - kloader's GUI - BETA (v. 0.4)"
        Me.BeehindMenuStrip.ResumeLayout(False)
        Me.BeehindMenuStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BeehindMenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents InfoMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SelectModeMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IPSWCreatorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents KloaderModeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RestoreModeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutBeehindToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FollowMeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DonationsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CreditsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IdevicerestoreModeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OriginalXPWNSourceToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SeeXPWNOnGitHubToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SeeIdevicerestoreOnGitHubToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SeeBeehindOnGitHubToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
