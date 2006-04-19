Imports System.Configuration
Imports System.Windows.Forms

''' <summary>
''' Klasse, die die Konfiguration der WinConfigurator.exe benutzt.
''' </summary>
Public NotInheritable Class Konfiguration

#Region " Verborgener Konstruktur "

    ''' <summary>
    ''' Konstruktor verbergen
    ''' </summary>
    Private Sub New()
        MyBase.New()
    End Sub

#End Region

#Region " Initialisierung "

    Private Shared mgr As System.Configuration.Configuration

    Private Shared Sub Init()
        mgr = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath)
    End Sub

#End Region

#Region " Parameter VisualStyle As Boolean = True "

    Public Shared Property VisualStyle() As Boolean
        Get
            If mgr Is Nothing Then Init()

            If mgr.AppSettings.Settings("VisualStyle") Is Nothing Then
                Return True
            Else
                Return CType(mgr.AppSettings.Settings("VisualStyle").Value, Boolean)
            End If
        End Get
        Set(ByVal value As Boolean)
            If mgr Is Nothing Then Init()

            If mgr.AppSettings.Settings("VisualStyle") Is Nothing Then
                mgr.AppSettings.Settings.Add("VisualStyle", value.ToString())
            Else
                mgr.AppSettings.Settings("VisualStyle").Value = value.ToString()
            End If

            mgr.Save()
        End Set
    End Property

#End Region

End Class
