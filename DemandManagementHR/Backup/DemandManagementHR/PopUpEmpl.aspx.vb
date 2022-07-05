Imports AXA.Framework.DataAccess
Imports System.Data.OleDb
Imports System.Data
Imports System.IO
Imports System.Configuration
Imports System.Web.UI
Imports System.Web
Imports System.Data.SqlClient
Partial Public Class PopUpEmpl
    Inherits System.Web.UI.Page
    Dim oSelect As New SelectBase
    Dim oUpdate As New UpdateBase
    Sub ListNotif()
        Dim dtS As New DataTable
        dtS = oSelect.f_SEL_MST_NOTIF()

        chkList.DataSource = dtS
        chkList.DataTextField = "NotifDesc"
        chkList.DataValueField = "idxNotif"
        chkList.DataBind()
    End Sub
    Sub ListDataBind()
        Try
            Dim dtS As New DataTable
            dtS = oSelect.f_SEL_DETAIL_MST_EMPL(Session("IDX").ToString)

            If dtS.Rows.Count > 0 Then
                lblEmplID2.Text = dtS.Rows(0)("EmployeeID").ToString()
                lblEmplName2.Text = dtS.Rows(0)("EmployeeName").ToString()
                lblArea2.Text = dtS.Rows(0)("AreaName").ToString()
                lblDeptName2.Text = dtS.Rows(0)("DepartmentName").ToString()
                lblJoinDate2.Text = dtS.Rows(0)("JoinDate").ToString()
                lblExpDate2.Text = dtS.Rows(0)("EndDate").ToString()
                lblEntity2.Text = dtS.Rows(0)("Entity").ToString()
                lblStatEmpl2.Text = dtS.Rows(0)("StatusEmployee").ToString()
                lblDuration2.Text = dtS.Rows(0)("Duration").ToString()
                lblEmlMgr2.Text = dtS.Rows(0)("EmailManager").ToString()

                Dim chkbx As CheckBoxList
                chkbx = CType(FindControl("chkList"), CheckBoxList)

                If dtS.Rows(0)("FlagOneDay").ToString() <> 0 Then
                    chkbx.Items.FindByText("1 Days").Selected = True
                End If

                If dtS.Rows(0)("FlagOneWeek").ToString() <> 0 Then
                    chkbx.Items.FindByText("1 Week").Selected = True
                End If

                If dtS.Rows(0)("FlagTwoWeek").ToString() <> 0 Then
                    chkbx.Items.FindByText("2 Weeks").Selected = True
                End If

                If dtS.Rows(0)("FlagThreeWeek").ToString() <> 0 Then
                    chkbx.Items.FindByText("3 Weeks").Selected = True
                End If

                If dtS.Rows(0)("FlagOneMonth").ToString() <> 0 Then
                    chkbx.Items.FindByText("1 Month").Selected = True
                End If

                If dtS.Rows(0)("FlagThreeMonth").ToString() <> 0 Then
                    chkbx.Items.FindByText("3 Months").Selected = True
                End If

            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub Alert()
        Dim confirmValue As String = Request.Form("confirm_value")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Session("IDX") = Request.QueryString("idx").ToString
            ListNotif()
            ListDataBind()
        End If
    End Sub

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Dim confirmValue As String = Request.Form("confirm_value")
        If confirmValue = "Yes" Then
            Dim i As Integer
            Dim chkbx As CheckBoxList
            chkbx = CType(FindControl("chkList"), CheckBoxList)
            For i = 0 To chkbx.Items.Count - 1
                If chkbx.Items(i).Selected Then
                    oUpdate.f_UPDATE_NOTIF_EMAIL_MST_EMPL(Session("UserID").ToString, chkbx.Items(i).Text, Session("IDX").ToString, "CHECK")
                Else
                    oUpdate.f_UPDATE_NOTIF_EMAIL_MST_EMPL(Session("UserID").ToString, chkbx.Items(i).Text, Session("IDX").ToString, "UNCHECK")
                End If
            Next
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "redirect", _
            "alert('Save Data Sukses'); window.location='Frm_list_empl.aspx';", True)
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "close", "window.close();", True)
        End If
    End Sub
End Class