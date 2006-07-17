
Namespace Internal

Public Class CsvNativeReader
        Implements IEnumerable(Of CsvFileItem)
        Implements IEnumerator(Of CsvFileItem)
        Implements IDisposable


#Region " Member "

        Private _fileName As String

        Private _header As List(Of CsvHeaderInfo)

        Private _headerArray() As String

        Private _encoding As System.Text.Encoding = New System.Text.UTF8Encoding

#End Region

        Public Sub New(ByVal initFileName As String)
            Dim fi As New IO.FileInfo(initFileName)
            If Not fi.Exists Then Throw New IO.FileNotFoundException("Datei " & initFileName & " existiert nicht")

            _fileName = initFileName
            ReadHeader()
        End Sub

        Private Sub ReadHeader()
            _header = New List(Of CsvHeaderInfo)

            Dim s As New IO.StreamReader(_fileName, _encoding)
            ' Header lesen
            Dim tmpHdr As String = s.ReadLine()
            Dim tmpHdrs() As String = tmpHdr.Split(""",""")

            _headerArray = tmpHdrs

            For i As Integer = 0 To tmpHdrs.Length - 1
                _header.Add(New CsvHeaderInfo(i, tmpHdrs(i)))
            Next

        End Sub

        Public ReadOnly Property Header() As IList
            Get
                Return _header
            End Get
        End Property

        Public ReadOnly Property FileName()
            Get
                Return _fileName
            End Get
        End Property

        Public Property Encoding() As System.Text.Encoding
            Get
                Return _encoding
            End Get
            Set(ByVal value As System.Text.Encoding)
                _encoding = value
            End Set
        End Property

#Region " IEnumerator "

        Dim _csvFile As IO.StreamReader

        Public ReadOnly Property CurrentTyped() As CsvFileItem Implements System.Collections.Generic.IEnumerator(Of CsvFileItem).Current
            Get
                _header = New List(Of CsvHeaderInfo)
                Dim tmpLne As String = _csvFile.ReadLine()
                Dim tmpLnes() As String = tmpLne.Split(""",""")

                Return New CsvFileItem(tmpLnes, _headerArray)
            End Get
        End Property

        Private ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
            Get
                Return CurrentTyped
            End Get
        End Property

        Private Function MoveNext() As Boolean Implements System.Collections.IEnumerator.MoveNext
            If Not IO.File.Exists(_fileName) Then Return False

            Try
                If _csvFile Is Nothing Then
                    _csvFile = New IO.StreamReader(_fileName, _encoding)
                    _csvFile.ReadLine() ' Header weglesen
                End If
                Return Not _csvFile.EndOfStream
            Catch ex As Exception
                Return False
            End Try
        End Function

        Private Sub Reset() Implements System.Collections.IEnumerator.Reset
            If Not _csvFile Is Nothing Then _csvFile.Close()
            _csvFile = Nothing
        End Sub

#End Region

#Region " IEnumerable "

        Public Function GetEnumeratorTyped() As System.Collections.Generic.IEnumerator(Of CsvFileItem) Implements System.Collections.Generic.IEnumerable(Of CsvFileItem).GetEnumerator
            Return Me
        End Function

        Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return Me
        End Function

#End Region

#Region " IDisposable implementierung "

        Private disposedValue As Boolean = False        ' To detect redundant calls

        ' IDisposable
        Protected Overridable Sub Dispose(ByVal disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    If Not _csvfile Is Nothing Then _csvFile.Close()
                    ' TODO: free unmanaged resources when explicitly called
                End If

                ' TODO: free shared unmanaged resources
            End If
            Me.disposedValue = True
        End Sub

        ' This code added by Visual Basic to correctly implement the disposable pattern.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub

#End Region

    End Class

End Namespace