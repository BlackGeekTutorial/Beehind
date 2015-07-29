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

Public Class Common_Functions

    Public Shared Sub Reset()
        MainView.IPSWTextBox.Text = ""
        OTADowngrade = False
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
        MainView.ChooseIPSWButton.Enabled = True
        MainView.DowngradeProgressBar.Value = 0
    End Sub

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

    Public Shared Function ReadAllBytes(reader As BinaryReader) As Byte()
        Const bufferSize As Integer = 4096
        Using ms As New MemoryStream()
            Dim buffer(bufferSize) As Byte
            Dim count As Integer
            Do
                count = reader.Read(buffer, 0, buffer.Length)
                If count > 0 Then ms.Write(buffer, 0, count)
            Loop While count <> 0

            Return ms.ToArray()
        End Using
    End Function

    Public Shared Sub CreateDirectory(path As String, newdir As String, replace As Boolean)
        If My.Computer.FileSystem.DirectoryExists(path + newdir) Then
            If replace = True Then
                Delete(True, path + newdir)
                My.Computer.FileSystem.CreateDirectory(path + newdir)
            End If
        End If
        My.Computer.FileSystem.CreateDirectory(path + newdir)
    End Sub

    Public Shared Sub Unzip(Infile As String, Outdir As String)
        InfoZipUnzip("""" + Infile + """" + " -d" + """" + Outdir + """")
    End Sub

    Public Shared Sub Zip(ZipFile As String, FileName As String, FilePath As String)
        InfoZipZip("-1 -r " + """" + ZipFile + """" + " " + """" + FileName + """", FilePath)
    End Sub

    Public Shared Function DecimalNumberToHexNumber(ByVal Number As Double) As String
        Dim hex_val As String
        hex_val = Hex(Number)
        Return hex_val
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

    Public Shared Sub SendTSSRequest(TSSRequestPlist As String, Outfile As String)
        Dim TSSRequest As WebRequest = WebRequest.Create("http://gs.apple.com:80/TSS/controller?action=2")
        TSSRequest.Method = "POST"
        TSSRequest.ContentType = "text/xml; charset=" + """" + "utf-8" + """"
        CType(TSSRequest, HttpWebRequest).UserAgent = "User-Agent	Mozilla/5.0 (Macintosh; Intel Mac OS X 10_10_2) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/40.0.2214.115 Safari/537.36"
        Dim TSSRequestFile As Byte() = File.ReadAllBytes(TSSRequestPlist)
        Dim dataStream As Stream = TSSRequest.GetRequestStream()
        dataStream.Write(TSSRequestFile, 0, TSSRequestFile.Length)
        dataStream.Close()
        Dim response As WebResponse = TSSRequest.GetResponse()
        Dim data As Stream = response.GetResponseStream
        Dim reader As New StreamReader(data)
        Dim AppleResponse As String = reader.ReadToEnd()
        reader.Close()
        dataStream.Close()
        response.Close()

        If AppleResponse.Contains("This device isn't eligible for the requested build.") Then
            MessageBox.Show("This device isn't eligible for the requested build.", "Apple TSS Server Returned an ERROR",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            OTADowngrade = False
            MainView.CancelOTADWN.Visible = False
            MainView.ChooseSHSHButton.Visible = True
            MainView.ChooseSHSHButton.Enabled = True
            MainView.SHSHGroupBox.Text = "Browse for SHSH"
            ECIDForm.Close()
            Exit Sub
        ElseIf AppleResponse.Contains("An internal error occurred.") Then
            MessageBox.Show("An internal error occurred.", "Apple TSS Server Returned an ERROR",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            OTADowngrade = False
            MainView.CancelOTADWN.Visible = False
            MainView.ChooseSHSHButton.Visible = True
            MainView.ChooseSHSHButton.Enabled = True
            MainView.SHSHGroupBox.Text = "Browse for SHSH"
            ECIDForm.Close()
            Exit Sub
        ElseIf AppleResponse.Contains("No data in the request") Then
            MessageBox.Show("No data in the request", "Apple TSS Server Returned an ERROR",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            OTADowngrade = False
            MainView.CancelOTADWN.Visible = False
            MainView.ChooseSHSHButton.Visible = True
            MainView.ChooseSHSHButton.Enabled = True
            MainView.SHSHGroupBox.Text = "Browse for SHSH"
            ECIDForm.Close()
            Exit Sub
        ElseIf AppleResponse.Contains("Error occured while importing config packet with cpsn:") Then
            MessageBox.Show("Error occured while importing config packet with cpsn:", "Apple TSS Server Returned an ERROR",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            OTADowngrade = False
            MainView.CancelOTADWN.Visible = False
            MainView.ChooseSHSHButton.Visible = True
            MainView.ChooseSHSHButton.Enabled = True
            MainView.SHSHGroupBox.Text = "Browse for SHSH"
            ECIDForm.Close()
            Exit Sub
        ElseIf AppleResponse.Contains("Invalid Option!") Then
            MessageBox.Show("Invalid Option!", "Apple TSS Server Returned an ERROR",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            OTADowngrade = False
            MainView.CancelOTADWN.Visible = False
            MainView.ChooseSHSHButton.Visible = True
            MainView.ChooseSHSHButton.Enabled = True
            MainView.SHSHGroupBox.Text = "Browse for SHSH"
            ECIDForm.Close()
            Exit Sub
        ElseIf AppleResponse.Contains("SUCCESS") Then
            File.WriteAllText(Outfile, AppleResponse.Replace("STATUS=0&MESSAGE=SUCCESS&REQUEST_STRING=", ""))
        End If

    End Sub

    Public Shared Function iOSAsInteger()
        If iOS_Version = "5.0" Or iOS_Version = "5.0.1" Or iOS_Version = "5.1" Or iOS_Version = "5.1.1" Then
            Return 5
        ElseIf iOS_Version = "6.0" Or iOS_Version = "6.0.1" Or iOS_Version = "6.0.2" Or iOS_Version = "6.1" Or iOS_Version = "6.1.1" Or iOS_Version = "6.1.2" Or iOS_Version = "6.1.3" Or iOS_Version = "6.1.4" Or iOS_Version = "6.1.5" Or iOS_Version = "6.1.6" Then
            Return 6
        ElseIf iOS_Version = "7.0" Or iOS_Version = "7.0.1" Or iOS_Version = "7.0.2" Or iOS_Version = "7.0.3" Or iOS_Version = "7.0.4" Or iOS_Version = "7.0.5" Or iOS_Version = "7.0.6" Or iOS_Version = "7.1" Or iOS_Version = "7.1.1" Or iOS_Version = "7.1.2" Then
            Return 7
        ElseIf iOS_Version = "8.0" Or iOS_Version = "8.0.1" Or iOS_Version = "8.0.2" Or iOS_Version = "8.1" Or iOS_Version = "8.1" Or iOS_Version = "8.1.1" Or iOS_Version = "8.1.2" Or iOS_Version = "8.1.3" Or iOS_Version = "8.2" Or iOS_Version = "8.3" Then
            Return 8
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

    Public Shared Function CheckIfProcessIsRunning(ProcessName As String)
        Return Process.GetProcessesByName(ProcessName).Count
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


    Public Shared Function WhatProcessesAreLockingAFile(File As String)
        Dim myProcessArray As New ArrayList()
        Dim myProcess As Process
        myProcessArray.Clear()
        Dim processes As Process() = Process.GetProcesses()
        Dim i As Integer = 0
        For i = 0 To processes.GetUpperBound(0) - 1
            myProcess = processes(i)
            'if (!myProcess.HasExited) //This will cause an "Access is denied" error
            If myProcess.Threads.Count > 0 Then
                Try
                    Dim modules As ProcessModuleCollection = myProcess.Modules
                    Dim j As Integer = 0
                    For j = 0 To modules.Count - 1
                        If (modules(j).FileName.ToLower().CompareTo(File.ToLower()) = 0) Then
                            myProcessArray.Add(myProcess)
                            ' TODO: might not be correct. Was : Exit For
                            Exit For
                        End If
                    Next
                    'MsgBox(("Error : " & exception.Message)) 
                Catch exception As Exception
                End Try
            End If
        Next
        myProcessArray.Add("ciao")
        Return myProcessArray
    End Function

    Public Shared Function Updater() As Boolean
        If CheckForInternetConnection() = True Then
            Using client As New WebClient
                latestversion = Decimal.Parse(client.DownloadString("http://geeksn0w.it/Beehind/latest-win.txt"), CultureInfo.InvariantCulture)
                ldownload = client.DownloadString("http://geeksn0w.it/Beehind/dlink-latest.win.txt")
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
    End Function

    Public Shared Function getControlFromName(ByRef containerObj As Object, _
                         ByVal name As String) As Control
        Try
            Dim tempCtrl As Control
            For Each tempCtrl In containerObj.Controls
                If tempCtrl.Name.ToUpper.Trim = name.ToUpper.Trim Then
                    Return tempCtrl
                End If
            Next tempCtrl
        Catch ex As Exception
        End Try
    End Function


    Public Shared Function IsDFUConnected()
        Dim forever As Boolean = True
        Dim text1 As String = ""
        text1 = " "
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
        'Loop()
    End Function

    Public Shared Function IsRecoveryConnected()
        'Dim DFUConnected As Boolean = False
        'Dim forever As Boolean = True
        Dim text1 As String = ""
        'Do Until DFUConnected = True
        'Delay(1)
        text1 = " "
        Dim searcher As New ManagementObjectSearcher( _
                  "root\CIMV2", _
                  "SELECT * FROM Win32_PnPEntity WHERE Description = 'Apple Recovery (iBoot) USB Driver'")
        For Each queryObj As ManagementObject In searcher.Get()

            text1 += (queryObj("Description"))
        Next
        If text1.Contains("iBoot") Then
            'DFUConnected = True
            Return True
        Else
            Return False
        End If
        'Loop
    End Function

    Public Shared Function IsUserlandConnected()
        Dim forever As Boolean = True
        Dim USBName As String = String.Empty
        Dim USBSearcher As New ManagementObjectSearcher( _
                      "root\CIMV2", _
                      "SELECT * FROM Win32_PnPEntity WHERE Description = 'Apple Mobile Device USB Driver'")
        For Each queryObj As ManagementObject In USBSearcher.Get()
            USBName += (queryObj("Description"))
        Next
        If USBName = "Apple Mobile Device USB Driver" Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
