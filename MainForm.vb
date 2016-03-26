Imports System.IO
Imports System.Net, System.Net.Sockets
Imports System.Text
Imports System.Collections.Specialized
Imports System.Threading
Public Class MainForm
    Dim IDManager As New IDManager
    Dim Status As New Status
    Dim Commander As New Commander
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        IDManager.GenerateID(8)
        Status.Online()
        Commander.Update("Is Online!")
        Commander.EnableReader()
    End Sub
    Private Sub MainForm_Closing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Status.Offline()
    End Sub
End Class