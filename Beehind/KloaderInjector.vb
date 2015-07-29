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

    Public Shared Sub AddLineToRestoreConsole(Text As String)
        KloaderInjector.SSHConsole.AppendText(Environment.NewLine + Text)
        KloaderInjector.SSHConsole.SelectionStart = Restore.RawRestoreConsole.TextLength
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
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles PwnDFUButton.Click
        Dim iBSS As String = File.ReadAllText(iBSSPathTextBox.Text)
        If Not iBSS.StartsWith("3gmI") Then
            MessageBox.Show("The provided IMG3 file is NOT valid! Please, select a valid patched iBSS's IMG3 and retry", "Not an IMG3 File!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Else
            If Not iBSS.Contains("ssbiEPYT") Then
                Dim result As Integer = MessageBox.Show("The provided file is an IMG3, but it doesn't seem to contain an iBSS image. Perhaps you're an expert user, do you really want to continue?", "Wrong IMG3 Container?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If result = DialogResult.No Then
                    Exit Sub
                End If
            End If
        End If

        SSHBackgroundWorker.RunWorkerAsync()
        Do Until IsUserlandConnected() = False
            Delay(1)
        Loop
        AddLineToRestoreConsole("[Info] Event: Device disconnected.")

        If IPTextBox.Text = "" Then
            AddLineToRestoreConsole("[Info] Stopping SSH over usb.")
            End_SSH_Over_USB()
        End If

        Dim tensec As Integer = 0
        Do Until tensec = 10
            If IsDFUConnected() = True Then
                AddLineToRestoreConsole("[Info] Event: New DFU Mode device connected.")
                tensec = 10

            ElseIf IsDFUConnected() = False Then
                AddLineToRestoreConsole("[!] Waiting for Soft DFU Mode")
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
                    AddLineToRestoreConsole("[Info] Event: New DFU Mode device connected.")
                ElseIf IsDFUConnected() = False Then
                    AddLineToRestoreConsole("[!] Waiting for Soft DFU Mode")
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
        'Restore.Show()
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
        iBSSPathTextBox.Text = iBSSFIleDialog.FileName
        AddLineToRestoreConsole("[!] New entry: '" + iBSSPathTextBox.Text + "'")
    End Sub

    Private Sub SSHBackgroundWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles SSHBackgroundWorker.DoWork
        Dim SSHSessionOptions As New SessionOptions
        With SSHSessionOptions
            .Protocol = Protocol.Sftp
            If IPTextBox.Text <> "" Then
                If IsIpValid(IPTextBox.Text) = True Then
                    .HostName = IPTextBox.Text
                Else
                    MessageBox.Show("The IP Address you've entered is NOT valid! Enter your device's Wi-Fi IP Address or live that form blank to try to autoconnect", "Invalid IP Address", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            Else
                .HostName = "127.0.0.1"
            End If
            .UserName = "root"
            .Password = "alpine"
            .PortNumber = "22"
            .GiveUpSecurityAndAcceptAnySshHostKey = True
        End With
        If IPTextBox.Text = "" Then
            AddLineToRestoreConsole("[Info] Starting SSH over usb... It will take some seconds")
            SSH_Over_USB("22", "22")
        Else
            AddLineToRestoreConsole("[Info] Starting SSH over Wi-Fi... It will take some seconds")
        End If

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
            SSHSession.ExecuteCommand("chmod 755 /usr/bin/kloader; chmod 777 /var/ibss")
            SSHSession.ExecuteCommand("sleep 2 && kloader /var/ibss")
            SSHSession.Close()
        End Using
    End Sub
End Class