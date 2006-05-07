''' <summary>
''' Eine HeaderNotFoundException ist eine <see cref="System.Exception">Exception</see>.
''' Der Fehler wird ausgelöst, wenn eine Spalte in der CVS Datei nicht gefunden werden kann,
''' obwohl diese im Objekt angegeben wurde.
''' </summary>
''' <remarks>
''' Die Fehlermeldung kann im <see cref="CsvMapper(Of T)">CsvMapper</see>
''' mit der Eigenschaft "IgnoreErrors" unterdrückt werden.
''' </remarks>
Public Class HeaderNotFoundException
    Inherits System.Exception

    ''' <summary>
    ''' Erzeugt eine neue Fehlermeldung mit der angegebenen Fehlermeldung.
    ''' </summary>
    ''' <param name="message">Fehlermeldung</param>
    Public Sub New(ByVal message As String)
        MyBase.New(message)
    End Sub

End Class
