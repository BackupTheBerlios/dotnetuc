Public Class EditDialog

#Region " Eigenschaft ConfigFile As String = Nothing "

    ''' <summary>
    ''' Speichert den Wert für die Eigenschaft ConfigFile.
    ''' Default ist Nothing
    ''' </summary>
    Private _ConfigFile As String = Nothing

    ''' <summary>
    ''' Eigenschaft ConfigFile
    ''' </summary>
    Public Property ConfigFile() As String
        Get
            Return (Me._ConfigFile)
        End Get
        Set(ByVal Value As String)
            Me._ConfigFile = Value
        End Set
    End Property

#End Region

    Private _list As IList

    Private Sub New()
        MyBase.New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal initConfigFile As String)
        Me.New()

        Me.Text = initConfigFile
        _ConfigFile = initConfigFile

        LoadData()
    End Sub

    Private Sub LoadData()
        _list = ConfigHelper.ReadList(_ConfigFile)
        KeyValue.HasChanges = False
        ReBind()
    End Sub

    Public Sub SaveData()
        Dim fi As New System.IO.FileInfo(ConfigHelper.GetConfiguration(_ConfigFile).FilePath)

        If fi.IsReadOnly Then
            If MessageBox.Show("Die Datei ist schreibgeschützt. Soll der Schreibschutz aufgehoben werden?", "Schreibgeschützt", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, 0) = Windows.Forms.DialogResult.Yes Then
                fi.IsReadOnly = False
            Else
                Exit Sub
            End If
        End If

        ConfigHelper.WriteList(_list, _ConfigFile)
    End Sub

    Private Sub ReBind()
        bndKeyValue.DataSource = _list
        bndKeyValue.ResetBindings(False)
    End Sub

    Private Sub toolInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolInfo.Click
        Dim frm As New AboutBox
        frm.ShowDialog()
    End Sub

    Private Sub toolReload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolReload.Click
        If Not KeyValue.HasChanges Then
            LoadData()
        ElseIf MessageBox.Show("Beim Neuladen der Konfigurationsdatei gehen alle Änderungen verloren.", "Neuladen", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, 0) = Windows.Forms.DialogResult.OK Then
            LoadData()
        End If
    End Sub

    Private Sub toolExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub

    Private Sub toolSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolSave.Click
        SaveData()
    End Sub

    Private Sub EditDialog_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim res As DialogResult
        If KeyValue.HasChanges Then

            res = MessageBox.Show("Sollen die Änderungen gespeichert werden?", "Speichern", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, 0)

            Select Case res
                Case Windows.Forms.DialogResult.Yes
                    SaveData()
                Case Windows.Forms.DialogResult.No
                    ' Nix!
                Case Else
                    e.Cancel = True
            End Select

        End If

    End Sub

    Private Sub toolLöschen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolLöschen.Click
        If bndKeyValue.Current Is Nothing Then Exit Sub
        If Not TypeOf bndKeyValue.Current Is KeyValue Then Exit Sub

        _list.Remove(bndKeyValue.Current)
        ReBind()
    End Sub

End Class