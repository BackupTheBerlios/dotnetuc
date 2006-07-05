
Namespace Forms

    Public Class FreeDbCdChooserDialog

        Public Property SelectedItem() As FreeDbCd
            Get
                Return CType(lsbCds.SelectedItem, FreeDbCd)
            End Get
            Set(ByVal value As FreeDbCd)
                lsbCds.SelectedItem = value
            End Set
        End Property

        Private _FreeDb As IFreeDb

        Public Property FreeDb() As IFreeDb
            Get
                Return _FreeDb
            End Get
            Set(ByVal value As IFreeDb)
                _FreeDb = value
                BindData()
            End Set
        End Property


        Private _items As List(Of FreeDbCd)

        Public Property Items() As List(Of FreeDbCd)
            Get
                Return _items
            End Get
            Set(ByVal value As List(Of FreeDbCd))
                _items = value
                BindData()
            End Set
        End Property

        Private Sub BindData()
            lsbCds.DataSource = _items

            oCdView.Visible = Not (_FreeDb Is Nothing)
        End Sub

        Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Close()
        End Sub

        Private Sub btnAbort_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Close()
        End Sub

        Private Sub lsbCds_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lsbCds.DoubleClick
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Close()
        End Sub

        Private Sub lsbCds_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lsbCds.SelectedIndexChanged
            Dim q As New Query.ReadQuery(CType(lsbCds.SelectedItem, FreeDbCd).CdId, CType(lsbCds.SelectedItem, FreeDbCd).Category)
            _FreeDb.Query(q)
            oCdView.FreeDbCd = q.Result
        End Sub
    End Class

End Namespace
