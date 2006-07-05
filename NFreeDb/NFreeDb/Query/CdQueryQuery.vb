Imports DotNetUC.NFreeDb.Collections

Namespace Query

    Public Class CdQueryQuery
        Implements IQuery

#Region " Schnittstelle IQuery "

        Private _parameter As FreeDbParameterCollection

        ''' <summary>
        ''' Gibt die Parameter der Abfrage zurück.
        ''' </summary>
        Public ReadOnly Property Parameter() As FreeDbParameterCollection Implements IQuery.Parameter
            Get
                Return _parameter
            End Get
        End Property

        Private _exception As FreeDbException

        ''' <summary>
        ''' Rückgabe der Server-Antwort
        ''' </summary>
        Public ReadOnly Property Exception() As FreeDbException Implements IQuery.Exception
            Get
                Return _exception
            End Get
        End Property

        Private _result As FreeDbCdCollection

        ''' <summary>
        ''' Parst ein Result
        ''' </summary>
        ''' <param name="raw">Antwort des Servers, die geparst werden soll</param>
        ''' <param name="version">Version des Protokolls</param>
        ''' <remarks>Es wird nur das Protokoll mit der Version 1 unterstützt.</remarks>
        Public Function ParseResult(ByVal raw As String, ByVal version As Integer) As Object Implements IQuery.ParseResult
            If version <> 1 Then Throw New VersionNotSupportedException()

            _rawResult = raw
            Dim rawLines() As String

            ' Fehlerinfo erzeugen
            rawLines = raw.Trim().Split(vbNewLine.ToCharArray, StringSplitOptions.RemoveEmptyEntries)
            _exception = FreeDbException.Create(rawLines(0))

            ' CD Informationen auslesen
            Dim res As New FreeDbCdCollection

            ' Parsen auf der Basis des Rückgabewertes
            Select Case _exception.Number
                Case 200
                    ' Ein Ergebnis gefunden
                    Dim tmp As New FreeDbCd

                    Dim lineParts() As String = rawLines(0).Split(" ".ToCharArray, StringSplitOptions.RemoveEmptyEntries)
                    tmp.Category = lineParts(1).Trim
                    tmp.CdId = lineParts(2).Trim

                    lineParts = rawLines(0).Substring(tmp.Category.Length + tmp.CdId.Length + 6).Split("/".ToCharArray)
                    tmp.Album = lineParts(1).Trim()
                    tmp.Artist = lineParts(0).Trim()

                    res.Add(tmp)

                Case 210
                    ' Mehrere Ergebnisse gefunden
                    Dim tmp As FreeDbCd
                    Dim lineParts() As String

                    If rawLines.Length >= 3 Then
                        For i As Integer = 1 To rawLines.Length - 2
                            tmp = New FreeDbCd
                            lineParts = rawLines(i).Split(" ".ToCharArray, StringSplitOptions.RemoveEmptyEntries)
                            tmp.Category = lineParts(0).Trim
                            tmp.CdId = lineParts(1).Trim

                            lineParts = rawLines(i).Substring(tmp.Category.Length + tmp.CdId.Length + 1).Split("/".ToCharArray)
                            tmp.Album = lineParts(1).Trim()
                            tmp.Artist = lineParts(0).Trim()

                            res.Add(tmp)
                        Next
                    End If

                Case 202
                    ' Nichts. Es wird kein Fehler geworfen, da "nur" kein Ergebnis gefunden wurde.

                Case 403, 409 ' DB Korrupt / Kein Handshake
                    Throw _exception

                Case Else
                    Throw _exception

            End Select

            ' Ergebnis zurückgeben
            Me._result = res
            Return res
        End Function

        Private _rawResult As String

        Public ReadOnly Property RawResult() As String Implements IQuery.RawResult
            Get
                Return _rawResult
            End Get
        End Property

#End Region

        Public ReadOnly Property Result() As FreeDbCdCollection
            Get
                Return _result
            End Get
        End Property

        Public Sub New(ByVal cdDrive As Char)
            ' Resulthelper initialisieren und defaults zuweisen
            _parameter = New FreeDbParameterCollection
            _parameter.Add("cddb")
            _parameter.Add("query")

            ' CDROM Zugriff initialisieren
            Dim cdAccessor As New DotNetUC.Ripper.CDDrive
            cdAccessor.Open(cdDrive)
            cdAccessor.LoadCD()
            cdAccessor.Refresh()
            cdAccessor.UnLockCD()

            ' Das CDROM stellt bereits einen Query-String zusammen. Splitten und hinzufügen
            _parameter.AddRange(cdAccessor.GetCDDBQuery().Split("+".ToCharArray, StringSplitOptions.RemoveEmptyEntries))
        End Sub

    End Class

End Namespace