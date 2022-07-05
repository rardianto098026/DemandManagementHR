Imports AXA.Framework.DataAccess
Imports System.Data.OleDb
Imports System.Data
Imports System.IO
Imports System.Configuration
Imports System.Web.UI
Imports System.Web
Imports System.DirectoryServices
Imports System.Data.SqlClient
Partial Public Class Frm_List_Empl
    Inherits System.Web.UI.Page
    Dim oSelect As New SelectBase
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            lblENTER.Text = ""
        Else
            If lblENTER.Text = "CLICK" Then
                Searching()
                lblENTER.Text = ""
            End If
        End If
    End Sub

    Sub Searching()
        'Validation
        If ChkEmplID.Checked = True And txtEmplID.Text = "" Then
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

        dgListEditNotif.PageSize = 10
        dgListEditNotif.PageIndex = 0
        dgListEditNotif.DataBind()


        lblTotal.Text = dgListEditNotif.PageCount
        txtGO.Value = dgListEditNotif.PageIndex + 1

        lblEmplID2.Visible = False
        lblName.Visible = False
    End Sub
    Private Sub grid_Databinding()

        Dim _emplID As String = ""
        Dim _emplName As String = ""

        Dim _flagemplID As String
        Dim _flagemplName As String

        If ChkEmplID.Checked = False Then
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
        dtSelect = oSelect.f_SEL_LIST_EMPL(_emplID, _emplName, _flagemplID, _flagemplName, Session("ROLE"), Session("EMPLNUMBER"), Session("ENTITY"))
        Session("dtSelect") = dtSelect
        dgListEditNotif.PageSize = 10
        dgListEditNotif.DataSource = dtSelect
        dgListEditNotif.Visible = True


        lblTotalRecords.Text = dtSelect.Rows.Count.ToString & " record(s)"
    End Sub
    Protected Sub Search_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Search.Click
        Searching()
    End Sub
    Protected Sub btn_Hidden_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_Hidden.Click
        Searching()
    End Sub
    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    Dim command As String = Session("Command")
    'End Sub
    Protected Sub lbFirst_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbFirst.Click
        'dgListEditNotif.DataSource = oSelect.f_SelRekeningKoran
        grid_Databinding()
        dgListEditNotif.DataBind()
        dgListEditNotif.PageIndex = 0
        dgListEditNotif.DataBind()

        txtGO.Value = dgListEditNotif.PageIndex + 1
    End Sub

    Protected Sub lbPrev_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbPrev.Click
        If dgListEditNotif.PageIndex <> 0 Then
            'dgListEditNotif.DataSource = oSelect.f_SelRekeningKoran
            grid_Databinding()
            dgListEditNotif.DataBind()
            dgListEditNotif.PageIndex = dgListEditNotif.PageIndex - 1
            dgListEditNotif.DataBind()

            txtGO.Value = dgListEditNotif.PageIndex + 1
        End If
    End Sub

    Protected Sub lnkNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkNext.Click
        If dgListEditNotif.PageIndex <> dgListEditNotif.PageCount - 1 Then
            'dgListEditNotif.DataSource = oSelect.f_SelRekeningKoran
            grid_Databinding()
            dgListEditNotif.DataBind()
            dgListEditNotif.PageIndex = dgListEditNotif.PageIndex + 1
            dgListEditNotif.DataBind()

            txtGO.Value = dgListEditNotif.PageIndex + 1
        End If
    End Sub

    Protected Sub lnkLast_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkLast.Click
        'dgListEditNotif.DataSource = oSelect.f_SelRekeningKoran
        grid_Databinding()
        dgListEditNotif.DataBind()
        dgListEditNotif.PageIndex = dgListEditNotif.PageCount - 1
        dgListEditNotif.DataBind()

        txtGO.Value = dgListEditNotif.PageIndex + 1
    End Sub

    Protected Sub lnkGo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkGo.Click
        If IsNumeric(txtGO.Value) = True Then
            If txtGO.Value <= dgListEditNotif.PageCount - 1 Then
                'dgListEditNotif.DataSource = oSelect.f_SelRekeningKoran
                grid_Databinding()
                dgListEditNotif.DataBind()
                dgListEditNotif.PageIndex = Int32.Parse(txtGO.Value) - 1
                dgListEditNotif.DataBind()

                txtGO.Value = dgListEditNotif.PageIndex + 1
            End If
        End If
    End Sub
    Protected Sub ddl_View_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_View.SelectedIndexChanged

        If ddl_View.SelectedValue = "10" Then
            grid_Databinding()
            dgListEditNotif.PageSize = 10
            dgListEditNotif.PageIndex = 0
            dgListEditNotif.DataBind()

            lblTotal.Text = dgListEditNotif.PageCount
            txtGO.Value = dgListEditNotif.PageIndex + 1
        ElseIf ddl_View.SelectedValue = "20" Then
            grid_Databinding()
            dgListEditNotif.PageSize = 20
            dgListEditNotif.PageIndex = 0
            dgListEditNotif.DataBind()

            lblTotal.Text = dgListEditNotif.PageCount
            txtGO.Value = dgListEditNotif.PageIndex + 1
        ElseIf ddl_View.SelectedValue = "50" Then
            grid_Databinding()
            dgListEditNotif.PageSize = 50
            dgListEditNotif.PageIndex = 0
            dgListEditNotif.DataBind()

            lblTotal.Text = dgListEditNotif.PageCount
            txtGO.Value = dgListEditNotif.PageIndex + 1
        ElseIf ddl_View.SelectedValue = "70" Then
            grid_Databinding()
            dgListEditNotif.PageSize = 70
            dgListEditNotif.PageIndex = 0
            dgListEditNotif.DataBind()


            lblTotal.Text = dgListEditNotif.PageCount
            txtGO.Value = dgListEditNotif.PageIndex + 1
        ElseIf ddl_View.SelectedValue = "100" Then
            grid_Databinding()
            dgListEditNotif.PageSize = 100
            dgListEditNotif.PageIndex = 0
            dgListEditNotif.DataBind()

            lblTotal.Text = dgListEditNotif.PageCount
            txtGO.Value = dgListEditNotif.PageIndex + 1
        End If
    End Sub
    Sub Searching_Export()
        If ChkEmplID.Checked = True And txtEmplID.Text = "" Then
            lblEmplID2.Visible = True
            lblEmplID2.Text = "* Please fill Employee ID"

            Exit Sub
        End If

        If ChkName.Checked = True And txtName.Text = "" Then
            lblName.Visible = True
            lblName.Text = "* Please fill Employee Name"

            Exit Sub
        End If


        grid_Export()
    End Sub

    Private Sub grid_Export()
        Dim _emplID As String = ""
        Dim _emplName As String = ""

        Dim _flagemplID As String
        Dim _flagemplName As String

        If ChkEmplID.Checked = False Then
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
        dtSelect = oSelect.f_SEL_LIST_EMPL(_emplID, _emplName, _flagemplID, _flagemplName, Session("ROLE"), Session("EMPLNUMBER"), Session("ENTITY"))
        Session("dtSelectExportUser") = dtSelect

    End Sub

    Sub exportReport()

        Dim dgs As New GridView
        dgs.DataSource = Session("dtSelectExportUser")
        dgs.DataBind()

        For Each r As GridViewRow In dgs.Rows
            If (r.RowType = DataControlRowType.DataRow) Then
                r.Cells(0).Attributes.Add("class", "text")
                r.Cells(1).Attributes.Add("class", "text")
                r.Cells(2).Attributes.Add("class", "text")
                r.Cells(3).Attributes.Add("class", "text")
                r.Cells(4).Attributes.Add("class", "text")
                r.Cells(5).Attributes.Add("class", "text")
            End If
        Next



        Dim filename As String = "List Employee" & Strings.Right(DateTime.Now.Year.ToString, 4).PadLeft(4, "0") & DateTime.Now.Month.ToString.PadLeft(2, "0") & DateTime.Now.Day.ToString.PadLeft(2, "0") & ".xls"


        Response.ContentType = "application/vnd.ms-excel"
        Response.AddHeader("Content-Disposition", "inline; filename=" + filename)

        Response.AddHeader("X-Download-Options", "noopen")

        Response.Charset = ""

        Me.EnableViewState = False

        Dim tw As New System.IO.StringWriter()
        Dim hw As New System.Web.UI.HtmlTextWriter(tw)

        dgs.RenderControl(hw)

        If dgs.Rows.Count > 0 Then

            Dim style As String = "<style> .text { mso-number-format:\@; } </style>"
            Response.Write(style)



            ' Write the HTML back to the browser.
            Response.Write(tw.ToString())

        Else
            Dim style As String = "NO DATA"
            Response.Write(style)
        End If
        Response.End()

        Session.Remove("dtSelect")
        Session.Remove("dtSelectExportUser")
    End Sub

    Private Sub Download_Click(sender As Object, e As EventArgs) Handles Download.Click
        Searching_Export()
        exportReport()
    End Sub

    Protected Sub dgListEditNotif_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles dgListEditNotif.RowCommand
        If e.CommandName = "cmdEdit" Then
            'Dim rowIndex As Int32 = Convert.ToInt32(e.CommandArgument)

            'Dim idx As String = dgListEditEmployee2.Rows(rowIndex).Cells(1).Text
            Dim clickedButton As ImageButton = CType(e.CommandSource, ImageButton)
            Dim clickedRow As GridViewRow = CType(clickedButton.NamingContainer, GridViewRow)
            Dim idx As String = clickedRow.Cells(1).Text

            Response.Redirect("PopUpEmpl.aspx?idx=" + idx)

        End If
    End Sub

    Protected Sub Button1_Click(sender As Object, e As System.EventArgs)
        'ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Name: " & txtName.Text & "');", True)

    End Sub
End Class