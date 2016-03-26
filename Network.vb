Imports System.Collections.Specialized
Imports System.Net
Imports System.IO
Public Class Network
    Public Sub UploadValues(c As NameValueCollection, Url As String)
        Dim Client As New WebClient
        Dim respByte() As Byte
        Try
            respByte = Client.UploadValues(Url, c)
        Catch ex As Exception
        End Try
    End Sub
    Public Function GetFileContents(url As String) As String
        Dim output As String = Nothing
        Try
            Dim hwreq As HttpWebRequest = WebRequest.Create(url)
            Dim hwresp As HttpWebResponse = hwreq.GetResponse
            Dim stream As Stream = hwresp.GetResponseStream
            Dim stream_reader As New StreamReader(stream)
            output = stream_reader.ReadToEnd
        Catch ex As Exception
            output = Nothing 'Nothing = ErrorCode
        End Try
        Return output
    End Function
End Class
