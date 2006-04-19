Imports Softwarekueche.NetConfigurator.Configurator

Public Class Start

    Public Shared Sub Main(ByVal args() As String)

        Dim frmMain As System.Windows.Forms.Form = Nothing

        Dim bOpenSingle As Boolean = False

        For Each s As String In args
            If String.Compare(s, "--single", True) = 0 Then bOpenSingle = True
            If System.IO.File.Exists(s) AndAlso bOpenSingle Then
                frmMain = New EditDialog(s)
                Exit For
            End If
        Next

        If Not bOpenSingle Then
            frmMain = New ConfiguratorApp
            For Each s As String In args
                If System.IO.File.Exists(s) Then
                    CType(frmMain, ConfiguratorApp).OpenFile(s)
                End If
            Next
        End If


        If Konfiguration.VisualStyle Then
            Application.EnableVisualStyles()
        End If
        If Not frmMain Is Nothing Then Application.Run(frmMain)

    End Sub

End Class
