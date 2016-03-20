Imports Beehind.Common_Definitions
Imports System.IO
Imports Beehind.Common_Functions
Imports Beehind.SignIMG3
Imports Beehind.ECIDManagement
Imports Beehind.Processes
Imports System.Management
Imports Beehind.Form1
Imports System.Net


Public Class Save_SHSH

    Public Shared SHSHOutputDir As String = userdir + "\Desktop\beehind-shsh"


    Public Sub UpdateGUI()
        Type_var.Text = info_devicemodel + info_cellularmodel + " [" + info_product + " / " + info_hwmodel + "]"
        Version_var.Text = info_ios + " (" + info_build + ")"
        UDID_var.Text = info_udid
        ECID_var.Text = info_ecid
        itunesname_var.Text = info_itunesname
    End Sub

    Public Sub UpdateStatus(value As Integer, text As String)
        If value > SHSHProgressBar.Maximum Then
            value = SHSHProgressBar.Maximum
        End If
        SHSHProgressBar.Value = value
        idle.Text = (value).ToString + "% - " + text
        Delay(1)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        DeviceIcon.Image = (My.Resources.iphone5c_green)
    End Sub

    Public Sub ResetGUI()
        rawdeviceinfos = String.Empty
        info_ios = String.Empty
        info_build = String.Empty
        info_serialno = String.Empty
        info_ecid = String.Empty
        info_itunesname = String.Empty
        info_product = String.Empty
        info_hwmodel = String.Empty
        info_udid = String.Empty
        info_color = String.Empty
        info_64 = False

        'bb (unusued for now)
        info_bbgoldcertid = String.Empty
        info_bbsnum = String.Empty

        'ricavabili
        info_devicemodel = String.Empty
        info_cellularmodel = String.Empty

        Me.Type_var.Text = "n/a"
        Me.Version_var.Text = "n/a"
        Me.UDID_var.Text = "n/a"
        Me.ECID_var.Text = "n/a"
        Me.itunesname_var.Text = "Connect an iOS Device"

        'Me.DeviceIcon.Image.Dispose()
        'Me.CableIcon.Image.Dispose()
        Me.DeviceIcon.Image = Nothing
        Me.CableIcon.Image = Nothing
        Me.DeviceIcon.Location = New Point(2, 35)
        Me.CableIcon.Location = New Point(2, 269)

    End Sub

    Private Sub SaveSHSHButton_Click(sender As Object, e As EventArgs) Handles SaveSHSHButton.Click

        SaveSHSHButton.Enabled = False

        If SavingPath.Text <> "" Then
            SHSHOutputDir = SavingPath.Text
        End If

        Dim bb As Boolean = False
        Dim apticket As Boolean = False

        Dim WebClient1 As New Net.WebClient

        ' Thanks @icj for this awesome json!
        UpdateStatus(5, "Getting signatures map...")
        Delay(1)
        WebClient1.DownloadFile("https://api.ipsw.me/v2.1/firmwares.json", hshsdir + "\fws.json")

        ' I know there are better ways to read a Json file in vb :/

        Dim Json() As String = IO.File.ReadAllLines(hshsdir + "\fws.json")

        Dim Jsonlines As Integer = Json.Length
        Dim position As Integer = 0
        Dim buildoffset As Integer = 0
        Dim versoffset As Integer = 0
        Dim urisoffset As Integer = 0
        Dim rightdevice As Boolean = False

        Dim signedbuilds As String() = {}
        Dim signedios As String() = {}
        Dim signeduris As String() = {}
        Dim signedcount As Integer = -1

        Dim open = 0
        Dim closed = 0

        Do While position <> Jsonlines

            If Json(position).Contains(info_product) Then
                rightdevice = True
            End If

            If Json(position).Contains("{") And rightdevice = True Then
                open = open + 1
            End If

            If Json(position).Contains("}") And rightdevice = True Then
                closed = closed + 1
            End If

            If open = closed And open <> 0 Then
                rightdevice = False
            End If

            If Json(position).Contains("""" + "version" + """" + ": ") And rightdevice = True Then
                versoffset = position
            End If

            If Json(position).Contains("""" + "buildid" + """" + ": ") And rightdevice = True Then
                buildoffset = position
            End If

            If Json(position).Contains("""" + "url" + """" + ": ") And rightdevice = True Then
                urisoffset = position
            End If

            If Json(position).Contains("true") And rightdevice = True Then
                signedcount = signedcount + 1

                Dim b = Json(versoffset).Replace("""" + "version" + """" + ": " + """", "").Replace("""" + ",", "").Trim()
                Dim a = Json(buildoffset).Replace("""" + "buildid" + """" + ": " + """", "").Replace("""" + ",", "").Trim()
                Dim c = Json(urisoffset).Replace("""" + "url" + """" + ": " + """", "").Replace("""" + ",", "").Trim()

                ReDim Preserve signedbuilds(signedcount)
                signedbuilds(signedcount) = a

                ReDim Preserve signedios(signedcount)
                signedios(signedcount) = b

                ReDim Preserve signeduris(signedcount)
                signeduris(signedcount) = c

            End If

            position = position + 1
        Loop

        Delete(False, hshsdir + "\fws.json")

        If FetchCydiaBlobsCheckBox.Checked = True Then
            ' phoning saurik's TSS...
            Dim saurik As String = String.Empty
            Using client As New WebClient
                saurik = client.DownloadString("http://cydia.saurik.com/tss@home/api/check/" + info_ecid).Replace("[", "").Replace("]", "").Replace("{", "").Replace("}", "")


                Dim cydiashsh As String() = saurik.Split(New String() {","}, StringSplitOptions.RemoveEmptyEntries)
                For Each blob In cydiashsh

                    If blob.Contains("""" + "firmware" + """" + ": ") Then
                        ReDim Preserve signedios(signedios.Length)
                        signedios(signedios.Length - 1) = blob.Replace("""" + "firmware" + """" + ": ", "").Replace("""", "").Trim()
                    End If


                    If blob.Contains("""" + "build" + """" + ": ") Then
                        ReDim Preserve signedbuilds(signedbuilds.Length)
                        signedbuilds(signedbuilds.Length - 1) = blob.Replace("""" + "build" + """" + ": ", "").Replace("""", "").Trim() + "cydia"

                        ReDim Preserve signeduris(signeduris.Length)
                        signeduris(signeduris.Length - 1) = client.DownloadString("http://api.ipsw.me/v2/" + info_product + "/" + signedbuilds(signedbuilds.Length - 1).Replace("cydia", "") + "/url")

                    End If
                Next
            End Using
        End If

        For Each build In signedbuilds
            Dim ios = signedios(Array.IndexOf(signedbuilds, build))
            Dim url = signeduris(Array.IndexOf(signedbuilds, build))

            If build.Contains("cydia") Then
                hostshandler("add", "74.208.10.249", "gs.apple.com")
                build = build.Replace("cydia", "")
            Else
                hostshandler("remove", "74.208.10.249", "gs.apple.com")
            End If

            UpdateStatus(SHSHProgressBar.Value + ((SHSHProgressBar.Maximum - 5) / (5 * signedbuilds.Length)), "Getting BuildManifest for iOS " + ios + ", " + build + "...")
            Delay(1)

            partialzip(url, "BuildManifest.plist", hshsdir + "\" + info_product + "_" + build + "_" + "BuildManifest.plist")

            If ExistsInBuildManifest(hshsdir + "\" + info_product + "_" + build + "_" + "BuildManifest.plist", "BasebandFirmware", "key") Then
                bb = True
            Else
                bb = False
            End If

            If Not info_product = "iPhone1,1" Or info_product = "iPhone1,2" Or info_product = "iPhone1,1" Or info_product = "iPod1,1" Or info_product = "iPod2,1" Then
                apticket = True
            Else
                apticket = False
            End If
            UpdateStatus(SHSHProgressBar.Value + ((SHSHProgressBar.Maximum - 5) / (5 * signedbuilds.Length)), "Writing request for iOS " + ios + ", " + build + "...")
            Delay(1)
            WriteTSSRequest(hshsdir + "\" + info_product + "_" + build + "_" + "BuildManifest.plist", hshsdir + "\" + info_product + "_" + build + "_" + "tss-request.plist", info_ecid, apticket, bb, info_64, GetDeviceInfos(True, "ApNonce"), "", GetDeviceInfos(True, "BasebandSerialNumber"), GetDeviceInfos(True, "BasebandCertId"), GetDeviceInfos(True, "SEPNonce"))

            UpdateStatus(SHSHProgressBar.Value + ((SHSHProgressBar.Maximum - 5) / (5 * signedbuilds.Length)), "Submitting magic to @TSS...")

            SendTSSRequest(hshsdir + "\" + info_product + "_" + build + "_" + "tss-request.plist", hshsdir + "\" + info_product + "_" + build + "_" + "tss-response.plist")

            If Not File.Exists(hshsdir + "\" + info_product + "_" + build + "_" + "tss-response.plist") Then
                MessageBox.Show("SHSH for this iOS version CAN be saved, but Beehind wasn't able to do that. Please, report this bug to blackgeektutorial@gmail.com!", "An error occurred", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            UpdateStatus(SHSHProgressBar.Value + ((SHSHProgressBar.Maximum - 5) / (5 * signedbuilds.Length)), "Compressing SHSH (bplist format)...")
            Delay(1)
            If Not File.Exists(SHSHOutputDir + "\" + info_ecid + "_" + info_product + "_" + ios + "_" + build + ".shsh") Then
                XmlToBplist(hshsdir + "\" + info_product + "_" + build + "_" + "tss-response.plist", SHSHOutputDir + "\" + info_ecid + "_" + info_product + "_" + ios + "_" + build + ".shsh")
            End If
            Delete(False, hshsdir + "\" + info_product + "_" + build + "_" + "BuildManifest.plist")
            Delete(False, hshsdir + "\" + info_product + "_" + build + "_" + "tss-request.plist")
            Delete(False, hshsdir + "\" + info_product + "_" + build + "_" + "tss-response.plist")

            UpdateStatus(SHSHProgressBar.Value + ((SHSHProgressBar.Maximum - 5) / (5 * signedbuilds.Length)), "Done!")
            Delay(1)
        Next
        hostshandler("remove", "74.208.10.249", "gs.apple.com")
        SaveSHSHButton.Enabled = True
    End Sub

    Private Sub Save_SHSH_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CreateDirectory(userdir + "\Desktop", "\beehind-shsh", False)

        DeviceConnected = True
        GetInfosFromConnectedDevice()
        UpdateGUI()
    End Sub

    Private Sub ChangeSavingPathBtn_Click(sender As Object, e As EventArgs) Handles ChangeSavingPathBtn.Click
        If FolderBrowserDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            SavingPath.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub DeviceChecker_Tick(sender As Object, e As EventArgs) Handles DeviceChecker.Tick
        If IsUserlandConnected(False) = True Then
            If DeviceConnected = False Then
                DeviceConnected = True
                GetInfosFromConnectedDevice()
                UpdateGUI()
            End If
        Else
            DeviceConnected = False
            ResetGUI()
        End If
    End Sub

    Private Sub ECID_var_Click(sender As Object, e As EventArgs) Handles ECID_var.Click
        Clipboard.SetText(ECID_var.Text)
    End Sub
End Class