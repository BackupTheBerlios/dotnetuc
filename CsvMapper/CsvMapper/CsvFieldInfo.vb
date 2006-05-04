Public Class CsvFieldInfo

    Public Sub New(ByVal initCsvAttribute As CsvAttribute, _
                   ByVal initPropertyInfo As System.Reflection.PropertyInfo)
        MyBase.New()

        _csvAttribute = initCsvAttribute
        _propertyInfo = initPropertyInfo
    End Sub

    Private _csvAttribute As CsvAttribute

    Private _propertyInfo As System.Reflection.PropertyInfo

    Public ReadOnly Property CsvAttribute() As CsvAttribute
        Get
            Return _csvAttribute
        End Get
    End Property

    Public ReadOnly Property PropertyInfo() As System.Reflection.PropertyInfo
        Get
            Return _propertyInfo
        End Get
    End Property

End Class
