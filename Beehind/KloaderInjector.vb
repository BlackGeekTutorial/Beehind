Imports Beehind.Common_Functions
Imports Beehind.Common_Definitions
Imports Beehind.Processes
Imports System.Management
Imports WinSCP
Imports System.Environment
Imports System.Text.RegularExpressions
Imports System.IO

Public Class KloaderInjector

    Public Shared SSHBWProgress As Integer = 0
    Public Shared kloaderoutput As String = String.Empty
    Public Shared iBSS As String = String.Empty

    Public Shared Sub AddLineToKloaderConsole(Text As String)
        KloaderInjector.SSHConsole.AppendText(Environment.NewLine + Text)
        KloaderInjector.SSHConsole.SelectionStart = KloaderInjector.SSHConsole.TextLength
        KloaderInjector.SSHConsole.ScrollToCaret()
    End Sub
    Private Sub DeviceChecker_Tick(sender As Object, e As EventArgs) Handles DeviceChecker.Tick
        If IsUserlandConnected() = True Then
            Label1.Text = "New Apple device found! Make sure it has OpenSSH installed and then press the " + """" + "Enter Pwned DFU Button" + """" + "."
        Else
            Label1.Text = "No Apple devices connected to the computer, connect one to begin"
        End If

        If IsUserlandConnected() = True And iBSSPathTextBox.Text <> "" Then
            PwnDFUButton.Enabled = True
        Else
            PwnDFUButton.Enabled = False
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles PwnDFUButton.Click

        'making sure iBSS is suitable for the connected device
        iBSS = File.ReadAllText(iBSSPathTextBox.Text)
        Dim DumpedHardwareModel As String = GetDeviceInfos(True, "HardwareModel")
        Dim iBSSHardwareModel As String = (Strings.Mid(iBSS, iBSS.IndexOf("iBSS for ") + ("iBSS for ").Length + 1, iBSS.IndexOf(", Copyright ") - iBSS.IndexOf("iBSS for ") - ("iBSS for ").Length)).Trim()
        AddLineToKloaderConsole("[Info] The given iBSS' Hardware model is: " + """" + iBSSHardwareModel + """")
        If DumpedHardwareModel.StartsWith("N") Or DumpedHardwareModel.StartsWith("K") Or DumpedHardwareModel.StartsWith("J") Or DumpedHardwareModel.StartsWith("P") Or DumpedHardwareModel.StartsWith("N") Then
            AddLineToKloaderConsole("[Info] The attached device's Hardware model is " + """" + DumpedHardwareModel + """")
            If Not iBSSHardwareModel = DumpedHardwareModel And Not iBSSHardwareModel = DumpedHardwareModel.ToLower Then
                Dim choice As Integer = MessageBox.Show("The given iBSS file has been made for " + iBSSHardwareModel + ". Your device's Hardware model (" + DumpedHardwareModel + ") mismatch! Do you want to proceed anyway?", "HardwareModel mismatch", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If choice = DialogResult.No Then
                    Exit Sub
                End If
            End If
        Else
            AddLineToKloaderConsole("[Info] Beehind wasn't able to dump devices informations... Continuing anyway.")
        End If

        If (IPTextBox.Text).Trim = "" Then
            AddLineToKloaderConsole("[Info] Starting SSH over usb... It will take several seconds")
            SSH_Over_USB("22", "22")
            Dim SSHSessionOptions As New SessionOptions
            With SSHSessionOptions
                .Protocol = Protocol.Sftp
                .HostName = "127.0.0.1"
                .UserName = "root"
                .Password = "alpine"
                .PortNumber = "22"
                .GiveUpSecurityAndAcceptAnySshHostKey = True
            End With
            Using SSHSession As Session = New Session
                SSHSession.DisableVersionCheck = True
                SSHSession.ExecutablePath = tempdir + "\WinSCP.exe"
                SSHSession.Open(SSHSessionOptions)
                Dim SSHTransferOptions As New TransferOptions
                SSHTransferOptions.TransferMode = TransferMode.Binary
                Dim SSHTransferResult As TransferOperationResult
                FileCopy(tempdir + "\kloader", tempdir + "\kloader.totransfer")
                SSHTransferResult = SSHSession.PutFiles(tempdir + "\kloader.totransfer", "/usr/bin/kloader", True, SSHTransferOptions)
                FileCopy(iBSSPathTextBox.Text, iBSSPathTextBox.Text + ".totransfer")
                SSHTransferResult = SSHSession.PutFiles(iBSSPathTextBox.Text + ".totransfer", "/var/ibss", True, SSHTransferOptions)
                SSHSession.ExecuteCommand("chmod 755 /usr/bin/kloader; chmod 777 /var/ibss; kloader /var/ibss")
                SSHSession.Close()
            End Using
        Else
            AddLineToKloaderConsole("[Info] Starting SSH over Wi-Fi... It will take several seconds")
            WiFiSSHBG.RunWorkerAsync()
            Do Until IsUserlandConnected() = False
                Delay(1)
            Loop
        End If
        AddLineToKloaderConsole("[Info] Event: Device disconnected.")
        If IPTextBox.Text = "" Then
            AddLineToKloaderConsole("[Info] Stopping SSH over usb.")
            End_SSH_Over_USB()
        End If

        'checking for kdfu mode
        Dim tensec As Integer = 0
        Do Until tensec = 10
            If IsDFUConnected() = True Then
                AddLineToKloaderConsole("[Info] Event: New DFU Mode device connected.")
                tensec = 10
            ElseIf IsDFUConnected() = False Then
                AddLineToKloaderConsole("[!] Waiting for Soft DFU Mode")
                Delay(1)
                tensec = tensec + 1
            End If
        Loop
        tensec = 0
        If IsDFUConnected() = False Then
            MessageBox.Show("After 10 seconds, no DFU Devices have been recognized. Don't worry, sometimes you just need to un-plug and plug it back in. Now make sure it's connected to the PC and unplug/replug it, then press OK", "No DFU Mode detected",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Do Until tensec = 10
                If IsDFUConnected() = True Then
                    tensec = 10
                    AddLineToKloaderConsole("[Info] Event: New DFU Mode device connected.")
                ElseIf IsDFUConnected() = False Then
                    AddLineToKloaderConsole("[!] Waiting for Soft DFU Mode")
                    Delay(1)
                    tensec = tensec + 1
                End If
            Loop
            If IsDFUConnected() = False Then
                MessageBox.Show("After 20 seconds, no DFU Devices have been recognized. Try to reboot in normal mode by unplugging it from the Computer and by pressing Home + Power button until the Apple Boot Logo shows up. Once you'll be in normal mode, try to Bootstrap iBSS again.", "No DFU Mode detected",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning)
                tensec = 0
                Exit Sub
            End If
        End If
        tensec = 0
        MessageBox.Show("Beehind has detected a new Apple device in DFU Mode, now press OK to be redirected at the Restore part of Beehind", "Device has been pwned!",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information)
        Restore.MdiParent = Form1
        Me.Close()
        idevicerestoreGUI.MdiParent = Form1
        idevicerestoreGUI.Show()
        Exit Sub
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        iBSSFIleDialog.FileName = ""
        iBSSFIleDialog.InitialDirectory = GetFolderPath(SpecialFolder.DesktopDirectory)
        iBSSFIleDialog.Filter = "Decrypted iBSS IMG3|*.img3;*.dfu; *.*;"
        If iBSSFIleDialog.ShowDialog = DialogResult.Abort Then
            Exit Sub
        End If

        Dim iBSSFileInfo As New FileInfo(iBSSFIleDialog.FileName)
        Dim iBSSFileSize As Long = iBSSFileInfo.Length
        If iBSSFileSize > 1000000 Then
            MessageBox.Show("Your file is size (" + Convert.ToInt32(iBSSFileSize / 1000000).ToString + " MB) is too big. It can't be iBSS!", "Too BIG!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Else
            iBSS = File.ReadAllText(iBSSFIleDialog.FileName)
            If Not iBSS.StartsWith("3gmI") Then
                MessageBox.Show("The provided IMG3 file is NOT valid! Please, select a valid patched iBSS's IMG3 and retry", "Not an IMG3 File!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Else
                If Not iBSS.Contains("ssbiEPYT") Then
                    Dim result As Integer = MessageBox.Show("The provided file is an IMG3, but it doesn't seem to contain an iBSS image. Perhaps you're an expert user, do you really want to continue?", "Wrong IMG3 Container?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If result = DialogResult.No Then
                        Exit Sub
                    End If
                Else
                    If Not iBSS.Contains("iBSS for") Then
                        MessageBox.Show("Refusing to submit this iBSS since it seems encrypted. Kloader only accepts decrypted IMG3 files.", "Object not found in header", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                End If
            End If
        End If
        MessageBox.Show("The iBSS you provided looks valid :)", "Valid iBSS!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        iBSSPathTextBox.Text = iBSSFIleDialog.FileName
        AddLineToKloaderConsole("[!] New entry: '" + iBSSPathTextBox.Text + "'")
    End Sub

    Private Sub WiFiSSHBG_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles WiFiSSHBG.DoWork
        Dim SSHSessionOptions As New SessionOptions
        With SSHSessionOptions
            .Protocol = Protocol.Sftp
            If IsIpValid(IPTextBox.Text) = True Then
                .HostName = IPTextBox.Text
            Else
                MessageBox.Show("The IP Address you've entered is NOT valid! Enter your device's Wi-Fi IP Address or leave that box blank to try autoconnect", "Invalid IP Address", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            .UserName = "root"
            .Password = "alpine"
            .PortNumber = "22"
            .GiveUpSecurityAndAcceptAnySshHostKey = True
        End With
        Using SSHSession As Session = New Session
            SSHSession.DisableVersionCheck = True
            SSHSession.ExecutablePath = tempdir + "\WinSCP.exe"
            SSHSession.Open(SSHSessionOptions)
            Dim SSHTransferOptions As New TransferOptions
            SSHTransferOptions.TransferMode = TransferMode.Binary
            Dim SSHTransferResult As TransferOperationResult
            FileCopy(tempdir + "\kloader", tempdir + "\kloader.totransfer")
            SSHTransferResult = SSHSession.PutFiles(tempdir + "\kloader.totransfer", "/usr/bin/kloader", True, SSHTransferOptions)
            FileCopy(iBSSPathTextBox.Text, iBSSPathTextBox.Text + ".totransfer")
            SSHTransferResult = SSHSession.PutFiles(iBSSPathTextBox.Text + ".totransfer", "/var/ibss", True, SSHTransferOptions)
            SSHSession.ExecuteCommand("chmod 755 /usr/bin/kloader; chmod 777 /var/ibss; kloader /var/ibss")
            SSHSession.Close()
        End Using
    End Sub

    Private Sub KloaderInjector_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class