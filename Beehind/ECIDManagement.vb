Imports Beehind.Common_Definitions
Imports Beehind.Common_Functions
Imports System.IO


Public Class ECIDManagement

    Public Shared CurrentDecimalECID As String = String.Empty
    Public Shared CurrentHexECID As String = String.Empty
    Public Shared CurrentBinaryECID As Byte()
    Public Shared CurrentBase64ECID As String = String.Empty

    Public Shared Function IsHex(ByVal Expression As String) As Boolean

        On Error GoTo ErrorHandler

        Dim lonValue As Long

        'Remove ending & if present
        If Right$(Expression, 1) = "&" Then
            Expression = Left$(Expression, Len(Expression) - 1)
        End If

        'Check if starting with &H
        If LCase$(Left$(Expression, 2)) = "&h" Then
            lonValue = CLng(Expression)
        Else
            lonValue = CLng("&H" & Expression)
        End If

        IsHex = True

        Exit Function

ErrorHandler:

        If Err.Number = 6 Then 'Overflow
            IsHex = True 'Still a number, just too big
        End If

        Exit Function

    End Function

    Public Shared Function IsHexECID(NumIn As String) As Boolean
        Dim decNum, hexNum As Boolean
        Dim f As String = NumIn
        If NumIn <> "" Then
            decNum = NumIn.All(Function(c) Char.IsDigit(c))
            hexNum = (NumIn.Length Mod 2 = 0) AndAlso NumIn.All(Function(c) "0123456789abcdefABCDEF".Contains(c))
        End If
        'MessageBox.Show("Possible dec: " & decNum & " - possible hex: " & hexNum)
        Return hexNum
    End Function

    Public Shared Function OnlyHexInString(test As String) As Boolean
        ' For C-style hex notation (0xFF) you can use @"\A\b(0[xX])?[0-9a-fA-F]+\b\Z"
        Return System.Text.RegularExpressions.Regex.IsMatch(test, "\A\b[0-9a-fA-F]+\b\Z")
    End Function


    Public Shared Sub ECIDParser(ECID As String)
        If IsHexECID(ECID) = True Then
            If ECID.StartsWith("0x") Then
                ECID = ECID.Replace("0x", "")
            End If
            'ECID is in it's Hexadecimal Format
            CurrentHexECID = ECID
            CurrentBase64ECID = HexECIDConverter(ECID, True, False, False)
            CurrentBinaryECID = HexECIDConverter(ECID, False, True, False)
            CurrentDecimalECID = HexECIDConverter(ECID, False, False, True)
        ElseIf ECID.Length = 8 Then
        'ECID is in it's base64 format
        CurrentBase64ECID = ECID
        CurrentHexECID = base64ECIDConverter(ECID, False, True, False, False)
        CurrentBinaryECID = base64ECIDConverter(ECID, False, False, False, True)
        CurrentDecimalECID = base64ECIDConverter(ECID, True, False, False, False)
        Else
        'ECID is in it's decimal format
        CurrentDecimalECID = ECID
        CurrentBase64ECID = DecimalECIDConverter(ECID, False, False, False, True)
        CurrentHexECID = DecimalECIDConverter(ECID, True, False, False, False)
        CurrentBinaryECID = DecimalECIDConverter(ECID, False, False, True, False)
        End If
    End Sub

    Public Shared Function GrabECIDFromBase64Blob(Base64Blob As String)

        Dim PreviousCharactr As Integer = 15
        Dim NextCharacter As Integer = 8
        Dim Base64ECID As String = Base64Blob.Substring(PreviousCharactr + 1, NextCharacter)

        Return Base64ECID
    End Function

    Public Shared Function DecimalECIDConverter(DecECID As String, ReturnHexECID As Boolean, ReturnHexReversedECID As Boolean, ReturnByteArrayECID As Boolean, Returnbase64ECID As Boolean)
        Dim DecimalECID As Long = CLng(DecECID)
        Dim HexECID As String = DecimalNumberToHexNumber(DecimalECID)
        If HexECID.Length Mod 2 <> 0 Then
            HexECID = "0" + HexECID
        End If
        If ReturnHexECID = True Then
            Return HexECID
        End If
        Dim ECIDHexOriginalBytes = Enumerable.Range(0, HexECID.Length \ 2).[Select](Function(i) HexECID.Substring(i * 2, 2))
        Dim ECIDHexReversedBytes = ECIDHexOriginalBytes.Reverse()
        Dim reversedhexecid As String = String.Empty
        For Each hbyte In ECIDHexReversedBytes
            reversedhexecid = reversedhexecid + hbyte
        Next
        If ReturnHexReversedECID = True Then
            Return reversedhexecid
        End If
        Dim BinaryECID As Byte() = ConvertHexStringToByteArray(reversedhexecid)
        If ReturnByteArrayECID Then
            Return BinaryECID
        End If
        Dim base64EncodedECID = Convert.ToBase64String(BinaryECID)
        If Returnbase64ECID = True Then
            Return base64EncodedECID.Replace("=", "")
        End If
    End Function

    Public Shared Function base64ECIDConverter(base64ECID As String, ReturnDecECID As Boolean, ReturnHexECID As Boolean, ReturnHexReversedECID As Boolean, ReturnByteArrayECID As Boolean)

        Dim BinaryECID As Byte() = Convert.FromBase64String(base64ECID) 'OK
        If ReturnByteArrayECID = True Then
            Return BinaryECID
        End If


        Dim ReversedHexECID As String = ByteArrayToHexString(BinaryECID) 'OK
        If ReturnHexReversedECID = True Then
            Return ReversedHexECID
        End If
        
        Dim ReversedHexECIDBytes = Enumerable.Range(0, ReversedHexECID.Length \ 2).[Select](Function(i) ReversedHexECID.Substring(i * 2, 2))
        Dim OriginalHexECIDBytes = ReversedHexECIDBytes.Reverse()
        Dim HexECID As String = String.Empty
        For Each HByte In OriginalHexECIDBytes
            HexECID = HexECID + HByte
        Next
        If ReturnHexECID = True Then
            Return HexECID
        End If

        Dim DecECID = Val("&H" & HexECID)
        If ReturnDecECID = True Then
            Return DecECID.ToString
        End If
    End Function

    Public Shared Function HexECIDConverter(HexECID As String, Returnbase64ECID As Boolean, ReturnBinaryECID As Boolean, ReturnDecECID As Boolean)
        Dim DecECID = Val("&H" & HexECID)
        If ReturnDecECID = True Then
            Return DecECID.ToString
        End If

        If ReturnBinaryECID = True Then
            Return DecimalECIDConverter(DecECID, False, False, True, False)
        ElseIf Returnbase64ECID = True Then
            Return DecimalECIDConverter(DecECID, False, False, False, True)
        End If
    End Function
End Class
