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
Imports System.IO

Public Class Frm_Edit
    Inherits System.Web.UI.Page
    Dim oSelect As New SelectBase
    Dim oInsert As New InsertBase
    Dim oUpdate As New UpdateBase
    Dim oDelete As New DeleteBase
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'LoadEntity()
            LoadManager()
            Session("_idx") = Request.QueryString("idx").ToString
            bindData(Session("_idx"))
            'countData()
        End If
    End Sub
    'Sub LoadEntity()
    '    Dim dt As New DataTable
    '    dt = oSelect.f_LOAD_DDL("ENTITY")
    '    ddl_Entity.Items.Clear()
    '    ddl_Entity.DataSource = dt
    '    ddl_Entity.DataValueField = "LongEntity"
    '    ddl_Entity.DataTextField = "ShortEntity"
    '    ddl_Entity.DataBind()

    '    ddl_Entity.Items.Insert(0, New ListItem("--Choose--", "0"))

    'End Sub
    Sub LoadManager()
        Dim dt As New DataTable
        dt = oSelect.f_LOAD_DDL("MANAGER")

        If dt.Rows.Count > 0 Then

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
    Public Sub Alert_Edit()
        Dim confirmValue As String = Request.Form("confirm_value")
    End Sub

    'Sub countData()
    '    Dim COUNTING_DATA As Integer
    '    Dim dtSelect As New DataTable
    '    dtSelect = oSelect.f_SEL_CHECK_DATA(Session("EMPLNUMBER").ToString)
    '    If dtSelect.Rows.Count > 0 Then
    '        COUNTING_DATA = Convert.ToInt32(dtSelect.Rows(0)("COUNTING").ToString())
    '        If COUNTING_DATA > 0 Then
    '            'Label7.Visible = True
    '        Else
    '            'Label7.Visible = False
    '        End If
    '    Else
    '        'Label7.Visible = False
    '    End If

    'End Sub

    'Sub bindData()
    '    Try
    '        Dim dtS As New DataTable
    '        Dim idx = Session("IDX").ToString
    '        dtS = oSelect.f_SEL_DETAIL_MST_EMPL(Convert.ToInt32(Session("IDX").ToString))

    '        If dtS.Rows.Count > 0 Then
    '            lblEmplID.Text = dtS.Rows(0)("EmployeeID").ToString()
    '            lblName.Text = dtS.Rows(0)("EmployeeName").ToString()
    '            txtdepartment.Text = dtS.Rows(0)("DepartmentName").ToString()
    '            ddl_Entity.SelectedIndex = ddl_Entity.Items.IndexOf(ddl_Entity.Items.FindByValue(dtS.Rows(0)("Entity").ToString()))
    '            txtarea.Text = dtS.Rows(0)("AreaName").ToString()
    '            ddl_Manager.SelectedIndex = ddl_Manager.Items.IndexOf(ddl_Manager.Items.FindByText(dtS.Rows(0)("EmployeeName_Manager").ToString()))
    '            txtdatehire.Text = dtS.Rows(0)("JoinDate").ToString()
    '            txtdateexpire.Text = dtS.Rows(0)("EndDate").ToString()
    '            txtduration.Text = dtS.Rows(0)("Duration").ToString()
    '            ddl_Status.SelectedIndex = ddl_Status.Items.IndexOf(ddl_Status.Items.FindByValue(dtS.Rows(0)("StatusEmployee").ToString()))
    '            Dim status = dtS.Rows(0)("StatusEmployee").ToString()
    '        End If

    '    Catch ex As Exception

    '    End Try
    'End Sub

    Sub bindData(ByVal IDX As String)
        Dim dtSelect As New DataTable
        dtSelect = oSelect.f_SEL_LOAD_DATA(IDX)
        If dtSelect.Rows.Count > 0 Then
            lblEmplID.Text = dtSelect.Rows(0)("EmployeeID").ToString()
            lblName.Text = dtSelect.Rows(0)("EmployeeName").ToString()
            lbldepartmemt.Text = dtSelect.Rows(0)("DepartmentName").ToString()
            lblEntity.Text = dtSelect.Rows(0)("Entity").ToString()
            txtarea.Text = dtSelect.Rows(0)("AreaName").ToString()
            ddl_Manager.SelectedIndex = ddl_Manager.Items.IndexOf(ddl_Manager.Items.FindByText(dtSelect.Rows(0)("EmployeeName_Manager").ToString()))
            txtdatehire.Text = dtSelect.Rows(0)("JoinDate").ToString()
            txtdateexpire.Text = dtSelect.Rows(0)("EndDate").ToString()
            txtduration.Text = dtSelect.Rows(0)("Duration").ToString()
            ddl_Status.SelectedIndex = ddl_Status.Items.IndexOf(ddl_Status.Items.FindByValue(dtSelect.Rows(0)("StatusEmployee").ToString()))
        End If

    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Try
            Dim confirmValue As String = Request.Form("confirm_value")
            If confirmValue = "Yes" Then

                Dim message2 As String
                Dim sb2 As New System.Text.StringBuilder()
                'Dim Counting As String = ""
                'Dim dtCrit2 As New DataTable
                'dtCrit2 = oSelect.f_SEL_GET_COUNT_EMPLOYEE(txtempid.Text, txtempname.Text, txtdatehire.Text)

                'If dtCrit2.Rows.Count > 0 Then
                '    Counting = dtCrit2.Rows(0)("Counting").ToString()
                'End If

                'If Counting >= 1 Then
                '    message2 = "Data already exist, please fill another data."
                '    sb2.Append("<script type = 'text/javascript'>")
                '    sb2.Append("window.onload=function(){")
                '    sb2.Append("alert('")
                '    sb2.Append(message2)
                '    sb2.Append("')};")
                '    sb2.Append("</script>")
                '    ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb2.ToString())
                '    Exit Sub
                'End If

                ' VALIDASI MANDATORY FIELD

                'If txtdepartment.Text = "" Then
                '    message2 = "Please Fill Department"
                '    sb2.Append("<script type = 'text/javascript'>")
                '    sb2.Append("window.onload=function(){")
                '    sb2.Append("alert('")
                '    sb2.Append(message2)
                '    sb2.Append("')};")
                '    sb2.Append("</script>")
                '    ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb2.ToString())
                '    txtdepartment.Focus()
                '    Exit Sub
                'End If
                'If ((ddl_Entity.SelectedValue.ToString = "0")) Then
                '    message2 = "Please Choose Entity"
                '    sb2.Append("<script type = 'text/javascript'>")
                '    sb2.Append("window.onload=function(){")
                '    sb2.Append("alert('")
                '    sb2.Append(message2)
                '    sb2.Append("')};")
                '    sb2.Append("</script>")
                '    ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb2.ToString())
                '    ddl_Entity.Focus()
                '    Exit Sub
                'End If
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
                'If txtdateexpire.Text = "" Then
                '    message2 = "Please Fill Expired Date"
                '    Dim sb2 As New System.Text.StringBuilder()
                '    sb2.Append("<script type = 'text/javascript'>")
                '    sb2.Append("window.onload=function(){")
                '    sb2.Append("alert('")
                '    sb2.Append(message2)
                '    sb2.Append("')};")
                '    sb2.Append("</script>")
                '    ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb2.ToString())
                '    txtdateexpire.Focus()
                '    Exit Sub
                'End If
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
                ' batas validasi mandatory 

                Dim _total As String = EditData()
                'countData()

            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Function EditData() As String
        Dim rows As Integer
        Submit()
        Return rows
    End Function

    Public Function Submit() As String
        Dim rows As String = ""

        'Dim MyCultureInfo As CultureInfo = New CultureInfo("de-DE")
        'Dim Datehire As DateTime = DateTime.Parse(txtdatehire.Text, MyCultureInfo,
        '                           DateTimeStyles.NoCurrentDateDefault)
        'Dim Dateexpire As DateTime = DateTime.Parse(txtdateexpire.Text, MyCultureInfo,
        '                           DateTimeStyles.NoCurrentDateDefault)


        oUpdate.f_INS_UPD_MST_EMPLOYEE(lblEmplID.Text, lblName.Text, lbldepartmemt.Text, lblEntity.Text, txtarea.Text,
                                       ddl_Manager.SelectedValue, txtdatehire.Text, txtdateexpire.Text, txtduration.Text, ddl_Status.SelectedValue, 1, "",
                                       Session("USERID").ToString, Request.QueryString("idx"), "EDIT")

        ScriptManager.RegisterStartupScript(Me, Me.GetType(),
        "alert",
        "alert('Update Data Success');window.location ='ListEdit_Employee.aspx';",
        True)

        'Catch ex As Exception

        'End Try
        Return rows
    End Function
    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Response.Redirect("ListEdit_Employee.aspx")
    End Sub
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        oDelete.f_Del_MST_EMPLOYEE(Request.QueryString("idx"))
        ScriptManager.RegisterStartupScript(Me, Me.GetType(),
        "alert",
        "alert('Delete Succesfully');window.location ='ListEdit_Employee.aspx';",
        True)

        'Catch ex As Exception
        'End Try
    End Sub
End Class