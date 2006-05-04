Imports NUnit.Framework
Imports Softwarekueche.CsvMapper

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

        For Each s As CsvHeaderInfo In cm.Header
            Debug.WriteLine(s)
        Next

        For Each s As CsvFieldInfo In cm.Fields
            Debug.WriteLine(s)
        Next
        Dim lst As IList = cm.List
        Assert.AreEqual(3, lst.Count, "Anzahl der generierten Objekte muss 4 sein")

        ' ZWEITE Csv Datei
        cm.CsvFile = "DatenFalschTest.csv"
        Debug.WriteLine(cm.CsvFile & " -->")

        For Each s As CsvHeaderInfo In cm.Header
            Debug.WriteLine(s)
        Next

        For Each s As CsvFieldInfo In cm.Fields
            Debug.WriteLine(s)
        Next

        lst = cm.List
        Assert.AreEqual(4, lst.Count, "Anzahl der generierten Objekte muss 4 sein")
    End Sub

    <Test(Description:="Auslesen der Meta Infotmationen")> _
    Public Sub ReadHeaderAndFields()
        Dim cm As New CsvMapper(Of AttrKlasse)("DatenTest.csv")

        Debug.WriteLine(cm.CsvFile & " -->")

        For Each s As CsvHeaderInfo In cm.Header
            Debug.WriteLine(s)
        Next

        For Each s As CsvFieldInfo In cm.Fields
            Debug.WriteLine(s)
        Next
    End Sub

    ' Testen von Falschbedienung

    <Test()> _
    Public Sub FalscheDatenTest()
        Dim cm As New CsvMapper(Of AttrKlasse)("DatenFalschTest.csv")

        Dim lst As IList = cm.List

        Assert.AreEqual(4, lst.Count, "Anzahl der generierten Objekte muss 4 sein")
    End Sub

    <Test(), _
     ExpectedException(GetType(System.Data.Odbc.OdbcException))> _
    Public Sub FalscheCsvTest()
        Dim cm As New CsvMapper(Of AttrKlasse)("ExistiertNicht.csv")
    End Sub

    <Test(), _
     ExpectedException(GetType(Softwarekueche.CsvMapper.HeaderNotFoundException))> _
    Public Sub FalscheKlasseHeader()
        Dim cm As New CsvMapper(Of AttrFalsch)("DatenTest.csv")

        Dim lst As IList = cm.List
    End Sub

    <Test()> _
    Public Sub FalscheKlasseIgnoreHeader()
        Dim cm As New CsvMapper(Of AttrFalsch)("DatenTest.csv")
        cm.IgnoreErrors = True

        Dim lst As IList = cm.List

        Assert.AreEqual(3, lst.Count, "Anzahl der generierten Objekte muss 4 sein")
    End Sub


End Class
