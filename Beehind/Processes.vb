Imports Beehind.Common_Definitions
Imports Beehind.Common_Functions
Imports Beehind.IPSW_URLs
Imports Beehind.keys
Imports System.Management
Imports Beehind.idevicerestoreGUI
Imports System.IO

Public Class Processes

    Public Shared Sub xpwntool(infile As String, outfile As String, IV As String, Key As String, decrypt As Boolean, Optional template As String = "")
        Dim xpwntool_p As New Process()
        Try
            Dim xpwnargs As String

            If IV <> "" And Key <> "" Then
                xpwnargs = """" + infile + """" + " " + """" + outfile + """" + " -iv " + IV + " -k " + Key
            Else
                xpwnargs = """" + infile + """" + " " + """" + outfile + """"
            End If

            If decrypt = True Then
                xpwnargs = xpwnargs + " -decrypt"
            End If
            If template <> "" Then
                xpwnargs = xpwnargs + " -t " + """" + template + """"
            End If
            xpwntool_p.StartInfo.UseShellExecute = False
            xpwntool_p.StartInfo.FileName = tempdir + "\xpwntool.exe"
            xpwntool_p.StartInfo.CreateNoWindow = True
            xpwntool_p.StartInfo.Arguments = xpwnargs
            xpwntool_p.Start()
        Catch ex As Exception
        End Try
        Do Until xpwntool_p.HasExited
            Delay(1)
        Loop
    End Sub

    Public Shared Sub imagetool(extract As Boolean, infile As String, outfile As String, IV As String, K As String, Optional template As String = "")
        Dim ivk As String = String.Empty
        If IV <> "" And K <> "" Then
            ivk = " " + IV + " " + K
        End If
        Dim imagetool_p As New Process()
        Try
            imagetool_p.StartInfo.UseShellExecute = False
            imagetool_p.StartInfo.FileName = tempdir + "\imagetool.exe"
            imagetool_p.StartInfo.CreateNoWindow = True
            If extract = True Then
                imagetool_p.StartInfo.Arguments = "extract " + """" + infile + """" + " " + """" + outfile + """" + ivk
            ElseIf extract = False Then
                imagetool_p.StartInfo.Arguments = "inject " + """" + infile + """" + " " + """" + outfile + """" + " " + """" + template + """" + ivk
            End If
            'MessageBox.Show(imagetool_p.StartInfo.Arguments)
            imagetool_p.Start()
        Catch ex As Exception
        End Try
        Do Until imagetool_p.HasExited
            Delay(1)
        Loop
    End Sub

    Public Shared Sub itunnel_mux(args As String)
        Dim itunnel_mux_p As New Process()
        Try
            itunnel_mux_p.StartInfo.UseShellExecute = False
            itunnel_mux_p.StartInfo.FileName = tempdir + "\itunnel_mux.exe"
            itunnel_mux_p.StartInfo.Arguments = args
            itunnel_mux_p.StartInfo.CreateNoWindow = True
            itunnel_mux_p.Start()
        Catch ex As Exception
        End Try
    End Sub

    Public Shared Sub hostshandler(mode As String, ip As String, hostname As String)
        Dim sr As New StreamReader(Environment.SystemDirectory & "\drivers\etc\hosts")
        Dim hosts As String = sr.ReadToEnd()
        sr.Close()

        If mode = "add" And hosts.Contains(ip + " " + hostname) Then
            Exit Sub
        End If

        If mode = "remove" And hosts.Contains(ip + " " + hostname) = False Then
            Exit Sub
        End If

        Dim hostshandler_p As New Process()
        Try
            hostshandler_p.StartInfo.UseShellExecute = True
            hostshandler_p.StartInfo.FileName = tempdir + "\hostshandler.exe"
            hostshandler_p.StartInfo.Arguments = mode + " " + """" + ip + """" + " " + """" + hostname + """"
            hostshandler_p.StartInfo.CreateNoWindow = True
            hostshandler_p.StartInfo.Verb = "runas"
            hostshandler_p.Start()
        Catch ex As Exception
        End Try
        Do Until hostshandler_p.HasExited
            Delay(1)
        Loop
        Delay(1)
    End Sub


    Public Shared Sub partialzip(ZipUrl As String, ZipPath As String, Outfile As String)
REDO:
        Dim partialzip_p As New Process()
        Try
            partialzip_p.StartInfo.UseShellExecute = False
            partialzip_p.StartInfo.FileName = tempdir + "\pzip.exe"
            partialzip_p.StartInfo.Arguments = """" + ZipUrl + """" + " " + """" + ZipPath + """" + " " + """" + Outfile + """"
            partialzip_p.StartInfo.CreateNoWindow = True
            partialzip_p.Start()
        Catch ex As Exception
        End Try

        Dim timeout = 0
        Dim looped As Boolean = False

        Do Until IO.File.Exists(Outfile)
            Delay(1)
        Loop
        Dim newfile As New FileInfo(Outfile)
        Dim size As Long = newfile.Length

        Do Until partialzip_p.HasExited

            If timeout = 5 And size <= 0 Then
                'dunno why, sometimes my remote zip file downloader loops :(
                Kill({"pzip"})
                looped = True
            End If

            Delay(1)
            timeout = timeout + 1
        Loop
        If looped = True Then
            GoTo REDO
        End If
    End Sub

    Public Shared Sub unrar(RARFile As String, outdir As String)

        Dim unrar_p As New Process()
        Try
            unrar_p.StartInfo.UseShellExecute = False
            unrar_p.StartInfo.FileName = tempdir + "\unrar.exe"
            unrar_p.StartInfo.Arguments = "x " + """" + RARFile + """" + " " + """" + outdir + """"
            unrar_p.StartInfo.CreateNoWindow = True
            unrar_p.Start()
        Catch ex As Exception
        End Try
        Do Until unrar_p.HasExited
            Delay(1)
        Loop
    End Sub

    Public Shared Sub idevicerestore(args As String, BeehindMode As Boolean)
        Dim idevicerestore_p As New Process()
        Try
            'idevicerestore_p.StartInfo.UseShellExecute = False
            If BeehindMode = True Then
                idevicerestore_p.StartInfo.FileName = tempdir + "\libimobiledevice\idevicerestore-w.exe"
            Else
                idevicerestore_p.StartInfo.FileName = tempdir + "\libimobiledevice\idevicerestore.exe"
            End If
            idevicerestore_p.StartInfo.WorkingDirectory = tempdir + "\Restore\"
            idevicerestore_p.StartInfo.Arguments = args
            'idevicerestore_p.StartInfo.CreateNoWindow = True
            idevicerestore_p.Start()
        Catch ex As Exception
        End Try
        Do Until idevicerestore_p.HasExited
            Delay(1)
        Loop
    End Sub

    Public Shared Function GetDeviceInfos(QueryValue As Boolean, Optional ByVal Value As String = "")
        Dim ideviceinfo_p As New Process()
        Try
            ideviceinfo_p.StartInfo.UseShellExecute = False
            ideviceinfo_p.StartInfo.FileName = tempdir + "\libimobiledevice\ideviceinfo.exe"
            If QueryValue = True Then
                ideviceinfo_p.StartInfo.Arguments = "-k " + """" + Value + """"
            End If
            ideviceinfo_p.StartInfo.CreateNoWindow = True
            ideviceinfo_p.StartInfo.RedirectStandardOutput = True
            ideviceinfo_p.StartInfo.RedirectStandardError = True
            ideviceinfo_p.Start()

        Catch ex As Exception
        End Try

        Dim stdout As String = String.Empty
        Dim stderr As String = String.Empty
        Dim infos As String = String.Empty

        Using oStreamReader As System.IO.StreamReader = ideviceinfo_p.StandardOutput
            stdout = oStreamReader.ReadToEnd()
        End Using

        Using oStreamReader As System.IO.StreamReader = ideviceinfo_p.StandardError
            stderr = oStreamReader.ReadToEnd()
        End Using

        infos = stdout + stderr
        Return infos.Trim()
    End Function

    Public Shared Sub opensn0w(args As String)
        Dim opensn0w_p As New Process()
        Try
            opensn0w_p.StartInfo.UseShellExecute = False
            opensn0w_p.StartInfo.FileName = tempdir + "\opensn0w_cli\opensn0w.exe"
            opensn0w_p.StartInfo.Arguments = args
            opensn0w_p.StartInfo.CreateNoWindow = True
            opensn0w_p.Start()
        Catch ex As Exception
        End Try
        Do Until opensn0w_p.HasExited
            Delay(1)
        Loop
    End Sub

    Public Shared Sub SSH_Over_USB(iport As String, lport As String)
        itunnel_mux("--iport " + iport + " --lport " + lport)
    End Sub

    Public Shared Sub End_SSH_Over_USB()
        Kill({"itunnel_mux"})
    End Sub

    Public Shared Sub hfsplus(args As String)
        Dim hfsplus_p As New Process()
        Try
            hfsplus_p.StartInfo.UseShellExecute = False
            hfsplus_p.StartInfo.FileName = tempdir + "\hfsplus.exe"
            hfsplus_p.StartInfo.Arguments = args
            hfsplus_p.StartInfo.CreateNoWindow = True
            hfsplus_p.Start()
        Catch ex As Exception
        End Try
        Do Until hfsplus_p.HasExited
            Delay(1)
        Loop
    End Sub

    Public Shared Sub bspatch(infile As String, outfile As String, patchfile As String)
        Dim bspatch_p As New Process()
        Try
            bspatch_p.StartInfo.UseShellExecute = False
            bspatch_p.StartInfo.FileName = tempdir + "\diff.exe"
            bspatch_p.StartInfo.Arguments = """" + infile + """" + " " + """" + outfile + """" + " " + """" + patchfile + """"
            bspatch_p.StartInfo.CreateNoWindow = True
            bspatch_p.Start()
        Catch ex As Exception
        End Try
        Do Until bspatch_p.HasExited
            Delay(1)
        Loop
    End Sub

    Public Shared Sub InfoZipUnzip(args As String)
        Dim InfoZipUnzip_p As New Process()
        Try
            InfoZipUnzip_p.StartInfo.UseShellExecute = False
            InfoZipUnzip_p.StartInfo.FileName = tempdir + "\unzip.exe"
            InfoZipUnzip_p.StartInfo.Arguments = args
            InfoZipUnzip_p.StartInfo.CreateNoWindow = True
            InfoZipUnzip_p.Start()
        Catch ex As Exception
        End Try
        Do Until InfoZipUnzip_p.HasExited
            Delay(1)
        Loop
    End Sub

    Public Shared Sub InfoZipZip(args As String, workingdir As String)
        Dim InfoZipZip_p As New Process()
        Try
            InfoZipZip_p.StartInfo.UseShellExecute = False
            InfoZipZip_p.StartInfo.FileName = tempdir + "\zip.exe"
            InfoZipZip_p.StartInfo.Arguments = args
            InfoZipZip_p.StartInfo.CreateNoWindow = True
            InfoZipZip_p.StartInfo.WorkingDirectory = workingdir
            InfoZipZip_p.Start()
        Catch ex As Exception
        End Try
        Do Until InfoZipZip_p.HasExited
            Delay(1)
        Loop
    End Sub

    Public Shared Sub dmg(args As String)
        Dim dmg_p As New Process()
        Try
            dmg_p.StartInfo.UseShellExecute = False
            dmg_p.StartInfo.FileName = tempdir + "\dmg.exe"
            dmg_p.StartInfo.Arguments = args
            dmg_p.StartInfo.CreateNoWindow = True
            dmg_p.Start()
        Catch ex As Exception
        End Try
        Do Until dmg_p.HasExited
            Delay(1)
        Loop
    End Sub

    Public Shared Sub bplist2xml(args As String)
        Dim bplist2xml_p As New Process()
        Try
            bplist2xml_p.StartInfo.UseShellExecute = False
            bplist2xml_p.StartInfo.FileName = tempdir + "\bplist2xml.exe"
            bplist2xml_p.StartInfo.Arguments = args
            bplist2xml_p.StartInfo.CreateNoWindow = True
            bplist2xml_p.Start()
        Catch ex As Exception
        End Try
        Do Until bplist2xml_p.HasExited
            Delay(1)
        Loop
    End Sub

    Public Shared Sub xml2bplist(args As String)
        Dim xml2bplist_p As New Process()
        Try
            xml2bplist_p.StartInfo.UseShellExecute = False
            xml2bplist_p.StartInfo.FileName = tempdir + "\xml2bplist.exe"
            xml2bplist_p.StartInfo.Arguments = args
            xml2bplist_p.StartInfo.CreateNoWindow = True
            xml2bplist_p.Start()
        Catch ex As Exception
        End Try
        Do Until xml2bplist_p.HasExited
            Delay(1)
        Loop
    End Sub
End Class
