<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.PrinterQueBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Ooprod_otherDataSet = New LabelPrinter.ooprod_otherDataSet()
        Me.PrinterQueDataGridView = New System.Windows.Forms.DataGridView()
        Me.queid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.PrinterQueTableAdapter = New LabelPrinter.ooprod_otherDataSetTableAdapters.PrinterQueTableAdapter()
        Me.TableAdapterManager = New LabelPrinter.ooprod_otherDataSetTableAdapters.TableAdapterManager()
        CType(Me.PrinterQueBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Ooprod_otherDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PrinterQueDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        'PrinterQueDataGridView
        '
        Me.PrinterQueDataGridView.AllowUserToAddRows = False
        Me.PrinterQueDataGridView.AutoGenerateColumns = False
        Me.PrinterQueDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.PrinterQueDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.queid, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6})
        Me.PrinterQueDataGridView.DataSource = Me.PrinterQueBindingSource
        Me.PrinterQueDataGridView.Location = New System.Drawing.Point(12, 34)
        Me.PrinterQueDataGridView.Name = "PrinterQueDataGridView"
        Me.PrinterQueDataGridView.ReadOnly = True
        Me.PrinterQueDataGridView.Size = New System.Drawing.Size(561, 247)
        Me.PrinterQueDataGridView.TabIndex = 1
        '
        'queid
        '
        Me.queid.DataPropertyName = "id"
        Me.queid.HeaderText = "id"
        Me.queid.Name = "queid"
        Me.queid.ReadOnly = True
        Me.queid.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "VendorSKU"
        Me.DataGridViewTextBoxColumn2.HeaderText = "VendorSKU"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "EmployeeKey"
        Me.DataGridViewTextBoxColumn3.HeaderText = "EmployeeKey"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "SubmitTime"
        Me.DataGridViewTextBoxColumn4.HeaderText = "SubmitTime"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "QtytoPrint"
        Me.DataGridViewTextBoxColumn5.HeaderText = "QtytoPrint"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "DoctoPrint"
        Me.DataGridViewTextBoxColumn6.HeaderText = "DoctoPrint"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 308)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(561, 23)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Manual Start Print"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 5000
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"LabelPrinter1", "LabelPrinter2", "LabelPrinter3"})
        Me.ComboBox1.Location = New System.Drawing.Point(126, 347)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox1.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 350)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(108, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "This Printer is Called: "
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(498, 350)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "Refresh"
        Me.Button2.UseVisualStyleBackColor = True
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
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(620, 392)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.PrinterQueDataGridView)
        Me.Name = "Form1"
        Me.Text = "Label Printer Que"
        CType(Me.PrinterQueBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Ooprod_otherDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PrinterQueDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Ooprod_otherDataSet As ooprod_otherDataSet
    Friend WithEvents PrinterQueBindingSource As BindingSource
    Friend WithEvents PrinterQueTableAdapter As ooprod_otherDataSetTableAdapters.PrinterQueTableAdapter
    Friend WithEvents TableAdapterManager As ooprod_otherDataSetTableAdapters.TableAdapterManager
    Friend WithEvents PrinterQueDataGridView As DataGridView
    Friend WithEvents Button1 As Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents queid As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
End Class
