Public Interface IFreeDb

    Property User() As String

    Property Host() As String

    Property Client() As String

    Property Version() As String

    Property Protocol() As Integer

    Function Query(ByVal qry As IQuery) As Object

End Interface
