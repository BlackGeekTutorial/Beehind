Imports System.Xml
Imports Beehind.Processes
Imports Beehind.XML

Public Class RestoreClass

    'Manifest
    Public Shared Restore_iBSS As String = String.Empty
    Public Shared Restore_iBEC As String = String.Empty
    Public Shared Restore_RestoreRamdisk As String = String.Empty
    Public Shared Restore_UpdateRamdisk As String = String.Empty
    Public Shared Restore_RootFS As String = String.Empty
    Public Shared Restore_KernelCache As String = String.Empty
    Public Shared Restore_RestoreKernelCache As String = String.Empty
    Public Shared Restore_AppleLogo As String = String.Empty
    Public Shared Restore_RestoreLogo As String = String.Empty
    Public Shared Restore_BatteryCharging As String = String.Empty
    Public Shared Restore_BatteryCharging0 As String = String.Empty
    Public Shared Restore_BatteryCharging1 As String = String.Empty
    Public Shared Restore_BatteryFull As String = String.Empty
    Public Shared Restore_BatteryLow0 As String = String.Empty
    Public Shared Restore_BatteryLow1 As String = String.Empty
    Public Shared Restore_RestoreDeviceTree As String = String.Empty
    Public Shared Restore_DeviceTree As String = String.Empty
    Public Shared Restore_GlyphCharging As String = String.Empty
    Public Shared Restore_GlyphPlugin As String = String.Empty
    Public Shared Restore_iBoot As String = String.Empty
    Public Shared Restore_LLB As String = String.Empty
    Public Shared Restore_RecoveryMode As String = String.Empty

    Public Shared Function GetPathFromBeehindManifest(ItemName As String, xmlfile As String, MaxPick As Integer)
        Dim reader As XmlTextReader = New XmlTextReader(xmlfile)
        Dim DumpedItems As Integer = 0
        Dim RawDump As String = String.Empty
        Dim OutputItem As String = String.Empty
        Do While (reader.Read())
            Select Case reader.NodeType
                Case XmlNodeType.Text
                    If reader.Value = ItemName Then
                        DumpedItems = DumpedItems + 1
                    End If
                    If DumpedItems > 0 And DumpedItems <> MaxPick Then
                        DumpedItems = DumpedItems + 1
                        RawDump = RawDump + "---" + reader.Value
                    End If
                    If DumpedItems = MaxPick Then
                        OutputItem = RawDump.Replace("---" + ItemName + "---", "")
                        DumpedItems = DumpedItems + 1
                    End If
            End Select
        Loop
        Return OutputItem
    End Function

    Public Shared Sub SendFileToRecoveryMode(InFile As String)
        opensn0w("-S " + """" + InFile + """")
    End Sub

    Public Shared Sub SendCMDToRecoveryMode(CMD As String)
        opensn0w("-C " + """" + CMD + """")
    End Sub

End Class
