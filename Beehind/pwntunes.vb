Imports Beehind.Common_Definitions
Imports Beehind.Common_Functions
Imports System.IO
Imports Beehind.RestoreClass

Public Class pwntunes

    Public Shared ProgramData As String = "C:\ProgramData\Apple Computer\iTunes"
    Public Shared RestoreDir As String = "\iP" + "*"
    Public Shared PersonalizedBundlesDir As String = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\Temp"
    Public Shared PerTEMP As String() = Directory.GetDirectories(PersonalizedBundlesDir, "Per" + "*" + ".tmp")
    '{"\Per" + "*" + ".tmp"}
    Public Shared RestorePath As String = String.Empty


    Public Sub WipeOutRestoreDirectories()
        For Each RD In Directory.GetDirectories(ProgramData, RestoreDir.Replace("\", ""))
            Delete(True, RD)
        Next
    End Sub

    Public Shared Sub WipeOutPersonalizedBundles()
        MessageBox.Show(Path.GetDirectoryName((PerTEMP(0))))
        For Each PB In Directory.GetDirectories(PersonalizedBundlesDir, Path.GetDirectoryName((PerTEMP(0))))
            Delete(True, PB)
        Next
    End Sub

    Public Sub getpaths()
        Restore_KernelCache = RestorePath + "\" + GetPathFromBeehindManifest("KernelCache", RestorePath + "\Beehind.xml", 3)
        Restore_RestoreKernelCache = RestorePath + "\" + GetPathFromBeehindManifest("RestoreKernelCache", RestorePath + "\Beehind.xml", 3)
        Restore_AppleLogo = RestorePath + "\" + GetPathFromBeehindManifest("AppleLogo", RestorePath + "\Beehind.xml", 3)
        Restore_RestoreLogo = RestorePath + "\" + GetPathFromBeehindManifest("RestoreLogo", RestorePath + "\Beehind.xml", 3)
        Restore_DeviceTree = RestorePath + "\" + GetPathFromBeehindManifest("DeviceTree", RestorePath + "\Beehind.xml", 3)
        Restore_RestoreDeviceTree = RestorePath + "\" + GetPathFromBeehindManifest("RestoreDeviceTree", RestorePath + "\Beehind.xml", 3)
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start("iTunes")
    End Sub

    Private Sub pwntunes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Kill({"iTunes"})
        'WipeOutRestoreDirectories()
        'WipeOutPersonalizedBundles()
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Process.Start("http://appldnld.apple.com/iTunes11/041-1850.20121129.S2Ux2/iTunesSetup.exe")
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Process.Start("http://appldnld.apple.com/iTunes11/041-1851.20121129.6Uhg7/iTunes64Setup.exe")

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim iTunes As Process() = Process.GetProcessesByName("iTunes")
        SuspendProcess(iTunes(0))
        Dim directories As String() = Directory.GetDirectories(ProgramData, RestoreDir.Replace("\", ""))
        If directories.Length > 1 Then
            MessageBox.Show("ERROR")
            Exit Sub
        End If
        RestorePath = directories(0)
        getpaths()
        Delete(False, Restore_RestoreKernelCache)
        Delete(False, Restore_RestoreLogo)
        Delete(False, Restore_RestoreDeviceTree)
        Rename(Restore_KernelCache, Restore_RestoreKernelCache)
        Rename(Restore_AppleLogo, Restore_RestoreLogo)
        Rename(Restore_DeviceTree, Restore_RestoreDeviceTree)

        ResumeProcess(iTunes(0))
        MessageBox.Show("Patching Done! Now close Beehind and enjoy your restore ^_^")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim iTunes As Process() = Process.GetProcessesByName("iTunes")
        Do Until PerTEMP.Length = 1
            PerTEMP = Directory.GetDirectories(PersonalizedBundlesDir, "Per" + "*" + ".tmp")
        Loop
        Do Until File.Exists(PerTEMP(0) + "\amai\debug\tss-response.plist")
        Loop
        SuspendProcess(iTunes(0))
        'File.Delete(PerTEMP(0) + "\amai\debug\tss-response.plist")
        'File.Copy(appdata + "\emma.plist", PerTEMP(0) + "\amai\debug\tss-response.plist")
        MessageBox.Show("Press ok to resume")
        ResumeProcess(iTunes(0))
        'Delay(1)
        'SuspendProcess(iTunes(0))
    End Sub
End Class