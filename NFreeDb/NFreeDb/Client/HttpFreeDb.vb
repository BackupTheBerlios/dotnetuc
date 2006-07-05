Namespace Client

    Public Class HttpFreeDb
        Implements IFreeDb

#Region " Programmeinstellungen "

#Region " Eigenschaft User As String = 'Softwarekoch' "

        ''' <summary>
        ''' Speichert den Wert für die Eigenschaft User.
        ''' Default ist Thomas
        ''' </summary>
        Private _User As String = "Softwarekoch"

        ''' <summary>
        ''' Eigenschaft User
        ''' </summary>
        Public Property User() As String Implements IFreeDb.User
            Get
                Return (Me._User)
            End Get
            Set(ByVal Value As String)
                Me._User = Value
            End Set
        End Property

#End Region

#Region " Eigenschaft Host As String = 'dotnetuc.berlios.de' "

        ''' <summary>
        ''' Speichert den Wert für die Eigenschaft Host.
        ''' Default ist 
        ''' </summary>
        Private _Host As String = "dotnetuc.berlios.de"

        ''' <summary>
        ''' Eigenschaft Host
        ''' </summary>
        Public Property Host() As String Implements IFreeDb.Host
            Get
                Return (Me._Host)
            End Get
            Set(ByVal Value As String)
                Me._Host = Value
            End Set
        End Property

#End Region

#Region " Eigenschaft Client As String = 'NFreeDb' "

        ''' <summary>
        ''' Speichert den Wert für die Eigenschaft Client.
        ''' Default ist NFreeDb
        ''' </summary>
        Private _Client As String = "NFreeDb"

        ''' <summary>
        ''' Eigenschaft Client
        ''' </summary>
        Public Property Client() As String Implements IFreeDb.Client
            Get
                Return (Me._Client)
            End Get
            Set(ByVal Value As String)
                Me._Client = Value
            End Set
        End Property

#End Region

#Region " Eigenschaft Version As String = Assembly.Version' "

        ''' <summary>
        ''' Speichert den Wert für die Eigenschaft Version.
        ''' Default ist NFreeDb
        ''' </summary>
        Private _Version As String = "0"

        ''' <summary>
        ''' Eigenschaft Version
        ''' </summary>
        Public Property Version() As String Implements IFreeDb.Version
            Get
                Return (Me._Version)
            End Get
            Set(ByVal Value As String)
                Me._Version = Value
            End Set
        End Property

#End Region

#Region " Eigenschaft Protokol As Integer = 1 "

        ''' <summary>
        ''' Speichert den Wert für die Eigenschaft Protokoll.
        ''' Default ist 1
        ''' </summary>
        Private _Protokol As Integer = 1

        ''' <summary>
        ''' Eigenschaft Protokol für das Übertragungsprotokoll.
        ''' </summary>
        Public Property Protokol() As Integer Implements IFreeDb.Protocol
            Get
                Return (Me._Protokol)
            End Get
            Set(ByVal Value As Integer)
                Me._Protokol = Value
            End Set
        End Property

#End Region

#End Region

        Public Sub New()
            _Version = (My.Application.Info.Version.ToString())
        End Sub

        Private Const WebQuery As String = "http://freedb.freedb.org/~cddb/cddb.cgi?cmd=@cmd&hello=@user+@host+@client+@version&proto=@proto"

        Public Function Query(ByVal qry As IQuery) As Object Implements IFreeDb.Query
            ' Abfrage generieren
            Dim httpQry As String = WebQuery
            ' User, Host, Client, Version
            httpQry = httpQry.Replace("@user", _User).Replace("@host", _Host).Replace("@client", _Client).Replace("@version", _Version)
            ' Protokoll
            httpQry = httpQry.Replace("@proto", _Protokol.ToString)

            ' Abfrageparameter concatenieren
            Dim cmd As String = ""
            For Each s As String In qry.Parameter
                If cmd.Length = 0 Then
                    cmd = s
                Else
                    cmd &= "+" & s
                End If
            Next

            ' Abfrage ausführen
            httpQry = httpQry.Replace("@cmd", cmd)

            Dim httpResult As String
            Dim wc As New System.Net.WebClient
            httpResult = wc.DownloadString(httpQry)

            ' Rückgabe parsen (über IQuery.Parse)
            Dim res As Object
            res = qry.ParseResult(httpResult, _protokol)

            ' Exception werfen, falls ein "echter" Fehleraufgetreten ist.
            If qry.Exception.IsError Then
                Throw qry.Exception
            End If

            Return res
        End Function

    End Class

End Namespace