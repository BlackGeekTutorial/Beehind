Imports System.Net
Imports Beehind.Common_Definitions
Imports Beehind.Processes
Imports System.IO
Imports System.IO.Compression
Imports System.Globalization
Imports System.Environment
Imports System.Security.Cryptography
Imports System.Text
Imports System.Management
Imports System.Collections
Imports System.Diagnostics
Imports System.ComponentModel
Imports System.Text.RegularExpressions
Imports System.Security.Principal
Imports Microsoft.Win32

Public Class Common_Functions

    Public Shared Function IsRoot()
        Dim identity = WindowsIdentity.GetCurrent()
        Dim principal = New WindowsPrincipal(identity)
        Dim isElevated As Boolean = principal.IsInRole(WindowsBuiltInRole.Administrator)

        Return isElevated
    End Function

    Public Shared Sub Reset()
        MainView.IPSWTextBox.Text = ""
        DowngradeType = "SIGNED"
        MainView.IPSWGroupBox.Text = "Browse for the IPSW"
        MainView.SHSHGroupBox.Text = "Browse for SHSH"
        MainView.SHSHTextBox.Text = ""
        MainView.SHSHTextBox.Enabled = False
        MainView.MagicButton.Text = "Build IPSW!"
        MainView.MagicButton.Enabled = True
        MainView.MagicButton.Visible = True
        MainView.PathLabelIPSW.Text = "Path:"
        MainView.PathLabelSHSH.Text = "Path:"
        MainView.ChooseSHSHButton.Enabled = True
        MainView.ChooseSHSHButton.Visible = True
        MainView.ChooseIPSWButton.Enabled = True
        MainView.DowngradeProgressBar.Value = 0
        MainView.BasebandCheckBox.Checked = False
        MainView.BasebandCheckBox.Enabled = True
        MainView.BasebandComboBox.Text = ""
        MainView.CustomSizeCheckBox.Checked = False
        MainView.CustomSizeCheckBox.Enabled = True
        MainView.NewSizeUpDown.Value = 1024
        MainView.NewSizeUpDown.Enabled = True
        MainView.CustomBundleCheckBox.Enabled = True
        MainView.CustomBundleCheckBox.Checked = False
        MainView.HacktivateCheckBox.Checked = False
        MainView.HacktivateCheckBox.Enabled = True
        MainView.AddUntetherCheckBox.Enabled = True
        MainView.AddUntetherCheckBox.Checked = False
        MainView.AddSSHCheckBox.Enabled = True
        MainView.AddSSHCheckBox.Checked = False
        MainView.AddCydiaCheckBox.Enabled = True
        MainView.AddCydiaCheckBox.Checked = False
        MainView.NoNANDFlashCheckBox.Enabled = True
        MainView.NoNANDFlashCheckBox.Checked = False
        MainView.NoSysFlashCheckBox.Enabled = True
        MainView.NoSysFlashCheckBox.Checked = False
        iOS_Version = ""
        iOS_Build = ""
        DeviceModel = ""
        DeviceClass = ""
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
        SHSHPath = ""
        XMLPath = ""
        MainView.CancelOTADWN.Visible = False
        MainView.CancelOTADWN.Text = "Cancel OTA Downgrade"
        IsiFaithMode = False
        ExploitType = String.Empty

        If Beehind.Betashit.IsRelease = True Then
            MainView.BasebandComboBox.Enabled = False
            MainView.BasebandCheckBox.Enabled = False
            MainView.CustomBundleCheckBox.Enabled = False
        End If
    End Sub
    Public Shared Function GetSettingItem(Infile As String, Identifier As String) As String
        Dim SettingsDocument() As String = IO.File.ReadAllLines(Infile)
        Dim DocumentLength As Integer = SettingsDocument.Length
        Dim CurrentLine As Integer = 0
        Dim result As String = "GOTANYITEM!"
        Do Until CurrentLine = DocumentLength Or result <> "GOTANYITEM!"
            If SettingsDocument(CurrentLine).Trim.StartsWith(Identifier) Then
                result = (SettingsDocument(CurrentLine).Trim).Replace(Identifier + ": ", "")
                CurrentLine = CurrentLine + 1
            Else
                CurrentLine = CurrentLine + 1
            End If
        Loop
        Return result.Trim
    End Function

    Public Shared Sub Delay(ByVal dblSecs As Double)
        'iH8Sn0w Delay
        Const OneSec As Double = 1.0# / (1440.0# * 60.0#)
        Dim dblWaitTil As Date
        Now.AddSeconds(OneSec)
        dblWaitTil = Now.AddSeconds(OneSec).AddSeconds(dblSecs)
        Do Until Now > dblWaitTil
            Application.DoEvents()
        Loop
    End Sub

    Public Shared Function UninstallProgram(name As String, wait As Boolean) As Integer
        Dim uninstallstring As String = String.Empty
        Dim ParentKey As RegistryKey
        If Environment.Is64BitOperatingSystem = True Then
            ParentKey = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64)
            ParentKey = ParentKey.OpenSubKey("SOFTWARE\MICROSOFT\Windows\CurrentVersion\Installer\UserData\S-1-5-18\Products")
        Else
            ParentKey = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry32)
            ParentKey = ParentKey.OpenSubKey("SOFTWARE\MICROSOFT\Windows\CurrentVersion\Installer\UserData\S-1-5-18\Products")
        End If

        Dim ChildKey As RegistryKey

        For Each child As String In ParentKey.GetSubKeyNames()

            ChildKey = ParentKey.OpenSubKey(child).OpenSubKey("InstallProperties")

            If Not ChildKey Is Nothing Then

                If ChildKey.GetValue("DisplayName").ToString.Contains(name) And ChildKey.GetValue("UninstallString") IsNot Nothing Then
                    uninstallstring = ChildKey.GetValue("UninstallString")
                    Exit For
                End If
            End If
        Next
        If Not uninstallstring.Contains("No Uninstall String") Then
            If wait = False Then
                Return Shell(uninstallstring, AppWinStyle.NormalFocus)
            Else
                Dim pid As Integer
                pid = Shell(uninstallstring, AppWinStyle.NormalFocus)
                If Not pid = 0 Then
                    Do Until ProcessPIDIsRunning(pid) = True
                        Delay(1)
                    Loop
                    Do While ProcessPIDIsRunning(pid) = True
                        Delay(1)
                    Loop
                    Return pid
                Else
                    MessageBox.Show("Beehind wasn't able to uninstall " + name + ".", "Uninstaller failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Function
                End If
            End If
        Else
            Return 0
        End If
    End Function

    Public Shared Function DeterminateCurrentDate()
        Dim regDate As Date = Date.Now()
        Dim strDate As String = regDate.ToString("dd/MM/yyyy")
        Return strDate
    End Function

    Public Shared Sub Delete(IsDirectory As Boolean, path As String)
        If IsDirectory = True Then
            If My.Computer.FileSystem.DirectoryExists(path) Then
                    IO.Directory.Delete(path, True)
                End If
            Else
                If My.Computer.FileSystem.FileExists(path) Then
                    IO.File.Delete(path)
                End If
            End If
    End Sub

    Public Shared Sub DeleteLine(ByRef FileAddress As String, ByRef line As Integer)
        Dim TheFileLines As New List(Of String)
        TheFileLines.AddRange(System.IO.File.ReadAllLines(FileAddress))
        If line >= TheFileLines.Count Then Exit Sub
        TheFileLines.RemoveAt(line)
        System.IO.File.WriteAllLines(FileAddress, TheFileLines.ToArray)
    End Sub

    Public Shared Sub CreateDirectory(path As String, newdir As String, replace As Boolean)
        If My.Computer.FileSystem.DirectoryExists(path + newdir) Then
            If replace = True Then
                Delete(True, path + newdir)
                My.Computer.FileSystem.CreateDirectory(path + newdir)
            End If
        Else
            My.Computer.FileSystem.CreateDirectory(path + newdir)
        End If
    End Sub

    Public Shared Sub Unzip(Infile As String, Outdir As String, Optional ByVal JustAFile As String = "")
        If JustAFile <> "" Then
            JustAFile = " " + """" + JustAFile + """"
        End If
        InfoZipUnzip("-o " + """" + Infile + """" + JustAFile + " -d" + """" + Outdir + """")
    End Sub

    Public Shared Sub Zip(ZipFile As String, FileName As String, FilePath As String)
        InfoZipZip("-1 -r " + """" + ZipFile + """" + " " + """" + FileName + """", FilePath)
    End Sub

    Public Shared Function DecimalNumberToHexNumber(ByVal Number As Double) As String
        Dim hex_val As String
        hex_val = Hex(Number)
        Return hex_val
    End Function

    Public Shared Function HexToDec(Hexnumber As String) As Integer
        If Hexnumber.Contains("0x") Then
            Hexnumber = Hexnumber.Replace("0x", "")
        End If
        Dim number As Integer = Integer.Parse(Hexnumber, System.Globalization.NumberStyles.HexNumber)
        Return number
    End Function

    Public Shared Function HexToLong(ByVal sHex As String) As Long
        HexToLong = Val("&H" & sHex & "&")
    End Function


    Public Shared Function ByteArrayToHexString(ba As Byte()) As String
        Dim hex As String = BitConverter.ToString(ba)
        Return hex.Replace("-", "")
    End Function
    Public Shared Function PrintByteArray(ByVal array() As Byte)
        Dim hex_value As String = ""
        Dim i As Integer
        For i = 0 To array.Length - 1
            hex_value += array(i).ToString("X2")
        Next i
        Return hex_value.ToLower
    End Function

    Public Shared Function ASCII2Hex(str)
        Dim byteArray() As Byte
        Dim hexNumbers As System.Text.StringBuilder = New System.Text.StringBuilder
        byteArray = System.Text.ASCIIEncoding.ASCII.GetBytes(str)
        For i As Integer = 0 To byteArray.Length - 1
            hexNumbers.Append(byteArray(i).ToString("x"))
        Next
        Return hexNumbers.ToString()
    End Function

    Public Shared Function FindBytes(src As Byte(), find As Byte()) As Integer
        Dim index As Integer = -1
        Dim matchIndex As Integer = 0
        For i As Integer = 0 To src.Length - 1
            If src(i) = find(matchIndex) Then
                If matchIndex = (find.Length - 1) Then
                    index = i - matchIndex
                    Exit For
                End If
                matchIndex += 1
            Else
                matchIndex = 0

            End If
        Next
        Return index
    End Function

    Public Shared Function ReplaceBytes(src As Byte(), search As Byte(), repl As Byte()) As Byte()
        Dim dst As Byte() = Nothing
        Dim index As Integer = FindBytes(src, search)
        If index >= 0 Then
            dst = New Byte(src.Length - search.Length + (repl.Length - 1)) {}
            Buffer.BlockCopy(src, 0, dst, 0, index)
            Buffer.BlockCopy(repl, 0, dst, index, repl.Length)
            Buffer.BlockCopy(src, index + search.Length, dst, index + repl.Length, src.Length - (index + search.Length))
        End If
        Return dst
    End Function

    Public Shared Function ConvertHexStringToByteArray(hexString As String) As Byte()
        If hexString.Length Mod 2 <> 0 Then
            Throw New ArgumentException([String].Format(CultureInfo.InvariantCulture, "The binary key cannot have an odd number of digits: {0}", hexString))
        End If

        Dim HexAsBytes As Byte() = New Byte(hexString.Length / 2 - 1) {}
        For index As Integer = 0 To HexAsBytes.Length - 1
            Dim byteValue As String = hexString.Substring(index * 2, 2)
            HexAsBytes(index) = Byte.Parse(byteValue, NumberStyles.HexNumber, CultureInfo.InvariantCulture)
        Next
        Return HexAsBytes
    End Function

    Public Shared Function ASCIIToHex(ASCIIString As String)
        Dim hexNumbers As System.Text.StringBuilder = New System.Text.StringBuilder
        For i As Integer = 0 To System.Text.ASCIIEncoding.ASCII.GetBytes(ASCIIString).Length - 1
            hexNumbers.Append(System.Text.ASCIIEncoding.ASCII.GetBytes(ASCIIString)(i).ToString("x"))
        Next

        Return hexNumbers.ToString()
    End Function

    Public Shared Sub HexPatchFile(ByVal Infile As String, Outfile As String, OriginalHexBytes As String, PatchedHexBytes As String)
        Dim OriginalBytes As Byte() = ConvertHexStringToByteArray(OriginalHexBytes)
        Dim PatchedBytes As Byte() = ConvertHexStringToByteArray(PatchedHexBytes)
        Dim SourceBytes As Byte() = File.ReadAllBytes(Infile)
        Dim PatchedPayload As Byte() = ReplaceBytes(SourceBytes, OriginalBytes, PatchedBytes)
        If PatchedPayload Is Nothing Then
            ' OriginalBytes not found in SourceBytes
            MessageBox.Show("ERROR: This pattern isn't replaceble: " + OriginalHexBytes)
            Exit Sub
        End If
        File.WriteAllBytes(Outfile, PatchedPayload)
    End Sub

    Public Shared Sub WriteBytesToFile(bytes As Byte(), NewFilePath As String)
        Dim outFile As System.IO.FileStream
        outFile = New System.IO.FileStream(NewFilePath, _
                                           System.IO.FileMode.Create, _
                                           System.IO.FileAccess.Write)
        outFile.Write(bytes, 0, bytes.Length - 1)
        outFile.Close()
    End Sub

    Public Shared Function ByteArrayToString(arrInput As Byte()) As String
        Dim builder As New StringBuilder(arrInput.Length)
        For i As Integer = 0 To (arrInput.Length - 1)
            builder.Append(arrInput(i).ToString("X2"))
        Next
        Return builder.ToString()
    End Function


    Public Shared Function SubUpHex(Address As String, Value As String) As Object
        Dim num As Integer = Integer.Parse(Value.Replace("0x", ""), NumberStyles.HexNumber)
        Dim num3 As Integer = Integer.Parse(Address.Replace("0x", ""), NumberStyles.HexNumber) - num
        Return ("0x" + num3.ToString("X"))
    End Function


    Public Shared Sub RawPatch(FilePath As String, Offset As String, BytesToWrite As String)
        Offset = Offset.Replace("0x", "")
        BytesToWrite = BytesToWrite.Replace(" ", "")
        Dim writer As New BinaryWriter(System.IO.File.Open(FilePath, FileMode.Open, FileAccess.ReadWrite))
        writer.Seek(Integer.Parse(Offset, NumberStyles.HexNumber), SeekOrigin.Begin)
        writer.Write(ConvertHexStringToByteArray(BytesToWrite))
        writer.Close()
    End Sub

    '<----------------------------------------------------- SHSH part ---------------------------------------------------------------->

    Public Shared Function search(fileName As String, searchKey As Char(), start As Long) As Long
        Try
            Dim pos As Long
            Dim count As Integer = 0
            Dim f As New FileStream(fileName, FileMode.Open, FileAccess.Read)
            f.Position = start
            Dim character As Integer = f.ReadByte()
            While character <> -1
                If character = Asc(searchKey(count)) Then
                    count += 1
                    If count > searchKey.Length - 1 Then
                        Exit While
                    End If
                Else
                    count = 0
                End If
                character = f.ReadByte()
            End While
            pos = f.Position
            f.Close()
            If count > searchKey.Length - 1 Then
                Return pos
            End If
        Catch
        End Try
        Return -1
    End Function

    Public Shared Sub SendTSSRequest(TSSRequestPlist As String, Outfile As String, Optional ByVal AlterHost As Boolean = False)

        Dim tssquery_p As New Process()
        Try
            tssquery_p.StartInfo.UseShellExecute = False
            tssquery_p.StartInfo.FileName = tempdir + "\TSSQuery.exe"
            tssquery_p.StartInfo.Arguments = """" + TSSRequestPlist + """" + " " + """" + Outfile + """"
            tssquery_p.StartInfo.CreateNoWindow = True
            tssquery_p.StartInfo.RedirectStandardOutput = True
            tssquery_p.StartInfo.RedirectStandardError = True
            tssquery_p.Start()
        Catch ex As Exception
        End Try
        Do Until tssquery_p.HasExited
            Delay(1)
        Loop

        Dim stdout As String = String.Empty
        Dim stderr As String = String.Empty
        Dim infos As String = String.Empty

        Using oStreamReader As System.IO.StreamReader = tssquery_p.StandardOutput
            stdout = oStreamReader.ReadToEnd()
        End Using

        Using oStreamReader As System.IO.StreamReader = tssquery_p.StandardError
            stderr = oStreamReader.ReadToEnd()
        End Using

        infos = stdout + stderr

        If Not infos.Contains("SUCCESS") Then
            MessageBox.Show(infos, "Apple TSS Server Returned an ERROR",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            DowngradeType = "SIGNED"
            MainView.CancelOTADWN.Visible = False
            MainView.ChooseSHSHButton.Visible = True
            MainView.ChooseSHSHButton.Enabled = True
            MainView.SHSHGroupBox.Text = "Browse for SHSH"
            ECIDForm.Close()
            Exit Sub
        End If

    End Sub

    Public Shared Function iOSAsInteger(ios)
        If iOS_Version.StartsWith("1.") Then
            Return 1
        ElseIf iOS_Version.StartsWith("2.") Then
            Return 2
        ElseIf iOS_Version.StartsWith("3.") Then
            Return 3
        ElseIf iOS_Version.StartsWith("4.") Then
            Return 4
        ElseIf iOS_Version.StartsWith("5.") Then
            Return 5
        ElseIf iOS_Version.StartsWith("6.") Then
            Return 6
        ElseIf iOS_Version.StartsWith("7.") Then
            Return 7
        ElseIf iOS_Version.StartsWith("8.") Then
            Return 8
        ElseIf iOS_Version.StartsWith("9.") Then
            Return 9
        End If
    End Function

    '<-------------------------------------------------------------------------------------------------------------------------------->

    Public Shared Function Check_File_MD5(ByVal Infile As String)
        Dim hash = MD5.Create
        Dim hashValue() As Byte
        Dim fileStream As FileStream = File.OpenRead(Infile)
        fileStream.Position = 0
        hashValue = hash.ComputeHash(fileStream)
        Dim hash_hex = PrintByteArray(hashValue)
        fileStream.Close()
        Return hash_hex
    End Function

    Public Shared Function CheckForInternetConnection() As Boolean
        Try
            Using client = New WebClient()
                Using stream = client.OpenRead("http://www.google.com")
                    Return True
                End Using
            End Using
        Catch
            Return False
        End Try
    End Function

    Public Shared Function IsIpValid(ByVal ipAddress As String)
        Dim expr As String = "^\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}$"
        Dim reg As Regex = New Regex(expr)
        If (reg.IsMatch(ipAddress)) Then
            Dim parts() As String = ipAddress.Split(".")
            If parts.Length <> 4 Then
                Return False
                Exit Function
            End If
            For Each num In parts
                If Convert.ToInt32(num) > 255 Then
                    Return False
                    Exit Function
                End If
            Next
            Return True
        Else
            Return False
            Exit Function
        End If
    End Function

    Public Enum ThreadAccess As Integer
        TERMINATE = (&H1)
        SUSPEND_RESUME = (&H2)
        GET_CONTEXT = (&H8)
        SET_CONTEXT = (&H10)
        SET_INFORMATION = (&H20)
        QUERY_INFORMATION = (&H40)
        SET_THREAD_TOKEN = (&H80)
        IMPERSONATE = (&H100)
        DIRECT_IMPERSONATION = (&H200)
    End Enum

    Public Declare Function OpenThread Lib "kernel32.dll" (ByVal dwDesiredAccess As ThreadAccess, ByVal bInheritHandle As Boolean, ByVal dwThreadId As UInteger) As IntPtr
    Public Declare Function SuspendThread Lib "kernel32.dll" (ByVal hThread As IntPtr) As UInteger
    Public Declare Function ResumeThread Lib "kernel32.dll" (ByVal hThread As IntPtr) As UInteger
    Public Declare Function CloseHandle Lib "kernel32.dll" (ByVal hHandle As IntPtr) As Boolean

    Public Shared Sub SuspendProcess(ByVal process As System.Diagnostics.Process)
        For Each t As ProcessThread In process.Threads
            Dim th As IntPtr
            th = OpenThread(ThreadAccess.SUSPEND_RESUME, False, t.Id)
            If th <> IntPtr.Zero Then
                SuspendThread(th)
                CloseHandle(th)
            End If
        Next
    End Sub

    Public Shared Sub ResumeProcess(ByVal process As System.Diagnostics.Process)
        For Each t As ProcessThread In process.Threads
            Dim th As IntPtr
            th = OpenThread(ThreadAccess.SUSPEND_RESUME, False, t.Id)
            If th <> IntPtr.Zero Then
                ResumeThread(th)
                CloseHandle(th)
            End If
        Next
    End Sub

    Public Shared Function ProcessNameIsRunning(ProcessName As String)
        Return Process.GetProcessesByName(ProcessName).Count
    End Function


    Public Shared Function ProcessPIDIsRunning(id As Integer) As Boolean
        Return Process.GetProcesses().Any(Function(x) x.Id = id)
    End Function

    Public Shared Sub Kill(ProcessesList As String())
        For Each ProcessName In ProcessesList
            Dim SubProcesses() As Process = Process.GetProcessesByName(ProcessName)
            For Each SubProcess As Process In SubProcesses
                If IsProcessRunning(SubProcess.ProcessName) = True Then
                    SubProcess.Kill()
                End If
            Next
        Next
    End Sub

    Public Shared Function IsProcessRunning(name As String) As Boolean
        For Each clsProcess As Process In Process.GetProcesses()
            If clsProcess.ProcessName.StartsWith(name) Then
                Return True
            End If
        Next
        Return False
    End Function

    Public Shared Sub Updater()
        If CheckForInternetConnection() = True Then
            Using client As New WebClient
                latestversion = Decimal.Parse(client.DownloadString("https://raw.githubusercontent.com/BlackGeekTutorial/Beehind/master/Updater/latest-win.txt"), CultureInfo.InvariantCulture)
                ldownload = client.DownloadString("https://raw.githubusercontent.com/BlackGeekTutorial/Beehind/master/Updater/dlink-latest.win.txt")
                If currentversion < latestversion Then
                    MainView.UpdateLabel.Text = "This version (" + currentversion.ToString.Replace(",", ".") + ") is obsolete! Download the newer one (" + latestversion.ToString.Replace(",", ".") + ")"
                    MainView.LatestBuildLinkLabel.Visible = True
                Else
                    MainView.UpdateLabel.Text = "This is the latest version of Beehind (" + currentversion.ToString.Replace(",", ".") + ")."
                End If
            End Using
        Else
            MainView.UpdateLabel.Text = "Beehind wasn't able to check for updates... Check your internet connection!"
        End If
    End Sub

    Public Shared Function IsDFUConnected()
        Dim forever As Boolean = True
        Dim text1 As String = " "
        Dim searcher As New ManagementObjectSearcher( _
                  "root\CIMV2", _
                  "SELECT * FROM Win32_PnPEntity WHERE Description = 'Apple Recovery (DFU) USB Driver'")
        For Each queryObj As ManagementObject In searcher.Get()
            text1 += (queryObj("Description"))
        Next
        If text1.Contains("DFU") Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Shared Function IsRecoveryConnected()
        Dim text1 As String = " "
        Dim searcher As New ManagementObjectSearcher( _
                  "root\CIMV2", _
                  "SELECT * FROM Win32_PnPEntity WHERE Description = 'Apple Recovery (iBoot) USB Driver'")
        For Each queryObj As ManagementObject In searcher.Get()
            text1 += (queryObj("Description"))
        Next
        If text1.Contains("iBoot") Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Shared Function IsUserlandConnected(Optional ByVal comunication As Boolean = True)

A:
        Dim forever As Boolean = True
        Dim USBName As String = String.Empty
        Dim USBSearcher As New ManagementObjectSearcher( _
                      "root\CIMV2", _
                      "SELECT * FROM Win32_PnPEntity WHERE Description = 'Apple Mobile Device USB Driver'")
        For Each queryObj As ManagementObject In USBSearcher.Get()
            USBName += (queryObj("Description"))
        Next
        If USBName.Contains("Apple Mobile Device USB Driver") Then
            If comunication = True Then
                Dim a As String = GetDeviceInfos(False)
                If a.Contains("ActivationState:") Then
                    Return True
                Else
                    If a.Contains("error code -20") Then
                        'trust this computer
                        MessageBox.Show("ERROR: This computer host is not trusted by the attatched device. In order to use your iPhone, iPod touch or iPad with Beehind, please tap on 'Trust' button right now. Then click 'OK' to retry" + " " + a, "Untrusted Computer", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        GoTo A
                    ElseIf a.Contains("error code -14") Then
                        ' password protected
                        MessageBox.Show("ERROR: the attatched device is password protected. In order to use your iPhone, iPod touch or iPad with Beehind, please unlock it. Then click 'OK' to retry" + " " + a, "Password-protected", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        GoTo A
                    Else
                        'unknown error code
                        MessageBox.Show("ERROR: Beehind (ideviceinfo) wasn't able to estabilish a connection with the attatched device. Please, unplug and replug it. Then retry with Beehind." + " " + a, "Unknown Error.", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        GoTo A
                    End If
                End If
            Else
                Return True
            End If
        Else
            Return False
        End If
    End Function

    Public Shared Function IsRestoreConnected()

        Dim forever As Boolean = True
        Dim USBName As String = String.Empty
        Dim USBSearcher As New ManagementObjectSearcher( _
                      "root\CIMV2", _
                      "SELECT * FROM Win32_PnPEntity WHERE Description = 'Apple Mobile Device USB Driver'")
        For Each queryObj As ManagementObject In USBSearcher.Get()
            USBName += (queryObj("Description"))
        Next
        If USBName.Contains("Apple Mobile Device USB Driver") And Not USBName.Contains("iBoot") And Not USBName.Contains("DFU") Then
            Dim a As String = GetDeviceInfos(False)
            If Not a.Contains("ActivationState:") Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function
End Class
