Imports Softwarekueche.CsvMapper.Internal

''' <summary>
''' Die Klasse CsvMapper ist die Klasse zum Anlegen von Objekten auf der Basis
''' einer CSV Datei. Dazu wird als Typ die Klasse angegeben, welche die
''' <see cref="CsvAttribute">CsvAttribute enthält.</see>
''' Beim Anlegen einer Klasse wird das Fachobjekt analysiert und die 
''' Mapping-Informationen des Fachobjektes.
''' <code>
''' Dim cm As New CsvMapper(Of AttrKlasse)("Test.csv")
''' Dim lst As IList = cm.List
''' 
''' For Each o As AttrKlasse In lst
'''     Debug.WriteLine(o.ToString())
''' Next
''' </code>
''' </summary>
''' <typeparam name="keyType">Typ, von dem eine Liste von Objekten aus der 
''' CSV Datei erzeugt werden soll.</typeparam>
Public Class CsvPersister(Of keyType)

    ''' <summary>
    ''' Erstellt eine neue Instanz und analysiert den KeyType.
    ''' </summary>
    Public Sub New()
        MyBase.New()

        ' Initialisieren der Felder der Klasse
        readFieldInfo()
    End Sub

    ''' <summary>
    ''' Erstellt eine neue Instanz und analysiert den KeyType.
    ''' </summary>
    ''' <param name="initCsvFile">CSV Datei, welche die Daten enthält.</param>
    Public Sub New(ByVal initCsvFile As String)
        Me.New()

        CsvFile = initCsvFile
    End Sub

    ''' <summary>
    ''' Speichert den Wert von IgnoreErrors
    ''' </summary>
    Private _ignoreErrors As Boolean = False

    ''' <summary>
    ''' Gibt an, ob Mapping-Fehler zu einer Exception führen
    ''' </summary>
    Public Property IgnoreErrors() As Boolean
        Get
            Return _ignoreErrors
        End Get
        Set(ByVal value As Boolean)
            _ignoreErrors = value
        End Set
    End Property

    ''' <summary>
    ''' Liest aus der Fachklasse die CsvAttrubute
    ''' </summary>
    Private Sub readFieldInfo()
        ' Initialisieren der Felder
        _fieldInfos = New List(Of CsvFieldInfo)
        Dim pis() As System.Reflection.PropertyInfo
        Dim cas() As Object
        Dim cfi As CsvFieldInfo

        ' Auslesen der Properties
        pis = GetType(keyType).GetProperties

        For Each pi As System.Reflection.PropertyInfo In pis

            ' Auslesen der Attribute
            cas = pi.GetCustomAttributes(True)

            For Each ca As Object In cas

                ' CsvAttribute der FieldInfo-Liste hinzufügen
                If TypeOf ca Is CsvAttribute Then
                    cfi = New CsvFieldInfo(ca, pi)
                    _fieldInfos.Add(cfi)
                End If

            Next

        Next

    End Sub

    Private _fieldInfos As List(Of CsvFieldInfo)

    Private _csvFileWriter As CsvFileWriter

    ''' <summary>
    ''' Name der CSV Datei
    ''' </summary>
    Public Property CsvFile() As String
        Get
            Return _csvFileWriter.FileName
        End Get
        Set(ByVal value As String)
            _csvFileWriter = New CsvFileWriter(value)
        End Set
    End Property

    ''' <summary>
    ''' Persistiert eine Liste von Fachobjekten.
    ''' </summary>
    Public Sub Persist(ByVal list As List(Of keyType))
        If _csvFileWriter Is Nothing Then Throw New InvalidCsvFileException("Keine CSV Datei angegeben")

        For Each cfi As CsvFieldInfo In _fieldInfos
            _csvFileWriter.WriteHeader(cfi.CsvAttribute.csvColumn)
        Next

        For Each t As keyType In list

            For Each cfi As CsvFieldInfo In _fieldInfos
                Dim value As Object

                value = cfi.PropertyInfo.GetValue(t, Nothing)

                _csvFileWriter.WriteField(value, cfi.PropertyInfo.PropertyType)

            Next

            _csvFileWriter.WriteItem()

        Next

        _csvFileWriter.Flush()

    End Sub

End Class
