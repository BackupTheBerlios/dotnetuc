Imports System.Reflection

Namespace Internal

    ''' <summary>
    ''' Klasse zum Serialisieren von Objekten.
    ''' </summary>
    Friend NotInheritable Class ObjectHelper

        ''' <summary>
        ''' Serialisiert eine Liste in eine Komma-Verkettung.
        ''' </summary>
        Public Shared Function IList2String(ByVal list As IList) As String
            Dim sb As String = ""

            For Each o As Object In list
                sb &= ", " & o.ToString
            Next

            Return sb.Substring(2)
        End Function

        ''' <summary>
        ''' Serialisiert die Peoperties mittels Object.ToString()
        ''' </summary>
        Public Shared Function Object2String(ByVal _object As Object) As String

            If _object Is Nothing Then
                Return ""

            ElseIf TypeOf _object Is IList Then
                Dim res As New System.Text.StringBuilder

                For Each o As Object In CType(_object, IList)
                    res.Append("=========== Object ===========")
                    res.Append(Object2String(o))
                Next

                Return res.ToString()

            End If

            ' Normales Objekt parsen...
            Dim info As New System.Text.StringBuilder
            Dim pval As Object

            For Each p As PropertyInfo In _object.GetType.GetProperties

                Try
                    pval = p.GetValue(_object, Nothing)

                    If TypeOf pval Is IList Then
                        info.AppendLine(p.Name & ": " & IList2String(CType(pval, IList)))

                    ElseIf Not pval Is Nothing Then
                        info.AppendLine(p.Name & ": " & pval.ToString())

                    Else
                        info.AppendLine(p.Name & ": ")

                    End If

                Catch ex As Exception
                    info.Append(p.Name & ": <ERROR: " & ex.Message & ">")

                End Try
            Next

            Return info.ToString
        End Function

    End Class

End Namespace