Imports System.Environment
Imports Beehind.Common_Functions


Public Class Common_Definitions

    Public Shared currentversion As Decimal = 0.2
    Public Shared latestversion As Decimal
    Public Shared ldownload As String = String.Empty
    Public Shared appdata As String = GetFolderPath(SpecialFolder.ApplicationData)
    Public Shared tempdir As String = appdata + "\beehind"
    Public Shared IPSWPath As String = String.Empty
    Public Shared IPSWMD5 As String = String.Empty
    Public Shared SHSHPath As String = String.Empty
    Public Shared XMLPath As String = String.Empty
    Public Shared BasebandPath As String = String.Empty
    Public Shared CustomBundlePath As String = String.Empty
    Public Shared OTADowngrade As Boolean = False
    'Public Shared DeviceNormalModeConnected As Boolean = False
    Public Shared iBSSToKload As String = String.Empty

    Public Shared PNGLogoPath As String = String.Empty

    Public Shared IPSW_MD5 As String = String.Empty
    Public Shared iOS_Version As String = String.Empty
    Public Shared iOS_Build As String = String.Empty
    Public Shared iOS_BundleName As String = String.Empty
    Public Shared DeviceModel As String = String.Empty
    Public Shared board_id As String = String.Empty
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
            OTADowngrade = False
        ElseIf UsersChoice = DialogResult.Yes Then
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
                OTADowngrade = False
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
                OTADowngrade = True
                MainView.ChooseSHSHButton.Visible = False
                MainView.SHSHGroupBox.Text = "No Blobs are required to perform an OTA Downgrade"
                MainView.CancelOTADWN.Visible = True
                MainView.HacktivateCheckBox.Checked = False
                MainView.BasebandCheckBox.Checked = False
            End If
        End If
    End Sub
End Class
