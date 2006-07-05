Public Class FreeDbCd

#Region " Eigenschaft Artist As String "

    ''' <summary>
    ''' Speichert den Wert für die Eigenschaft Artist.
    ''' Default ist ""
    ''' </summary>
    Private _Artist As String

    ''' <summary>
    ''' Eigenschaft Artist
    ''' </summary>
    Public Property Artist() As String
        Get
            Return (Me._Artist)
        End Get
        Set(ByVal Value As String)
            Me._Artist = Value
        End Set
    End Property

#End Region

#Region " Eigenschaft Album As String  "

    ''' <summary>
    ''' Speichert den Wert für die Eigenschaft Album.
    ''' Default ist Standard
    ''' </summary>
    Private _Album As String

    ''' <summary>
    ''' Eigenschaft Album
    ''' </summary>
    Public Property Album() As String
        Get
            Return (Me._Album)
        End Get
        Set(ByVal Value As String)
            Me._Album = Value
        End Set
    End Property

#End Region

#Region " Eigenschaft Category As String = '' "

    ''' <summary>
    ''' Speichert den Wert für die Eigenschaft Category.
    ''' Default ist ''
    ''' </summary>
    Private _Category As String = ""

    ''' <summary>
    ''' Eigenschaft Category
    ''' </summary>
    Public Property Category() As String
        Get
            Return (Me._Category)
        End Get
        Set(ByVal Value As String)
            Me._Category = Value
        End Set
    End Property

#End Region

#Region " Eigenschaft CdId As String = '' "

    ''' <summary>
    ''' Speichert den Wert für die Eigenschaft CdId.
    ''' Default ist ''
    ''' </summary>
    Private _CdId As String = ""

    ''' <summary>
    ''' Eigenschaft CdId
    ''' </summary>
    Public Property CdId() As String
        Get
            Return (Me._CdId)
        End Get
        Set(ByVal Value As String)
            Me._CdId = Value
        End Set
    End Property

#End Region

#Region " Eigenschaft Genre As String = '' "

    ''' <summary>
    ''' Speichert den Wert für die Eigenschaft Genre.
    ''' Default ist ''
    ''' </summary>
    Private _Genre As String = ""

    ''' <summary>
    ''' Eigenschaft Genre
    ''' </summary>
    Public Property Genre() As String
        Get
            Return (Me._Genre)
        End Get
        Set(ByVal Value As String)
            Me._Genre = Value
        End Set
    End Property

#End Region

#Region " Eigenschaft Year As Integer = 0 "

    ''' <summary>
    ''' Speichert den Wert für die Eigenschaft Year.
    ''' Default ist 0
    ''' </summary>
    Private _Year As Integer = 0

    ''' <summary>
    ''' Eigenschaft Year
    ''' </summary>
    Public Property Year() As Integer
        Get
            Return (Me._Year)
        End Get
        Set(ByVal Value As Integer)
            Me._Year = Value
        End Set
    End Property

#End Region

#Region " Eigenschaft Tracks As List(Of String) = New List(Of String) "

    ''' <summary>
    ''' Speichert den Wert für die Eigenschaft Tracks.
    ''' Default ist New List(Of String)
    ''' </summary>
    Private _Tracks As List(Of String) = New List(Of String)

    ''' <summary>
    ''' Eigenschaft Tracks
    ''' </summary>
    Public Property Tracks() As List(Of String)
        Get
            Return (Me._Tracks)
        End Get
        Set(ByVal Value As List(Of String))
            Me._Tracks = Value
        End Set
    End Property

#End Region

    Public Overrides Function ToString() As String
        Return Artist & " / " & Album & " (" & CdId & "-" & Category & ")"
    End Function

End Class
