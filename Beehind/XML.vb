Imports System.Xml

Public Class XML

    Public Shared Function GetTextFromXMLItem(XMLFile As String, MaxPick As Integer, Word As String, replace As String)
        Dim reader As XmlTextReader = New XmlTextReader(XMLFile)
        Dim DumpedItems As Integer = 0
        Dim RawDump As String = String.Empty
        Dim OutputItem As String = String.Empty
        Do While (reader.Read())
            Select Case reader.NodeType
                Case XmlNodeType.Text
                    If reader.Value = Word Then
                        DumpedItems = DumpedItems + 1
                    End If
                    If DumpedItems > 0 And DumpedItems <> MaxPick Then
                        DumpedItems = DumpedItems + 1
                        RawDump = RawDump + reader.Value
                    End If
                    If DumpedItems = MaxPick Then
                        OutputItem = RawDump.Replace(replace, "")
                        DumpedItems = DumpedItems + 1
                        reader.Close()
                    End If
            End Select
        Loop
        Return OutputItem.Trim()
    End Function
End Class
