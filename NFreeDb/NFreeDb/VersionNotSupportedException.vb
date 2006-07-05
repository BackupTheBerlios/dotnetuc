
''' <summary>
''' Die Exception wird ausgelößt, wenn ein Query-Parser eine Version eines
''' Prokolls nicht unterstützt.
''' </summary>
Public Class VersionNotSupportedException
    Inherits System.Exception

#Region " Überschreiben der Konstruktoren "

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
