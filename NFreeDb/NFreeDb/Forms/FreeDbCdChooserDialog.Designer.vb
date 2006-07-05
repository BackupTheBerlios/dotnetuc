Namespace Forms

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class FreeDbCdChooserDialog
        Inherits System.Windows.Forms.Form

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Me.lsbCds = New System.Windows.Forms.ListBox
            Me.btnOk = New System.Windows.Forms.Button
            Me.btnAbort = New System.Windows.Forms.Button
            Me.oCdView = New DotNetUC.NFreeDb.Components.FreeDbCdView
            Me.SuspendLayout()
            '
            'lsbCds
            '
            Me.lsbCds.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lsbCds.FormattingEnabled = True
            Me.lsbCds.Location = New System.Drawing.Point(12, 12)
            Me.lsbCds.Name = "lsbCds"
            Me.lsbCds.Size = New System.Drawing.Size(304, 134)
            Me.lsbCds.TabIndex = 0
            '
            'btnOk
            '
            Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnOk.Location = New System.Drawing.Point(160, 320)
            Me.btnOk.Name = "btnOk"
            Me.btnOk.Size = New System.Drawing.Size(75, 23)
            Me.btnOk.TabIndex = 1
            Me.btnOk.Text = "&OK"
            Me.btnOk.UseVisualStyleBackColor = True
            '
            'btnAbort
            '
            Me.btnAbort.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnAbort.Location = New System.Drawing.Point(241, 320)
            Me.btnAbort.Name = "btnAbort"
            Me.btnAbort.Size = New System.Drawing.Size(75, 23)
            Me.btnAbort.TabIndex = 2
            Me.btnAbort.Text = "&Abbrechen"
            Me.btnAbort.UseVisualStyleBackColor = True
            '
            'oCdView
            '
            Me.oCdView.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.oCdView.FreeDbCd = Nothing
            Me.oCdView.Location = New System.Drawing.Point(12, 161)
            Me.oCdView.Multiline = True
            Me.oCdView.Name = "oCdView"
            Me.oCdView.ReadOnly = True
            Me.oCdView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.oCdView.Size = New System.Drawing.Size(304, 153)
            Me.oCdView.TabIndex = 3
            '
            'FreeDbCdChooserDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(328, 355)
            Me.Controls.Add(Me.oCdView)
            Me.Controls.Add(Me.btnAbort)
            Me.Controls.Add(Me.btnOk)
            Me.Controls.Add(Me.lsbCds)
            Me.Name = "FreeDbCdChooserDialog"
            Me.Text = "CD Auswählen"
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents lsbCds As System.Windows.Forms.ListBox
        Friend WithEvents btnOk As System.Windows.Forms.Button
        Friend WithEvents btnAbort As System.Windows.Forms.Button
        Friend WithEvents oCdView As DotNetUC.NFreeDb.Components.FreeDbCdView
    End Class

End Namespace