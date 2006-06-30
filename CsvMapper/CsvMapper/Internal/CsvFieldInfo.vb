Imports DotNetUC.CsvMapper

Namespace Internal

    ''' <summary>
    ''' Klasse zum Beschreiben von Informationen über die gemappten
    ''' Eigenschaften der Fachklasse. Dafür wird zum einen eine
    ''' <see cref="Reflection.PropertyInfo">PropertyInfo</see> 
    ''' und das gefundene <see cref="CsvAttribute">CsvAttribut</see> 
    ''' gespeichert.
    ''' </summary>
    Public Class CsvFieldInfo

        ''' <summary>
        ''' Erstellt eine neue Instanz für eine gefundene Eigenschaft
        ''' </summary>
        ''' <param name="initCsvAttribute">CsvAttribut, dass in der Klasse angegeben wurde</param>
        ''' <param name="initPropertyInfo">PropertyInfo für die Eigenschaft der Klasse</param>
        Public Sub New(ByVal initCsvAttribute As CsvAttribute, _
                       ByVal initPropertyInfo As System.Reflection.PropertyInfo)
            MyBase.New()

            _csvAttribute = initCsvAttribute
            _propertyInfo = initPropertyInfo
        End Sub

        ''' <summary>
        ''' Speichert das CsvAttribut
        ''' </summary>
        Private _csvAttribute As CsvAttribute

        ''' <summary>
        ''' Speichert die PropertyInfo
        ''' </summary>
        Private _propertyInfo As System.Reflection.PropertyInfo

        ''' <summary>
        ''' Gibt das CsvAttribut mit dem Namen der Spalte in der CSV Datei zurück.
        ''' </summary>
        ''' <value>CsvAttribute der Eigenschaft</value>
        ''' <returns>CsvAttribute der Eigenschaft</returns>
        Public ReadOnly Property CsvAttribute() As CsvAttribute
            Get
                Return _csvAttribute
            End Get
        End Property

        ''' <summary>
        ''' Gibt die PropertyInfo für die Eigenschaft des Objektes zurück.
        ''' </summary>
        ''' <value>PropertyInfo des Objektes</value>
        ''' <returns>PropertyInfo des Objektes</returns>
        Public ReadOnly Property PropertyInfo() As System.Reflection.PropertyInfo
            Get
                Return _propertyInfo
            End Get
        End Property

    End Class

End Namespace
