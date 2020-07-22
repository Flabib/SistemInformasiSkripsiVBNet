<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formChildLaporan
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.rvLaporan = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.ayoskripsiDataSet = New Sistem_Informasi_Skripsi.ayoskripsiDataSet()
        Me.laporanBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.laporanTableAdapter = New Sistem_Informasi_Skripsi.ayoskripsiDataSetTableAdapters.laporanTableAdapter()
        CType(Me.ayoskripsiDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.laporanBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rvLaporan
        '
        Me.rvLaporan.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "Laporan"
        ReportDataSource1.Value = Me.laporanBindingSource
        Me.rvLaporan.LocalReport.DataSources.Add(ReportDataSource1)
        Me.rvLaporan.LocalReport.ReportEmbeddedResource = "Sistem_Informasi_Skripsi.templateLaporan.rdlc"
        Me.rvLaporan.Location = New System.Drawing.Point(0, 0)
        Me.rvLaporan.Name = "rvLaporan"
        Me.rvLaporan.Size = New System.Drawing.Size(1134, 511)
        Me.rvLaporan.TabIndex = 0
        '
        'ayoskripsiDataSet
        '
        Me.ayoskripsiDataSet.DataSetName = "ayoskripsiDataSet"
        Me.ayoskripsiDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'laporanBindingSource
        '
        Me.laporanBindingSource.DataMember = "laporan"
        Me.laporanBindingSource.DataSource = Me.ayoskripsiDataSet
        '
        'laporanTableAdapter
        '
        Me.laporanTableAdapter.ClearBeforeFill = True
        '
        'formChildLaporan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1134, 511)
        Me.Controls.Add(Me.rvLaporan)
        Me.Name = "formChildLaporan"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "formChildLaporan"
        CType(Me.ayoskripsiDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.laporanBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents rvLaporan As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents laporanBindingSource As BindingSource
    Friend WithEvents ayoskripsiDataSet As ayoskripsiDataSet
    Friend WithEvents laporanTableAdapter As ayoskripsiDataSetTableAdapters.laporanTableAdapter
End Class
