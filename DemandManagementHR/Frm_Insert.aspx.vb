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
            chkexpire.Checked = False
            Session("CHECKED") = "FALSE"
            txtdateexpire.ReadOnly = True
            LoadEntity()
            LoadDepartment()
            LoadArea()
            LoadManager()
        End If
    End Sub

    Sub LoadEntity()
        Dim dt As New DataTable
        dt = oSelect.f_LOAD_DDL("ENTITY")

        If dt.Rows.Count > 0 Then
            'ddl_Entity.Items.Clear()
            ddl_Entity.DataSource = dt
            ddl_Entity.DataValueField = "LongEntity"
            ddl_Entity.DataTextField = "LongEntity"
            ddl_Entity.DataBind()

            ddl_Entity.Items.Insert(0, New ListItem("--Choose--", "0"))
        End If
    End Sub

    Sub LoadDepartment()
        Dim dtCrit2 As New DataTable
        dtCrit2 = oSelect.f_SEL_GET_DEPARTMENT()
        If dtCrit2.Rows.Count > 0 Then

            ddl_Department.DataSource = dtCrit2
            ddl_Department.DataValueField = "Department"
            ddl_Department.DataTextField = "Department"
            ddl_Department.DataBind()

            ddl_Department.Items.Insert(0, New ListItem("--Choose--", "0"))

        End If

    End Sub


    Sub LoadArea()
        Dim dtCrit2 As New DataTable
        dtCrit2 = oSelect.f_SEL_GET_AREA_NAME()
        If dtCrit2.Rows.Count > 0 Then

            ddl_Area.DataSource = dtCrit2
            ddl_Area.DataValueField = "AreaName"
            ddl_Area.DataTextField = "AreaName"
            ddl_Area.DataBind()

            ddl_Area.Items.Insert(0, New ListItem("--Choose--", "0"))

        End If

    End Sub
    Sub LoadManager()
        Dim dt As New DataTable
        dt = oSelect.f_LOAD_DDL("MANAGER")

        If dt.Rows.Count > 0 Then
            'ddl_Manager.Items.Clear()
            ddl_Manager.DataSource = dt
            ddl_Manager.DataValueField = "Email_Manager"
            ddl_Manager.DataTextField = "EmployeeName_Manager"
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
        Session("expireddate") = "off"
    End Sub

    Sub GetDepartment()
        Dim dtCrit2 As New DataTable
        dtCrit2 = oSelect.f_SEL_GET_ONCHANGE_DEPARTMENT(ddl_Entity.SelectedItem.Text)
        If dtCrit2.Rows.Count > 0 Then
            ddl_Department.DataSource = dtCrit2
            ddl_Department.DataValueField = "Department"
            ddl_Department.DataTextField = "Department"
            ddl_Department.DataBind()

            ddl_Department.Items.Insert(0, New ListItem("--Choose--", "0"))
            'ddl_Department.SelectedItem.Text = dtCrit2.Rows(0)("Department").ToString()
        End If
    End Sub

    Protected Sub txtdatehire_TextChanged(sender As Object, e As EventArgs) Handles txtdatehire.TextChanged
        GetExpiredDate()
    End Sub
    Protected Sub txtduration_TextChanged(sender As Object, e As EventArgs) Handles txtdatehire.TextChanged
        GetExpiredDate()
    End Sub
    Protected Sub ddl_Entity_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_Entity.SelectedIndexChanged
        GetDepartment()
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
                dtCrit2 = oSelect.f_SEL_GET_COUNT_EMPLOYEE(txtempid.Text)

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
                If ((ddl_Department.SelectedValue.ToString = "0")) Then
                    message2 = "Please Choose Department"
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

                If ((ddl_Area.SelectedValue.ToString = "0")) Then
                    message2 = "Please Choose Area Name"
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

                oInsert.f_INS_UPD_MST_EMPLOYEE(txtempid.Text, txtempname.Text, ddl_Entity.SelectedValue, ddl_Department.SelectedValue, ddl_Area.SelectedValue,
                                                   ddl_Manager.SelectedValue, txtdatehire.Text, txtdateexpire.Text, txtduration.Text,
                                                   ddl_Status.SelectedValue, 1, Session("USERID").ToString, "", "", 0, "ADD", ddl_Worker.SelectedItem.Text, ddl_nationality.SelectedItem.Text)

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

    Private Sub chkexpire_CheckedChanged(sender As Object, e As EventArgs) Handles chkexpire.CheckedChanged
        If chkexpire.Checked = True Then
            txtdateexpire.ReadOnly = False
            txtduration.ReadOnly = True
            Session("CHECKED") = "TRUE"
        Else
            txtdateexpire.ReadOnly = True
            txtduration.ReadOnly = False
            Session("CHECKED") = "FALSE"
        End If
    End Sub

    Private Sub txtdateexpire_TextChanged(sender As Object, e As EventArgs) Handles txtdateexpire.TextChanged
        If chkexpire.Checked = True Then
            Dim a As Date = txtdatehire.Text
            Dim b As Date = txtdateexpire.Text
            'txtduration.Text = Math.Abs(b.Month - a.Month).ToString()
            txtduration.Text = Math.Abs((b.Month - a.Month) + 12 * (b.Year - a.Year)).ToString()
            Dim hasil As String = txtduration.Text
        End If
    End Sub
End Class