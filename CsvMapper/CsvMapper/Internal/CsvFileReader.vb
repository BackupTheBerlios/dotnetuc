Imports System.Data.Odbc

Namespace Internal

    ''' <summary>
    ''' Der CvsFileReader ist eine Klasse zum zeilenweisen Auslesen von CVS Dateien. Die
    ''' CVS Dateien müssen in der ersten Zeile die Spaltenüberschriften enthalten. Diese
    ''' Spaltenüberschriften werden beim Initialisieren ausgelesen und sind über 
    ''' die Eigenschaft Header zugreifbar.
    ''' Die CVS Datei wird mittels ADO.NET ausgelesen.
    ''' <code>
    ''' Dim _csvFileReader As CsvFileReader
    ''' _csvFileReader = New CsvFileReader(value)
    ''' 
    ''' Dim en As IEnumerator = _csvFileReader
    ''' Dim cur As CsvFileItem
    ''' 
    ''' While en.MoveNext
    '''     cur = CType(en.Current, CsvFileItem)
    ''' Wend
    ''' </code>
    ''' </summary>
    Public Class CsvFileReader
        Implements System.Collections.IEnumerable
        Implements System.Collections.IEnumerator

        ''' <summary>
        ''' Erstellt einen neuen CsvFileReader auf der Basis der übergebenen CSV Datei.
        ''' </summary>
        ''' <param name="initFileName">CVS Datei, auf der die Instanz basiert</param>
        Public Sub New(ByVal initFileName As String)
            Dim fi As New IO.FileInfo(initFileName)

            _fileName = initFileName
            _connectionString = "Driver={Microsoft Text Driver (*.txt; *.csv)};Dbq=" & fi.DirectoryName & ";"
            ReadHeader()
        End Sub

        ''' <summary>
        ''' Liest die Spaltenüberschriften aus der CSV Datei aus. Dazu wird ein DataTable
        ''' mit den Daten gefüllt und die Spalteninformationen mit Spaltennamen ausgelesen.
        ''' </summary>
        Private Sub ReadHeader()
            _header = New List(Of CsvHeaderInfo)
            Dim fi As New IO.FileInfo(_fileName)

            Dim csvConnection = New OdbcConnection(_connectionString)
            csvConnection.Open()

            Dim csvCommand As OdbcCommand
            csvCommand = csvConnection.CreateCommand()
            csvCommand.CommandText = "SELECT * FROM [" & fi.Name & "]"

            Dim dt As New DataTable("Csv")
            dt.Locale = Globalization.CultureInfo.CurrentCulture

            Dim da As New OdbcDataAdapter(csvCommand)
            da.Fill(dt)

            Dim index As Integer = 0

            Dim hdrTmp(dt.Columns.Count - 1) As String

            For Each c As DataColumn In dt.Columns
                _header.Add(New CsvHeaderInfo(index, c.ColumnName))
                _headerOrder &= ", [" & c.ColumnName & "]"
                hdrTmp(index) = c.ColumnName
                index += 1
            Next

            _headerOrder = _headerOrder.Substring(2)
            _headerArray = hdrTmp

            da = Nothing
            dt = Nothing
            csvCommand = Nothing
            csvConnection.Close()
        End Sub

        ''' <summary>
        ''' Gibt eine Liste aller Spaltenüberschriften als List(Of CsvHeaderInfo) zurück.
        ''' </summary>
        ''' <value>List(Of CsvHeaderInfo)</value>
        ''' <returns>Liste aller Spalteninformationen</returns>
        ''' <remarks></remarks>
        Public ReadOnly Property Header() As IList
            Get
                Return _header
            End Get
        End Property

        ''' <summary>
        ''' Speichert den Namen der CSV Datei
        ''' </summary>
        Private _fileName As String

        ''' <summary>
        ''' Speichert die Liste aller CSV Header
        ''' </summary>
        Private _header As List(Of CsvHeaderInfo)

        ''' <summary>
        ''' Speichert eine Liste aller Header als Array
        ''' </summary>
        Private _headerArray() As String

        ''' <summary>
        ''' Speichert eine Liste der Header als Zeichenfolge für das Select.
        ''' </summary>
        ''' <remarks>Dadurch ist der Index für die Spaltennamen beim 
        ''' DataReader bekannt.</remarks>
        Private _headerOrder As String

        ''' <summary>
        ''' ConnectionString für die CVS Datei.
        ''' </summary>
        Private _connectionString As String

        ''' <summary>
        ''' Gibt den Namen der CSV Datei zurück.
        ''' </summary>
        ''' <value>Name der CSV Datei</value>
        ''' <returns>Name der CSV Datei</returns>
        Public ReadOnly Property FileName() As String
            Get
                Return _fileName
            End Get
        End Property

        ''' <summary>
        ''' DataReader für den Enumerator
        ''' </summary>
        Private _dr As OdbcDataReader

        ''' <summary>
        ''' Öffnet den DataReader für den Enumerator
        ''' </summary>
        Private Sub OpenDataReader()
            Dim csvConnection = New OdbcConnection(_connectionString)
            Dim fi As New IO.FileInfo(_fileName)

            csvConnection.Open()
            Dim csvCommand As OdbcCommand

            csvCommand = csvConnection.CreateCommand()
            csvCommand.CommandText = "SELECT " & _headerOrder & " FROM [" & fi.Name & "]"

            _dr = csvCommand.ExecuteReader()
        End Sub

        ''' <summary>
        ''' Gibt die Datenzeile der CSV Datei als <see cref="CsvFileItem">CsvFileItem</see>
        ''' zurück.
        ''' </summary>
        ''' <value>Aktuelle Datenzeile</value>
        ''' <returns>Aktuelle Datenzeile</returns>
        Private ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
            Get
                If _dr Is Nothing Then OpenDataReader()

                Dim s(_dr.FieldCount - 1) As Object
                For i As Integer = 0 To _dr.FieldCount - 1
                    s(i) = _dr.Item(i)
                Next

                Return New CsvFileItem(s, _headerArray)
            End Get
        End Property

        ''' <summary>
        ''' Setzt den Zeiger auf den nächsten Datensatz
        ''' </summary>
        ''' <returns>True, wenn auf den nächsten Datensatz gesprungen werden konnte. Bei False
        ''' ist kein "Current()" vorhanden.</returns>
        Private Function MoveNext() As Boolean Implements System.Collections.IEnumerator.MoveNext
            If _dr Is Nothing Then OpenDataReader()
            Return _dr.Read()
        End Function

        ''' <summary>
        ''' Setzt den DataReader zurück.
        ''' </summary>
        Private Sub Reset() Implements System.Collections.IEnumerator.Reset
            If Not _dr Is Nothing Then _dr.Close()
            _dr = Nothing
        End Sub

        Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return Me
        End Function
    End Class

End Namespace