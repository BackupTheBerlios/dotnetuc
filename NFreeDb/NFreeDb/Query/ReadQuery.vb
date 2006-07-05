Imports DotNetUC.NFreeDb.Collections

Namespace Query

    Public Class ReadQuery
        Implements IQuery

#Region " Schnittstelle IQuery "

        Private _parameter As FreeDbParameterCollection

        ''' <summary>
        ''' Gibt eine Liste aller Parameter für die Abfrage zurück.
        ''' </summary>
        Public ReadOnly Property Parameter() As FreeDbParameterCollection Implements IQuery.Parameter
            Get
                Return _parameter
            End Get
        End Property

        Private _exception As FreeDbException

        ''' <summary>
        ''' Gibt die Antwort des Servers zurück.
        ''' </summary>
        Public ReadOnly Property Exception() As FreeDbException Implements IQuery.Exception
            Get
                Return _exception
            End Get
        End Property

        Private _result As FreeDbCd

        ''' <summary>
        ''' Parst ein Ergebnis in die richtigen Klassen.
        ''' </summary>
        ''' <param name="raw">Antwort des Services</param>
        ''' <param name="version">Version des Protokolls</param>
        Public Function ParseResult(ByVal raw As String, ByVal version As Integer) As Object Implements IQuery.ParseResult
            If version <> 1 Then Throw New VersionNotSupportedException()

            _rawResult = raw
            Dim rawLines() As String

            ' Fehlerinfo erzeugen
            rawLines = raw.Trim().Split(vbNewLine.ToCharArray, StringSplitOptions.RemoveEmptyEntries)
            _exception = FreeDbException.Create(rawLines(0))

            ' CD Informationen auslesen
            Dim res As New FreeDbCd
            Dim titleFound As Boolean = False

            ' Parsen auf der Basis des Rückgabewertes
            Select Case _exception.Number
                Case 210 ' Found exact match
                    Dim lineParts() As String

                    If rawLines.Length >= 3 Then
                        For i As Integer = 1 To rawLines.Length - 2
                            If rawLines(i) Is Nothing OrElse rawLines(i).ToString = "" Then Continue For
                            If rawLines(i).Trim.StartsWith("#") Then Continue For

                            lineParts = rawLines(i).Split("=".ToCharArray, StringSplitOptions.RemoveEmptyEntries)
                            If lineParts.Length < 2 Then Continue For

                            If rawLines(i).StartsWith("DISCID") Then
                                res.CdId = lineParts(1).Trim

                            ElseIf rawLines(i).StartsWith("DTITLE") Then
                                Dim splitTmp() As String = lineParts(1).Trim.Split("/".ToCharArray, StringSplitOptions.RemoveEmptyEntries)
                                If splitTmp.Length >= 2 Then
                                    res.Artist = splitTmp(0).Trim
                                    res.Album = splitTmp(1).Trim
                                    titleFound = True

                                ElseIf titleFound Then
                                    ' TODO Erst alle DTITLE sammeln oder
                                    ' entsprechend Adden (text&=split(0))
                                    ' DTITLE kann mehrzeilig sein.
                                    res.Album &= lineParts(1)

                                End If

                            ElseIf rawLines(i).StartsWith("DYEAR") Then
                                res.Year = Integer.Parse(lineParts(1).Trim)

                            ElseIf rawLines(i).StartsWith("DGENRE") Then
                                res.Genre = lineParts(1).Trim

                            ElseIf rawLines(i).StartsWith("TTITLE") Then
                                Dim title As Integer
                                title = Integer.Parse(lineParts(0).Substring("TTITLE".Length)) + 1

                                res.Tracks.Add(lineParts(1).Trim)

                            End If
                        Next
                    End If

                Case 401, 402, 403, 409
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

        Public ReadOnly Property Result() As FreeDbCd
            Get
                Return _result
            End Get
        End Property

        Public Sub New(ByVal cdId As String, ByVal category As String)
            ' Resulthelper initialisieren und defaults zuweisen
            _parameter = New FreeDbParameterCollection

            _parameter.Add("cddb")
            _parameter.Add("read")
            _parameter.Add(category)
            _parameter.Add(cdId)
        End Sub

    End Class

End Namespace