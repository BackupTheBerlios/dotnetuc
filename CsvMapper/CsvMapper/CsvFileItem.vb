''' <summary>
''' Repräsentiert eine Datenzeile in einer CSV Datei. Zusätzlich werden die 
''' Spaltenüberschriften gespeichert. Dadurch ist ein Zugriff über den 
''' Index und den Spaltennamen möglich.
''' </summary>
Public Class CsvFileItem

    ''' <summary>
    ''' Erstellt eine neue Datenzeile aus dem den übergebenen Spaltenheadern
    ''' und der Daten.
    ''' </summary>
    ''' <param name="initData">Daten aus dem CsvFileReader.DataReader</param>
    ''' <param name="initHeader">Spaltenüberschriften aus der CSV Datei</param>
    Public Sub New(ByVal initData() As Object, ByVal initHeader() As String)
        _data = initData
        _header = initHeader
    End Sub

    ''' <summary>
    ''' Speichert die Daten
    ''' </summary>
    Private _data() As Object

    ''' <summary>
    ''' Speichert die Header
    ''' </summary>
    Private _header() As String

    ''' <summary>
    ''' Gibt ein Datum aus den Daten zurück.
    ''' </summary>
    ''' <param name="index">Index des Feldes</param>
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

    ''' <summary>
    ''' Gibt ein Datum aus den Daten zurück.
    ''' </summary>
    ''' <param name="index">Spaltenüberschrift des Feldes</param>
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
