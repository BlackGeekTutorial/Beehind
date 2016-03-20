Imports Beehind.Common_Definitions
Imports Beehind.Common_Functions
Imports Beehind.Processes
Imports Microsoft.Win32
Imports System.Net
Imports System.IO
Imports Beehind.RestoreClass

Public Class iTunesRestore

    Public Shared itunespath As String = ""
    Public Shared iTunesSetup As New Process()
    Public Shared url As String = ""
    Public Shared ipsw As String = ""

    Public Shared rkrnl As String = ""
    Public Shared rlogo As String = ""
    Public Shared rdtre As String = ""

    Public Shared krnl As String = ""
    Public Shared logo As String = ""
    Public Shared dtre As String = ""

    Public Shared Sub UninstalliTunes()
        Kill({"iTunes", "iTunesHelper", "iPodService Module"})
        If My.Computer.FileSystem.DirectoryExists(userdir + "\Music\iTunes") Then
            Rename(userdir + "\Music\iTunes", userdir + "\Music\iTunes.beehind")
        End If

        Dim uninstall() As String = {("iTunes"), ("Bonjour")}

        Dim ParentKey As RegistryKey
        If Environment.Is64BitOperatingSystem = True Then
            ParentKey = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64)
            ParentKey = ParentKey.OpenSubKey("SOFTWARE\MICROSOFT\Windows\CurrentVersion\Installer\UserData\S-1-5-18\Products")
        Else
            ParentKey = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry32)
            ParentKey = ParentKey.OpenSubKey("SOFTWARE\MICROSOFT\Windows\CurrentVersion\Installer\UserData\S-1-5-18\Products")
        End If
        Dim count As Integer = 0
        Dim ChildKey As RegistryKey

        For Each child As String In ParentKey.GetSubKeyNames()
            ChildKey = ParentKey.OpenSubKey(child).OpenSubKey("InstallProperties")
            If Not ChildKey Is Nothing Then
                If ChildKey.GetValue("DisplayName").ToString.Contains("Apple") And ChildKey.GetValue("UninstallString") IsNot Nothing Then
                    ReDim Preserve uninstall(uninstall.Length)
                    uninstall(uninstall.Length - 1) = ChildKey.GetValue("DisplayName").ToString
                End If
            End If
        Next

        For Each crap In uninstall
            Dim pid = UninstallProgram(crap, True)
        Next
    End Sub

    Public Shared Sub DeleteRestoreDirs()
        Dim no_more_fwdirs As Boolean = False
        Do Until no_more_fwdirs = True
            Dim fw_dirs As String() = Directory.GetDirectories("C:/ProgramData/Apple Computer/iTunes/", "iP" + "*")
            If fw_dirs.Length.ToString = 0 Then
                no_more_fwdirs = True
            Else
                IO.Directory.Delete(fw_dirs(0), True)
            End If
        Loop
    End Sub
    Private Sub iTunesRestore_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim itunesvers As Version = Version.Parse(FileVersionInfo.GetVersionInfo("C:\Program Files (x86)\iTunes\iTunes.exe").FileVersion)
        If itunesvers > Version.Parse("11.0") Then
            Dim downgrade As Integer = MessageBox.Show("The installed iTunes version (" + itunesvers.ToString + ") is too new. You need 11.0. Click Yes and Beehind will automatically downgrade it", "Wrong iTunes Version", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If downgrade = DialogResult.Yes Then

                UninstalliTunes()

                If Environment.Is64BitOperatingSystem = True Then
                    url = "http://appldnld.apple.com/iTunes11/041-1851.20121129.6Uhg7/iTunes64Setup.exe"
                Else
                    url = "http://appldnld.apple.com/iTunes11/041-1850.20121129.S2Ux2/iTunesSetup.exe"
                End If

                Beehind.dm.StartPosition = FormStartPosition.CenterParent
                Beehind.dm.url = url
                itunespath = tempdir + "\" + url.Substring(url.LastIndexOf("/") + 1)
                Delete(False, itunespath)
                Beehind.dm.dpath = itunespath
                Beehind.dm.Show()
                Do Until Beehind.dm.finished = True
                    Delay(1)
                Loop

                Try
                    iTunesSetup.StartInfo.UseShellExecute = True
                    iTunesSetup.StartInfo.FileName = itunespath
                    iTunesSetup.StartInfo.CreateNoWindow = False
                    iTunesSetup.Start()
                Catch ex As Exception
                End Try
                Do Until iTunesSetup.HasExited
                    Delay(1)
                Loop
                Delete(False, itunespath)
            End If
        End If
        

        DeleteRestoreDirs()

        Process.Start("iTunes.exe")

        Do Until IsRecoveryConnected() = True
            Delay(1)
        Loop
        Do Until IsRestoreConnected() = True
            Delay(1)
        Loop
        Dim restore_dir As String() = Directory.GetDirectories("C:/ProgramData/Apple Computer/iTunes/", "iP" + "*")

        MessageBox.Show("Deleting: " + restore_dir(restore_dir.Length - 1) + "\" + rkrnl.Substring(rkrnl.LastIndexOf("\") + 1))
        MessageBox.Show("Moving: " + restore_dir(restore_dir.Length - 1) + "\" + krnl.Substring(krnl.LastIndexOf("\") + 1) + "TO: " + restore_dir(restore_dir.Length - 1) + "\" + rkrnl.Substring(rkrnl.LastIndexOf("\") + 1))

        Delete(False, restore_dir(restore_dir.Length - 1).Replace("/", "\") + "\" + rkrnl.Substring(rkrnl.LastIndexOf("\") + 1).Replace("/", "\"))
        Rename(restore_dir(restore_dir.Length - 1).Replace("/", "\") + "\" + krnl.Substring(krnl.LastIndexOf("\") + 1).Replace("/", "\"), restore_dir(restore_dir.Length - 1).Replace("/", "\") + "\" + rkrnl.Substring(rkrnl.LastIndexOf("\") + 1).Replace("/", "\"))
        Delete(False, restore_dir(restore_dir.Length - 1).Replace("/", "\") + "\" + rdtre.Substring(rdtre.LastIndexOf("\") + 1).Replace("/", "\"))
        Rename(restore_dir(restore_dir.Length - 1).Replace("/", "\") + "\" + dtre.Substring(dtre.LastIndexOf("\") + 1).Replace("/", "\"), restore_dir(restore_dir.Length - 1).Replace("/", "\") + "\" + rdtre.Substring(rdtre.LastIndexOf("\") + 1).Replace("/", "\"))
        Delete(False, restore_dir(restore_dir.Length - 1).Replace("/", "\") + "\" + rlogo.Substring(rlogo.LastIndexOf("\") + 1).Replace("/", "\"))
        Rename(restore_dir(restore_dir.Length - 1).Replace("/", "\") + "\" + logo.Substring(logo.LastIndexOf("\") + 1).Replace("/", "\"), restore_dir(restore_dir.Length - 1).Replace("/", "\") + "\" + rlogo.Substring(rlogo.LastIndexOf("\") + 1).Replace("/", "\"))

        Do While IsRestoreConnected() = True
            Delay(1)
        Loop
        MessageBox.Show("restore finished")
        UninstalliTunes()
        If My.Computer.FileSystem.DirectoryExists(userdir + "\Music\iTunes.beehind") And My.Computer.FileSystem.DirectoryExists(userdir + "\Music\iTunes") Then
            Delete(True, userdir + "\Music\iTunes")
            Rename(userdir + "\Music\iTunes.beehind", userdir + "\Music\iTunes")
        End If
        Using client As New WebClient
            If Environment.Is64BitOperatingSystem = True Then
                url = client.DownloadString("https://api.ipsw.me/v2.1/iTunes/win/latest/64biturl")
            Else
                url = client.DownloadString("https://api.ipsw.me/v2.1/iTunes/win/latest/url")
            End If
        End Using
        Beehind.dm.StartPosition = FormStartPosition.CenterParent
        Beehind.dm.url = url
        itunespath = tempdir + "\" + url.Substring(url.LastIndexOf("/") + 1)
        Delete(False, itunespath)
        Beehind.dm.dpath = itunespath
        Beehind.dm.Show()
        Do Until Beehind.dm.finished = True
            Delay(1)
        Loop
        Try
            iTunesSetup.StartInfo.UseShellExecute = True
            iTunesSetup.StartInfo.FileName = itunespath
            iTunesSetup.StartInfo.CreateNoWindow = False
            iTunesSetup.Start()
        Catch ex As Exception
        End Try
        Do Until iTunesSetup.HasExited
            Delay(1)
        Loop
        Delete(False, itunespath)
        MessageBox.Show("Done")

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        IPSWToRestoreFD.InitialDirectory = desktop
        IPSWToRestoreFD.Filter = "IPSW Files|*.ipsw;*.zip;"
        If IPSWToRestoreFD.ShowDialog = DialogResult.Abort Then
            Exit Sub
        End If

        ipsw = IPSWToRestoreFD.FileName
        Unzip(ipsw, tempdir + "\Restore", "Beehind.xml")
        If Not File.Exists(tempdir + "\Restore\Beehind.xml") Then
            MessageBox.Show("This IPSW hasn't been created with Beehind and can't be restored by Beehind.", "Missing Beehind.xml", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        logo = GetPathFromBeehindManifest("AppleLogo", tempdir + "\Restore\Beehind.xml", 3)
        rlogo = GetPathFromBeehindManifest("RestoreLogo", tempdir + "\Restore\Beehind.xml", 3)
        dtre = GetPathFromBeehindManifest("DeviceTree", tempdir + "\Restore\Beehind.xml", 3)
        rdtre = GetPathFromBeehindManifest("RestoreDeviceTree", tempdir + "\Restore\Beehind.xml", 3)
        krnl = GetPathFromBeehindManifest("KernelCache", tempdir + "\Restore\Beehind.xml", 3)
        rkrnl = GetPathFromBeehindManifest("RestoreKernelCache", tempdir + "\Restore\Beehind.xml", 3)
    End Sub
End Class