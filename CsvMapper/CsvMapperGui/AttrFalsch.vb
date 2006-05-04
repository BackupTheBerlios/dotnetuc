Imports Softwarekueche.CsvMapper

Public Class AttrFalsch

    Private _name As String

    Private _kurz As String

    Private _alter As Integer

    <Softwarekueche.CsvMapper.CsvAttribute("GibbtEsNicht")> _
    Public Property Alter() As Integer
        Get
            Return _alter
        End Get
        Set(ByVal value As Integer)
            _alter = value
        End Set
    End Property
End Class
