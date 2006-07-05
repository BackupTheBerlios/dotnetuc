
''' <summary>
''' Diese Exception ist keine Exception im eigentlichen Sinne. Es kann i.d.R.
''' davon ausgegangen werden, dass die Funktion "isError" false ist.
''' Die Exception parst und hält wäre der Antwort des Services.
''' </summary>
Public Class FreeDbException
    Inherits System.Exception

#Region " Factory Methode "

    ''' <summary>
    ''' Erzeugt einen neuen Fehler und parst die erste Zeile. Ob der Fehler ein Fehler
    ''' oder ein Status ist, gibt die Methode isError() an.
    ''' </summary>
    Public Shared Function Create(ByVal freeDbCode As String) As FreeDbException
        Dim res As New FreeDbException

        ' Raw Code speichern
        res._freeDbCode = freeDbCode

        ' An Leerzeichen aufsplitten
        Dim parts() As String = freeDbCode.Split(" ".ToCharArray, StringSplitOptions.RemoveEmptyEntries)

        ' Nummernteile auslesen
        res._Number = Integer.Parse(parts(0))
        res._FirstDigit = Integer.Parse(parts(0)(0))
        res._SecondDigit = Integer.Parse(parts(0)(1))
        res._ThirdDigit = Integer.Parse(parts(0)(2))

        Return res
    End Function

#End Region

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

#Region " Daten der Exception "

    Private _freeDbCode As String

#Region " Eigenschaft FirstDigit, FirstDigitMessage "

    ''' <summary>
    ''' Speichert den Wert für die Eigenschaft FirstDigit.
    ''' Default ist -1
    ''' </summary>
    Private _FirstDigit As Integer = -1

    ''' <summary>
    ''' Eigenschaft FirstDigit
    ''' </summary>
    Public ReadOnly Property FirstDigit() As Integer
        Get
            Return (Me._FirstDigit)
        End Get
    End Property

    ''' <summary>
    ''' Fehlertext zu der ersten Fehlerzahl
    ''' </summary>
    Public ReadOnly Property FirstDigitMessage() As String
        Get
            Select Case _FirstDigit
                Case -1
                    Return "Kein Fehler zugewiesen"
                Case 0
                    Return "Fehlernummer konnte nicht geparst werden"
                Case 1
                    Return "Information"
                Case 2
                    Return "Befehl OK"
                Case 3
                    Return "Befehl OK, Fortsetzen"
                Case 4
                    Return "Befehl OK, Aktion konnte aber nicht durchgeführt werden"
                Case 5
                    Return "Befehl nicht implementiert, inkorrekt oder Fehler."
                Case Else
                    Return "Unbekannte Fehlernummer"
            End Select
        End Get
    End Property

#End Region

#Region " Eigenschaft SecondDigit, SecondDigitMessage "

    ''' <summary>
    ''' Speichert den Wert für die Eigenschaft SecondDigit.
    ''' Default ist -1
    ''' </summary>
    Private _SecondDigit As Integer = -1

    ''' <summary>
    ''' Eigenschaft SecondDigit
    ''' </summary>
    Public ReadOnly Property SecondDigit() As Integer
        Get
            Return (Me._SecondDigit)
        End Get
    End Property

    ''' <summary>
    ''' Fehlertext zu der zweiten Fehlerzahl
    ''' </summary>
    Public ReadOnly Property SecondDigitMessage() As String
        Get
            Select Case SecondDigit
                Case -1
                    Return "Kein Fehler zugewiesen"
                Case 0
                    Return "Bereit für weitere Befehle"
                Case 1
                    Return "Weitere serverseitige Ausgaben folgen"
                Case 2
                    Return "Weitere clientseitige Eingaben folgen"
                Case 3
                    Return "Verbindung wird geschlossen"
                Case Else
                    Return "Unbekannte Fehlernummer"
            End Select
        End Get
    End Property

#End Region

#Region " Eigenschaft ThirdDigit As Integer = -1 "

    ''' <summary>
    ''' Speichert den Wert für die Eigenschaft ThirdDigit.
    ''' Default ist -1
    ''' </summary>
    Private _ThirdDigit As Integer = -1

    ''' <summary>
    ''' Eigenschaft ThirdDigit
    ''' </summary>
    Public ReadOnly Property ThirdDigit() As Integer
        Get
            Return (Me._ThirdDigit)
        End Get
    End Property

#End Region

#Region " Eigenschaft Number, NumberMessage "

    ''' <summary>
    ''' Speichert den Wert für die Eigenschaft Number.
    ''' Default ist -1
    ''' </summary>
    Private _Number As Integer = -1

    ''' <summary>
    ''' Eigenschaft Number
    ''' </summary>
    Public ReadOnly Property Number() As Integer
        Get
            Return (Me._Number)
        End Get
    End Property

    ''' <summary>
    ''' Gibt dem gesamten Fehlertext zurück.
    ''' </summary>
    Public ReadOnly Property NumberMessage() As String
        Get
            Return _freeDbCode.Substring(5)
        End Get
    End Property

#End Region

#Region " Eigenschaft Message As String = '' "

    ''' <summary>
    ''' Eigenschaft Message
    ''' </summary>
    Public Overrides ReadOnly Property Message() As String
        Get
            Return _freeDbCode.Substring(5)
        End Get
    End Property

#End Region

#Region " Eigenschaft IsError As Boolean "

    ''' <summary>
    ''' Speichert den Wert für die Eigenschaft IsError.
    ''' Default ist Standard
    ''' </summary>
    Private _IsError As Boolean

    ''' <summary>
    ''' Eigenschaft IsError
    ''' </summary>
    Public ReadOnly Property IsError() As Boolean
        Get
            Return (_FirstDigit = 5) OrElse (_FirstDigit = 4)
        End Get
    End Property

#End Region

#End Region

End Class
