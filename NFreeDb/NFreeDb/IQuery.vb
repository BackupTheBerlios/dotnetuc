Imports DotNetUC.NFreeDb.Collections

''' <summary>
''' Schnittstelle für die Parameter von Abfragen an eien FreeDb Service.
''' </summary>
Public Interface IQuery

    ''' <summary>
    ''' Property zum Auslesen der Parameter für die spezielle Abfrage
    ''' </summary>
    ReadOnly Property Parameter() As FreeDbParameterCollection

    ''' <summary>
    ''' Zugriff auf die Antwort des Servers. Die Exception wird ausgelößt, wenn
    ''' ein Fehler ausgetreten oder die Antwort nicht geparst werden konnte.
    ''' </summary>
    ReadOnly Property Exception() As FreeDbException

    ''' <summary>
    ''' Parsen eines Ergebnisses von Service.
    ''' </summary>
    ''' <param name="raw">Antwortstring des Servers</param>
    ''' <param name="version">Version des Protokolls</param>
    Function ParseResult(ByVal raw As String, ByVal version As Integer) As Object

    ''' <summary>
    ''' Rückgabe des nativen geparsten Ergebnisses.
    ''' </summary>
    ReadOnly Property RawResult() As String

End Interface
