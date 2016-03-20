Imports System.Environment
Imports Beehind.Common_Functions
Public Class Common_Definitions

    Public Shared currentversion As Decimal = 0.5
    Public Shared latestversion As Decimal
    Public Shared ldownload As String = String.Empty
    Public Shared shshHeader As String = "<?xml version=" + """" + "1.0" + """" + " encoding=" + """" + "utf-8" + """" + "?>" + Environment.NewLine + "<!DOCTYPE plist PUBLIC " + """" + "-//Apple Computer//DTD PLIST 1.0//EN" + """" + " " + """" + "http://www.apple.com/DTDs/PropertyList-1.0.dtd" + """" + ">" + Environment.NewLine + "<plist version=" + """" + "1.0" + """" + ">" + Environment.NewLine
    Public Shared appdata As String = GetFolderPath(SpecialFolder.ApplicationData)
    Public Shared userdir As String = GetFolderPath(SpecialFolder.UserProfile)
    Public Shared desktop As String = GetFolderPath(SpecialFolder.Desktop)
    Public Shared tempdir As String = appdata + "\beehind"
    Public Shared bundlesdir As String = tempdir + "\fw_bundles"
    Public Shared settingsfile As String = tempdir + "\settings.txt"
    Public Shared hshsdir As String = tempdir + "\hshs"
    Public Shared shsh_saving_dir As String = String.Empty
    Public Shared settingsbackup As String = String.Empty
    Public Shared IPSWPath As String = String.Empty
    Public Shared IPSWMD5 As String = String.Empty
    Public Shared SHSHPath As String = String.Empty
    Public Shared XMLPath As String = String.Empty
    Public Shared BasebandPath As String = String.Empty
    Public Shared CustomBundlePath As String = String.Empty
    Public Shared RestoredExternalPatch As Boolean = False
    Public Shared DowngradeType As String = "SIGNED"
    Public Shared IsiFaithMode As Boolean = False
    Public Shared ExploitType As String = String.Empty
    'Public Shared DeviceNormalModeConnected As Boolean = False
    Public Shared iBSSToKload As String = String.Empty

    Public Shared PNGLogoPath As String = String.Empty

    Public Shared IPSW_MD5 As String = String.Empty
    Public Shared iOS_Version As String = String.Empty
    Public Shared iOS_Build As String = String.Empty
    Public Shared iOS_BundleName As String = String.Empty
    Public Shared DeviceModel As String = String.Empty
    Public Shared DeviceClass As String = String.Empty
    Public Shared iPhoneProcessor As String = String.Empty

    'Current data
    Public Shared CurrentRootFSKey As String = String.Empty
    Public Shared CurrentRestoreRamdiskIV As String = String.Empty
    Public Shared CurrentRestoreRamdiskKey As String = String.Empty
    Public Shared CurrentUpdateRamdiskIV As String = String.Empty
    Public Shared CurrentUpdateRamdiskKey As String = String.Empty
    Public Shared CurrentAppleLogoIV As String = String.Empty
    Public Shared CurrentAppleLogoKey As String = String.Empty
    Public Shared CurrentBatteryCharging0IV As String = String.Empty
    Public Shared CurrentBatteryCharging0Key As String = String.Empty
    Public Shared CurrentBatteryCharging1IV As String = String.Empty
    Public Shared CurrentBatteryCharging1Key As String = String.Empty
    Public Shared CurrentBatteryFullIV As String = String.Empty
    Public Shared CurrentBatteryFullKey As String = String.Empty
    Public Shared CurrentBatteryLow0IV As String = String.Empty
    Public Shared CurrentBatteryLow0Key As String = String.Empty
    Public Shared CurrentBatteryLow1IV As String = String.Empty
    Public Shared CurrentBatteryLow1Key As String = String.Empty
    Public Shared CurrentDeviceTreeIV As String = String.Empty
    Public Shared CurrentDeviceTreeKey As String = String.Empty
    Public Shared CurrentGlyphChargingIV As String = String.Empty
    Public Shared CurrentGlyphChargingKey As String = String.Empty
    Public Shared CurrentGlyphPluginIV As String = String.Empty
    Public Shared CurrentGlyphPluginKey As String = String.Empty
    Public Shared CurrentIBECIV As String = String.Empty
    Public Shared CurrentIBECKey As String = String.Empty
    Public Shared CurrentiBootIV As String = String.Empty
    Public Shared CurrentiBootKey As String = String.Empty
    Public Shared CurrentIBSSIV As String = String.Empty
    Public Shared CurrentIBSSKey As String = String.Empty
    Public Shared CurrentKernelCacheIV As String = String.Empty
    Public Shared CurrentKernelCacheKey As String = String.Empty
    Public Shared CurrentLLBIV As String = String.Empty
    Public Shared CurrentLLBKey As String = String.Empty
    Public Shared CurrentRecoveryModeIV As String = String.Empty
    Public Shared CurrentRecoveryModeKey As String = String.Empty

    Public Shared all_flashFolder As String = String.Empty
    Public Shared rootfsName As String = String.Empty
    Public Shared UpdateRamdiskName As String = String.Empty
    Public Shared RestoreRamdiskName As String = String.Empty
    Public Shared AppleLogoName As String = String.Empty
    Public Shared BatteryChargingName As String = String.Empty
    Public Shared BatteryCharging0Name As String = String.Empty
    Public Shared BatteryCharging1Name As String = String.Empty
    Public Shared BatteryFullName As String = String.Empty
    Public Shared BatteryLow0Name As String = String.Empty
    Public Shared BatteryLow1Name As String = String.Empty
    Public Shared BatteryPluginName As String = String.Empty
    Public Shared DeviceTreeName As String = String.Empty
    Public Shared GlyphChargingName As String = String.Empty
    Public Shared GlyphPluginName As String = String.Empty
    Public Shared iBECName As String = String.Empty
    Public Shared iBootName As String = String.Empty
    Public Shared iBSSName As String = String.Empty
    Public Shared KernelCacheName As String = String.Empty
    Public Shared LLBName As String = String.Empty
    Public Shared RecoveryModeName As String = String.Empty

    Public Shared Sub OTADGForum()
        Dim UsersChoice As Integer = MessageBox.Show("You're lucky! iPhone 4S and iPad 2 possessors can UNTETHER DOWNGRADE to iOS 6.1.3 (yes, only this version) WITHOUT ANY SHSH BLOB through an OTA Downgrade. Do you want to perform an OTA Downgrade? (Press Yes to downgrade without SHSH, press No to use your own SHSH Blobs saved previously)", "OTA Signature detected", MessageBoxButtons.YesNo)
        If UsersChoice = DialogResult.No Then
            DowngradeType = "SIGNED"
        Else
            ECIDForm.MdiParent = Form1
            ECIDForm.Show()
            ECIDForm.WorkBar.Visible = True
            ECIDForm.Worklabel.Visible = True
            ECIDForm.ECIDTextBox.Visible = False
            ECIDForm.ECIDConfirmBtn.Visible = False
            ECIDForm.ECIDIntroductionLabel.Visible = False
            If CheckForInternetConnection() = False Then
                MessageBox.Show("It seems you currently don't have internet access on this computer. You won't be able to do OTA Downgrades until a valid internet connection is provided.", "Internet connection required",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
                DowngradeType = "SIGNED"
                MainView.CancelOTADWN.Visible = False
                MainView.ChooseSHSHButton.Visible = True
                MainView.ChooseSHSHButton.Enabled = True
                MainView.SHSHGroupBox.Text = "Browse for SHSH"
                ECIDForm.Close()
            Else
                ECIDForm.WorkBar.Visible = False
                ECIDForm.Worklabel.Visible = False
                ECIDForm.ECIDTextBox.Visible = True
                ECIDForm.ECIDConfirmBtn.Visible = True
                ECIDForm.ECIDIntroductionLabel.Visible = True
                DowngradeType = "OTA"
                MainView.ChooseSHSHButton.Visible = False
                MainView.SHSHGroupBox.Text = "No Blobs are required to perform an OTA Downgrade"
                MainView.CancelOTADWN.Visible = True
                MainView.HacktivateCheckBox.Checked = False
                MainView.BasebandCheckBox.Checked = False
            End If
        End If
    End Sub

    Public Shared Sub TetheredDGForum()
        Dim UsersChoice As Integer = MessageBox.Show("There are two available downgrades for your device:" + Environment.NewLine + "- Tethered Downgrade: It DOESN'T REQUIRE any SHSH Blob, but it is tethered! If you execute it on your device, it won't be able to boot up autonomously: you'll need to plug into the Computer and use tools like RedSn0w everytime you want to switch it on." + Environment.NewLine + "- Untethered Downgrade: It's a complete downgrade (your device will be able to boot up autonomously), but to execute it, you need saved unique SHSH Blobs of the old Firmware you want to install for your specific device." + Environment.NewLine + Environment.NewLine + "Basically: if you have valid SHSH Blobs, click Yes for a standard untethered downgrade; else, click No for a tethered downgrade", "To do or not To Do?", MessageBoxButtons.YesNo)
        If UsersChoice = DialogResult.No Then
            DowngradeType = "NOSIGN"
            MainView.NoNANDFlashCheckBox.Checked = True
            MainView.NoNANDFlashCheckBox.Enabled = False
            MainView.ChooseSHSHButton.Visible = False
            MainView.SHSHGroupBox.Text = "No Blobs are required to perform a Tethered Downgrade"
            MainView.CancelOTADWN.Visible = True
            MainView.CancelOTADWN.Text = "Cancel Tethered Downgrade"
            MainView.MagicButton.Enabled = True
        End If
    End Sub

    Public Shared Function IsLimera1nDevice()
        If DeviceModel = "iPhone2,1" Or DeviceModel = "iPhone3,1" Or DeviceModel = "iPhone3,2" Or DeviceModel = "iPhone3,3" Or DeviceModel = "iPod3,1" Or DeviceModel = "iPod4,1" Or DeviceModel = "iPad1,1" Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Shared Function iOSFromBuild(Build As String)
        If Build = "9A334" Then
            Return "5.0"
        ElseIf Build = "9A405" Or Build = "9A406" Then
            Return "5.0.1"
        ElseIf Build = "9B176" Then
            Return "5.1"
        ElseIf Build = "9B206" Or Build = "9B208" Then
            Return "5.1.1"
        ElseIf Build = "10A403" Then
            Return "6.0"
        ElseIf Build = "10A523" Then
            Return "6.0.1"
        ElseIf Build = "10B144" Then
            Return "6.1"
        ElseIf Build = "10B145" Then
            Return "6.1.1"
        ElseIf Build = "10B146" Then
            Return "6.1.2"
        ElseIf Build = "10B329" Then
            Return "6.1.3"
        ElseIf Build = "11A465" Then
            Return "7.0"
        ElseIf Build = "11A501" Then
            Return "7.0.2"
        ElseIf Build = "11B511" Then
            Return "7.0.3"
        ElseIf Build = "11B554a" Then
            Return "7.0.4"
        ElseIf Build = "11B601" Then
            Return "7.0.5"
        ElseIf Build = "11B651" Then
            Return "7.0.6"
        ElseIf Build = "11D169" Then
            Return "7.1"
        ElseIf Build = "11D201" Then
            Return "7.1.1"
        ElseIf Build = "11D257" Then
            Return "7.1.2"
        ElseIf Build = "12A365" Then
            Return "8.0"
        ElseIf Build = "12A402" Then
            Return "8.0.1"
        ElseIf Build = "12A405" Then
            Return "8.0.2"
        ElseIf Build = "12B411" Then
            Return "8.1"
        ElseIf Build = "12B435" Then
            Return "8.1.1"
        ElseIf Build = "12B440" Then
            Return "8.1.2"
        ElseIf Build = "12B466" Then
            Return "8.1.3"
        ElseIf Build = "12D508" Then
            Return "8.2"
        ElseIf Build = "12F70" Then
            Return "8.3"
        ElseIf Build = "12H143" Then
            Return "8.4"

        End If
    End Function
End Class
