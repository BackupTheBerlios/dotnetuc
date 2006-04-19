<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConfiguratorApp
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConfiguratorApp))
        Me.stripMenü = New System.Windows.Forms.MenuStrip
        Me.toolDatei = New System.Windows.Forms.ToolStripMenuItem
        Me.toolDateiÖffnen = New System.Windows.Forms.ToolStripMenuItem
        Me.toolSaveAll = New System.Windows.Forms.ToolStripMenuItem
        Me.toolDateiSep0 = New System.Windows.Forms.ToolStripSeparator
        Me.toolDateiBeenden = New System.Windows.Forms.ToolStripMenuItem
        Me.toolHilfe = New System.Windows.Forms.ToolStripMenuItem
        Me.toolHilfeInfo = New System.Windows.Forms.ToolStripMenuItem
        Me.ofdExecutable = New System.Windows.Forms.OpenFileDialog
        Me.stripMenü.SuspendLayout()
        Me.SuspendLayout()
        '
        'stripMenü
        '
        Me.stripMenü.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolDatei, Me.toolHilfe})
        Me.stripMenü.Location = New System.Drawing.Point(0, 0)
        Me.stripMenü.Name = "stripMenü"
        Me.stripMenü.Size = New System.Drawing.Size(819, 24)
        Me.stripMenü.TabIndex = 1
        Me.stripMenü.Text = "MenuStrip1"
        '
        'toolDatei
        '
        Me.toolDatei.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolDateiÖffnen, Me.toolSaveAll, Me.toolDateiSep0, Me.toolDateiBeenden})
        Me.toolDatei.Name = "toolDatei"
        Me.toolDatei.Size = New System.Drawing.Size(44, 20)
        Me.toolDatei.Text = "&Datei"
        '
        'toolDateiÖffnen
        '
        Me.toolDateiÖffnen.Name = "toolDateiÖffnen"
        Me.toolDateiÖffnen.Size = New System.Drawing.Size(164, 22)
        Me.toolDateiÖffnen.Text = "&Öffnen..."
        '
        'toolSaveAll
        '
        Me.toolSaveAll.Name = "toolSaveAll"
        Me.toolSaveAll.Size = New System.Drawing.Size(164, 22)
        Me.toolSaveAll.Text = "&Alle Speichern..."
        '
        'toolDateiSep0
        '
        Me.toolDateiSep0.Name = "toolDateiSep0"
        Me.toolDateiSep0.Size = New System.Drawing.Size(161, 6)
        '
        'toolDateiBeenden
        '
        Me.toolDateiBeenden.Name = "toolDateiBeenden"
        Me.toolDateiBeenden.Size = New System.Drawing.Size(164, 22)
        Me.toolDateiBeenden.Text = "&Beenden"
        '
        'toolHilfe
        '
        Me.toolHilfe.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolHilfeInfo})
        Me.toolHilfe.Name = "toolHilfe"
        Me.toolHilfe.Size = New System.Drawing.Size(40, 20)
        Me.toolHilfe.Text = "&Hilfe"
        '
        'toolHilfeInfo
        '
        Me.toolHilfeInfo.Name = "toolHilfeInfo"
        Me.toolHilfeInfo.Size = New System.Drawing.Size(117, 22)
        Me.toolHilfeInfo.Text = "&Info..."
        '
        'ofdExecutable
        '
        Me.ofdExecutable.CheckFileExists = False
        Me.ofdExecutable.CheckPathExists = False
        Me.ofdExecutable.Filter = ".NET Assemblies (*.exe)|*.exe|Konfigurationsdateien (*.config)|*.config|Alle Date" & _
            "ien (*.*)|*.*"
        Me.ofdExecutable.Multiselect = True
        Me.ofdExecutable.Title = ".NET Assemblies öffnen"
        '
        'ConfiguratorApp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(819, 530)
        Me.Controls.Add(Me.stripMenü)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.stripMenü
        Me.Name = "ConfiguratorApp"
        Me.Text = ".NET Assembly Configurator"
        Me.stripMenü.ResumeLayout(False)
        Me.stripMenü.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents stripMenü As System.Windows.Forms.MenuStrip
    Friend WithEvents toolDatei As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolDateiÖffnen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ofdExecutable As System.Windows.Forms.OpenFileDialog
    Friend WithEvents toolHilfe As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolHilfeInfo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolDateiBeenden As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolDateiSep0 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolSaveAll As System.Windows.Forms.ToolStripMenuItem

End Class
