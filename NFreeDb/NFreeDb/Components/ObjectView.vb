Imports System.Reflection

Namespace Components

    Public Class ObjectView
        Inherits System.Windows.Forms.TextBox

#Region " Konstruktor "

        Public Sub New()
            MyBase.New()

            MyBase.Multiline = True
            MyBase.ReadOnly = True
        End Sub

#End Region

#Region " Eigenschaft Object As Object "

        ''' <summary>
        ''' Speichert den Wert für die Eigenschaft Object.
        ''' Default ist Standard
        ''' </summary>
        Private _Object As Object

        ''' <summary>
        ''' Eigenschaft Object
        ''' </summary>
        Public Property [Object]() As Object
            Get
                Return (Me._Object)
            End Get
            Set(ByVal Value As Object)
                Me._Object = Value
                ParseObject()
            End Set
        End Property

        Private Sub ParseObject()
            If _Object Is Nothing Then
                Me.Text = ""
                Exit Sub
            ElseIf TypeOf _Object Is IList Then
                Me.Text = "Liste"
                Exit Sub
            End If

            Dim info As New System.Text.StringBuilder

            For Each p As PropertyInfo In _Object.GetType.GetProperties

                Dim pval As Object
                pval = p.GetValue(_Object, Nothing)

                If Not pval Is Nothing Then
                    'If TypeOf pval Is System.Array Then
                    '    info.AppendLine(p.Name & ": " & StringHelper.MergeStrings(CType(pval, Array), ", "))
                    'ElseIf TypeOf pval Is Price Then
                    '    info.AppendLine(p.Name & ": " & CType(pval, Price).FormattedPrice)
                    'Else
                    info.AppendLine(p.Name & ": " & pval.ToString())
                    'End If
                End If
            Next

            Me.Text = info.ToString
        End Sub

#End Region

    End Class

End Namespace
