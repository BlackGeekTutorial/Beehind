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
Imports System.Threading

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

        If iOSAsInteger(iOS_Version) < 8 Then
            'ios 7
            If SignPWN = True Then
                StitchBlobAndFixHeader(tempdir + "\IPSW\Firmware\dfu" + iBECName, iBEC)
            End If
        End If

        If iOSAsInteger(iOS_Version) < 7 Then
            'ios 6 or 5
            StitchBlobAndFixHeader(tempdir + "\IPSW" + KernelCacheName, KernelCache)

            If SignPWN = True Then
                StitchBlobAndFixHeader(tempdir + "\IPSW" + RestoreRamdiskName, RestoreRamdisk)
            End If
        End If

        If iOSAsInteger(iOS_Version) < 5 Then
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

    Public Shared Function ExistsInBuildManifest(Infile As String, value As String, valuetype As String, Optional ByVal subvalue As String = "", Optional ByVal subvaluetype As String = "")
        If subvalue = "" Then
            If File.ReadAllText(Infile).Contains("<" + valuetype + ">" + value + "</" + valuetype + ">") Then
                Return True
            Else
                Return False
            End If
        Else
            Dim BuildManifest() As String = IO.File.ReadAllLines(Infile)

            Dim BuildManifestLines As Integer = BuildManifest.Length
            Dim position As Integer = 0
            Dim rightblob As Boolean = False
            Dim data As String = String.Empty

            Dim open = 0
            Dim closed = 0

            Dim typeopen = 0
            Dim typeclosed = 0

            Do While position < BuildManifestLines

                If BuildManifest(position).Contains("<key>" + value + "</key>") Then
                    If BuildManifest(position + 1).Contains("<" + valuetype + ">") Then
                        rightblob = True
                    End If
                End If

                If BuildManifest(position).Contains("<dict>") And rightblob = True Then
                    open = open + 1
                End If

                If BuildManifest(position).Contains("</dict>") And rightblob = True Then
                    closed = closed + 1
                End If

                If open = closed And open <> 0 Then
                    rightblob = False
                    Exit Do
                    Return False
                End If

                If BuildManifest(position).Contains(subvalue) And rightblob = True Then
                    Return True
                    Exit Do
                End If

                position = position + 1
            Loop
        End If
    End Function

    Public Shared Function GetFromBuildManifest(Infile As String, value As String, valuetype As String, subvalue As String, subvaluetype As String, multiline As Boolean, Optional ByVal subvaluekey As String = "key")
        Dim BuildManifest() As String = IO.File.ReadAllLines(Infile)

        Dim BuildManifestLines As Integer = BuildManifest.Length
        Dim position As Integer = 0
        Dim rightblob As Boolean = False
        Dim data As String = String.Empty

        Dim open = 0
        Dim closed = 0

        Dim typeopen = 0
        Dim typeclosed = 0

        Do While position <> BuildManifestLines
            If BuildManifest(position).Contains("</plist") Then
                Exit Do
                Exit Function
            End If

            If BuildManifest(position).Contains(value) And rightblob = False Then
                If BuildManifest(position + 1).Contains(valuetype) Then
                    rightblob = True
                End If
            End If

            If BuildManifest(position).Contains("<dict>") And rightblob = True Then
                open = open + 1
            End If

            If BuildManifest(position).Contains("</dict>") And rightblob = True Then
                closed = closed + 1
            End If

            If open = closed And open <> 0 Then
                rightblob = False
            End If

            If BuildManifest(position).Contains("<" + subvaluekey + ">" + subvalue + "</" + subvaluekey + ">") And rightblob = True Then
                Do While True

                    If BuildManifest(position).Contains("<" + subvaluetype + ">") Then
                        typeopen = typeopen + 1
                    End If

                    If typeopen <> typeclosed And typeopen <> 0 Then
                        If multiline = False Then
                            data = data + BuildManifest(position)
                        Else
                            data = data + BuildManifest(position) + Environment.NewLine
                        End If
                    End If

                    If BuildManifest(position).Contains("</" + subvaluetype + ">") Then
                        typeclosed = typeclosed + 1
                    End If

                    If typeopen = typeclosed And typeopen <> 0 Then
                        Exit Do
                    End If

                    position = position + 1
                Loop
            End If

            position = position + 1
        Loop

        If multiline = False Then
            Return ((data.Replace("<" + subvaluetype + ">", "").Replace("</" + subvaluetype + ">", "")).Replace(vbTab, "")).Trim()
        Else
            Return data
        End If
    End Function

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

    Public Shared Sub XmlToBplist(InfileXml As String, OutfileBplist As String)
        xml2bplist("""" + InfileXml + """" + " " + """" + OutfileBplist + """")
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
                If DowngradeType = "OTA" Then
                    XMLWriter.WriteLine("		<key>AppleLogo</key>")
                    XMLWriter.WriteLine("		<string>Firmware\all_flash" + all_flashFolder + AppleLogoName + "</string>")
                Else
                    XMLWriter.WriteLine("		<key>AppleLogo</key>")
                    XMLWriter.WriteLine("		<string>Firmware\all_flash" + all_flashFolder + AppleLogoName + ".toflash" + "</string>")
                End If
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
                If DowngradeType = "OTA" Then
                    XMLWriter.WriteLine("		<key>DeviceTree</key>")
                    XMLWriter.WriteLine("		<string>Firmware\all_flash" + all_flashFolder + DeviceTreeName + "</string>")
                Else
                    XMLWriter.WriteLine("		<key>DeviceTree</key>")
                    XMLWriter.WriteLine("		<string>Firmware\all_flash" + all_flashFolder + DeviceTreeName + ".toflash" + "</string>")
                End If
            End If
            If KernelCacheName <> "" Then
                If DowngradeType = "OTA" Then
                    XMLWriter.WriteLine("		<key>KernelCache</key>")
                    XMLWriter.WriteLine("		<string>Firmware\all_flash" + all_flashFolder + KernelCacheName + "</string>")
                Else
                    XMLWriter.WriteLine("		<key>KernelCache</key>")
                    XMLWriter.WriteLine("		<string>Firmware\all_flash" + all_flashFolder + KernelCacheName + ".toflash" + "</string>")
                End If
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
                If DowngradeType = "OTA" Then
                    XMLWriter.WriteLine("		<key>RestoreDeviceTree</key>")
                    XMLWriter.WriteLine("		<string>Firmware\all_flash" + all_flashFolder + DeviceTreeName.Replace("DeviceTree", "RestoreDeviceTree_DeviceTree") + "</string>")
                Else
                    XMLWriter.WriteLine("		<key>RestoreDeviceTree</key>")
                    XMLWriter.WriteLine("		<string>Firmware\all_flash" + all_flashFolder + DeviceTreeName + "</string>")
                End If
            End If
            If KernelCacheName <> "" Then
                If DowngradeType = "OTA" Then
                    XMLWriter.WriteLine("		<key>RestoreKernelCache</key>")
                    XMLWriter.WriteLine("		<string>" + KernelCacheName.Replace("\kernelcache", "RestoreKernelCache_kernelcache") + "</string>")
                Else
                    XMLWriter.WriteLine("		<key>RestoreKernelCache</key>")
                    XMLWriter.WriteLine("		<string>" + KernelCacheName + "</string>")
                End If
            End If
            If AppleLogoName <> "" Then
                If DowngradeType = "OTA" Then
                    XMLWriter.WriteLine("		<key>RestoreLogo</key>")
                    XMLWriter.WriteLine("		<string>Firmware\all_flash" + all_flashFolder + AppleLogoName.Replace("applelogo", "RestoreLogo_applelogo") + "</string>")
                Else
                    XMLWriter.WriteLine("		<key>RestoreLogo</key>")
                    XMLWriter.WriteLine("		<string>Firmware\all_flash" + all_flashFolder + AppleLogoName + "</string>")
                End If
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
            XMLWriter.WriteLine("	<key>IPSW Type</key>")
            XMLWriter.WriteLine("	<string>" + DowngradeType + "</string>")
            XMLWriter.WriteLine("	<key>restored_external patch</key>")
            If RestoredExternalPatch = True Then
                XMLWriter.WriteLine("	<string>true</string>")
            Else
                XMLWriter.WriteLine("	<string>false</string>")
            End If
            XMLWriter.WriteLine("	<key>OTA Downgrade</key>")
            If DowngradeType = "OTA" Then
                XMLWriter.WriteLine("	<string>true</string>")
            Else
                XMLWriter.WriteLine("	<string>false</string>")
            End If
            XMLWriter.WriteLine("		<key>DecimalECID</key>")
            XMLWriter.WriteLine("		<string>" + CurrentDecimalECID + "</string>")
            XMLWriter.WriteLine("</dict>")
            XMLWriter.Write("</plist>")
            XMLWriter.Close()
        End Using
    End Sub

    Public Shared Sub WriteTSSRequest(BuildManifest As String, Outfile As String, ecid As String, apticket As Boolean, bbticket As Boolean, img4 As Boolean, Optional ByVal apnonce As String = "", Optional ByVal bbnonce As String = "", Optional ByVal bbsnum As String = "", Optional ByVal bbgoldcertid As String = "", Optional ByVal sepnonce As String = "")
        Dim Cool As String() = {"AppleLogo", "BatteryCharging", "BatteryCharging0", "BatteryCharging1", "BatteryFull", "BatteryLow0", "BatteryLow1", "BatteryPlugin", "DeviceTree", "KernelCache", "LLB", "RecoveryMode", "RestoreDeviceTree", "RestoreKernelCache", "RestoreLogo", "RestoreRamDisk", "iBEC", "iBSS", "iBoot", "RestoreSEP", "SEP", "ftap", "ftsp", "rfta", "rfts"}

        File.Create(Outfile).Dispose()
        Using XMLWriter As StreamWriter = New StreamWriter(Outfile, True)
            'System.Text.Encoding.UTF8
            XMLWriter.Write(shshHeader)
            XMLWriter.WriteLine("<dict>")
            If apticket = True Then
                If Not img4 Then
                    XMLWriter.WriteLine("	<key>@APTicket</key>")
                    XMLWriter.WriteLine("	<true/>")
                Else
                    XMLWriter.WriteLine("	<key>@ApImg4Ticket</key>")
                    XMLWriter.WriteLine("	<true/>")
                End If
            End If
            If bbticket = True Then
                XMLWriter.WriteLine("	<key>@BBTicket</key>")
                XMLWriter.WriteLine("	<true/>")
            End If
            XMLWriter.WriteLine("	<key>@HostPlatformInfo</key>")
            XMLWriter.WriteLine("	<string>windows</string>")
            XMLWriter.WriteLine("	<key>@VersionInfo</key>")
            XMLWriter.WriteLine("	<string>libauthinstall-391.0.0.1.3</string>")
            XMLWriter.WriteLine("	<key>@Locality</key>")
            XMLWriter.WriteLine("	<string>" + Thread.CurrentThread.CurrentCulture.Name + "</string>")
            XMLWriter.WriteLine("	<key>ApBoardID</key>")
            XMLWriter.WriteLine("	<integer>" + (HexToDec(GetFromBuildManifest(BuildManifest, "array", "dict", "ApBoardID", "string", False))).ToString + "</integer>")
            XMLWriter.WriteLine("	<key>ApChipID</key>")
            XMLWriter.WriteLine("	<integer>" + (HexToDec(GetFromBuildManifest(BuildManifest, "array", "dict", "ApChipID", "string", False))).ToString + "</integer>")
            If ecid <> String.Empty Then
                XMLWriter.WriteLine("	<key>ApECID</key>")
                XMLWriter.WriteLine("	<integer>" + ecid + "</integer>")
            End If
            If apticket = True Then
                If apnonce.Length = 28 Then
                    XMLWriter.WriteLine("	<key>ApNonce</key>")
                    XMLWriter.WriteLine("	<data>" + apnonce + "</data>")
                Else
                    XMLWriter.WriteLine("	<key>ApNonce</key>")
                    XMLWriter.WriteLine("	<data>FFrp/uZvF8gUV8Xj9RaXRyOZiO0=</data>")
                End If
            End If

            If img4 = True Then
                If sepnonce.Length = 28 Then
                    XMLWriter.WriteLine("	<key>SepNonce</key>")
                    XMLWriter.WriteLine("	<data>" + sepnonce + "</data>")
                    ' trovato nel BM.plist di iPhone 6 iOS 9.2.1
                    XMLWriter.WriteLine("	<key>ApSecurityMode</key>")
                    XMLWriter.WriteLine("	<true/>")
                Else
                    XMLWriter.WriteLine("	<key>SepNonce</key>")
                    XMLWriter.WriteLine("	<data>nE+WLdr06Ey/9TZu93+BedtRcmQ=</data>")
                End If
            End If
            XMLWriter.WriteLine("	<key>ApProductionMode</key>")
            XMLWriter.WriteLine("	<true/>")
            XMLWriter.WriteLine("	<key>ApSecurityDomain</key>")
            XMLWriter.WriteLine("	<integer>" + (HexToDec(GetFromBuildManifest(BuildManifest, "array", "dict", "ApSecurityDomain", "string", False))).ToString + "</integer>")




            For Each element In Cool
                If ExistsInBuildManifest(BuildManifest, element, "key") Then
                    XMLWriter.WriteLine("	<key>" + element + "</key>")
                    XMLWriter.WriteLine("	<dict>")
                    If element = "LLB" Or element = "iBSS" Or element = "iBEC" Then
                        XMLWriter.WriteLine("			<key>BuildString</key>")
                        XMLWriter.WriteLine("			<string>" + GetFromBuildManifest(BuildManifest, "<key>" + element + "</key>", "dict", "BuildString", "string", False) + "</string>")
                    End If
                    If element <> "ftap" And element <> "ftsp" And element <> "rfta" And element <> "rfts" Then
                        If GetFromBuildManifest(BuildManifest, "<key>" + element + "</key>", "dict", "Digest", "data", False) <> String.Empty Then
                            XMLWriter.WriteLine("		<key>Digest</key>")
                            XMLWriter.WriteLine("		<data>" + GetFromBuildManifest(BuildManifest, "<key>" + element + "</key>", "dict", "Digest", "data", False) + "</data>")
                        End If
                    Else
                        ' quei 4 stronzi vogliono il Digest anche se è vuoto :/
                        XMLWriter.WriteLine("		<key>Digest</key>")
                        XMLWriter.WriteLine("		<data>" + GetFromBuildManifest(BuildManifest, "<key>" + element + "</key>", "dict", "Digest", "data", False) + "</data>")
                    End If
                    If img4 = True Then
                        XMLWriter.WriteLine("		<key>EPRO</key>")
                        XMLWriter.WriteLine("		<true/>")
                        XMLWriter.WriteLine("		<key>ESEC</key>")
                        XMLWriter.WriteLine("		<true/>")
                    End If
                    If GetFromBuildManifest(BuildManifest, "<key>" + element + "</key>", "dict", "PartialDigest", "data", False) <> String.Empty Then
                        XMLWriter.WriteLine("		<key>PartialDigest</key>")
                        XMLWriter.WriteLine("		<data>" + GetFromBuildManifest(BuildManifest, "<key>" + element + "</key>", "dict", "PartialDigest", "data", False) + "</data>")
                    End If
                    If ExistsInBuildManifest(BuildManifest, element, "dict", "Trusted", "") = True Then
                        XMLWriter.WriteLine("		<key>Trusted</key>")
                        XMLWriter.WriteLine("		<true/>")
                    End If
                    XMLWriter.WriteLine("	</dict>")
                End If
            Next

            If bbticket = True Then
                XMLWriter.WriteLine("	<key>BasebandFirmware</key>")
                XMLWriter.Write(GetFromBuildManifest(BuildManifest, "Manifest", "dict", "BasebandFirmware", "dict", True))

                XMLWriter.WriteLine("	<key>BbChipID</key>")
                XMLWriter.WriteLine("	<integer>" + (HexToDec(GetFromBuildManifest(BuildManifest, "array", "dict", "BbChipID", "string", False))).ToString + "</integer>")
                XMLWriter.WriteLine("	<key>BbGoldCertId</key>")
                XMLWriter.WriteLine("	<integer>" + bbgoldcertid + "</integer>")
                If bbnonce.Length = 28 Then
                    XMLWriter.WriteLine("	<key>BbNonce</key>")
                    XMLWriter.WriteLine("	<data>" + bbnonce + "</data>")
                Else
                    XMLWriter.WriteLine("	<key>BbNonce</key>")
                    XMLWriter.WriteLine("	<data>FFrp/uZvF8gUV8Xj9RaXRyOZiO0=</data>")
                End If
                XMLWriter.WriteLine("	<key>BbSNUM</key>")
                XMLWriter.WriteLine("	<data>" + bbsnum + "</data>")

                If ExistsInBuildManifest(BuildManifest, "BbSkeyId", "key") Then
                    XMLWriter.WriteLine("	<key>BbSkeyId</key>")
                    XMLWriter.WriteLine("	<data>" + GetFromBuildManifest(BuildManifest, "array", "dict", "BbSkeyId", "data", False) + "</data>")
                End If

                If ExistsInBuildManifest(BuildManifest, "BbActivationManifestKeyHash", "key") Then
                    XMLWriter.WriteLine("	<key>BbActivationManifestKeyHash</key>")
                    XMLWriter.WriteLine("	<data>" + GetFromBuildManifest(BuildManifest, "array", "dict", "BbActivationManifestKeyHash", "data", False) + "</data>")
                End If

                If ExistsInBuildManifest(BuildManifest, "BbProvisioningManifestKeyHash", "key") Then
                    XMLWriter.WriteLine("	<key>BbProvisioningManifestKeyHash</key>")
                    XMLWriter.WriteLine("	<data>" + GetFromBuildManifest(BuildManifest, "array", "dict", "BbProvisioningManifestKeyHash", "data", False) + "</data>")
                End If

            End If
            XMLWriter.WriteLine("	<key>UniqueBuildID</key>")
            XMLWriter.WriteLine("	<data>" + GetFromBuildManifest(BuildManifest, "array", "dict", "UniqueBuildID", "data", False) + "</data>")
            XMLWriter.WriteLine("</dict>")
            XMLWriter.Write("</plist>")

            XMLWriter.Close()
        End Using
    End Sub
End Class
