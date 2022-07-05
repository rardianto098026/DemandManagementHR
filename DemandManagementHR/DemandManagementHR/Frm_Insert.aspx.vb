Imports System
Imports System.Text
Imports System.Collections
Imports System.DirectoryServices
Imports System.Data.SqlClient
Imports AXA.Framework.DataAccess
Imports System.Data
Imports System.Net
Imports System.Globalization.TextInfo
Imports System.Security.Principal
Imports System.Globalization

Public Class Frm_Insert
    Inherits System.Web.UI.Page
    Dim oSelect As New SelectBase
    Dim oInsert As New InsertBase
    Dim oUpdate As New UpdateBase
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            LoadEntity()
            LoadManager()
            'Dim command = Session("Command").ToString()
            'If Session("Command") = "Edit_MST" Then
            '    Session("IDX") = Request.QueryString("idx").ToString
            '    bindData()
            'End If
        End If
    End Sub

    Sub LoadEntity()
        Dim dt As New DataTable
        dt = oSelect.f_LOAD_DDL("ENTITY")

        If dt.Rows.Count > 0 Then
            'ddl_Entity.Items.Clear()
            ddl_Entity.DataSource = dt
            ddl_Entity.DataValueField = "LongEntity"
            ddl_Entity.DataTextField = "ShortEntity"
            ddl_Entity.DataBind()

            ddl_Entity.Items.Insert(0, New ListItem("--Choose--", "0"))
        End If


    End Sub
    Sub LoadManager()
        Dim dt As New DataTable
        dt = oSelect.f_LOAD_DDL("MANAGER")

        If dt.Rows.Count > 0 Then
            'ddl_Manager.Items.Clear()
            ddl_Manager.DataSource = dt
            ddl_Manager.DataValueField = "EmployeeID"
            ddl_Manager.DataTextField = "EmployeeName"
            ddl_Manager.DataBind()

            ddl_Manager.Items.Insert(0, New ListItem("--Choose--", "0"))
        End If

    End Sub

    Sub GetExpiredDate()
        Dim dtCrit2 As New DataTable
        If txtduration.Text = "" Then
            txtduration.Text = 0
        End If
        'Dim DATEHIRE As Date = CDate(Me.txtdatehire.Text).ToString("yyyy-MM-dd")
        'Dim fdt As String = CDate(txtdatehire.Text).ToString("yyyy-MM-dd")
        dtCrit2 = oSelect.f_SEL_GETEXPIREDDATE(txtdatehire.Text, txtduration.Text)
        If dtCrit2.Rows.Count > 0 Then
            'txtdateexpire.Text = dtCrit2.Rows(0)("ExpiredDate").ToString()
            txtdateexpire.Text = Format(dtCrit2.Rows(0)("ExpiredDate"), "yyyy-MM-dd")
        End If
    End Sub

    Protected Sub txtdatehire_TextChanged(sender As Object, e As EventArgs) Handles txtdatehire.TextChanged
        GetExpiredDate()
    End Sub
    Protected Sub txtduration_TextChanged(sender As Object, e As EventArgs) Handles txtdatehire.TextChanged
        GetExpiredDate()
    End Sub
    Public Sub Alert_Add()
        Dim confirmValue As String = Request.Form("confirm_value")
    End Sub
    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Try
            Dim confirmValue As String = Request.Form("confirm_value")
            If confirmValue = "Yes" Then

                Dim message2 As String
                Dim sb2 As New System.Text.StringBuilder()
                Dim Counting As String = ""
                Dim dtCrit2 As New DataTable
                dtCrit2 = oSelect.f_SEL_GET_COUNT_EMPLOYEE(txtempid.Text, txtempname.Text, txtdatehire.Text)

                If dtCrit2.Rows.Count > 0 Then
                    Counting = dtCrit2.Rows(0)("Counting").ToString()
                End If

                If Counting >= 1 Then
                    message2 = "Data already exist, please fill another data."
                    sb2.Append("<script type = 'text/javascript'>")
                    sb2.Append("window.onload=function(){")
                    sb2.Append("alert('")
                    sb2.Append(message2)
                    sb2.Append("')};")
                    sb2.Append("</script>")
                    ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb2.ToString())
                    Exit Sub
                End If

                'VALIDASI SUBMIT DATA
                If txtempid.Text = "" Then
                    message2 = "Please Fill Employee ID"
                    sb2.Append("<script type = 'text/javascript'>")
                    sb2.Append("window.onload=function(){")
                    sb2.Append("alert('")
                    sb2.Append(message2)
                    sb2.Append("')};")
                    sb2.Append("</script>")
                    ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb2.ToString())
                    txtempid.Focus()
                    Exit Sub
                End If
                If txtempname.Text = "" Then
                    message2 = "Please Fill Employee Name"
                    sb2.Append("<script type = 'text/javascript'>")
                    sb2.Append("window.onload=function(){")
                    sb2.Append("alert('")
                    sb2.Append(message2)
                    sb2.Append("')};")
                    sb2.Append("</script>")
                    ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb2.ToString())
                    txtempname.Focus()
                    Exit Sub
                End If
                If txtdepartment.Text = "" Then
                    message2 = "Please Fill Department"
                    sb2.Append("<script type = 'text/javascript'>")
                    sb2.Append("window.onload=function(){")
                    sb2.Append("alert('")
                    sb2.Append(message2)
                    sb2.Append("')};")
                    sb2.Append("</script>")
                    ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb2.ToString())
                    txtdepartment.Focus()
                    Exit Sub
                End If
                If ((ddl_Entity.SelectedValue.ToString = "0")) Then
                    message2 = "Please Choose Entity"
                    sb2.Append("<script type = 'text/javascript'>")
                    sb2.Append("window.onload=function(){")
                    sb2.Append("alert('")
                    sb2.Append(message2)
                    sb2.Append("')};")
                    sb2.Append("</script>")
                    ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb2.ToString())
                    ddl_Entity.Focus()
                    Exit Sub
                End If
                If txtarea.Text = "" Then
                    message2 = "Please Fill Area Name"
                    sb2.Append("<script type = 'text/javascript'>")
                    sb2.Append("window.onload=function(){")
                    sb2.Append("alert('")
                    sb2.Append(message2)
                    sb2.Append("')};")
                    sb2.Append("</script>")
                    ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb2.ToString())
                    txtarea.Focus()
                    Exit Sub
                End If
                If ((ddl_Manager.SelectedValue.ToString = "0")) Then
                    message2 = "Please Choose Manager Name"
                    sb2.Append("<script type = 'text/javascript'>")
                    sb2.Append("window.onload=function(){")
                    sb2.Append("alert('")
                    sb2.Append(message2)
                    sb2.Append("')};")
                    sb2.Append("</script>")
                    ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb2.ToString())
                    ddl_Manager.Focus()
                    Exit Sub
                End If
                If txtdatehire.Text = "" Then
                    message2 = "Please Choose Hire Date"
                    sb2.Append("<script type = 'text/javascript'>")
                    sb2.Append("window.onload=function(){")
                    sb2.Append("alert('")
                    sb2.Append(message2)
                    sb2.Append("')};")
                    sb2.Append("</script>")
                    ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb2.ToString())
                    txtdatehire.Focus()
                    Exit Sub
                End If

                'If txtduration.Text = "" Then
                '    message2 = "Please Fill Duration (Month)"
                '    Dim sb2 As New System.Text.StringBuilder()
                '    sb2.Append("<script type = 'text/javascript'>")
                '    sb2.Append("window.onload=function(){")
                '    sb2.Append("alert('")
                '    sb2.Append(message2)
                '    sb2.Append("')};")
                '    sb2.Append("</script>")
                '    ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb2.ToString())
                '    txtduration.Focus()
                '    Exit Sub
                'End If
                If ((ddl_Status.SelectedValue.ToString = "0")) Then
                    message2 = "Please Choose Status"
                    sb2.Append("<script type = 'text/javascript'>")
                    sb2.Append("window.onload=function(){")
                    sb2.Append("alert('")
                    sb2.Append(message2)
                    sb2.Append("')};")
                    sb2.Append("</script>")
                    ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb2.ToString())
                    ddl_Manager.Focus()
                    Exit Sub
                End If

                'Dim MyCultureInfo As CultureInfo = New CultureInfo("de-DE")
                'Dim Datehire As DateTime = DateTime.Parse(txtdatehire.Text, MyCultureInfo,
                '                           DateTimeStyles.NoCurrentDateDefault)
                'Dim Dateexpire As DateTime = DateTime.Parse(txtdateexpire.Text, MyCultureInfo,
                '                           DateTimeStyles.NoCurrentDateDefault)


                oInsert.f_INS_UPD_MST_EMPLOYEE(txtempid.Text, txtempname.Text, txtdepartment.Text, ddl_Entity.SelectedValue, txtarea.Text,
                                                   ddl_Manager.SelectedValue, txtdatehire.Text, txtdateexpire.Text, txtduration.Text, ddl_Status.SelectedValue, 1, Session("USERID").ToString,
                                                   "", "", "ADD")

                ScriptManager.RegisterStartupScript(Me, Me.GetType(),
            "alert",
            "alert('Submit Data Success');window.location ='ListEdit_Employee.aspx';",
            True)
                Exit Sub
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        'If Session("Command") = "Edit_MST" Then
        '    ScriptManager.RegisterStartupScript(Page, Me.GetType(), "close", "window.close();", True)
        '    Session("Command") = ""
        'Else
        Response.Redirect("Home.aspx")
        'End If
    End Sub

    Private Sub Frm_Insert_Unload(sender As Object, e As EventArgs) Handles Me.Unload
        Session("Command") = ""
    End Sub
End Class