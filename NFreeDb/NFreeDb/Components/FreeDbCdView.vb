Imports System.Reflection

Namespace Components

    Public Class FreeDbCdView
        Inherits System.Windows.Forms.TextBox

#Region " Konstruktor "

        public sub new(
        Public Sub New()
            MyBase.New()

            MyBase.Multiline = True
            MyBase.ReadOnly = True
            Me.ScrollBars = Windows.Forms.ScrollBars.Vertical

            If Me.DesignMode Then
                Dim f As New Client.HttpFreeDb
                Dim q As New Query.ReadQuery("c912940e", "rock")
                f.Query(q)
                FreeDbCd = q.Result
                MessageBox.Show(q.RawResult)
            End If
        End Sub

#End Region

#Region " Eigenschaft Object As Object "

        ''' <summary>
        ''' Speichert den Wert für die Eigenschaft FreeDbCd.
        ''' Default ist Standard
        ''' </summary>
        Private _FreeDbCd As FreeDbCd

        ''' <summary>
        ''' Eigenschaft FreeDbCd
        ''' </summary>
        Public Property [FreeDbCd]() As FreeDbCd
            Get
                Return (Me._FreeDbCd)
            End Get
            Set(ByVal value As FreeDbCd)
                Me._FreeDbCd = value
                Me.Text = Internal.ObjectHelper.Object2String(value)
            End Set
        End Property

#End Region

    End Class

End Namespace
