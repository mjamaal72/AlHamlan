Public Class CBAutoComplete
    Public Sub AutoComplete(cb As ComboBox, e As System.Windows.Forms.KeyPressEventArgs)
        Me.AutoComplete(cb, e, False)
    End Sub

    Public Sub AutoComplete(cb As ComboBox, e As System.Windows.Forms.KeyPressEventArgs, blnLimitToList As Boolean)
        Dim strFindStr As String = ""

        If (e.KeyChar = (Chr(8))) Then
            If cb.SelectionStart <= 1 Then
                cb.Text = ""
                Return
            End If

            If cb.SelectionLength = 0 Then
                strFindStr = cb.Text.Substring(0, cb.Text.Length - 1)
            Else
                strFindStr = cb.Text.Substring(0, cb.SelectionStart - 1)
            End If
        Else
            If cb.SelectionLength = 0 Then
                strFindStr = cb.Text + e.KeyChar
            Else
                strFindStr = cb.Text.Substring(0, cb.SelectionStart) + e.KeyChar
            End If
        End If

        Dim intIdx As Integer = -1

        ' Search the string in the ComboBox list.

        intIdx = cb.FindString(strFindStr)

        If intIdx <> -1 Then
            cb.SelectedText = ""
            cb.SelectedIndex = intIdx
            cb.SelectionStart = strFindStr.Length
            cb.SelectionLength = cb.Text.Length
            e.Handled = True
        Else
            e.Handled = blnLimitToList
        End If

    End Sub
End Class
