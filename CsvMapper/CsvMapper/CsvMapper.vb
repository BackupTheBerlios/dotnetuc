Public Class CsvMapper(Of keyType)

    Public Sub New()
        MyBase.New()

        ' Initialisieren der Felder der Klasse
        readFieldInfo()
    End Sub

    Public Sub New(ByVal initCsvFile As String)
        Me.New()

        CsvFile = initCsvFile
    End Sub

    Private _ignoreErrors As Boolean = False

    Public Property IgnoreErrors() As Boolean
        Get
            Return _ignoreErrors
        End Get
        Set(ByVal value As Boolean)
            _ignoreErrors = value
        End Set
    End Property

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

    'Public ReadOnly Property Fields() As IList
    '    Get
    '        If _fieldInfos Is Nothing Then Return Nothing
    '        Return _fieldInfos
    '    End Get
    'End Property

    'Public ReadOnly Property Header() As IList
    '    Get
    '        If _csvFileReader Is Nothing Then Return Nothing
    '        Return _csvFileReader.Header
    '    End Get
    'End Property

    Public Property CsvFile() As String
        Get
            Return _csvFileReader.FileName
        End Get
        Set(ByVal value As String)
            _csvFileReader = New CsvFileReader(value)
        End Set
    End Property

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
