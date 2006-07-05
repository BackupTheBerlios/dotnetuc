Imports NUnit.Framework
Imports DotNetUC.CsvMapper

<TestFixture()> _
Public Class NUnitTest

    ' Testen von Richtigbedienung

    <Test(Description:="Einfaches Generieren von Klassen")> _
    Public Sub GenerateClasses()
        Dim cm As New CsvMapper(Of AttrKlasse)("DatenTest.csv")

        Dim lst As IList = cm.List

        Assert.AreEqual(3, lst.Count, "Anzahl der generierten Objekte muss 4 sein")
    End Sub

    <Test(Description:="Einfaches Generieren von Klassen mit verschiedenen Csv Dateien")> _
    Public Sub GenerateClasses2()
        ' ERSTE Csv DAtei
        Dim cm As New CsvMapper(Of AttrKlasse)("DatenTest.csv")

        Debug.WriteLine(cm.CsvFile & " -->")

        Dim lst As IList = cm.List
        Assert.AreEqual(3, lst.Count, "Anzahl der generierten Objekte muss 4 sein")

        ' ZWEITE Csv Datei
        cm.CsvFile = "DatenFalschTest.csv"
        Debug.WriteLine(cm.CsvFile & " -->")

        lst = cm.List
        Assert.AreEqual(4, lst.Count, "Anzahl der generierten Objekte muss 4 sein")
    End Sub

    <Test()> _
    Public Sub FalscheKlasseIgnoreHeader()
        Dim cm As New CsvMapper(Of AttrFalsch)("DatenTest.csv")
        cm.IgnoreErrors = True

        Dim lst As IList = cm.List

        Assert.AreEqual(3, lst.Count, "Anzahl der generierten Objekte muss 4 sein")
    End Sub

    ' Testen von Falschbedienung

    <Test(Description:="Testen einer unvollständigen Csv Datei")> _
    Public Sub FalscheDatenTest()
        Dim cm As New CsvMapper(Of AttrKlasse)("DatenFalschTest.csv")

        Dim lst As IList = cm.List

        Assert.AreEqual(4, lst.Count, "Anzahl der generierten Objekte muss 4 sein")
    End Sub

    <Test(Description:="Öffnen einer nicht existenten Datei"), _
     ExpectedException(GetType(System.Data.Odbc.OdbcException))> _
    Public Sub FalscheCsvTest()
        Dim cm As New CsvMapper(Of AttrKlasse)("ExistiertNicht.csv")
    End Sub

    <Test(Description:="Erstellen von Objekten, deren Csv Column keine Column in der Csv Datei hat"), _
     ExpectedException(GetType(DotNetUC.CsvMapper.HeaderNotFoundException))> _
    Public Sub FalscheKlasseHeader()
        Dim cm As New CsvMapper(Of AttrFalsch)("DatenTest.csv")

        Dim lst As IList = cm.List
    End Sub

End Class
