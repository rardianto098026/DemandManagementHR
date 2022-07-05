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
    Sub Searching()
        'Validation
        If chkEmplID.Checked = True And txtEmplID.Text = "" Then
            lblErrEmplID2.Visible = True
            lblErrEmplID2.Text = "* Please fill the Employee Number"

            Exit Sub
        End If

        If chkEmplName.Checked = True And txtEmplName.Text = "" Then
            lblErrEmplName2.Visible = True
            lblErrEmplName2.Text = "* Please fill the Employee Name"

            Exit Sub
        End If

        grid_Databinding()

        dgRekeningKoran.PageSize = 10
        dgRekeningKoran.PageIndex = 0
        dgRekeningKoran.DataBind()


        lblTotal.Text = dgRekeningKoran.PageCount
        txtGO.Value = dgRekeningKoran.PageIndex + 1

        lblErrEmplID2.Visible = False
        lblErrEmplName2.Visible = False
    End Sub
    Private Sub grid_Databinding()

        Dim _emplID As String = ""
        Dim _emplName As String = ""

        Dim _flagemplID As String
        Dim _flagemplName As String

        If chkEmplID.Checked = False Then
            _flagemplID = "0"
            lblErrEmplID2.Visible = False
        Else
            _flagemplID = "1"
            _emplID = txtEmplID.Text
            lblErrEmplID2.Visible = False
        End If

        If chkEmplName.Checked = False Then
            _flagemplName = "0"
            lblErrEmplName2.Visible = False
        Else
            _flagemplName = "1"
            _emplName = txtEmplName.Text
            lblErrEmplName2.Visible = False
        End If

        Dim dtSelect As New DataTable
        dtSelect = oSelect.f_SEL_LIST_EMPL(_emplID, _emplName, _flagemplID, _flagemplName)
        Session("dtSelect") = dtSelect
        dgRekeningKoran.PageSize = 10
        dgRekeningKoran.DataSource = dtSelect
        dgRekeningKoran.Visible = True


        lblTotalRecords.Text = dtSelect.Rows.Count.ToString & " record(s)"
    End Sub
    Protected Sub Search_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Search.Click
        Searching()
    End Sub
    Protected Sub btn_Hidden_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_Hidden.Click
        Searching()
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

End Class