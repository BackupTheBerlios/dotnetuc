Public Class ExecuteHelper

    Public Shared Sub ExecuteProgram(ByVal Prog As String)
        Try
            Dim prc As New System.Diagnostics.Process
            prc.StartInfo.FileName = Prog
            prc.StartInfo.Arguments = ""
            prc.StartInfo.WorkingDirectory = Windows.Forms.Application.StartupPath

            prc.Start()

        Catch ex As Exception
            System.Console.WriteLine("Beim Starten von '" & Prog & "' ist ein Fehler aufgetreten")
            System.Console.WriteLine("   " & ex.Message)

        End Try
    End Sub

End Class
