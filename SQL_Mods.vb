

Imports System.Data.SqlClient
Imports PopupControl


Module SQL_Mods
    Private ConnectionString As String = CBConnectionString
    Public reader As SqlDataReader = Nothing
    Public conn As New SqlConnection
    Public cmd As SqlCommand = Nothing
    Public AlterTableBtn As System.Windows.Forms.Button
    Public sql As String = Nothing
    Public ProductFolder As String
    Private CreateOthersBtn As System.Windows.Forms.Button
    Private button1 As System.Windows.Forms.Button
    'Public popup As Popup



    Sub CreateNewTable()
        ' Open the connection
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
        ConnectionString = "Integrated Security=SSPI;" + "Initial Catalog=mydb;" + "Data Source=localhost;"
        conn.ConnectionString = ConnectionString
        conn.Open()
        sql = "CREATE TABLE myTable" + "(myId INTEGER CONSTRAINT PKeyMyId PRIMARY KEY," + "myName CHAR(50), myAddress CHAR(255), myBalance FLOAT)"
        cmd = New SqlCommand(sql, conn)
        Try
            cmd.ExecuteNonQuery()
            ' Adding records the table
            sql = "INSERT INTO myTable(myId, myName, myAddress, myBalance) " + "VALUES (1001, 'Puneet Nehra', 'A 449 Sect 19, DELHI', 23.98 ) "
            cmd = New SqlCommand(sql, conn)
            cmd.ExecuteNonQuery()
            sql = "INSERT INTO myTable(myId, myName, myAddress, myBalance) " + "VALUES (1002, 'Anoop Singh', 'Lodi Road, DELHI', 353.64) "
            cmd = New SqlCommand(sql, conn)
            cmd.ExecuteNonQuery()
            sql = "INSERT INTO myTable(myId, myName, myAddress, myBalance) " + "VALUES (1003, 'Rakesh M', 'Nag Chowk, Jabalpur M.P.', 43.43) "
            cmd = New SqlCommand(sql, conn)
            cmd.ExecuteNonQuery()
            sql = "INSERT INTO myTable(myId, myName, myAddress, myBalance) " + "VALUES (1004, 'Madan Kesh', '4th Street, Lane 3, DELHI', 23.00) "
            cmd = New SqlCommand(sql, conn)
            cmd.ExecuteNonQuery()
        Catch ae As SqlException
            MessageBox.Show(ae.Message.ToString())
        End Try



    End Sub

    Public Function ExecuteSQLStmt(ByVal sql As String, Optional DataStringNo As Integer = 1) As Boolean
        ' Open the connection
        ExecuteSQLStmt = True 'start off ok
        Try
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If

            Select Case DataStringNo
                Case 1
                    ConnectionString = My.Settings.ooprod_otherConnectionString.ToString ' CBConnectionString '"Integrated Security=SSPI;" + "Initial Catalog=mydb;" + "Data Source=localhost;"
                    conn.ConnectionString = ConnectionString
                    conn.Open()
                Case 2
                    ConnectionString = My.Settings.ooprod_otherConnectionString.ToString ' CBConnectionString '"Integrated Security=SSPI;" + "Initial Catalog=mydb;" + "Data Source=localhost;"
                    conn.ConnectionString = ConnectionString
                    conn.Open()

                    'Case 3
                    '    ConnectionString = My.Settings.ooprod_InstallConnectionString.ToString ' CBConnectionString '"Integrated Security=SSPI;" + "Initial Catalog=mydb;" + "Data Source=localhost;"
                    '    conn.ConnectionString = ConnectionString
                    '    conn.Open()


            End Select



        Catch ex As Exception
            ExecuteSQLStmt = False
        End Try

        Try
            cmd = New SqlCommand(sql, conn)
            cmd.ExecuteNonQuery()
        Catch ae As SqlException
            If ae.ErrorCode <> -2146232060 Then
                MessageBox.Show("SQLUPDATE:" & ae.Message.ToString())

                ExecuteSQLStmt = False
            End If


        End Try
    End Function 'ExecuteSQLStmt 
    Public Function execSQLGetID(ByVal sql As String, Optional DataStringNo As Integer = 1) As String
        'Send only sql string that returns a 1 simple row / value

        ' Open the connection
        execSQLGetID = Nothing 'start off ok
        Try
            If conn.State = ConnectionState.Open Then
                conn.Close()
            Else

            End If
            Try
                Select Case DataStringNo
                    Case 1
                        ConnectionString = My.Settings.ooprod_otherConnectionString.ToString ' CBConnectionString '"Integrated Security=SSPI;" + "Initial Catalog=mydb;" + "Data Source=localhost;"
                        conn.ConnectionString = ConnectionString
                        conn.Open()
                    Case 2
                        ConnectionString = My.Settings.ooprod_otherConnectionString.ToString ' CBConnectionString '"Integrated Security=SSPI;" + "Initial Catalog=mydb;" + "Data Source=localhost;"
                        conn.ConnectionString = ConnectionString
                        conn.Open()

                        'Case 3
                        '    ConnectionString = My.Settings.ooprod_InstallConnectionString.ToString ' CBConnectionString '"Integrated Security=SSPI;" + "Initial Catalog=mydb;" + "Data Source=localhost;"
                        '    conn.ConnectionString = ConnectionString
                        '    conn.Open()


                End Select
            Catch ex As Exception

            End Try


        Catch ex As Exception
            execSQLGetID = Nothing
            Exit Function
        End Try
        Try
            Dim cmd As SqlCommand = New SqlCommand(sql, conn)
            execSQLGetID = cmd.ExecuteScalar()
        Catch ex As Exception
            execSQLGetID = "Err"
        End Try




    End Function 'ExecuteSQLStmt 
    Public Function GetSQLValue(ByVal sql As String, Optional DataStringNo As Integer = 1) As DataRow
        'Send only sql string that returns a 1 simple row / value

        ' Open the connection
        GetSQLValue = Nothing 'start off ok
        Try
            If conn.State = ConnectionState.Open Then
                conn.Close()
            Else

            End If
            Select Case DataStringNo
                Case 1
                    ConnectionString = My.Settings.ooprod_otherConnectionString.ToString ' CBConnectionString '"Integrated Security=SSPI;" + "Initial Catalog=mydb;" + "Data Source=localhost;"
                    conn.ConnectionString = ConnectionString
                    conn.Open()
                Case 2
                    ConnectionString = My.Settings.ooprod_otherConnectionString.ToString ' CBConnectionString '"Integrated Security=SSPI;" + "Initial Catalog=mydb;" + "Data Source=localhost;"
                    conn.ConnectionString = ConnectionString
                    conn.Open()
                    'Case 3
                    '    ConnectionString = My.Settings.ooprod_InstallConnectionString.ToString ' CBConnectionString '"Integrated Security=SSPI;" + "Initial Catalog=mydb;" + "Data Source=localhost;"
                    '    conn.ConnectionString = ConnectionString
                    '    conn.Open()
            End Select

        Catch ex As Exception
            GetSQLValue = Nothing
            Exit Function
        End Try

        Try
            Dim da As New SqlDataAdapter(sql, conn)

            Dim retval As DataSet = New DataSet
            da.Fill(retval)
            Dim thisdatarow As DataRow
            If retval.Tables(0).Rows.Count = 0 Then

                Exit Function
            End If

            thisdatarow = retval.Tables(0).Rows(0)
            GetSQLValue = thisdatarow
            'GetSQLValue = thisdatarow.Item(0).ToString

        Catch ae As SqlException
            If ae.ErrorCode <> -2146232060 Then
                '  MessageBox.Show("SQLUPDATE:" & ae.Message.ToString())
            End If

            GetSQLValue = Nothing
        End Try
    End Function 'ExecuteSQLStmt 


    Public Function SQLGetTable(ByVal sql As String, Optional DataStringNo As Integer = 1) As DataTable
        ' Open the connection
        SQLGetTable = Nothing 'start off ok
        Try
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            Select Case DataStringNo
                Case 1
                    ConnectionString = My.Settings.ooprod_otherConnectionString.ToString ' CBConnectionString '"Integrated Security=SSPI;" + "Initial Catalog=mydb;" + "Data Source=localhost;"
                    conn.ConnectionString = ConnectionString
                    conn.Open()
                Case 2
                    ConnectionString = My.Settings.ooprod_otherConnectionString.ToString ' CBConnectionString '"Integrated Security=SSPI;" + "Initial Catalog=mydb;" + "Data Source=localhost;"
                    conn.ConnectionString = ConnectionString
                    conn.Open()
                    'Case 3
                    '    ConnectionString = My.Settings.ooprod_InstallConnectionString.ToString ' CBConnectionString '"Integrated Security=SSPI;" + "Initial Catalog=mydb;" + "Data Source=localhost;"
                    '    conn.ConnectionString = ConnectionString
                    '    conn.Open()
            End Select
        Catch ex As Exception
            sql = False
        End Try

        Try
            Dim da As New SqlDataAdapter(sql, conn)
            Dim thisrow As DataRow

            Dim retval As DataSet = New DataSet
            da.Fill(retval)


            'Dim thisdatarow As DataRow
            'If retval.Tables(0).Rows.Count = 0 Then

            '    Exit Function
            'End If

            'thisdatarow = retval.Tables(0).Rows(0)
            'thisrow = thisdatarow

            'GetSQLValue = thisdatarow.Item(0).ToString
            SQLGetTable = retval.Tables(0)
        Catch ae As SqlException
            If ae.ErrorCode <> -2146232060 Then
                '  MessageBox.Show("SQLUPDATE:" & ae.Message.ToString())
            End If

            SQLGetTable = Nothing
        End Try

    End Function 'ExecuteSQLStmt 



    Sub createTable()
        ' Open the connection
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
        ConnectionString = "Integrated Security=SSPI;" + "Initial Catalog=mydb;" + "Data Source=localhost;"
        conn.ConnectionString = ConnectionString
        conn.Open()
        sql = "CREATE TABLE myTable" + "(myId INTEGER CONSTRAINT PKeyMyId PRIMARY KEY," + "myName CHAR(50), myAddress CHAR(255), myBalance FLOAT)"
        cmd = New SqlCommand(sql, conn)
        Try
            cmd.ExecuteNonQuery()
            ' Adding records the table
            sql = "INSERT INTO myTable(myId, myName, myAddress, myBalance) " + "VALUES (1001, 'Puneet Nehra', 'A 449 Sect 19, DELHI', 23.98 ) "
            cmd = New SqlCommand(sql, conn)
            cmd.ExecuteNonQuery()
            sql = "INSERT INTO myTable(myId, myName, myAddress, myBalance) " + "VALUES (1002, 'Anoop Singh', 'Lodi Road, DELHI', 353.64) "
            cmd = New SqlCommand(sql, conn)
            cmd.ExecuteNonQuery()
            sql = "INSERT INTO myTable(myId, myName, myAddress, myBalance) " + "VALUES (1003, 'Rakesh M', 'Nag Chowk, Jabalpur M.P.', 43.43) "
            cmd = New SqlCommand(sql, conn)
            cmd.ExecuteNonQuery()
            sql = "INSERT INTO myTable(myId, myName, myAddress, myBalance) " + "VALUES (1004, 'Madan Kesh', '4th Street, Lane 3, DELHI', 23.00) "
            cmd = New SqlCommand(sql, conn)
            cmd.ExecuteNonQuery()
        Catch ae As SqlException
            MessageBox.Show(ae.Message.ToString())
        End Try

    End Sub

    Sub altertable()
        sql = "ALTER TABLE MyTable ALTER COLUMN" + "myName CHAR(100) NOT NULL"
        ExecuteSQLStmt(sql)

    End Sub
    Public Sub AppExit()
        If Not (reader Is Nothing) Then
            reader.Close()
        End If
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
    End Sub 'AppExit
    Public Sub updateCBDatabase()

        'Add 
        sql = "ALTER TABLE Insul_ChangeOrders ADD" + " Remedial bit NULL"
        'sql = "SELECT * FROM Insul_ChangeOrders"
        ExecuteSQLStmt(sql)
    End Sub

    'Sub CB_Alter_Employees(ByVal CB_Column As String)


    '    Select Case CB_Column

    '        Case "pw"

    '            sql = "ALTER TABLE Employees ADD" + " pw nvarchar(50) NULL"


    '        Case "email"
    '            sql = "ALTER TABLE Employees ADD" + " email nvarchar(255) NULL"

    '        Case "lastsyncdate"
    '            sql = "ALTER TABLE Employees ADD" + " lastsyncdate datetime NULL"
    '        Case "msgnumber"
    '            sql = "ALTER TABLE Employees ADD" + " msgnumber int NULL"

    '    End Select

    '    ExecuteSQLStmt(sql)

    'End Sub
    'Sub CB_Alter_Customers(ByVal CB_Column As String)


    '    Select Case CB_Column

    '        Case "maplat"

    '            sql = "ALTER TABLE Customers ADD" + " maplat float NULL"


    '        Case "maplong"
    '            sql = "ALTER TABLE Customers ADD" + " maplong float NULL"

    '        Case "STATUS"

    '            sql = "ALTER TABLE Customers ADD" + " STATUS [int] NULL"


    '    End Select

    '    ExecuteSQLStmt(sql)

    'End Sub

    'Sub CB_Alter_InsulOrderDetails(ByVal CB_Column As String)


    '    Select Case CB_Column

    '        Case "UserLineNotes"

    '            sql = "ALTER TABLE Insul_Order_Details ADD" + " UserLineNotes nvarchar(255) NULL"

    '        Case "LineStatus"
    '            sql = "ALTER TABLE Insul_Order_Details ADD" + " LineStatus nvarchar(50) NULL"
    '        Case "Calc_OriginalLP"
    '            sql = "ALTER TABLE Insul_Order_Details ADD" + " Calc_OriginalLP float NULL"
    '        Case "HiddenLineItem"
    '            sql = ""
    '            sql = "ALTER TABLE Insul_Order_Details ADD" + " HiddenLineItem bit NULL"
    '        Case "LaborOnlyItem"
    '            sql = "ALTER TABLE Insul_Order_Details ADD" + " LaborOnlyItem bit NULL"

    '        Case "InternalFlag"
    '            sql = "ALTER TABLE Insul_Order_Details ADD" + " InternalFlag [int] NULL"

    '    End Select

    '    ExecuteSQLStmt(sql)

    'End Sub
    'Sub CB_Alter_InsulOrders(ByVal CB_Column As String)


    '    Select Case CB_Column

    '        Case "MessageBoard"

    '            sql = "ALTER TABLE Insul_Orders ADD" + " MessageBoard ntext NULL"

    '        Case "maplat"

    '            sql = "ALTER TABLE Insul_Orders ADD" + " maplat float NULL"


    '        Case "maplong"
    '            sql = "ALTER TABLE Insul_Orders ADD" + " maplong float NULL"

    '        Case "InternalFlag"
    '            sql = "ALTER TABLE Insul_Orders ADD" + " InternalFlag [int] NULL"
    '    End Select

    '    ExecuteSQLStmt(sql)

    'End Sub
    'Sub CB_Alter_FP_Orders(ByVal CB_Column As String)

    '    Select Case CB_Column
    '        Case "ALL"
    '            sql = ""
    '            sql = sql + "CREATE TABLE [dbo].[FP_Orders]("
    '            sql = sql + "[FP_OrderID] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,"
    '            sql = sql + "[OrderKey] [nvarchar](50) NULL,"
    '            sql = sql + "[ChangeID] [nvarchar](50) NULL,"
    '            sql = sql + "[ShippingMethodID] [int] NULL,"
    '            sql = sql + "[CustomerKey] [nvarchar](50) NULL,"
    '            sql = sql + "[EmployeeID] [int] NULL,"
    '            sql = sql + "[OrderDate] [datetime] NULL,"
    '            sql = sql + "[PurchaseOrderNumber] [nvarchar](30) NULL,"
    '            sql = sql + "[PlanNumber] [nvarchar](50) NULL,"
    '            sql = sql + "[ShipName] [nvarchar](50) NULL,"
    '            sql = sql + "[ShipAddress] [nvarchar](255) NULL,"
    '            sql = sql + "[ShipCity] [nvarchar](50) NULL,"
    '            sql = sql + "[ShipStateOrProvince] [nvarchar](50) NULL,"
    '            sql = sql + "[ShipPostalCode] [nvarchar](20) NULL,"
    '            sql = sql + "[ShipCountry] [nvarchar](50) NULL,"
    '            sql = sql + "[ShipPhoneNumber] [nvarchar](30) NULL,"
    '            sql = sql + "[ShipDate] [datetime] NULL,"
    '            sql = sql + "[FreightCharge] [money] NULL,"
    '            sql = sql + "[SalesTaxRate] [float] NULL,"
    '            sql = sql + "[DriveDirections] [nvarchar](max) NULL,"
    '            sql = sql + "[InstallDirections] [nvarchar](max) NULL,"
    '            sql = sql + "[Terms] [nvarchar](max) NULL,"
    '            sql = sql + "[InvoiceNotes] [nvarchar](max) NULL,"
    '            sql = sql + "[OrderType] [nvarchar](50) NULL,"
    '            sql = sql + "[DeptType] [nvarchar](50) NULL,"
    '            sql = sql + "[DefaultDiscount] [float] NULL,"
    '            sql = sql + "[ProjectType] [nvarchar](50) NULL,"
    '            sql = sql + "[Mileage] [int] NULL,"
    '            sql = sql + "[Other] [nvarchar](255) NULL,"
    '            sql = sql + "[JSupervisor] [nvarchar](255) NULL,"
    '            sql = sql + "[CellNo] [nvarchar](255) NULL,"
    '            sql = sql + "[ChangeWork] [nvarchar](max) NULL,"
    '            sql = sql + "[ChangeAmount] [money] NULL,"
    '            sql = sql + "[ChangeDate] [datetime] NULL,"
    '            sql = sql + "[OrderNum] [nvarchar](255) NULL,"
    '            sql = sql + "[Exported] [nvarchar](255) NULL,"
    '            sql = sql + "[STATUS] [int] NULL,"
    '            sql = sql + "[EmployeeKey] [nvarchar](50) NULL,"
    '            sql = sql + "[ExportNow] [bit] NULL,"
    '            sql = sql + "[LastEditDate] [datetime] NULL,"
    '            sql = sql + "[CreationDate] [datetime] NULL,"
    '            sql = sql + "[LICheck] [bit] NULL,"
    '            sql = sql + "[Sync_Status] [nvarchar](50) NULL,"
    '            sql = sql + "[Sync_Errors] [nvarchar](255) NULL,"
    '            sql = sql + "[MessageBoard] [ntext] NULL,"
    '            sql = sql + "[CBProduct] [nvarchar](50) NULL,"
    '            sql = sql + "[maplat] [float] NULL,"
    '            sql = sql + "[maplong] [float] NULL)"
    '            ExecuteSQLStmt(sql)
    '        Case "CBProduct"
    '            sql = "ALTER TABLE FP_Orders ADD" + " CBProduct nvarchar(50) NULL"
    '            ExecuteSQLStmt(sql)
    '        Case "maplat"
    '            sql = "ALTER TABLE FP_Orders ADD" + " maplat [float] NULL"
    '            ExecuteSQLStmt(sql)
    '        Case "maplong"
    '            sql = "ALTER TABLE FP_Orders ADD" + " maplong [float] NULL"
    '            ExecuteSQLStmt(sql)

    '        Case "gutter"
    '            sql = "ALTER TABLE FP_Orders ADD "
    '            sql = sql + "[GRoofAnchors] [nvarchar](50) NULL,"
    '            sql = sql + "[GBuildingheight] [nvarchar](50) NULL,"
    '            sql = sql + "[GPitch] [nvarchar](50) NULL,"
    '            sql = sql + "[GTypeofRoof] [nvarchar](50) NULL,"
    '            sql = sql + "[GSpikeFerrule] [nvarchar](50) NULL,"
    '            sql = sql + "[GHiddenHanger] [nvarchar](50) NULL,"
    '            sql = sql + "[GTileCaps] [nvarchar](50) NULL"

    '            ExecuteSQLStmt(sql)

    '    End Select


    'End Sub
    'Sub CB_Alter_FP_Order_Details(ByVal CB_Column As String)
    '    Select Case CB_Column
    '        Case "ALL"
    '            sql = ""

    '            sql = sql + "CREATE TABLE [dbo].[FP_Order_Details]("
    '            sql = sql + "[FP_Order_DetailID] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,"
    '            sql = sql + "[Quantity] [float] NULL,"
    '            sql = sql + "[UnitPrice] [money] NULL,"
    '            sql = sql + "[Discount] [float] NULL,"
    '            sql = sql + "[ProductOC] [nvarchar](50) NULL,"
    '            sql = sql + "[ProductCH] [int] NULL,"
    '            sql = sql + "[Labor] [float] NULL,"
    '            sql = sql + "[LaborType] [nvarchar](50) NULL,"
    '            sql = sql + "[ProductName] [nvarchar](255) NULL,"
    '            sql = sql + "[ProductShortName] [nvarchar](255) NULL,"
    '            sql = sql + "[CompPrintOrder] [nvarchar](255) NULL,"
    '            sql = sql + "[CompOnePrice] [int] NULL,"
    '            sql = sql + "[OrderKey] [nvarchar](50) NULL,"
    '            sql = sql + "[VendorID] [int] NULL,"
    '            sql = sql + "[VendorPrice] [float] NULL,"
    '            sql = sql + "[DetailKey] [nvarchar](50) NULL,"
    '            sql = sql + "[LocalProductID] [int] NULL,"
    '            sql = sql + "[ChangeOrderKey] [nvarchar](50) NULL,"
    '            sql = sql + "[OptionalItem] [bit] NULL,"
    '            sql = sql + "[LastEditDate] [datetime] NULL,"
    '            sql = sql + "[CreationDate] [datetime] NULL,"
    '            sql = sql + "[CalcRowPrice] [float] NULL,"
    '            sql = sql + "[CalcBagsRequired] [float] NULL,"
    '            sql = sql + "[CalcLaborPrice] [float] NULL,"
    '            sql = sql + "[CalcMargin] [float] NULL,"
    '            sql = sql + "[OriginalListPrice] [float] NULL,"
    '            sql = sql + "[ProductKey] [nvarchar](50) NULL,"
    '            sql = sql + "[NODISCOUNT] [bit] NULL,"
    '            sql = sql + "[SKUONEPRICE] [bigint] NULL,"
    '            sql = sql + "[Sync_Status] [nvarchar](50) NULL,"
    '            sql = sql + "[Sync_Errors] [nvarchar](255) NULL,"
    '            sql = sql + "[ForcedMargin] [float] NULL,"
    '            sql = sql + "[CoProductName] [nvarchar](255) NULL,"
    '            sql = sql + "[UserLineNotes] [nvarchar](255) NULL,"
    '            sql = sql + "[LineStatus] nvarchar(50) NULL,"
    '            sql = sql + "[InstallArea] nvarchar(255) NULL,"
    '            sql = sql + "[CBProduct] [nvarchar](50) NULL,"
    '            sql = sql + "[Calc_OriginalLP] float NULL,"
    '            sql = sql + "[HiddenLineItem] bit NULL)"

    '        Case "LineStatus"
    '            sql = "ALTER TABLE FP_Order_Details ADD" + " LineStatus nvarchar(50) NULL"

    '        Case "InstallArea"
    '            sql = "ALTER TABLE FP_Order_Details ADD" + " InstallArea nvarchar(50) NULL"

    '        Case "CBProduct"
    '            sql = "ALTER TABLE FP_Order_Details ADD" + " CBProduct nvarchar(50) NULL"
    '        Case "Calc_OriginalLP"
    '            sql = "ALTER TABLE FP_Order_Details ADD" + " Calc_OriginalLP float NULL"
    '        Case "HiddenLineItem"
    '            sql = ""
    '            sql = "ALTER TABLE FP_Order_Details ADD" + " HiddenLineItem bit NULL"

    '        Case "Color"
    '            sql = ""
    '            sql = "ALTER TABLE FP_Order_Details ADD" + " Color nvarchar(255) NULL"
    '            '   sql = "ALTER TABLE FP_Order_Details ADD" + " Size nvarchar(50) NULL"

    '        Case "Size"
    '            sql = ""
    '            '   sql = "ALTER TABLE FP_Order_Details ADD" + " Color nvarchar(255) NULL"
    '            sql = "ALTER TABLE FP_Order_Details ADD" + " Size nvarchar(50) NULL"


    '    End Select

    '    ExecuteSQLStmt(sql)

    'End Sub
    'Sub CB_Alter_FP_Products(ByVal CB_Column As String)
    '    Select Case CB_Column
    '        Case "ALL"
    '            sql = ""
    '            sql = sql + "CREATE TABLE [dbo].[FP_Products]("
    '            sql = sql + "[FP_ProductID] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,"
    '            sql = sql + "[ProductName] [nvarchar](255) NULL,"
    '            sql = sql + "[CustomerDesc] [nvarchar](255) NULL,"
    '            sql = sql + "[ProductRValue] [nvarchar](50) NULL,"
    '            sql = sql + "[UnitPrice] [money] NULL,"
    '            sql = sql + "[BlowBatt] [nvarchar](50) NULL,"
    '            sql = sql + "[SKU] [nvarchar](50) NULL,"
    '            sql = sql + "[Length] [int] NULL,"
    '            sql = sql + "[USEDYN] [bit] NULL,"
    '            sql = sql + "[Width] [int] NULL,"
    '            sql = sql + "[AltLaborRate] [float] NULL,"
    '            sql = sql + "[VendorPrice] [money] NULL,"
    '            sql = sql + "[VendorID] [int] NULL,"
    '            sql = sql + "[LastEditDate] [datetime] NULL,"
    '            sql = sql + "[CreationDate] [datetime] NULL,"
    '            sql = sql + "[Footageper] [float] NULL,"
    '            sql = sql + "[UnitShortDesc] [nvarchar](50) NULL,"
    '            sql = sql + "[NODISCOUNT] [bit] NULL,"
    '            sql = sql + "[ProductKey] [nvarchar](50) NULL,"
    '            sql = sql + "[SKUONEPRICE] [bit] NULL,"
    '            sql = sql + "[ForcedMargin] [float] NULL,"
    '            sql = sql + "[Assembed] [int] NULL,"
    '            sql = sql + "[Calc_AssemblyCheck] [int] NULL,"
    '            sql = sql + "[CBProduct] [nvarchar](50) NULL)"
    '        Case "AltLaborRate"
    '            sql = "ALTER TABLE FP_Products ALTER COLUMN " + " AltLaborRate  [float] NULL"


    '        Case "CBProduct"
    '            sql = "ALTER TABLE FP_Products ADD" + " CBProduct nvarchar(50) NULL"
    '        Case "HiddenLineItem"
    '            sql = ""
    '            sql = "ALTER TABLE FP_Products ADD" + " HiddenLineItem bit NULL"

    '    End Select

    '    ExecuteSQLStmt(sql)

    'End Sub

    'Sub CB_Alter_InsulProducts(ByVal CB_Column As String)
    '    Select Case CB_Column
    '        Case "HiddenLineItem"
    '            sql = ""
    '            sql = "ALTER TABLE Insul_Products ADD" + " HiddenLineItem bit NULL"
    '        Case "LaborOnlyItem"
    '            sql = "ALTER TABLE Insul_Products ADD" + " LaborOnlyItem bit NULL"

    '    End Select

    '    ExecuteSQLStmt(sql)

    'End Sub
    'Sub CB_Alter_Insul_InventoryTrans(ByVal CB_Column As String)
    '    Select Case CB_Column
    '        Case "LaborType"
    '            sql = ""
    '            sql = "ALTER TABLE Insul_InventoryTrans ADD" + " LaborType nvarchar(50) NULL,"
    '            sql = "ALTER TABLE Insul_InventoryTrans ADD" + " LaborRate [float] NULL"

    '    End Select

    '    ExecuteSQLStmt(sql)

    'End Sub

    'Sub CB_Alter_FP_Status(ByVal CB_Column As String)
    '    Select Case CB_Column
    '        Case "ALL"
    '            sql = ""
    '            sql = sql + " CREATE TABLE [dbo].[FP_Status]("
    '            sql = sql + "[FP_StatusID] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,"
    '            sql = sql + "[FP_Status] [nvarchar](20) NULL,"
    '            sql = sql + "[FP_StatusVal] [int] NULL,"
    '            sql = sql + "[CBProduct] [nvarchar](50) NULL)"
    '    End Select

    '    ExecuteSQLStmt(sql)

    'End Sub
    'Sub CB_Alter_FP_LaborTypes(ByVal CB_Column As String)
    '    Select Case CB_Column
    '        Case "ALL"
    '            sql = ""


    '            sql = sql + "CREATE TABLE [dbo].[FP_LaborTypes]("
    '            sql = sql + "[LaborType] [nvarchar](50) NOT NULL,"
    '            sql = sql + "[LaborTypeID] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,"
    '            sql = sql + "[LastEditDate] [datetime] NULL,"
    '            sql = sql + "[CreationDate] [datetime] NULL,"
    '            sql = sql + "[Order] [int] NULL,"
    '            sql = sql + "[QuickBooks_InvItem] [nvarchar](50) NULL,"
    '            sql = sql + "[CBPRODUCT] [nvarchar](50) NULL)"
    '    End Select

    '    ExecuteSQLStmt(sql)

    'End Sub

    'Sub CB_Alter_LaborTypes(ByVal CB_Column As String)
    '    Select Case CB_Column
    '        Case "Cust_Desc"
    '            sql = ""

    '            sql = "ALTER TABLE Insul_LaborType ADD" + " Cust_Desc [nvarchar](100) NULL"
    '    End Select

    '    ExecuteSQLStmt(sql)

    'End Sub

    'Sub CB_Alter_FP_InvbyLabor(ByVal CB_Column As String)
    '    Select Case CB_Column
    '        Case "ALL"
    '            sql = ""

    '            sql = sql + " CREATE TABLE [dbo].[FP_InvbyLabor]("
    '            sql = sql + "[FP_InvbyLaborID] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,"
    '            sql = sql + "[OrderKey] [nvarchar](50) NULL,"
    '            sql = sql + "[LaborType] [nvarchar](50) NULL,"
    '            sql = sql + "[Invoiced] [bit] NULL,"
    '            sql = sql + "[InvoicedAmount] [float] NULL,"
    '            sql = sql + "[InvoiceStatus] [nvarchar](50) NULL,"
    '            sql = sql + "[ChangeOrderKey] [nvarchar](50) NULL,"
    '            sql = sql + "[InvoiceRef] [nvarchar](50) NULL)"




    '    End Select

    '    ExecuteSQLStmt(sql)

    'End Sub
    'Sub CB_Alter_FP_Assembly(ByVal CB_Column As String)
    '    Select Case CB_Column
    '        Case "ALL"
    '            sql = ""
    '            sql = sql + "CREATE TABLE [dbo].[FP_Assembly]("
    '            sql = sql + "[FP_AssemblyID] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,"
    '            sql = sql + "[FP_ProductKey] [nvarchar](50) NULL,"
    '            sql = sql + "[FP_AssblyProductKey] [nvarchar](50) NULL,"
    '            sql = sql + "[FP_Quantity] [float] NULL,"
    '            sql = sql + "[CBProduct] [nvarchar](50) NULL,"
    '            sql = sql + "[FP_AssemblyKey] [nvarchar](50) NULL)"
    '        Case "FP_AssemblyKey"
    '            sql = "ALTER TABLE FP_Assembly ADD" + " FP_AssemblyKey [nvarchar](50) NULL"
    '        Case "CBProduct"
    '            sql = "ALTER TABLE FP_Assembly ADD" + " CBProduct nvarchar(50) NULL"

    '    End Select

    '    ExecuteSQLStmt(sql)
    'End Sub
    'Sub CB_Alter_FP_ChangeOrder(ByVal CB_Column As String)
    '    Select Case CB_Column
    '        Case "ALL"
    '            sql = ""
    '            sql = sql + "CREATE TABLE [dbo].[FP_ChangeOrder](
    '            sql = sql + "[FP_ChangeOrderID] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,"
    '            sql = sql + "[FP_OrderKey] [nvarchar](50) NULL,"
    '            sql = sql + "[FP_DetailKey] [nvarchar](50) NULL,"
    '            sql = sql + "[ChangeOrderDate] [datetime] NULL,"
    '            sql = sql + "[ChangeOrderKey] [nvarchar](50) NULL,"
    '            sql = sql + "[ChangeOrderDesc] [nvarchar](255) NULL,"
    '            sql = sql + "[ChangeOrderNotes] [ntext] NULL,"
    '            sql = sql + "[Exported] [int] NULL,"
    '            sql = sql + "[STATUS] [int] NULL,"
    '            sql = sql + "[LastEditDate] [datetime] NULL,"
    '            sql = sql + "[CreationDate] [datetime] NULL,"
    '            sql = sql + "[Remedial] [bit] NULL,"
    '            sql = sql + "[CBProduct] [nvarchar](50) NULL)"

    '        Case "CBProduct"
    '            sql = "ALTER TABLE FP_ChangeOrder ADD" + " CBProduct nvarchar(50) NULL"

    '    End Select

    '    ExecuteSQLStmt(sql)
    'End Sub

    'Sub CB_Alter_Suggestions(ByVal CB_Column As String)
    '    Select Case CB_Column
    '        Case "ALL"
    '            sql = ""

    '            sql = sql + "CREATE TABLE [dbo].[Suggestions]("
    '            sql = sql + "[suggestionID] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,"
    '            sql = sql + "[Suggestion_Long] [ntext] NULL,"
    '            sql = sql + "[Suggestion_Short] [nvarchar](255) NULL,"
    '            sql = sql + "[SuggestionLevel] [nvarchar](50) NULL,"
    '            sql = sql + "[SuggesterKey] [nvarchar](50) NULL,"
    '            sql = sql + "[TODO_Level] [nvarchar](50) NULL,"
    '            sql = sql + "[LastEditDate] [datetime] NULL,"
    '            sql = sql + "[SugKey] [nvarchar](50) NULL,"
    '            sql = sql + "[OrigSugKey] [nvarchar](50) NULL)"

    '    End Select

    '    ExecuteSQLStmt(sql)
    'End Sub
    'Sub CB_Alter_MakeDespatch(ByVal CB_Column As String)
    '    Select Case CB_Column
    '        Case "ALL"
    '            sql = ""

    '            sql = sql + "CREATE TABLE [dbo].[CB_Despatch]("
    '            sql = sql + "[dispatchid] [int] IDENTITY(1,1) NOT NULL, PRIMARY KEY,"
    '            sql = sql + "[EmployeeKey] [nvarchar](50) NULL,"
    '            sql = sql + "[OrderKey] [nvarchar](50) NULL,"
    '            sql = sql + "[SchedDate] [datetime] NULL,"
    '            sql = sql + "[SchedTime] [float] NULL,"
    '            sql = sql + "[WorkedDate] [datetime] NULL,"
    '            sql = sql + "[WorkedTime] [float] NULL,"
    '            sql = sql + "[SchedPercent] [float] NULL"
    '            sql = sql + ") ON [PRIMARY]"
    '    End Select

    '    ExecuteSQLStmt(sql)
    'End Sub


    'Sub updateUTCDate(ByVal CB_Column As String)
    '    Select Case CB_Column
    '        Case "ALL"
    '            sql = ""
    '            sql = sql + "UPDATE Customers "
    '            sql = sql + "SET LastEditDate = DateAdd(hh, DateDiff(hh, GETDATE(), GETUTCDATE()), LastEditDate)"
    '            ExecuteSQLStmt(sql)

    '            sql = ""
    '            sql = sql + "UPDATE Insul_Orders "
    '            sql = sql + "SET LastEditDate = DateAdd(hh, DateDiff(hh, GETDATE(), GETUTCDATE()), LastEditDate)"
    '            ExecuteSQLStmt(sql)

    '            sql = ""
    '            sql = sql + "UPDATE Insul_ChangeOrders "
    '            sql = sql + "SET LastEditDate = DateAdd(hh, DateDiff(hh, GETDATE(), GETUTCDATE()), LastEditDate)"
    '            ExecuteSQLStmt(sql)

    '    End Select

    '    ExecuteSQLStmt(sql)
    'End Sub

    'Sub CB_Alter_fallprotection(ByVal CB_Column As String)
    '    Select Case CB_Column
    '        Case "ALL"
    '            sql = ""


    '            sql = sql + "CREATE TABLE [dbo].[fallprotection]("
    '            sql = sql + "[FallProtectID] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,"
    '            sql = sql + "[OrderKey] [nvarchar](50) NULL,"
    '            sql = sql + "[FallProtectKey] [nvarchar](50) NULL,"
    '            sql = sql + "[GENERALORDERLINESS] [nvarchar](50) NULL,"
    '            sql = sql + "[HAZARDSFROMOTHERS] [nvarchar](50) NULL,"
    '            sql = sql + "[FALLPROTECTIONINPLACE] [nvarchar](50) NULL,"
    '            sql = sql + "[FLOOROPENINGS] [nvarchar](50) NULL,"
    '            sql = sql + "[WORKAREASFREEOF] [nvarchar](50) NULL,"
    '            sql = sql + "[WORKERSPROTECTED] [nvarchar](50) NULL,"
    '            sql = sql + "[PROPERACCESS] [nvarchar](50) NULL,"
    '            sql = sql + "[OTHER] [nvarchar](50) NULL,"
    '            sql = sql + "[OTHERTEXT] [nvarchar](50) NULL,"
    '            sql = sql + "[SINGLELEVEL810] [bit] NULL,"
    '            sql = sql + "[TWOSTORY1820] [bit] NULL,"
    '            sql = sql + "[THREESTORY21UP] [bit] NULL,"
    '            sql = sql + "[ROOFTYPE] [bit] NULL,"
    '            sql = sql + "[ROOFTYPETEXT] [nvarchar](50) NULL,"
    '            sql = sql + "[ROOFPITCH] [bit] NULL,"
    '            sql = sql + "[ROOFPITCHTEXT] [nvarchar](50) NULL,"
    '            sql = sql + "[GRADEOFWORK] [bit] NULL,"
    '            sql = sql + "[GRADEOFWORKTEXT] [nvarchar](50) NULL,"
    '            sql = sql + "[EXTERIOROTHER] [bit] NULL,"
    '            sql = sql + "[EXTERIOROTHERTEXT] [nvarchar](50) NULL,"
    '            sql = sql + "[STEPLADDERSIZE] [bit] NULL,"
    '            sql = sql + "[STEPLADDERTEXT] [nvarchar](50) NULL,"
    '            sql = sql + "[EXTENTIONLADDER] [bit] NULL,"
    '            sql = sql + "[EXTENTIONLADDERTEXT] [nvarchar](50) NULL,"
    '            sql = sql + "[HARNESSFULLBODY] [bit] NULL,"
    '            sql = sql + "[SUPERANCHOR] [bit] NULL,"
    '            sql = sql + "[SUPERANCHORTEXT] [nvarchar](50) NULL,"
    '            sql = sql + "[EXTERIOROTHER2] [bit] NULL,"
    '            sql = sql + "[EXTERIOROTHER2TEXT] [nvarchar](50) NULL,"
    '            sql = sql + "[HIGHENTRYWAY] [bit] NULL,"
    '            sql = sql + "[STAIRWAYHEIGHT] [bigint] NULL,"
    '            sql = sql + "[STAIRWAYHEIGHTTEXT] [nvarchar](50) NULL,"
    '            sql = sql + "[CATHREDRALCA] [bit] NULL,"
    '            sql = sql + "[CATHREDRALCATEXT] [nvarchar](50) NULL,"
    '            sql = sql + "[SKYLIGHTS] [bit] NULL,"
    '            sql = sql + "[HIGHFLATCA] [bit] NULL,"
    '            sql = sql + "[HIGHUNDERFLOOR] [bit] NULL,"
    '            sql = sql + "[WALLS] [bit] NULL,"
    '            sql = sql + "[WALLSTEXT] [nvarchar](50) NULL,"
    '            sql = sql + "[INTERIOROTHER] [bit] NULL,"
    '            sql = sql + "[INTERIOROTHERTEXT] [nvarchar](50) NULL,"
    '            sql = sql + "[SSWS8PLANKHT] [bit] NULL,"
    '            sql = sql + "[SSWSOOVER8PLANKHT] [bit] NULL,"
    '            sql = sql + "[DSWDP10PLANKHT] [bit] NULL,"
    '            sql = sql + "[DSWS1016PLANKHT] [bit] NULL,"
    '            sql = sql + "[DSWOSOVER16PLANKHT] [bit] NULL,"
    '            sql = sql + "[HAMMER] [bit] NULL,"
    '            sql = sql + "[NAILS] [bit] NULL,"
    '            sql = sql + "	[ADDL2X4S] [bit] NULL,"
    '            sql = sql + "[EXPOSEDBEAMS] [bit] NULL,"
    '            sql = sql + "[INTERIORHARNESSFULLBODY] [bit] NULL,"
    '            sql = sql + "[PLANKSNEEDED] [bit] NULL,"
    '            sql = sql + "[PLANKS8] [nvarchar](50) NULL,"
    '            sql = sql + "	[PLANKS12] [nvarchar](50) NULL,"
    '            sql = sql + "[SCAFFOLD] [nvarchar](50) NULL,"
    '            sql = sql + "[PLANKSOTHER] [nvarchar](50) NULL,"
    '            sql = sql + "[INTERIOREXTENTIONLADDER] [bit] NULL,"
    '            sql = sql + "[EXTLADDER20] [nvarchar](50) NULL,"
    '            sql = sql + "[EXTLADDER24] [nvarchar](50) NULL,"
    '            sql = sql + "[EXTLADDER28] [nvarchar](50) NULL,"
    '            sql = sql + "[EXTLADDER32] [nvarchar](50) NULL,"
    '            sql = sql + "[EXTLADDER40] [nvarchar](50) NULL,"
    '            sql = sql + "[INTERIORSTPLADDERSIZE] [bit] NULL,"
    '            sql = sql + "[INTERIORSTPLADDERSIZETEXT] [nvarchar](50) NULL,"
    '            sql = sql + "[SCISSORLIFT] [bit] NULL,"
    '            sql = sql + "[INTERIOROTHER2] [bit] NULL,"
    '            sql = sql + "[INTERIOROTHER2TEXT] [nvarchar](50) NULL,"
    '            sql = sql + "[INTERIOROTHER3] [bit] NULL,"
    '            sql = sql + "	[INTERIOROTHER3TEXT] [nvarchar](50) NULL,"
    '            sql = sql + "[CBProduct] [nvarchar](50) NULL)"


    '    End Select
    '    ExecuteSQLStmt(sql)

    'End Sub

    'Public Function checkadminrightsYN(loginname As String) As Boolean

    '    checkadminrightsYN = False
    '    ADMINRIGHTS = False
    '    'check admin privs for 

    '    sql = ("Select Administrator, ID, name from users where id='" & loginname & "'")
    '    Dim adminuser As DataRow = GetSQLValue(sql)
    '    If Not IsNothing(adminuser) Then
    '        If MDB(adminuser("Administrator")) = True Then
    '            checkadminrightsYN = True
    '            ADMINRIGHTS = True


    '        End If

    '    Else
    '        sql = ("Select Administrator, ID, name from users where Alt_EasyLoginid='" & loginname & "'")
    '        adminuser = GetSQLValue(sql)
    '        If Not IsNothing(adminuser) Then
    '            If MDB(adminuser("Administrator")) = True Then
    '                checkadminrightsYN = True
    '                ADMINRIGHTS = True

    '            End If


    '        End If
    '    End If



    '    '  setuserscreen()

    'End Function

    ''#######################   TIME MODS ############################


    'Sub CB_Alter_company(ByVal CB_Column As String)


    '    Select Case CB_Column

    '        Case "Email"

    '            sql = "ALTER TABLE [My Company Information] ADD" + " EmailOutMailServer [nvarchar](50) NULL"
    '            ExecuteSQLStmt(sql)
    '            sql = "ALTER TABLE [My Company Information] ADD" + " EmailUserName [nvarchar](50) NULL"
    '            ExecuteSQLStmt(sql)
    '            sql = "ALTER TABLE [My Company Information] ADD" + " EmailPW [nvarchar](50) NULL"
    '            ExecuteSQLStmt(sql)




    '    End Select



    'End Sub


End Module
