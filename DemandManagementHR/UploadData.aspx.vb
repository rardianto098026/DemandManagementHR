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

        Try

            Dim confirmValue As String = Request.Form("confirm_value")
            If confirmValue = "Yes" Or confirmValue = "OK" Then

                If txtUpload.PostedFile.FileName = "" Then
                    lblErr_Upload.Visible = True
                    lblErr_Upload.Text = "* Please choose the file you want to upload"

                    Exit Sub
                End If
                Dim _total As String = UploadExcel()

                If Session("CRUD") = "Failed" Then
                    Session("CRUD") = ""
                    Dim sb As New System.Text.StringBuilder()
                    Dim message2 As String = "Something error on Upload File"
                    sb.Append("<script type = 'text/javascript'>")
                    sb.Append("window.onload=function(){")
                    sb.Append("alert('")
                    sb.Append(message2)
                    sb.Append("')};")
                    sb.Append("</script>")
                    ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
                    lblErr_Upload.Text = "Upload Failed"
                    Exit Sub
                End If

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

        Catch ex As Exception
            lblErr_Upload.Text = Convert.ToString(ex)
        End Try
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
        Row = 1
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

                    Dim sDateTime As Date
                    Dim sDateTime2 As Date

                    If dr("HIRED DATE").ToString = "" Then
                        dr("HIRED DATE") = "1900/01/01"
                    End If

                    If dr("EXPIRED DATE").ToString = "" Then
                        dr("EXPIRED DATE") = "1900/01/01"
                    End If

                    Dim sDate As String() = dr("HIRED DATE").ToString.Split("/")
                    sDateTime = sDate(0) + "/" + sDate(1) + "/" + sDate(2)
                    sDateTime2 = sDate(0) + "-" + sDate(1) + "-" + sDate(2)

                    Try
                        Dim month As Int32
                        month = dr("DURATION (MONTH)").ToString
                    Catch ex As Exception
                        dr("DURATION (MONTH)") = 99999
                    End Try


                    oInsert.f_INS_UPD_MST_EMPLOYEE(dr("EMPLOYEE ID").ToString, dr("EMPLOYEE NAME").ToString, dr("ENTITY").ToString, dr("DEPARTMENT").ToString,
                                                    dr("AREA NAME").ToString, dr("MANAGER EMAIL").ToString, dr("HIRED DATE").ToString, dr("EXPIRED DATE").ToString,
                                                    dr("DURATION (MONTH)").ToString, dr("STATUS").ToString, 1, Session("UserID").ToString, Session("EMPLNUMBER"), Session("Entity").ToString(), uploadid, "UPLOAD", dr("Worker Type").ToString, dr("NATIONALITY").ToString)

                    Session("CRUD") = "Success"

                    rows = rows + 1
                    rows = rows + 1

                Next

            End If

            lblErr_Upload.Text = "Upload Success"
        Catch ex As Exception
            Session("CRUD") = "Failed"
        End Try

        Return rows
    End Function

    Private Sub btn_submit_dep_Click(sender As Object, e As EventArgs) Handles btn_submit_dep.Click
        Try

            Dim confirmValue As String = Request.Form("confirm_value")
            If confirmValue = "Yes" Or confirmValue = "OK" Then

                If upload_depart.PostedFile.FileName = "" Then
                    Label1.Visible = True
                    Label1.Text = "* Please choose the file you want to upload"

                    Exit Sub
                End If
                'Dim _total As String = UploadDepart()
                UploadDataDepart()

                If Session("CRUD") = "Failed" Then
                    Session("CRUD") = ""
                    Dim sb As New System.Text.StringBuilder()
                    Dim message2 As String = "Something error on Upload File"
                    sb.Append("<script type = 'text/javascript'>")
                    sb.Append("window.onload=function(){")
                    sb.Append("alert('")
                    sb.Append(message2)
                    sb.Append("')};")
                    sb.Append("</script>")
                    ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
                    Label1.Text = "Upload Failed"
                    Exit Sub
                Else
                    Session("CRUD") = ""
                    Dim sb As New System.Text.StringBuilder()
                    Dim message2 As String = "Upload Success"
                    sb.Append("<script type = 'text/javascript'>")
                    sb.Append("window.onload=function(){")
                    sb.Append("alert('")
                    sb.Append(message2)
                    sb.Append("')};")
                    sb.Append("</script>")
                    ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
                    Label1.Text = "Upload Success"
                    Exit Sub
                End If
            End If

        Catch ex As Exception
            Label1.Text = Convert.ToString(ex)
        End Try
    End Sub

    Private Function UploadDepart() As String
        Dim rows As Integer
        UploadDataDepart()
        Return rows
    End Function
    Public Function UploadDataDepart() As String
        Dim row, rows, rowbsm, rowMCM As Integer

        Dim da As New OleDbDataAdapter
        Dim dtImport, dtCheckBSM, dtCheckMCM As New DataTable
        Dim strFileName As String = upload_depart.PostedFile.FileName
        Dim filename As String = Path.GetFileName(strFileName)
        Dim new_path As String = Server.MapPath("Upload\") + filename
        Dim msgError As String

        row = 1
        rows = 0
        rowbsm = 0
        rowMCM = 0
        upload_depart.PostedFile.SaveAs(new_path)


        Dim strConn As String
        strConn = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + new_path + ";Extended Properties=""Excel 12.0;HDR=YES;IMEX=1;"""
        Dim conn As New OleDb.OleDbConnection(strConn)
        da = New OleDb.OleDbDataAdapter("Select * from [Sheet1$A1:A1000000]", conn)
        dtImport = New DataTable("ExcelFile")
        Try
            'On Error Resume Next
            da.Fill(dtImport)

            Label1.Visible = True
            Label1.Text = "* Now Uploading..."

            If dtImport.Rows.Count > 0 Then
                uploadid = Convert.ToInt32(oSelect.f_InsertUploadFile(filename, Session("UserName").ToString, Session("Entity")).Rows(0)(0).ToString)

                For Each dr As DataRow In dtImport.Rows

                    oInsert.f_DEPART(dr("Department").ToString())

                    Session("CRUD") = "Success"

                    rows = rows + 1
                    rows = rows + 1

                Next

            End If

            Label1.Text = "Upload Success"
        Catch ex As Exception
            Session("CRUD") = "Failed"
        End Try

        Return rows
    End Function
End Class