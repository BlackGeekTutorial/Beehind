Imports Beehind.Common_Definitions
Imports Beehind.Common_Functions
Imports Beehind.Processes
Imports Beehind.keys
Imports System.IO
Imports System.Xml
Imports Beehind.XML
Imports Beehind.ECIDManagement
Imports System.Globalization
Imports Microsoft.VisualBasic

Public Class SignIMG3

    Public Shared BlobBackup As String = String.Empty

    Public Shared APTicket() As Byte
    Public Shared AppleLogo() As Byte
    Public Shared BatteryCharging0() As Byte
    Public Shared BatteryCharging1() As Byte
    Public Shared BatteryFull() As Byte
    Public Shared BatteryLow0() As Byte
    Public Shared BatteryLow1() As Byte
    Public Shared BatteryPlugin() As Byte
    Public Shared DeviceTree() As Byte
    Public Shared GlyphCharging() As Byte
    Public Shared GlyphPlugin() As Byte
    Public Shared KernelCache() As Byte
    Public Shared LLB() As Byte
    Public Shared RecoveryMode() As Byte
    Public Shared RestoreDeviceTree() As Byte
    Public Shared RestoreKernelCache() As Byte
    Public Shared RestoreLogo() As Byte
    Public Shared RestoreRamdisk() As Byte
    Public Shared iBEC() As Byte
    Public Shared iBSS() As Byte
    Public Shared iBoot() As Byte
    Public Shared NeedService() As Byte

    Public Shared Function RemoveHSHSTag(IMG3Path As String)
        Dim pattern As Integer() = New Integer() {&H48, &H53, &H48, &H53}
        Dim p As Integer = 0
        Using fs = New FileStream(IMG3Path, FileMode.Open, FileAccess.ReadWrite)
            For pos As Integer = 0 To fs.Length - 1
                Dim b As Integer = fs.ReadByte()
                If b = pattern(p) Then
                    p += 1
                    If p = pattern.Length Then
                        fs.SetLength(pos - pattern.Length + 1)
                        Return 1
                    End If
                Else
                    p = 0
                End If
            Next
        End Using
    End Function

    Public Shared Sub StitchBlobAndFixHeader(IMG3Path As String, SHSHBlob As Byte())
        RemoveHSHSTag(IMG3Path)
        Dim f As New FileStream(IMG3Path, FileMode.Append, FileAccess.Write)
        Dim writer1 As New BinaryWriter(f)
        writer1.Write(SHSHBlob)
        writer1.Close()
        Dim fi As New FileInfo(IMG3Path)
        Dim fullSize As Integer = CInt(fi.Length)
        Dim sizeNoPack As Integer = fullSize - 20
        Dim sigCheckArea As Integer = CInt(search(IMG3Path, "HSHS".ToCharArray(), 0) - search(IMG3Path, "ATAD".ToCharArray(), 0) + 32)
        f = New FileStream(IMG3Path, FileMode.Open, FileAccess.Write)
        writer1 = New BinaryWriter(f)
        writer1.Write("3gmI".ToCharArray())
        writer1.Write(BitConverter.GetBytes(CUInt(fullSize)))
        writer1.Write(BitConverter.GetBytes(CUInt(sizeNoPack)))
        writer1.Write(BitConverter.GetBytes(CUInt(sigCheckArea)))
        writer1.Close()
    End Sub

    Public Shared Sub FillBlockWithBlobs(Blobtype As String, xmlfile As String, MaxPick As Integer)
        Dim reader As XmlTextReader = New XmlTextReader(xmlfile)
        Dim interestingitem As Integer = 0
        Do While (reader.Read())
            Select Case reader.NodeType
                Case XmlNodeType.Text
                    Dim Blob As String
                    If reader.Value = Blobtype Then
                        interestingitem = interestingitem + 1
                    End If

                    If interestingitem > 0 And interestingitem <> MaxPick Then
                        Blob = Blob + reader.Value
                        interestingitem = interestingitem + 1
                    End If

                    If interestingitem = MaxPick Then
                        If Blobtype = "APTicket" Then
                            APTicket = System.Convert.FromBase64String(Blob.Replace(Blobtype, ""))
                        ElseIf Blobtype = "AppleLogo" Then
                            AppleLogo = System.Convert.FromBase64String(Blob.Replace(Blobtype + "Blob", ""))
                        ElseIf Blobtype = "BatteryCharging" Then
                            GlyphCharging = System.Convert.FromBase64String(Blob.Replace(Blobtype + "Blob", ""))
                        ElseIf Blobtype = "BatteryCharging0" Then
                            BatteryCharging0 = System.Convert.FromBase64String(Blob.Replace(Blobtype + "Blob", ""))
                        ElseIf Blobtype = "BatteryCharging1" Then
                            BatteryCharging1 = System.Convert.FromBase64String(Blob.Replace(Blobtype + "Blob", ""))
                        ElseIf Blobtype = "BatteryFull" Then
                            BatteryFull = System.Convert.FromBase64String(Blob.Replace(Blobtype + "Blob", ""))
                        ElseIf Blobtype = "BatteryLow0" Then
                            BatteryLow0 = System.Convert.FromBase64String(Blob.Replace(Blobtype + "Blob", ""))
                        ElseIf Blobtype = "BatteryLow1" Then
                            BatteryLow1 = System.Convert.FromBase64String(Blob.Replace(Blobtype + "Blob", ""))
                        ElseIf Blobtype = "BatteryPlugin" Then
                            BatteryPlugin = System.Convert.FromBase64String(Blob.Replace(Blobtype + "Blob", ""))
                        ElseIf Blobtype = "DeviceTree" Then
                            DeviceTree = System.Convert.FromBase64String(Blob.Replace(Blobtype + "Blob", ""))
                        ElseIf Blobtype = "KernelCache" Then
                            KernelCache = System.Convert.FromBase64String(Blob.Replace(Blobtype + "Blob", ""))
                        ElseIf Blobtype = "LLB" Then
                            LLB = System.Convert.FromBase64String(Blob.Replace(Blobtype + "Blob", ""))
                        ElseIf Blobtype = "RecoveryMode" Then
                            RecoveryMode = System.Convert.FromBase64String(Blob.Replace(Blobtype + "Blob", ""))
                        ElseIf Blobtype = "RestoreDeviceTree" Then
                            RestoreDeviceTree = System.Convert.FromBase64String(Blob.Replace(Blobtype + "Blob", ""))
                        ElseIf Blobtype = "RestoreKernelCache" Then
                            RestoreKernelCache = System.Convert.FromBase64String(Blob.Replace(Blobtype + "Blob", ""))
                        ElseIf Blobtype = "RestoreLogo" Then
                            RestoreLogo = System.Convert.FromBase64String(Blob.Replace(Blobtype + "Blob", ""))
                        ElseIf Blobtype = "RestoreRamDisk" Then
                            RestoreRamdisk = System.Convert.FromBase64String(Blob.Replace(Blobtype + "Blob", ""))
                        ElseIf Blobtype = "iBEC" Then
                            iBEC = System.Convert.FromBase64String(Blob.Replace(Blobtype + "Blob", ""))
                        ElseIf Blobtype = "iBSS" Then
                            iBSS = System.Convert.FromBase64String(Blob.Replace(Blobtype + "Blob", ""))
                            BlobBackup = Blob.Replace(Blobtype + "Blob", "")
                        ElseIf Blobtype = "iBoot" Then
                            iBoot = System.Convert.FromBase64String(Blob.Replace(Blobtype + "Blob", ""))
                        End If
                    End If
            End Select
        Loop
        reader.Close()
    End Sub

    Public Shared Sub FillBlobsSet(iOSVersion As Integer)

        'apticket part
        If iOSVersion > 4 Then
            FillBlockWithBlobs("APTicket", XMLPath, 3)
        End If

        'ios 8
        FillBlockWithBlobs("LLB", XMLPath, 4)
        FillBlockWithBlobs("iBSS", XMLPath, 4)

        If iOSVersion < 8 Then
            'ios 7
            FillBlockWithBlobs("iBEC", XMLPath, 4)
        End If

        If iOSVersion < 7 Then
            'ios 6 or 5
            FillBlockWithBlobs("KernelCache", XMLPath, 4)
            FillBlockWithBlobs("RestoreKernelCache", XMLPath, 4)
            FillBlockWithBlobs("RestoreRamDisk", XMLPath, 4)
        End If

        If iOSVersion < 5 Then
            'ios 4
            FillBlockWithBlobs("AppleLogo", XMLPath, 4)
            FillBlockWithBlobs("BatteryCharging", XMLPath, 4)
            FillBlockWithBlobs("BatteryCharging0", XMLPath, 4)
            FillBlockWithBlobs("BatteryCharging1", XMLPath, 4)
            FillBlockWithBlobs("BatteryFull", XMLPath, 4)
            FillBlockWithBlobs("BatteryLow0", XMLPath, 4)
            FillBlockWithBlobs("BatteryLow1", XMLPath, 4)
            FillBlockWithBlobs("BatteryPlugin", XMLPath, 4)
            FillBlockWithBlobs("DeviceTree", XMLPath, 4)
            FillBlockWithBlobs("RecoveryMode", XMLPath, 4)
            FillBlockWithBlobs("RestoreDeviceTree", XMLPath, 4)
            FillBlockWithBlobs("RestoreLogo", XMLPath, 4)
            FillBlockWithBlobs("iBoot", XMLPath, 4)
        End If
    End Sub

    Public Shared Sub SignIMG3Set(iOSVersion As Integer, SignPWN As Boolean)

        'ios 8
        StitchBlobAndFixHeader(tempdir + "\IPSW\Firmware\all_flash" + all_flashFolder + LLBName, LLB)
        If SignPWN = True Then
            StitchBlobAndFixHeader(tempdir + "\IPSW\Firmware\dfu" + iBSSName, iBSS)
        End If

        If iOSAsInteger() < 8 Then
            'ios 7
            If SignPWN = True Then
                StitchBlobAndFixHeader(tempdir + "\IPSW\Firmware\dfu" + iBECName, iBEC)
            End If
        End If

        If iOSAsInteger() < 7 Then
            'ios 6 or 5
            StitchBlobAndFixHeader(tempdir + "\IPSW" + KernelCacheName, KernelCache)

            If SignPWN = True Then
                StitchBlobAndFixHeader(tempdir + "\IPSW" + RestoreRamdiskName, RestoreRamdisk)
            End If
        End If

        If iOSAsInteger() < 5 Then
            'ios 4 
            StitchBlobAndFixHeader(tempdir + "\IPSW\Firmware\all_flash" + all_flashFolder + AppleLogoName, AppleLogo)
            StitchBlobAndFixHeader(tempdir + "\IPSW\Firmware\all_flash" + all_flashFolder + BatteryCharging0Name, BatteryCharging0)
            StitchBlobAndFixHeader(tempdir + "\IPSW\Firmware\all_flash" + all_flashFolder + BatteryCharging1Name, BatteryCharging1)
            StitchBlobAndFixHeader(tempdir + "\IPSW\Firmware\all_flash" + all_flashFolder + BatteryFullName, BatteryFull)
            StitchBlobAndFixHeader(tempdir + "\IPSW\Firmware\all_flash" + all_flashFolder + BatteryLow0Name, BatteryLow0)
            StitchBlobAndFixHeader(tempdir + "\IPSW\Firmware\all_flash" + all_flashFolder + BatteryLow1Name, BatteryLow1)
            StitchBlobAndFixHeader(tempdir + "\IPSW\Firmware\all_flash" + all_flashFolder + DeviceTreeName, DeviceTree)
            StitchBlobAndFixHeader(tempdir + "\IPSW\Firmware\all_flash" + all_flashFolder + RecoveryModeName, RecoveryMode)
            StitchBlobAndFixHeader(tempdir + "\IPSW\Firmware\all_flash" + all_flashFolder + iBootName, iBoot)
        End If
    End Sub

    Public Shared Function ObtainRestoreLogoDigest(InfileXML As String)
        Dim XMLReader As XmlTextReader = New XmlTextReader(InfileXML)
        Dim Item As Integer = 0
        Dim MaxPick As Integer = 3
        Dim RawDigest As String = String.Empty
        Do While (XMLReader.Read())
            Select Case XMLReader.NodeType
                Case XmlNodeType.Text
                    If XMLReader.Value = "RestoreLogo" Then
                        Item = Item + 1
                    End If
                    If Item > 0 And Item <= MaxPick Then
                        RawDigest = XMLReader.Value
                        Item = Item + 1
                    End If
            End Select
        Loop
        XMLReader.Close()
        Return RawDigest.Trim()
    End Function

    Public Shared Function ObtainRestoreDeviceTreeDigest(InfileXML As String)
        Dim XMLReader As XmlTextReader = New XmlTextReader(InfileXML)
        Dim Item As Integer = 0
        Dim MaxPick As Integer = 3
        Dim RawDigest As String = String.Empty
        Do While (XMLReader.Read())
            Select Case XMLReader.NodeType
                Case XmlNodeType.Text
                    If XMLReader.Value = "RestoreDeviceTree" Then
                        Item = Item + 1
                    End If
                    If Item > 0 And Item <= MaxPick Then
                        RawDigest = XMLReader.Value
                        Item = Item + 1
                    End If
            End Select
        Loop
        XMLReader.Close()
        Return RawDigest.Trim()
    End Function

    Public Shared Function ObtainUniqueBuildID(InfileXML As String)
        Dim XMLReader As XmlTextReader = New XmlTextReader(InfileXML)
        Dim Item As Integer = 0
        Dim MaxPick As Integer = 3
        Dim RawDigest As String = String.Empty
        Do While (XMLReader.Read())
            Select Case XMLReader.NodeType
                Case XmlNodeType.Text
                    If XMLReader.Value = "UniqueBuildID" Then
                        Item = Item + 1
                    End If
                    If Item > 0 And Item <= MaxPick Then
                        RawDigest = XMLReader.Value
                        Item = Item + 1
                    End If
            End Select
        Loop
        XMLReader.Close()
        Return RawDigest.Trim()
    End Function

    Public Shared Function ObtainRestoreKernelCacheDigest(InfileXML As String)
        Dim XMLReader As XmlTextReader = New XmlTextReader(InfileXML)
        Dim Item As Integer = 0
        Dim MaxPick As Integer = 3
        Dim RawDigest As String = String.Empty
        Do While (XMLReader.Read())
            Select Case XMLReader.NodeType
                Case XmlNodeType.Text
                    If XMLReader.Value = "RestoreKernelCache" Then
                        Item = Item + 1
                    End If
                    If Item > 0 And Item <= MaxPick Then
                        RawDigest = XMLReader.Value
                        Item = Item + 1
                        If RawDigest = "RestoreRamDisk" Then
                            RawDigest = String.Empty
                            Item = 0
                        End If
                    End If
            End Select
        Loop
        XMLReader.Close()
        Return RawDigest.Trim()
    End Function

    Public Shared Function GetOriginalRootfsSize(InfileXML As String)
        Dim XMLReader As XmlTextReader = New XmlTextReader(InfileXML)
        Dim Item As Integer = 0
        Dim MaxPick As Integer = 2
        Dim Size As String = String.Empty
        Do While (XMLReader.Read())
            Select Case XMLReader.NodeType
                Case XmlNodeType.Text
                    If XMLReader.Value = "SystemPartitionSize" Then
                        Item = Item + 1
                    End If
                    If Item > 0 And Item <= MaxPick Then
                        Size = XMLReader.Value
                        Item = Item + 1
                    End If
            End Select
        Loop
        XMLReader.Close()
        Return Size.Trim()
    End Function

    Public Shared Function ByteFlipper(Bytes As String) As Object
        Dim length As Integer = Bytes.Length
        Dim str As String = String.Empty
        While length <> 0
            str = str & Bytes.Substring(length - 2, 2)
            length -= 2
        End While
        Return str
    End Function

    Public Shared Function AddUpHex(Address As String, Value As String) As Object
        Dim s As String = Value.Replace("0x", "")
        Dim str2 As String = Address.Replace("0x", "")
        Dim num As Integer = Integer.Parse(s, NumberStyles.HexNumber)
        Dim num2 As Integer = Integer.Parse(str2, NumberStyles.HexNumber)
        Dim num3 As Integer = num + num2
        Return ("0x" + num3.ToString("X"))
    End Function

    Public Shared Sub RepairApTicketIMG3Header(IMG3 As String)
        Dim reader As New BinaryReader(System.IO.File.Open(IMG3, FileMode.Open, FileAccess.ReadWrite))
        Dim str As String = ByteArrayToString(reader.ReadBytes(&H10)).ToUpper()
        reader.Close()
        Dim str2 As String = Microsoft.VisualBasic.CompilerServices.Conversions.ToString(ByteFlipper(str.Substring(8, 8)))
        Dim address As String = Microsoft.VisualBasic.CompilerServices.Conversions.ToString(ByteFlipper(str.Substring(&H10, 8)))
        Dim str4 As String = Microsoft.VisualBasic.CompilerServices.Conversions.ToString(ByteFlipper(str.Substring(&H18, 8)))
        Dim writer As New BinaryWriter(System.IO.File.Open(IMG3, FileMode.Open, FileAccess.ReadWrite))
        writer.Seek(4, SeekOrigin.Begin)
        Dim bytes As String = Conversion.Hex(writer.BaseStream.Length)
        While bytes.Length <> 8
            bytes = Convert.ToString("0") & bytes
        End While
        writer.Write(ConvertHexStringToByteArray(Microsoft.VisualBasic.CompilerServices.Conversions.ToString(ByteFlipper(bytes))))
        Dim str6 As String = SubUpHex(Conversion.Hex(writer.BaseStream.Length), "14").ToString().Replace("0x", "")
        While str6.Length <> 8
            str6 = Convert.ToString("0") & str6
        End While
        writer.Seek(8, SeekOrigin.Begin)
        writer.Write(ConvertHexStringToByteArray(Microsoft.VisualBasic.CompilerServices.Conversions.ToString(ByteFlipper(str6))))
        writer.Close()
    End Sub

    Public Shared Sub RepairApTicketDATAHeader(IMG3File As String, hexapticket As String)
        Dim reader As New BinaryReader(System.IO.File.Open(IMG3File, FileMode.Open, FileAccess.ReadWrite))
        reader.BaseStream.Seek(CLng(Integer.Parse("38", NumberStyles.HexNumber)), SeekOrigin.Begin)
        Dim address As String = Microsoft.VisualBasic.Conversion.Hex(CDbl(hexapticket.Length) / 2.0)
        While address.Length <> 8
            address = Convert.ToString("0") & address
        End While
        Dim bytes As String = AddUpHex(address, "0xC").ToString().Replace("0x", "")
        Dim str3 As String = Microsoft.VisualBasic.CompilerServices.Conversions.ToString(ByteFlipper(address))
        While str3.Length <> 8
            str3 = Convert.ToString("0") & str3
        End While
        While bytes.Length <> 8
            bytes = Convert.ToString("0") & bytes
        End While
        bytes = Microsoft.VisualBasic.CompilerServices.Conversions.ToString(ByteFlipper(bytes))
        reader.Close()
        RawPatch(IMG3File, "0x38", bytes & str3)
    End Sub

    Public Shared Sub IMG3ApTicket(ticket As Byte(), outputIMG3Path As String)
        'image3maker("-f " + """" + ApTicketDerPath + """" + " -t SCAB -o " + """" + outputIMG3Path + """")
        Dim HexApTicket As String = ByteArrayToHexString(ticket)

        Dim writer As New BinaryWriter(File.Open(outputIMG3Path, FileMode.OpenOrCreate, FileAccess.ReadWrite))
        writer.Write(ConvertHexStringToByteArray("33676D49AAAAAAAABBBBBBBB0000000042414353455059542000000004000000424143530000000000000000000000000000000041544144CCCCCCCCDDDDDDDD" + HexApTicket))
        writer.Close()
        RepairApTicketDATAHeader(outputIMG3Path, HexApTicket)
        RepairApTicketIMG3Header(outputIMG3Path)
    End Sub

    Public Shared Sub BPlistToXml(InfilePlist As String, OutfileXml As String)
        bplist2xml("""" + InfilePlist + """" + " " + """" + OutfileXml + """")
    End Sub


    Public Shared Sub WriteBeehindXML(Infile As String)
        File.Create(Infile).Dispose()
        Using XMLWriter As StreamWriter = New StreamWriter(Infile, True)
            'System.Text.Encoding.UTF8
            XMLWriter.WriteLine("<?xml version=" + """" + "1.0" + """" + " encoding=" + """" + "UTF-8" + """" + "?>")
            XMLWriter.WriteLine("<!DOCTYPE plist PUBLIC " + """" + "-//Apple//DTD PLIST 1.0//EN" + """" + " " + """" + "http://www.apple.com/DTDs/PropertyList-1.0.dtd" + """" + ">")
            XMLWriter.WriteLine("<plist version=" + """" + "1.0" + """" + ">")
            XMLWriter.WriteLine("<dict>")
            XMLWriter.WriteLine("	<key>BeehindVersion</key>")
            XMLWriter.WriteLine("	<real>" + currentversion.ToString.Replace(",", ".") + "</real>")
            XMLWriter.WriteLine("	<key>RestoreManifest</key>")
            XMLWriter.WriteLine("	<dict>")
            If AppleLogoName <> "" Then
                XMLWriter.WriteLine("		<key>AppleLogo</key>")
                XMLWriter.WriteLine("		<string>Firmware\all_flash" + all_flashFolder + AppleLogoName + "</string>")
            End If
            If BatteryChargingName <> "" Then
                XMLWriter.WriteLine("		<key>BatteryCharging</key>")
                XMLWriter.WriteLine("		<string>Firmware\all_flash" + all_flashFolder + BatteryChargingName + "</string>")
            End If
            If BatteryCharging0Name <> "" Then
                XMLWriter.WriteLine("		<key>BatteryCharging0</key>")
                XMLWriter.WriteLine("		<string>Firmware\all_flash" + all_flashFolder + BatteryCharging0Name + "</string>")
            End If
            If BatteryCharging1Name <> "" Then
                XMLWriter.WriteLine("		<key>BatteryCharging1</key>")
                XMLWriter.WriteLine("		<string>Firmware\all_flash" + all_flashFolder + BatteryCharging1Name + "</string>")
            End If
            If BatteryFullName <> "" Then
                XMLWriter.WriteLine("		<key>BatteryFull</key>")
                XMLWriter.WriteLine("		<string>Firmware\all_flash" + all_flashFolder + BatteryFullName + "</string>")
            End If
            If BatteryLow0Name <> "" Then
                XMLWriter.WriteLine("		<key>BatteryLow0</key>")
                XMLWriter.WriteLine("		<string>Firmware\all_flash" + all_flashFolder + BatteryLow0Name + "</string>")
            End If
            If BatteryLow1Name <> "" Then
                XMLWriter.WriteLine("		<key>BatteryLow1</key>")
                XMLWriter.WriteLine("		<string>Firmware\all_flash" + all_flashFolder + BatteryLow1Name + "</string>")
            End If
            If BatteryPluginName <> "" Then
                XMLWriter.WriteLine("		<key>BatteryPlugin</key>")
                XMLWriter.WriteLine("		<string>Firmware\all_flash" + all_flashFolder + BatteryPluginName + "</string>")
            End If
            If DeviceTreeName <> "" Then
                XMLWriter.WriteLine("		<key>DeviceTree</key>")
                XMLWriter.WriteLine("		<string>Firmware\all_flash" + all_flashFolder + DeviceTreeName + "</string>")
            End If
            If KernelCacheName <> "" Then
                XMLWriter.WriteLine("		<key>KernelCache</key>")
                XMLWriter.WriteLine("		<string>" + KernelCacheName.Replace("\", "") + "</string>")
            End If
            If LLBName <> "" Then
                XMLWriter.WriteLine("		<key>LLB</key>")
                XMLWriter.WriteLine("		<string>Firmware\all_flash" + all_flashFolder + LLBName + "</string>")
            End If
            If RecoveryModeName <> "" Then
                XMLWriter.WriteLine("		<key>RecoveryMode</key>")
                XMLWriter.WriteLine("		<string>Firmware\all_flash" + all_flashFolder + RecoveryModeName + "</string>")
            End If
            If DeviceTreeName <> "" Then
                XMLWriter.WriteLine("		<key>RestoreDeviceTree</key>")
                XMLWriter.WriteLine("		<string>Firmware\all_flash" + all_flashFolder + DeviceTreeName.Replace("DeviceTree", "Restor    eDeviceTree_DeviceTree") + "</string>")
            End If
            If KernelCacheName <> "" Then
                XMLWriter.WriteLine("		<key>RestoreKernelCache</key>")
                XMLWriter.WriteLine("		<string>" + KernelCacheName.Replace("\kernelcache", "RestoreKernelCache_kernelcache") + "</string>")
            End If
            If AppleLogoName <> "" Then
                XMLWriter.WriteLine("		<key>RestoreLogo</key>")
                XMLWriter.WriteLine("		<string>Firmware\all_flash" + all_flashFolder + AppleLogoName.Replace("applelogo", "RestoreLogo_applelogo") + "</string>")
            End If
            If RestoreRamdiskName <> "" Then
                XMLWriter.WriteLine("		<key>RestoreRamDisk</key>")
                XMLWriter.WriteLine("		<string>" + RestoreRamdiskName.Replace("\", "") + "</string>")
            End If
            If rootfsName <> "" Then
                XMLWriter.WriteLine("		<key>RootFS</key>")
                XMLWriter.WriteLine("		<string>" + rootfsName.Replace("\", "") + "</string>")
            End If
            If iBECName <> "" Then
                XMLWriter.WriteLine("		<key>iBEC</key>")
                XMLWriter.WriteLine("		<string>Firmware\dfu" + iBECName + "</string>")
            End If
            If iBSSName <> "" Then
                XMLWriter.WriteLine("		<key>iBSS</key>")
                XMLWriter.WriteLine("		<string>Firmware\dfu" + iBSSName + "</string>")
            End If
            If iBootName <> "" Then
                XMLWriter.WriteLine("		<key>iBoot</key>")
                XMLWriter.WriteLine("		<string>Firmware\all_flash" + all_flashFolder + iBootName + "</string>")
            End If
            XMLWriter.WriteLine("	</dict>")
            XMLWriter.WriteLine("	<key>iOSBuild</key>")
            XMLWriter.WriteLine("	<string>" + iOS_Build + "</string>")
            XMLWriter.WriteLine("	<key>iOSVersion</key>")
            XMLWriter.WriteLine("	<string>" + iOS_Version + "</string>")
            XMLWriter.WriteLine("	<key>Pre-Signed</key>")
            If OTADowngrade = True Then
                XMLWriter.WriteLine("	<string>false</string>")
            Else
                XMLWriter.WriteLine("	<string>true</string>")
            End If
            XMLWriter.WriteLine("		<key>DecimalECID</key>")
            XMLWriter.WriteLine("		<string>" + CurrentDecimalECID + "</string>")
            XMLWriter.WriteLine("</dict>")
            XMLWriter.Write("</plist>")
            XMLWriter.Close()
        End Using
    End Sub
End Class
