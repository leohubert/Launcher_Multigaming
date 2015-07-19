Imports System.Net
Imports System.ComponentModel
Imports System.IO
Imports System.Net.Mail
Public Class Form1

    Dim update = ""
    Dim site = ""
    Public dlauncher As String = Application.StartupPath & "\" ' Ne pas changer !! 


    Dim sitea
    Dim updatea


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Computer.FileSystem.FileExists(dlauncher & "update.txt") Then
            update = My.Computer.FileSystem.ReadAllText(dlauncher & "update.txt")
        Else
            updatea = "false"
        End If

        If My.Computer.FileSystem.FileExists(dlauncher & "site.txt") Then
            site = My.Computer.FileSystem.ReadAllText(dlauncher & "site.txt")
        Else
            sitea = "false"
        End If

        If sitea And updatea = "false" Then
            MsgBox("Une erreur est survenue ! " & vbNewLine & "Contacter MrDarkSkil nomé Jason Statam pour voir avec lui le problème .")
        End If


        Dim Client As WebClient = New WebClient

        AddHandler Client.DownloadProgressChanged, AddressOf client_ProgressChanged

        AddHandler Client.DownloadFileCompleted, AddressOf client_DownloadCompleted

        Client.DownloadFileAsync(New Uri(site), update)





    End Sub

    Private Sub client_ProgressChanged(ByVal sender As Object, ByVal e As DownloadProgressChangedEventArgs)

        Dim bytesIn As Double = Double.Parse(e.BytesReceived.ToString())

        Dim totalBytes As Double = Double.Parse(e.TotalBytesToReceive.ToString())

        Dim percentage As Double = bytesIn / totalBytes * 100

        ProgressBar1.Value = Int32.Parse(Math.Truncate(percentage).ToString())


    End Sub

    Private Sub client_DownloadCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs)
        If My.Computer.FileSystem.FileExists(update) Then
            Process.Start(update)
            Me.Close()
        End If
    End Sub
End Class
