Imports CrystalDecisions.Windows.Forms
Imports Microsoft.VisualBasic.Devices

Public Class CRViewer
    Dim AccessVerify As New VerifyAccess

    Private Sub CRViewer_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If (e.Control And e.KeyCode = Keys.P) Or (e.Alt And e.KeyCode = Keys.P) Then
            CrystalReportViewer1.PrintReport()
        End If
    End Sub

    Private Sub CRViewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AccessVerify.Themeing(Me, MainMDI.lbltheme.Text)
        AccessVerify.LoadingFrm(False)
    End Sub

End Class