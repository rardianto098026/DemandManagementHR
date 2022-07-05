Imports AXA.Framework.DataAccess
Imports System.Data.OleDb
Imports System.Data
Imports System.IO
Imports System.Configuration
Imports System.Globalization
Imports System.Data.SqlClient

Partial Public Class UploadData
    Inherits System.Web.UI.Page
    Dim oInsert As New InsertBase
    Dim oUpdate As New UpdateBase
    Dim oSelect As New SelectBase
    Dim oDelete As New DeleteBase
    Dim uploadid As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("~/Home.aspx")
    End Sub
    Protected Sub Alert(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click

    End Sub
    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click

        Dim confirmValue As String = Request.Form("confirm_value")
        If confirmValue = "Yes" Then

            If txtUpload.PostedFile.FileName = "" Then
                lblErr_Upload.Visible = True
                lblErr_Upload.Text = "* Please choose the file you want to upload"

                Exit Sub
            End If

            Dim _total As String = UploadExcel()
            Dim dtCriteria = oSelect.f_CheckCriteria_Upload(uploadid)

            Dim _sukses As String = dtCriteria.Rows(0)("SUKSES").ToString
            Dim _totalpload As String = dtCriteria.Rows(0)("TOTAL_UPLOAD").ToString

            Dim totalCount As String = Nothing
            Dim _failed As Integer = Nothing

            _failed = dtCriteria.Rows(0)("FAILED").ToString

            Dim message As String

            message = "* Total " & _totalpload & " record(s). " + "\n" + "" _
                            & _sukses & " record(s) Sukses. " + "\n" + "" & _failed & " record(s) Failed. " + "\n"

            Dim message_failed As String

            message_failed = "* Total " & _totalpload & " record(s). " + "\n" + "" _
                            & _sukses & " record(s) Sukses. " + "\n" + "" & _failed & " record(s) Failed. " + "\n" _
                            & "Please Re-Upload File" + "\n" + " " + "\n" + " "
            If CInt(_totalpload) <> 0 And CInt(_failed) = 0 Then
                Dim sb As New System.Text.StringBuilder()

                sb.Append("<script type = 'text/javascript'>")

                sb.Append("window.onload=function(){")

                sb.Append("alert('")

                sb.Append(message)

                sb.Append("')};")

                sb.Append("</script>")


                ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
            Else
                Dim sbs As New System.Text.StringBuilder()

                sbs.Append("<script type='text/javascript'>")

                sbs.Append("if(confirm('" + message_failed + "Do You Want to Download Failed Upload?')){window.location='Download_Failed_Upload.aspx';}")
                sbs.Append("</script>")

                ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sbs.ToString())
            End If
        End If
    End Sub
    Private Function UploadExcel() As String
        Dim rows As Integer
        UploadData()
        Return rows
    End Function
    Public Function UploadData() As String
        Dim row, rows, rowbsm, rowMCM As Integer
        'Try
        Dim da As New OleDbDataAdapter
        Dim dtImport, dtCheckBSM, dtCheckMCM As New DataTable
        Dim strFileName As String = txtUpload.PostedFile.FileName
        Dim filename As String = Path.GetFileName(strFileName)
        Dim new_path As String = Server.MapPath("Upload\") + filename
        Dim msgError As String
        'Dim row, rows, rowbsm, rowMCM As Integer
        row = 1
        rows = 0
        rowbsm = 0
        rowMCM = 0
        txtUpload.PostedFile.SaveAs(new_path)

        Dim strConn As String
        strConn = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + new_path + ";Extended Properties=""Excel 12.0;HDR=YES;IMEX=1;"""

        Dim conn As New OleDb.OleDbConnection(strConn)
        da = New OleDb.OleDbDataAdapter("Select * from [Sheet1$A1:N1000000]", conn)
        dtImport = New DataTable("ExcelFile")
        Try
            'On Error Resume Next
            da.Fill(dtImport)

            lblErr_Upload.Visible = True
            lblErr_Upload.Text = "* Now Uploading..."

            If dtImport.Rows.Count > 0 Then
                uploadid = Convert.ToInt32(oSelect.f_InsertUploadFile(filename, Session("UserName").ToString, Session("Entity")).Rows(0)(0).ToString)

                For Each dr As DataRow In dtImport.Rows
                    'If dr("Policy effective dat").ToString <> "" Then
                    'oInsert.f_INSERT_MST_EMPLOYEE_FAILED(dr("HIRE DATE").ToString, dr("CONTRACT EXPIRE DATE").ToString, dr("DURATION (MONTH)").ToString, dr("STATUS").ToString, dr("EMPLOYEE ID").ToString, _
                    '                                     dr("EMPLOYEE NAME").ToString, dr("TITLE").ToString, dr("DEPARTMENT").ToString, dr("ENTITY").ToString, dr("EMAIL MANAGER").ToString, _
                    '                                     dr("EMAIL HR SERVICES").ToString, dr("EMAIL HRBP").ToString, dr("EMAIL PIC").ToString, uploadid, "FORMAT DATE", _
                    '                                     Session("UserID").ToString)

                    ' On Error Resume Next
                    Dim sDateTime As Date
                    Dim sDateTime2 As Date

                    If dr("HIRE DATE").ToString = "" Then
                        dr("HIRE DATE") = "1900/01/01"
                    End If

                    Dim sDate As String() = dr("HIRE DATE").ToString.Split("/")
                    sDateTime = sDate(0) + "/" + sDate(1) + "/" + sDate(2)
                    sDateTime2 = sDate(0) + "-" + sDate(1) + "-" + sDate(2)

                    ' On Error Resume Next
                    Dim sDateTime3 As String
                    Dim sDateTime4 As String

                    If dr("CONTRACT EXPIRE DATE").ToString = "" Then
                        dr("CONTRACT EXPIRE DATE") = "1900/01/01"
                    End If

                    Dim sDate2 As String() = dr("CONTRACT EXPIRE DATE").ToString.Split("/")
                    sDateTime3 = sDate2(0) + "/" + sDate2(1) + "/" + sDate2(2)
                    sDateTime4 = sDate2(0) + "-" + sDate2(1) + "-" + sDate2(2)


                    'If Err.Number = 0 Then
                    ' EDIT MM/DD/YYYY

                    'If sDate(1) <= 12 And sDate2(1) <= 12 Then
                    oInsert.f_INSERT_MST_EMPLOYEE(dr("HIRE DATE").ToString, dr("CONTRACT EXPIRE DATE").ToString, dr("DURATION (MONTH)").ToString, dr("STATUS").ToString, dr("EMPLOYEE ID").ToString, _
                                                 dr("EMPLOYEE NAME").ToString, dr("AREA NAME").ToString, dr("DEPARTMENT").ToString, dr("ENTITY").ToString, dr("MANAGER").ToString, _
                                                 dr("HR").ToString, uploadid, _
                                                 Session("UserID").ToString)


                    rows = rows + 1
                    rows = rows + 1
                    'Else
                    'oInsert.f_INSERT_MST_EMPLOYEE_FAILED(dr("HIRE DATE").ToString, dr("CONTRACT EXPIRE DATE").ToString, dr("DURATION (MONTH)").ToString, dr("STATUS").ToString, dr("EMPLOYEE ID").ToString, _
                    '                             dr("EMPLOYEE NAME").ToString, dr("TITLE").ToString, dr("DEPARTMENT").ToString, dr("ENTITY").ToString, dr("EMAIL MANAGER").ToString, _
                    '                             dr("EMAIL HR SERVICES").ToString, dr("EMAIL HRBP").ToString, dr("EMAIL PIC").ToString, uploadid, "FORMAT DATE", _
                    '                             Session("UserID").ToString)
                    'End If
                    'End If

                Next

            End If

            lblErr_Upload.Text = "Upload Success"
        Catch ex As Exception
        End Try

        'Catch ex As Exception
        'lblErr_Upload.Text = "Upload Error Because " & ex.ToString
        'End Try
        Return rows
    End Function
End Class