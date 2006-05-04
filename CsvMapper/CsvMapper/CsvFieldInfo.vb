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

    Public Overrides Function ToString() As String
        If _propertyInfo Is Nothing Then
            Return _csvAttribute.csvColumn & " -> <NN>"
        ElseIf _csvAttribute Is Nothing Then
            Return "<NN> -> " & _propertyInfo.Name
        Else
            Return _csvAttribute.csvColumn & " -> " & _propertyInfo.Name
        End If
    End Function

End Class
