
<AttributeUsage(AttributeTargets.Property, Inherited:=False, AllowMultiple:=False)> _
Public NotInheritable Class CsvAttribute
    Inherits System.Attribute

#Region " Constructor "

    Public Sub New(ByVal csvColumn As String)
        _csvColumn = csvColumn
    End Sub

#End Region

#Region " Fields "

    Private _csvColumn As String

#End Region

#Region " Properties "

    Public ReadOnly Property csvColumn() As String
        Get
            Return _csvColumn
        End Get
    End Property

#End Region

End Class
