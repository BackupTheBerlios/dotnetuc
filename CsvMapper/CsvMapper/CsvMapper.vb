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
Public Class CsvMapper(Of keyType)

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

    Private _csvFileReader As CsvFileReader

    ''' <summary>
    ''' Name der CSV Datei
    ''' </summary>
    Public Property CsvFile() As String
        Get
            Return _csvFileReader.FileName
        End Get
        Set(ByVal value As String)
            _csvFileReader = New CsvFileReader(value)
        End Set
    End Property

    ''' <summary>
    ''' Erzeugt eine Liste von Fachobjekten und gibt diese zurück.
    ''' </summary>
    Public Function List() As IList
        Dim res As New List(Of keyType)
        Dim tmp As keyType
        Dim val As Object
        Dim cur As CsvFileItem

        Dim en As IEnumerator = _csvFileReader

        While en.MoveNext
            tmp = CType(Activator.CreateInstance(GetType(keyType)), keyType)

            cur = CType(en.Current, CsvFileItem)

            For Each cfi As CsvFieldInfo In Me._fieldInfos
                Try
                    val = cur.Item(cfi.CsvAttribute.csvColumn)
                Catch ex As Exception
                    If Not Me.IgnoreErrors Then Throw
                    val = Nothing
                End Try

                cfi.PropertyInfo.SetValue(tmp, val, Reflection.BindingFlags.Public Or Reflection.BindingFlags.SetField Or Reflection.BindingFlags.Instance, Nothing, Nothing, Globalization.CultureInfo.CurrentCulture)
            Next

            res.Add(tmp)
        End While

        en.Reset()

        Return res
    End Function

End Class
