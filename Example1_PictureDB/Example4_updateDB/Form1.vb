Imports System.Data
Imports System.Data.SqlClient

Public Class Form1

    Dim constr As String = "Server=(LocalDB)\MSSQLLocalDB;AttachDBFilename=D:\Northwind.mdf"
    Dim conn As New SqlConnection(constr)

End Class
