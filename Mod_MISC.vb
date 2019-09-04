Imports System.Text.RegularExpressions
Imports System.Data.SqlClient
Imports System.IO.Ports
Imports System.IO
Imports System

Imports System.Data
Imports System.Net.Mail
Imports Microsoft.Reporting.WinForms
Imports System.Configuration
Imports System.Text
Imports System.Security.Cryptography



Module Mod_MISC
    Public ProductID As String
    Public ADMINRIGHTS As Boolean
    Public MaximumDiscountAllowed As Double
    Public EmployeeKey As String

    Public Sel_CustomerID As Integer
    Public Sel_WorkOrderID As Integer
    Public Sel_WorkOrderNum As String
    Public Sel_ProjectID As Integer
    Public Sel_EmployeeID As Integer
    Public Sel_CustomerName As String
    Public Sel_ProductionMailDropID As Integer
    Public CBConnectionString As String
    Public CBADMINConnString As String = My.Settings.ooprod_otherConnectionString.ToString
    Public destFilePath As String
    Public alternatDestPath As Boolean
    Public webconfirmed As Boolean

    Public ADMINTOGGLE As Boolean ' identifies if this is an admin user going local for faster services

    Public HIDDENMENU As Boolean

    Public Req_BranchNumber As Integer

    'Public Sub subExportDGVToCSV(ByVal strExportFileName As String, _
    'ByVal DataGridView As DataGridView, _
    'Optional ByVal blnWriteColumnHeaderNames As Boolean = False, _
    'Optional ByVal strDelimiterType As String = ",")

    '    '* Parameters Description:
    '    '* --------------------------------------------------------------
    '    '* strExportFileName = The name of the file to export to.

    '    '* DataGridView = The name of the DataGridView on your form.

    '    '* blnWriteColumnHeaderNames = YES/NO for writing the column
    '    '*  names as the first line of the CSV file.  This will cause
    '    '*  programs like Excel to argue but still open the file.

    '    '* strDelimiterType = The type of delimiter you want to use.
    '    '*  Examples:  TAB (vbTab) or Comma (",")
    '    '* --------------------------------------------------------------

    '    '* Create a StreamWriter object to open and write contents
    '    '* of the DataGridView columns and rows.
    '    Dim sr As StreamWriter = File.CreateText(strExportFileName)

    '    '* Create a variable to hold the delimiter type
    '    '* (i.e., TAB or comma or whatever you choose)
    '    '* The default for this procedure is a comma (",").
    '    Dim strDelimiter As String = strDelimiterType

    '    '* Create a variable that holds the total number of columns
    '    '* in the DataGridView.
    '    Dim intColumnCount As Integer = DataGridView.Columns.Count - 1

    '    '* Create a variable to hold the row data
    '    Dim strRowData As String = ""

    '    '* If the CSV file will have column names then write that data
    '    '* as the first line of the file.
    '    If blnWriteColumnHeaderNames Then

    '        '* Interate through each column and get/write the column name.
    '        For intX As Integer = 0 To intColumnCount

    '            '* The IIf statement will not put a delimiter after the
    '            '* last value added.

    '            '* The Replace function will remove the delimiter
    '            '* from the field data if found.
    '            strRowData += Replace(DataGridView.Columns(intX).Name, strDelimiter, "") & _
    '            IIf(intX < intColumnCount, strDelimiter, "")

    '        Next intX

    '        '* Write the column header data to the CSV file.
    '        sr.WriteLine(strRowData)

    '    End If '* If blnWriteColumnHeaderNames

    '    '* Now collect data for each row and write to the CSV file.
    '    '* Loop through each row in the DataGridView.
    '    For intX As Integer = 0 To DataGridView.Rows.Count - 1

    '        '* Reset the value of the strRowData variable
    '        strRowData = ""

    '        For intRowData As Integer = 0 To intColumnCount

    '            '* The IIf statement will not put a delimiter after the
    '            '* last value added.

    '            '* The Replace function will remove the delimiter
    '            '* from the field data if found.
    '            strRowData += Replace(DataGridView.Rows(intX).Cells(intRowData).Value, strDelimiter, "") & _
    '                IIf(intRowData < intColumnCount, strDelimiter, "")

    '        Next intRowData

    '        '* Write the row data to the CSV file.
    '        sr.WriteLine(strRowData)

    '    Next intX

    '    '* Close the StreamWriter object.
    '    sr.Close()

    '    '* You are done!
    '    MsgBox("Done!")

    'End Sub
    Public Sub subExportDATATABLEToCSV(ByVal strExportFileName As String, _
ByVal dt As DataTable, _
Optional ByVal blnWriteColumnHeaderNames As Boolean = False, _
Optional ByVal strDelimiterType As String = ",")
        Dim sw As New StreamWriter(strExportFileName, False)
        'Open new file
        Try
            Dim colCount As Integer = dt.Columns.Count
            'Total number of Columns

            Dim c As Integer = 0
            While c < colCount
                'Write different column names with ','
                sw.Write(dt.Columns(c))
                If c < colCount - 1 Then
                    sw.Write(",")
                End If
                System.Math.Max(System.Threading.Interlocked.Increment(c), c - 1)
            End While
            sw.Write(sw.NewLine)


            For Each dr As DataRow In dt.Rows
                Dim r As Integer = 0
                While r < colCount
                    If Not Convert.IsDBNull(dr(r)) Then
                        If dr(r).[GetType]().ToString() = "System.String" Then
                            'Will check column is string or not
                            sw.Write(dr(r).ToString())
                        Else
                            sw.Write(dr(r).ToString())
                        End If
                    End If
                    If r < colCount - 1 Then
                        sw.Write(",")

                    End If
                    System.Math.Max(System.Threading.Interlocked.Increment(r), r - 1)
                End While
                sw.WriteLine()
            Next
            'sw.WriteLine(sw.NewLine)
            'sw.Write("File Compiled at " + System.DateTime.Now)
        Finally
            sw.Close()
        End Try



    End Sub

    Public Sub SendDataTabletoCSV()

    End Sub
    Sub disablecontrols(ByVal sender As Object, ByVal onoff As Boolean)

        For Each ctrl As Control In sender.Controls
            If (ctrl.GetType() Is GetType(TextBox)) Then
                Dim thistb As TextBox = ctrl
                thistb.ReadOnly = Not onoff
                thistb.BackColor = Color.White
            Else
                ctrl.Enabled = onoff
            End If

            '    If (ctrl.GetType() Is GetType(ComboBox)) Then
            'Dim cbobx As ComboBox = CType(ctrl, ComboBox)
            'cbobx.Enabled = onoff
            'End If
        Next
    End Sub


    'Public Function decode(ByVal ThisValue As String) As String
    '    decode = ""
    '    Dim wrapper As New Simple3Des("waterkid")

    '    ' DecryptData throws if the wrong password is used.
    '    Try
    '        Dim plainText As String = wrapper.DecryptData(ThisValue)
    '        decode = plainText
    '    Catch ex As System.Security.Cryptography.CryptographicException
    '        '  MsgBox("The data could not be decrypted with the password.")
    '    End Try
    'End Function
    'Public Function ENcod(ByVal ThisCrypt As String) As String
    '    ENcod = ""
    'Dim wrapper As New Simple3Des("waterkid")
    '    ENcod = wrapper.EncryptData(ThisCrypt)

    'End Function
    Function CheckNumbersOnly2(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) As Boolean
        'check for multiple dots

        Dim charactersAllowed As String = ".1234567890" & Chr(127)
        CheckNumbersOnly2 = False
        'e.KeyChar <> Microsoft.VisualBasic.ChrW(Keys.Delete) And
        If e.KeyChar <> Convert.ToChar(8) Then
            Dim cc As Long = 0
            Try
                cc = Countchars(CType(sender, MaskedTextBox).Text, ".")
            Catch ex As Exception

            End Try

            Try
                cc = Countchars(CType(sender, TextBox).Text, ".")
            Catch ex As Exception

            End Try
            Try
                cc = Countchars(CType(sender, ToolStripTextBox).Text, ".")
            Catch ex As Exception

            End Try



            If InStr(charactersAllowed, e.KeyChar) > 0 Then
                CheckNumbersOnly2 = True
            End If
            If cc >= 1 And e.KeyChar = "." Then CheckNumbersOnly2 = False
            'If checktext.IndexOfAny(charactersAllowed.ToCharArray) > 1 Then
            '    CheckNumbersOnly = True
            'End If

        Else

            CheckNumbersOnly2 = True

        End If



    End Function
    Function Countchars(ByVal sText As String, ByVal comparechar As String) As Long
        'Dim bArr() As Byte
        'Dim i As Long
        Dim count As Long
        'bArr() = sText
        'For i = 0 To UBound(bArr) Step 2
        '    ' if this char is a space, increase the counter
        '    If bArr(i) = 32 Then count = count + 1
        'Next
        'CountSpaces = count

        For i = 1 To Len(sText)
            If Mid$(sText, i, 1) = comparechar Then count = count + 1

        Next
        Countchars = count
    End Function


    Function CheckNumbersOnly(ByVal checktext As String) As Boolean
        Dim charactersAllowed As String = ".1234567890" & Chr(127)
        CheckNumbersOnly = False



        If InStr(charactersAllowed, checktext) > 0 Then
            CheckNumbersOnly = True
        End If
        'If checktext.IndexOfAny(charactersAllowed.ToCharArray) > 1 Then
        '    CheckNumbersOnly = True
        'End If
    End Function

    Function GetLastDayInMonth(ByVal dDate As Date) As Date
        dDate = DateAdd(DateInterval.Month, 1, dDate)
        dDate = Convert.ToDateTime(Month(dDate).ToString() & "/" & "1/" & Year(dDate).ToString())
        dDate = DateAdd(DateInterval.Day, -1, dDate)
        Return dDate
    End Function

    Public Function roundtimeto15(thisdate As Date) As Date
        roundtimeto15 = thisdate
        Select Case thisdate.Minute

            Case 1 To 14
                roundtimeto15 = DateAdd(DateInterval.Minute, (15 - thisdate.Minute), thisdate)
            Case 16 To 29
                roundtimeto15 = DateAdd(DateInterval.Minute, (30 - thisdate.Minute), thisdate)
            Case 31 To 44
                roundtimeto15 = DateAdd(DateInterval.Minute, (45 - thisdate.Minute), thisdate)
            Case 46 To 59
                roundtimeto15 = DateAdd(DateInterval.Minute, (60 - thisdate.Minute), thisdate)



        End Select
    End Function
    Public Function roundminutesto15(OrigMinutes As Integer) As Double
        'BAD WAY TO DO IT BUT IN A HURRY
        Dim x As Integer = 0
        Dim period As Integer = 1

        roundminutesto15 = OrigMinutes
        Try


            Do While period <> 0


                Dim test As Double = (OrigMinutes + x) / 15
                Dim teststr As String = CType(test, String)

                period = InStr(teststr, ".")
                roundminutesto15 = OrigMinutes + x 'Mid(CType(test, String), period, 2)

                ' If period = 0 Then Exit Function
                x = x + 1
            Loop



            'Dim teststr As String = Mid(CType(test, String), period, 2)



            'Dim Extratime As Double = 15 - ((CType(teststr, Double)) * 15)


            'roundminutesto15 = roundminutesto15 + Extratime




        Catch ex As Exception

        End Try
    End Function


    Function parseTags(ByVal TagString As String, ByVal ParamValue As String) As String
        parseTags = ""
        If Len(TagString) < 1 Then parseTags = "" : Exit Function
        Dim startCnt As Integer = 0
        Dim lastCnt As Integer = 0
        'put the ? or & in here in case we use a html page to view later also helps separate the values, matches the value behind it with the ParamValue and returns
        'the string after it
        startCnt = InStr(TagString, ParamValue, CompareMethod.Text) 'finds startpoint
        If startCnt > 0 Then
            startCnt = startCnt + Len(ParamValue) + 1
            If Len(TagString) >= startCnt Then 'tries to catch missing info in string and abort
                If InStr(Right(TagString, Len(TagString) - startCnt), "&", CompareMethod.Text) = 0 Then
                    lastCnt = Len(TagString)
                Else
                    lastCnt = InStr(Right(TagString, Len(TagString) - startCnt), "&", CompareMethod.Text)
                End If

                parseTags = Mid(TagString, startCnt, lastCnt)
            End If
        Else
            parseTags = ""
        End If


    End Function
    Public Function IsDBNull(ByVal dbvalue As Object) As Boolean
        Return dbvalue Is DBNull.Value
    End Function

    Public Function MDB(ByVal o As Object) As Boolean
        If IsDBNull(o) Then
            Return False
        Else
            Return CType(o, Boolean)
        End If
    End Function
    ' Return 0 if object is null, else decimal value
    Public Function MND(ByVal o As Object) As Decimal
        If IsDBNull(o) Then
            Return 0
        Else
            Dim tempstr As String = o
            If tempstr = "" Then o = 0
            Try
                Return CType(o, Double)
            Catch ex As Exception

            End Try

        End If
    End Function

    ' Return 0 if null, else integer value of object.
    Public Function MNI(ByVal i As Object) As Integer
        If IsDBNull(i) Then
            Return 0
        Else
            If CType(i, String) = "" Then i = 0

            Return CType(i, Integer)
        End If
    End Function

    ''' Return String if object is not null, else return empty.string
    Public Function MNS(ByVal s As Object) As String
        If IsDBNull(s) Then
            Return String.Empty
        Else
            Return CType(s, String)
        End If
    End Function
    Public Function MNDT(ByVal dt As Object) As Date
        If IsDBNull(dt) Then
            Return Now().ToShortDateString
        Else
            Return CType(dt, Date)
        End If
    End Function
    Public Function MNDT_Old(ByVal dt As Object) As Date
        If IsDBNull(dt) Then
            Return CType(#1/1/1900#, Date)
        Else
            Return CType(dt, Date)
        End If
    End Function
    Public Function mndts(ByVal dt As Date) As String
        If IsDBNull(dt) Then
            Return Now().ToShortDateString
        Else
            Return dt.ToShortDateString
        End If
    End Function



    Public Function TBD(ByVal tx As String) As Double
        If tx = "" Then
            tx = "0"
        End If

        TBD = CType(tx, Double)


    End Function


    Function rm_multiple_characters(ByVal strIn As String, ByVal ridtext As String) As String
        strIn = Replace(strIn, Chr(160), ridtext)
        Return IIf(strIn.Trim(ridtext).Length = 0, strIn, Regex.Replace(strIn, " {2,}", ridtext))
    End Function
    Function rm_multiple_spaces(ByVal strIn As String) As String
        rm_multiple_spaces = ""
        If strIn = Nothing Then Exit Function
        strIn = Replace(strIn, Chr(160), " ")
        Return IIf(strIn.Trim(" ").Length = 0, strIn, Regex.Replace(strIn, " {2,}", " "))
    End Function

    Function makeSavedINI(ByVal SaveOrderID As String) As Boolean
        makeSavedINI = False
        'Locate the traction.ini file if not there then create it
        Dim errflag As Boolean = False
        Dim inipath As String = "C:\Traction_Design.ini"
        If FileIO.FileSystem.FileExists(inipath) Then 'its here so delete it first
            FileIO.FileSystem.DeleteFile(inipath)
        End If

        Dim objReader As New StreamWriter(inipath)
        Try
            objReader.WriteLine(SaveOrderID)
            objReader.Close()
        Catch Ex As Exception
            'if there was an error then try and close and then delete the file then just create a new one
            errflag = True
            objReader.Close()
            FileIO.FileSystem.DeleteFile(inipath)
        End Try
        If errflag Then

        Else

        End If

    End Function


    Function RenderPDF(ByVal thisReportViewer As ReportViewer, ByVal thisfilename As String) As String
        RenderPDF = ""
        'MsgBox("Emailing Report:WORK IN PROGRESS")

        Dim localAppData As String = ""
        Dim UserFilePath As String = ""

        Try
            localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
            UserFilePath = Path.Combine(localAppData, ProductFolder)


        Catch ex As Exception

        End Try
        thisfilename = thisfilename + ".PDF"
        Dim fullfile As String = Path.Combine(UserFilePath, thisfilename)

        If File.Exists(fullfile) Then File.Delete(fullfile)

        Dim warnings As Warning() = Nothing
        Dim streamids As String() = Nothing
        Dim mimeType As String = Nothing
        Dim encoding As String = Nothing
        Dim extension As String = Nothing
        Dim bytes As Byte()
        RenderPDF = fullfile
        Try
            bytes = thisReportViewer.LocalReport.Render("PDF", Nothing, mimeType, encoding, extension, streamids, warnings)

            Dim fs As New FileStream(fullfile, FileMode.Create)
            fs.Write(bytes, 0, bytes.Length)
            fs.Close()
        Catch ex As Exception
            RenderPDF = ""
        End Try

       



    End Function
    Function emailattachment(ByVal emailname As String, ByVal subjectline As String, ByVal msgbody As String, ByVal attachname As String, ByVal eFrom As String, ByVal ecc As String, ByVal BCC As Boolean, servername As String, emailuser As String, emailpw As String, emailport As String) As String
        ' ''email
        emailattachment = ""

        Try
            Dim SendFrom As MailAddress = New MailAddress(eFrom)
            Dim SendTo As MailAddress = New MailAddress(emailname)
            Dim MyMessage As MailMessage = New MailMessage(SendFrom, SendTo)
            MyMessage.Subject = subjectline
            MyMessage.Body = msgbody

            If ecc <> "" Then
                Dim thisecc As New MailAddress(ecc)
                MyMessage.CC.Add(thisecc)

            End If
            If BCC Then MyMessage.Bcc.Add(eFrom)


            If attachname <> "" Then
                Dim attachFile As New Attachment(attachname)
                MyMessage.Attachments.Add(attachFile)
            End If




            Dim emailClient As New SmtpClient()
            emailClient.Host = servername
            emailClient.Port = emailport
            emailClient.UseDefaultCredentials = False
            emailClient.EnableSsl = True

            emailClient.DeliveryMethod = SmtpDeliveryMethod.Network

            emailClient.Credentials = New System.Net.NetworkCredential(emailuser, emailpw)
            emailClient.Send(MyMessage)
            '   MDIParent1.ToolStripStatusLabel.Text = "Message Sent"

        Catch ex As Exception
            emailattachment = "Problem sending email, check settings and internet connection."

        End Try


    End Function

    Public Function MD5(ByVal str As String) As String

        Dim provider As MD5CryptoServiceProvider
        Dim bytValue() As Byte
        Dim bytHash() As Byte
        Dim strOutput As String = ""
        Dim i As Integer

        provider = New MD5CryptoServiceProvider()

        bytValue = System.Text.Encoding.UTF8.GetBytes(str)

        bytHash = provider.ComputeHash(bytValue)

        provider.Clear()

        For i = 0 To bytHash.Length - 1

            strOutput &= bytHash(i).ToString("x").PadLeft(2, "0")

        Next

        Return strOutput

    End Function

End Module
