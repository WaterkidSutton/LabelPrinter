<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
        Dim ReportDataSource3 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.PrinterQueBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Ooprod_otherDataSet = New LabelPrinter.ooprod_otherDataSet()
        Me.PrinterQueTableAdapter = New LabelPrinter.ooprod_otherDataSetTableAdapters.PrinterQueTableAdapter()
        Me.TableAdapterManager = New LabelPrinter.ooprod_otherDataSetTableAdapters.TableAdapterManager()
        Me.PrinterQueDataGridView = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.PrinterQueBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Ooprod_otherDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PrinterQueDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        ReportDataSource3.Name = "DataSet1"
        ReportDataSource3.Value = Me.PrinterQueBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource3)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "LabelPrinter.Rpt_VendorSKU.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(308, 100)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(416, 302)
        Me.ReportViewer1.TabIndex = 5
        '
        'PrinterQueBindingSource
        '
        Me.PrinterQueBindingSource.DataMember = "PrinterQue"
        Me.PrinterQueBindingSource.DataSource = Me.Ooprod_otherDataSet
        '
        'Ooprod_otherDataSet
        '
        Me.Ooprod_otherDataSet.DataSetName = "ooprod_otherDataSet"
        Me.Ooprod_otherDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'PrinterQueTableAdapter
        '
        Me.PrinterQueTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.Connection = Nothing
        Me.TableAdapterManager.UpdateOrder = LabelPrinter.ooprod_otherDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'PrinterQueDataGridView
        '
        Me.PrinterQueDataGridView.AutoGenerateColumns = False
        Me.PrinterQueDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.PrinterQueDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6})
        Me.PrinterQueDataGridView.DataSource = Me.PrinterQueBindingSource
        Me.PrinterQueDataGridView.Location = New System.Drawing.Point(30, 54)
        Me.PrinterQueDataGridView.Name = "PrinterQueDataGridView"
        Me.PrinterQueDataGridView.Size = New System.Drawing.Size(209, 302)
        Me.PrinterQueDataGridView.TabIndex = 4
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "id"
        Me.DataGridViewTextBoxColumn1.HeaderText = "id"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "VendorSKU"
        Me.DataGridViewTextBoxColumn2.HeaderText = "VendorSKU"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "EmployeeKey"
        Me.DataGridViewTextBoxColumn3.HeaderText = "EmployeeKey"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "SubmitTime"
        Me.DataGridViewTextBoxColumn4.HeaderText = "SubmitTime"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "QtytoPrint"
        Me.DataGridViewTextBoxColumn5.HeaderText = "QtytoPrint"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "DoctoPrint"
        Me.DataGridViewTextBoxColumn6.HeaderText = "DoctoPrint"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(308, 63)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(972, 501)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Controls.Add(Me.PrinterQueDataGridView)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Form2"
        Me.Text = "Form2"
        CType(Me.PrinterQueBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Ooprod_otherDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PrinterQueDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents PrinterQueBindingSource As BindingSource
    Friend WithEvents Ooprod_otherDataSet As ooprod_otherDataSet
    Friend WithEvents PrinterQueTableAdapter As ooprod_otherDataSetTableAdapters.PrinterQueTableAdapter
    Friend WithEvents TableAdapterManager As ooprod_otherDataSetTableAdapters.TableAdapterManager
    Friend WithEvents PrinterQueDataGridView As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Friend WithEvents Button1 As Button
End Class
