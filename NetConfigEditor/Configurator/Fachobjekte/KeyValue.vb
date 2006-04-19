''' <summary>
''' Objekt, dass ein Schlüssel-Wert-Paar darstellt.
''' </summary>
Public Class KeyValue

#Region " Eigenschaft HasChanges "

    Private Shared _hasChanges As Boolean = False

    Public Shared Property HasChanges() As Boolean
        Get
            Return _hasChanges
        End Get
        Set(ByVal value As Boolean)
            _hasChanges = value
        End Set
    End Property

#End Region

#Region " Eigenschaft Key As String = Nothing "

    ''' <summary>
    ''' Speichert den Wert für die Eigenschaft Key.
    ''' Default ist Nothing
    ''' </summary>
    Private _Key As String = Nothing

    ''' <summary>
    ''' Eigenschaft Key
    ''' </summary>
    Public Property Key() As String
        Get
            Return (Me._Key)
        End Get
        Set(ByVal Value As String)
            If Value = _Key Then Exit Property
            Me._Key = Value
            _hasChanges = True
        End Set
    End Property

#End Region

#Region " Eigenschaft Value As String = Nothing "

    ''' <summary>
    ''' Speichert den Wert für die Eigenschaft Value.
    ''' Default ist Nothing
    ''' </summary>
    Private _Value As String = Nothing

    ''' <summary>
    ''' Eigenschaft Value
    ''' </summary>
    Public Property Value() As String
        Get
            Return (Me._Value)
        End Get
        Set(ByVal Value As String)
            If Value = _Value Then Exit Property
            Me._Value = Value
            _hasChanges = True
        End Set
    End Property

#End Region

#Region " Konstruktoren "

    Public Sub New()
        MyBase.New()
        _hasChanges = True
    End Sub

    Public Sub New(ByVal initKey As String, ByVal initValue As String)
        Me.New()
        _Key = initKey
        _Value = initValue
        _hasChanges = True
    End Sub

#End Region

End Class
