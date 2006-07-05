Imports DotNetUC.NFreeDb.Collections

Namespace Query

    ''' <summary>
    ''' Abfrage für das Kommando: <b>cddb lscat</b>.
    ''' </summary>
    Public Class LscatQuery
        Implements IQuery

#Region " Schnittstelle IQuery "

        ''' <summary>
        ''' Auslesen der Parameter für die Abfrage: "cddb,lscat"
        ''' </summary>
        Public ReadOnly Property Parameter() As FreeDbParameterCollection Implements IQuery.Parameter
            Get
                Dim res As New FreeDbParameterCollection
                res.Add("cddb")
                res.Add("lscat")
                Return res
            End Get
        End Property

        ''' <summary>
        ''' Attribut für die Eigenschaft "Exception"
        ''' </summary>
        ''' <remarks></remarks>
        Private _exception As FreeDbException

        ''' <summary>
        ''' Eigenschaft zum Zugriff auf den Response-Code des Servers.
        ''' </summary>
        Public ReadOnly Property Exception() As FreeDbException Implements IQuery.Exception
            Get
                Return _exception
            End Get
        End Property

        ''' <summary>
        ''' Ergebnis der Abfrage.
        ''' </summary>
        Private _result As Collections.FreeDbCategoryCollection

        ''' <summary>
        ''' Parst das Ergebnis 
        ''' </summary>
        ''' <param name="raw">Ergebnis, das direkt vom dem Service an den Client gesendet wurde.</param>
        Public Function ParseResult(ByVal raw As String, ByVal version As Integer) As Object Implements IQuery.ParseResult
            If version <> 1 Then Throw New VersionNotSupportedException()

            _rawResult = raw

            Dim res As New Collections.FreeDbCategoryCollection
            Dim rawLines() As String
            rawLines = raw.Split(vbNewLine.ToCharArray, StringSplitOptions.RemoveEmptyEntries)

            ' Exception füllen
            _exception = FreeDbException.Create(rawLines(0))

            Select Case _exception.Number
                Case 210
                    ' Kategorien auslesen, wenn mind. 3 Zeilen (Header und "." fallen weg)
                    If rawLines.Length >= 3 Then
                        For i As Integer = 1 To rawLines.Length - 2
                            res.Add(rawLines(i))
                        Next
                    End If

                Case Else
                    Throw _exception
            End Select

            Me._result = res
            Return res
        End Function

        ''' <summary>
        ''' Speichert die direkte Rückgabe des Web Services.
        ''' </summary>
        Private _rawResult As String

        ''' <summary>
        ''' Property zum Zugrif auf den geparsten String.
        ''' </summary>
        Public ReadOnly Property RawResult() As String Implements IQuery.RawResult
            Get
                Return _rawResult
            End Get
        End Property

#End Region

#Region " Eigenschaft 'Result' "

        ''' <summary>
        ''' Gibt eine Liste aller FreeDb Kategorien in einer List(Of String) zurück.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property Result() As Collections.FreeDbCategoryCollection
            Get
                Return _result
            End Get
        End Property

#End Region

    End Class

End Namespace