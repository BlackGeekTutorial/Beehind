Imports Beehind.Common_Definitions
Imports Beehind.Processes


Public Class AddUntethers

    Public Shared Sub AddUntetherPayload(rootfsEXT)
        If iOS_Version = "5.0" Or iOS_Version = "5.0.1" Then
            AddCoronaPayload()
        ElseIf iOS_Version = "5.1" Or iOS_Version = "5.1.1" Then
            AddRockyRacoonPayload()
        ElseIf iOS_Version = "6.0" Or iOS_Version = "6.0.1" Or iOS_Version = "6.0.2" Or iOS_Version = "6.1" Or iOS_Version = "6.1.1" Or iOS_Version = "6.1.2" Then
            AddEvasi0n6Payload(rootfsEXT)
        ElseIf iOS_Version = "6.1.3" Or iOS_Version = "6.1.4" Or iOS_Version = "6.1.5" Or iOS_Version = "6.1.6" Then
            Addp0sixspwnPayload(rootfsEXT)
        ElseIf iOS_Version = "7.0" Or iOS_Version = "7.0.1" Or iOS_Version = "7.0.2" Or iOS_Version = "7.0.3" Or iOS_Version = "7.0.4" Or iOS_Version = "7.0.5" Or iOS_Version = "7.0.6" Then
            AddEvasi0n7Payload()
        ElseIf iOS_Version = "7.1" Or iOS_Version = "7.1.1" Or iOS_Version = "7.1.2" Then
            AddPangu7Payload(rootfsEXT)
        ElseIf iOS_Version = "8.0" Or iOS_Version = "8.0.1" Or iOS_Version = "8.0.2" Or iOS_Version = "8.1" Or iOS_Version = "8.1.1" Or iOS_Version = "8.1.2 Then" Then
            AddTaiGPayload()
        ElseIf iOS_Version = "8.1.3" Or iOS_Version = "8.2" Or iOS_Version = "8.3" Then
            AddTaiG2Payload()
        End If
    End Sub

    Public Shared Sub AddCoronaPayload()

    End Sub

    Public Shared Sub AddRockyRacoonPayload()

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

    Public Shared Sub AddEvasi0n7Payload()

    End Sub

    Public Shared Sub AddPangu7Payload(rootfsEXT)
        MainView.ProgressLabel.Text = "55% - Adding PanguTeam's PanguAxe Untether to the Custom Firmware..."
        hfsplus("""" + rootfsEXT + """" + " untar " + """" + tempdir + "\payloads\io.panguaxe-untether.tar" + """" + " " + """" + "/" + """")
    End Sub

    Public Shared Sub AddPangu8Payload()

    End Sub

    Public Shared Sub AddTaiGPayload()

    End Sub

    Public Shared Sub AddTaiG2Payload()

    End Sub

    Public Shared Sub AddSSH(rootfsEXT)
        MainView.ProgressLabel.Text = "55% - Adding SSH to the Custom Firmware..."
        hfsplus("""" + rootfsEXT + """" + " untar " + """" + tempdir + "\payloads\ssh-shrink.tar" + """" + " " + """" + "/" + """")
        hfsplus("""" + rootfsEXT + """" + " untar " + """" + tempdir + "\payloads\openssl.tar" + """" + " " + """" + "/" + """")
        hfsplus("""" + rootfsEXT + """" + " untar " + """" + tempdir + "\payloads\openssh.tar" + """" + " " + """" + "/" + """")
        'hfsplus("""" + rootfsEXT + """" + " add " + """" + tempdir + "\payloads\open" + """" + " " + """" + "/usr/bin/open" + """")
        'hfsplus("""" + rootfsEXT + """" + " chmod 100755 " + """" + "/usr/bin/open" + """")
    End Sub

    Public Shared Sub AddCydia(rootfsEXT)
        MainView.ProgressLabel.Text = "55% - Adding Cydia to the Custom Firmware..."
        hfsplus("""" + rootfsEXT + """" + " untar " + """" + tempdir + "\payloads\cydia.tar" + """" + " " + """" + "/" + """")
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
