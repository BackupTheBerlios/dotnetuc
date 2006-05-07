''' <summary>
''' Speichert die CSV Spaltenüberschriften mit den zugehörigen Index.
''' </summary>
Public Class CsvHeaderInfo

    ''' <summary>
    ''' Legt eine neue Spaltenüberschrift mit Namen und Index an.
    ''' </summary>
    ''' <param name="initIndex">Index der Überschrift</param>
    ''' <param name="initHeader">Name der Überschrift</param>
    Public Sub New(ByVal initIndex As Integer, ByVal initHeader As String)
        _index = initIndex
        _header = initHeader
    End Sub

    ''' <summary>
    ''' Speichert den Index
    ''' </summary>
    Private _index As Integer

    ''' <summary>
    ''' Speichert den Namen der Spaltenüberschrift.
    ''' </summary>
    Private _header As String

End Class
