Imports Beehind.ResourceHandler
Imports Beehind.Common_Functions
Imports System.IO
Imports Beehind.Common_Definitions
Imports Beehind.ProcessUtilities

Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Directory.Exists(tempdir) Then
            For Each File In (Directory.GetFiles(tempdir)).ToArray()
                For Each Process In GetProcessesUsingFiles({File})
                    Kill({Process.ProcessName})
                Next
            Next

            For Each subdir In (My.Computer.FileSystem.GetDirectories(tempdir + "\", FileIO.SearchOption.SearchAllSubDirectories, "*")).ToArray
                For Each File In (Directory.GetFiles(subdir)).ToArray()
                    For Each Process In GetProcessesUsingFiles({File})
                        Kill({Process.ProcessName})
                    Next
                Next
            Next
        End If

        ExtractResources()

        If Beehind.Betashit.IsRelease = True Then
            MainView.BasebandCheckBox.Enabled = False
            MainView.BasebandComboBox.Enabled = False
            MainView.CustomBundleCheckBox.Enabled = False
            BeehindMenuStrip.Items.Remove(RestoreModeToolStripMenuItem)
            idevicerestoreGUI.RestoreOptionsGroupBox.Visible = False
            MessageBox.Show(Beehind.Betashit.Warning)
        End If

        MainView.MdiParent = Me
        MainView.Show()
    End Sub


    Private Sub IPSWCreatorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IPSWCreatorToolStripMenuItem.Click
        MainView.MdiParent = Me
        MainView.Show()
        KloaderInjector.Close()
        Restore.Close()
        idevicerestoreGUI.Close()
    End Sub

    Private Sub KloaderModeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KloaderModeToolStripMenuItem.Click
        KloaderInjector.MdiParent = Me
        KloaderInjector.Show()
        MainView.Close()
        Restore.Close()
        idevicerestoreGUI.Close()
    End Sub

    Private Sub RestoreModeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RestoreModeToolStripMenuItem.Click
        Restore.MdiParent = Me
        Restore.Show()
        idevicerestoreGUI.Close()
        MainView.Close()
        KloaderInjector.Close()
    End Sub

    Private Sub AboutBeehindToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutBeehindToolStripMenuItem.Click
        Process.Start("http://beehind.geeksn0w.it")
    End Sub

    Private Sub FollowMeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FollowMeToolStripMenuItem.Click
        Process.Start("http://twitter.com/blackgeektuto")
    End Sub

    Private Sub DonationsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DonationsToolStripMenuItem.Click
        Process.Start("http://geeksn0w.it/donate.html")
    End Sub

    Private Sub CreditsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreditsToolStripMenuItem.Click
        MessageBox.Show("Beehind has been developed by Andrea Bentivegna (@blackgeektuto)" + Environment.NewLine + Environment.NewLine + "Thanks to:" + Environment.NewLine + "@winocm - for kloader and ios-kexec-utils" + Environment.NewLine + "@geohot - for limera1n exploit" + Environment.NewLine + "@pimskeks - for libimobiledevice and idevicerestore source code" + Environment.NewLine + "@Elro74 - for helping in compiling idevicerestore for Windows" + Environment.NewLine + "@taig_Jailbreak - for iOS 8.x Untether Payload" + Environment.NewLine + "@PanguTeam - for iOS 7.1.x Untether Payload" + Environment.NewLine + "@evad3rs - for iOS 7.0.x and 6.0-6.1.2 Untether Payload" + Environment.NewLine + "@iH8Sn0w, @squiffy and @winocm - for iOS 6.1.3-6.1.6 Untether Payload", "Credits/Thanks to:",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub IdevicerestoreModeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IdevicerestoreModeToolStripMenuItem.Click
        idevicerestoreGUI.MdiParent = Me
        idevicerestoreGUI.Show()
        Restore.Close()
        MainView.Close()
        KloaderInjector.Close()
    End Sub

    Private Sub SeeXPWNOnGitHubToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SeeXPWNOnGitHubToolStripMenuItem.Click
        Process.Start("https://github.com/planetbeing/xpwn")
    End Sub

    Private Sub SeeBeehindOnGitHubToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SeeBeehindOnGitHubToolStripMenuItem.Click
        Process.Start("https://github.com/BlackGeekTutorial/Beehind")
    End Sub

    Private Sub SeeIdevicerestoreOnGitHubToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SeeIdevicerestoreOnGitHubToolStripMenuItem.Click
        Process.Start("https://github.com/libimobiledevice/idevicerestore")
    End Sub
End Class
