Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim conStr As String = "Server=(LocalDB)\MSSQLLocalDB;AttachDBFilename=D:\Northwind.mdf"
        Dim conn As New SqlConnection(conStr)
        conn.Open()

        Dim sql As String = "select Picture from Categories 
                             where CategoryID = " & TextBox1.Text
        Dim cmd As New SqlCommand(sql, conn)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim data As New DataSet()
        adapter.Fill(data, "pic")

        Try
            Dim pic() As Byte = data.Tables("pic").Rows(0)("Picture")
            Dim streamPicture As New MemoryStream(pic)

            streamPicture.Write(pic, 78, pic.Length - 78) 'Only Northwind Database
            PictureBox1.Image = Image.FromStream(streamPicture)
        Catch ex As Exception
            MessageBox.Show("ไม่พบข้อมูล", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox1.Clear()
            TextBox1.Select()
            PictureBox1.Image = Nothing
        End Try

        conn.Close()
    End Sub
End Class
