Imports Beehind.Common_Functions
Imports Beehind.Common_Definitions
Imports Beehind.Processes
Imports Beehind.SignIMG3
Imports System.IO
Imports Beehind.AddUntethers

Public Class IMG3Patches

    Public Shared Sub ProcessRootFS(Infile As String)
        CreateDirectory(tempdir, "\rootfs-patch", True)
        dmg("extract " + """" + Infile + """" + " " + """" + tempdir + "\IPSW" + rootfsName + ".extracted" + """" + " " + "-k " + CurrentRootFSKey)
        File.Delete(tempdir + "\IPSW" + rootfsName)
        Dim RootFSInfo As New FileInfo(tempdir + "\IPSW" + rootfsName + ".extracted")
        hfsplus("""" + Infile + ".extracted" + """" + " grow " + (CLng(RootFSInfo.Length + &H25000000)).ToString)

        If MainView.HacktivateCheckBox.Checked = True Then
            MainView.ProgressLabel.Text = "55% - Hacktivating..."
            hfsplus("""" + Infile + ".extracted" + """" + " extract " + """" + "/usr/libexec/lockdownd" + """" + " " + """" + tempdir + "\rootfs-patch\lockdownd" + """")
            hfsplus("""" + Infile + ".extracted" + """" + " rm " + """" + "/usr/libexec/lockdownd" + """")
            PatchLockdownd(tempdir + "\rootfs-patch\lockdownd")
            hfsplus("""" + Infile + ".extracted" + """" + " add " + """" + tempdir + "\rootfs-patch\lockdownd" + """" + " " + """" + "/usr/libexec/lockdownd" + """")
            hfsplus("""" + Infile + ".extracted" + """" + " chmod 100755 " + """" + "/usr/libexec/lockdownd" + """")
        End If

        If MainView.AddUntetherCheckBox.Checked = True Then
            AddUntetherPayload(tempdir + "\IPSW" + rootfsName + ".extracted")
        End If

        If MainView.AddSSHCheckBox.Checked = True Then
            AddSSH(tempdir + "\IPSW" + rootfsName + ".extracted")
        End If

        If MainView.AddCydiaCheckBox.Checked = True Then
            AddCydia(tempdir + "\IPSW" + rootfsName + ".extracted")
        End If

        If MainView.BasebandCheckBox.Checked = True Then
            MainView.ProgressLabel.Text = "55% - Adding baseband..."
            If BasebandPath = "" Then
                BasebandPath = tempdir + "\baseband.tar"
            End If

            If File.Exists(BasebandPath) Then
                Dim BasebandDumpInfo As New FileInfo(BasebandPath)
                hfsplus("""" + Infile + ".extracted" + """" + " grow " + (CLng(RootFSInfo.Length + BasebandDumpInfo.Length + &H280000L)).ToString + """")
                hfsplus("""" + Infile + ".extracted" + """" + " untar " + """" + BasebandPath + """" + " " + """" + "/" + """")
            End If
        End If

        If MainView.CustomBundleCheckBox.Checked = True Then
            MainView.ProgressLabel.Text = "55% - Installing Custom bundle..."
            If CustomBundlePath <> "" Then
                If File.Exists(CustomBundlePath) Then
                    Dim PayloadInfo As New FileInfo(CustomBundlePath)
                    hfsplus("""" + Infile + ".extracted" + """" + " grow " + (CLng(RootFSInfo.Length + PayloadInfo.Length)).ToString + """")
                    hfsplus("""" + Infile + ".extracted" + """" + " untar " + """" + CustomBundlePath + """" + " " + """" + "/" + """")
                End If
            End If
        End If

        MainView.ProgressLabel.Text = "55% - Rebuilding RootFS..."
        dmg("build " + """" + Infile + ".extracted" + """" + " " + """" + Infile + """")
        Delete(False, Infile + ".extracted")
        Delete(True, tempdir + "\rootfs-patch")
    End Sub

    Public Shared Sub PrepareRamdisk(Infile As String)
        CreateDirectory(tempdir + "\", "ramdisk-patch", True)
        Dim ramdiskinfo As FileInfo = My.Computer.FileSystem.GetFileInfo(Infile)
        hfsplus("""" + Infile + """" + " grow " + (CLng(ramdiskinfo.Length + &H280000L)).ToString)
        hfsplus("""" + Infile + """" + " extract " + """" + "/usr/sbin/asr" + """" + " " + """" + tempdir + "\ramdisk-patch\asr" + """")
        hfsplus("""" + Infile + """" + " extract " + """" + "/usr/local/bin/restored_external" + """" + " " + """" + tempdir + "\ramdisk-patch\restored_external" + """")
        'hfsplus(Infile + " extract " + """" + "/usr/local/share/restore/options.plist" + """" + " " + """" + tempdir + "\ramdisk-patch\options.plist" + """")
        hfsplus("""" + Infile + """" + " extract " + """" + "/usr/local/share/restore/options." + KernelCacheName.Replace("\kernelcache.release.", "") + ".plist" + """" + " " + """" + tempdir + "\ramdisk-patch\options.plist" + """")

        Dim OptionsPlistFileInfo As New FileInfo(tempdir + "\ramdisk-patch\options.plist")
        Dim OptionsPlistSize As Long = OptionsPlistFileInfo.Length
        If OptionsPlistSize = 0 Then
            hfsplus(Infile + " extract " + """" + "/usr/local/share/restore/options.plist" + """" + " " + """" + tempdir + "\ramdisk-patch\options.plist" + """")
        End If

        hfsplus("""" + Infile + """" + " rm " + """" + "/usr/sbin/asr" + """")
        hfsplus("""" + Infile + """" + " rm " + """" + "/usr/local/bin/restored_external" + """")
        hfsplus(Infile + " rm " + """" + "/usr/local/share/restore/options.plist" + """")
        hfsplus("""" + Infile + """" + " rm " + """" + "/usr/local/share/restore/options." + KernelCacheName.Replace("\kernelcache.release.", "") + ".plist" + """")
        PatchOptionsPlist(tempdir + "\ramdisk-patch\options.plist")

        'RestoredExternal Stuff
        If DowngradeType <> "OTA" Then
            If File.Exists(bundlesdir + "\Down_" + DeviceModel + "_" + iOS_Version + "_" + iOS_Build + ".bundle\restored_external.patch") Then
                RestoredExternalPatch = True
                bspatch(tempdir + "\ramdisk-patch\restored_external", tempdir + "\ramdisk-patch\restored_external.patched", bundlesdir + "\Down_" + DeviceModel + "_" + iOS_Version + "_" + iOS_Build + ".bundle\restored_external.patch")
                Delete(False, tempdir + "\ramdisk-patch\restored_external")
                Rename(tempdir + "\ramdisk-patch\restored_external.patched", tempdir + "\ramdisk-patch\restored_external")
            Else
                RestoredExternalPatch = False
            End If
        End If

        'Patch ASR
        bspatch(tempdir + "\ramdisk-patch\asr", tempdir + "\ramdisk-patch\asr.patched", bundlesdir + "\Down_" + DeviceModel + "_" + iOS_Version + "_" + iOS_Build + ".bundle\asr.patch")
        Delete(False, tempdir + "\ramdisk-patch\asr")
        Rename(tempdir + "\ramdisk-patch\asr.patched", tempdir + "\ramdisk-patch\asr")

        'Repacking
        hfsplus("""" + Infile + """" + " add " + """" + tempdir + "\ramdisk-patch\options.plist" + """" + " " + """" + "/usr/local/share/restore/options." + KernelCacheName.Replace("\kernelcache.release.", "") + ".plist" + """")
        hfsplus(Infile + " add " + """" + tempdir + "\ramdisk-patch\options.plist" + """" + " " + """" + "/usr/local/share/restore/options.plist" + """")
        hfsplus("""" + Infile + """" + " add " + """" + tempdir + "\ramdisk-patch\asr" + """" + " " + """" + "/usr/sbin/asr" + """")
        hfsplus("""" + Infile + """" + " add " + """" + tempdir + "\ramdisk-patch\restored_external" + """" + " " + """" + "/usr/local/bin/restored_external" + """")
        hfsplus("""" + Infile + """" + " chmod 100755 " + """" + "/usr/sbin/asr" + """")
        hfsplus("""" + Infile + """" + " chmod 100755 " + """" + "/usr/local/bin/restored_external" + """")
        hfsplus("""" + Infile + """" + " rm " + """" + "/usr/share/progressui/images-2x/" + "applelogo.png" + """")
        hfsplus("""" + Infile + """" + " add " + """" + tempdir + "\restore-images\images-2x\" + "applelogo.png" + """" + " " + """" + "/usr/share/progressui/images-2x/" + "applelogo.png" + """")
        hfsplus("""" + Infile + """" + " rm " + """" + "/usr/share/progressui/images-1x/" + "applelogo.png" + """")
        hfsplus("""" + Infile + """" + " add " + """" + tempdir + "\restore-images\images-1x\" + "applelogo.png" + """" + " " + """" + "/usr/share/progressui/images-1x/" + "applelogo.png" + """")
        Delete(True, tempdir + "\ramdisk-patch")
    End Sub

    Public Shared Sub PatchLockdownd(Infile)
        If iOS_Version = "6.1.3" Then
            HexPatchFile(Infile, Infile, "4210d141", "4213e041")
            HexPatchFile(Infile, Infile, "0cf03bfd", "01200120")
            HexPatchFile(Infile, Infile, "8e66ac9a17ff555100d599fd894fadca7457f597", "9aa58067f7619127625502645f8efd18b2d1355c")
        End If
    End Sub

    Public Shared Sub PatchOptionsPlist(Infile As String)
        If DowngradeType <> "OTA" Then
            HexPatchFile(Infile, Infile, "3c2f646963743e0a3c2f706c6973743e0a", "093c6b65793e5570646174654261736562616e643c2f6b65793e0a093c66616c73652f3e0a3c2f646963743e0a3c2f706c6973743e0a")
        End If

        If MainView.CustomSizeCheckBox.Checked = True Then
            Dim OriginalRootFsSize As String = GetOriginalRootfsSize(Infile)
            Dim NewRootFsSize As String = MainView.NewSizeUpDown.Value.ToString

            If Convert.ToInt32(NewRootFsSize) > Convert.ToInt32(OriginalRootFsSize) Then
                HexPatchFile(Infile, Infile, "3c6b65793e53797374656d506172746974696f6e53697a653c2f6b65793e0a093c696e74656765723e" + ASCIIToHex(OriginalRootFsSize), "3c6b65793e53797374656d506172746974696f6e53697a653c2f6b65793e0a093c696e74656765723e" + ASCIIToHex(NewRootFsSize))
                HexPatchFile(Infile, Infile, "3c2f646963743e0a3c2f706c6973743e0a", "093c6b65793e46697453797374656d506172746974696f6e546f436f6e74656e743c2f6b65793e0a093c66616c73652f3e0a093c2f646963743e0a3c2f706c6973743e0a")
            End If
        End If

        If MainView.NoNANDFlashCheckBox.Checked = True Then
            HexPatchFile(Infile, Infile, "3c2f646963743e0a3c2f706c6973743e0a", "093c6b65793e466c6173684e4f523c2f6b65793e0a093c66616c73652f3e0a093c2f646963743e0a3c2f706c6973743e0a")
        End If

        If MainView.NoSysFlashCheckBox.Checked = True Then
            HexPatchFile(Infile, Infile, "3c2f646963743e0a3c2f706c6973743e0a", "093c6b65793e43726561746546696c6573797374656d506172746974696f6e733c2f6b65793e0a093c66616c73652f3e0a093c2f646963743e0a3c2f706c6973743e0a")
            HexPatchFile(Infile, Infile, "3c2f646963743e0a3c2f706c6973743e0a", "093c6b65793e53797374656d496d6167653c2f6b65793e0a093c66616c73652f3e0a093c2f646963743e0a3c2f706c6973743e0a")

        End If
    End Sub


    Public Shared Sub PatchBuildManifest(Infile As String)
        Dim RestoreDeviceTreeOriginalBytes As String = "526573746F7265446576696365547265653C2F6B65793E0A090909093C646963743E0A09090909093C6B65793E4469676573743C2F6B65793E0A09090909093C646174613E0A0909090909" + ASCIIToHex(ObtainRestoreDeviceTreeDigest(Infile)) + "0A09090909093C2F646174613E0A09090909093C6B65793E496E666F3C2F6B65793E0A09090909093C646963743E0A0909090909093C6B65793E506174683C2F6B65793E0A0909090909093C737472696E673E" + ASCIIToHex("Firmware/all_flash/" + all_flashFolder.Replace("\", "") + DeviceTreeName.Replace("\", "/")).ToString
        Dim RestoreDeviceTreePatchedBytes As String = "526573746F7265446576696365547265653C2F6B65793E0A090909093C646963743E0A09090909093C6B65793E4469676573743C2F6B65793E0A09090909093C646174613E0A0909090909" + ASCIIToHex(ObtainRestoreDeviceTreeDigest(Infile)) + "0A09090909093C2F646174613E0A09090909093C6B65793E496E666F3C2F6B65793E0A09090909093C646963743E0A0909090909093C6B65793E506174683C2F6B65793E0A0909090909093C737472696E673E" + ASCIIToHex("Firmware/all_flash/" + all_flashFolder.Replace("\", "") + DeviceTreeName.Replace("\DeviceTree", "/RestoreDeviceTree_DeviceTree")).ToString

        Dim RestoreLogoOriginalBytes As String = "526573746F72654C6F676F3C2F6B65793E0A090909093C646963743E0A09090909093C6B65793E4469676573743C2F6B65793E0A09090909093C646174613E0A0909090909" + ASCIIToHex(ObtainRestoreLogoDigest(Infile)) + "0A09090909093C2F646174613E0A09090909093C6B65793E496E666F3C2F6B65793E0A09090909093C646963743E0A0909090909093C6B65793E506174683C2F6B65793E0A0909090909093C737472696E673E" + ASCIIToHex("Firmware/all_flash/" + all_flashFolder.Replace("\", "") + AppleLogoName.Replace("\", "/")).ToString
        Dim RestoreLogoPatchedBytes As String = "526573746F72654C6F676F3C2F6B65793E0A090909093C646963743E0A09090909093C6B65793E4469676573743C2F6B65793E0A09090909093C646174613E0A0909090909" + ASCIIToHex(ObtainRestoreLogoDigest(Infile)) + "0A09090909093C2F646174613E0A09090909093C6B65793E496E666F3C2F6B65793E0A09090909093C646963743E0A0909090909093C6B65793E506174683C2F6B65793E0A0909090909093C737472696E673E" + ASCIIToHex("Firmware/all_flash/" + all_flashFolder.Replace("\", "") + AppleLogoName.Replace("\applelogo", "/RestoreLogo_applelogo")).ToString

        Dim RestoreKernelCacheOriginalBytes As String = "526573746F72654B65726E656C43616368653C2F6B65793E0A090909093C646963743E0A09090909093C6B65793E4469676573743C2F6B65793E0A09090909093C646174613E0A0909090909" + ASCIIToHex(ObtainRestoreKernelCacheDigest(Infile)) + "0A09090909093C2F646174613E0A09090909093C6B65793E496E666F3C2F6B65793E0A09090909093C646963743E0A0909090909093C6B65793E506174683C2F6B65793E0A0909090909093C737472696E673E" + ASCIIToHex(KernelCacheName.Replace("\", ""))
        Dim RestoreKernelCachePatchedBytes As String = "526573746F72654B65726E656C43616368653C2F6B65793E0A090909093C646963743E0A09090909093C6B65793E4469676573743C2F6B65793E0A09090909093C646174613E0A0909090909" + ASCIIToHex(ObtainRestoreKernelCacheDigest(Infile)) + "0A09090909093C2F646174613E0A09090909093C6B65793E496E666F3C2F6B65793E0A09090909093C646963743E0A0909090909093C6B65793E506174683C2F6B65793E0A0909090909093C737472696E673E" + ASCIIToHex(KernelCacheName.Replace("\kernelcache", "RestoreKernelCache_kernelcache"))

        'MessageBox.Show("Original UniqueBuildID is: " + ObtainUniqueBuildID(Infile))

        Dim OTABuildID As String = String.Empty
        Dim OTARamdiskDigest As String = String.Empty
        Dim OTARamdiskPartialDigest As String = String.Empty

        If DeviceModel = "iPad2,1" Then
            OTABuildID = "tmhlqSVs3hfYDCFEF1CNxG9edO8"
            OTARamdiskDigest = ""
            OTARamdiskPartialDigest = ""
        ElseIf DeviceModel = "iPad2,2" Then
            OTABuildID = "8iAuVn4UX8D2WcdqFQyoa"
            OTARamdiskDigest = ""
            OTARamdiskPartialDigest = ""
        ElseIf DeviceModel = "iPad2,3" Then
            OTABuildID = "k8/0Wy73uXDFAc84NnXIXIXUnHI="
            OTARamdiskDigest = ""
            OTARamdiskPartialDigest = ""
        End If

        'Dim UniqueBuildIDOriginalBytes As String = "556e697175654275696c6449443c2f6b65793e0a0909093c646174613e0a090909" + ASCIIToHex(ObtainUniqueBuildID(Infile))
        'Dim UniqueBuildIDPatchedBytes As String = "556e697175654275696c6449443c2f6b65793e0a0909093c646174613e0a090909" + ASCIIToHex(OTABuildID)

        HexPatchFile(Infile, Infile, RestoreDeviceTreeOriginalBytes, RestoreDeviceTreePatchedBytes)
        HexPatchFile(Infile, Infile, RestoreLogoOriginalBytes, RestoreLogoPatchedBytes)
        HexPatchFile(Infile, Infile, RestoreKernelCacheOriginalBytes, RestoreKernelCachePatchedBytes)

        HexPatchFile(Infile, Infile, RestoreDeviceTreeOriginalBytes, RestoreDeviceTreePatchedBytes)
        HexPatchFile(Infile, Infile, RestoreLogoOriginalBytes, RestoreLogoPatchedBytes)
        HexPatchFile(Infile, Infile, RestoreKernelCacheOriginalBytes, RestoreKernelCachePatchedBytes)

        'HexPatchFile(Infile, Infile, UniqueBuildIDOriginalBytes, UniqueBuildIDPatchedBytes)
        'HexPatchFile(Infile, Infile, UniqueBuildIDOriginalBytes, UniqueBuildIDPatchedBytes)
    End Sub

End Class
