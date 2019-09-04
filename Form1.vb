
Imports System
Imports System.IO
Imports System.Data
Imports System.Text
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Drawing.Printing
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports Microsoft.Reporting.WinForms


Imports Microsoft.Win32
Imports System.Data.SqlClient
Imports System.Xml

Public Class Form1
    Implements IDisposable
    Private m_currentPageIndex As Integer
    Private m_streams As IList(Of Stream)



    Private Sub PrinterQueBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.PrinterQueBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.Ooprod_otherDataSet)

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Ooprod_otherDataSet.PrinterQue' table. You can move, or remove it, as needed.
        GetRegValues()


        Me.PrinterQueTableAdapter.Fill(Me.Ooprod_otherDataSet.PrinterQue)
        Dim testcount As Integer = PrinterQueBindingSource.Count

        '   ComboBox1.SelectedIndex = 0
        '   Me.ReportViewer1.RefreshReport()
        '  Me.ReportViewer1.RefreshReport()


        ''Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        processprints()

    End Sub
    Sub processprints()
        Timer1.Enabled = False
        For Each rw As DataGridViewRow In PrinterQueDataGridView.Rows
            Dim queid As Integer = rw.Cells("queid").Value
            Dim doctoprint As String = rw.Cells("DataGridViewTextBoxColumn6").Value
            Dim qty As Integer = MNI(rw.Cells("DataGridViewTextBoxColumn5").Value)
            Select Case doctoprint
                Case "VENDORSKU"
                    Dim report As New LocalReport()
                    report.ReportPath = (Application.StartupPath & "\myreports\Rpt_VendorSKU.rdlc")
                    ' TextBox1.Text = report.ReportPath

                    report.DataSources.Add(New ReportDataSource("DataSet1", LoadSalesData(queid)))
                    ExportSingleLabels(report)

                    Print(qty)
                    sql = "Delete from ooprod_other.dbo.PrinterQue where id=" & queid
                    ExecuteSQLStmt(sql)
                Case "VENDORSKUPO"
                    Dim report As New LocalReport()
                    report.ReportPath = (Application.StartupPath & "\myreports\Rpt_SKUPO.rdlc")
                    ' TextBox1.Text = report.ReportPath

                    report.DataSources.Add(New ReportDataSource("DataSet1", LoadSalesData(queid)))
                    ExportSingleLabels(report)

                    Print(qty)
                    sql = "Delete from ooprod_other.dbo.PrinterQue where id=" & queid
                    ExecuteSQLStmt(sql)
                Case "CUTSPIECE"


                    ' Me.ReportViewer1.RefreshReport()

                    'Exit Sub


                    Dim report As New LocalReport()
                    report.ReportPath = (Application.StartupPath & "\myreports\lbl_cutslabel.rdlc")
                    ' TextBox1.Text = report.ReportPath

                    report.DataSources.Add(New ReportDataSource("DataSet1", LoadCutsPiece(queid)))
                    ExportSingleLabels(report)

                    Print(qty)
                    sql = "Delete from ooprod_other.dbo.PrinterQue where id=" & queid
                    ExecuteSQLStmt(sql)
            End Select

        Next
        Timer1.Enabled = True
        Me.PrinterQueTableAdapter.Fill(Me.Ooprod_otherDataSet.PrinterQue)

    End Sub

    Private Function LoadSalesData(queid As Integer) As DataTable
        ' Create a new DataSet and read sales data file 
        ' data.xml into the first DataTable.
        Dim dataSet As New DataSet()
        '   dataSet.ReadXml("..\..\data.xml")

        sql = "SELECT        PrinterQue.id, PrinterQue.VendorSKU, PrinterQue.EmployeeKey, PrinterQue.SubmitTime, PrinterQue.QtytoPrint, PrinterQue.DoctoPrint, vendorproducts.ReorderDescription, ISNULL(PrinterQue.LOCATIONID, 0) AS LOCATIONID, 
                         ISNULL(PrinterQue.PONumber, 0) AS PONumber, vendorproducts.id AS SKUID
FROM              ooprod_other.dbo.PrinterQue INNER JOIN
                             (SELECT        id, VendorID, VendorSKU, VendorName, VendorPrice, VendorQtyPer, PerDescr, ProductID, BulkPrice1, BulkUnit, BulkPrice, Cost, SubBulkUnit, SubBulkQtyPerUnit, BulkQtyPerUnit, PMSmUnit, PmInvUnit, 
                                                         PmBulkUnit, PmInvQty, PmBulkQty, PmDefaultBulk, M1BulkCost, Discount, ReorderDescription, UnitsInStockIhs, Discontinued, NOT_Recomend, Vend_Ref1, Vend_CatRef, Vend_CatYear, Vend_CatPage, 
                                                         PMSmQty, VendorDefPackaging, DiscountPercent, Vend_ColorID, Temp_Updated, Def_Vend_Level
                               FROM            ooprod_InventoryTrans.dbo.VendorProducts AS VendorProducts_1) AS vendorproducts ON PrinterQue.skuid = vendorproducts.id
WHERE        (ooprod_other.dbo.PrinterQue.id = " & queid & ")

"
        Dim thistable As DataTable = SQLGetTable(sql)

        ' dataSet.Tables.Add(thistable)




        Return thistable 'dataSet.Tables(0)
    End Function

    Private Function LoadCutsPiece(queid As Integer) As DataTable
        ' Create a new DataSet and read sales data file 
        ' data.xml into the first DataTable.
        Dim dataSet As New DataSet()
        '   dataSet.ReadXml("..\..\data.xml")

        sql = "SELECT        ooprod_other.dbo.PrinterQue.id, ooprod_other.dbo.PrinterQue.VendorSKU, ooprod_other.dbo.PrinterQue.EmployeeKey, ooprod_other.dbo.PrinterQue.SubmitTime, ooprod_other.dbo.PrinterQue.QtytoPrint, 
                         ooprod_other.dbo.PrinterQue.DoctoPrint, vendorproducts.ReorderDescription, ISNULL(ooprod_other.dbo.PrinterQue.LOCATIONID, 0) AS LOCATIONID, ISNULL(ooprod_other.dbo.PrinterQue.PONumber, 0) AS PONumber, 
                         vendorproducts.id AS SKUID, ooprod_other.dbo.PrinterQue.PrinterName, ooprod_other.dbo.PrinterQue.POLineID, ooprod_other.dbo.PrinterQue.PONumber AS Expr1, ooprod_other.dbo.PrinterQue.LOCATIONID AS Expr2, 
                         ooprod_other.dbo.PrinterQue.CutsPieceID, ooprod_other.dbo.PrinterQue.skuid AS Expr3, derivedtbl_1.inventory_id, derivedtbl_1.FromInvTransID, derivedtbl_1.TransDate, derivedtbl_1.width, derivedtbl_1.height, 
                         derivedtbl_1.material_qty, derivedtbl_1.full_panel, derivedtbl_1.note, derivedtbl_1.piece_id, derivedtbl_1.ColorID, derivedtbl_1.BoxNumber, derivedtbl_1.Loc_RowRack, derivedtbl_1.Loc_ColShelf, derivedtbl_1.Loc_Bin, 
                         derivedtbl_1.Loc_Shelf, derivedtbl_1.cellsize
FROM            ooprod_other.dbo.PrinterQue LEFT OUTER JOIN
                             (SELECT        ooprod_CutsInv.dbo.tbl_cuts_inventory_2010.LabelPrinted, ooprod_CutsInv.dbo.tbl_cuts_inventory_2010.inventory_id, ooprod_CutsInv.dbo.tbl_cuts_inventory_2010.FromInvTransID, 
                                                         CAST(ooprod_CutsInv.dbo.tbl_cuts_inventory_2010.TransDate AS DATE) AS TransDate, ooprod_CutsInv.dbo.tbl_cuts_inventory_2010.width, ooprod_CutsInv.dbo.tbl_cuts_inventory_2010.height, 
                                                         ooprod_CutsInv.dbo.tbl_cuts_inventory_2010.material_qty, ooprod_CutsInv.dbo.tbl_cuts_inventory_2010.full_panel, ooprod_CutsInv.dbo.tbl_cuts_inventory_2010.note, 
                                                         ooprod_CutsInv.dbo.tbl_cuts_inventory_2010.piece_id, products.ColorID, BoxLocations.BoxNumber, BoxLocations.id, warehouse.Loc_RowRack, warehouse.Loc_ColShelf, warehouse.Loc_Bin, 
                                                         warehouse.Loc_Shelf, PrinterQue_1.id AS Quid, ooprod_CutsInv.dbo.tbl_cuts_inventory_2010.cellsize
                               FROM            ooprod_other.dbo.PrinterQue AS PrinterQue_1 INNER JOIN
                                                         ooprod_CutsInv.dbo.tbl_cuts_inventory_2010 ON PrinterQue_1.CutsPieceID = ooprod_CutsInv.dbo.tbl_cuts_inventory_2010.piece_id LEFT OUTER JOIN
                                                             (SELECT        id, LocationName, LocationDesc, Loc_SubLoc1, Loc_SubLoc2, Loc_RowRack, Loc_ColShelf, Loc_Bin, Loc_Shelf, TEMP, EntityKey, BranchID, CaraYN
                                                               FROM            ooprod_InventoryTrans.dbo.InvLocations) AS warehouse INNER JOIN
                                                             (SELECT        id, LocationID_Col_Row, BoxNumber
                                                               FROM            ooprod_CutsInv.dbo.BoxLocations AS BoxLocations_1) AS BoxLocations ON warehouse.id = BoxLocations.LocationID_Col_Row ON 
                                                         ooprod_CutsInv.dbo.tbl_cuts_inventory_2010.BoxLocationID = BoxLocations.id LEFT OUTER JOIN
                                                             (SELECT        id, name, description, minx, maxx, miny, maxy, defaultdiscount, glacct, [glacct-d], division_id, rstypefilter, exproduct, maxgroup, productgroup_id, onlineorder, image, id1, TaxCodeClass, 
                                                                                         Instl_TimeDiv, AssemblyYN, TrackInventoryYN, Building, Location, VendorID, ProductID, ReorderDescription, OurDescription, ColorID, Catagory, PriceGrid, UnitsInStockWhs, UnitsInStockIhs, 
                                                                                         UnitsOnFloor, UnitsInStockCtr1, UnitsInStockCtr2, UnitsOnFloorCtr3, DiscTurnils, UnitsOnOrder, ReorderLevel, InventoryItem, Discontinued, Discount, ShipDate, Notes, BulkPrice1, BulkUnit, 
                                                                                         BulkPrice, SubBulkUnit, SubBulkQtyPerUnit, BulkQtyPerUnit, Length, Cost, Unit, Reorder, ReOrderQty, P1, C1, C2, C3, V1, V2, CD, ML, PL, DL, AG, CP, C2HP, W2HP, F2HP, P2HP, M2HP, M1BulkCost, 
                                                                                         M2SmCost, PMSmUnit, PmInvUnit, PmBulkUnit, PmInvQty, PmBulkQty, PmDefaultBulk, MonthStart, UnitsReceived, UnitsUsed, MonthEnd, SoftShadeDept, VerticalDept, MiniBlindDept, DeluxeDept, 
                                                                                         DraperyDept, BathroomDept, ShelvingDept, OfficeDept, [Tools&Maint], [Shipping&Packaging], Filter, WarehouseLabel, Request, RequestQty, Photo, Request#, [Rod Size], [Drop], Width, 
                                                                                         WireTracking, LineID, RollerShadeDept, WovenWoodDept, a_qty, a_reorder, b_qty, b_reorder, c_qty, c_reorder, location2, location3, PiecesPerUnit, EntityKey, ACTIVE, SingleRetailPrice, 
                                                                                         SimplePricing, ShopID, TEMPSKU, NeedsMeasured, NeedsInstalled, IndvUnit, UsesWidth, UsesDrop, MeasureIncrement, Product_Type
                                                               FROM            products AS products_1) AS products ON ooprod_CutsInv.dbo.tbl_cuts_inventory_2010.inventory_id = products.id) AS derivedtbl_1 ON 
                         ooprod_other.dbo.PrinterQue.id = derivedtbl_1.Quid LEFT OUTER JOIN
                             (SELECT        id, VendorID, VendorSKU, VendorName, VendorPrice, VendorQtyPer, PerDescr, ProductID, BulkPrice1, BulkUnit, BulkPrice, Cost, SubBulkUnit, SubBulkQtyPerUnit, BulkQtyPerUnit, PMSmUnit, PmInvUnit, 
                                                         PmBulkUnit, PmInvQty, PmBulkQty, PmDefaultBulk, M1BulkCost, Discount, ReorderDescription, UnitsInStockIhs, Discontinued, NOT_Recomend, Vend_Ref1, Vend_CatRef, Vend_CatYear, Vend_CatPage, 
                                                         PMSmQty, VendorDefPackaging, DiscountPercent, Vend_ColorID, Temp_Updated, Def_Vend_Level
                               FROM            ooprod_InventoryTrans.dbo.VendorProducts AS VendorProducts_1) AS vendorproducts ON ooprod_other.dbo.PrinterQue.skuid = vendorproducts.id
WHERE        (ooprod_other.dbo.PrinterQue.id = " & queid & ")"


        Dim thistable As DataTable = SQLGetTable(sql)

        ' dataSet.Tables.Add(thistable)




        Return thistable 'dataSet.Tables(0)
    End Function


    ' Routine to provide to the report renderer, in order to
    ' save an image for each page of the report.
    Private Function CreateStream(ByVal name As String, ByVal fileNameExtension As String, ByVal encoding As Encoding, ByVal mimeType As String, ByVal willSeek As Boolean) As Stream
        Dim stream As Stream = New MemoryStream()
        m_streams.Add(stream)
        Return stream
    End Function

    ' Export the given report as an EMF (Enhanced Metafile) file.
    Private Sub ExportSingleLabels(ByVal report As LocalReport)
        Dim deviceInfo As String = "<DeviceInfo>" &
            "<OutputFormat>EMF</OutputFormat>" &
                    "<PageWidth>4in</PageWidth>" &
        "<PageHeight>1in</PageHeight>" & "</DeviceInfo>"

        '"<MarginTop>0.1in</MarginTop>" &
        '        "<MarginLeft>-4.0in</MarginLeft>" &
        '"<MarginRight>0.0in</MarginRight>" &
        '        "<MarginBottom>0.0in</MarginBottom>" &


        Dim warnings As Warning()
        m_streams = New List(Of Stream)()



        report.Render("Image", deviceInfo, AddressOf CreateStream, warnings)
        ''TEST: try and remove 1st 3 pages for labels
        'For j As Integer = 0 To m_streams.Count - 1
        '    m_streams.RemoveAt(0)
        'Next

        Dim testcount As Integer = m_streams.Count
        Dim thiscount As Integer = 0

        For x As Integer = 1 To testcount - 1
            Dim tstream As Stream = m_streams(0)
            m_streams.Remove(tstream)
        Next



        For Each stream As Stream In m_streams
            thiscount = thiscount + 1

            stream.Position = 0


        Next
    End Sub

    ' Handler for PrintPageEvents
    Private Sub PrintPage(ByVal sender As Object, ByVal ev As PrintPageEventArgs)
        Dim pageImage As New Metafile(m_streams(m_currentPageIndex))

        ' Adjust rectangular area with printer margins.

        'Dim adjustedRect As New Rectangle(ev.PageBounds.Left - CInt(ev.PageSettings.HardMarginX),
        '                                  ev.PageBounds.Top - CInt(ev.PageSettings.HardMarginY),
        '                                  ev.PageBounds.Width,
        '                                  ev.PageBounds.Height)

        Dim adjustedRect As New Rectangle(ev.PageBounds.Left - CInt(ev.PageSettings.HardMarginX),
                                          ev.PageBounds.Top - CInt(ev.PageSettings.HardMarginY),
                                          ev.PageBounds.Width,
                                          ev.PageBounds.Height)

        ' Draw a white background for the report
        ev.Graphics.FillRectangle(Brushes.White, adjustedRect)

        ' Draw the report content
        ev.Graphics.DrawImage(pageImage, adjustedRect)

        ' Prepare for the next page. Make sure we haven't hit the end.
        m_currentPageIndex += 1
        ev.HasMorePages = (m_currentPageIndex < m_streams.Count)
    End Sub

    Private Sub Print(SentCopies As Integer)
        If m_streams Is Nothing OrElse m_streams.Count = 0 Then
            Throw New Exception("Error: no stream to print.")
        End If
        Dim printDoc As New PrintDocument()
        printDoc.PrinterSettings.Copies = SentCopies
        If Not printDoc.PrinterSettings.IsValid Then
            Throw New Exception("Error: cannot find the default printer.")
        Else
            AddHandler printDoc.PrintPage, AddressOf PrintPage
            m_currentPageIndex = 0
            printDoc.Print()
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Me.PrinterQueTableAdapter.Fill(Me.Ooprod_otherDataSet.PrinterQue)

        processprints()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

        writeRegistry()
        Try

        Catch ex As Exception

        End Try
        PrinterQueBindingSource.Filter = ""
        PrinterQueBindingSource.Filter = "PrinterName='" & ComboBox1.Text & "'"
    End Sub

    ' Create a local report for Report.rdlc, load the data,
    ' ExportSingleLabels the report to an .emf file, and print it.
    'Private Sub Run()
    'Private Sub VendorSKULabel()
    '    Dim report As New LocalReport()
    '    report.ReportPath = (Application.StartupPath & "\Rpt_VendorSKU.rdlc")
    '    report.DataSources.Add(New ReportDataSource("DataSet1", LoadSalesData()))
    '    ExportSingleLabels(report)
    '    Print()

    'End Sub

    'Public Overloads Sub Dispose() Implements IDisposable.Dispose
    '    If m_streams IsNot Nothing Then
    '        For Each stream As Stream In m_streams
    '            stream.Close()
    '        Next
    '        m_streams = Nothing
    '    End If
    'End Sub
    Sub GetRegValues()
        Dim regKey As RegistryKey
        Try
            regKey = Registry.CurrentUser.OpenSubKey("Software\AIUtility", True)
            'ProductID = regKey.GetValue("PRODUCTID", 0)
            'Get Database Connection and or password here
            Try
                ComboBox1.Text = regKey.GetValue("PrinterName", "")

            Catch ex As Exception

            End Try

            'UserPWTextBox.Text = regKey.GetValue("PW", "")
            'CheckBox1.Checked = regKey.GetValue("PWck", False)

            'DatabasePW = decode(regKey.GetValue("DPass", ""))
            'ADPW = decode(regKey.GetValue("ADPW", ""))
            regKey.Close()

        Catch ex As Exception
            ' createRegistry()
            ' MsgBox("NO REGKEY " & ex.Message)
        End Try
    End Sub
    Function writeRegistry() As Boolean
        Dim regKey As RegistryKey
        Dim ver As Decimal
        writeRegistry = True

        'try to create registry 1st if error then its already there
        Try
            Dim CU As Microsoft.Win32.RegistryKey = Registry.CurrentUser.CreateSubKey("SOFTWARE\AIUtility")
        Catch ex As Exception

        End Try
        Try
            regKey = Registry.CurrentUser.OpenSubKey("Software\AIUtility", True)
            regKey.SetValue("PrinterName", ComboBox1.Text)
            'If CheckBox1.Checked Then
            '    regKey.SetValue("PW", UserPWTextBox.Text)
            '    regKey.SetValue("PWck", "True")

            'Else
            '    regKey.SetValue("PW", "")
            '    regKey.SetValue("PWch", "False")

            'End If
            'regKey.SetValue("VALID", Validyn)
            'regKey.SetValue("CS", MakeCHeckSum(Expdate, Validyn))
            regKey.Close()
        Catch ex As Exception
            writeRegistry = False
        End Try


        'ver = regKey.GetValue("Version", 0.0)
        'If ver < 1.1 Then
        'regKey.SetValue("Version", 1.1)
        ' End If


    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.PrinterQueTableAdapter.Fill(Me.Ooprod_otherDataSet.PrinterQue)

    End Sub
End Class
