Imports Beehind.Common_Definitions
Imports Beehind.Processes
Imports Beehind.Common_Functions


Public Class AddUntethers

    Public Shared Sub AddUntetherPayload(rootfsEXT)
        If iOS_Version = "5.0" Or iOS_Version = "5.0.1" Then
            AddCoronaPayload(rootfsEXT)
        ElseIf iOS_Version = "5.1" Or iOS_Version = "5.1.1" Then
            AddRockyRacoonPayload(rootfsEXT)
        ElseIf iOS_Version = "6.0" Or iOS_Version = "6.0.1" Or iOS_Version = "6.0.2" Or iOS_Version = "6.1" Or iOS_Version = "6.1.1" Or iOS_Version = "6.1.2" Then
            AddEvasi0n6Payload(rootfsEXT)
        ElseIf iOS_Version = "6.1.3" Or iOS_Version = "6.1.4" Or iOS_Version = "6.1.5" Or iOS_Version = "6.1.6" Then
            Addp0sixspwnPayload(rootfsEXT)
        ElseIf iOS_Version = "7.0" Or iOS_Version = "7.0.1" Or iOS_Version = "7.0.2" Or iOS_Version = "7.0.3" Or iOS_Version = "7.0.4" Or iOS_Version = "7.0.5" Or iOS_Version = "7.0.6" Then
            AddEvasi0n7Payload(rootfsEXT)
        ElseIf iOS_Version = "7.1" Or iOS_Version = "7.1.1" Or iOS_Version = "7.1.2" Then
            AddPangu7Payload(rootfsEXT)
        ElseIf iOS_Version = "8.0" Or iOS_Version = "8.0.1" Or iOS_Version = "8.0.2" Or iOS_Version = "8.1" Or iOS_Version = "8.1.1" Or iOS_Version = "8.1.2 Then" Then
            AddTaiGPayload(rootfsEXT)
        ElseIf iOS_Version = "8.1.3" Or iOS_Version = "8.2" Or iOS_Version = "8.3" Or iOS_Version = "8.4" Then
            AddTaiG2Payload(rootfsEXT)
        ElseIf iOS_Version = "8.4.1" Then
            AddYaluPayload(rootfsEXT)
        ElseIf iOS_Version = "9.0" Or iOS_Version = "9.0.1" Or iOS_Version = "9.0.2" Then
            AddPangu9Payload(rootfsEXT)
        End If
    End Sub

    Public Shared Sub AddCoronaPayload(rootfsEXT)

        MainView.ProgressLabel.Text = "55% - Adding Chronic Dev-Team's Cprona Untether to the Custom Firmware..."
        hfsplus("""" + rootfsEXT + """" + " untar " + """" + tempdir + "\payloads\com.chronic-dev.greenpois0n.corona-untether.tar" + """" + " " + """" + "/" + """")
        hfsplus("""" + rootfsEXT + """" + " extract " + """" + "/usr/sbin/racoon" + """" + " " + """" + tempdir + "\racoon" + """")
        hfsplus("""" + rootfsEXT + """" + " add " + """" + tempdir + "\racoon" + """" + " " + """" + "/usr/sbin/corona" + """")
        Delete(False, tempdir + "\racoon")
        hfsplus("""" + rootfsEXT + """" + " chmod 100555 " + """" + "/usr/sbin/corona" + """")
        hfsplus("""" + rootfsEXT + """" + " mv " + """" + "/tmp/corona_install/" + iOS_Build + "/" + DeviceModel + "/payload" + """" + " " + """" + "/usr/share/corona/payload" + """")
        hfsplus("""" + rootfsEXT + """" + " mv " + """" + "/tmp/corona_install/" + iOS_Build + "/" + DeviceModel + "/payload-vars" + """" + " " + """" + "/usr/share/corona/payload-vars" + """")
        hfsplus("""" + rootfsEXT + """" + " mv " + """" + "/tmp/corona_install/" + iOS_Build + "/" + DeviceModel + "/racoon-exploit.conf" + """" + " " + """" + "/usr/share/corona/racoon-exploit.conf" + """")
        hfsplus("""" + rootfsEXT + """" + " mv " + """" + "/tmp/corona_install/" + iOS_Build + "/" + DeviceModel + "/vnimage.overflow" + """" + " " + """" + "/usr/share/corona/vnimage.overflow" + """")
        hfsplus("""" + rootfsEXT + """" + " mv " + """" + "/tmp/corona_install/" + iOS_Build + "/" + DeviceModel + "/vnimage.payload" + """" + " " + """" + "/usr/share/corona/vnimage.payload" + """")
        hfsplus("""" + rootfsEXT + """" + " rm " + """" + "/tmp/corona_install" + """")
        hfsplus("""" + rootfsEXT + """" + " rm " + """" + "/etc/fstab" + """")
        hfsplus("""" + rootfsEXT + """" + " add " + """" + tempdir + "\payloads\fstab" + """" + " " + """" + "/etc/fstab" + """")
        hfsplus("""" + rootfsEXT + """" + " chmod 100644 " + """" + "/etc/fstab" + """")
        hfsplus("""" + rootfsEXT + """" + " add " + """" + tempdir + "\payloads\corona_launchd.conf" + """" + " " + """" + "/etc/launchd.conf" + """")
        hfsplus("""" + rootfsEXT + """" + " chmod 100644 " + """" + "/etc/launchd.conf" + """")
    End Sub

    Public Shared Sub AddRockyRacoonPayload(rootfsEXT)
        MainView.ProgressLabel.Text = "55% - Adding Chronic Dev-Team's Rocky Racoon Untether to the Custom Firmware..."
        hfsplus("""" + rootfsEXT + """" + " untar " + """" + tempdir + "\payloads\com.chronic-dev.greenpois0n.corona-rocky-racoon-untether.tar" + """" + " " + """" + "/" + """")
        hfsplus("""" + rootfsEXT + """" + " rm " + """" + "/etc/fstab" + """")
        hfsplus("""" + rootfsEXT + """" + " add " + """" + tempdir + "\payloads\fstab" + """" + " " + """" + "/etc/fstab" + """")
        hfsplus("""" + rootfsEXT + """" + " chmod 100644 " + """" + "/etc/fstab" + """")
    End Sub

    Public Shared Sub AddEvasi0n6Payload(rootfsEXT)
        MainView.ProgressLabel.Text = "55% - Adding Evad3rs' evasi0n Untether to the Custom Firmware..."
        hfsplus("""" + rootfsEXT + """" + " untar " + """" + tempdir + "\payloads\evasi0n6-untether.tar" + """" + " " + """" + "/" + """")
    End Sub

    Public Shared Sub Addp0sixspwnPayload(rootfsEXT)
        MainView.ProgressLabel.Text = "55% - Adding iH8Sn0w's p0sixspwn Untether to the Custom Firmware..."
        hfsplus("""" + rootfsEXT + """" + " mkdir " + """" + "/private/var/untether" + """")
        hfsplus("""" + rootfsEXT + """" + " untar " + """" + tempdir + "\payloads\p0sixspwn-untether.tar" + """" + " " + """" + "/" + """")
    End Sub

    Public Shared Sub AddEvasi0n7Payload(rootfsEXT)
        MainView.ProgressLabel.Text = "55% - Adding Evad3rs' evasi0n7 Untether to the Custom Firmware..."
        hfsplus("""" + rootfsEXT + """" + " untar " + """" + tempdir + "\payloads\evasi0n7-untether.tar" + """" + " " + """" + "/" + """")
    End Sub

    Public Shared Sub AddPangu7Payload(rootfsEXT)
        MainView.ProgressLabel.Text = "55% - Adding PanguTeam's PanguAxe Untether to the Custom Firmware..."
        hfsplus("""" + rootfsEXT + """" + " untar " + """" + tempdir + "\payloads\io.panguaxe-untether.tar" + """" + " " + """" + "/" + """")
    End Sub

    Public Shared Sub AddPangu8Payload(rootfsEXT)
        MainView.ProgressLabel.Text = "55% - Adding PanguTeam's Pangu Xuanyuansword8 Untether to the Custom Firmware..."
        hfsplus("""" + rootfsEXT + """" + " untar " + """" + tempdir + "\payloads\io.xuanyuansword8-untether.tar" + """" + " " + """" + "/" + """")
    End Sub

    Public Shared Sub AddTaiGPayload(rootfsEXT)

    End Sub

    Public Shared Sub AddTaiG2Payload(rootfsEXT)
        MainView.ProgressLabel.Text = "55% - Adding TaiG's Untether (8.1.3 -> 8.4) to the Custom Firmware..."
        hfsplus("""" + rootfsEXT + """" + " untar " + """" + tempdir + "\payloads\taiguntether83x.tar" + """" + " " + """" + "/" + """")
    End Sub

    Public Shared Sub AddYaluPayload(rootfsEXT)

    End Sub

    Public Shared Sub AddPangu9Payload(rootfsEXT)
        MainView.ProgressLabel.Text = "55% - Adding PanguTeam's Fuxiqin9 Untether to the Custom Firmware..."
        hfsplus("""" + rootfsEXT + """" + " untar " + """" + tempdir + "\payloads\io.fuxiqin9-untether.tar" + """" + " " + """" + "/" + """")
    End Sub

    Public Shared Sub AddSSH(rootfsEXT)
        MainView.ProgressLabel.Text = "55% - Adding SSH to the Custom Firmware..."
        hfsplus("""" + rootfsEXT + """" + " untar " + """" + tempdir + "\payloads\ssh-shrink.tar" + """" + " " + """" + "/" + """")
        hfsplus("""" + rootfsEXT + """" + " untar " + """" + tempdir + "\payloads\openssl.tar" + """" + " " + """" + "/" + """")
        hfsplus("""" + rootfsEXT + """" + " untar " + """" + tempdir + "\payloads\openssh.tar" + """" + " " + """" + "/" + """")
        hfsplus("""" + rootfsEXT + """" + " add " + """" + tempdir + "\payloads\open" + """" + " " + """" + "/usr/bin/open" + """")
        hfsplus("""" + rootfsEXT + """" + " chmod 100755 " + """" + "/usr/bin/open" + """")
    End Sub

    Public Shared Sub AddCydia(rootfsEXT)
        MainView.ProgressLabel.Text = "55% - Adding Cydia to the Custom Firmware..."
        hfsplus("""" + rootfsEXT + """" + " untar " + """" + tempdir + "\payloads\cydia.tar" + """" + " " + """" + "/" + """")
        hfsplus("""" + rootfsEXT + """" + " untar " + """" + tempdir + "\payloads\cydia-1.1.26.tar" + """" + " " + """" + "/" + """")
        hfsplus("""" + rootfsEXT + """" + " chmod 6775 " + """" + "/Applications/Cydia.app/MobileCydia" + """")
        hfsplus("""" + rootfsEXT + """" + " chown root wheel " + """" + "/Applications/Cydia.app/MobileCydia" + """")

        'stashing
        MainView.ProgressLabel.Text = "55% - Doing Cydia's Preparing Filesystem..."
        hfsplus("""" + rootfsEXT + """" + " mkdir " + """" + "/private/var/stash" + """")
        hfsplus("""" + rootfsEXT + """" + " mv " + """" + "/Applications" + """" + " " + """" + "/private/var/stash/Applications" + """")
        hfsplus("""" + rootfsEXT + """" + " mv " + """" + "/Library/Ringtones" + """" + " " + """" + "/private/var/stash/Ringtones" + """")
        hfsplus("""" + rootfsEXT + """" + " mv " + """" + "/Library/Wallpaper" + """" + " " + """" + "/private/var/stash/Wallpaper" + """")
        hfsplus("""" + rootfsEXT + """" + " mv " + """" + "/usr/include" + """" + " " + """" + "/private/var/stash/include" + """")
        hfsplus("""" + rootfsEXT + """" + " mv " + """" + "/usr/libexec" + """" + " " + """" + "/private/var/stash/libexec" + """")
        hfsplus("""" + rootfsEXT + """" + " mv " + """" + "/usr/lib/pam" + """" + " " + """" + "/private/var/stash/pam" + """")
        hfsplus("""" + rootfsEXT + """" + " mv " + """" + "/usr/share" + """" + " " + """" + "/private/var/stash/share" + """")
        hfsplus("""" + rootfsEXT + """" + " symlink " + """" + "/Applications" + """" + " " + """" + "/private/var/stash/Applications" + """")
        hfsplus("""" + rootfsEXT + """" + " symlink " + """" + "/Library/Ringtones" + """" + " " + """" + "/private/var/stash/Ringtones" + """")
        hfsplus("""" + rootfsEXT + """" + " symlink " + """" + "/Library/Wallpaper" + """" + " " + """" + "/private/var/stash/Wallpaper" + """")
        hfsplus("""" + rootfsEXT + """" + " symlink " + """" + "/usr/include" + """" + " " + """" + "/private/var/stash/include" + """")
        hfsplus("""" + rootfsEXT + """" + " symlink " + """" + "/usr/libexec" + """" + " " + """" + "/private/var/stash/libexec" + """")
        hfsplus("""" + rootfsEXT + """" + " symlink " + """" + "/usr/lib/pam" + """" + " " + """" + "/private/var/stash/pam" + """")
        hfsplus("""" + rootfsEXT + """" + " symlink " + """" + "/usr/share" + """" + " " + """" + "/private/var/stash/share" + """")

    End Sub

End Class
