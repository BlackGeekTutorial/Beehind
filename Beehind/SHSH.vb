Imports Beehind.Common_Definitions
Imports Beehind.Common_Functions
Imports System.Text.RegularExpressions
Imports System.Text

Public Class SHSH

    Public Shared Sub SplitNewSHSH(Infile As String, workingdirectory As String, ExtractFolder As String)
        Dim DestinationFolder As String = workingdirectory + ExtractFolder
        CreateDirectory(workingdirectory, ExtractFolder, True)
        Dim shshHeader As String = "<?xml version=" + """" + "1.0" + """" + " encoding=" + """" + "utf-8" + """" + "?>" + Environment.NewLine + "<!DOCTYPE plist PUBLIC " + """" + "-//Apple Computer//DTD PLIST 1.0//EN" + """" + " " + """" + "http://www.apple.com/DTDs/PropertyList-1.0.dtd" + """" + ">" + Environment.NewLine + "<plist version=" + """" + "1.0" + """" + ">"
        Dim BuildsPattern As Regex = New Regex("<key>\d{2}\w\d{3}")
        Dim BuildsDocument() As String = IO.File.ReadAllLines(Infile)
        For Each BuildsLine In BuildsDocument
            Dim BuildsMatch As Match = BuildsPattern.Match(BuildsLine)
            If BuildsMatch.Success Then
                Dim BuildsPosition As Integer = -1
                For i As Integer = 0 To BuildsDocument.Length - 1
                    If BuildsDocument(i).Contains(BuildsLine) Then
                        BuildsPosition = i
                        Exit For
                    End If
                Next

                ' The line's number of <dict> is = position + 1
                ' The line of Builds Number is = position

                Dim BuildsTXT2Write As String = shshHeader
                Dim BuildsOpenDict As Integer = 0
                Dim BuildsCloseDict As Integer = 0
                Dim BuildsCurrentLine As Integer = BuildsPosition
                Do Until BuildsOpenDict = BuildsCloseDict And BuildsCloseDict <> 0 And BuildsOpenDict <> 0
                    BuildsCurrentLine = BuildsCurrentLine + 1
                    If BuildsDocument(BuildsCurrentLine).Trim.Contains("<dict>") Then
                        BuildsOpenDict = BuildsOpenDict + 1
                    ElseIf BuildsDocument(BuildsCurrentLine).Trim.Contains("</dict>") Then
                        BuildsCloseDict = BuildsCloseDict + 1
                    End If
                    BuildsTXT2Write = BuildsTXT2Write + Environment.NewLine + BuildsDocument(BuildsCurrentLine)
                Loop
                BuildsTXT2Write = BuildsTXT2Write + Environment.NewLine + "</plist>"
                IO.File.WriteAllText(DestinationFolder + "\" + BuildsLine.Trim.Replace("<key>", "").Replace("</key>", "") + ".xml", BuildsTXT2Write)

                'getting EraseBlobs

                Dim ErasePattern As Regex = New Regex("<key>Erase</key>")
                Dim EraseDocument() As String = IO.File.ReadAllLines(DestinationFolder + "\" + BuildsLine.Trim.Replace("<key>", "").Replace("</key>", "") + ".xml")
                Dim EraseBlobsCount As Integer = 0
                For Each EraseLine In EraseDocument
                    Dim EraseMatch As Match = ErasePattern.Match(EraseLine)
                    If EraseMatch.Success Then
                        Dim ErasePosition As Integer = -1
                        For i As Integer = 0 To EraseDocument.Length - 1
                            If EraseDocument(i).Contains(EraseLine) Then
                                ErasePosition = i
                                Exit For
                            End If
                        Next

                        ' The line's number of <dict> is = position + 1
                        ' The line of Erase Number is = position
                        Dim EraseTXT2Write As String = shshHeader
                        Dim EraseOpenDict As Integer = 0
                        Dim EraseCloseDict As Integer = 0
                        Dim EraseCurrentLine As Integer = ErasePosition
                        Do Until EraseOpenDict = EraseCloseDict And EraseCloseDict <> 0 And EraseOpenDict <> 0
                            EraseCurrentLine = EraseCurrentLine + 1
                            If EraseDocument(EraseCurrentLine).Trim.Contains("<dict>") Then
                                EraseOpenDict = EraseOpenDict + 1
                            ElseIf EraseDocument(EraseCurrentLine).Trim.Contains("</dict>") Then
                                EraseCloseDict = EraseCloseDict + 1
                            End If
                            EraseTXT2Write = EraseTXT2Write + Environment.NewLine + EraseDocument(EraseCurrentLine)
                        Loop
                        EraseTXT2Write = EraseTXT2Write + Environment.NewLine + "</plist>"
                        IO.File.WriteAllText(DestinationFolder + "\" + BuildsLine.Trim.Replace("<key>", "").Replace("</key>", "") + "_Erase(" + EraseBlobsCount.ToString + ").xml", EraseTXT2Write)
                        EraseBlobsCount = EraseBlobsCount + 1
                    End If
                Next


                'getting UpdateBlobs

                Dim UpdatePattern As Regex = New Regex("<key>Update</key>")
                Dim UpdateDocument() As String = IO.File.ReadAllLines(DestinationFolder + "\" + BuildsLine.Trim.Replace("<key>", "").Replace("</key>", "") + ".xml")
                Dim UpdateBlobsCount As Integer = 0
                For Each UpdateLine In UpdateDocument
                    Dim UpdateMatch As Match = UpdatePattern.Match(UpdateLine)
                    If UpdateMatch.Success Then
                        Dim UpdatePosition As Integer = -1
                        For i As Integer = 0 To UpdateDocument.Length - 1
                            If UpdateDocument(i).Contains(UpdateLine) Then
                                UpdatePosition = i
                                Exit For
                            End If
                        Next

                        ' The line's number of <dict> is = position + 1
                        ' The line of Update Number is = position

                        Dim UpdateTXT2Write As String = shshHeader
                        Dim UpdateOpenDict As Integer = 0
                        Dim UpdateCloseDict As Integer = 0
                        Dim UpdateCurrentLine As Integer = UpdatePosition
                        Do Until UpdateOpenDict = UpdateCloseDict And UpdateCloseDict <> 0 And UpdateOpenDict <> 0
                            UpdateCurrentLine = UpdateCurrentLine + 1
                            If UpdateDocument(UpdateCurrentLine).Trim.Contains("<dict>") Then
                                UpdateOpenDict = UpdateOpenDict + 1
                            ElseIf UpdateDocument(UpdateCurrentLine).Trim.Contains("</dict>") Then
                                UpdateCloseDict = UpdateCloseDict + 1
                            End If
                            UpdateTXT2Write = UpdateTXT2Write + Environment.NewLine + UpdateDocument(UpdateCurrentLine)
                        Loop
                        UpdateTXT2Write = UpdateTXT2Write + Environment.NewLine + "</plist>"
                        IO.File.WriteAllText(DestinationFolder + "\" + BuildsLine.Trim.Replace("<key>", "").Replace("</key>", "") + "_Update(" + UpdateBlobsCount.ToString + ").xml", UpdateTXT2Write)
                        UpdateBlobsCount = UpdateBlobsCount + 1
                    End If
                Next


                '-------------OTA------------>
                'getting OTAArrayBlobs

                Dim OTAArrayPattern As Regex = New Regex("<key>OTA</key>")
                Dim OTAArrayDocument() As String = IO.File.ReadAllLines(DestinationFolder + "\" + BuildsLine.Trim.Replace("<key>", "").Replace("</key>", "") + ".xml")
                For Each OTAArrayLine In OTAArrayDocument
                    Dim OTAArrayMatch As Match = OTAArrayPattern.Match(OTAArrayLine)
                    If OTAArrayMatch.Success Then
                        Dim OTAArrayPosition As Integer = -1
                        For i As Integer = 0 To OTAArrayDocument.Length - 1
                            If OTAArrayDocument(i).Contains(OTAArrayLine) Then
                                OTAArrayPosition = i
                                Exit For
                            End If
                        Next

                        ' The line's number of <dict> is = position + 1
                        ' The line of OTAArray Number is = position

                        Dim OTAArrayTXT2Write As String = String.Empty
                        Dim OTAArrayOpenDict As Integer = 0
                        Dim OTAArrayCloseDict As Integer = 0
                        Dim OTAArrayCurrentLine As Integer = OTAArrayPosition
                        Do Until OTAArrayOpenDict = OTAArrayCloseDict And OTAArrayCloseDict <> 0 And OTAArrayOpenDict <> 0
                            OTAArrayCurrentLine = OTAArrayCurrentLine + 1
                            If OTAArrayDocument(OTAArrayCurrentLine).Trim.Contains("<array>") Then
                                OTAArrayOpenDict = OTAArrayOpenDict + 1
                            ElseIf OTAArrayDocument(OTAArrayCurrentLine).Trim.Contains("</array>") Then
                                OTAArrayCloseDict = OTAArrayCloseDict + 1
                            End If
                            OTAArrayTXT2Write = OTAArrayTXT2Write + Environment.NewLine + OTAArrayDocument(OTAArrayCurrentLine)
                        Loop
                        IO.File.WriteAllText(DestinationFolder + "\ota-array.txt", (OTAArrayTXT2Write))
                    End If
                Next

                If IO.File.Exists(DestinationFolder + "\ota-array.txt") Then

                    'making sure the first line is <dict> and the last line is </dict>
                    Dim File() As String = IO.File.ReadAllLines(DestinationFolder + "\ota-array.txt")
                    Do Until File(0).Contains("<dict>")
                        DeleteLine(DestinationFolder + "\ota-array.txt", 0)
                        File = IO.File.ReadAllLines(DestinationFolder + "\ota-array.txt")
                    Loop
                    File = IO.File.ReadAllLines(DestinationFolder + "\ota-array.txt")
                    Do Until File(File.Length - 1).Contains("</dict>")
                        DeleteLine(DestinationFolder + "\ota-array.txt", File.Length - 1)
                        File = IO.File.ReadAllLines(DestinationFolder + "\ota-array.txt")
                    Loop

                    Dim OTADocument() As String = IO.File.ReadAllLines(DestinationFolder + "\ota-array.txt")
                    Dim OTABlobsCount As Integer = 0
                    Dim OTADocumentLines As Integer = OTADocument.Length
                    Dim OTACurrentLine As Integer = 0
                    Dim OTATXT2Write As String = shshHeader
                    Dim OTAOpenDict As Integer = 0
                    Dim OTACloseDict As Integer = 0
                    Do Until OTACurrentLine = OTADocumentLines
                        OTATXT2Write = shshHeader
                        OTAOpenDict = 0
                        OTACloseDict = 0
                        Do Until OTAOpenDict = OTACloseDict And OTAOpenDict <> 0 And OTACloseDict <> 0
                            OTATXT2Write = OTATXT2Write + Environment.NewLine + OTADocument(OTACurrentLine)
                            If (OTADocument(OTACurrentLine).Trim).Contains("<dict>") Then
                                OTAOpenDict = OTAOpenDict + 1
                            ElseIf (OTADocument(OTACurrentLine).Trim).Contains("</dict>") Then
                                OTACloseDict = OTACloseDict + 1
                            End If
                            OTACurrentLine = OTACurrentLine + 1
                        Loop
                        OTATXT2Write = OTATXT2Write + Environment.NewLine + "</plist>"
                        IO.File.WriteAllText(DestinationFolder + "\" + BuildsLine.Trim.Replace("<key>", "").Replace("</key>", "") + "_OTA(" + OTABlobsCount.ToString + ").xml", OTATXT2Write)
                        OTABlobsCount = OTABlobsCount + 1
                    Loop
                End If

                Delete(False, DestinationFolder + "\ota-array.txt")
                Delete(False, DestinationFolder + "\" + BuildsLine.Trim.Replace("<key>", "").Replace("</key>", "") + ".xml")
            End If
        Next
        Delete(False, Infile)
    End Sub
End Class
