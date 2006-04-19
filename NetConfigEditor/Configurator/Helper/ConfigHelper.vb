''' <summary>
''' Hilfsfunktionen zum Auslesen und Schreiben der Konfigurationsdatei.
''' </summary>
''' <remarks></remarks>
Public Class ConfigHelper

    ''' <summary>
    ''' Gibt eine Konfiguration auf der Basis der übergebenen Datei zurück. Dabei muss
    ''' unterschieden werden, ob die Konfigurationsdatei eine "*.exe" oder eine
    ''' "*.config" Datei ist. Es wird bewusst nicht die "*.exe.config" benutzt, da auch
    ''' eine "app.config" editierbar sein soll.
    ''' </summary>
    ''' <param name="_configFile">Konfigurationsdatei oder Assembly, die Konfiguriert wird</param>
    ''' <returns>Konfigurationsinstanz</returns>
    Public Shared Function GetConfiguration(ByVal _configFile As String) As System.Configuration.Configuration
        Dim mgr As System.Configuration.Configuration

        If _configFile.EndsWith(".config", StringComparison.CurrentCultureIgnoreCase) Then
            Dim map As New Configuration.ExeConfigurationFileMap
            map.ExeConfigFilename = _configFile
            mgr = System.Configuration.ConfigurationManager.OpenMappedExeConfiguration(map, Configuration.ConfigurationUserLevel.None)
        Else
            mgr = System.Configuration.ConfigurationManager.OpenExeConfiguration(_configFile)
        End If

        Return mgr
    End Function

    ''' <summary>
    ''' Liest eine Konfigurationsdatei in eine Key/Value Liste.
    ''' </summary>
    ''' <param name="_configFile">Konfigurationsdatei oder Assembly, die Konfiguriert wird</param>
    ''' <returns>Liste mit allen Parametern in der Konfigurationsdatei</returns>
    Public Shared Function ReadList(ByVal _configFile As String) As IList
        Dim _list As New List(Of KeyValue)

        Dim mgr As System.Configuration.Configuration
        Dim okv As KeyValue

        mgr = GetConfiguration(_configFile)

        For Each a As System.Configuration.KeyValueConfigurationElement In mgr.AppSettings.Settings
            okv = New KeyValue(a.Key, a.Value)
            _list.Add(okv)
        Next

        Return _list
    End Function

    ''' <summary>
    ''' Schreibt die Key/Value in die übergebene Konfigurationsdatei
    ''' </summary>
    ''' <param name="_list">Liste mit Key/Value Einträgen</param>
    ''' <param name="_configFile">Konfigurationsdatei oder Assembly, die Konfiguriert wird</param>
    Public Shared Sub WriteList(ByVal _list As IList, ByVal _configFile As String)
        Dim mgr As System.Configuration.Configuration

        mgr = GetConfiguration(_configFile)

        mgr.AppSettings.Settings.Clear()
        For Each a As KeyValue In _list

            If mgr.AppSettings.Settings(a.Key) Is Nothing Then
                mgr.AppSettings.Settings.Add(a.Key, a.Value)
            Else
                mgr.AppSettings.Settings(a.Key).Value = a.Value
            End If

        Next

        Try
            mgr.Save()
            KeyValue.HasChanges = False
        Catch ex As Exception
            MessageBox.Show(ex.StackTrace, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, 0)
        End Try

    End Sub

End Class
