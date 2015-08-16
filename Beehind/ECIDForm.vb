Imports Beehind.Common_Definitions
Imports System.IO
Imports Beehind.Common_Functions
Imports Beehind.SignIMG3
Imports Beehind.ECIDManagement
Imports Beehind.Processes
Imports System.Management

Public Class ECIDForm

    Private Sub ECIDConfirmBtn_Click(sender As Object, e As EventArgs) Handles ECIDConfirmBtn.Click
        'workingUI
        WorkBar.Visible = True
        Worklabel.Visible = True
        ECIDTextBox.Visible = False
        ECIDConfirmBtn.Visible = False
        ECIDIntroductionLabel.Visible = False

        ECIDParser(ECIDTextBox.Text.Replace(" ", ""))

        Dim RequestPlist As String = (File.ReadAllText(tempdir + "\ota-manifests\" + DeviceModel + "_" + iOS_Version + "_ota-tss-request.plist")).Replace("123456", CurrentDecimalECID)
        Dim RequestBuilder As StreamWriter
        RequestBuilder = System.IO.File.CreateText(tempdir + "\tss-request.plist")
        RequestBuilder.WriteLine(RequestPlist)
        RequestBuilder.Close()
        SendTSSRequest(tempdir + "\tss-request.plist", tempdir + "\tss-response.plist")
        XMLPath = tempdir + "\tss-response.plist"
        FillBlobsSet(iOSAsInteger)

        'writing out apticket
        If APTicket.Length <> 0 Then
            WriteBytesToFile(APTicket, tempdir + "\apticket.der")
        End If
        If XMLPath <> "" And IPSWPath <> "" Then
            MainView.MagicButton.Enabled = True
        End If
        Me.Close()
    End Sub

    Private Sub ECIDForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim deviceinfos As String = GetDeviceInfos()
        Dim DumpedECID As String = (deviceinfos.Substring(deviceinfos.IndexOf("UniqueChipID") + 13)).Substring(0, (deviceinfos.Substring(deviceinfos.IndexOf("UniqueChipID") + 13)).IndexOf(Environment.NewLine))
        If IsNumeric(DumpedECID) Then
            Dim QuestECID As Integer = MessageBox.Show("ECID Dumped: " + DumpedECID + ". Do you want to use it for this downgrade?", "Success!", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If QuestECID = DialogResult.Yes Then
                ECIDTextBox.Text = DumpedECID
                ECIDConfirmBtn.PerformClick()
            End If
        Else
            MessageBox.Show("An error has occurred during the ECID dump (" + deviceinfos + "). Make sure you have iTunes 12 or above installed", "Dump failed",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub DeviceChecker_Tick(sender As Object, e As EventArgs) Handles DeviceChecker.Tick
        If IsUserlandConnected() = True Then
            LinkLabel1.Text = "New Apple device found! Click here to get its ECID"
            LinkLabel1.Enabled = True
        Else
            LinkLabel1.Text = "Connect an iOS device and Beehind will automatically dump" + Environment.NewLine + "its ECID"
            LinkLabel1.Enabled = False
        End If
    End Sub
End Class