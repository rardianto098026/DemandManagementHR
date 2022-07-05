Imports AXA.Framework.DataAccess
Imports System.Data.OleDb
Imports System.Data
Imports System.IO
Imports System.Data.SqlClient

Partial Public Class Download_Failed_Upload
    Inherits System.Web.UI.Page
    Dim oSelect As New SelectBase
    Sub export2()
        If chkExpDate.Checked = True And (txtPolExpDateFrom.Text = "" Or txtPolExpDateTo.Text = "") Then
            lblpolExpDate.Visible = True
            lblpolExpDate.Text = "* Please fill Start Date and To Date"

            Exit Sub
        End If
        
        Dim dtFinaldate As String
        Dim sDate As String() = txtPolExpDateFrom.Text.ToString.Split("/")
        dtFinaldate = sDate(2) + "-" + sDate(1) + "-" + sDate(0)

        Dim dtFinaldateTo As String
        Dim sDateTo As String() = txtPolExpDateTo.Text.ToString.Split("/")
        dtFinaldateTo = sDateTo(2) + "-" + sDateTo(1) + "-" + sDateTo(0)

        Dim _flagChkDate As Integer = 0
        Dim _flagCorpCode As Integer = 0

        If chkExpDate.Checked = False Then
            _flagChkDate = "0"
        Else
            _flagChkDate = "1"
        End If


        Dim dtTable As DataTable
        dtTable = oSelect.f_SEL_Download_Failed_Upload(dtFinaldate, dtFinaldateTo)
        Dim uploadid As Integer
        uploadid = Convert.ToInt32(oSelect.f_InsertUploadFile("DownloadFailed Upload", Session("UserName").ToString, Session("Entity")).Rows(0)(0).ToString)

        ' Set the content type to Excel.
        ' Edit Data Grid To Gridview
        Dim dg As New GridView
        dg.DataSource = dtTable
        dg.DataBind()


        For Each r As GridViewRow In dg.Rows
            If (r.RowType = DataControlRowType.DataRow) Then
                r.Cells(0).Attributes.Add("class", "text")
                r.Cells(1).Attributes.Add("class", "text")
                r.Cells(2).Attributes.Add("class", "text")
                r.Cells(3).Attributes.Add("class", "text")
                r.Cells(5).Attributes.Add("class", "text")
                r.Cells(6).Attributes.Add("class", "text")
                r.Cells(7).Attributes.Add("class", "text")
                r.Cells(8).Attributes.Add("class", "text")
                r.Cells(9).Attributes.Add("class", "text")
                r.Cells(10).Attributes.Add("class", "text")
                r.Cells(11).Attributes.Add("class", "text")
                r.Cells(12).Attributes.Add("class", "text")
                r.Cells(13).Attributes.Add("class", "text")
                r.Cells(14).Attributes.Add("class", "text")

            End If
        Next



        Dim filename As String = "Failed Upload" & Strings.Right(DateTime.Now.Year.ToString, 4).PadLeft(4, "0") & DateTime.Now.Month.ToString.PadLeft(2, "0") & DateTime.Now.Day.ToString.PadLeft(2, "0") & ".xls"


        Response.ContentType = "application/vnd.ms-excel"
        Response.AddHeader("Content-Disposition", "inline; filename=" + filename)

        Response.AddHeader("X-Download-Options", "noopen")

        Response.Charset = ""

        Me.EnableViewState = False

        Dim tw As New System.IO.StringWriter()
        Dim hw As New System.Web.UI.HtmlTextWriter(tw)

        dg.RenderControl(hw)

        If dg.Rows.Count > 0 Then

            Dim style As String = "<style> .text { mso-number-format:\@; } </style>"
            Response.Write(style)



            ' Write the HTML back to the browser.
            Response.Write(tw.ToString())


        Else
            Dim style As String = "NO DATA"
            Response.Write(style)
        End If
        Response.End()

    End Sub
    Protected Sub Search_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Search.Click
        export2()
    End Sub
End Class