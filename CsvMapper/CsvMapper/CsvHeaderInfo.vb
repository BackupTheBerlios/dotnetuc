Public Class CsvHeaderInfo

    Public Sub New(ByVal initIndex As Integer, ByVal initHeader As String)
        _index = initIndex
        _header = initHeader
    End Sub

    Private _index As Integer

    Private _header As String

    Public Overrides Function ToString() As String
        Return _index & " -> " & _header
    End Function

End Class
