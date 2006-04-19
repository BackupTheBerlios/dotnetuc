Public Class ConfiguratorApp

    Private Sub ÷ffnenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolDatei÷ffnen.Click
        If Me.ofdExecutable.ShowDialog() = Windows.Forms.DialogResult.OK Then
            For Each f As String In Me.ofdExecutable.FileNames
                Me.OpenFile(f)
            Next
        End If

    End Sub

    Public Sub OpenFile(ByVal fileName As String)
        If fileName = "" Then Exit Sub
        If Not System.IO.File.Exists(fileName) Then Exit Sub

        Dim frm As New EditDialog(fileName)
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub toolDateiBeenden_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolDateiBeenden.Click
        Me.Close()
    End Sub

    Private Sub toolHilfeInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolHilfeInfo.Click
        Dim frm As New Configurator.AboutBox
        frm.ShowDialog()
    End Sub

    Private Sub toolSaveAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolSaveAll.Click
        For Each f As Form In Me.MdiChildren
            If TypeOf f Is EditDialog Then
                CType(f, EditDialog).SaveData()
            End If
        Next
    End Sub

End Class
