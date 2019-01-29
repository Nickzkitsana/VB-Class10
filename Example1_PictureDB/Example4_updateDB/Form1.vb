Imports System.Data
Imports System.Data.SqlClient

Public Class Form1

    Dim constr As String = "Server=(LocalDB)\MSSQLLocalDB;AttachDBFilename=D:\Northwind.mdf"
    Dim conn As New SqlConnection(constr)

    Private Sub btnShowData_Click(sender As Object, e As EventArgs) Handles btnShowData.Click
        Try
            conn.Open()
            Dim sql As String = "select categoryname , description 
                                 from categories
                                 where categoryid = " & TextBox1.Text

            Dim cmd As New SqlCommand(sql, conn)
            Dim adapter As New SqlDataAdapter(cmd)
            Dim data As New DataSet()
            adapter.Fill(data, "category")

            TextBox2.Text = data.Tables("category").Rows(0)("categoryname")
            TextBox3.Text = data.Tables("category").Rows(0)("description")
            conn.Close()
        Catch ex As Exception
            Dim message = String.Format("Error : {0}", ex.Message)
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Try
            conn.Open()
            Dim sql As String = "Update categories
                             set description = @description
                             where categoryname = @name"
            Dim cmd As New SqlCommand(sql, conn)
            cmd.Parameters.AddWithValue("description", TextBox3.Text)
            cmd.Parameters.AddWithValue("name", TextBox2.Text)

            If cmd.ExecuteNonQuery = -1 Then
                MessageBox.Show("ไม่สามารถอัพเดทข้อมูลได้", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show("อัพเดทข้อมูลเรียบร้อย", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TextBox1.Clear()
                TextBox2.Clear()
                TextBox3.Clear()
                TextBox1.Select()
            End If

            conn.Close()
        Catch ex As Exception
            Dim message = String.Format("Error : {0}", ex.Message)
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
