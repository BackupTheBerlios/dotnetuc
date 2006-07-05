Public Class FreeDbInput

    Private Sub FreeDbInput_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ListBox1.DataSource = DotNetUC.Ripper.CDDrive.GetCDDriveLetters()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim cdDrive As New DotNetUC.Ripper.CDDrive

        cdDrive.Open(ListBox1.SelectedItem.ToString.ToCharArray()(0))
        cdDrive.LoadCD()
        cdDrive.Refresh()
        cdDrive.UnLockCD()

        TextBox1.Text = cdDrive.GetCDDBDiskID
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        ' Todo CategoryList
        Dim f As New DotNetUC.NFreeDb.FreeDb
        Dim q As New DotNetUC.NFreeDb.CategoryQuery

        f.Query(q)
        Dim lst As IList = q.Result

        For Each l As Object In lst
            Debug.WriteLine(l.ToString)
        Next

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim f As New DotNetUC.NFreeDb.FreeDb
        Dim q As New DotNetUC.NFreeDb.NativeCdQuery(ListBox1.SelectedItem.ToString.ToCharArray()(0))

        f.Query(q)

        ObjectView1.Object = q.Result.Item(0)
    End Sub
End Class