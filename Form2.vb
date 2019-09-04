
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports Microsoft.Reporting.WinForms
Imports System.Reflection
Imports System.Drawing.Printing
Imports System.IO
Imports System.Drawing.Imaging
Imports System.Drawing
Public Class Form2
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Ooprod_otherDataSet.PrinterQue' table. You can move, or remove it, as needed.
        Me.PrinterQueTableAdapter.Fill(Me.Ooprod_otherDataSet.PrinterQue)

        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub


End Class
