Imports AXA.Framework.DataAccess
Imports System.Data.OleDb
Imports System.Data
Imports System.IO
Imports System.Configuration
Imports System.Web.UI
Imports System.Web
Imports System.DirectoryServices
Imports System.Data.SqlClient
Partial Public Class ListEdit_Employee
    Inherits System.Web.UI.Page
    Dim oSelect As New SelectBase
    Sub Searching()

        If ChkEmpl1.Checked = True And txtEmplID.Text = "" Then
            lblEmplID2.Visible = True
            lblEmplID2.Text = "* Please fill Employee ID"

            Exit Sub
        End If

        If ChkName.Checked = True And txtName.Text = "" Then
            lblName.Visible = True
            lblName.Text = "* Please fill Employee Name"

            Exit Sub
        End If

        grid_Databinding()

        dgListEditEmployee2.PageSize = 10
        dgListEditEmployee2.PageIndex = 0
        dgListEditEmployee2.DataBind()


        lblTotal.Text = dgListEditEmployee2.PageCount
        txtGO.Value = dgListEditEmployee2.PageIndex + 1

        lblEmplID2.Visible = False
        lblName.Visible = False
    End Sub
    Protected Sub Search_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Search.Click
        Searching()
    End Sub

    Private Sub grid_Databinding()

        Dim _emplID As String = ""
        Dim _emplName As String = ""

        Dim _flagemplID As String
        Dim _flagemplName As String

        If ChkEmpl1.Checked = False Then
            _flagemplID = "0"
            lblEmplID2.Visible = False
        Else
            _flagemplID = "1"
            _emplID = txtEmplID.Text
            lblEmplID2.Visible = False
        End If

        If ChkName.Checked = False Then
            _flagemplName = "0"
            lblName.Visible = False
        Else
            _flagemplName = "1"
            _emplName = txtName.Text
            lblName.Visible = False
        End If


        Dim dtSelect As New DataTable
        dtSelect = oSelect.f_SEL_LIST_EMPL(_emplID, _emplName, _flagemplID, _flagemplName)

        Session("dtSelect") = dtSelect

        dgListEditEmployee2.PageSize = 10
        dgListEditEmployee2.DataSource = dtSelect
        dgListEditEmployee2.Visible = True


        lblTotalRecords.Text = dtSelect.Rows.Count.ToString & " record(s)"
    End Sub
    '
    '    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '        Dim command As String = Session("Command")
    'End Sub
    Protected Sub lbFirst_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbFirst.Click
        'dgListEditEmployee2.DataSource = oSelect.f_SelRekeningKoran
        grid_Databinding()
        dgListEditEmployee2.DataBind()
        dgListEditEmployee2.PageIndex = 0
        dgListEditEmployee2.DataBind()

        txtGO.Value = dgListEditEmployee2.PageIndex + 1
    End Sub

    Protected Sub lbPrev_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbPrev.Click
        If dgListEditEmployee2.PageIndex <> 0 Then
            'dgListEditEmployee2.DataSource = oSelect.f_SelRekeningKoran
            grid_Databinding()
            dgListEditEmployee2.DataBind()
            dgListEditEmployee2.PageIndex = dgListEditEmployee2.PageIndex - 1
            dgListEditEmployee2.DataBind()

            txtGO.Value = dgListEditEmployee2.PageIndex + 1
        End If
    End Sub

    Protected Sub lnkNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkNext.Click
        If dgListEditEmployee2.PageIndex <> dgListEditEmployee2.PageCount - 1 Then
            'dgListEditEmployee2.DataSource = oSelect.f_SelRekeningKoran
            grid_Databinding()
            dgListEditEmployee2.DataBind()
            dgListEditEmployee2.PageIndex = dgListEditEmployee2.PageIndex + 1
            dgListEditEmployee2.DataBind()

            txtGO.Value = dgListEditEmployee2.PageIndex + 1
        End If
    End Sub

    Protected Sub lnkLast_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkLast.Click
        'dgListEditEmployee2.DataSource = oSelect.f_SelRekeningKoran
        grid_Databinding()
        dgListEditEmployee2.DataBind()
        dgListEditEmployee2.PageIndex = dgListEditEmployee2.PageCount - 1
        dgListEditEmployee2.DataBind()

        txtGO.Value = dgListEditEmployee2.PageIndex + 1
    End Sub

    Protected Sub lnkGo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkGo.Click
        If IsNumeric(txtGO.Value) = True Then
            If txtGO.Value <= dgListEditEmployee2.PageCount - 1 Then
                'dgListEditEmployee2.DataSource = oSelect.f_SelRekeningKoran
                grid_Databinding()
                dgListEditEmployee2.DataBind()
                dgListEditEmployee2.PageIndex = Int32.Parse(txtGO.Value) - 1
                dgListEditEmployee2.DataBind()

                txtGO.Value = dgListEditEmployee2.PageIndex + 1
            End If
        End If
    End Sub
    Protected Sub ddl_View_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_View.SelectedIndexChanged

        If ddl_View.SelectedValue = "10" Then
            grid_Databinding()
            dgListEditEmployee2.PageSize = 10
            dgListEditEmployee2.PageIndex = 0
            dgListEditEmployee2.DataBind()

            lblTotal.Text = dgListEditEmployee2.PageCount
            txtGO.Value = dgListEditEmployee2.PageIndex + 1
        ElseIf ddl_View.SelectedValue = "20" Then
            grid_Databinding()
            dgListEditEmployee2.PageSize = 20
            dgListEditEmployee2.PageIndex = 0
            dgListEditEmployee2.DataBind()

            lblTotal.Text = dgListEditEmployee2.PageCount
            txtGO.Value = dgListEditEmployee2.PageIndex + 1
        ElseIf ddl_View.SelectedValue = "50" Then
            grid_Databinding()
            dgListEditEmployee2.PageSize = 50
            dgListEditEmployee2.PageIndex = 0
            dgListEditEmployee2.DataBind()

            lblTotal.Text = dgListEditEmployee2.PageCount
            txtGO.Value = dgListEditEmployee2.PageIndex + 1
        ElseIf ddl_View.SelectedValue = "70" Then
            grid_Databinding()
            dgListEditEmployee2.PageSize = 70
            dgListEditEmployee2.PageIndex = 0
            dgListEditEmployee2.DataBind()


            lblTotal.Text = dgListEditEmployee2.PageCount
            txtGO.Value = dgListEditEmployee2.PageIndex + 1
        ElseIf ddl_View.SelectedValue = "100" Then
            grid_Databinding()
            dgListEditEmployee2.PageSize = 100
            dgListEditEmployee2.PageIndex = 0
            dgListEditEmployee2.DataBind()

            lblTotal.Text = dgListEditEmployee2.PageCount
            txtGO.Value = dgListEditEmployee2.PageIndex + 1
        End If
    End Sub
    Protected Sub btn_Hidden_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_Hidden.Click
        Searching()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

        End If

    End Sub
    Protected Sub dgListEditEmployee2_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles dgListEditEmployee2.RowCommand
        If e.CommandName = "cmdEdit" Then
            Dim rowIndex As Int32 = Convert.ToInt32(e.CommandArgument)

            Dim idx As String = dgListEditEmployee2.Rows(rowIndex).Cells(1).Text
            Response.Redirect("Frm_Edit.aspx?idx=" + idx)

        End If

    End Sub

    'Protected Sub lnkExport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lnkExport.Click
    '    export()
    'End Sub
    'Sub export()

    '    Dim _emplID As String = ""
    '    Dim _emplName As String = ""

    '    Dim _flagemplID As String
    '    Dim _flagemplName As String

    '    If ChkEmpl1.Checked = False Then
    '        _flagemplID = "0"
    '        lblEmplID2.Visible = False
    '    Else
    '        _flagemplID = "1"
    '        _emplID = txtEmplID.Text
    '        lblEmplID2.Visible = False
    '    End If

    '    If ChkName.Checked = False Then
    '        _flagemplName = "0"
    '        lblName.Visible = False
    '    Else
    '        _flagemplName = "1"
    '        _emplName = txtName.Text
    '        lblName.Visible = False
    '    End If


    '    'Dim StatKaryawan As String = ""

    '    'Dim dtSelect2 As New DataTable
    '    'dtSelect2 = oSelect.f_SEL_STAT_KARYAWAN(Session("EMPLNUMBER").ToString())
    '    'If dtSelect2.Rows.Count > 0 Then
    '    '    StatKaryawan = dtSelect2.Rows(0)("Status").ToString()
    '    'Else
    '    '    StatKaryawan = "FTE"
    '    'End If


    '    Dim dtSelect As New DataTable
    '    dtSelect = oSelect.f_SEL_LIST_EMPL(_emplID, _emplName, _flagemplID, _flagemplName)

    '    Dim uploadid As Integer
    '    uploadid = Convert.ToInt32(oSelect.f_InsertUploadFile("EXPORT LIST EMPLOYEE", Session("UserName").ToString, Session("Entity")).Rows(0)(0).ToString)

    '    ' Set the content type to Excel.
    '    ' Edit Data Grid To Gridview
    '    Dim dg As New GridView
    '    dg.DataSource = dtSelect
    '    dg.DataBind()


    '    For Each r As GridViewRow In dg.Rows
    '        If (r.RowType = DataControlRowType.DataRow) Then

    '            r.Cells(0).Attributes.Add("class", "text")
    '            r.Cells(1).Attributes.Add("class", "text")
    '            r.Cells(2).Attributes.Add("class", "text")
    '            r.Cells(3).Attributes.Add("class", "text")
    '            r.Cells(4).Attributes.Add("class", "text")
    '            r.Cells(5).Attributes.Add("class", "text")
    '            r.Cells(6).Attributes.Add("class", "text")
    '            r.Cells(7).Attributes.Add("class", "text")

    '        End If
    '    Next



    '    Dim filename As String = "Export List Employee" & Strings.Right(DateTime.Now.Year.ToString, 4).PadLeft(4, "0") & DateTime.Now.Month.ToString.PadLeft(2, "0") & DateTime.Now.Day.ToString.PadLeft(2, "0") & ".xls"
    '    'Response.AddHeader("content-disposition", "attachment;filename=" & filename)

    '    Response.ContentType = "application/vnd.ms-excel"
    '    'Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"

    '    'EDIT Himawan 26-06-2014 For File Name 
    '    Response.AddHeader("Content-Disposition", "inline; filename=" + filename)

    '    'Edit Himawan (25-06-2014) For Disable Open Button in save file dialog
    '    Response.AddHeader("X-Download-Options", "noopen")

    '    ' Remove the charset from the Content-Type header.
    '    Response.Charset = ""

    '    ' Turn off the view state.
    '    Me.EnableViewState = False

    '    Dim tw As New System.IO.StringWriter()
    '    Dim hw As New System.Web.UI.HtmlTextWriter(tw)

    '    dg.RenderControl(hw)

    '    If dg.Rows.Count > 0 Then

    '        Dim style As String = "<style> .text { mso-number-format:\@; } </style>"
    '        Response.Write(style)

    '        Response.Write(tw.ToString())

    '    Else
    '        Dim style As String = "NO DATA"
    '        Response.Write(style)
    '    End If
    '    Response.End()
    'End Sub
End Class