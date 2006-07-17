Imports System.Data.Odbc

Namespace Internal

    ''' <summary>
    ''' Der CvsFileWriter ist eine Klasse zum zeilenweisen Schreiben von CVS Dateien. Die
    ''' CVS Dateien enthalten in der ersten Zeile die Spaltenüberschriften.
    ''' </summary>
    Public Class CsvNativeWriter

        ''' <summary>
        ''' Erstellt einen neuen CsvFileReader auf der Basis der übergebenen CSV Datei.
        ''' </summary>
        ''' <param name="initFileName">CVS Datei, auf der die Instanz basiert</param>
        Public Sub New(ByVal initFileName As String)
            _fileName = initFileName
            _header = ""
            _body = New List(Of String)
            _currentItem = New String("")
        End Sub

        ''' <summary>
        ''' Speichert den Namen der CSV Datei
        ''' </summary>
        Private _fileName As String

        ''' <summary>
        ''' Gibt den Namen der CSV Datei zurück.
        ''' </summary>
        ''' <value>Name der CSV Datei</value>
        ''' <returns>Name der CSV Datei</returns>
        Public ReadOnly Property FileName() As String
            Get
                Return _fileName
            End Get
        End Property

        ''' <summary>
        ''' Variable mit der Kopfzeile
        ''' </summary>
        Private _header As String

        ''' <summary>
        ''' CSV Datenzeilen
        ''' </summary>
        Private _body As List(Of String)

        Public Sub WriteHeader(ByVal column As String)
            If _header.Length = 0 Then
                ' Erster Header
                _header = """" & column & """"
            Else
                ' Weiterer Header
                _header &= ";""" & column & """"
            End If
        End Sub

        Public Sub WriteItem()
            _body.Add(_currentItem)
            _currentItem = New String("")
        End Sub

        Private _currentItem As String

        Public Sub WriteField(ByVal value As Object, ByVal type As Type)
            If _currentItem.Length > 0 Then _currentItem &= ";"

            If type Is GetType(Integer) OrElse _
               type Is GetType(Short) OrElse _
               type Is GetType(Long) Then
                ' Wert ohne Hochkommas
                If value Is Nothing Then
                    _currentItem &= "0"
                Else
                    _currentItem &= value.ToString
                End If
            Else
                ' Wert mit Hochkommas
                If value Is Nothing Then
                    _currentItem &= """" & "" & """"
                Else
                    _currentItem &= """" & value.ToString & """"
                End If
            End If

        End Sub

        Private _encoding As System.Text.Encoding = New System.Text.UTF8Encoding

        Public Property Encoding() As System.Text.Encoding
            Get
                Return _encoding
            End Get
            Set(ByVal value As System.Text.Encoding)
                _encoding = value
            End Set
        End Property

        Public Sub Flush()
            ' CSV Datei öffnen
            Dim s As New IO.StreamWriter(_fileName, False, _encoding)
            ' Header schreiben
            s.WriteLine(_header)
            ' Body schreiben
            For Each str As String In _body
                s.WriteLine(str)
            Next
            ' Datei schließen
            s.Close()
        End Sub

    End Class

End Namespace