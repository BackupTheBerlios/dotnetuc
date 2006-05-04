Imports System.Data.Odbc

Public Class CsvFileReader
    Implements IEnumerator(Of CsvFileItem)

    Public Sub New(ByVal initFileName As String)
        Dim fi As New IO.FileInfo(initFileName)

        _fileName = initFileName
        _connectionString = "Driver={Microsoft Text Driver (*.txt; *.csv)};Dbq=" & fi.DirectoryName & ";"
        ReadHeader()
    End Sub

    Private Sub ReadHeader()
        _header = New List(Of CsvHeaderInfo)
        Dim fi As New IO.FileInfo(_fileName)

        Dim csvConnection = New OdbcConnection(_connectionString)
        csvConnection.Open()

        Dim csvCommand As OdbcCommand
        csvCommand = csvConnection.CreateCommand()
        csvCommand.CommandText = "SELECT * FROM [" & fi.Name & "]"

        Dim dt As New DataTable("Csv")
        dt.Locale = Globalization.CultureInfo.CurrentCulture

        Dim da As New OdbcDataAdapter(csvCommand)
        da.Fill(dt)

        Dim index As Integer = 0

        Dim hdrTmp(dt.Columns.Count - 1) As String

        For Each c As DataColumn In dt.Columns
            _header.Add(New CsvHeaderInfo(index, c.ColumnName))
            _headerOrder &= ", [" & c.ColumnName & "]"
            hdrTmp(index) = c.ColumnName
            index += 1
        Next

        _headerOrder = _headerOrder.Substring(2)
        _headerArray = hdrTmp

        da = Nothing
        dt = Nothing
        csvCommand = Nothing
        csvConnection.Close()
    End Sub

    Public ReadOnly Property Header() As IList
        Get
            Return _header
        End Get
    End Property

    Private _fileName As String

    Private _header As List(Of CsvHeaderInfo)

    Private _headerArray() As String

    Private _headerOrder As String

    Private _connectionString As String

    Public ReadOnly Property FileName() As String
        Get
            Return _fileName
        End Get
    End Property

#Region " IEnumerator "

    Private _dr As OdbcDataReader

    Private Sub OpenDataReader()
        Dim csvConnection = New OdbcConnection(_connectionString)
        Dim fi As New IO.FileInfo(_fileName)

        csvConnection.Open()
        Dim csvCommand As OdbcCommand

        csvCommand = csvConnection.CreateCommand()
        csvCommand.CommandText = "SELECT " & _headerOrder & " FROM [" & fi.Name & "]"

        _dr = csvCommand.ExecuteReader()
    End Sub

    Private ReadOnly Property CurrentTyped() As CsvFileItem Implements System.Collections.Generic.IEnumerator(Of CsvFileItem).Current
        Get
            If _dr Is Nothing Then OpenDataReader()

            Dim s(_dr.FieldCount - 1) As Object
            For i As Integer = 0 To _dr.FieldCount - 1
                s(i) = _dr.Item(i)
            Next

            Return New CsvFileItem(s, _headerArray)
        End Get
    End Property

    Private ReadOnly Property CurrentUntyped() As Object Implements System.Collections.IEnumerator.Current
        Get
            Return CurrentTyped
        End Get
    End Property

    Private Function MoveNext() As Boolean Implements System.Collections.IEnumerator.MoveNext
        If _dr Is Nothing Then
            Try
                OpenDataReader()
                Return _dr.Read()
                '                Return _dr.HasRows
            Catch ex As Exception
                Return False
            End Try
        Else
            Return _dr.Read()
        End If
    End Function

    Private Sub Reset() Implements System.Collections.IEnumerator.Reset
        If Not _dr Is Nothing Then _dr.Close()
        _dr = Nothing
    End Sub

#End Region

#Region " IDisposable Support "

    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' free unmanaged resources when explicitly called

            End If

            ' free shared unmanaged resources
            If Not _dr Is Nothing AndAlso Not _dr.IsClosed Then _dr.Close()

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

