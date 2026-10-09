Imports System.Windows.Forms

Module FxAndSub
    Public Sub ChangeValue(ByRef a As Double, ByRef b As Double)
        a += b
        b = a - b
        a -= b
    End Sub
    Public Sub ChangeValue(ByRef a As String, ByRef b As String)
        Dim c
        c = b
        b = a
        c = a
    End Sub
    Public Sub Chkdsk(Drive As String,
                      Optional Force As Boolean = False,
                      Optional View As Boolean = False,
                      Optional Recover As Boolean = False,
                      Optional X As Boolean = False)
        Dim Parameter = ""
        If Force Then Parameter += " /F"
        If View Then Parameter += " /V"
        If Recover Then Parameter += " /R"
        If X Then Parameter += " /X"
        Shell("runas /user:administrator cmd /k CHKDSK " & Drive & Parameter, AppWinStyle.NormalFocus)
    End Sub
    Public Function Between(n, a, b)
        Return If(n >= a And n < b, True, False)
    End Function
    Public Function InComboBoxItems(ComboBoxName As ComboBox, Find As String)
        For Each Item In ComboBoxName.Items
            If Find = Item Then
                Return True
                Exit Function
            End If
        Next
        Return False
    End Function
    Public Function RandomInteger(Min As Long, Max As Long)
        Return CInt(Math.Ceiling(Rnd() * Max)) + Min - 1
    End Function
    Public Sub ReadTXT(FilePath As String, ListBoxName As ListBox, Optional Delimiters As String = "vbCrLf", Optional ErrorPrompt As String = "")
        Try
            Using MyReader As New FileIO.TextFieldParser(FilePath)
                MyReader.TextFieldType = FileIO.FieldType.Delimited
                MyReader.SetDelimiters(Delimiters)
                Dim currentRow As String()
                While Not MyReader.EndOfData
                    Try
                        currentRow = MyReader.ReadFields()
                        Dim currentField As String
                        For Each currentField In currentRow
                            ListBoxName.Items.Add(currentField)
                        Next
                    Catch ex As FileIO.MalformedLineException
                        ListBoxName.Items.Add("第" & ex.Message & "行无效，将被跳过")
                    End Try
                End While
            End Using
        Catch exp As IO.FileNotFoundException
            MsgBox(ErrorPrompt)
        End Try
    End Sub
End Module