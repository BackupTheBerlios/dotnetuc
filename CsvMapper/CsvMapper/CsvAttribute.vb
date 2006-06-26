
''' <summary>
''' Attribut zum Beschreiben des Mappings der CSV Spalten auf das Objekt.
''' <code>
'''&lt;CsvAttribute("AlterSpalte")&gt; _ <br />
'''Public Property Alter() As Integer<br />
'''    Get<br />
'''        Return _alter<br />
'''    End Get<br />
'''    Set(ByVal value As Integer)<br />
'''        _alter = value<br />
'''    End Set<br />
'''End Property
''' </code>
''' </summary>
<AttributeUsage(AttributeTargets.Property, Inherited:=False, AllowMultiple:=False)> _
Public NotInheritable Class CsvAttribute
    Inherits System.Attribute

    ''' <summary>
    ''' Legt eine neue Instanz eines CSV Attributes mit der CSV Spalteninformation
    ''' an.
    ''' </summary>
    ''' <param name="csvColumn">Name der CSV Spalte</param>
    Public Sub New(ByVal csvColumn As String)
        _csvColumn = csvColumn
    End Sub

    ''' <summary>
    ''' Hält den Wert für die Eigenschaft <see cref="csvColumn">CsvColumn</see>
    ''' </summary>
    ''' <remarks></remarks>
    Private _csvColumn As String

    ''' <summary>
    ''' Name der Spalte in der CSV Datei, mit dessen Wert die Eigenschaft des Objetkes
    ''' initialisiert wird.
    ''' </summary>
    ''' <value>Name der CSV Spalte</value>
    ''' <returns>Name der CSV Spalte</returns>
    ''' <remarks>Es wird ein <see cref="HeaderNotFoundException">Fehler</see> geworfen,
    ''' wenn in der CSV Datei die Spalte nicht gefunden werden kann.</remarks>
    Public ReadOnly Property csvColumn() As String
        Get
            Return _csvColumn
        End Get
    End Property

End Class
