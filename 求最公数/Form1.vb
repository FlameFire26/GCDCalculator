Public Class Form1
    Public a, b, c, d As Integer

    Public Sub Calculate()
        If IsNumeric(TextBox1.Text) And IsNumeric(TextBox2.Text) Then
            If TextBox1.Text = 0 Or TextBox2.Text = 0 Then
                TextBox3.Text = 0
                TextBox4.Text = 0
            Else
                a = CInt(TextBox1.Text)
                b = CInt(TextBox2.Text)
                Dim Product As Integer = a * b
                If a < b Then
                    a += b
                    b = a - b
                    a -= b
                End If
                Dim Remainder As Integer
                Remainder = a Mod b
                Do While Remainder <> 0
                    a = b
                    b = Remainder
                    Remainder = a Mod b
                Loop
                TextBox3.Text = b
                TextBox4.Text = Product / b
            End If
        Else
            MsgBox("请输入有效的数字", vbOKOnly, "提示")
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Calculate()
    End Sub
End Class
