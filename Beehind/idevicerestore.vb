Imports Beehind.Common_Definitions
Imports Beehind.Common_Functions
Imports Beehind.Processes
Imports System.ComponentModel
Imports System.Environment
Imports System.Xml
Imports System.IO.Compression
Imports System.IO
Imports System.Windows.Threading
Imports Beehind.XML

Public Class idevicerestoreGUI

    Public RestoreArguments As String = String.Empty

    Public Shared Function IsThisIPSWOTA(IPSWPath)
        InfoZipUnzip("""" + IPSWPath + """" + " " + """" + "Beehind.xml" + """" + " -d " + """" + tempdir + "\Restore" + """")
        If File.Exists(tempdir + "\Restore\Beehind.xml") = False Then
            MessageBox.Show("File 'Beehind.xml' NOT found! IPSW could be corrupted or it has been created with an outdated version of Beehind. Please, re-create it with this current version.", "Missing 'Beehind.xml'", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Function
        End If
        Dim IsOTA As String = GetTextFromXMLItem(tempdir + "\Restore\Beehind.xml", 3, "OTA Downgrade", "OTA Downgrade")
        Delete(False, tempdir + "\Restore\Beehind.xml")
        If IsOTA = "false" Then
            Return False
        ElseIf IsOTA = "true" Then
            Return True
        Else
            MessageBox.Show("ERROR: Beehind wasn't able to determinate the IPSW type.. Are you sure it's valid? Maybe you've created it with an older version of Beehind; if yes, please, re-create it with the current version!", "Plist reading fail", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Function

    Public Shared Function ExtractSHSHFromIPSW(IPSWPath As String, outdir As String)
        InfoZipUnzip("""" + IPSWPath + """" + " " + """" + "shsh/*" + """" + " -d " + """" + outdir + """")
        If Directory.Exists(outdir) = False Then
            MessageBox.Show("ERROR: Failed to extract shsh folder! IPSW could be corrupted or it has been created with an outdated version of Beehind. Please, re-create it with this current version.", "Missing 'Beehind.xml'", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Function
        End If
    End Function

    Public Sub SelectCacheDir()
        MessageBox.Show("Please, choose the saving directory", "Select caching directory", MessageBoxButtons.OK, MessageBoxIcon.Information)
        CacheDirPath.RootFolder = SpecialFolder.Desktop
        If CacheDirPath.ShowDialog = DialogResult.Abort Then
            CacheDirCheckBox.Checked = False
            FetchSHSHCheckBox.Checked = False
            Exit Sub
        End If
    End Sub

    Private Sub RestoreButton_Click(sender As Object, e As EventArgs) Handles RestoreButton.Click

        Kill({"iTunes", "idevicerestore", "iTunesHelper"})
        Dim iTunesHelper As Process() = Process.GetProcessesByName("iTunesHelper")
        'SuspendProcess(iTunesHelper(0))
        Dim OTA As Boolean = IsThisIPSWOTA(IPSWPathTextBox.Text)

        If OTA = False Then
            CreateDirectory(tempdir, "\Restore", True)
            ExtractSHSHFromIPSW(IPSWPathTextBox.Text, tempdir + "/Restore/")
            RestoreArguments = "-w " + """" + IPSWPathTextBox.Text + """"
            idevicerestore(RestoreArguments, True)
        ElseIf OTA = True Then
            RestoreArguments = "-e " + """" + IPSWPathTextBox.Text + """"
            idevicerestore(RestoreArguments, False)
        End If
        'ResumeProcess(iTunesHelper(0))

    End Sub

    Private Sub BrowseIPSWButtin_Click(sender As Object, e As EventArgs) Handles BrowseIPSWButtin.Click
        IPSWFileDialog.FileName = ""
        IPSWFileDialog.InitialDirectory = GetFolderPath(SpecialFolder.DesktopDirectory)
        IPSWFileDialog.Filter = "IPSW Files|*.ipsw"
        IPSWFileDialog.ShowDialog()

        If IPSWFileDialog.FileName <> "" Then
            RestoreButton.Enabled = True
            IPSWPathTextBox.Text = IPSWFileDialog.FileName
        End If
    End Sub

    Private Sub EraseCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles EraseCheckBox.CheckedChanged
        If EraseCheckBox.Checked = True Then
            RestoreArguments = RestoreArguments + " -e " + """" + IPSWPathTextBox.Text + """"
            UpgradeCheckBox.Checked = False
            limera1nCheckBox.Checked = False
            FetchSHSHCheckBox.Checked = False
        Else
            RestoreArguments = RestoreArguments.Replace(" -e " + """" + IPSWPathTextBox.Text + """", "")
            LatestInstallCheckBox.Checked = False
            BeehindModeCheckBox.Checked = False
            CustomFWCheckBox.Checked = False
        End If
    End Sub

    Private Sub UpgradeCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles UpgradeCheckBox.CheckedChanged
        If UpgradeCheckBox.Checked = True Then
            RestoreArguments = RestoreArguments + """" + IPSWPathTextBox.Text + " " + """"
            EraseCheckBox.Checked = False
            LatestInstallCheckBox.Checked = False
            BeehindModeCheckBox.Checked = False
            limera1nCheckBox.Checked = False
            CustomFWCheckBox.Checked = False
            FetchSHSHCheckBox.Checked = False
        Else
            RestoreArguments = RestoreArguments.Replace("""" + IPSWPathTextBox.Text + " " + """", "")
        End If
    End Sub

    Private Sub LatestInstallCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles LatestInstallCheckBox.CheckedChanged
        If LatestInstallCheckBox.Checked = True Then
            EraseCheckBox.Checked = True
            RestoreArguments = RestoreArguments + " -l " + """" + IPSWPathTextBox.Text + """"
            UpgradeCheckBox.Checked = False
            BeehindModeCheckBox.Checked = False
            limera1nCheckBox.Checked = False
            CustomFWCheckBox.Checked = False
            FetchSHSHCheckBox.Checked = False
        Else
            RestoreArguments = RestoreArguments.Replace(" -l " + """" + IPSWPathTextBox.Text + """", "")
        End If
    End Sub

    Private Sub BeehindModeCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles BeehindModeCheckBox.CheckedChanged
        If BeehindModeCheckBox.Checked = True Then
            EraseCheckBox.Checked = True
            CustomFWCheckBox.Checked = False
            LatestInstallCheckBox.Checked = False
            SaurikModeCheckBox.Checked = False
            FetchSHSHCheckBox.Checked = False
            limera1nCheckBox.Checked = False
            RestoreArguments = RestoreArguments + " -a "
        Else
            RestoreArguments = RestoreArguments.Replace(" -a ", "")
        End If
    End Sub

    Private Sub limera1nCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles limera1nCheckBox.CheckedChanged
        If limera1nCheckBox.Checked = True Then
            RestoreArguments = RestoreArguments + " -p "
            EraseCheckBox.Checked = False
            FetchSHSHCheckBox.Checked = False
            SkipNORAndBBFlashingCheckBox.Checked = False
        Else
            RestoreArguments = RestoreArguments.Replace(" -p ", "")
        End If
    End Sub

    Private Sub CustomFWCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles CustomFWCheckBox.CheckedChanged
        If CustomFWCheckBox.Checked = True Then
            EraseCheckBox.Checked = True
            BeehindModeCheckBox.Checked = False
            RestoreArguments = RestoreArguments + " -c "
        Else
            RestoreArguments = RestoreArguments.Replace(" -c ", "")
        End If
    End Sub

    Private Sub FetchSHSHCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles FetchSHSHCheckBox.CheckedChanged
        If FetchSHSHCheckBox.Checked = True Then
            EraseCheckBox.Checked = False
            UpgradeCheckBox.Checked = False
            CacheDirCheckBox.Checked = True
            RestoreArguments = RestoreArguments + " -t " + """" + IPSWPathTextBox.Text + """"
        Else
            RestoreArguments = RestoreArguments.Replace(" -t " + """" + IPSWPathTextBox.Text + """", "")
        End If
    End Sub

    Private Sub SaurikModeCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles SaurikModeCheckBox.CheckedChanged
        If SaurikModeCheckBox.Checked = True Then
            CacheDirCheckBox.Checked = True
            RestoreArguments = RestoreArguments + " -s "
        Else
            RestoreArguments = RestoreArguments.Replace(" -s ", "")
        End If
    End Sub

    Private Sub TargetECIDCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles TargetECIDCheckBox.CheckedChanged
        If TargetECIDCheckBox.Checked = True Then
            RestoreArguments = RestoreArguments + " -i " + TargetECIDTextBox.Text
        Else
            RestoreArguments = RestoreArguments.Replace(" -i " + TargetECIDTextBox.Text, "")
        End If
    End Sub

    Private Sub TargetUDIDCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles TargetUDIDCheckBox.CheckedChanged
        If TargetUDIDCheckBox.Checked = True Then
            RestoreArguments = RestoreArguments + " -u " + TargetUDIDTextBox.Text
        Else
            RestoreArguments = RestoreArguments.Replace(" -u " + TargetUDIDTextBox.Text, "")
        End If
    End Sub

    Private Sub VerboseCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles VerboseCheckBox.CheckedChanged
        If SaurikModeCheckBox.Checked = True Then
            RestoreArguments = RestoreArguments + " -d "
        Else
            RestoreArguments = RestoreArguments.Replace(" -d ", "")
        End If
    End Sub

    Private Sub SkipNORAndBBFlashingCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles SkipNORAndBBFlashingCheckBox.CheckedChanged
        If SaurikModeCheckBox.Checked = True Then
            RestoreArguments = RestoreArguments + " -x "
        Else
            RestoreArguments = RestoreArguments.Replace(" -x ", "")
        End If
    End Sub

    Private Sub CacheDirCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles CacheDirCheckBox.CheckedChanged
        If CacheDirCheckBox.Checked = True Then
            SelectCacheDir()
            RestoreArguments = RestoreArguments + " -C " + """" + CacheDirPath.SelectedPath + """"
        Else
            RestoreArguments = RestoreArguments.Replace(" -C " + """" + CacheDirPath.SelectedPath + """", "")
        End If
    End Sub

    Private Sub idevicerestoreGUI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CreateDirectory(tempdir, "\Restore", True)
    End Sub
End Class