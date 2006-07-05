
''' <summary>
''' Die Exception wird ausgel��t, wenn ein Query-Parser eine Version eines
''' Prokolls nicht unterst�tzt.
''' </summary>
Public Class VersionNotSupportedException
    Inherits System.Exception

#Region " �berschreiben der Konstruktoren "

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal message As String)
        MyBase.New(message)
    End Sub

    Public Sub New(ByVal message As String, ByVal innerException As Exception)
        MyBase.New(message, innerException)
    End Sub

    Public Sub New(ByVal info As System.Runtime.Serialization.SerializationInfo, ByVal context As System.Runtime.Serialization.StreamingContext)
        MyBase.New(info, context)
    End Sub

#End Region

End Class
