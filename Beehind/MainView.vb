Imports Beehind.Common_Definitions
Imports Beehind.Common_Functions
Imports System.Environment
Imports Beehind.Processes
Imports System.IO
Imports System.IO.Compression
Imports Beehind.IPSWsMD5
Imports Beehind.IMG3Patches
Imports Beehind.SignIMG3
Imports System.Net
Imports Beehind.keys
Imports System.Xml
Imports Beehind.RestoreClass
Imports Beehind.Restore
Imports System.Text
Imports Beehind.ECIDManagement
Imports System.Management



Public Class MainView

    Private Sub BasebandCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles BasebandCheckBox.CheckedChanged
        If BasebandCheckBox.Checked = True Then
            If OTADowngrade = True Then
                MessageBox.Show("Refusing to add another baseband since it makes no sense if you're doing an OTA Downgrade...", "No Baseband.tar",
                               MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                BasebandCheckBox.Checked = False
            ElseIf DeviceModel = "iPod4,1" Or DeviceModel = "iPod5,1" Or DeviceModel = "iPad2,1" Or DeviceModel = "iPad3,1" Or DeviceModel = "iPad2,5" Or DeviceModel = "iPad3,4" Then
                MessageBox.Show("Why should you flash a baseband on a Wi-Fi only device?")
                BasebandCheckBox.Checked = False
            End If
        Else
            BasebandComboBox.Enabled = True
        End If

        If BasebandCheckBox.Checked = False Then
            BasebandComboBox.Enabled = False
        End If
    End Sub

    Private Sub LatestBuildLinkLabel_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LatestBuildLinkLabel.LinkClicked
        Process.Start(ldownload)
    End Sub

    Private Sub MainView_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            Updater()
    End Sub

    Private Sub ChooseIPSWButton_Click(sender As Object, e As EventArgs) Handles ChooseIPSWButton.Click
        IPSWFileDialog.FileName = ""
        IPSWFileDialog.InitialDirectory = GetFolderPath(SpecialFolder.DesktopDirectory)
        IPSWFileDialog.Filter = "IPSW Files|*.ipsw;*.zip;"
        IPSWFileDialog.ShowDialog()

        If IPSWFileDialog.FileName <> "" Then
            IPSWTextBox.Enabled = False
            IPSWTextBox.Text = IPSWFileDialog.FileName
            IPSWPath = IPSWFileDialog.FileName

            'IPSW has been given
            IPSWGroupBox.Text = "Analyzing IPSW..."
            Delay(1)
            IPSWParser(Check_File_MD5(IPSWPath))
            If Beehind.Betashit.IsRelease = True Then
                If Not Beehind.Betashit.Beta1SupportedCombox.Contains(iOS_Version + DeviceModel) Then
                    MessageBox.Show(Beehind.Betashit.Beta1LIMITEDMessage, "BETA LIMITED",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            End If
            If iOS_Version = "" Then
                MessageBox.Show("This IPSW (md5: " + IPSWMD5 + ") is not supported by this version of Beehind", "IPSW Unrecognized",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                Reset()
                Exit Sub
            Else
                IPSWGroupBox.Text = "IPSW Identified: " + DeviceModel + "_" + iOS_Version + "_" + iOS_Build
                If OTADowngrade = False Then
                    SHSHGroupBox.Text = "Browse for '" + DeviceModel + "_" + iOS_Version + "_" + iOS_Build + "' SHSH Blobs"
                    ChooseSHSHButton.Enabled = True
                End If
            End If
        End If
    End Sub

    Private Sub ChooseSHSHButton_Click(sender As Object, e As EventArgs) Handles ChooseSHSHButton.Click
        SHSHFileDialog.FileName = ""
        SHSHFileDialog.InitialDirectory = GetFolderPath(SpecialFolder.DesktopDirectory)
        SHSHFileDialog.Filter = "SHSH Blobs|*.shsh;*.xml;"
        If SHSHFileDialog.ShowDialog = DialogResult.Abort Then
            Exit Sub
        End If
        SHSHTextBox.Enabled = False
        SHSHTextBox.Text = SHSHFileDialog.FileName
        SHSHPath = SHSHFileDialog.FileName
        If File.ReadAllText(SHSHPath).Contains("xml") Then
            'xml file (uncompressed plist)
            FileCopy(SHSHPath, tempdir + "\" + Path.GetFileName(SHSHPath))
            XMLPath = tempdir + "\" + Path.GetFileName(SHSHPath)

        Else
            BPlistToXml(SHSHPath, tempdir + "\" + Path.GetFileName(SHSHPath).Replace(".shsh", ".xml"))
            XMLPath = tempdir + "\" + Path.GetFileName(SHSHPath).Replace(".shsh", ".xml")
        End If

        FillBlobsSet(iOSAsInteger)
        If OTADowngrade = False Then
            'getting ECID
            If BlobBackup <> "" Then
                ECIDParser(GrabECIDFromBase64Blob(BlobBackup))
            End If
        End If
        If XMLPath <> "" And IPSWPath <> "" Then
            MagicButton.Enabled = True
        End If
    End Sub

    Private Sub BasebandComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles BasebandComboBox.SelectedIndexChanged
        If BasebandComboBox.SelectedItem = "Manually select 'baseband.tar' file" Then
            BasebandFileDialog.FileName = ""
            BasebandFileDialog.InitialDirectory = GetFolderPath(SpecialFolder.DesktopDirectory)
            BasebandFileDialog.Filter = "TAR Files|*.tar;*.tgz;"
            If BasebandFileDialog.ShowDialog = DialogResult.Abort Then
                BasebandCheckBox.Checked = False
                Exit Sub
            End If
            BasebandPath = BasebandFileDialog.FileName
        End If
    End Sub

    Private Sub MagicButton_Click(sender As Object, e As EventArgs) Handles MagicButton.Click

        'If AddCydiaCheckBox.Checked = True And AddSSHCheckBox.Checked = False Then
        'If DeviceModel.StartsWith("iPad2") Then
        'Dim result As Integer = MessageBox.Show("For some strange reasons, in this beta of Beehind Cydia doesn't seem to appear on iPads after the downgrade (even if they've been succesfully jailbroken). I highly reccommend to check also 'Install OpenSSH', in this way, you'll just need to send this command: 'open com.saurik.Cydia' via SSH to run Cydia even if the icon doesn't appear in the SpringBoard. Do you want to check 'Install OpenSSH' now?", "iPad 2, detected Cydia problem", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        'If result = DialogResult.Yes Then
        'AddSSHCheckBox.Checked = True
        'End If
        'End If
        'End If

        If AddUntetherCheckBox.Checked = True And DeviceModel.StartsWith("iPad2") Then
            MessageBox.Show("Refusing to pre-bundle the Jailbreak in the IPSW since, for some strange reasons, in this beta of Beehind Cydia doesn't appear on iPads after the downgrade (even if they've been succesfully jailbroken). For this reason, I highly reccommend to do a downgrade with an original IPSW and then Jailbreak with the corresponding tool.", "Refusing to Jailbreak", MessageBoxButtons.OK, MessageBoxIcon.Information)
            AddUntetherCheckBox.Checked = False
            AddCydiaCheckBox.Checked = False
            AddSSHCheckBox.Checked = False
            HacktivateCheckBox.Checked = False
        End If

        MagicButton.Enabled = False
        CreateDirectory(tempdir, "\IPSW", True)
        ChooseIPSWButton.Enabled = False
        ChooseSHSHButton.Enabled = False
        DowngradeProgressBar.Value = 10
        ProgressLabel.Text = "10% - Extracting IPSW..."
        Delay(1)
        Unzip(IPSWPath, tempdir + "\IPSW")
        Delete(False, tempdir + "\IPSW" + UpdateRamdiskName)

        If OTADowngrade = True Then
            Delete(False, tempdir + "\IPSW\BuildManifest.plist")
            FileCopy(tempdir + "\BuildManifests\" + DeviceModel + "_" + iOS_Version + "_" + iOS_Build + "_OTAManifest.plist", tempdir + "\IPSW\BuildManifest.plist")
        Else
            PatchBuildManifest(tempdir + "\IPSW\BuildManifest.plist")
        End If
        '<----------------------------------------- iBSS patch ------------------------------------------------->
        DowngradeProgressBar.Value = 15
        ProgressLabel.Text = "15% - Patching iBSS..."
        xpwntool(tempdir + "\IPSW\Firmware\dfu" + iBSSName, tempdir + "\IPSW\Firmware\dfu" + iBSSName.Replace("dfu", "d"), CurrentIBSSIV, CurrentIBSSKey, True)
        PatchIBSS(tempdir + "\IPSW\Firmware\dfu" + iBSSName.Replace("dfu", "d"), tempdir + "\IPSW\Firmware\dfu" + iBSSName)
        Delete(False, tempdir + "\IPSW\Firmware\dfu" + iBSSName.Replace("dfu", "d"))
        '<---------------------------------------------------------------------------------------------------------------->

        '<----------------------------------------- iBEC patch ------------------------------------------------->
        DowngradeProgressBar.Value = 20
        ProgressLabel.Text = "20% - Patching iBEC..."
        xpwntool(tempdir + "\IPSW\Firmware\dfu" + iBECName, tempdir + "\IPSW\Firmware\dfu" + iBECName.Replace("dfu", "d"), CurrentIBECIV, CurrentIBECKey, True)
        PatchIBEC(tempdir + "\IPSW\Firmware\dfu" + iBECName.Replace("dfu", "d"), tempdir + "\IPSW\Firmware\dfu" + iBECName)
        Delete(False, tempdir + "\IPSW\Firmware\dfu" + iBECName.Replace("dfu", "d"))
        '<---------------------------------------------------------------------------------------------------------------->

        '<---------------------------------------------------- AppleLogo Stuff ---------------------------------------------->
        DowngradeProgressBar.Value = 25
        ProgressLabel.Text = "25% - Preparing RestoreLogo for kloader..."

        'If OTADowngrade = False Then
        'Rename(tempdir + "\IPSW\Firmware\all_flash" + all_flashFolder + AppleLogoName, tempdir + "\IPSW\Firmware\all_flash" + all_flashFolder + AppleLogoName + ".toflash")
        'imagetool(False, tempdir + "\restore-images\images-2x\applelogo.png", tempdir + "\IPSW\Firmware\all_flash" + all_flashFolder + AppleLogoName, tempdir + "\restore-images\logo-template.img3")
        'Else
        imagetool(False, tempdir + "\restore-images\images-2x\applelogo.png", tempdir + "\IPSW\Firmware\all_flash" + all_flashFolder + AppleLogoName.Replace("applelogo", "RestoreLogo_applelogo"), tempdir + "\restore-images\logo-template.img3")
        'End If
        '<---------------------------------------------------------------------------------------------------------------->

        '<---------------------------------------------------- DeviceTree Stuff ---------------------------------------------->
        DowngradeProgressBar.Value = 30
        ProgressLabel.Text = "30% - Preparing DeviceTree for kloader..."
        'If OTADowngrade = False Then
        'Rename(tempdir + "\IPSW\Firmware\all_flash" + all_flashFolder + DeviceTreeName, tempdir + "\IPSW\Firmware\all_flash" + all_flashFolder + DeviceTreeName + ".toflash")
        'xpwntool(tempdir + "\IPSW\Firmware\all_flash" + all_flashFolder + DeviceTreeName + ".toflash", tempdir + "\IPSW\Firmware\all_flash" + all_flashFolder + DeviceTreeName, CurrentDeviceTreeIV, CurrentDeviceTreeKey, True)
        'Else
        xpwntool(tempdir + "\IPSW\Firmware\all_flash" + all_flashFolder + DeviceTreeName, tempdir + "\IPSW\Firmware\all_flash" + all_flashFolder + DeviceTreeName.Replace("DeviceTree", "RestoreDeviceTree_DeviceTree"), CurrentDeviceTreeIV, CurrentDeviceTreeKey, True)
        'End If

        '<---------------------------------------------------------------------------------------------------------------->

        '<---------------------------------------------------- Kernel Stuff ---------------------------------------------->
        DowngradeProgressBar.Value = 35
        ProgressLabel.Text = "35% - Preparing Kernel for kloader..."
        'If OTADowngrade = False Then
        'Rename(tempdir + "\IPSW" + KernelCacheName, tempdir + "\IPSW" + KernelCacheName + ".toflash")
        'xpwntool(tempdir + "\IPSW" + KernelCacheName + ".toflash", tempdir + "\IPSW" + KernelCacheName, CurrentKernelCacheIV, CurrentKernelCacheKey, True)
        'Else
        xpwntool(tempdir + "\IPSW" + KernelCacheName, tempdir + "\IPSW" + KernelCacheName.Replace("kernelcache", "RestoreKernelCache_kernelcache"), CurrentKernelCacheIV, CurrentKernelCacheKey, True)
        'End If
        '<---------------------------------------------------------------------------------------------------------------->

        '<----------------------------------------- Ramdisk stuff -------------------------------------------------------->
        DowngradeProgressBar.Value = 40
        ProgressLabel.Text = "40% - Decrypting Ramdisk..."
        xpwntool(tempdir + "\IPSW" + RestoreRamdiskName, tempdir + "\IPSW\ramdisk.dmg", CurrentRestoreRamdiskIV, CurrentRestoreRamdiskKey, False)
        DowngradeProgressBar.Value = 45
        ProgressLabel.Text = "45% - Preparing Ramdisk..."
        PrepareRamdisk(tempdir + "\IPSW\ramdisk.dmg")
        DowngradeProgressBar.Value = 47
        ProgressLabel.Text = "47% - Preparing Ramdisk for kloader..."
        xpwntool(tempdir + "\IPSW\ramdisk.dmg", tempdir + "\IPSW\ramdisk_re-encrypted.dmg", CurrentRestoreRamdiskIV, CurrentRestoreRamdiskKey, False, tempdir + "\IPSW" + RestoreRamdiskName)
        Delete(False, tempdir + "\IPSW" + RestoreRamdiskName)
        xpwntool(tempdir + "\IPSW\ramdisk_re-encrypted.dmg", tempdir + "\IPSW" + RestoreRamdiskName, CurrentRestoreRamdiskIV, CurrentRestoreRamdiskKey, True)
        DowngradeProgressBar.Value = 50
        ProgressLabel.Text = "50% - Cleaning Up..."
        File.Delete(tempdir + "\IPSW\ramdisk.dmg")
        File.Delete(tempdir + "\IPSW\ramdisk_re-encrypted.dmg")
        '<---------------------------------------------------------------------------------------------------------------->

        DowngradeProgressBar.Value = 55
        ProgressLabel.Text = "55% - Processing Filesystem..."
        ProcessRootFS(tempdir + "\IPSW" + rootfsName)

        If OTADowngrade = False Then
            DowngradeProgressBar.Value = 60
            ProgressLabel.Text = "60% - Signing IPSW..."
            SignIMG3Set(iOSAsInteger(), False)


            DowngradeProgressBar.Value = 70
            ProgressLabel.Text = "60% - Adding 'apticket.img3'..."
            If APTicket.Length <> 0 Then
                WriteBytesToFile(APTicket, tempdir + "\apticket.der")
                IMG3ApTicket(APTicket, tempdir + "\IPSW\Firmware\all_flash" + all_flashFolder + "\apticket.img3")
                Dim manifest As Byte() = File.ReadAllBytes(tempdir + "\IPSW\Firmware\all_flash" + all_flashFolder + "\manifest")
                Delete(False, tempdir + "\IPSW\Firmware\all_flash" + all_flashFolder + "\manifest")
                Dim fs As New System.IO.FileStream(tempdir + "\IPSW\Firmware\all_flash" + all_flashFolder + "\manifest", System.IO.FileMode.Append, System.IO.FileAccess.Write, System.IO.FileShare.ReadWrite)
                fs.Write(ConvertHexStringToByteArray("61707469636b65742e696d67330a"), 0, ConvertHexStringToByteArray("61707469636b65742e696d67330a").Length)
                fs.Write(manifest, 0, manifest.Length)
                fs.Close()
            End If


        End If
        DowngradeProgressBar.Value = 80
        ProgressLabel.Text = "80% - Generating Beehind manifest file..."
        WriteBeehindXML(tempdir + "\IPSW\Beehind.xml")

        DowngradeProgressBar.Value = 90
        ProgressLabel.Text = "90% - Re-Packing Custom Firmware..."
        Zip(tempdir + "\IPSW\final.zip", "*", tempdir + "\IPSW")
        CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "\" + CurrentDecimalECID + "_" + DeviceModel + "_" + iOS_Version + "_" + iOS_Build + "_kloader-bundle", True)
        File.Move(tempdir + "\IPSW\final.zip", Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\" + CurrentDecimalECID + "_" + DeviceModel + "_" + iOS_Version + "_" + iOS_Build + "_kloader-bundle" + "\" + CurrentDecimalECID + "_" + DeviceModel + "_" + iOS_Version + "_" + iOS_Build + "-kloader'signed'.ipsw")
        File.Move(tempdir + "\IPSW\Firmware\dfu" + iBSSName, Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\" + CurrentDecimalECID + "_" + DeviceModel + "_" + iOS_Version + "_" + iOS_Build + "_kloader-bundle" + "\" + DeviceModel + "_" + iOS_Version + "_" + iOS_Build + "_iBSS-pwned.img3")
        DowngradeProgressBar.Value = 95
        ProgressLabel.Text = "95% - (Re)cleaning up..."
        Delete(False, tempdir + "\apticket.der")
        Delete(False, tempdir + "\tss-request.plist")
        If OTADowngrade = True Then
            File.Copy(XMLPath, Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\" + CurrentDecimalECID + "_" + DeviceModel + "_" + iOS_Version + "_" + iOS_Build + "_kloader-bundle\" + CurrentDecimalECID + "-" + DeviceModel + "-" + iOS_Version + "-" + iOS_Build + "_OTABlobs.plist")
        End If
        Delete(False, XMLPath)
        Delete(True, tempdir + "\IPSW")
        DowngradeProgressBar.Value = 100
        ProgressLabel.Text = "100% - Done!"
        My.Computer.Audio.Play(My.Resources.sound_completed, _
            AudioPlayMode.Background)
        MessageBox.Show("Done! A new directory has been created on your desktop containing the custom IPSW and a patched iBSS (required for entering in Pwned DFU Mode)")
        If OTADowngrade = True = True Then
            MessageBox.Show("Since you've chosen an OTA downgrade, this firmware is not signed; it will be signed during the restore. For safety reasons, you'll also find a .plist file inside the new folder on your Desktop. Keep it in a secure place, because that is the only way to go back to iOS 6.1.3 if Apple will close this signing window")
        End If
        Reset()
        KloaderInjector.iBSSPathTextBox.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\" + CurrentDecimalECID + "_" + DeviceModel + "_" + iOS_Version + "_" + iOS_Build + "_kloader-bundle\" + DeviceModel + "_" + iOS_Version + "_" + iOS_Build + "_iBSS-pwned.img3"
        idevicerestoreGUI.IPSWPathTextBox.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\" + CurrentDecimalECID + "_" + DeviceModel + "_" + iOS_Version + "_" + iOS_Build + "_kloader-bundle" + "\" + CurrentDecimalECID + "_" + DeviceModel + "_" + iOS_Version + "_" + iOS_Build + "-kloader'signed'.ipsw"
        KloaderInjector.MdiParent = Form1
        KloaderInjector.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles CancelOTADWN.Click
        CancelOTADWN.Visible = False
        OTADowngrade = False
        ChooseSHSHButton.Enabled = True
        SHSHGroupBox.Enabled = True
        IPSWGroupBox.Text = "Browse for the IPSW"
        IPSWTextBox.Text = ""
        SHSHGroupBox.Text = "Browse for SHSH"
        iOS_Version = ""
        iOS_Build = ""
        DeviceModel = ""
        board_id = ""
        iPhoneProcessor = ""
        CurrentRootFSKey = ""
        CurrentRestoreRamdiskIV = ""
        CurrentRestoreRamdiskKey = ""
        CurrentUpdateRamdiskIV = ""
        CurrentUpdateRamdiskKey = ""
        CurrentAppleLogoIV = ""
        CurrentAppleLogoKey = ""
        CurrentBatteryCharging0IV = ""
        CurrentBatteryCharging0Key = ""
        CurrentBatteryCharging1IV = ""
        CurrentBatteryCharging1Key = ""
        CurrentBatteryFullIV = ""
        CurrentBatteryFullKey = ""
        CurrentBatteryLow0IV = ""
        CurrentBatteryLow0Key = ""
        CurrentBatteryLow1IV = ""
        CurrentBatteryLow1Key = ""
        CurrentDeviceTreeIV = ""
        CurrentDeviceTreeKey = ""
        CurrentGlyphPluginIV = ""
        CurrentGlyphPluginKey = ""
        CurrentIBECIV = ""
        CurrentIBECKey = ""
        CurrentiBootIV = ""
        CurrentiBootKey = ""
        CurrentIBSSIV = ""
        CurrentIBSSKey = ""
        CurrentKernelCacheIV = ""
        CurrentKernelCacheKey = ""
        CurrentLLBIV = ""
        CurrentLLBKey = ""
        CurrentRecoveryModeIV = ""
        CurrentRecoveryModeKey = ""
        all_flashFolder = ""
        rootfsName = ""
        UpdateRamdiskName = ""
        RestoreRamdiskName = ""
        AppleLogoName = ""
        BatteryCharging0Name = ""
        BatteryCharging1Name = ""
        BatteryFullName = ""
        BatteryLow0Name = ""
        BatteryLow1Name = ""
        DeviceTreeName = ""
        GlyphPluginName = ""
        iBECName = ""
        iBootName = ""
        iBSSName = ""
        KernelCacheName = ""
        LLBName = ""
        RecoveryModeName = ""
        ECIDForm.Close()
        IPSWGroupBox.Text = "Browse for the IPSW"
        IPSWGroupBox.Enabled = True
        PathLabelIPSW.Text = "Path: "
        IPSWTextBox.Enabled = False
        IPSWTextBox.Text = ""
        ChooseIPSWButton.Text = "Choose"
        ChooseIPSWButton.Enabled = True
        ChooseIPSWButton.Visible = True

        SHSHGroupBox.Text = "Browse for SHSH"
        SHSHGroupBox.Enabled = True
        PathLabelSHSH.Text = "Path: "
        SHSHTextBox.Enabled = False
        SHSHTextBox.Text = ""
        ChooseSHSHButton.Text = "Choose"
        ChooseSHSHButton.Enabled = True
        ChooseSHSHButton.Visible = True
        SHSHPath = ""
        XMLPath = ""
        CancelOTADWN.Visible = False
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Process.Start("http://www.twitter.com/blackgeektuto")
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Process.Start("http://beehind.geeksn0w.it")
    End Sub

    Private Sub LinkLabel1_LinkClicked_1(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start("http://www.geeksn0w.it/donate.html")

    End Sub

    Private Sub CustomBundleCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles CustomBundleCheckBox.CheckedChanged
        BasebandFileDialog.FileName = ""
        BasebandFileDialog.InitialDirectory = GetFolderPath(SpecialFolder.DesktopDirectory)
        BasebandFileDialog.Filter = "TAR Bundles|*.tar;*.tgz;"
        If BasebandFileDialog.ShowDialog = DialogResult.Abort Then
            Exit Sub
        End If
        CustomBundlePath = BasebandFileDialog.FileName
    End Sub

    Private Sub AddSSHCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles AddSSHCheckBox.CheckedChanged
        If AddSSHCheckBox.Checked = True Then
            AddUntetherCheckBox.Checked = True
        End If

    End Sub

    Private Sub AddUntetherCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles AddUntetherCheckBox.CheckedChanged
        If AddUntetherCheckBox.Checked = False Then
            AddSSHCheckBox.Checked = False
            AddCydiaCheckBox.Checked = False
            HacktivateCheckBox.Checked = False
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles AddCydiaCheckBox.CheckedChanged
        If AddCydiaCheckBox.Checked = True Then
            AddUntetherCheckBox.Checked = True
            MessageBox.Show("Please, in order to have a working Cydia, you will have to reboot your device after the downgrade; it always crashes after the first boot due to apps stashing!")
        End If
    End Sub

    Private Sub HacktivateCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles HacktivateCheckBox.CheckedChanged
        If HacktivateCheckBox.Checked = True Then
            If OTADowngrade = True Then
                MessageBox.Show("Refusing to Hacktivate the device since it makes no sense if you're doing an OTA Downgrade...", "No Hacktivation",
                               MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                HacktivateCheckBox.Checked = False
                Exit Sub
            End If

            If DeviceModel = "iPod4,1" Or DeviceModel = "iPod5,1" Or DeviceModel = "iPad2,1" Or DeviceModel = "iPad3,1" Or DeviceModel = "iPad2,5" Or DeviceModel = "iPad3,4" Then
                MessageBox.Show("Why should you Hacktivate a Wi-Fi Only device? No baseband problems :P")
                HacktivateCheckBox.Checked = False
            End If
            AddUntetherCheckBox.Checked = True
        End If

    End Sub

    Private Sub NoNANDFlashCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles NoNANDFlashCheckBox.CheckedChanged
        If NoNANDFlashCheckBox.Checked = True Then
            Dim UserChoice As Integer = MessageBox.Show("Avoiding NOR flashing will render your device unbootable! I added this option only for expert users who know what these things are... Do you really want to enable it?", "Are you sure about that?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If UserChoice = DialogResult.No Then
                NoNANDFlashCheckBox.Checked = False
            End If
        End If
    End Sub

    Private Sub NoSysFlashCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles NoSysFlashCheckBox.CheckedChanged
        If NoSysFlashCheckBox.Checked = True Then
            MessageBox.Show("You've chosen to avoid system flashing. This menas that when you restore to this IPSW, iTunes will only flash Baseband and NOR stuff, so you won't lose any data after the restore. This could be helpful in some cases, but it only works if you're restoring to the same iOS version installed on your device...", "Keep in mind", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CustomSizeCheckBox.Checked = False
            End If
    End Sub

    Private Sub CustomSizeCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles CustomSizeCheckBox.CheckedChanged
        If CustomSizeCheckBox.Checked = True Then
            NoSysFlashCheckBox.Checked = False
        End If
    End Sub
End Class