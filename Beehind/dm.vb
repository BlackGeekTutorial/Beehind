Imports System.Net
Imports System.ComponentModel

Public Class dm

    Public Shared url As String = ""
    Public Shared dpath As String = ""
    Public Shared formalname As String = ""
    Public Shared finished = False

    Public Sub resetstrings()
        url = ""
        dpath = ""
        formalname = ""
        finished = False
    End Sub
    Private Sub dm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        finished = False

        formalname = url.Substring(url.LastIndexOf("/") + 1)
        Label1.Text = "Downloading " + """" + formalname + """" + " from: " + """" + url + """"
        Dim client As New WebClient()
        AddHandler client.DownloadProgressChanged, AddressOf ShowDownloadProgress
        AddHandler client.DownloadFileCompleted, AddressOf OnDownloadComplete
        client.DownloadFileAsync(New Uri(url), dpath)
    End Sub

    Private Sub OnDownloadComplete(ByVal sender As Object, ByVal e As AsyncCompletedEventArgs)
        If Not e.Cancelled AndAlso e.Error Is Nothing Then
            finished = True
            Me.Close()
        Else
            MessageBox.Show("Download failed", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        Me.Close()
    End Sub

    Private Sub ShowDownloadProgress(ByVal sender As Object, ByVal e As DownloadProgressChangedEventArgs)
        ProgressBar1.Value = e.ProgressPercentage
        progress.Text = e.ProgressPercentage.ToString + "%"

    End Sub
End Class