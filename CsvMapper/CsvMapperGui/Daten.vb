Public Class Daten

    Private _name As String

    Private _alter As Integer

    <Softwarekueche.CsvMapper.CsvAttribute("Name")> _
    Public Property Name() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            _name = value
        End Set
    End Property

    <Softwarekueche.CsvMapper.CsvAttribute("Age")> _
    Public Property Alter() As Integer
        Get
            Return _alter
        End Get
        Set(ByVal value As Integer)
            _alter = value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return Me._name & " ist " & _alter & " Jahre alt"
    End Function

End Class
