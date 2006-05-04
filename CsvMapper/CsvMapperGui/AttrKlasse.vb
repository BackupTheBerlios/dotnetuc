Imports Softwarekueche.CsvMapper

Public Class AttrKlasse

    Private _name As String

    Private _kurz As String

    <CsvAttribute("Name")> _
    Public Property Kurz()
        Get
            Return _kurz
        End Get
        Set(ByVal value)
            _kurz = value
        End Set
    End Property

    Private _alter As Integer

    Public Property Alter() As Integer
        Get
            Return _alter
        End Get
        Set(ByVal value As Integer)
            _alter = value
        End Set
    End Property
End Class
