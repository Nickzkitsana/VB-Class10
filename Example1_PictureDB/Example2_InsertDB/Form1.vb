Imports System.Data
Imports System.Data.SqlClient

Public Class Form1

    Dim constr As String = "Server=(LocalDB)\MSSQLLocalDB;AttachDBFilename=D:\Northwind.mdf"
    Dim conn As New SqlConnection(constr)

    Private Sub showData()
        conn.Open()
        Dim sql As String = "select * from categories"
        Dim cmd As New SqlCommand(sql, conn)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim data As New DataSet()
        adapter.Fill(data, "category")
        DataGridView1.DataSource = data.Tables("category")
        conn.Close()
    End Sub

End Class
