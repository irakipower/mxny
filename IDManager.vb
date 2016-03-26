Imports System.Text
Public Class IDManager
    Public Function GetRandomID(length As Integer) As String
        Dim StrBuilder As New StringBuilder
        Dim Chars As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890"
        Dim Rnd As New Random
        For i As Integer = 0 To length
            Dim nbr As Integer = Rnd.Next(0, Chars.Length)
            StrBuilder.Append(Chars.Substring(nbr, 1))
        Next
        Dim buff As Byte() = Encoding.ASCII.GetBytes(StrBuilder.ToString())
        Return Convert.ToBase64String(buff)
    End Function
    Public Sub GenerateID(length As Integer)
        MsgBox(My.Settings.id)
        If (Not My.Settings.id.Contains(Environment.UserName)) Then
            Dim id As String = Environment.UserName & "@" & GetRandomID(length)
            With My.Settings
                .id = id
                .Save()
            End With
        End If
    End Sub
End Class