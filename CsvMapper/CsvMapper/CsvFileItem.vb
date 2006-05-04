Public Class CsvFileItem

    Public Sub New(ByVal initData() As Object, ByVal initHeader() As String)
        _data = initData
        _header = initHeader
    End Sub

    Private _data() As Object

    Private _header() As String

    Public ReadOnly Property Item(ByVal index As Integer) As Object
        Get
            Try
                If TypeOf _data(index) Is DBNull Then Return Nothing

                Return _data(index)
            Catch ex As Exception
                Throw
            End Try
        End Get
    End Property

    Public ReadOnly Property Item(ByVal index As String) As Object
        Get
            Dim ind As Integer = Array.IndexOf(_header, index)
            If ind = -1 Then
                Throw New HeaderNotFoundException("Header not found")
            End If

            Return Item(ind)
        End Get
    End Property

End Class
