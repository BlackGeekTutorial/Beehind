Imports Beehind.Common_Functions
Imports Beehind.Common_Definitions
Imports Beehind.Processes
Imports Beehind.SignIMG3
Imports System.IO
Imports Beehind.AddUntethers

Public Class IMG3Patches

    Public Shared Sub PatchIBSS(DecryptedIBSS As String, outfile As String)
        If iOSAsInteger() = 4 Then
            If DeviceModel = "iPhone3,1" Then
                HexPatchFile(DecryptedIBSS, outfile, "feffffea00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000", "feffffea04a213681b1c03d05068c8500832f8e77047c046d8037200ead10120e0d98c0030e000205cdb270001000000e4d98c0000202de0")
                HexPatchFile(outfile, outfile, "fff773fe", "00200020")
                HexPatchFile(outfile, outfile, "fff760fe", "00200020")
                HexPatchFile(outfile, outfile, "fff7b6fe", "00200020")
                HexPatchFile(outfile, outfile, "fff73afe", "00200020")
                HexPatchFile(outfile, outfile, "fff729fe", "00200020")
                HexPatchFile(outfile, outfile, "fff717fe", "00200020")
                HexPatchFile(outfile, outfile, "fff705fe", "00200020")
                HexPatchFile(outfile, outfile, "fff7f6fd", "00200020")
                HexPatchFile(outfile, outfile, "fff7e4fd", "00200020")
                HexPatchFile(outfile, outfile, "08f00d", "ecf74b")
                HexPatchFile(outfile, outfile, "4ff0ff30", "00200020")
            End If
        End If

        If iOSAsInteger() = 5 Then
            If DeviceModel = "iPhone3,1" Then
                'patches di ios 5.1.1 per iPhone 4
                HexPatchFile(DecryptedIBSS, outfile, "fff742fe", "00200020")
                HexPatchFile(outfile, outfile, "fff72ffe", "00200020")
                HexPatchFile(outfile, outfile, "fff710fe", "00200020")
                HexPatchFile(outfile, outfile, "fff7fefd", "00200020")
                HexPatchFile(outfile, outfile, "fff7e8fd", "00200020")
                HexPatchFile(outfile, outfile, "fff7d6fd", "00200020")
                HexPatchFile(outfile, outfile, "fff7c4fd", "00200020")
                HexPatchFile(outfile, outfile, "fff7affd", "00200020")
                HexPatchFile(outfile, outfile, "18f000fb", "e9f7c0ff")
                HexPatchFile(outfile, outfile, "4ff0ff30", "00200020")
                HexPatchFile(outfile, outfile, "4ff0ff30", "00200020")
            End If
        End If

        If iOSAsInteger() = 6 Then
            If DeviceModel = "iPhone3,1" Or DeviceModel = "iPod4,1" Then
                'patches di ios 6.1.3 per iPhone 4 e di ios 6.1 per iPod touch 4
                HexPatchFile(DecryptedIBSS, outfile, "fff7a0fd", "00201860")

            ElseIf DeviceModel = "iPhone4,1" Then
                'patches di ios 6.1.3 per iPhone 4S
                HexPatchFile(DecryptedIBSS, outfile, "60e86800", "60002000")
                HexPatchFile(outfile, outfile, "fff7a0fd", "00201860")
                HexPatchFile(outfile, outfile, "3098bb85", "30002085")
                HexPatchFile(outfile, outfile, "81bb05ab", "30e005ab")
            ElseIf DeviceModel = "iPhone5,2" Then
                'patches di ios 6.1.4 per iPhone 5,2
                HexPatchFile(DecryptedIBSS, outfile, "e8680028", "00200028")
                HexPatchFile(outfile, outfile, "fff7a0fd", "00201860")
                HexPatchFile(outfile, outfile, "ff3098bb", "ff300020")
                HexPatchFile(outfile, outfile, "81bb05ab", "30e005ab")
            ElseIf DeviceModel = "iPad2,1" Then 'verificate
                HexPatchFile(DecryptedIBSS, outfile, "e8680028", "00200028")
                HexPatchFile(outfile, outfile, "fff7a0fd", "00201860")
                HexPatchFile(outfile, outfile, "ff3098bb", "ff300020")
                HexPatchFile(outfile, outfile, "81bb05ab", "30e005ab")

            ElseIf DeviceModel = "iPad2,2" Then 'verificate
                HexPatchFile(DecryptedIBSS, outfile, "e8680028", "00200028")
                HexPatchFile(outfile, outfile, "fff7a0fd", "00201860")
                HexPatchFile(outfile, outfile, "98bb85f0", "002085f0")
                HexPatchFile(outfile, outfile, "81bb05ab", "30e005ab")
            ElseIf DeviceModel = "iPad2,3" Then 'verificate
                HexPatchFile(DecryptedIBSS, outfile, "E8680028", "00200028")
                HexPatchFile(outfile, outfile, "FFF7A0FD", "00201860")
                HexPatchFile(outfile, outfile, "FF3098BB", "FF300020")
                HexPatchFile(outfile, outfile, "81BB05AB", "30E005AB")
            ElseIf DeviceModel = "iPad3,1" Then
                'patches di ios 6.1.2 su ipad 3,1
                HexPatchFile(DecryptedIBSS, outfile, "e8680028", "00200028")
                HexPatchFile(outfile, outfile, "fff7a0fd", "00201860")
                HexPatchFile(outfile, outfile, "ff3098bb", "ff300020")
                HexPatchFile(outfile, outfile, "81bb05ab", "30e005ab")
            End If
        End If

        If iOSAsInteger() = 7 Then
            If DeviceModel = "iPhone3,1" Then
                HexPatchFile(DecryptedIBSS, outfile, "33676d49c0000100ac00010078010100", "33676d49c0000100ac00010000000000") 'patching first 20 bytes of 3gmI header
                HexPatchFile(outfile, outfile, "fff7ccfd", "00201860")
                HexPatchFile(outfile, outfile, "ff300028", "ff300020")
                HexPatchFile(outfile, outfile, "01010cd0", "010100bf")
            ElseIf DeviceModel = "iPhone4,1" Or DeviceModel = "iPhone3,1" Or DeviceModel = "iPad2,1" Or DeviceModel = "iPad3,1" Then
                'patches di ios 7.1.2 su iphone 4S
                HexPatchFile(DecryptedIBSS, outfile, "fff7ccfd", "00201860")
                HexPatchFile(outfile, outfile, "ff300028", "ff300020")
                HexPatchFile(outfile, outfile, "01010cd0", "010100bf")
            ElseIf DeviceModel = "iPhone5,4" Then
                'patches di ios 7.1.2 per iPhone 5,4
                HexPatchFile(DecryptedIBSS, outfile, "fff7ccfd", "00201860")
                HexPatchFile(outfile, outfile, "ff300028", "ff300020")
                HexPatchFile(outfile, outfile, "0cd0d8f8", "00bfd8f8")
            End If
        End If

        If iOSAsInteger() = 8 Then
            If DeviceModel = "iPhone5,2" Then

            End If
        End If

    End Sub
    Public Shared Sub PatchIBEC(DecryptedIBEC As String, outfile As String)
        If iOSAsInteger() = 5 Then
            If DeviceModel = "iPhone3,1" Then
                If iOS_Version = "5.1.1" Then
                    HexPatchFile(DecryptedIBEC, outfile, "feffffea0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000", "04a213681b1c03d05068c8500832f8e77047c04618475900002001219492a4001804002074480400a26a0123")
                    HexPatchFile(outfile, outfile, "fff742fe", "00200020")
                    HexPatchFile(outfile, outfile, "fff72ffe", "00200020")
                    HexPatchFile(outfile, outfile, "fff710fe", "00200020")
                    HexPatchFile(outfile, outfile, "fff7fefd", "00200020")
                    HexPatchFile(outfile, outfile, "fff7e8fd", "00200020")
                    HexPatchFile(outfile, outfile, "fff7d6fd", "00200020")
                    HexPatchFile(outfile, outfile, "fff7c4fd", "00200020")
                    HexPatchFile(outfile, outfile, "fff7affd", "00200020")
                    HexPatchFile(outfile, outfile, "18f000fb", "e9f7c0ff")
                    HexPatchFile(outfile, outfile, "4ff0ff30", "00200020")
                    HexPatchFile(outfile, outfile, "4ff0ff30", "00200020")
                End If
            End If
        End If

        If iOSAsInteger() = 6 Then
            If DeviceModel = "iPhone3,1" Then
                If iOS_Version = "6.1.3" Then
                    HexPatchFile(DecryptedIBEC, outfile, "feffffea00000000000000000000000000000000000000000000000000000000", "feffffea04a213681b1c03d05068c8500832f8e77047c04600ec0400ff2801d0")
                    HexPatchFile(outfile, outfile, "fff742fc", "00201860")
                    HexPatchFile(outfile, outfile, "04f0dbff", "01200120")
                    HexPatchFile(outfile, outfile, "18f096fe", "e5f7d6f9")
                    HexPatchFile(outfile, outfile, "9449002c94", "9049002c8f")
                    HexPatchFile(outfile, outfile, "0abff3", "781ff4")
                    HexPatchFile(outfile, outfile, "52656c69616e6365206f6e207468697320636572746966696361746520627920616e7920706172747920617373756d65732061636365", "72643d6d643020616d66693d307866662063735f656e666f7263656d656e745f64697361626c653d312070696f2d6572726f723d3000") 'patch ideata da me presa da ios 7
                End If

            ElseIf DeviceModel = "iPhone4,1" Then
                If iOS_Version = "6.1.3" Then
                    HexPatchFile(DecryptedIBEC, outfile, "feffffea00000000000000000000000000000000000000000000000000000000000000", "feffffea034a044bca50044a044bca50704700000120704708f54900002000201ee5ad")
                    HexPatchFile(outfile, outfile, "e8680028", "00200028")
                    HexPatchFile(outfile, outfile, "fff742fc", "00201860")
                    HexPatchFile(outfile, outfile, "16f0a4fa", "e4f756f8")
                    HexPatchFile(outfile, outfile, "ff3098bb", "ff300020")
                    HexPatchFile(outfile, outfile, "81bb05ab", "30e005ab")
                    HexPatchFile(outfile, outfile, "6110f09f", "00000080")
                End If
            ElseIf DeviceModel = "iPhone5,2" Then
                If iOS_Version = "6.1.4" Or iOS_Version = "6.1.2" Then
                    HexPatchFile(DecryptedIBEC, outfile, "feffffea00000000000000000000000000000000000000000000000000000000000000", "feffffea034a044bca50044a044bca507047000001207047181a4a00002000203e35a5")
                    HexPatchFile(outfile, outfile, "e8680028", "00200028")
                    HexPatchFile(outfile, outfile, "fff742fc", "00201860")
                    HexPatchFile(outfile, outfile, "16f0e0fa", "e3f754fc")
                    HexPatchFile(outfile, outfile, "ff3098bb", "ff300020")
                    HexPatchFile(outfile, outfile, "81bb05ab", "30e005ab")
                    HexPatchFile(outfile, outfile, "8910f0bf", "00000080")
                End If
            ElseIf DeviceModel = "iPad2,1" Then
                HexPatchFile(DecryptedIBEC, outfile, "feffffea00000000000000000000000000000000000000000000000000000000000000", "feffffea034a044bca50044a044bca50704700000120704708f54900002000201eb5a8")
                HexPatchFile(outfile, outfile, "e8680028", "00200028")
                HexPatchFile(outfile, outfile, "fff742fc", "00201860")
                HexPatchFile(outfile, outfile, "19f0faf9", "e3f7e8fe") '
                HexPatchFile(outfile, outfile, "ff3098bb", "ff300020")
                HexPatchFile(outfile, outfile, "81bb05ab", "30e005ab")
                HexPatchFile(outfile, outfile, "6110f09f", "00000080")

            ElseIf DeviceModel = "iPad2,2" Then
                If iOS_Version = "6.1.3" Then
                    HexPatchFile(DecryptedIBEC, outfile, "feffffea00000000000000000000000000000000000000000000000000000000000000", "feffffea034a044bca50044a044bca50704700000120704708f54900002000201eb5b0")
                    HexPatchFile(outfile, outfile, "e8680028", "00200028")
                    HexPatchFile(outfile, outfile, "fff742fc", "00201860")
                    HexPatchFile(outfile, outfile, "19f01afa", "e3f7e8fe")
                    HexPatchFile(outfile, outfile, "ff3098bb", "ff300020")
                    HexPatchFile(outfile, outfile, "81bb05ab", "30e005ab")
                    HexPatchFile(outfile, outfile, "6110f09f", "00000080")
                End If
            ElseIf DeviceModel = "iPad2,3" Then
                If iOS_Version = "6.1.3" Then
                    HexPatchFile(DecryptedIBEC, outfile, "FEFFFFEA0000000000000000000000000000000000000000000000000000000000000000", "FEFFFFEA034A044BCA50044A044BCA50704700000120704708F54900002000201E85B000")
                    HexPatchFile(outfile, outfile, "E8680028", "00200028")
                    HexPatchFile(outfile, outfile, "FFF742FC", "00201860")
                    HexPatchFile(outfile, outfile, "19F01AFA", "E3F7E8FE")
                    HexPatchFile(outfile, outfile, "FF3098BB85", "FF30002085")
                    HexPatchFile(outfile, outfile, "81BB05AB", "30E005AB")
                    HexPatchFile(outfile, outfile, "6110F09F", "00000080")
                End If
            ElseIf DeviceModel = "iPad3,1" Then
                If iOS_Version = "6.1.2" Then
                    HexPatchFile(DecryptedIBEC, outfile, "feffffea00000000000000000000000000000000000000000000000000000000000000", "feffffea034a044bca50044a044bca5070470000012070474ce44900002000201e35ae")
                    HexPatchFile(outfile, outfile, "e8680028", "00200028")
                    HexPatchFile(outfile, outfile, "fff742fc", "00201860")
                    HexPatchFile(outfile, outfile, "16f01efa", "e2f790f9")
                    HexPatchFile(outfile, outfile, "ff3098bb", "ff300020")
                    HexPatchFile(outfile, outfile, "81bb05ab", "30e005ab")
                    HexPatchFile(outfile, outfile, "6110f0bf", "00000080")
                End If
            End If
            If DeviceModel = "iPod4,1" Then
                If iOS_Version = "6.1" Then
                    HexPatchFile(DecryptedIBEC, outfile, "feffffea00000000000000000000000000000000000000000000000000000000", "feffffea04a213681b1c03d05068c8500832f8e77047c04600ec0400ff2801d0")
                    HexPatchFile(outfile, outfile, "fff742fc", "00201860")
                    HexPatchFile(outfile, outfile, "04f0d1ff", "01200120")
                    HexPatchFile(outfile, outfile, "18f0befd", "e6f736fc")
                    HexPatchFile(outfile, outfile, "9449002c94", "9049002c8f")
                    HexPatchFile(outfile, outfile, "8ca6f3", "b806f4")
                    HexPatchFile(outfile, outfile, "52656c69616e6365206f6e207468697320636572746966696361746520627920616e7920706172747920617373756d65732061636365", "72643d6d643020616d66693d307866662063735f656e666f7263656d656e745f64697361626c653d312070696f2d6572726f723d3000")
                End If
            End If
        End If

        If iOSAsInteger() = 7 Then

            If iOS_Version = "7.1.2" Then
                If DeviceModel = "iPhone3,1" Then
                    HexPatchFile(DecryptedIBEC, outfile, "33676d49c0500400ac50040078510400", "33676d49c0500400ac50040000000000")
                    HexPatchFile(outfile, outfile, "feffffea00000000000000000000000000000000000000000000000000000000000000", "feffffea034a044bca50044a044bca507047000001207047f8bf760000200020a2d084")
                    HexPatchFile(outfile, outfile, "fff774fc", "00201860")
                    HexPatchFile(outfile, outfile, "c348294618f064ff", "c3482946e5f7e4f9")
                    HexPatchFile(outfile, outfile, "ff300028", "ff300020")
                    HexPatchFile(outfile, outfile, "01010cd0", "010100bf")
                    HexPatchFile(outfile, outfile, "7111f05f", "00000040")
                ElseIf DeviceModel = "iPhone4,1" Then
                    HexPatchFile(DecryptedIBEC, outfile, "feffffea00000000000000000000000000000000000000000000000000000000000000", "feffffea034a044bca50044a044bca507047000001207047f89f550000200020a250b9")
                    HexPatchFile(outfile, outfile, "fff774fc", "00201860")
                    HexPatchFile(outfile, outfile, "16f046ff", "e4f738f9")
                    HexPatchFile(outfile, outfile, "ff300028", "ff300020")
                    HexPatchFile(outfile, outfile, "01010cd0", "010100bf")
                    HexPatchFile(outfile, outfile, "7111f09f", "00000080")
                ElseIf DeviceModel = "iPhone5,4" Then
                    HexPatchFile(DecryptedIBEC, outfile, "10ff2fe1feffffea00000000000000000000000000000000000000000000000000000000000000", "10ff2fe1feffffea034a044bca50044a044bca507047000001207047b0f1550000200020ae80b2")
                    HexPatchFile(outfile, outfile, "fff774fc", "00201860")
                    HexPatchFile(outfile, outfile, "17f052f9", "e3f750fa")
                    HexPatchFile(outfile, outfile, "ff300028", "ff300020")
                    HexPatchFile(outfile, outfile, "01010cd0", "010100bf")
                    HexPatchFile(outfile, outfile, "9911f0bf", "00000080")
                ElseIf DeviceModel = "iPad2,1" Then
                    HexPatchFile(DecryptedIBEC, outfile, "feffffea00000000000000000000000000000000000000000000000000000000000000", "feffffea034a044bca50044a044bca507047000001207047f89f550000200020a2f0b3")
                    HexPatchFile(outfile, outfile, "fff774fc", "00201860")
                    HexPatchFile(outfile, outfile, "19f0b2fa", "e3f7e2ff")
                    HexPatchFile(outfile, outfile, "ff300028", "ff300020")
                    HexPatchFile(outfile, outfile, "01010cd0", "010100bf")
                    HexPatchFile(outfile, outfile, "7111f09f", "00000080")
                ElseIf DeviceModel = "iPad3,1" Then
                    HexPatchFile(DecryptedIBEC, outfile, "feffffea00000000000000000000000000000000000000000000000000000000000000", "feffffea034a044bca50044a044bca507047000001207047f89f550000200020a250b9")
                    HexPatchFile(outfile, outfile, "fff774fc", "00201860")
                    HexPatchFile(outfile, outfile, "16f0e4fe", "e2f79cf8")
                    HexPatchFile(outfile, outfile, "ff300028", "ff300020")
                    HexPatchFile(outfile, outfile, "01010cd0", "010100bf")
                    HexPatchFile(outfile, outfile, "7111f0bf", "00000080")
                End If
            End If
        End If

    End Sub

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
        If OTADowngrade = False Then
            PatchRestoredExternal(tempdir + "\ramdisk-patch\restored_external")
        End If
        PatchASR(tempdir + "\ramdisk-patch\asr")
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

    Public Shared Sub PatchRestoredExternal(Infile As String)
        If iOSAsInteger() = 6 Then
            If iOS_Version = "6.0" Then
                HexPatchFile(Infile, Infile, "06f01ef8b0b9", "0000000016e0")
                HexPatchFile(Infile, Infile, "4331614008430ad1", "4331614008430ae0")
                HexPatchFile(Infile, Infile, "0050281eecb95f69d7c2c1798c3615eca724be72", "331000cbaadd797fab68252335ccd9a1961e576e")
                HexPatchFile(Infile, Infile, "347a58b11cfacc421f3543f0c0bd33ecd658ef5c", "2adaed647eab94b15080f380c48354ae73108f70")
            ElseIf iOS_Version = "6.0.1" Then
                HexPatchFile(Infile, Infile, "06f01ef8b0b9", "0000000016e0")
                HexPatchFile(Infile, Infile, "4331614008430ad1", "4331614008430ae0")
                HexPatchFile(Infile, Infile, "9f61c2af4023bd861e42c1d7b6b03ed7de4cb7af", "d297afa70c7a35491ff5dc5f0f07624ae5ec08df")
                HexPatchFile(Infile, Infile, "6ee19aa5a4b6b4c69fcd6bed5f0a43e370c40205", "12f26d29e17be5518e044aa29fdcc385b5c8e0d0")
            ElseIf iOS_Version = "6.1" Or iOS_Version = "6.1.1" Or iOS_Version = "6.1.2" Or iOS_Version = "6.1.3" Or iOS_Version = "6.1.4" Then
                HexPatchFile(Infile, Infile, "06f030f8b0b9", "0000000016e0")
                HexPatchFile(Infile, Infile, "4331614008430ad1", "4331614008430ae0")
                HexPatchFile(Infile, Infile, "f834a0efb646af41470adbb9525f290c73e13784", "85621eb4315fc4e059544b51f557517d8e4c4f4d")
                HexPatchFile(Infile, Infile, "20ce8a478dd3d43b0b672f4be88d96393e4abbd5", "bfc15bc96937ad99d2b22769e2dadd0019635730")
            End If
        End If

        If iOSAsInteger() = 7 Then
            If iOS_Version = "7.0.2" Then
                If DeviceModel = "iPhone3,1" Then
                    HexPatchFile(Infile, Infile, "07f0d7fdb0b9", "0000000016e0")
                    HexPatchFile(Infile, Infile, "f0958028", "00000028")
                    HexPatchFile(Infile, Infile, "cccc0f2c1cda4c423933527696c706f34cc87871", "00000028d0f8ac6a9c1220186a223dbf301e4392ec2f005b")
                    HexPatchFile(Infile, Infile, "53c5706d829dc7be4f79133e20d0ffaae9ade874", "e78e17fb85d58917c49ac87383a8c1eff37ee017")
                End If
            ElseIf iOS_Version = "7.1.2" Then
                If DeviceModel = "iPhone3,1" Or DeviceModel = "iPhone4,1" Or DeviceModel = "iPad2,1" Or DeviceModel = "iPad3,1" Then
                    HexPatchFile(Infile, Infile, "07f031ffb0b9", "0000000016e0")
                    HexPatchFile(Infile, Infile, "f095802846", "0000002846")
                    HexPatchFile(Infile, Infile, "b11f7d2a191843cb95e16f3251940d4b949b6017", "219401670e60f2477b0370ba7286cd043bcd88b4")
                    HexPatchFile(Infile, Infile, "082d595262048760ab5cae1b2cd3b8c9530f6dd4", "9a1ffd1a73e6cadd7ecf6c4c0e4964dee4f72c05")
                End If
            End If
        End If
    End Sub

    Public Shared Sub PatchASR(Infile As String)
        If iOSAsInteger() = 4 Then
            'old man
            HexPatchFile(Infile, Infile, "dff8e000", "fdf7e000")
            HexPatchFile(Infile, Infile, "edb76caad3afa0b490086d635146170b8a408dc4", "6edb54d3db60a8fb744728eb0233eafa20b67eb5")
        ElseIf iOSAsInteger() = 5 Then
            HexPatchFile(Infile, Infile, "20460ff0c0eb4df2", "20460ff0c0ebf5e7")
            HexPatchFile(Infile, Infile, "fd4adfb2c6b19a721cbb80e0d97e8bc43261219a", "f693b6c74f33e1bae29dbc301b81ded20d651076")
        ElseIf iOSAsInteger() = 6 Then
            HexPatchFile(Infile, Infile, "4df66a30c0f20000", "f4e76a30c0f20000")
            HexPatchFile(Infile, Infile, "ffba472118b69b8b8610bd60035b153767bf0ca0", "870b9f3f8e9f8f8e98f7cbf7d6c74537cc3b16d8")
        ElseIf iOSAsInteger() = 7 Then
            'ios 7.0.2 (and 7.0 and 7.0.1)

            If iOS_Version = "7.0" Or iOS_Version = "7.0.1" Or iOS_Version = "7.0.2" Then
                If DeviceModel = "iPhone3,1" Then
                    HexPatchFile(Infile, Infile, "4df6e240", "3ae0e240")
                    HexPatchFile(Infile, Infile, "4c90b03e1e547ebfeae5cba04280ba858f6878e9", "67d37f9f4ce120a9b6be4eb48ff0938e22745481")
                End If
            End If


            If iOS_Version = "7.1.2" Then
                If DeviceModel = "iPhone3,1" Or DeviceModel = "iPhone4,1" Or DeviceModel = "iPad2,1" Or DeviceModel = "iPad3,1" Then
                    HexPatchFile(Infile, Infile, "9e4df6be", "9e3ae0be")
                    HexPatchFile(Infile, Infile, "e22e973d1c3a484e04220a4cc8aaa6fb9d05d198", "1c98f4f3987cd323ae3eb168606e34c8d995a727")
                ElseIf DeviceModel = "iPhone5,4" Then
                    HexPatchFile(Infile, Infile, "9e4df6e6", "9e34e0e6")
                    HexPatchFile(Infile, Infile, "794ff384ecb63d6a3c003185603cbb5b53dd1165", "ed28ba4e6274f3099ec785dbb1b6ac44d6f81730")
                End If
            End If


            ElseIf iOSAsInteger() = 8 Then
                'LOL, too even lazy to implement ios8 now
            End If
    End Sub

    Public Shared Sub PatchLockdownd(Infile)
        If iOS_Version = "6.1.3" Then
            HexPatchFile(Infile, Infile, "4210d141", "4213e041")
            HexPatchFile(Infile, Infile, "0cf03bfd", "01200120")
            HexPatchFile(Infile, Infile, "8e66ac9a17ff555100d599fd894fadca7457f597", "9aa58067f7619127625502645f8efd18b2d1355c")
        End If
    End Sub

    Public Shared Sub PatchOptionsPlist(Infile As String)
        If OTADowngrade = False Then
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
