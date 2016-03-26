Imports System.Collections.Specialized
Public Class Status
    Dim Network As New Network
    Dim Config As New Config
    Public Sub Online()
        Dim C As New NameValueCollection
        C.Add("id", My.Settings.id)
        C.Add("status", 1)
        Network.UploadValues(C, Config._Status)
    End Sub
    Public Sub Offline()
        Dim C As New NameValueCollection
        C.Add("id", My.Settings.id)
        C.Add("status", 0)
        Network.UploadValues(C, Config._Status)
    End Sub
End Class