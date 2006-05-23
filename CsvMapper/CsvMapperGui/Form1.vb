Imports Softwarekueche.CsvMapper

Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim tst As New CsvFileReader(InputFile1.Value)

        Dim il() As CsvHeaderInfo = tst.Header

        For Each ail As CsvHeaderInfo In il
            Debug.WriteLine(ail.ToString)
        Next

        Dim cm As New CsvMapper(Of AttrKlasse)(InputFile1.Value)

        Dim lst As IList = cm.List

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
