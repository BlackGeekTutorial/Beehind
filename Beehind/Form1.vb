Imports Beehind.ResourceHandler
Imports Beehind.Common_Functions
Imports System.IO
Imports Beehind.Common_Definitions
Imports Beehind.ProcessUtilities
Imports Beehind.Processes

Public Class Form1

    Public Shared DeviceConnected As Boolean = False
    Public Shared rawdeviceinfos As String = String.Empty

    'ideviceinfo
    Public Shared info_ios As String = String.Empty
    Public Shared info_build As String = String.Empty
    Public Shared info_serialno As String = String.Empty
    Public Shared info_ecid As String = String.Empty
    Public Shared info_itunesname As String = String.Empty
    Public Shared info_product As String = String.Empty
    Public Shared info_hwmodel As String = String.Empty
    Public Shared info_udid As String = String.Empty
    Public Shared info_color As String = String.Empty
    Public Shared info_64 As Boolean = False

    'bb (unusued for now)
    Public Shared info_bbgoldcertid As String = String.Empty
    Public Shared info_bbsnum As String = String.Empty

    'ricavabili
    Public Shared info_devicemodel As String = String.Empty
    Public Shared info_cellularmodel As String = String.Empty

    Public Shared Sub ProductNameParser(productname As String, color As String)
        If productname = "iPad1,1" Then
            info_devicemodel = "iPad 1"
            info_cellularmodel = ""
            info_64 = False
            Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.ipad1
            Beehind.Save_SHSH.CableIcon.Image = My.Resources._30pin_gradient
            Beehind.Save_SHSH.CableIcon.Location = New Point(2, Beehind.Save_SHSH.CableIcon.Location.Y + 5)
        ElseIf productname = "iPad2,1" Then
            info_devicemodel = "iPad 2"
            info_cellularmodel = " Wi-Fi Only"
            info_64 = False
            Beehind.Save_SHSH.CableIcon.Image = My.Resources._30pin_gradient
            Beehind.Save_SHSH.CableIcon.Location = New Point(2, Beehind.Save_SHSH.CableIcon.Location.Y + 5)
            If info_color = "white" Or info_color = "#e1e4e3" Then
                Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.ipad234_white
            ElseIf info_color = "black" Or info_color = "#272728" Then
                Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.ipad234_black
            End If
        ElseIf productname = "iPad2,2" Then
            info_devicemodel = "iPad 2"
            info_cellularmodel = " Wi-Fi + 3G GSM"
            info_64 = False
            Beehind.Save_SHSH.CableIcon.Image = My.Resources._30pin_gradient
            Beehind.Save_SHSH.CableIcon.Location = New Point(2, Beehind.Save_SHSH.CableIcon.Location.Y + 5)
            If info_color = "white" Or info_color = "#e1e4e3" Then
                Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.ipad234_white
            ElseIf info_color = "black" Or info_color = "#272728" Then
                Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.ipad234_black
            End If
        ElseIf productname = "iPad2,3" Then
            info_devicemodel = "iPad 2"
            info_cellularmodel = " Wi-Fi + 3G CDMA"
            info_64 = False
            Beehind.Save_SHSH.CableIcon.Image = My.Resources._30pin_gradient
            Beehind.Save_SHSH.CableIcon.Location = New Point(2, Beehind.Save_SHSH.CableIcon.Location.Y + 5)
            If info_color = "white" Or info_color = "#e1e4e3" Then
                Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.ipad234_white
            ElseIf info_color = "black" Or info_color = "#272728" Then
                Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.ipad234_black
            End If
        ElseIf productname = "iPad2,4" Then
            info_devicemodel = "iPad 2"
            info_cellularmodel = " Wi-Fi + 3G Rev 2012"
            info_64 = False
            Beehind.Save_SHSH.CableIcon.Image = My.Resources._30pin_gradient
            Beehind.Save_SHSH.CableIcon.Location = New Point(2, Beehind.Save_SHSH.CableIcon.Location.Y + 5)
            If info_color = "white" Or info_color = "#e1e4e3" Then
                Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.ipad234_white
            ElseIf info_color = "black" Or info_color = "#272728" Then
                Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.ipad234_black
            End If
        ElseIf productname = "iPad2,5" Then
            info_devicemodel = "iPad Mini 1"
            info_cellularmodel = " Wi-Fi Only"
            info_64 = False
            Beehind.Save_SHSH.CableIcon.Image = My.Resources.lightning_gradient
            Beehind.Save_SHSH.CableIcon.Location = New Point(2, 269)
            If info_color = "white" Or info_color = "#e1e4e3" Then
                Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.ipadmini12_white
            ElseIf info_color = "black" Or info_color = "#272728" Then
                Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.ipadmini12_black
            End If
        ElseIf productname = "iPad2,6" Then
            info_devicemodel = "iPad Mini 1"
            info_cellularmodel = " Wi-Fi + 3G GSM"
            info_64 = False
            Beehind.Save_SHSH.CableIcon.Image = My.Resources.lightning_gradient
            Beehind.Save_SHSH.CableIcon.Location = New Point(2, 269)
            If info_color = "white" Or info_color = "#e1e4e3" Then
                Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.ipadmini12_white
            ElseIf info_color = "black" Or info_color = "#272728" Then
                Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.ipadmini12_black
            End If
        ElseIf productname = "iPad2,7" Then
            info_devicemodel = "iPad Mini 1"
            info_cellularmodel = " Wi-Fi + 3G Global"
            info_64 = False
            Beehind.Save_SHSH.CableIcon.Image = My.Resources.lightning_gradient
            Beehind.Save_SHSH.CableIcon.Location = New Point(2, 269)
            If info_color = "white" Or info_color = "#e1e4e3" Then
                Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.ipadmini12_white
            ElseIf info_color = "black" Or info_color = "#272728" Then
                Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.ipadmini12_black
            End If
        ElseIf productname = "iPad3,1" Then
            info_devicemodel = "iPad 3"
            info_cellularmodel = " Wi-Fi Only"
            info_64 = False
            Beehind.Save_SHSH.CableIcon.Image = My.Resources._30pin_gradient
            Beehind.Save_SHSH.CableIcon.Location = New Point(2, Beehind.Save_SHSH.CableIcon.Location.Y + 5)
            If info_color = "white" Or info_color = "#e1e4e3" Then
                Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.ipad234_white
            ElseIf info_color = "black" Or info_color = "#272728" Then
                Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.ipad234_black
            End If
        ElseIf productname = "iPad3,2" Then
            info_devicemodel = "iPad 3"
            info_cellularmodel = " Wi-Fi + 3G CDMA"
            info_64 = False
            Beehind.Save_SHSH.CableIcon.Image = My.Resources._30pin_gradient
            Beehind.Save_SHSH.CableIcon.Location = New Point(2, Beehind.Save_SHSH.CableIcon.Location.Y + 5)
            If info_color = "white" Or info_color = "#e1e4e3" Then
                Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.ipad234_white
            ElseIf info_color = "black" Or info_color = "#272728" Then
                Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.ipad234_black
            End If
        ElseIf productname = "iPad3,3" Then
            info_devicemodel = "iPad 3"
            info_cellularmodel = " Wi-Fi + 3G GSM"
            info_64 = False
            Beehind.Save_SHSH.CableIcon.Image = My.Resources._30pin_gradient
            Beehind.Save_SHSH.CableIcon.Location = New Point(2, Beehind.Save_SHSH.CableIcon.Location.Y + 5)
            If info_color = "white" Or info_color = "#e1e4e3" Then
                Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.ipad234_white
            ElseIf info_color = "black" Or info_color = "#272728" Then
                Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.ipad234_black
            End If
        ElseIf productname = "iPad3,4" Then
            info_devicemodel = "iPad 4"
            info_cellularmodel = " Wi-Fi Only"
            info_64 = False
            Beehind.Save_SHSH.CableIcon.Image = My.Resources._30pin_gradient
            Beehind.Save_SHSH.CableIcon.Location = New Point(2, Beehind.Save_SHSH.CableIcon.Location.Y + 5)
            If info_color = "white" Or info_color = "#e1e4e3" Then
                Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.ipad234_white
            ElseIf info_color = "black" Or info_color = "#272728" Then
                Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.ipad234_black
            End If
        ElseIf productname = "iPad3,5" Then
            info_devicemodel = "iPad 4"
            info_cellularmodel = " Wi-Fi + 4G GSM"
            info_64 = False
            Beehind.Save_SHSH.CableIcon.Image = My.Resources._30pin_gradient
            Beehind.Save_SHSH.CableIcon.Location = New Point(2, Beehind.Save_SHSH.CableIcon.Location.Y + 5)
            If info_color = "white" Or info_color = "#e1e4e3" Then
                Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.ipad234_white
            ElseIf info_color = "black" Or info_color = "#272728" Then
                Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.ipad234_black
            End If
        ElseIf productname = "iPad3,6" Then
            info_devicemodel = "iPad 4"
            info_cellularmodel = " Wi-Fi + 4G Global"
            info_64 = False
            Beehind.Save_SHSH.CableIcon.Image = My.Resources._30pin_gradient
            Beehind.Save_SHSH.CableIcon.Location = New Point(2, Beehind.Save_SHSH.CableIcon.Location.Y + 5)
            If info_color = "white" Or info_color = "#e1e4e3" Then
                Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.ipad234_white
            ElseIf info_color = "black" Or info_color = "#272728" Then
                Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.ipad234_black
            End If
        ElseIf productname = "iPad4,1" Then
            info_devicemodel = "iPad Air 1"
            info_cellularmodel = " Wi-Fi Only"
            info_64 = True
            Beehind.Save_SHSH.CableIcon.Image = My.Resources.lightning_gradient
            Beehind.Save_SHSH.CableIcon.Location = New Point(2, 269)
            If info_color = "white" Or info_color = "#e1e4e3" Then
                Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.ipadair1_silver
            ElseIf info_color = "black" Or info_color = "#272728" Then
                Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.ipadair1_spacegrey
            End If
        ElseIf productname = "iPad4,2" Then
            info_devicemodel = "iPad Air 1"
            info_cellularmodel = " Wi-Fi + 4G"
            info_64 = True
            Beehind.Save_SHSH.CableIcon.Image = My.Resources.lightning_gradient
            Beehind.Save_SHSH.CableIcon.Location = New Point(2, 269)
            If info_color = "white" Or info_color = "#e1e4e3" Then
                Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.ipadair1_silver
            ElseIf info_color = "black" Or info_color = "#272728" Then
                Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.ipadair1_spacegrey
            End If
        ElseIf productname = "iPad4,3" Then
            info_devicemodel = "iPad Air 1"
            info_cellularmodel = " Wi-Fi + 4G (China)"
            info_64 = True
            Beehind.Save_SHSH.CableIcon.Image = My.Resources.lightning_gradient
            Beehind.Save_SHSH.CableIcon.Location = New Point(2, 269)
            If info_color = "white" Or info_color = "#e1e4e3" Then
                Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.ipadair1_silver
            ElseIf info_color = "black" Or info_color = "#272728" Then
                Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.ipadair1_spacegrey
            End If
        ElseIf productname = "iPad4,4" Then
            info_devicemodel = "iPad Mini 2"
            info_cellularmodel = " Wi-Fi Only"
            info_64 = False
            Beehind.Save_SHSH.CableIcon.Image = My.Resources.lightning_gradient
            Beehind.Save_SHSH.CableIcon.Location = New Point(2, 269)
            If info_color = "white" Or info_color = "#e1e4e3" Then
                Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.ipadmini12_white
            ElseIf info_color = "black" Or info_color = "#272728" Then
                Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.ipadmini12_black
            End If
        ElseIf productname = "iPad4,5" Then
            info_devicemodel = "iPad Mini 2"
            info_cellularmodel = " Wi-Fi + 4G"
            info_64 = False
            Beehind.Save_SHSH.CableIcon.Image = My.Resources.lightning_gradient
            Beehind.Save_SHSH.CableIcon.Location = New Point(2, 269)
            If info_color = "white" Or info_color = "#e1e4e3" Then
                Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.ipadmini12_white
            ElseIf info_color = "black" Or info_color = "#272728" Then
                Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.ipadmini12_black
            End If
        ElseIf productname = "iPad4,6" Then
            info_devicemodel = "iPad Mini 2"
            info_cellularmodel = " Wi-Fi + 4G (China)"
            info_64 = False
            Beehind.Save_SHSH.CableIcon.Image = My.Resources.lightning_gradient
            Beehind.Save_SHSH.CableIcon.Location = New Point(2, 269)
            If info_color = "white" Or info_color = "#e1e4e3" Then
                Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.ipadmini12_white
            ElseIf info_color = "black" Or info_color = "#272728" Then
                Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.ipadmini12_black
            End If
        ElseIf productname = "iPad4,7" Then
            info_devicemodel = "iPad Mini 3"
            info_cellularmodel = " Wi-Fi Only"
            info_64 = True
            Beehind.Save_SHSH.CableIcon.Image = My.Resources.lightning_gradient
            Beehind.Save_SHSH.CableIcon.Location = New Point(2, 269)
            If info_color = "white" Or info_color = "#e1e4e3" Then
                Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.ipadmini34_silver
            ElseIf info_color = "black" Or info_color = "#272728" Then
                Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.ipadmini34_spacegrey
            End If
        ElseIf productname = "iPad4,8" Then
            info_devicemodel = "iPad Mini 3"
            info_cellularmodel = " Wi-Fi + 4G"
            info_64 = True
            Beehind.Save_SHSH.CableIcon.Image = My.Resources.lightning_gradient
            Beehind.Save_SHSH.CableIcon.Location = New Point(2, 269)
            If info_color = "white" Or info_color = "#e1e4e3" Then
                Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.ipadmini34_silver
            ElseIf info_color = "black" Or info_color = "#272728" Then
                Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.ipadmini34_spacegrey
            End If
        ElseIf productname = "iPad4,9" Then
            info_devicemodel = "iPad Mini 3"
            info_cellularmodel = " Wi-Fi + 4G (China)"
            info_64 = True
            Beehind.Save_SHSH.CableIcon.Image = My.Resources.lightning_gradient
            Beehind.Save_SHSH.CableIcon.Location = New Point(2, 269)
            If info_color = "white" Or info_color = "#e1e4e3" Then
                Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.ipadmini34_silver
            ElseIf info_color = "black" Or info_color = "#272728" Then
                Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.ipadmini34_spacegrey
            End If
        ElseIf productname = "iPad5,1" Then
            info_devicemodel = "iPad Mini 4"
            info_cellularmodel = " Wi-Fi Only"
            info_64 = True
            Beehind.Save_SHSH.CableIcon.Image = My.Resources.lightning_gradient
            Beehind.Save_SHSH.CableIcon.Location = New Point(2, 269)
            If info_color = "white" Or info_color = "#e1e4e3" Then
                Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.ipadmini34_silver
            ElseIf info_color = "black" Or info_color = "#272728" Then
                Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.ipadmini34_spacegrey
            End If
        ElseIf productname = "iPad5,2" Then
            info_devicemodel = "iPad Mini 4"
            info_cellularmodel = " Wi-Fi + 4G"
            info_64 = True
            Beehind.Save_SHSH.CableIcon.Image = My.Resources.lightning_gradient
            Beehind.Save_SHSH.CableIcon.Location = New Point(2, 269)
            If info_color = "white" Or info_color = "#e1e4e3" Then
                Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.ipadmini34_silver
            ElseIf info_color = "black" Or info_color = "#272728" Then
                Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.ipadmini34_spacegrey
            End If
        ElseIf productname = "iPad5,3" Then
            info_devicemodel = "iPad Air 2"
            info_cellularmodel = " Wi-Fi Only"
            info_64 = True
            Beehind.Save_SHSH.CableIcon.Image = My.Resources.lightning_gradient
            Beehind.Save_SHSH.CableIcon.Location = New Point(2, 269)
            If info_color = "white" Or info_color = "#e1e4e3" Then
                Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.ipadair2_silver
            ElseIf info_color = "black" Or info_color = "#272728" Then
                Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.ipadair2_spacegrey
            End If
        ElseIf productname = "iPad5,4" Then
            info_devicemodel = "iPad Air 2"
            info_cellularmodel = " Wi-Fi + 4G"
            info_64 = True
            Beehind.Save_SHSH.CableIcon.Image = My.Resources.lightning_gradient
            Beehind.Save_SHSH.CableIcon.Location = New Point(2, 269)
            If info_color = "white" Or info_color = "#e1e4e3" Then
                Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.ipadair2_silver
            ElseIf info_color = "black" Or info_color = "#272728" Then
                Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.ipadair2_spacegrey
            End If
        ElseIf productname = "iPad6,7" Then
            info_devicemodel = "iPad Pro"
            info_cellularmodel = " Wi-Fi Only"
            info_64 = True
            Beehind.Save_SHSH.CableIcon.Image = My.Resources.lightning_gradient
            Beehind.Save_SHSH.CableIcon.Location = New Point(2, 269)
            If info_color = "white" Or info_color = "#e1e4e3" Then
                Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.ipadpro_white
            ElseIf info_color = "black" Or info_color = "#272728" Then
                Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.ipadpro_spacegrey
            End If
        ElseIf productname = "iPad6,8" Then
            info_devicemodel = "iPad Pro"
            info_cellularmodel = " Wi-Fi + 4G"
            info_64 = True
            Beehind.Save_SHSH.CableIcon.Image = My.Resources.lightning_gradient
            Beehind.Save_SHSH.CableIcon.Location = New Point(2, 269)
            If info_color = "white" Or info_color = "#e1e4e3" Then
                Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.ipadpro_white
            ElseIf info_color = "black" Or info_color = "#272728" Then
                Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.ipadpro_spacegrey
            End If
        ElseIf productname = "iPhone1,1" Then
            info_devicemodel = "iPhone 2G"
            info_cellularmodel = ""
            info_64 = False
            Beehind.Save_SHSH.CableIcon.Image = My.Resources._30pin_gradient
            Beehind.Save_SHSH.CableIcon.Location = New Point(2, Beehind.Save_SHSH.CableIcon.Location.Y + 5)
        ElseIf productname = "iPhone1,2" Then
            info_devicemodel = "iPhone 3G"
            info_cellularmodel = ""
            info_64 = False
        ElseIf productname = "iPhone2,1" Then
            info_devicemodel = "iPhone 3G[S]"
            info_cellularmodel = ""
            info_64 = False
            Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.iphone3gs
            Beehind.Save_SHSH.CableIcon.Image = My.Resources._30pin_gradient
            Beehind.Save_SHSH.CableIcon.Location = New Point(2, Beehind.Save_SHSH.CableIcon.Location.Y + 5)
        ElseIf productname = "iPhone3,1" Then
            info_devicemodel = "iPhone 4"
            info_cellularmodel = " GSM"
            info_64 = False
            Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.iphone4_black
            Beehind.Save_SHSH.CableIcon.Image = My.Resources._30pin_gradient
            Beehind.Save_SHSH.CableIcon.Location = New Point(2, Beehind.Save_SHSH.CableIcon.Location.Y + 5)
        ElseIf productname = "iPhone3,2" Then
            info_devicemodel = "iPhone 4"
            info_cellularmodel = " GSM Rev A (2012)"
            info_64 = False
            Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.iphone4_white
            Beehind.Save_SHSH.CableIcon.Image = My.Resources._30pin_gradient
            Beehind.Save_SHSH.CableIcon.Location = New Point(2, Beehind.Save_SHSH.CableIcon.Location.Y + 5)
        ElseIf productname = "iPhone3,3" Then
            info_devicemodel = "iPhone 4"
            info_cellularmodel = " CDMA"
            info_64 = False
            Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.iphone4s_black
            Beehind.Save_SHSH.CableIcon.Image = My.Resources._30pin_gradient
            Beehind.Save_SHSH.CableIcon.Location = New Point(2, Beehind.Save_SHSH.CableIcon.Location.Y + 5)
        ElseIf productname = "iPhone4,1" Then
            info_devicemodel = "iPhone 4[S]"
            info_cellularmodel = ""
            info_64 = False
            Beehind.Save_SHSH.CableIcon.Image = My.Resources._30pin_gradient
            Beehind.Save_SHSH.CableIcon.Location = New Point(2, Beehind.Save_SHSH.CableIcon.Location.Y + 5)
            If info_color = "white" Or info_color = "#e1e4e3" Then
                Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.iphone4s_white
            ElseIf info_color = "black" Or info_color = "#272728" Then
                Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.iphone4s_black
            End If
        ElseIf productname = "iPhone5,1" Then
            info_devicemodel = "iPhone 5"
            info_cellularmodel = " GSM"
            info_64 = False
            Beehind.Save_SHSH.CableIcon.Image = My.Resources.lightning_gradient
            Beehind.Save_SHSH.CableIcon.Location = New Point(2, 269)
            If info_color = "white" Or info_color = "#e1e4e3" Then
                Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.iphone5_silver
            ElseIf info_color = "black" Or info_color = "#272728" Then
                Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.iphone5_black
            End If
        ElseIf productname = "iPhone5,2" Then
            info_devicemodel = "iPhone 5"
            info_cellularmodel = " Global"
            info_64 = False
            Beehind.Save_SHSH.CableIcon.Image = My.Resources.lightning_gradient
            Beehind.Save_SHSH.CableIcon.Location = New Point(2, 269)
            If info_color = "white" Or info_color = "#e1e4e3" Then
                Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.iphone5_silver
            ElseIf info_color = "black" Or info_color = "#272728" Then
                Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.iphone5_black
            End If
        ElseIf productname = "iPhone5,3" Then
            info_devicemodel = "iPhone 5c"
            info_cellularmodel = " GSM"
            info_64 = False
            Beehind.Save_SHSH.CableIcon.Image = My.Resources.lightning_gradient
            Beehind.Save_SHSH.CableIcon.Location = New Point(2, 269)
            Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.iphone5c_white
        ElseIf productname = "iPhone5,4" Then
            info_devicemodel = "iPhone 5c"
            info_cellularmodel = " Global"
            info_64 = False
            Beehind.Save_SHSH.CableIcon.Image = My.Resources.lightning_gradient
            Beehind.Save_SHSH.CableIcon.Location = New Point(2, 269)
            Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.iphone5c_white
        ElseIf productname = "iPhone6,1" Then
            info_devicemodel = "iPhone 5s"
            info_cellularmodel = " GSM"
            info_64 = True
            Beehind.Save_SHSH.CableIcon.Image = My.Resources.lightning_gradient
            Beehind.Save_SHSH.CableIcon.Location = New Point(2, 269)
            If info_color = "white" Or info_color = "#e1e4e3" Then
                Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.iphone5s_silver
            ElseIf info_color = "black" Or info_color = "#272728" Then
                Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.iphone5s_spacegrey
            End If
        ElseIf productname = "iPhone6,2" Then
            info_devicemodel = "iPhone 5s"
            info_cellularmodel = " Global"
            info_64 = True
            Beehind.Save_SHSH.CableIcon.Image = My.Resources.lightning_gradient
            Beehind.Save_SHSH.CableIcon.Location = New Point(2, 269)
            If info_color = "white" Or info_color = "#e1e4e3" Then
                Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.iphone5s_silver
            ElseIf info_color = "black" Or info_color = "#272728" Then
                Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.iphone5s_spacegrey
            End If
        ElseIf productname = "iPhone7,1" Then
            info_devicemodel = "iPhone 6 Plus"
            info_cellularmodel = ""
            info_64 = True
            Beehind.Save_SHSH.CableIcon.Image = My.Resources.lightning_gradient
            Beehind.Save_SHSH.CableIcon.Location = New Point(2, 269)
            If info_color = "white" Or info_color = "#e1e4e3" Then
                Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.iphone6_6s__silver
            ElseIf info_color = "black" Or info_color = "#272728" Then
                Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.iphone6_6s__spacegrey
            End If
        ElseIf productname = "iPhone7,2" Then
            info_devicemodel = "iPhone 6"
            info_cellularmodel = ""
            info_64 = True
            Beehind.Save_SHSH.CableIcon.Image = My.Resources.lightning_gradient
            Beehind.Save_SHSH.CableIcon.Location = New Point(2, 269)
            If info_color = "white" Or info_color = "#e1e4e3" Then
                Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.iphone66s_silver
            ElseIf info_color = "black" Or info_color = "#272728" Then
                Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.iphone66s_spacegrey
            End If
        ElseIf productname = "iPhone8,1" Then
            info_devicemodel = "iPhone 6s"
            info_cellularmodel = ""
            info_64 = True
            Beehind.Save_SHSH.CableIcon.Image = My.Resources.lightning_gradient
            Beehind.Save_SHSH.CableIcon.Location = New Point(2, 269)
            If info_color = "white" Or info_color = "#e1e4e3" Then
                Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.iphone66s_silver
            ElseIf info_color = "black" Or info_color = "#272728" Then
                Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.iphone66s_spacegrey
            End If
        ElseIf productname = "iPhone8,2" Then
            info_devicemodel = "iPhone 6s Plus"
            info_cellularmodel = ""
            info_64 = True
            Beehind.Save_SHSH.CableIcon.Image = My.Resources.lightning_gradient
            Beehind.Save_SHSH.CableIcon.Location = New Point(2, 269)
            If info_color = "white" Or info_color = "#e1e4e3" Then
                Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.iphone6_6s__silver
            ElseIf info_color = "black" Or info_color = "#272728" Then
                Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.iphone6_6s__spacegrey
            End If
        ElseIf productname = "iPod1,1" Then
            info_devicemodel = "iPod touch 1G"
            info_cellularmodel = ""
            info_64 = False
            Beehind.Save_SHSH.CableIcon.Image = My.Resources._30pin_gradient
            Beehind.Save_SHSH.CableIcon.Location = New Point(2, Beehind.Save_SHSH.CableIcon.Location.Y + 5)
        ElseIf productname = "iPod2,1" Then
            info_devicemodel = "iPod touch 2G"
            info_cellularmodel = ""
            info_64 = False
            Beehind.Save_SHSH.CableIcon.Image = My.Resources._30pin_gradient
            Beehind.Save_SHSH.CableIcon.Location = New Point(2, Beehind.Save_SHSH.CableIcon.Location.Y + 5)
        ElseIf productname = "iPod3,1" Then
            info_devicemodel = "iPod touch 3"
            info_cellularmodel = ""
            info_64 = False
            Beehind.Save_SHSH.CableIcon.Image = My.Resources._30pin_gradient
            Beehind.Save_SHSH.CableIcon.Location = New Point(2, Beehind.Save_SHSH.CableIcon.Location.Y + 5)
        ElseIf productname = "iPod4,1" Then
            info_devicemodel = "iPod touch 4"
            info_cellularmodel = ""
            info_64 = False
            Beehind.Save_SHSH.CableIcon.Image = My.Resources._30pin_gradient
            Beehind.Save_SHSH.CableIcon.Location = New Point(2, Beehind.Save_SHSH.CableIcon.Location.Y + 5)
            If info_color = "white" Or info_color = "#e1e4e3" Then
                Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.ipod4_white
            ElseIf info_color = "black" Or info_color = "#272728" Then
                Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.ipod4_black
            End If
        ElseIf productname = "iPod5,1" Then
            info_devicemodel = "iPod touch 5"
            info_cellularmodel = ""
            info_64 = False
            Beehind.Save_SHSH.CableIcon.Image = My.Resources.lightning_gradient
            Beehind.Save_SHSH.CableIcon.Location = New Point(2, 269)
            If info_color = "white" Or info_color = "#e1e4e3" Then
                Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.ipod5_white
            ElseIf info_color = "black" Or info_color = "#272728" Then
                Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.ipod5_black
            End If
        ElseIf productname = "iPod7,1" Then
            info_devicemodel = "iPod touch 6"
            info_cellularmodel = ""
            info_64 = True
            Beehind.Save_SHSH.CableIcon.Image = My.Resources.lightning_gradient
            Beehind.Save_SHSH.CableIcon.Location = New Point(2, 269)
            If info_color = "white" Or info_color = "#e1e4e3" Then
                Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.ipod6_white
            ElseIf info_color = "black" Or info_color = "#272728" Then
                Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.ipod6_spacegrey
            End If
        ElseIf productname = "AppleTV5,3" Then
            info_devicemodel = "Apple TV (4th Gen)"
            info_cellularmodel = ""
            info_64 = True
            Beehind.Save_SHSH.DeviceIcon.Image = My.Resources.atv4
            Beehind.Save_SHSH.CableIcon.Image = Nothing
        End If

    End Sub


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If IsRoot() = False Then
            Dim relaunch As Integer = MessageBox.Show("Beehind isn't running with administrator's  privileges. Some of its functions can't work properly. Click 'Yes' to relaunch Beehind with administrator's privileges", "No root", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If relaunch = DialogResult.Yes Then
                Dim Beehind As New Process()
                Try
                    Beehind.StartInfo.UseShellExecute = True
                    Beehind.StartInfo.FileName = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName
                    Beehind.StartInfo.CreateNoWindow = False
                    Beehind.StartInfo.Verb = "runas"
                    Beehind.Start()
                Catch ex As Exception
                End Try
                Application.Exit()
            End If
        End If

        Me.Text = "Beehind - kloader's GUI - BETA (v. " + (Beehind.Common_Definitions.currentversion.ToString).Replace(",", ".") + ")"
        If Directory.Exists(tempdir) Then
            For Each File In (Directory.GetFiles(tempdir)).ToArray()
                For Each Process In GetProcessesUsingFiles({File})
                    Kill({Process.ProcessName})
                Next
            Next

            For Each subdir In (My.Computer.FileSystem.GetDirectories(tempdir + "\", FileIO.SearchOption.SearchAllSubDirectories, "*")).ToArray
                For Each File In (Directory.GetFiles(subdir)).ToArray()
                    For Each Process In GetProcessesUsingFiles({File})
                        Kill({Process.ProcessName})
                    Next
                Next
            Next
        End If

        ExtractResources()

        If shsh_saving_dir <> String.Empty And Not Directory.Exists(shsh_saving_dir) Then
            Directory.CreateDirectory(shsh_saving_dir)
        End If

        If Beehind.Betashit.IsRelease = True Then
            MainView.BasebandCheckBox.Enabled = False
            MainView.BasebandComboBox.Enabled = False
            MainView.CustomBundleCheckBox.Enabled = False
            BeehindMenuStrip.Items.Remove(RestoreModeToolStripMenuItem)
            BeehindMenuStrip.Items.Remove(DumpSHSHToolStripMenuItem)
            BeehindMenuStrip.Items.Remove(DumpBasebandToolStripMenuItem)
            idevicerestoreGUI.RestoreOptionsGroupBox.Visible = False
            Save_SHSH.FetchOTABlobsCheckBox.Visible = False
            MessageBox.Show(Beehind.Betashit.Warning)
        End If

        MainView.MdiParent = Me
        MainView.Show()
    End Sub


    Private Sub IPSWCreatorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IPSWCreatorToolStripMenuItem.Click
        MainView.MdiParent = Me
        MainView.Show()
        KloaderInjector.Close()
        Restore.Close()
        idevicerestoreGUI.Close()
        Save_SHSH.Close()
    End Sub

    Private Sub KloaderModeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KloaderModeToolStripMenuItem.Click
        KloaderInjector.MdiParent = Me
        KloaderInjector.Show()
        MainView.Close()
        Restore.Close()
        idevicerestoreGUI.Close()
        Save_SHSH.Close()
    End Sub

    Private Sub RestoreModeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RestoreModeToolStripMenuItem.Click
        Restore.MdiParent = Me
        Restore.Show()
        idevicerestoreGUI.Close()
        MainView.Close()
        Save_SHSH.Close()
        KloaderInjector.Close()
    End Sub

    Private Sub AboutBeehindToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutBeehindToolStripMenuItem.Click
        Process.Start("http://beehind.geeksn0w.it")
    End Sub

    Private Sub FollowMeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FollowMeToolStripMenuItem.Click
        Process.Start("http://twitter.com/blackgeektuto")
    End Sub

    Private Sub DonationsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DonationsToolStripMenuItem.Click
        Process.Start("http://geeksn0w.it/donate.html")
    End Sub

    Private Sub CreditsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreditsToolStripMenuItem.Click
        MessageBox.Show("Beehind has been developed by Andrea Bentivegna (@blackgeektuto)" + Environment.NewLine + Environment.NewLine + "Thanks to:" + Environment.NewLine + "@winocm - for kloader and ios-kexec-utils" + Environment.NewLine + "@geohot - for limera1n exploit" + Environment.NewLine + "@pimskeks - for libimobiledevice and idevicerestore source code" + Environment.NewLine + "@Elro74 - for helping in compiling idevicerestore for Windows" + Environment.NewLine + "@xerub, @iSuns9 and few others for Firmware Bundles" + Environment.NewLine + "@taig_Jailbreak - for iOS 8.x Untether Payload" + Environment.NewLine + "@PanguTeam - for iOS 7.1.x Untether Payload" + Environment.NewLine + "@evad3rs - for iOS 7.0.x and 6.0-6.1.2 Untether Payload" + Environment.NewLine + "@iH8Sn0w, @squiffy and @winocm - for iOS 6.1.3-6.1.6 Untether Payload", "Credits/Thanks to:",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub IdevicerestoreModeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IdevicerestoreModeToolStripMenuItem.Click
        idevicerestoreGUI.MdiParent = Me
        idevicerestoreGUI.Show()
        Restore.Close()
        MainView.Close()
        KloaderInjector.Close()
        Save_SHSH.Close()
    End Sub

    Private Sub SeeXPWNOnGitHubToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SeeXPWNOnGitHubToolStripMenuItem.Click
        Process.Start("https://github.com/planetbeing/xpwn")
    End Sub

    Private Sub SeeBeehindOnGitHubToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SeeBeehindOnGitHubToolStripMenuItem.Click
        Process.Start("https://github.com/BlackGeekTutorial/Beehind")
    End Sub

    Private Sub SeeIdevicerestoreOnGitHubToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SeeIdevicerestoreOnGitHubToolStripMenuItem.Click
        Process.Start("https://github.com/libimobiledevice/idevicerestore")
    End Sub

    Public Shared Sub GetInfosFromConnectedDevice()
        rawdeviceinfos = GetDeviceInfos(False)

        info_ios = (rawdeviceinfos.Substring(rawdeviceinfos.IndexOf("ProductVersion") + 16)).Substring(0, (rawdeviceinfos.Substring(rawdeviceinfos.IndexOf("ProductVersion") + 16)).IndexOf(Environment.NewLine)).Trim()
        info_build = (rawdeviceinfos.Substring(rawdeviceinfos.IndexOf("BuildVersion") + 14)).Substring(0, (rawdeviceinfos.Substring(rawdeviceinfos.IndexOf("BuildVersion") + 14)).IndexOf(Environment.NewLine)).Trim()
        info_serialno = (rawdeviceinfos.Substring(rawdeviceinfos.IndexOf(Environment.NewLine + "SerialNumber: ") + 14)).Substring(0, (rawdeviceinfos.Substring(rawdeviceinfos.IndexOf("SerialNumber: ") + 14)).IndexOf(Environment.NewLine)).Trim()
        info_ecid = (rawdeviceinfos.Substring(rawdeviceinfos.IndexOf("UniqueChipID") + 14)).Substring(0, (rawdeviceinfos.Substring(rawdeviceinfos.IndexOf("UniqueChipID") + 14)).IndexOf(Environment.NewLine)).Trim()
        info_itunesname = (rawdeviceinfos.Substring(rawdeviceinfos.IndexOf("DeviceName") + 12)).Substring(0, (rawdeviceinfos.Substring(rawdeviceinfos.IndexOf("DeviceName") + 12)).IndexOf(Environment.NewLine)).Trim()
        info_product = (rawdeviceinfos.Substring(rawdeviceinfos.IndexOf("ProductType") + 13)).Substring(0, (rawdeviceinfos.Substring(rawdeviceinfos.IndexOf("ProductType") + 13)).IndexOf(Environment.NewLine)).Trim()
        info_hwmodel = (rawdeviceinfos.Substring(rawdeviceinfos.IndexOf("HardwareModel") + 15)).Substring(0, (rawdeviceinfos.Substring(rawdeviceinfos.IndexOf("HardwareModel") + 15)).IndexOf(Environment.NewLine)).Trim()
        info_udid = (rawdeviceinfos.Substring(rawdeviceinfos.IndexOf("UniqueDeviceID") + 16)).Substring(0, (rawdeviceinfos.Substring(rawdeviceinfos.IndexOf("UniqueDeviceID") + 16)).IndexOf(Environment.NewLine)).Trim()
        info_color = (rawdeviceinfos.Substring(rawdeviceinfos.IndexOf("DeviceColor") + 13)).Substring(0, (rawdeviceinfos.Substring(rawdeviceinfos.IndexOf("DeviceColor") + 13)).IndexOf(Environment.NewLine)).Trim()
        ProductNameParser(info_product, info_color)


        'info_ios = GetDeviceInfos(True, "ProductVersion")
        'info_build = GetDeviceInfos(True, "BuildVersion")
        'info_serialno = GetDeviceInfos(True, "SerialNumber")
        'info_ecid = GetDeviceInfos(True, "UniqueChipID")
        'info_itunesname = GetDeviceInfos(True, "DeviceName")
        'info_product = GetDeviceInfos(True, "ProductType")
        'info_hwmodel = GetDeviceInfos(True, "HardwareModel")
        'info_udid = GetDeviceInfos(True, "UniqueDeviceID")


    End Sub

    Private Sub SaveSHSHToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveSHSHToolStripMenuItem.Click
        If IsUserlandConnected() = True Then
            Save_SHSH.MdiParent = Me
            idevicerestoreGUI.Close()
            Restore.Close()
            MainView.Close()
            KloaderInjector.Close()
            Save_SHSH.Show()
        Else
            MessageBox.Show("Please, plug your iOS device in. Then retry.")
        End If


        
    End Sub
End Class
