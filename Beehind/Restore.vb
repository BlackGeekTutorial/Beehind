Imports System.Environment
Imports Beehind.Common_Definitions
Imports Beehind.Common_Functions
Imports Beehind.IPSWsMD5
Imports Beehind.RestoreClass
Imports Beehind.SignIMG3
Imports System.Xml

Public Class Restore

    Public Shared Sub AddLineToRestoreConsole(Text As String)
        Restore.RawRestoreConsole.AppendText(Environment.NewLine + Text)
        Restore.RawRestoreConsole.SelectionStart = Restore.RawRestoreConsole.TextLength
        Restore.RawRestoreConsole.ScrollToCaret()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        IPSWToRestoreFD.InitialDirectory = GetFolderPath(SpecialFolder.DesktopDirectory)
        IPSWToRestoreFD.Filter = "IPSW Files|*.ipsw;*.zip;"
        If IPSWToRestoreFD.ShowDialog = DialogResult.Abort Then
            Exit Sub
        End If
        RawRestoreConsole.AppendText(Environment.NewLine + "[!] New entry: " + IPSWToRestoreFD.FileName)
        RestoreIPSWPathTextBox.Enabled = False
        RestoreIPSWPathTextBox.Text = IPSWToRestoreFD.FileName
        RawRestoreConsole.AppendText(Environment.NewLine + "[!] Calculating MD5 Hash of the IPSW")
        Delay(1)
        'IPSWParser(Check_File_MD5(RestoreIPSWPathTextBox.Text))
        AddLineToRestoreConsole("    IPSW's MD5 is: " + IPSWMD5)
        AddLineToRestoreConsole("")
        AddLineToRestoreConsole("--------------------")
        AddLineToRestoreConsole("")
        AddLineToRestoreConsole("    Device Type: " + DeviceModel)
        AddLineToRestoreConsole("    Device's Board ID: " + DeviceClass)
        AddLineToRestoreConsole("    iOS Version: " + iOS_Version)
        AddLineToRestoreConsole("    iOS Build: " + iOS_Build)
        AddLineToRestoreConsole("")
        AddLineToRestoreConsole("--------------------")
        AddLineToRestoreConsole("")
        If iOS_Version = "" Then
            AddLineToRestoreConsole("[!] IPSW not recognized, ")
            Dim UsersChoice As Integer = MessageBox.Show("The IPSW's MD5 hash (" + IPSWMD5 + ") was not in Beehind's database. However it could still be a valid IPSW, or simply, a Custom Firmware (Unhashable). If you want to continue with the restore, press Yes", "IPSW Unrecognized",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If UsersChoice = DialogResult.No Then
                RawRestoreConsole.AppendText("user stopped the operation")
            ElseIf UsersChoice = DialogResult.Yes Then
                RawRestoreConsole.AppendText("continuing anyway, press the Restore button to begin")
            End If
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        AddLineToRestoreConsole("")
        AddLineToRestoreConsole("[!] Creating Restore directory at: '" + tempdir + "\RestoreTEMP'")
        CreateDirectory(tempdir, "\RestoreTEMP", True)
        AddLineToRestoreConsole("[!] Extracting IPSW '" + RestoreIPSWPathTextBox.Text + "' to '" + tempdir + "\RestoreTEMP\*'")
        Unzip(RestoreIPSWPathTextBox.Text, tempdir + "\RestoreTEMP")
        If IO.File.Exists(tempdir + "\RestoreTEMP\Beehind.plist") Then

        ElseIf IO.File.Exists(tempdir + "\RestoreTEMP\BuildManifest.plist") Then

        ElseIf IO.File.Exists(tempdir + "\RestoreTEMP\Beehind.xml") Then
            Restore_iBSS = GetPathFromBeehindManifest("iBSS", tempdir + "\RestoreTEMP\Beehind.xml", 3)
            AddLineToRestoreConsole("[!] Getting path for iBSS: '" + Restore_iBSS + "'")
            Restore_iBEC = GetPathFromBeehindManifest("iBEC", tempdir + "\RestoreTEMP\Beehind.xml", 3)
            AddLineToRestoreConsole("[!] Getting path for iBEC: '" + Restore_iBEC + "'")
            Restore_RestoreRamdisk = GetPathFromBeehindManifest("RestoreRamDisk", tempdir + "\RestoreTEMP\Beehind.xml", 3)
            AddLineToRestoreConsole("[!] Getting path for RestoreRamdisk: '" + Restore_RestoreRamdisk + "'")
            Restore_RootFS = GetPathFromBeehindManifest("OS", tempdir + "\RestoreTEMP\Beehind.xml", 3)
            AddLineToRestoreConsole("[!] Getting path for RootFS: '" + Restore_RootFS + "'")
            Restore_KernelCache = GetPathFromBeehindManifest("KernelCache", tempdir + "\RestoreTEMP\Beehind.xml", 3)
            AddLineToRestoreConsole("[!] Getting path for KernelCache: '" + Restore_KernelCache + "'")
            Restore_RestoreKernelCache = GetPathFromBeehindManifest("RestoreKernelCache", tempdir + "\RestoreTEMP\Beehind.xml", 3)
            AddLineToRestoreConsole("[!] Getting path for RestoreKernelCache: '" + Restore_RestoreKernelCache + "'")
            Restore_AppleLogo = GetPathFromBeehindManifest("AppleLogo", tempdir + "\RestoreTEMP\Beehind.xml", 3)
            AddLineToRestoreConsole("[!] Getting path for AppleLogo: '" + Restore_AppleLogo + "'")
            Restore_RestoreLogo = GetPathFromBeehindManifest("RestoreLogo", tempdir + "\RestoreTEMP\Beehind.xml", 3)
            AddLineToRestoreConsole("[!] Getting path for RestoreLogo: '" + Restore_RestoreLogo + "'")
            Restore_BatteryCharging0 = GetPathFromBeehindManifest("BatteryCharging0", tempdir + "\RestoreTEMP\Beehind.xml", 3)
            AddLineToRestoreConsole("[!] Getting path for BatteryCharging0: '" + Restore_BatteryCharging0 + "'")
            Restore_BatteryCharging1 = GetPathFromBeehindManifest("BatteryCharging1", tempdir + "\RestoreTEMP\Beehind.xml", 3)
            AddLineToRestoreConsole("[!] Getting path for BatteryCharging1: '" + Restore_BatteryCharging1 + "'")
            Restore_BatteryFull = GetPathFromBeehindManifest("BatteryFull", tempdir + "\RestoreTEMP\Beehind.xml", 3)
            AddLineToRestoreConsole("[!] Getting path for BatteryFull: '" + Restore_BatteryFull + "'")
            Restore_BatteryLow0 = GetPathFromBeehindManifest("BatteryLow0", tempdir + "\RestoreTEMP\Beehind.xml", 3)
            AddLineToRestoreConsole("[!] Getting path for BatteryLow0: '" + Restore_BatteryLow0 + "'")
            Restore_BatteryLow1 = GetPathFromBeehindManifest("BatteryLow1", tempdir + "\RestoreTEMP\Beehind.xml", 3)
            AddLineToRestoreConsole("[!] Getting path for BatteryLow1: '" + Restore_BatteryLow1 + "'")
            Restore_DeviceTree = GetPathFromBeehindManifest("DeviceTree", tempdir + "\RestoreTEMP\Beehind.xml", 3)
            AddLineToRestoreConsole("[!] Getting path for DeviceTree: '" + Restore_DeviceTree + "'")
            Restore_RestoreDeviceTree = GetPathFromBeehindManifest("RestoreDeviceTree", tempdir + "\RestoreTEMP\Beehind.xml", 3)
            AddLineToRestoreConsole("[!] Getting path for RestoreDeviceTree: '" + Restore_RestoreDeviceTree + "'")
            Restore_GlyphCharging = GetPathFromBeehindManifest("GlyphCharging", tempdir + "\RestoreTEMP\Beehind.xml", 3)
            AddLineToRestoreConsole("[!] Getting path for GlyphCharging: '" + Restore_GlyphCharging + "'")
            Restore_GlyphPlugin = GetPathFromBeehindManifest("GlyphPlugin", tempdir + "\RestoreTEMP\Beehind.xml", 3)
            AddLineToRestoreConsole("[!] Getting path for GlyphPlugin: '" + Restore_GlyphPlugin + "'")
            Restore_iBoot = GetPathFromBeehindManifest("iBoot", tempdir + "\RestoreTEMP\Beehind.xml", 3)
            AddLineToRestoreConsole("[!] Getting path for iBoot: '" + Restore_iBoot + "'")
            Restore_LLB = GetPathFromBeehindManifest("LLB", tempdir + "\RestoreTEMP\Beehind.xml", 3)
            AddLineToRestoreConsole("[!] Getting path for LLB: '" + Restore_LLB + "'")
            Restore_RecoveryMode = GetPathFromBeehindManifest("RecoveryMode", tempdir + "\RestoreTEMP\Beehind.xml", 3)
            AddLineToRestoreConsole("[!] Getting path for RecoveryMode: '" + Restore_RecoveryMode + "'")
        End If
        Do Until IsDFUConnected() = True
            Dim counter As Integer = 0
            AddLineToRestoreConsole("[!] Waiting for DFU Mode...")
            counter = counter + 1
            Delay(1)
        Loop
        AddLineToRestoreConsole("[!] Uploading 'ibss' to the device")
        SendFileToRecoveryMode(tempdir + "\RestoreTEMP\" + Restore_iBSS)
        Do Until IsDFUConnected() = True
            AddLineToRestoreConsole("[!] Waiting for iBSS...")
        Loop
        AddLineToRestoreConsole("[!] Uploading 'ibec' to the device")
        SendFileToRecoveryMode(tempdir + "\RestoreTEMP\" + Restore_iBEC)
        Do Until IsRecoveryConnected() = True
            AddLineToRestoreConsole("[!] Waiting for iBEC...")
        Loop
        AddLineToRestoreConsole("[!] Sending 'logo' to iBEC")
        SendFileToRecoveryMode(tempdir + "\RestoreTEMP\" + Restore_RestoreLogo)
        AddLineToRestoreConsole("[!] Sending 'setpicture 0' command to iBEC")
        SendCMDToRecoveryMode("setpicture 0")
        AddLineToRestoreConsole("[!] Sending 'bgcolor 0 0 0' command to iBEC")
        SendCMDToRecoveryMode("bgcolor 0 0 0")
        AddLineToRestoreConsole("[!] Sending 'rdsk' to iBEC")
        SendFileToRecoveryMode(tempdir + "\RestoreTEMP\" + Restore_RestoreRamdisk)
        AddLineToRestoreConsole("[!] Sending 'ramdisk-delay' command to iBEC")
        SendCMDToRecoveryMode("ramdisk-delay")
        AddLineToRestoreConsole("[!] Sending 'ramdisk' command to iBEC")
        SendCMDToRecoveryMode("ramdisk")
        AddLineToRestoreConsole("[!] Sending 'dtre' to iBEC")
        SendFileToRecoveryMode(tempdir + "\RestoreTEMP\" + Restore_RestoreDeviceTree)
        AddLineToRestoreConsole("[!] Sending 'devicetree' command to iBEC")
        SendCMDToRecoveryMode("devicetree")
        AddLineToRestoreConsole("[!] Sending 'krnl' to iBEC")
        SendFileToRecoveryMode(tempdir + "\RestoreTEMP\" + Restore_RestoreKernelCache)
        AddLineToRestoreConsole("[!] Sending 'setenv boot-args rd=md0 nand-enable-reformat=1 -progress' command to iBEC")
        SendCMDToRecoveryMode("setenv boot-args rd=md0 nand-enable-reformat=1 -progress")
        AddLineToRestoreConsole("[!] Booting device...")
        AddLineToRestoreConsole("[!] Boot command: bootx")
        AddLineToRestoreConsole("[!] Sending 'bootx' command to iBEC")
        SendCMDToRecoveryMode("bootx")
    End Sub
End Class