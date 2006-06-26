Imports Softwarekueche.CsvMapper

Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        ' Daten auslesen
        Dim cm As New CsvMapper(Of AttrKlasse)(InputFile1.Value)
        Dim lst As List(Of AttrKlasse) = cm.List

        ' Daten Persistieren
        Dim pers As New CsvPersister(Of AttrKlasse)("Kopie von " & InputFile1.Value)
        pers.Persist(lst)

        ' Daten ausgeben
        For Each o As Object In lst
            Debug.WriteLine(o.ToString)
        Next

        BindingSource1.DataSource = lst

    End Sub

    Public Function GenerateDatenList() As IList
        Dim result As IList

        Dim csvMapper As New CsvMapper(Of Daten)("Daten.csv")

        result = csvMapper.List()

        For Each datenObj As Daten In result
            Console.WriteLine(datenObj.ToString())
        Next

        Return result
    End Function


End Class
