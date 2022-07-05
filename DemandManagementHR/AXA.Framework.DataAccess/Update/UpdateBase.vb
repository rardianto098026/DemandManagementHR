Imports System.Configuration
Imports System.Data.SqlClient
Imports System
Imports System.Data.OleDb

Public Class UpdateBase
    Inherits DataAccessBase

    'Dim _connectionString As String = ConfigurationManager.ConnectionStrings("ConSql").ToString
    Dim _connectionString_AFI As String = ConfigurationManager.ConnectionStrings("ConSql").ToString

#Region "Constanta"
    Dim const_SP_Update_REASON_INVEST As String = "SP_Update_REASON_INVEST"
    Dim const_sp_UPDATE_LOGOUT As String = "sp_UPDATE_LOGOUT"
    Dim const_sp_UPDATE_EMAIL As String = "sp_UPDATE_EMAIL"
    Dim const_sp_UPDATE_DEPARTMENT As String = "sp_UPDATE_DEPT"
    Dim const_SP_Update_LIFE_CYCLE As String = "sp_UPDATE_LIFECYCLE"
    Dim const_SP_Update_TOTAL_INV_AMOUNT As String = "sp_UPDATE_TOTAL_INV_AMOUNT"

    Dim const_SP_Update_COMPLETE_DOCUMENT As String = "sp_UPDATE_FCR_COMPLETE_DOC"
    Dim const_SP_Update_POL_DOCUMENT As String = "sp_UPDATE_FCR_POL_DOC"

    Dim const_SP_Update_INCOMPLETE_DOCUMENT As String = "sp_UPDATE_FCR_INCOMPLETE_DOC"
    Dim const_SP_Update_FBA_APPROVED_ADMIN As String = "sp_UPDATE_FBA_APPROVED_ADMIN"
    Dim const_SP_Update_FBA_APPROVED_FA As String = "sp_UPDATE_FBA_APPROVED_FINANCE"
    Dim const_SP_Update_FBA_APPROVED_FA_2 As String = "sp_UPDATE_FBA_APPROVED_FINANCE_2"
    Dim const_SP_Update_FBA_APPROVED_PAYMENT_SUBMIT As String = "[sp_UPDATE_FBA_APPROVED_PAYMENT_SUBMITED]"
    Dim const_SP_Update_FBA_APPROVED_PAYMENT_SUBMIT2 As String = "[sp_UPDATE_FBA_APPROVED_PAYMENT_SUBMITED_2]"
    Dim const_SP_Update_PAYMENT_REPORT_APPROVED As String = "sp_UPDATE_PAYMENT_REPORT_APPROVED"
    Dim const_SP_Update_PAYMENT_REPORT_FLAG_DOWNLOAD As String = "sp_UPDATE_PAYMENT_REPORT_FLAG_DOWNLOAD"
    Dim const_SP_Update_FLAG_SMS_LETTER As String = "sp_UPDATE_FLAG_SMS_LETTER"
    Dim const_SP_Update_FLAG_PAYMENT_FBA As String = "sp_UPDATE_FLAG_PAYMENT_FBA"

    'Dim const_sp_UPDATE_REKENINGKORAN_ITEM = "sp_EDIT_REKENINGKORAN_ITEM"
    'Dim const_sp_UPDATE_REKENINGKORAN_ITEM_SETTLED = "sp_EDIT_REKENINGKORAN_ITEM_SETTLED"
    'Dim const_sp_UPDATE_DCR_FLAG = "sp_UPDATE_DCR_FLAG"
    'Dim const_sp_UPDATE_SEQ_NUMBER = "sp_UPDATE_SEQ_NUMBER"

#End Region
    Public Function f_Update_LifeCycle(ByVal idx As String, ByVal _ClaimNo As String, ByVal _PolicyNo As String, _
                                 ByVal _NameInsured As String, ByVal _Product As String, _
                                 ByVal _DateLetteRPrinting_pendingletter As String, ByVal _DateLetterDispatch_pending_letter As String, _
                                 ByVal _Nextfollowup As String, ByVal _DateLetterPrinting_closingletter As String, _
                                 ByVal _DateLetterDispatch_closingletter As String, ByVal _DateLetterPrinting_ClaimSummary As String, _
                                 ByVal _DateLetterDispatch_ClaimSummary As String, ByVal _DateLetterPrinting_Declineletter As String, _
                                 ByVal _DateLetterDispatch_Declineletter As String, ByVal _TATRecvdtoPrint As String, _
                                 ByVal _PICCLAIM As String, ByVal _DateofFirstFCR As String, ByVal _TATRecvdtoFCR As String, ByVal _Output As String, _
                                 ByVal _PIC As String, ByVal _DateOFFBA As String, ByVal _TATRecvdtoFBA As String, ByVal _DateOfPaymentReporting As String, ByVal _TATRecvdtoPaymtReport As String, _
                                 ByVal _Status As String, ByVal _DateOfFirstSHC As String, ByVal _TATRecvdtoFirstSHC As String, ByVal _OutputFCR1 As String, ByVal _DateOfFirstRL As String, ByVal _TATRecvdtoFirstRL As String, _
                                 ByVal _OutputFCR2 As String, ByVal _DateOfMEDraft As String, ByVal _TATRecvdtoMEDraft As String, ByVal _DateofFirstME As String, ByVal _TATRecvdtoFirstME As String, ByVal _OutputME As String, _
                                 ByVal _DateofFirstEscalation As String, ByVal _TATRecvdtoFirstEscalation As String, ByVal _Decision As String, ByVal _PICInvestigasi As String, ByVal _Remark As String, ByVal _DateOfInitialInformation As String, _
                                 ByVal _DateforFollowup As String, ByVal _TATRecvdtoInitialInfo As String, ByVal _MonthClaimRecvd As String, ByVal _YearClaimRecvd As String, ByVal _FinalStatus As String, ByVal _OverallTAT As String, _
                                 ByVal _OverallAgeing As String, ByVal CreatedBy As String)

        Dim oParam(49) As SqlParameter

        oParam(0) = New SqlParameter("@ClaimNo", Data.SqlDbType.VarChar)
        oParam(0).Value = CType(_ClaimNo, String)

        oParam(1) = New SqlParameter("@PolicyNo", Data.SqlDbType.VarChar)
        oParam(1).Value = CType(_PolicyNo, String)

        oParam(2) = New SqlParameter("@NameInsured", Data.SqlDbType.VarChar)
        oParam(2).Value = CType(_NameInsured, String)

        oParam(3) = New SqlParameter("@Product", Data.SqlDbType.VarChar)
        oParam(3).Value = CType(_Product, String)

        oParam(4) = New SqlParameter("@DateLetteRPrinting_pendingletter", Data.SqlDbType.VarChar)
        oParam(4).Value = CType(_DateLetteRPrinting_pendingletter, String)

        oParam(5) = New SqlParameter("@DateLetterDispatch_pending_letter", Data.SqlDbType.VarChar)
        oParam(5).Value = CType(_DateLetterDispatch_pending_letter, String)

        oParam(6) = New SqlParameter("@Nextfollowup", Data.SqlDbType.VarChar)
        oParam(6).Value = CType(_Nextfollowup, String)

        oParam(7) = New SqlParameter("@DateLetterPrinting_closingletter", Data.SqlDbType.VarChar)
        oParam(7).Value = CType(_DateLetterPrinting_closingletter, String)

        oParam(8) = New SqlParameter("@DateLetterDispatch_closingletter", Data.SqlDbType.VarChar)
        oParam(8).Value = CType(_DateLetterDispatch_closingletter, String)

        oParam(9) = New SqlParameter("@DateLetterPrinting_ClaimSummary", Data.SqlDbType.VarChar)
        oParam(9).Value = CType(_DateLetterPrinting_ClaimSummary, String)

        oParam(10) = New SqlParameter("@DateLetterDispatch_ClaimSummary", Data.SqlDbType.VarChar)
        oParam(10).Value = CType(_DateLetterDispatch_ClaimSummary, String)

        oParam(11) = New SqlParameter("@DateLetterPrinting_Declineletter", Data.SqlDbType.VarChar)
        oParam(11).Value = CType(_DateLetterPrinting_Declineletter, String)

        oParam(12) = New SqlParameter("@DateLetterDispatch_Declineletter", Data.SqlDbType.VarChar)
        oParam(12).Value = CType(_DateLetterDispatch_Declineletter, String)

        oParam(13) = New SqlParameter("@TATRecvdtoPrint", Data.SqlDbType.VarChar)
        oParam(13).Value = CType(_TATRecvdtoPrint, String)

        oParam(14) = New SqlParameter("@PICCLAIM", Data.SqlDbType.VarChar)
        oParam(14).Value = CType(_PICCLAIM, String)

        oParam(15) = New SqlParameter("@DateofFirstFCR", Data.SqlDbType.VarChar)
        oParam(15).Value = CType(_DateofFirstFCR, String)

        oParam(16) = New SqlParameter("@TATRecvdtoFCR", Data.SqlDbType.VarChar)
        oParam(16).Value = CType(_TATRecvdtoFCR, String)

        oParam(17) = New SqlParameter("@Output", Data.SqlDbType.VarChar)
        oParam(17).Value = CType(_Output, String)

        oParam(18) = New SqlParameter("@PIC", Data.SqlDbType.VarChar)
        oParam(18).Value = CType(_PIC, String)

        oParam(19) = New SqlParameter("@DateOFFBA", Data.SqlDbType.VarChar)
        oParam(19).Value = CType(_DateOFFBA, String)

        oParam(20) = New SqlParameter("@TATRecvdtoFBA", Data.SqlDbType.VarChar)
        oParam(20).Value = CType(_TATRecvdtoFBA, String)

        oParam(21) = New SqlParameter("@DateOfPaymentReporting", Data.SqlDbType.VarChar)
        oParam(21).Value = CType(_DateOfPaymentReporting, String)

        oParam(22) = New SqlParameter("@TATRecvdtoPaymtReport", Data.SqlDbType.VarChar)
        oParam(22).Value = CType(_TATRecvdtoPaymtReport, String)

        oParam(23) = New SqlParameter("@Status", Data.SqlDbType.VarChar)
        oParam(23).Value = CType(_Status, String)

        oParam(24) = New SqlParameter("@DateOfFirstSHC", Data.SqlDbType.VarChar)
        oParam(24).Value = CType(_DateOfFirstSHC, String)

        oParam(25) = New SqlParameter("@TATRecvdtoFirstSHC", Data.SqlDbType.VarChar)
        oParam(25).Value = CType(_TATRecvdtoFirstSHC, String)

        oParam(26) = New SqlParameter("@OutputFCR1", Data.SqlDbType.VarChar)
        oParam(26).Value = CType(_OutputFCR1, String)

        oParam(27) = New SqlParameter("@DateOfFirstRL", Data.SqlDbType.VarChar)
        oParam(27).Value = CType(_DateOfFirstRL, String)

        oParam(28) = New SqlParameter("@TATRecvdtoFirstRL", Data.SqlDbType.VarChar)
        oParam(28).Value = CType(_TATRecvdtoFirstRL, String)

        oParam(29) = New SqlParameter("@OutputFCR2", Data.SqlDbType.VarChar)
        oParam(29).Value = CType(_OutputFCR2, String)

        oParam(30) = New SqlParameter("@DateOfMEDraft", Data.SqlDbType.VarChar)
        oParam(30).Value = CType(_DateOfMEDraft, String)

        oParam(31) = New SqlParameter("@TATRecvdtoMEDraft", Data.SqlDbType.VarChar)
        oParam(31).Value = CType(_TATRecvdtoMEDraft, String)

        oParam(32) = New SqlParameter("@DateofFirstME", Data.SqlDbType.VarChar)
        oParam(32).Value = CType(_DateofFirstME, String)

        oParam(33) = New SqlParameter("@TATRecvdtoFirstME", Data.SqlDbType.VarChar)
        oParam(33).Value = CType(_TATRecvdtoFirstME, String)

        oParam(34) = New SqlParameter("@OutputME", Data.SqlDbType.VarChar)
        oParam(34).Value = CType(_OutputME, String)

        oParam(35) = New SqlParameter("@DateofFirstEscalation", Data.SqlDbType.VarChar)
        oParam(35).Value = CType(_DateofFirstEscalation, String)

        oParam(36) = New SqlParameter("@TATRecvdtoFirstEscalation", Data.SqlDbType.VarChar)
        oParam(36).Value = CType(_TATRecvdtoFirstEscalation, String)

        oParam(37) = New SqlParameter("@Decision", Data.SqlDbType.VarChar)
        oParam(37).Value = CType(_Decision, String)

        oParam(38) = New SqlParameter("@PICInvestigasi", Data.SqlDbType.VarChar)
        oParam(38).Value = CType(_PICInvestigasi, String)

        oParam(39) = New SqlParameter("@Remark", Data.SqlDbType.VarChar)
        oParam(39).Value = CType(_Remark, String)

        oParam(40) = New SqlParameter("@DateOfInitialInformation", Data.SqlDbType.VarChar)
        oParam(40).Value = CType(_DateOfInitialInformation, String)

        oParam(41) = New SqlParameter("@DateforFollowup", Data.SqlDbType.VarChar)
        oParam(41).Value = CType(_DateforFollowup, String)

        oParam(42) = New SqlParameter("@TATRecvdtoInitialInfo", Data.SqlDbType.VarChar)
        oParam(42).Value = CType(_TATRecvdtoInitialInfo, String)

        oParam(43) = New SqlParameter("@MonthClaimRecvd", Data.SqlDbType.VarChar)
        oParam(43).Value = CType(_MonthClaimRecvd, String)

        oParam(44) = New SqlParameter("@YearClaimRecvd", Data.SqlDbType.VarChar)
        oParam(44).Value = CType(_YearClaimRecvd, String)

        oParam(45) = New SqlParameter("@FinalStatus", Data.SqlDbType.VarChar)
        oParam(45).Value = CType(_FinalStatus, String)

        oParam(46) = New SqlParameter("@OverallTAT", Data.SqlDbType.VarChar)
        oParam(46).Value = CType(_OverallTAT, String)

        oParam(47) = New SqlParameter("@OverallAgeing", Data.SqlDbType.VarChar)
        oParam(47).Value = CType(_OverallAgeing, String)

        oParam(48) = New SqlParameter("@CreatedBy", Data.SqlDbType.VarChar)
        oParam(48).Value = CType(CreatedBy, String)

        oParam(49) = New SqlParameter("@idx", Data.SqlDbType.VarChar)
        oParam(49).Value = CType(idx, String)

        Dim _connectionString As String = _connectionString_AFI


        Return (ExecuteNonQuery(_connectionString, const_SP_Update_LIFE_CYCLE, Data.CommandType.StoredProcedure, oParam))

    End Function

    Public Function f_UpdateLogout(ByVal _userid As String, ByVal _entity As String) As Integer

        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@USERID", SqlDbType.VarChar)
        oParam(0).Value = CType(_userid, String)

        Dim _connectionString As String = _connectionString_AFI
        Return ExecuteNonQuery(_connectionString, const_sp_UPDATE_LOGOUT, CommandType.StoredProcedure, oParam)

    End Function
    Public Function f_UpdateDept(ByVal _DeptID As Integer, ByVal _DeptName As String) As Integer

        Dim oParam(1) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@DeptID", SqlDbType.Int)
        oParam(0).Value = CType(_DeptID, Integer)

        oParam(1) = New SqlClient.SqlParameter("@DeptName", SqlDbType.VarChar)
        oParam(1).Value = CType(_DeptName, String)

        Dim _connectionString As String = _connectionString_AFI
        Return ExecuteNonQuery(_connectionString, const_sp_UPDATE_DEPARTMENT, CommandType.StoredProcedure, oParam)

    End Function
    Public Function f_UpdateFlagPaymentFBA(ByVal _ClaimNo As String, ByVal _CreatedBy As String) As Integer

        Dim oParam(1) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@ClaimNo", SqlDbType.VarChar)
        oParam(0).Value = CType(_ClaimNo, String)

        oParam(1) = New SqlClient.SqlParameter("@CreatedBy", SqlDbType.VarChar)
        oParam(1).Value = CType(_CreatedBy, String)

        Dim _connectionString As String = _connectionString_AFI
        Return ExecuteNonQuery(_connectionString, const_SP_Update_FLAG_PAYMENT_FBA, CommandType.StoredProcedure, oParam)

    End Function

    Public Function f_Update_TOTAL_INV_AMOUNT(ByVal _IDX As Integer, ByVal _TOTAL_INV As Decimal) As Integer

        Dim oParam(1) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@IDX", SqlDbType.Int)
        oParam(0).Value = CType(_IDX, Integer)

        oParam(1) = New SqlClient.SqlParameter("@TOTAL_INV", SqlDbType.Decimal)
        oParam(1).Value = CType(_TOTAL_INV, Decimal)

        Dim _connectionString As String = _connectionString_AFI
        Return ExecuteNonQuery(_connectionString, const_SP_Update_TOTAL_INV_AMOUNT, CommandType.StoredProcedure, oParam)

    End Function

    Public Function f_UPDATE_EMAIL(ByVal _IDX As Integer, ByVal _EMAIL As String, ByVal _CreatedBy As String) As Integer

        Dim oParam(2) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@IDX", SqlDbType.Int)
        oParam(0).Value = CType(_IDX, Integer)

        oParam(1) = New SqlClient.SqlParameter("@EMAIL", SqlDbType.VarChar)
        oParam(1).Value = CType(_EMAIL, String)

        oParam(2) = New SqlClient.SqlParameter("@CreatedBy", SqlDbType.VarChar)
        oParam(2).Value = CType(_CreatedBy, String)

        Dim _connectionString As String = _connectionString_AFI
        Return ExecuteNonQuery(_connectionString, const_sp_UPDATE_EMAIL, CommandType.StoredProcedure, oParam)

    End Function

    Public Function f_Updateflag_SMS_LETTER(ByVal CLAIMNO As String, ByVal POLICYNO As String) As Integer

        Dim oParam(1) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@CLAIMNO", SqlDbType.VarChar)
        oParam(0).Value = CType(CLAIMNO, String)

        oParam(1) = New SqlClient.SqlParameter("@POLICYNO", SqlDbType.VarChar)
        oParam(1).Value = CType(POLICYNO, String)


        Dim _connectionString As String = _connectionString_AFI
        Return ExecuteNonQuery(_connectionString, const_SP_Update_FLAG_SMS_LETTER, CommandType.StoredProcedure, oParam)

    End Function

    Public Function f_Edit_INCOMPLETE_DOCUMENT(ByVal CLAIMNO As String, ByVal POLICYNO As String, ByVal INCOMPLETE_DOCUMENT As String, ByVal CREATEDBY As String) As Integer

        Dim oParam(3) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@CLAIMNO", SqlDbType.VarChar)
        oParam(0).Value = CType(CLAIMNO, String)

        oParam(1) = New SqlClient.SqlParameter("@POLICYNO", SqlDbType.VarChar)
        oParam(1).Value = CType(POLICYNO, String)

        oParam(2) = New SqlClient.SqlParameter("@INCOMPLETE_DOCUMENT", SqlDbType.VarChar)
        oParam(2).Value = CType(INCOMPLETE_DOCUMENT, String)

        oParam(3) = New SqlClient.SqlParameter("@CREATEDBY", SqlDbType.VarChar)
        oParam(3).Value = CType(CREATEDBY, String)

        'oParam(4) = New SqlClient.SqlParameter("@IDX", SqlDbType.VarChar)
        'oParam(4).Value = CType(IDX, String)

        Dim _connectionString As String = _connectionString_AFI
        Return ExecuteNonQuery(_connectionString, const_SP_Update_INCOMPLETE_DOCUMENT, CommandType.StoredProcedure, oParam)

    End Function

    Public Function f_Edit_REASON_INVEST(ByVal CLAIMNO As String, ByVal POLICYNO As String, ByVal REASONINVEST As String, ByVal CREATEDBY As String) As Integer

        Dim oParam(3) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@CLAIMNO", SqlDbType.VarChar)
        oParam(0).Value = CType(CLAIMNO, String)

        oParam(1) = New SqlClient.SqlParameter("@POLICYNO", SqlDbType.VarChar)
        oParam(1).Value = CType(POLICYNO, String)

        oParam(2) = New SqlClient.SqlParameter("@REASONINVEST", SqlDbType.VarChar)
        oParam(2).Value = CType(REASONINVEST, String)

        oParam(3) = New SqlClient.SqlParameter("@CREATEDBY", SqlDbType.VarChar)
        oParam(3).Value = CType(CREATEDBY, String)

        'oParam(4) = New SqlClient.SqlParameter("@IDX", SqlDbType.VarChar)
        'oParam(4).Value = CType(IDX, String)

        Dim _connectionString As String = _connectionString_AFI
        Return ExecuteNonQuery(_connectionString, const_SP_Update_REASON_INVEST, CommandType.StoredProcedure, oParam)

    End Function

    Public Function f_Edit_COMPLETE_DOCUMENT(ByVal CLAIMNO As String, ByVal POLICYNO As String, ByVal INCOMPLETE_DOCUMENT As String, ByVal CREATEDBY As String) As Integer

        Dim oParam(3) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@CLAIMNO", SqlDbType.VarChar)
        oParam(0).Value = CType(CLAIMNO, String)

        oParam(1) = New SqlClient.SqlParameter("@POLICYNO", SqlDbType.VarChar)
        oParam(1).Value = CType(POLICYNO, String)

        oParam(2) = New SqlClient.SqlParameter("@COMPLETE_DOCUMENT", SqlDbType.VarChar)
        oParam(2).Value = CType(INCOMPLETE_DOCUMENT, String)

        oParam(3) = New SqlClient.SqlParameter("@CREATEDBY", SqlDbType.VarChar)
        oParam(3).Value = CType(CREATEDBY, String)

        'oParam(4) = New SqlClient.SqlParameter("@IDX", SqlDbType.VarChar)
        'oParam(4).Value = CType(IDX, String)

        Dim _connectionString As String = _connectionString_AFI
        Return ExecuteNonQuery(_connectionString, const_SP_Update_COMPLETE_DOCUMENT, CommandType.StoredProcedure, oParam)

    End Function

    Public Function f_Edit_POL_DOCUMENT(ByVal CLAIMNO As String, ByVal POLICYNO As String, ByVal INCOMPLETE_DOCUMENT As String, ByVal CREATEDBY As String, ByVal DATES As Date) As Integer

        Dim oParam(4) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@CLAIMNO", SqlDbType.VarChar)
        oParam(0).Value = CType(CLAIMNO, String)

        oParam(1) = New SqlClient.SqlParameter("@POLICYNO", SqlDbType.VarChar)
        oParam(1).Value = CType(POLICYNO, String)

        oParam(2) = New SqlClient.SqlParameter("@POL_DOCUMENT", SqlDbType.VarChar)
        oParam(2).Value = CType(INCOMPLETE_DOCUMENT, String)

        oParam(3) = New SqlClient.SqlParameter("@CREATEDBY", SqlDbType.VarChar)
        oParam(3).Value = CType(CREATEDBY, String)

        oParam(4) = New SqlClient.SqlParameter("@DATES", SqlDbType.Date)
        oParam(4).Value = CType(DATES, Date)

        Dim _connectionString As String = _connectionString_AFI
        Return ExecuteNonQuery(_connectionString, const_SP_Update_POL_DOCUMENT, CommandType.StoredProcedure, oParam)

    End Function


    Public Function f_Edit_FBA_ADMIN(ByVal CLAIMNO As String, ByVal POLICYNO As String, ByVal CREATEDBY As String) As Integer

        Dim oParam(2) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@CLAIMNO", SqlDbType.VarChar)
        oParam(0).Value = CType(CLAIMNO, String)

        oParam(1) = New SqlClient.SqlParameter("@POLICYNO", SqlDbType.VarChar)
        oParam(1).Value = CType(POLICYNO, String)

        oParam(2) = New SqlClient.SqlParameter("@CREATEDBY", SqlDbType.VarChar)
        oParam(2).Value = CType(CREATEDBY, String)

        'oParam(4) = New SqlClient.SqlParameter("@IDX", SqlDbType.VarChar)
        'oParam(4).Value = CType(IDX, String)

        Dim _connectionString As String = _connectionString_AFI
        Return ExecuteNonQuery(_connectionString, const_SP_Update_FBA_APPROVED_ADMIN, CommandType.StoredProcedure, oParam)

    End Function

    Public Function f_Edit_FBA_FA(ByVal CLAIMNO As String, ByVal POLICYNO As String, ByVal CREATEDBY As String) As Integer

        Dim oParam(2) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@CLAIMNO", SqlDbType.VarChar)
        oParam(0).Value = CType(CLAIMNO, String)

        oParam(1) = New SqlClient.SqlParameter("@POLICYNO", SqlDbType.VarChar)
        oParam(1).Value = CType(POLICYNO, String)

        oParam(2) = New SqlClient.SqlParameter("@CREATEDBY", SqlDbType.VarChar)
        oParam(2).Value = CType(CREATEDBY, String)

        Dim _connectionString As String = _connectionString_AFI
        Return ExecuteNonQuery(_connectionString, const_SP_Update_FBA_APPROVED_FA, CommandType.StoredProcedure, oParam)

    End Function
    Public Function f_Edit_FBA_FA2(ByVal CLAIMNO As String, ByVal POLICYNO As String, ByVal CREATEDBY As String, ByVal IDXFBA As String) As Integer

        Dim oParam(3) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@CLAIMNO", SqlDbType.VarChar)
        oParam(0).Value = CType(CLAIMNO, String)

        oParam(1) = New SqlClient.SqlParameter("@POLICYNO", SqlDbType.VarChar)
        oParam(1).Value = CType(POLICYNO, String)

        oParam(2) = New SqlClient.SqlParameter("@CREATEDBY", SqlDbType.VarChar)
        oParam(2).Value = CType(CREATEDBY, String)

        oParam(3) = New SqlClient.SqlParameter("@IDXFBA", SqlDbType.VarChar)
        oParam(3).Value = CType(IDXFBA, String)

        Dim _connectionString As String = _connectionString_AFI
        Return ExecuteNonQuery(_connectionString, const_SP_Update_FBA_APPROVED_FA_2, CommandType.StoredProcedure, oParam)

    End Function
    Public Function f_Edit_FBA_PAYMENT_SUBMIT(ByVal CLAIMNO As String, ByVal POLICYNO As String, ByVal CREATEDBY As String) As Integer

        Dim oParam(2) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@CLAIMNO", SqlDbType.VarChar)
        oParam(0).Value = CType(CLAIMNO, String)

        oParam(1) = New SqlClient.SqlParameter("@POLICYNO", SqlDbType.VarChar)
        oParam(1).Value = CType(POLICYNO, String)

        oParam(2) = New SqlClient.SqlParameter("@CREATEDBY", SqlDbType.VarChar)
        oParam(2).Value = CType(CREATEDBY, String)

        Dim _connectionString As String = _connectionString_AFI
        Return ExecuteNonQuery(_connectionString, const_SP_Update_FBA_APPROVED_PAYMENT_SUBMIT, CommandType.StoredProcedure, oParam)

    End Function
    Public Function f_Edit_FBA_PAYMENT_SUBMIT2(ByVal CLAIMNO As String, ByVal POLICYNO As String, ByVal CREATEDBY As String, ByVal IDXFBA As String) As Integer

        Dim oParam(3) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@CLAIMNO", SqlDbType.VarChar)
        oParam(0).Value = CType(CLAIMNO, String)

        oParam(1) = New SqlClient.SqlParameter("@POLICYNO", SqlDbType.VarChar)
        oParam(1).Value = CType(POLICYNO, String)

        oParam(2) = New SqlClient.SqlParameter("@CREATEDBY", SqlDbType.VarChar)
        oParam(2).Value = CType(CREATEDBY, String)

        oParam(3) = New SqlClient.SqlParameter("@IDXFBA", SqlDbType.VarChar)
        oParam(3).Value = CType(IDXFBA, String)


        Dim _connectionString As String = _connectionString_AFI
        Return ExecuteNonQuery(_connectionString, const_SP_Update_FBA_APPROVED_PAYMENT_SUBMIT2, CommandType.StoredProcedure, oParam)

    End Function


    Public Function f_Update_Approve_PAYMENT_REPORT(ByVal CLAIMNO As String, ByVal POLICYNO As String, ByVal IDX As String, _
                                                    ByVal ValueDate As Date, ByVal CREATEDBY As String) As Integer

        Dim oParam(4) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@CLAIMNO", SqlDbType.VarChar)
        oParam(0).Value = CType(CLAIMNO, String)

        oParam(1) = New SqlClient.SqlParameter("@POLICYNO", SqlDbType.VarChar)
        oParam(1).Value = CType(POLICYNO, String)

        oParam(2) = New SqlClient.SqlParameter("@CREATEDBY", SqlDbType.VarChar)
        oParam(2).Value = CType(CREATEDBY, String)

        oParam(3) = New SqlClient.SqlParameter("@IDX", SqlDbType.VarChar)
        oParam(3).Value = CType(IDX, String)

        oParam(4) = New SqlClient.SqlParameter("@ValueDate", SqlDbType.Date)
        oParam(4).Value = CType(ValueDate, Date)

        Dim _connectionString As String = _connectionString_AFI
        Return ExecuteNonQuery(_connectionString, const_SP_Update_PAYMENT_REPORT_APPROVED, CommandType.StoredProcedure, oParam)

    End Function

    Public Function f_Update_FLAG_DOWNLOAD_PAYMENT_REPORT(ByVal CLAIMNO As String, ByVal POLICYNO As String, ByVal UPLOADID As String) As Integer

        Dim oParam(2) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@CLAIMNO", SqlDbType.VarChar)
        oParam(0).Value = CType(CLAIMNO, String)

        oParam(1) = New SqlClient.SqlParameter("@POLICYNO", SqlDbType.VarChar)
        oParam(1).Value = CType(POLICYNO, String)

        oParam(2) = New SqlClient.SqlParameter("@UPLOADID", SqlDbType.VarChar)
        oParam(2).Value = CType(UPLOADID, String)


        Dim _connectionString As String = _connectionString_AFI
        Return ExecuteNonQuery(_connectionString, const_SP_Update_PAYMENT_REPORT_FLAG_DOWNLOAD, CommandType.StoredProcedure, oParam)

    End Function


    'Public Function f_Update_RekKoran_Item(ByVal _rowid As Integer, ByVal _PolicyNo As String, ByVal _currency As String, ByVal _amount As Decimal, ByVal _updatedby As String, ByVal _refund As String, ByVal _remarks As String, ByVal _rekkoran As String, ByVal _entity As String, _
    '                                       ByVal _tcCode As Integer, ByVal _RefundAmount As Decimal) As Integer

    '    Dim oParam(9) As SqlParameter

    '    oParam(0) = New SqlClient.SqlParameter("@ROWID", SqlDbType.Int)
    '    oParam(0).Value = CType(_rowid, Integer)

    '    oParam(1) = New SqlClient.SqlParameter("@POLICYNO", SqlDbType.VarChar)
    '    oParam(1).Value = CType(_PolicyNo, String)

    '    oParam(2) = New SqlClient.SqlParameter("@CURRENCY", SqlDbType.VarChar)
    '    oParam(2).Value = CType(_currency, String)

    '    oParam(3) = New SqlClient.SqlParameter("@AMOUNT", SqlDbType.Float)
    '    oParam(3).Value = CType(_amount, Decimal)

    '    oParam(4) = New SqlClient.SqlParameter("@UPDATEDBY", SqlDbType.VarChar)
    '    oParam(4).Value = CType(_updatedby, String)

    '    oParam(5) = New SqlClient.SqlParameter("@REFUND", SqlDbType.VarChar)
    '    oParam(5).Value = CType(_refund, String)

    '    oParam(6) = New SqlClient.SqlParameter("@REMARK", SqlDbType.VarChar)
    '    oParam(6).Value = CType(_remarks, String)

    '    oParam(7) = New SqlClient.SqlParameter("@REKKORAN", SqlDbType.VarChar)
    '    oParam(7).Value = CType(_rekkoran, String)

    '    oParam(8) = New SqlClient.SqlParameter("@TC_CODE", SqlDbType.Int)
    '    oParam(8).Value = CType(_tcCode, Integer)

    '    oParam(9) = New SqlClient.SqlParameter("@REFUND_AMOUNTS", SqlDbType.Float)
    '    oParam(9).Value = CType(_RefundAmount, Decimal)

    '    Dim _connectionString As String = _connectionString_AFI
    '    Return (ExecuteNonQuery(_connectionString, const_sp_UPDATE_REKENINGKORAN_ITEM, CommandType.StoredProcedure, oParam))

    'End Function



    'Public Function f_Update_RekKoran_Item_Settled(ByVal _rowid As Integer, ByVal _remark As String, ByVal _isrefund As String, ByVal _UpdatedBy As String, ByVal _entity As String, _
    '                                               ByVal _tcCode As Integer, ByVal _refAmount As Decimal) As Integer

    '    Dim oParam(5) As SqlParameter

    '    oParam(0) = New SqlClient.SqlParameter("@ROWID", SqlDbType.Int)
    '    oParam(0).Value = CType(_rowid, Integer)

    '    oParam(1) = New SqlClient.SqlParameter("@REMARK", SqlDbType.VarChar)
    '    oParam(1).Value = CType(_remark, String)

    '    oParam(2) = New SqlClient.SqlParameter("@REFUND", SqlDbType.VarChar)
    '    oParam(2).Value = CType(_isrefund, String)

    '    oParam(3) = New SqlClient.SqlParameter("@UPDATED_BY", SqlDbType.VarChar)
    '    oParam(3).Value = CType(_UpdatedBy, String)

    '    oParam(4) = New SqlClient.SqlParameter("@TC_CODE", SqlDbType.VarChar)
    '    oParam(4).Value = CType(_tcCode, Integer)

    '    oParam(5) = New SqlClient.SqlParameter("@REFUND_AMOUNT", SqlDbType.Float)
    '    oParam(5).Value = CType(_refAmount, Decimal)


    '    Dim _connectionString As String = _connectionString_AFI
    '    Return (ExecuteNonQuery(_connectionString, const_sp_UPDATE_REKENINGKORAN_ITEM_SETTLED, CommandType.StoredProcedure, oParam))

    'End Function

    'Public Function f_UpdateDCR_FLAG(ByVal _remark As String, ByVal _uploadid As Integer, ByVal _entity As String) As Integer

    '    Dim oParam(1) As SqlParameter

    '    oParam(0) = New SqlClient.SqlParameter("@REMARK", SqlDbType.VarChar)
    '    oParam(0).Value = CType(_remark, String)

    '    oParam(1) = New SqlClient.SqlParameter("@UPLOADID", SqlDbType.Int)
    '    oParam(1).Value = CType(_uploadid, String)

    '    Dim _connectionString As String = _connectionString_AFI
    '    Return ExecuteNonQuery(_connectionString, const_sp_UPDATE_DCR_FLAG, CommandType.StoredProcedure, oParam)

    'End Function


    'Public Function f_Update_SEQNO(ByVal _Policy As String, ByVal _amount As Decimal, ByVal _SeqNo As String, ByVal _entity As String) As Integer

    '    Dim oParam(2) As SqlParameter

    '    oParam(0) = New SqlClient.SqlParameter("@Policy", SqlDbType.VarChar)
    '    oParam(0).Value = CType(_Policy, String)

    '    oParam(1) = New SqlClient.SqlParameter("@amount", SqlDbType.Float)
    '    oParam(1).Value = CType(_amount, Decimal)

    '    oParam(2) = New SqlClient.SqlParameter("@SEQ_NO", SqlDbType.VarChar)
    '    oParam(2).Value = CType(_SeqNo, String)

    '    Dim _connectionString As String = _connectionString_AFI
    '    Return ExecuteNonQuery(_connectionString, const_sp_UPDATE_SEQ_NUMBER, CommandType.StoredProcedure, oParam)

    'End Function

End Class
