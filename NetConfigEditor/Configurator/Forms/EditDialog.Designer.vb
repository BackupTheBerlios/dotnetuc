<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditDialog
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
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EditDialog))
        Me.dgvKeyValue = New System.Windows.Forms.DataGridView
        Me.dctKey = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dctValue = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.bndKeyValue = New System.Windows.Forms.BindingSource(Me.components)
        Me.stripMenu = New System.Windows.Forms.ToolStrip
        Me.toolReload = New System.Windows.Forms.ToolStripButton
        Me.toolSave = New System.Windows.Forms.ToolStripButton
        Me.toolExit = New System.Windows.Forms.ToolStripButton
        Me.toolSep0 = New System.Windows.Forms.ToolStripSeparator
        Me.toolInfo = New System.Windows.Forms.ToolStripButton
        CType(Me.dgvKeyValue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bndKeyValue, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.stripMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvKeyValue
        '
        Me.dgvKeyValue.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvKeyValue.AutoGenerateColumns = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvKeyValue.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvKeyValue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvKeyValue.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dctKey, Me.dctValue})
        Me.dgvKeyValue.DataSource = Me.bndKeyValue
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvKeyValue.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvKeyValue.Location = New System.Drawing.Point(12, 28)
        Me.dgvKeyValue.Name = "dgvKeyValue"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvKeyValue.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvKeyValue.RowHeadersWidth = 20
        Me.dgvKeyValue.Size = New System.Drawing.Size(418, 419)
        Me.dgvKeyValue.TabIndex = 0
        '
        'dctKey
        '
        Me.dctKey.DataPropertyName = "Key"
        Me.dctKey.HeaderText = "Schlüssel"
        Me.dctKey.Name = "dctKey"
        Me.dctKey.Width = 125
        '
        'dctValue
        '
        Me.dctValue.DataPropertyName = "Value"
        Me.dctValue.HeaderText = "Wert"
        Me.dctValue.Name = "dctValue"
        Me.dctValue.Width = 250
        '
        'bndKeyValue
        '
        Me.bndKeyValue.DataSource = GetType(Softwarekueche.NetConfigurator.Configurator.KeyValue)
        '
        'stripMenu
        '
        Me.stripMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolReload, Me.toolSave, Me.toolExit, Me.toolSep0, Me.toolInfo})
        Me.stripMenu.Location = New System.Drawing.Point(0, 0)
        Me.stripMenu.Name = "stripMenu"
        Me.stripMenu.Size = New System.Drawing.Size(442, 25)
        Me.stripMenu.TabIndex = 3
        Me.stripMenu.Text = "ToolStrip1"
        '
        'toolReload
        '
        Me.toolReload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolReload.Image = Global.Softwarekueche.NetConfigurator.Configurator.My.Resources.Resources.Neuladen3
        Me.toolReload.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolReload.Name = "toolReload"
        Me.toolReload.Size = New System.Drawing.Size(23, 22)
        Me.toolReload.Text = "Neuladen"
        Me.toolReload.ToolTipText = "Neuladen der Konfigurationsdatei"
        '
        'toolSave
        '
        Me.toolSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolSave.Image = Global.Softwarekueche.NetConfigurator.Configurator.My.Resources.Resources.Speichern3
        Me.toolSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolSave.Name = "toolSave"
        Me.toolSave.Size = New System.Drawing.Size(23, 22)
        Me.toolSave.Text = "Speichern"
        Me.toolSave.ToolTipText = "Speichern der Konfigurationsdatei"
        '
        'toolExit
        '
        Me.toolExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolExit.Image = Global.Softwarekueche.NetConfigurator.Configurator.My.Resources.Resources.Beenden3
        Me.toolExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolExit.Name = "toolExit"
        Me.toolExit.Size = New System.Drawing.Size(23, 22)
        Me.toolExit.Text = "Schließen"
        Me.toolExit.ToolTipText = "Schließen des Fensters"
        '
        'toolSep0
        '
        Me.toolSep0.Name = "toolSep0"
        Me.toolSep0.Size = New System.Drawing.Size(6, 25)
        '
        'toolInfo
        '
        Me.toolInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolInfo.Image = Global.Softwarekueche.NetConfigurator.Configurator.My.Resources.Resources.Info3
        Me.toolInfo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolInfo.Name = "toolInfo"
        Me.toolInfo.Size = New System.Drawing.Size(23, 22)
        Me.toolInfo.Text = "Infobox"
        Me.toolInfo.ToolTipText = "Infobox anzeigen"
        '
        'EditDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(442, 459)
        Me.Controls.Add(Me.stripMenu)
        Me.Controls.Add(Me.dgvKeyValue)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "EditDialog"
        Me.ShowInTaskbar = False
        Me.Text = "EditDialog"
        CType(Me.dgvKeyValue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bndKeyValue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.stripMenu.ResumeLayout(False)
        Me.stripMenu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvKeyValue As System.Windows.Forms.DataGridView
    Friend WithEvents bndKeyValue As System.Windows.Forms.BindingSource
    Friend WithEvents dctKey As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dctValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents stripMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents toolReload As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolSep0 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolInfo As System.Windows.Forms.ToolStripButton
End Class
