''' <summary>
''' Speichert die CSV Spalten�berschriften mit den zugeh�rigen Index.
''' </summary>
Public Class CsvHeaderInfo

    ''' <summary>
    ''' Legt eine neue Spalten�berschrift mit Namen und Index an.
    ''' </summary>
    ''' <param name="initIndex">Index der �berschrift</param>
    ''' <param name="initHeader">Name der �berschrift</param>
    Public Sub New(ByVal initIndex As Integer, ByVal initHeader As String)
        _index = initIndex
        _header = initHeader
    End Sub

    ''' <summary>
    ''' Speichert den Index
    ''' </summary>
    Private _index As Integer

    ''' <summary>
    ''' Speichert den Namen der Spalten�berschrift.
    ''' </summary>
    Private _header As String

End Class
