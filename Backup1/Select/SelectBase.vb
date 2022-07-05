Imports System.Configuration
Imports System.Data.SqlClient
Imports AXA.Framework.DataAccess

Public Class SelectBase
    Inherits DataAccessBase

    'Dim _connectionString As String = ConfigurationManager.ConnectionStrings("ConSql").ToString
    Dim _connectionString_AFI As String = ConfigurationManager.ConnectionStrings("ConSql").ToString

#Region "Constanta"
    Dim const_sp_SEL_CASHBEN_DETAIL As String = "SP_SEL_FBA_CASHBACK_BENEFIT"
    Dim const_sp_download_failed_upload As String = "sp_download_failed_upload"
    Dim const_sp_SEL_CheckCriteria_Upload As String = "sp_CheckCriteria_Upload"
    Dim const_sp_SEL_ReasonInves As String = "sp_Sel_TRN_FCR_REASON_INVESTIGATION"
    Dim const_SP_SEL_DETAIL_EMAIL_SENDING As String = "sp_GET_DATA_EMAIL_CLAIM_SUMMARY"
    Dim const_SP_SEL_HISTORY_LOG_FBA As String = "[sp_Sel_HISTORY_LOG_FBA]"
    Dim const_SP_SEL_HISTORY_LOG_EMAIL As String = "[sp_Sel_HISTORY_LOG_EMAIL]"
    Dim const_SP_SEND_EMAIL_CLAIM_SUMMARY = "sp_FORMAT_EMAIL_CLAIM_SUMMARY_DOC"
    Dim const_SP_SEND_EMAIL_DECLINE = "sp_FORMAT_EMAIL_DECLINE_DOC"
    Dim const_SP_SEND_EMAIL_EMPTY = "sp_FORMAT_EMAIL_EMPTY"
    Dim const_SP_FORMAT_EMAIL_BODY = "[sp_FORMAT_EMAIL_BODY]"
    Dim const_SP_FORMAT_EMAIL_BODY2 = "[sp_FORMAT_EMAIL_BODY2]"
    Dim const_SP_SEND_EMAIL_INC_DOC = "sp_FORMAT_EMAIL_INCOMPLETE_DOC"
    Dim const_SP_SEND_EMAIL_PENDING = "sp_FORMAT_EMAIL_PENDING_DOC"
    Dim const_sp_GET_DATE_ADM As String = "sp_GET_DATE_ADM"
    Dim const_sp_SEL_GET_NAME_PLAN As String = "sp_GET_NAME_PLAN"
    Dim const_sp_SEL_MST_FCR_CLAIM_STATUS As String = "sp_SEL_MST_FCR_CLAIM_STATUS"
    Dim const_sp_SEL_GET_DAYS As String = "sp_SEL_GET_DAYS_SMS"
    Dim const_sp_SEL_MST_FCR_REASON_INVESTIGATION As String = "sp_SEL_MST_REASON_INVESTIGATION"
    Dim const_sp_SEL_FBA_ACTUAL_PLAN As String = "sp_SEL_TRN_FBA_ACTUAL_PLAN"
    Dim const_sp_SEL_SUM_FBA_CASHBACK_BENEFIT As String = "sp_SEL_SUM_FBA_CASHBACK_BENEFIT"
    Dim const_sp_SEL_MST_TYPE_FBA_HEADER As String = "sp_SEL_MST_TYPE_FBA_HEADER"
    Dim const_sp_SEL_FBACASHBACK_BENEFIT As String = "sp_SEL_FBACASHBACK_BENEFIT"
    Dim const_sp_SEL_MST_TYPE_FBA_DETAIL As String = "sp_SEL_MST_TYPE_FBA_DETAIL"
    Dim const_sp_Count_FBA As String = "sp_Count_FBA"
    Dim const_SEL_IDX_FCR As String = "sp_SEL_IDX_FCR"
    Dim const_SEL_FCR_FROM_GRIDVIEW As String = "sp_SEL_FCR_FROM_GRIDVIEW"
    Dim const_SEL_FBA_FROM_GRIDVIEW As String = "sp_SEL_FBA_FROM_GRIDVIEW"
    Dim const_sp_SEL_FBA_GRIDVIEW As String = "sp_SEL_GRIDVIEW_FBA"
    Dim const_sp_SEL_DETAIL_EMAIL As String = "sp_SEL_DETAIL_EMAIL"
    Dim const_sp_Sel_EXC_RATE As String = "sp_SEL_EXCH_RATE"
    Dim const_sp_SEL_OBT_REPORT As String = "sp_SEL_OBT"
    Dim const_sp_SEL_NONMED_REPORT As String = "sp_SEL_NON_MED"
    Dim const_sp_InsertLogin As String = "sp_INSERT_LOGIN"
    Dim const_sp_Sel_Dept As String = "sp_SEL_DEPT"
    Dim const_sp_Sel_APPROVED_LETTER As String = "[sp_SEL_approved_LETTER]"
    Dim const_sp_Sel_List As String = "sp_SEL_TodoList"
    Dim const_sp_Sel_List_Load As String = "sp_SEL_TodoList_Load"
    Dim const_sp_InsertUploadFile As String = "sp_INSERT_UPLOADFILE"
    Dim const_sp_Sel_Borderaux As String = "sp_SEL_BORDERAUX"
    Dim const_sp_Sel_Borderaux_Cloning As String = "sp_SEL_BORDERAUX_CLONING"
    Dim const_sp_Sel_Borderaux_all As String = "sp_Sel_BORDERAUX_ALL"
    Dim const_sp_Sel_Borderaux_Claim As String = "sp_Sel_BORDERAUX_Claim"
    Dim const_sp_Sel_Borderaux_Claim_LETTER As String = "sp_Sel_BORDERAUX_CLAIM_LETTER"
    Dim const_sp_Sel_Borderaux_DETAIL As String = "sp_SEL_BORDERAUX_DETAIL"
    Dim const_sp_Sel_Borderaux_DETAIL1 As String = "sp_SEL_FBA_DETAIL1"
    Dim const_sp_Sel_FBA_FROM_FCR As String = "sp_SEL_FBA_DETAIL_FROM_FCR"
    Dim const_sp_Sel_FBA_FROM_FCR2 As String = "sp_SEL_FBA_DETAIL_FROM_FCR2"
    Dim const_sp_Sel_CHECK_FBA As String = "sp_CHECK_FBA"
    Dim const_sp_Sel_Borderaux_DETAIL2 As String = "sp_SEL_FBA_DETAIL2"
    Dim const_sp_Sel_Borderaux_DETAIL3 As String = "sp_SEL_FBA_DETAIL3"
    Dim const_sp_Sel_Borderaux_DETAIL4 As String = "sp_SEL_FBA_DETAIL4"
    Dim const_sp_Sel_CLAIM_SUMMARY_LETTER_LIST As String = "[sp_SEL_CLAIM_SUMMARR_LETTER_LIST]"
    Dim const_sp_Sel_CHECK_DEPARTMENT As String = "sp_CHECK_DEPARTMNET"
    Dim const_sp_Sel_COORPORATECODE As String = "sp_SEL_COORPORATECODE"
    Dim const_sp_Sel_Email_Send As String = "sp_SEL_EMAIL_SEND"
    Dim const_sp_SEL_MST_CLAIM_STATUS As String = "sp_SEL_MST_CLAIM_STATUS"

    Dim const_sp_Sel_FCR_EMAIL_SMS As String = "[sp_SEL_FCR_EMAIL_SMS]"
    Dim const_sp_Sel_MST_CURR_BI As String = "sp_SEL_MST_CURR_BI"
    Dim const_sp_Sel_MST_CURR_BM As String = "sp_SEL_MST_CURR_BM"
    Dim const_sp_Sel_CURR_BI As String = "Sel_CURR_BI"
    Dim const_sp_Sel_CURR_BM As String = "Sel_CURR_BM"
    Dim const_sp_Sel_CURR_BM_DETAIL As String = "Sel_CURR_BM_DETAIL"
    Dim const_sp_Sel_CURR_BI_DETAIL As String = "Sel_CURR_BI_DETAIL"



    Dim const_sp_Sel_FCR_DETAIL_PENDING As String = "sp_SEL_FCR_DETAIL_PENDING"
    Dim const_sp_Sel_FCR_DETAIL_PENDING_NEW As String = "sp_SEL_FCR_DETAIL_PENDING_NEW"
    Dim const_sp_Sel_FCR As String = "sp_SEL_FCR"
    Dim const_sp_Sel_FCR_LIST As String = "sp_SEL_FCR_LIST"
    Dim const_sp_Sel_FCR_SMS As String = "sp_SEL_FCR_SMS"
    Dim const_sp_Sel_FCR_PRODUCT As String = "sp_SEL_FCR_PRODUCT"
    Dim const_sp_Sel_FCR_PENDING As String = "sp_SEL_FCR_PENDING"
    Dim const_sp_Sel_FCR_Detail As String = "sp_SEL_FCR_DETAIL"
    Dim const_sp_Sel_FCR_ALL As String = "sp_SEL_FCR_ALL"
    Dim const_sp_Sel_LIFE_CYCLE As String = "sp_SEL_LIFE_CYCLE"
    Dim const_sp_Sel_LIFE_CYCLE_DETAIL As String = "[sp_SEL_LIFE_CYCLE_DETAIL]"
    Dim const_sp_Sel_MST_INCOMPLETE_DOC As String = "sp_SEL_INC_DOC"
    Dim const_sp_Sel_MST_COMPLETE_DOC As String = "[sp_SEL_COMPLETE_DOC]"
    Dim const_sp_Sel_MST_FCR_TASKS As String = "sp_SEL_FCR_TASKS"
    Dim const_sp_Sel_MST_PRODUCT As String = "sp_SEL_MST_PRODUCT"
    Dim const_sp_Sel_INCOMPLETE_DOC As String = "[sp_Sel_TRN_FCR_incomplete_document]"
    Dim const_sp_Sel_COMPLETE_DOC As String = "[sp_Sel_TRN_FCR_COMPLETE_document]"
    Dim const_sp_Sel_POL_DOC As String = "[sp_Sel_TRN_FCR_POL_document]"
    Dim const_sp_Sel_EnrollMent_List As String = "[sp_Sel_EnrollMent_List]"
    Dim const_sp_Sel_EnrollMent_ALL As String = "sp_Sel_EnrollMent_ALL"

    Dim const_sp_Sel_FBA_LIST As String = "[sp_Sel_TRN_FBA]"
    Dim cont_sp_sel_count_payment As String = "[sp_SEL_COUNT_PAYMENT]"
    Dim const_sp_Sel_FBA_DETAIL As String = "sp_SEL_TRN_FBA_DETAIL"
    Dim const_sp_Sel_FBA_DETAIL2 As String = "sp_SEL_TRN_FBA_DETAIL2"
    Dim const_sp_Sel_FBA_DETAIL3 As String = "sp_SEL_TRN_FBA_DETAIL3"
    Dim const_sp_Sel_FCR_APPROVED As String = "sp_SEL_FCR_APPROVED"
    Dim const_sp_Sel_FCR_APPROVED_DETAIL As String = "[sp_SEL_FCR_APPROVED_DETAIL_FOR_FBA]"
    Dim const_sp_Sel_FBANONMED As String = "[sp_SEL_FBA_NON_MED]"
    Dim const_sp_Sel_FBANONMED2 As String = "[sp_SEL_FBA_NON_MED2]"
    Dim const_sp_Sel_FBAOBT As String = "[sp_SEL_FBA_OBT]"
    Dim const_sp_Sel_FBAOBT2 As String = "[sp_SEL_FBA_OBT2]"
    Dim const_sp_Sel_HOSPITAL As String = "sp_SEL_HOSPITAL"
    Dim const_sp_Sel_HOSPITAL_ROOM_TYPE As String = "sp_SEL_HOSPITAL_TYPE"
    Dim const_sp_Sel_UPGRADE_COST_SHARE As String = "sp_SEL_MST_UPGRADE_SHARE"
    Dim const_sp_Sel_FBA_DETAIL_LIST As String = "sp_SEL_FBA_DETAIL"
    Dim const_sp_Sel_FBA_DETAIL_LIST2 As String = "sp_SEL_FBA_DETAIL_2B"
    Dim const_sp_Sel_PAYMENT_REPORT_INS As String = "[sp_Sel_TRN_FBA_APPROVED]"
    Dim const_sp_Sel_PAYMENT_REPORT_EDIT As String = "[sp_Sel_TRN_FBA_APPROVED_EDIT]"
    Dim const_sp_Sel_PAYMENT_REPORT As String = "[sp_Sel_PAYMENT_REPORT]"
    Dim const_sp_Sel_PAYMENT_REPORT_DOWNLOAD As String = "[sp_Sel_TRN_PAYMENT_REPORT_DOWNLOAD]"
    Dim const_sp_Sel_DOWNLOAD_PAYMENT_REPORT As String = "[sp_DOWNLOAD_PAYMENT_REPORT]"
    Dim const_sp_Sel_DOWNLOAD_PAYMENT_REPORT_FOR_UPDATE As String = "[sp_DOWNLOAD_PAYMENT_REPORT_FOR_UPDATE]"
    Dim const_sp_Sel_DOWNLOAD_PAYMENT_REPORT_FOR_UPDATE_2 As String = "[sp_DOWNLOAD_PAYMENT_REPORT_FOR_UPDATE_2]"
    Dim const_sp_Sel_DOWNLOAD_PAYMENT_REPORT2 As String = "[sp_DOWNLOAD_PAYMENT_REPORT2]"
    Dim const_sp_Sel_DOWNLOAD_PAYMENT_REPORT3 As String = "sp_DOWNLOAD_PAYMENT_REPORT3"
    Dim const_sp_Sel_DOWNLOAD_PENDING_LETTER As String = "sp_DOWNLOAD_PENDING_LETTER"
    Dim const_sp_Sel_DOWNLOAD_PENDING_LETTER_EXPORT As String = "sp_DOWNLOAD_PENDING_LETTER_EXPORT"
    Dim const_sp_Sel_REQUEST_LETTER_DRAFT As String = "sp_SEL_REQUEST_LETTTER_DRAFT"
    Dim const_sp_Sel_REQUEST_LETTER_DRAFT_LIST As String = "sp_SEL_REQUEST_LETTER_LIST"
    Dim const_sp_Sel_MASTER_CURRENCY As String = "sp_Sel_MASTER_CURRENCY"
    Dim const_sp_SEL_SUM_INELIG_AMOUNT As String = "sp_SEL_SUM_INELIG_AMOUNT"
    Dim const_sp_Sel_CURRENCY As String = "sp_SEL_CURRENCY"
    Dim const_sp_Sel_PAYMENTDETAILS3 As String = "sp_SEL_PAYMENTDETAILS3"
    Dim const_sp_Sel_SMSTYPE As String = "sp_SEL_SMS_TYPE"
    Dim const_sp_SEL_SMS As String = "sp_SEL_SMS"
    Dim const_sp_SEL_SMS_DOWNLOAD As String = "sp_SEL_SMS_DOWNLOAD"
    Dim const_sp_SEL_SMS_DOWNLOAD2 As String = "sp_SEL_SMS_DOWNLOAD2"
    Dim const_sp_SEL_SMS_COUNT As String = "sp_SEL_SMS_COUNT"
    Dim const_sp_SEL_SMS_VALUE_TYPE As String = "sp_sel_SMS_VALUE_TYPE"
    Dim const_sp_SEL_SMS_LETTER As String = "sp_SEL_SMS_LETTER"
    Dim const_sp_SEL_TRN_SMS As String = "sp_SEL_TRN_SMS"
    Dim const_sp_SEL_ESCALATION_LETTER As String = "sp_SEL_ESCALATION_LETTER"
    Dim const_sp_SEL_ESCALATION_LETTER_DETAIL As String = "[sp_SEL_ESCALATION_LETTER_DETAIL]"
    Dim const_sp_SEL_MST_CLAIM_SUMMARY_LETTER As String = "[sp_SEL_MST_CLAIM_SUMMARY_LETTER]"
    Dim const_sp_SEL_DOWNLOAD_CLAIM_SUMMARY_LETTER As String = "sp_DOWNLOAD_CLAIM_SUMMARY_LETTER_EXPORT"
    Dim const_sp_SEL_TRN_DASHBOARD As String = "sp_SEL_TRN_DASHBOARD"
    Dim const_sp_SEL_TRN_DASHBOARD_APPROVED As String = "[sp_TRN_DASHBOARD_APPROVED_GRAPH]"
    Dim const_sp_SEL_TRN_DASHBOARD_CLOSING As String = "sp_TRN_DASHBOARD_CLOSING_GRAPH"
    Dim const_sp_SEL_TRN_DASHBOARD_PENDING As String = "sp_TRN_DASHBOARD_PENDING_GRAPH"
    Dim const_sp_SEL_TRN_DASHBOARD_DECLINED As String = "sp_TRN_DASHBOARD_DECLINED_GRAPH"
    Dim const_sp_SEL_TRN_CASE_FOLLOW_UP As String = "sp_SEL_CASE_FOLLOWUP"
    Dim const_sp_SEL_ME_LETTER As String = "[sp_SEL_ME_LETTER]"
    Dim const_sp_SEL_ME_LETTER_LIST As String = "[sp_SEL_ME_LETTER_LIST]"

    Dim const_sp_Sel_MST_POLICY_FCR As String = "[sp_SEL_MST_POLICY_FCR]"

    Dim const_sp_Sel_MST_CURRENCY As String = "sp_SEL_MST_CURRENCY"

    Dim const_sp_Sel_RekeningKoran As String = "sp_SEL_REKENINGKORAN"
    Dim const_sp_Sel_RekeningKoranItem As String = "sp_SEL_REKENINGKORAN_ITEM"

    Dim const_sp_Sel_DCRReport As String = "sp_DCR_REPORT"
    Dim const_sp_Sel_DCRReport_Failed As String = "sp_DCR_REPORT_FAILED"
    Dim const_sp_CHECK_CRITERIA As String = "sp_CHECK_CRITERIA"
    Dim const_sp_CHECK_CRITERIA_FAILED As String = "sp_CHECK_CRITERIA_FAILED"
    Dim const_sp_CHECK_BALANCE As String = "sp_CHECK_BALANCE"
    Dim const_sp_CHECK_AMOUNT As String = "sp_CHECK_AMOUNT"
    Dim const_sp_SEL_ACCT As String = "sp_SEL_ACCT"
    Dim const_sp_CHECK_DOUBLE_DATA_BSM As String = "sp_check_double_data_AMFS_BSM"
    Dim const_sp_CHECK_DOUBLE_DATA_MCM As String = "sp_check_double_data_AMFS_MCM"
    Dim const_sp_CHECK_DOUBLE_DATA_Upload As String = "sp_check_double_data_Upload_Seq"
    Dim const_sp_CHECK_MENU As String = "sp_check_Menu_MASTER"
    Dim const_sp_CHECK_MENUS As String = "sp_check_Menu"
    Dim const_sp_CHECK_MENU_NAME_MASTER As String = "sp_check_Menu_name"
    Dim const_sp_CHECK_PREFIX_POLICY As String = "sp_check_prefix"
    Dim const_sp_BALANCE_RK As String = "sp_BALANCE_REJECT"
    Dim const_sp_CHECK_UPLOAD_FILE As String = "sp_CHECK_UPLOAD"
    Dim const_sp_CHECK_CURR_BSM As String = "sp_CHECK_CURR_AMFS"
    Dim const_sp_CHECK_UPLOAD_FILE_DOUBLE_PAYMENT As String = "sp_CHECK_UPLOAD_PAYMENT"
    Dim const_sp_CHECK_STATUS_REK_KORAN As String = "sp_Sel_STATUS"
    Dim const_sp_SEL_FAILED_FILE As String = "sp_Sel_FAILED_FILE"
    Dim const_sp_CHECK_CURR_BSM_by_RekKoran As String = "sp_CHECK_CURR_AMFS_by_RekKoran"
    Dim const_sp_Sel_DCRReport_FAILED_AFI As String = "sp_DCR_REPORT_FAILED_AFI"
    Dim const_sp_Sel_DetailRek_Koran As String = "sp_Detail_rekKoran"
    Dim const_sp_CHECK_POLICY As String = "sp_Check_Policy"
    Dim const_sp_CHECK_DATE_POLICY As String = "sp_Check_Date_Policy"
    Dim const_sp_CHECK_CURRENCY_AFI As String = "sp_Check_CURRENCY_AFI"
    Dim const_sp_CHECK_AMOUNT_RK As String = "sp_Check_AMOUNT_RK"
    Dim const_sp_CHECK_CRITERIA_UPLOAD_WORKSITE As String = "sp_Check_CRITERIA_UPLOAD_WORKSITE"
    Dim const_sp_Sel_DCRReport_Failed_DCR As String = "sp_DCR_REPORT_FAILED_AFI"
#End Region

    Public Function f_SEL_SMS(ByVal CLAIMNO As String, ByVal POLICYNO As String, _
                                   ByVal FLAGCLAIMNO As String, ByVal FLAGPOLICYNO As String, _
                                   ByVal SMSVALUE As String, ByVal SMSTYPE As String, _
                                   ByVal CREATEDDATEFROM As Date, ByVal CREATEDDATETO As Date, _
                                   ByVal FLAGSMSValue As String, ByVal FLAGSMSTYPE As String, _
                                   ByVal FLAGCREATEDDATE As String, ByVal ENTITY As String, _
                                   ByVal MOBILENO As String, ByVal FLAGMOBILENO As String, _
                                   ByVal CORCODE As String, ByVal FLAGCORCODE As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(15) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@CLAIMNO", SqlDbType.VarChar)
        oParam(0).Value = CType(CLAIMNO, String)

        oParam(1) = New SqlClient.SqlParameter("@POLICYNO", SqlDbType.VarChar)
        oParam(1).Value = CType(POLICYNO, String)

        oParam(2) = New SqlClient.SqlParameter("@FLAGCLAIMNO", SqlDbType.VarChar)
        oParam(2).Value = CType(FLAGCLAIMNO, String)

        oParam(3) = New SqlClient.SqlParameter("@FLAGPOLICYNO", SqlDbType.VarChar)
        oParam(3).Value = CType(FLAGPOLICYNO, String)

        oParam(4) = New SqlClient.SqlParameter("@SMSVALUE", SqlDbType.VarChar)
        oParam(4).Value = CType(SMSVALUE, String)

        oParam(5) = New SqlClient.SqlParameter("@SMSTYPE", SqlDbType.VarChar)
        oParam(5).Value = CType(SMSTYPE, String)

        oParam(6) = New SqlClient.SqlParameter("@CREATEDDATEFROM", SqlDbType.Date)
        oParam(6).Value = CType(CREATEDDATEFROM, Date)

        oParam(7) = New SqlClient.SqlParameter("@CREATEDDATETO", SqlDbType.Date)
        oParam(7).Value = CType(CREATEDDATETO, Date)

        oParam(8) = New SqlClient.SqlParameter("@FLAGSMSValue", SqlDbType.VarChar)
        oParam(8).Value = CType(FLAGSMSValue, String)

        oParam(9) = New SqlClient.SqlParameter("@FLAGSMSTYPE", SqlDbType.VarChar)
        oParam(9).Value = CType(FLAGSMSTYPE, String)

        oParam(10) = New SqlClient.SqlParameter("@FLAGCREATEDDATE", SqlDbType.VarChar)
        oParam(10).Value = CType(FLAGCREATEDDATE, String)

        oParam(11) = New SqlClient.SqlParameter("@ENTITY", SqlDbType.VarChar)
        oParam(11).Value = CType(ENTITY, String)

        oParam(12) = New SqlClient.SqlParameter("@MOBILENO", SqlDbType.VarChar)
        oParam(12).Value = CType(MOBILENO, String)

        oParam(13) = New SqlClient.SqlParameter("@FLAGMOBILENO", SqlDbType.VarChar)
        oParam(13).Value = CType(FLAGMOBILENO, String)

        oParam(14) = New SqlClient.SqlParameter("@CORCODE", SqlDbType.VarChar)
        oParam(14).Value = CType(CORCODE, String)

        oParam(15) = New SqlClient.SqlParameter("@FLAGCORCODE", SqlDbType.VarChar)
        oParam(15).Value = CType(FLAGCORCODE, String)




        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_SEL_SMS, CommandType.StoredProcedure, oParam)

        Return dt

    End Function
    Public Function f_SEL_APPROVED_LETTER(ByVal CLAIMNO As String, ByVal POLICYNO As String, _
                                   ByVal FLAGCLAIMNO As String, ByVal FLAGPOLICYNO As String, _
                                   ByVal FLAGPAYDETAILS As String, ByVal PAYDETAILS As String)
        Dim dt As New DataTable
        Dim oParam(5) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@CLAIMNO", SqlDbType.VarChar)
        oParam(0).Value = CType(CLAIMNO, String)

        oParam(1) = New SqlClient.SqlParameter("@POLICYNO", SqlDbType.VarChar)
        oParam(1).Value = CType(POLICYNO, String)

        oParam(2) = New SqlClient.SqlParameter("@FLAGCLAIMNO", SqlDbType.VarChar)
        oParam(2).Value = CType(FLAGCLAIMNO, String)

        oParam(3) = New SqlClient.SqlParameter("@FLAGPOLICYNO", SqlDbType.VarChar)
        oParam(3).Value = CType(FLAGPOLICYNO, String)

        oParam(4) = New SqlClient.SqlParameter("@FLAGPAYDETAILS", SqlDbType.VarChar)
        oParam(4).Value = CType(FLAGPAYDETAILS, String)

        oParam(5) = New SqlClient.SqlParameter("@PAYDETAILS", SqlDbType.VarChar)
        oParam(5).Value = CType(PAYDETAILS, String)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Sel_APPROVED_LETTER, CommandType.StoredProcedure, oParam)

        Return dt
    End Function
    Public Function f_SEL_HISTORY_LOG_FBA(ByVal CLAIMNO As String, ByVal POLICYNO As String, _
                                  ByVal FLAGCLAIMNO As String, ByVal FLAGPOLICYNO As String, _
                                  ByVal FLAGPAYMENTDETAILS As String, ByVal PAYMENTDETAILS As String, ByVal STATUS As String, _
                                  ByVal FBADETAIL As String, ByVal FLAGFBADETAIL As String)
        Dim dt As New DataTable
        Dim oParam(8) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@CLAIMNO", SqlDbType.VarChar)
        oParam(0).Value = CType(CLAIMNO, String)

        oParam(1) = New SqlClient.SqlParameter("@POLICYNO", SqlDbType.VarChar)
        oParam(1).Value = CType(POLICYNO, String)

        oParam(2) = New SqlClient.SqlParameter("@FLAGCLAIMNO", SqlDbType.VarChar)
        oParam(2).Value = CType(FLAGCLAIMNO, String)

        oParam(3) = New SqlClient.SqlParameter("@FLAGPOLICYNO", SqlDbType.VarChar)
        oParam(3).Value = CType(FLAGPOLICYNO, String)

        oParam(4) = New SqlClient.SqlParameter("@FLAGPAYMENTDETAILS", SqlDbType.VarChar)
        oParam(4).Value = CType(FLAGPAYMENTDETAILS, String)

        oParam(5) = New SqlClient.SqlParameter("@PAYMENTDETAILS", SqlDbType.VarChar)
        oParam(5).Value = CType(PAYMENTDETAILS, String)

        oParam(6) = New SqlClient.SqlParameter("@STATUS", SqlDbType.VarChar)
        oParam(6).Value = CType(STATUS, String)

        oParam(7) = New SqlClient.SqlParameter("@FBADETAIL", SqlDbType.VarChar)
        oParam(7).Value = CType(FBADETAIL, String)

        oParam(8) = New SqlClient.SqlParameter("@FLAGFBADETAIL", SqlDbType.VarChar)
        oParam(8).Value = CType(FLAGFBADETAIL, String)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_SP_SEL_HISTORY_LOG_FBA, CommandType.StoredProcedure, oParam)

        Return dt
    End Function

    Public Function f_SEL_HISTORY_LOG_EMAIL(ByVal CLAIMNO As String, ByVal POLICYNO As String, _
                                            ByVal STATUSFBA As String, ByVal FBADETAIL As String, _
                                            ByVal STATUSFCR As String, ByVal TO_EMAIL As String, _
                                            ByVal CC_EMAIL As String, ByVal BCC_EMAIL As String, _
                                            ByVal DESCEMAIL As String, _
                                            ByVal FLAGCLAIMNO As String, ByVal FLAGPOLICYNO As String, _
                                            ByVal FLAGSTATUSFBA As String, ByVal FLAGFBADETAIL As String, _
                                            ByVal FLAGSTATUSFCR As String, ByVal FLAGTO_EMAIL As String, _
                                            ByVal FLAGCC_EMAIL As String, ByVal FLAGBCC_EMAIL As String, _
                                            ByVal FLAGDESCEMAIL As String)
        Dim dt As New DataTable
        Dim oParam(17) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@CLAIMNO", SqlDbType.VarChar)
        oParam(0).Value = CType(CLAIMNO, String)

        oParam(1) = New SqlClient.SqlParameter("@POLICYNO", SqlDbType.VarChar)
        oParam(1).Value = CType(POLICYNO, String)

        oParam(2) = New SqlClient.SqlParameter("@STATUSFBA", SqlDbType.VarChar)
        oParam(2).Value = CType(STATUSFBA, String)

        oParam(3) = New SqlClient.SqlParameter("@FBADETAIL", SqlDbType.VarChar)
        oParam(3).Value = CType(FBADETAIL, String)

        oParam(4) = New SqlClient.SqlParameter("@STATUSFCR", SqlDbType.VarChar)
        oParam(4).Value = CType(STATUSFCR, String)

        oParam(5) = New SqlClient.SqlParameter("@TO_EMAIL", SqlDbType.VarChar)
        oParam(5).Value = CType(TO_EMAIL, String)

        oParam(6) = New SqlClient.SqlParameter("@CC_EMAIL", SqlDbType.VarChar)
        oParam(6).Value = CType(CC_EMAIL, String)

        oParam(7) = New SqlClient.SqlParameter("@BCC_EMAIL", SqlDbType.VarChar)
        oParam(7).Value = CType(BCC_EMAIL, String)

        oParam(8) = New SqlClient.SqlParameter("@FLAGCLAIMNO", SqlDbType.VarChar)
        oParam(8).Value = CType(FLAGCLAIMNO, String)

        oParam(9) = New SqlClient.SqlParameter("@FLAGPOLICYNO", SqlDbType.VarChar)
        oParam(9).Value = CType(FLAGPOLICYNO, String)

        oParam(10) = New SqlClient.SqlParameter("@FLAGSTATUSFBA", SqlDbType.VarChar)
        oParam(10).Value = CType(FLAGSTATUSFBA, String)

        oParam(11) = New SqlClient.SqlParameter("@FLAGFBADETAIL", SqlDbType.VarChar)
        oParam(11).Value = CType(FLAGFBADETAIL, String)

        oParam(12) = New SqlClient.SqlParameter("@FLAGSTATUSFCR", SqlDbType.VarChar)
        oParam(12).Value = CType(FLAGSTATUSFCR, String)

        oParam(13) = New SqlClient.SqlParameter("@FLAGTO_EMAIL", SqlDbType.VarChar)
        oParam(13).Value = CType(FLAGTO_EMAIL, String)

        oParam(14) = New SqlClient.SqlParameter("@FLAGCC_EMAIL", SqlDbType.VarChar)
        oParam(14).Value = CType(FLAGCC_EMAIL, String)

        oParam(15) = New SqlClient.SqlParameter("@FLAGBCC_EMAIL", SqlDbType.VarChar)
        oParam(15).Value = CType(FLAGBCC_EMAIL, String)

        oParam(16) = New SqlClient.SqlParameter("@DESCEMAIL", SqlDbType.VarChar)
        oParam(16).Value = CType(DESCEMAIL, String)

        oParam(17) = New SqlClient.SqlParameter("@FLAGDESCEMAIL", SqlDbType.VarChar)
        oParam(17).Value = CType(FLAGDESCEMAIL, String)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_SP_SEL_HISTORY_LOG_EMAIL, CommandType.StoredProcedure, oParam)

        Return dt
    End Function


    Public Function f_Sel_EMAIL_SEND(ByVal CLAIMNO As String, ByVal POLICYNO As String, _
                                   ByVal FLAGCLAIMNO As String, ByVal FLAGPOLICYNO As String, _
                                   ByVal EMAILADDRS As String, ByVal FLAGEMAILADDRESS As String, _
                                   ByVal NAMEOFINSURED As String, ByVal FLAGNAMEOFINSURED As String, _
                                   ByVal NAMEOFPOLICY As String, ByVal FLAGNAMEOFPOLICY As String)
        Dim dt As New DataTable
        Dim oParam(9) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@CLAIMNO", SqlDbType.VarChar)
        oParam(0).Value = CType(CLAIMNO, String)

        oParam(1) = New SqlClient.SqlParameter("@POLICYNO", SqlDbType.VarChar)
        oParam(1).Value = CType(POLICYNO, String)

        oParam(2) = New SqlClient.SqlParameter("@FLAGCLAIMNO", SqlDbType.VarChar)
        oParam(2).Value = CType(FLAGCLAIMNO, String)

        oParam(3) = New SqlClient.SqlParameter("@FLAGPOLICYNO", SqlDbType.VarChar)
        oParam(3).Value = CType(FLAGPOLICYNO, String)

        oParam(4) = New SqlClient.SqlParameter("@EMAILADDRS", SqlDbType.VarChar)
        oParam(4).Value = CType(EMAILADDRS, String)

        oParam(5) = New SqlClient.SqlParameter("@FLAGEMAILADDRESS", SqlDbType.VarChar)
        oParam(5).Value = CType(FLAGEMAILADDRESS, String)

        oParam(6) = New SqlClient.SqlParameter("@NAMEOFINSURED", SqlDbType.VarChar)
        oParam(6).Value = CType(NAMEOFINSURED, String)

        oParam(7) = New SqlClient.SqlParameter("@FLAGNAMEOFINSURED", SqlDbType.VarChar)
        oParam(7).Value = CType(FLAGNAMEOFINSURED, String)

        oParam(8) = New SqlClient.SqlParameter("@NAMEOFPOLICY", SqlDbType.VarChar)
        oParam(8).Value = CType(NAMEOFPOLICY, String)

        oParam(9) = New SqlClient.SqlParameter("@FLAGNAMEOFPOLICY", SqlDbType.VarChar)
        oParam(9).Value = CType(FLAGNAMEOFPOLICY, String)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Sel_Email_Send, CommandType.StoredProcedure, oParam)

        Return dt
    End Function


    Public Function f_SEL_FCR_EMAIL_SMS(ByVal CLAIMNO As String, ByVal POLICYNO As String, _
                               ByVal CREATEDBY As String)
        Dim dt As New DataTable
        Dim oParam(2) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@CLAIMNO", SqlDbType.VarChar)
        oParam(0).Value = CType(CLAIMNO, String)

        oParam(1) = New SqlClient.SqlParameter("@POLICYNO", SqlDbType.VarChar)
        oParam(1).Value = CType(POLICYNO, String)

        oParam(2) = New SqlClient.SqlParameter("@CREATEDBY", SqlDbType.VarChar)
        oParam(2).Value = CType(CREATEDBY, String)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Sel_FCR_EMAIL_SMS, CommandType.StoredProcedure, oParam)

        Return dt
    End Function
    Public Function f_SEL_BodyEmail(ByVal LBLNAMATERTANGGUNG As String, ByVal LBLPT As String, _
                              ByVal LBLSTATUSFCRFBA As String, ByVal LBLTLPPT As String, _
                              ByVal LBLFAXPT As String, ByVal LBLEMAILPT As String, _
                              ByVal ddlGroup As String, ByVal Bahasa As String, _
                              ByVal txtPTAGII As String, ByVal lblCorCode As String, _
                              ByVal ddlPraotorisasi As String)
        Dim dt As New DataTable
        Dim oParam(10) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@LBLNAMATERTANGGUNG", SqlDbType.VarChar)
        oParam(0).Value = CType(LBLNAMATERTANGGUNG, String)

        oParam(1) = New SqlClient.SqlParameter("@LBLPT", SqlDbType.VarChar)
        oParam(1).Value = CType(LBLPT, String)

        oParam(2) = New SqlClient.SqlParameter("@LBLSTATUSFCRFBA", SqlDbType.VarChar)
        oParam(2).Value = CType(LBLSTATUSFCRFBA, String)

        oParam(3) = New SqlClient.SqlParameter("@LBLTLPPT", SqlDbType.VarChar)
        oParam(3).Value = CType(LBLTLPPT, String)

        oParam(4) = New SqlClient.SqlParameter("@LBLFAXPT", SqlDbType.VarChar)
        oParam(4).Value = CType(LBLFAXPT, String)

        oParam(5) = New SqlClient.SqlParameter("@LBLEMAILPT", SqlDbType.VarChar)
        oParam(5).Value = CType(LBLEMAILPT, String)

        oParam(6) = New SqlClient.SqlParameter("@ddlGroup", SqlDbType.VarChar)
        oParam(6).Value = CType(ddlGroup, String)

        oParam(7) = New SqlClient.SqlParameter("@Bahasa", SqlDbType.VarChar)
        oParam(7).Value = CType(Bahasa, String)

        oParam(8) = New SqlClient.SqlParameter("@txtPTAGII", SqlDbType.VarChar)
        oParam(8).Value = CType(txtPTAGII, String)

        oParam(9) = New SqlClient.SqlParameter("@lblCorCode", SqlDbType.VarChar)
        oParam(9).Value = CType(lblCorCode, String)

        oParam(10) = New SqlClient.SqlParameter("@ddlPraotorisasi", SqlDbType.VarChar)
        oParam(10).Value = CType(ddlPraotorisasi, String)


        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_SP_FORMAT_EMAIL_BODY, CommandType.StoredProcedure, oParam)

        Return dt
    End Function
    Public Function f_SEL_BodyEmail2(ByVal LBLNAMATERTANGGUNG As String, ByVal LBLPT As String, _
                              ByVal LBLSTATUSFCRFBA As String, ByVal LBLTLPPT As String, _
                              ByVal LBLFAXPT As String, ByVal LBLEMAILPT As String, _
                              ByVal ddlGroup As String, ByVal Bahasa As String, _
                              ByVal txtPTAGII As String, ByVal lblCorCode As String, _
                              ByVal ddlPraotorisasi As String, ByVal ToEmail As String, _
                              ByVal AgentEmail As String, ByVal BCCEmail As String, ByVal FileName As String, _
                              ByVal CreatedBy As String, ByVal CLAIMNO As String, ByVal POLICYNO As String, _
                              ByVal IDXFBA As String, ByVal IDXFCR As String)
        Dim dt As New DataTable
        Dim oParam(19) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@LBLNAMATERTANGGUNG", SqlDbType.VarChar)
        oParam(0).Value = CType(LBLNAMATERTANGGUNG, String)

        oParam(1) = New SqlClient.SqlParameter("@LBLPT", SqlDbType.VarChar)
        oParam(1).Value = CType(LBLPT, String)

        oParam(2) = New SqlClient.SqlParameter("@LBLSTATUSFCRFBA", SqlDbType.VarChar)
        oParam(2).Value = CType(LBLSTATUSFCRFBA, String)

        oParam(3) = New SqlClient.SqlParameter("@LBLTLPPT", SqlDbType.VarChar)
        oParam(3).Value = CType(LBLTLPPT, String)

        oParam(4) = New SqlClient.SqlParameter("@LBLFAXPT", SqlDbType.VarChar)
        oParam(4).Value = CType(LBLFAXPT, String)

        oParam(5) = New SqlClient.SqlParameter("@LBLEMAILPT", SqlDbType.VarChar)
        oParam(5).Value = CType(LBLEMAILPT, String)

        oParam(6) = New SqlClient.SqlParameter("@ddlGroup", SqlDbType.VarChar)
        oParam(6).Value = CType(ddlGroup, String)

        oParam(7) = New SqlClient.SqlParameter("@Bahasa", SqlDbType.VarChar)
        oParam(7).Value = CType(Bahasa, String)

        oParam(8) = New SqlClient.SqlParameter("@txtPTAGII", SqlDbType.VarChar)
        oParam(8).Value = CType(txtPTAGII, String)

        oParam(9) = New SqlClient.SqlParameter("@lblCorCode", SqlDbType.VarChar)
        oParam(9).Value = CType(lblCorCode, String)

        oParam(10) = New SqlClient.SqlParameter("@ddlPraotorisasi", SqlDbType.VarChar)
        oParam(10).Value = CType(ddlPraotorisasi, String)

        oParam(11) = New SqlClient.SqlParameter("@ToEmail", SqlDbType.VarChar)
        oParam(11).Value = CType(ToEmail, String)

        oParam(12) = New SqlClient.SqlParameter("@AgentEmail", SqlDbType.VarChar)
        oParam(12).Value = CType(AgentEmail, String)

        oParam(13) = New SqlClient.SqlParameter("@BCCEmail", SqlDbType.VarChar)
        oParam(13).Value = CType(BCCEmail, String)

        oParam(14) = New SqlClient.SqlParameter("@FileName", SqlDbType.VarChar)
        oParam(14).Value = CType(FileName, String)

        oParam(15) = New SqlClient.SqlParameter("@CreatedBy", SqlDbType.VarChar)
        oParam(15).Value = CType(CreatedBy, String)

        oParam(16) = New SqlClient.SqlParameter("@CLAIMNO", SqlDbType.VarChar)
        oParam(16).Value = CType(CLAIMNO, String)


        oParam(17) = New SqlClient.SqlParameter("@POLICYNO", SqlDbType.VarChar)
        oParam(17).Value = CType(POLICYNO, String)


        oParam(18) = New SqlClient.SqlParameter("@IDXFBA", SqlDbType.VarChar)
        oParam(18).Value = CType(IDXFBA, String)


        oParam(19) = New SqlClient.SqlParameter("@IDXFCR", SqlDbType.VarChar)
        oParam(19).Value = CType(IDXFCR, String)



        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_SP_FORMAT_EMAIL_BODY2, CommandType.StoredProcedure, oParam)

        Return dt
    End Function

    Public Function f_SEL_GET_DATE_ADM(ByVal CLAIMNO As String, ByVal POLICYNO As String)
        Dim dt As New DataTable
        Dim oParam(1) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@CLAIMNO", SqlDbType.VarChar)
        oParam(0).Value = CType(CLAIMNO, String)

        oParam(1) = New SqlClient.SqlParameter("@POLICYNO", SqlDbType.VarChar)
        oParam(1).Value = CType(POLICYNO, String)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_GET_DATE_ADM, CommandType.StoredProcedure, oParam)

        Return dt
    End Function
    Public Function f_CheckCriteria_Upload(ByVal UploadID As String)
        Dim dt As New DataTable
        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@uploadid", SqlDbType.VarChar)
        oParam(0).Value = CType(UploadID, String)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_SEL_CheckCriteria_Upload, CommandType.StoredProcedure, oParam)

        Return dt
    End Function
    Public Function f_SEL_CASHBEN_DETAIL(ByVal IDX As String)
        Dim dt As New DataTable
        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@IDX", SqlDbType.VarChar)
        oParam(0).Value = CType(IDX, String)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_SEL_CASHBEN_DETAIL, CommandType.StoredProcedure, oParam)

        Return dt
    End Function


    Public Function f_SEL_GET_DETAIL_SEND_EMAIL(ByVal CLAIMNO As String, ByVal POLICYNO As String, ByVal IDXFBA As Integer)
        Dim dt As New DataTable
        Dim oParam(2) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@CLAIMNO", SqlDbType.VarChar)
        oParam(0).Value = CType(CLAIMNO, String)

        oParam(1) = New SqlClient.SqlParameter("@POLICYNO", SqlDbType.VarChar)
        oParam(1).Value = CType(POLICYNO, String)

        oParam(2) = New SqlClient.SqlParameter("@IDXFBA", SqlDbType.Int)
        oParam(2).Value = CType(IDXFBA, Integer)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_SP_SEL_DETAIL_EMAIL_SENDING, CommandType.StoredProcedure, oParam)

        Return dt
    End Function


    Public Function f_SEL_GET_DAYS_SMS(ByVal CLAIMNO As String, ByVal POLICYNO As String)
        Dim dt As New DataTable
        Dim oParam(1) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@CLAIMNO", SqlDbType.VarChar)
        oParam(0).Value = CType(CLAIMNO, String)

        oParam(1) = New SqlClient.SqlParameter("@POLICYNO", SqlDbType.VarChar)
        oParam(1).Value = CType(POLICYNO, String)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_SEL_GET_DAYS, CommandType.StoredProcedure, oParam)

        Return dt
    End Function

    Public Function f_SEL_GET_NAME_PLAN(ByVal CLAIMNO As String, ByVal POLICYNO As String)
        Dim dt As New DataTable
        Dim oParam(1) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@CLAIMNO", SqlDbType.VarChar)
        oParam(0).Value = CType(CLAIMNO, String)

        oParam(1) = New SqlClient.SqlParameter("@POLICYNO", SqlDbType.VarChar)
        oParam(1).Value = CType(POLICYNO, String)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_SEL_GET_NAME_PLAN, CommandType.StoredProcedure, oParam)

        Return dt
    End Function


    Public Function f_SEL_COUNT_PAYMENT(ByVal CLAIMNO As String, ByVal POLICYNO As String, ByVal PayDetails As String)
        Dim dt As New DataTable
        Dim oParam(2) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@CLAIMNO", SqlDbType.VarChar)
        oParam(0).Value = CType(CLAIMNO, String)

        oParam(1) = New SqlClient.SqlParameter("@POLICYNO", SqlDbType.VarChar)
        oParam(1).Value = CType(POLICYNO, String)

        oParam(2) = New SqlClient.SqlParameter("@PayDetails", SqlDbType.VarChar)
        oParam(2).Value = CType(PayDetails, String)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, cont_sp_sel_count_payment, CommandType.StoredProcedure, oParam)

        Return dt
    End Function

    Public Function f_SEL_IDX_FCR(ByVal CLAIMNO As String, ByVal POLICYNO As String)
        Dim dt As New DataTable
        Dim oParam(1) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@CLAIMNO", SqlDbType.VarChar)
        oParam(0).Value = CType(CLAIMNO, String)

        oParam(1) = New SqlClient.SqlParameter("@POLICYNO", SqlDbType.VarChar)
        oParam(1).Value = CType(POLICYNO, String)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_SEL_IDX_FCR, CommandType.StoredProcedure, oParam)

        Return dt
    End Function
    Public Function f_sp_SEL_MST_TYPE_FBA_HEADER()
        Dim dt As New DataTable
        
        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_SEL_MST_TYPE_FBA_HEADER, CommandType.StoredProcedure)

        Return dt
    End Function
    Public Function f_sp_SEL_MST_FCR_CLAIM_STATUS()
        Dim dt As New DataTable

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_SEL_MST_FCR_CLAIM_STATUS, CommandType.StoredProcedure)

        Return dt
    End Function
    Public Function f_SEL_ReasonInves()
        Dim dt As New DataTable

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_SEL_MST_FCR_REASON_INVESTIGATION, CommandType.StoredProcedure)

        Return dt
    End Function

    Public Function f_SEL_FBA_ACTUAL_PLAN(ByVal IDXFBA As Integer)
        Dim dt As New DataTable
        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@IDXFBA", SqlDbType.Int)
        oParam(0).Value = CType(IDXFBA, Integer)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_SEL_FBA_ACTUAL_PLAN, CommandType.StoredProcedure, oParam)

        Return dt
    End Function

    Public Function f_sp_SEL_MST_TYPE_FBA_DETAIL(ByVal CODE As String)
        Dim dt As New DataTable
        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@CODE", SqlDbType.VarChar)
        oParam(0).Value = CType(CODE, String)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_SEL_MST_TYPE_FBA_DETAIL, CommandType.StoredProcedure, oParam)

        Return dt
    End Function


    Public Function f_SEL_ME_LETTER_LIST(ByVal CLAIMNO As String, ByVal POLICYNO As String, _
                                   ByVal FLAGCLAIMNO As String, ByVal FLAGPOLICYNO As String)
        Dim dt As New DataTable
        Dim oParam(3) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@CLAIMNO", SqlDbType.VarChar)
        oParam(0).Value = CType(CLAIMNO, String)

        oParam(1) = New SqlClient.SqlParameter("@POLICYNO", SqlDbType.VarChar)
        oParam(1).Value = CType(POLICYNO, String)

        oParam(2) = New SqlClient.SqlParameter("@FLAGCLAIMNO", SqlDbType.VarChar)
        oParam(2).Value = CType(FLAGCLAIMNO, String)

        oParam(3) = New SqlClient.SqlParameter("@FLAGPOLICYNO", SqlDbType.VarChar)
        oParam(3).Value = CType(FLAGPOLICYNO, String)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_SEL_ME_LETTER_LIST, CommandType.StoredProcedure, oParam)

        Return dt
    End Function
    Public Function f_SEL_FBA_FROM_FCR(ByVal CLAIMNO As String, ByVal POLICYNO As String)
        Dim dt As New DataTable
        Dim oParam(1) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@CLAIMNO", SqlDbType.VarChar)
        oParam(0).Value = CType(CLAIMNO, String)

        oParam(1) = New SqlClient.SqlParameter("@POLICYNO", SqlDbType.VarChar)
        oParam(1).Value = CType(POLICYNO, String)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Sel_FBA_FROM_FCR, CommandType.StoredProcedure, oParam)

        Return dt
    End Function
    Public Function f_SEL_FBA_FROM_FCR2(ByVal CLAIMNO As String, ByVal POLICYNO As String, ByVal IDXFBA As String)
        Dim dt As New DataTable
        Dim oParam(2) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@CLAIMNO", SqlDbType.VarChar)
        oParam(0).Value = CType(CLAIMNO, String)

        oParam(1) = New SqlClient.SqlParameter("@POLICYNO", SqlDbType.VarChar)
        oParam(1).Value = CType(POLICYNO, String)

        oParam(2) = New SqlClient.SqlParameter("@IDXFBA", SqlDbType.VarChar)
        oParam(2).Value = CType(IDXFBA, String)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Sel_FBA_FROM_FCR2, CommandType.StoredProcedure, oParam)

        Return dt
    End Function
    Public Function f_SEL_DETAIL_EMAIL(ByVal IDX As Integer, ByVal IDXFBA As Integer)
        Dim dt As New DataTable
        Dim oParam(1) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@IDX", SqlDbType.Int)
        oParam(0).Value = CType(IDX, Integer)

        oParam(1) = New SqlClient.SqlParameter("@IDXFBA", SqlDbType.Int)
        oParam(1).Value = CType(IDXFBA, Integer)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_SEL_DETAIL_EMAIL, CommandType.StoredProcedure, oParam)

        Return dt
    End Function
    Public Function f_SEL_MST_CLAIM_STATUS()
        Dim dt As New DataTable
       
        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_SEL_MST_CLAIM_STATUS, CommandType.StoredProcedure)

        Return dt
    End Function

    Public Function f_SEL_EXCH_RATE(ByVal FROM_CURR As String, ByVal TO_CURR As String, ByVal SOURCE As String, ByVal DATEADM As Date)
        Dim dt As New DataTable
        Dim oParam(3) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@FROM_CURR", SqlDbType.VarChar)
        oParam(0).Value = CType(FROM_CURR, String)

        oParam(1) = New SqlClient.SqlParameter("@TO_CURR", SqlDbType.VarChar)
        oParam(1).Value = CType(TO_CURR, String)

        oParam(2) = New SqlClient.SqlParameter("@SOURCE", SqlDbType.VarChar)
        oParam(2).Value = CType(SOURCE, String)

        oParam(3) = New SqlClient.SqlParameter("@DATEADM", SqlDbType.Date)
        oParam(3).Value = CType(DATEADM, Date)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Sel_EXC_RATE, CommandType.StoredProcedure, oParam)

        Return dt
    End Function

    Public Function f_sel_CURR_BI_ALL(ByVal Curr As String, ByVal FlagCurr As String)
        Dim dt As New DataTable
        Dim oParam(1) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@CURRENCY", SqlDbType.VarChar)
        oParam(0).Value = CType(Curr, String)

        oParam(1) = New SqlClient.SqlParameter("@FLAG_CURRENCY", SqlDbType.VarChar)
        oParam(1).Value = CType(FlagCurr, String)


        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Sel_CURR_BI, CommandType.StoredProcedure, oParam)

        Return dt
    End Function
    Public Function f_sel_CURR_BM_ALL(ByVal Curr As String, ByVal FlagCurr As String)
        Dim dt As New DataTable
        Dim oParam(1) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@CURRENCY", SqlDbType.VarChar)
        oParam(0).Value = CType(Curr, String)

        oParam(1) = New SqlClient.SqlParameter("@FLAG_CURRENCY", SqlDbType.VarChar)
        oParam(1).Value = CType(FlagCurr, String)


        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Sel_CURR_BM, CommandType.StoredProcedure, oParam)

        Return dt
    End Function
    Public Function f_SEL_MST_CURR_BI(ByVal idx As Integer)
        Dim dt As New DataTable
        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@IDX", SqlDbType.VarChar)
        oParam(0).Value = CType(idx, String)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Sel_MST_CURR_BI, CommandType.StoredProcedure, oParam)

        Return dt
    End Function

    Public Function f_SEL_MST_CURR_BM(ByVal idx As Integer)
        Dim dt As New DataTable
        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@IDX", SqlDbType.VarChar)
        oParam(0).Value = CType(idx, String)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Sel_MST_CURR_BM, CommandType.StoredProcedure, oParam)

        Return dt
    End Function
    Public Function f_SEL_CASE_FOLLOW_UP_LOG(ByVal CLAIMNO As String, ByVal POLICYNO As String)
        Dim dt As New DataTable
        Dim oParam(1) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@CLAIMNO", SqlDbType.VarChar)
        oParam(0).Value = CType(CLAIMNO, String)

        oParam(1) = New SqlClient.SqlParameter("@POLICYNO", SqlDbType.VarChar)
        oParam(1).Value = CType(POLICYNO, String)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_SEL_TRN_CASE_FOLLOW_UP, CommandType.StoredProcedure, oParam)

        Return dt
    End Function
    Public Function f_SEL_CHECK_FBA(ByVal CLAIMNO As String, ByVal POLICYNO As String)
        Dim dt As New DataTable
        Dim oParam(1) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@CLAIMNO", SqlDbType.VarChar)
        oParam(0).Value = CType(CLAIMNO, String)

        oParam(1) = New SqlClient.SqlParameter("@POLICYNO", SqlDbType.VarChar)
        oParam(1).Value = CType(POLICYNO, String)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Sel_CHECK_FBA, CommandType.StoredProcedure, oParam)

        Return dt
    End Function

    Public Function f_SEL_ME_LETTER_DOWNLOAD(ByVal CLAIMNO As String, ByVal POLICYNO As String)
        Dim dt As New DataTable
        Dim oParam(1) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@CLAIMNO", SqlDbType.VarChar)
        oParam(0).Value = CType(CLAIMNO, String)

        oParam(1) = New SqlClient.SqlParameter("@POLICYNO", SqlDbType.VarChar)
        oParam(1).Value = CType(POLICYNO, String)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_SEL_ME_LETTER, CommandType.StoredProcedure, oParam)

        Return dt
    End Function

    Public Function f_SEND_EMAIL_CLAIM_SUMMARY(ByVal CLAIMNO As String, ByVal POLICYNO As String, ByVal EMAIL As String)
        Dim dt As New DataTable
        Dim oParam(2) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@CLAIMNO", SqlDbType.VarChar)
        oParam(0).Value = CType(CLAIMNO, String)

        oParam(1) = New SqlClient.SqlParameter("@POLICYNO", SqlDbType.VarChar)
        oParam(1).Value = CType(POLICYNO, String)

        oParam(2) = New SqlClient.SqlParameter("@EMAIL", SqlDbType.VarChar)
        oParam(2).Value = CType(EMAIL, String)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_SP_SEND_EMAIL_CLAIM_SUMMARY, CommandType.StoredProcedure, oParam)

        Return dt
    End Function
    Public Function f_SEND_EMAIL_DECLINE(ByVal CLAIMNO As String, ByVal POLICYNO As String, ByVal EMAIL As String)
        Dim dt As New DataTable
        Dim oParam(2) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@CLAIMNO", SqlDbType.VarChar)
        oParam(0).Value = CType(CLAIMNO, String)

        oParam(1) = New SqlClient.SqlParameter("@POLICYNO", SqlDbType.VarChar)
        oParam(1).Value = CType(POLICYNO, String)

        oParam(2) = New SqlClient.SqlParameter("@EMAIL", SqlDbType.VarChar)
        oParam(2).Value = CType(EMAIL, String)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_SP_SEND_EMAIL_DECLINE, CommandType.StoredProcedure, oParam)

        Return dt
    End Function
    Public Function f_SEND_EMAIL_EMPTY(ByVal CLAIMNO As String, ByVal POLICYNO As String, ByVal EMAIL As String)
        Dim dt As New DataTable
        Dim oParam(2) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@CLAIMNO", SqlDbType.VarChar)
        oParam(0).Value = CType(CLAIMNO, String)

        oParam(1) = New SqlClient.SqlParameter("@POLICYNO", SqlDbType.VarChar)
        oParam(1).Value = CType(POLICYNO, String)

        oParam(2) = New SqlClient.SqlParameter("@EMAIL", SqlDbType.VarChar)
        oParam(2).Value = CType(EMAIL, String)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_SP_SEND_EMAIL_EMPTY, CommandType.StoredProcedure, oParam)

        Return dt
    End Function
    Public Function f_SEND_EMAIL_INC_DOC(ByVal CLAIMNO As String, ByVal POLICYNO As String, ByVal EMAIL As String)
        Dim dt As New DataTable
        Dim oParam(2) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@CLAIMNO", SqlDbType.VarChar)
        oParam(0).Value = CType(CLAIMNO, String)

        oParam(1) = New SqlClient.SqlParameter("@POLICYNO", SqlDbType.VarChar)
        oParam(1).Value = CType(POLICYNO, String)

        oParam(2) = New SqlClient.SqlParameter("@EMAIL", SqlDbType.VarChar)
        oParam(2).Value = CType(EMAIL, String)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_SP_SEND_EMAIL_INC_DOC, CommandType.StoredProcedure, oParam)

        Return dt
    End Function
    Public Function f_SEND_EMAIL_PENDING(ByVal CLAIMNO As String, ByVal POLICYNO As String, ByVal EMAIL As String)
        Dim dt As New DataTable
        Dim oParam(2) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@CLAIMNO", SqlDbType.VarChar)
        oParam(0).Value = CType(CLAIMNO, String)

        oParam(1) = New SqlClient.SqlParameter("@POLICYNO", SqlDbType.VarChar)
        oParam(1).Value = CType(POLICYNO, String)

        oParam(2) = New SqlClient.SqlParameter("@EMAIL", SqlDbType.VarChar)
        oParam(2).Value = CType(EMAIL, String)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_SP_SEND_EMAIL_PENDING, CommandType.StoredProcedure, oParam)

        Return dt
    End Function

    Public Function f_SEL_CHECK_DEPARTMENT(ByVal USERNAME As String)
        Dim dt As New DataTable
        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@USERNAME", SqlDbType.VarChar)
        oParam(0).Value = CType(USERNAME, String)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Sel_CHECK_DEPARTMENT, CommandType.StoredProcedure, oParam)

        Return dt
    End Function

    Public Function f_SEL_SMS_DOWNLOAD(ByVal CLAIMNO As String, ByVal POLICYNO As String, _
                                   ByVal FLAGCLAIMNO As String, ByVal FLAGPOLICYNO As String, _
                                   ByVal SMSVALUE As String, ByVal SMSTYPE As String, _
                                   ByVal CREATEDDATEFROM As Date, ByVal CREATEDDATETO As Date, _
                                   ByVal FLAGSMSValue As String, ByVal FLAGSMSTYPE As String, _
                                   ByVal FLAGCREATEDDATE As String, ByVal ENTITY As String, _
                                   ByVal MOBILENO As String, ByVal FLAGMOBILENO As String, _
                                   ByVal CORCODE As String, ByVal FLAGCORCODE As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(15) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@CLAIMNO", SqlDbType.VarChar)
        oParam(0).Value = CType(CLAIMNO, String)

        oParam(1) = New SqlClient.SqlParameter("@POLICYNO", SqlDbType.VarChar)
        oParam(1).Value = CType(POLICYNO, String)

        oParam(2) = New SqlClient.SqlParameter("@FLAGCLAIMNO", SqlDbType.VarChar)
        oParam(2).Value = CType(FLAGCLAIMNO, String)

        oParam(3) = New SqlClient.SqlParameter("@FLAGPOLICYNO", SqlDbType.VarChar)
        oParam(3).Value = CType(FLAGPOLICYNO, String)

        oParam(4) = New SqlClient.SqlParameter("@SMSVALUE", SqlDbType.VarChar)
        oParam(4).Value = CType(SMSVALUE, String)

        oParam(5) = New SqlClient.SqlParameter("@SMSTYPE", SqlDbType.VarChar)
        oParam(5).Value = CType(SMSTYPE, String)

        oParam(6) = New SqlClient.SqlParameter("@CREATEDDATEFROM", SqlDbType.Date)
        oParam(6).Value = CType(CREATEDDATEFROM, Date)

        oParam(7) = New SqlClient.SqlParameter("@CREATEDDATETO", SqlDbType.Date)
        oParam(7).Value = CType(CREATEDDATETO, Date)

        oParam(8) = New SqlClient.SqlParameter("@FLAGSMSValue", SqlDbType.VarChar)
        oParam(8).Value = CType(FLAGSMSValue, String)

        oParam(9) = New SqlClient.SqlParameter("@FLAGSMSTYPE", SqlDbType.VarChar)
        oParam(9).Value = CType(FLAGSMSTYPE, String)

        oParam(10) = New SqlClient.SqlParameter("@FLAGCREATEDDATE", SqlDbType.VarChar)
        oParam(10).Value = CType(FLAGCREATEDDATE, String)

        oParam(11) = New SqlClient.SqlParameter("@ENTITY", SqlDbType.VarChar)
        oParam(11).Value = CType(ENTITY, String)

        oParam(12) = New SqlClient.SqlParameter("@MOBILENO", SqlDbType.VarChar)
        oParam(12).Value = CType(MOBILENO, String)

        oParam(13) = New SqlClient.SqlParameter("@FLAGMOBILENO", SqlDbType.VarChar)
        oParam(13).Value = CType(FLAGMOBILENO, String)

        oParam(14) = New SqlClient.SqlParameter("@CORCODE", SqlDbType.VarChar)
        oParam(14).Value = CType(CORCODE, String)

        oParam(15) = New SqlClient.SqlParameter("@FLAGCORCODE", SqlDbType.VarChar)
        oParam(15).Value = CType(FLAGCORCODE, String)



        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_SEL_SMS_DOWNLOAD, CommandType.StoredProcedure, oParam)

        Return dt

    End Function
    Public Function f_SEL_SMS_DOWNLOAD2(ByVal CLAIMNO As String, ByVal POLICYNO As String, _
                                  ByVal FLAGCLAIMNO As String, ByVal FLAGPOLICYNO As String, _
                                  ByVal SMSVALUE As String, ByVal SMSTYPE As String, _
                                  ByVal CREATEDDATEFROM As Date, ByVal CREATEDDATETO As Date, _
                                  ByVal FLAGSMSValue As String, ByVal FLAGSMSTYPE As String, _
                                  ByVal FLAGCREATEDDATE As String, ByVal ENTITY As String, _
                                  ByVal MOBILENO As String, ByVal FLAGMOBILENO As String, _
                                  ByVal CORCODE As String, ByVal FLAGCORCODE As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(15) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@CLAIMNO", SqlDbType.VarChar)
        oParam(0).Value = CType(CLAIMNO, String)

        oParam(1) = New SqlClient.SqlParameter("@POLICYNO", SqlDbType.VarChar)
        oParam(1).Value = CType(POLICYNO, String)

        oParam(2) = New SqlClient.SqlParameter("@FLAGCLAIMNO", SqlDbType.VarChar)
        oParam(2).Value = CType(FLAGCLAIMNO, String)

        oParam(3) = New SqlClient.SqlParameter("@FLAGPOLICYNO", SqlDbType.VarChar)
        oParam(3).Value = CType(FLAGPOLICYNO, String)

        oParam(4) = New SqlClient.SqlParameter("@SMSVALUE", SqlDbType.VarChar)
        oParam(4).Value = CType(SMSVALUE, String)

        oParam(5) = New SqlClient.SqlParameter("@SMSTYPE", SqlDbType.VarChar)
        oParam(5).Value = CType(SMSTYPE, String)

        oParam(6) = New SqlClient.SqlParameter("@CREATEDDATEFROM", SqlDbType.Date)
        oParam(6).Value = CType(CREATEDDATEFROM, Date)

        oParam(7) = New SqlClient.SqlParameter("@CREATEDDATETO", SqlDbType.Date)
        oParam(7).Value = CType(CREATEDDATETO, Date)

        oParam(8) = New SqlClient.SqlParameter("@FLAGSMSValue", SqlDbType.VarChar)
        oParam(8).Value = CType(FLAGSMSValue, String)

        oParam(9) = New SqlClient.SqlParameter("@FLAGSMSTYPE", SqlDbType.VarChar)
        oParam(9).Value = CType(FLAGSMSTYPE, String)

        oParam(10) = New SqlClient.SqlParameter("@FLAGCREATEDDATE", SqlDbType.VarChar)
        oParam(10).Value = CType(FLAGCREATEDDATE, String)

        oParam(11) = New SqlClient.SqlParameter("@ENTITY", SqlDbType.VarChar)
        oParam(11).Value = CType(ENTITY, String)

        oParam(12) = New SqlClient.SqlParameter("@MOBILENO", SqlDbType.VarChar)
        oParam(12).Value = CType(MOBILENO, String)

        oParam(13) = New SqlClient.SqlParameter("@FLAGMOBILENO", SqlDbType.VarChar)
        oParam(13).Value = CType(FLAGMOBILENO, String)

        oParam(14) = New SqlClient.SqlParameter("@CORCODE", SqlDbType.VarChar)
        oParam(14).Value = CType(CORCODE, String)

        oParam(15) = New SqlClient.SqlParameter("@FLAGCORCODE", SqlDbType.VarChar)
        oParam(15).Value = CType(FLAGCORCODE, String)



        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_SEL_SMS_DOWNLOAD2, CommandType.StoredProcedure, oParam)

        Return dt

    End Function
    Public Function f_SEL_SMS_COUNT(ByVal ENTITY As String, ByVal SMSTYPE As String, _
                                    ByVal CREATEDDATEFROM As Date, ByVal CREATEDDATETO As Date) As DataTable

        Dim dt As New DataTable
        Dim oParam(3) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@ENTITY", SqlDbType.VarChar)
        oParam(0).Value = CType(ENTITY, String)

        oParam(1) = New SqlClient.SqlParameter("@SMSTYPE", SqlDbType.VarChar)
        oParam(1).Value = CType(SMSTYPE, String)

        oParam(2) = New SqlClient.SqlParameter("@CREATEDDATEFROM", SqlDbType.Date)
        oParam(2).Value = CType(CREATEDDATEFROM, Date)

        oParam(3) = New SqlClient.SqlParameter("@CREATEDDATETO", SqlDbType.Date)
        oParam(3).Value = CType(CREATEDDATETO, Date)


        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_SEL_SMS_COUNT, CommandType.StoredProcedure, oParam)

        Return dt

    End Function

    Public Function f_SEL_SMS_VALUE_TYPE(ByVal ENTITY As String, ByVal SMSTYPE As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(1) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@ENTITY", SqlDbType.VarChar)
        oParam(0).Value = CType(ENTITY, String)

        oParam(1) = New SqlClient.SqlParameter("@SMSTYPE", SqlDbType.VarChar)
        oParam(1).Value = CType(SMSTYPE, String)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_SEL_SMS_VALUE_TYPE, CommandType.StoredProcedure, oParam)

        Return dt

    End Function
    Public Function f_SEL_TRN_DASHBOARD() As DataTable

        Dim dt As New DataTable
        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_SEL_TRN_DASHBOARD, CommandType.StoredProcedure)

        Return dt

    End Function
    Public Function f_SEL_TRN_DASHBOARD_APPROVED() As DataTable

        Dim dt As New DataTable
        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_SEL_TRN_DASHBOARD_APPROVED, CommandType.StoredProcedure)

        Return dt

    End Function
    Public Function f_SEL_TRN_DASHBOARD_CLOSING() As DataTable

        Dim dt As New DataTable
        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_SEL_TRN_DASHBOARD_CLOSING, CommandType.StoredProcedure)

        Return dt

    End Function

    Public Function f_SEL_TRN_DASHBOARD_PENDING() As DataTable

        Dim dt As New DataTable
        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_SEL_TRN_DASHBOARD_PENDING, CommandType.StoredProcedure)

        Return dt

    End Function
    Public Function f_SEL_TRN_DASHBOARD_DECLINED() As DataTable

        Dim dt As New DataTable
        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_SEL_TRN_DASHBOARD_DECLINED, CommandType.StoredProcedure)

        Return dt

    End Function


    Public Function f_SEL_MST_CLAIM_SUMMARY_LETTER(ByVal PRODUCT As String, ByVal COORPORATE_CODE As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(1) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@PRODUCT", SqlDbType.VarChar)
        oParam(0).Value = CType(PRODUCT, String)

        oParam(1) = New SqlClient.SqlParameter("@COORPORATE_CODE", SqlDbType.VarChar)
        oParam(1).Value = CType(COORPORATE_CODE, String)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_SEL_MST_CLAIM_SUMMARY_LETTER, CommandType.StoredProcedure, oParam)

        Return dt

    End Function

    Public Function f_Sel_COORPORATECODE(ByVal CLAIMNO As String, ByVal POLICYNO As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(1) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@CLAIMNO", SqlDbType.VarChar)
        oParam(0).Value = CType(CLAIMNO, String)

        oParam(1) = New SqlClient.SqlParameter("@POLICYNO", SqlDbType.VarChar)
        oParam(1).Value = CType(POLICYNO, String)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Sel_COORPORATECODE, CommandType.StoredProcedure, oParam)

        Return dt

    End Function


    Public Function f_SEL_SMS_LETTER(ByVal IDX As String, ByVal SMSValue As String, ByVal SMSTYPE As String, _
                                      ByVal CREATEDDATEFROM As Date, ByVal CREATEDDATETO As Date) As DataTable

        Dim dt As New DataTable
        Dim oParam(4) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@IDX", SqlDbType.VarChar)
        oParam(0).Value = CType(IDX, String)

        oParam(1) = New SqlClient.SqlParameter("@SMSValue", SqlDbType.VarChar)
        oParam(1).Value = CType(SMSValue, String)

        oParam(2) = New SqlClient.SqlParameter("@SMSTYPE", SqlDbType.VarChar)
        oParam(2).Value = CType(SMSTYPE, String)

        oParam(3) = New SqlClient.SqlParameter("@CREATEDDATEFROM", SqlDbType.Date)
        oParam(3).Value = CType(CREATEDDATEFROM, Date)

        oParam(4) = New SqlClient.SqlParameter("@CREATEDDATETO", SqlDbType.Date)
        oParam(4).Value = CType(CREATEDDATETO, Date)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_SEL_SMS_LETTER, CommandType.StoredProcedure, oParam)

        Return dt

    End Function


    Public Function f_SEL_PAYMENT_REPORT_INS(ByVal CLAIMNO As String, ByVal POLICYNO As String, _
                                   ByVal FLAGCLAIMNO As String, ByVal FLAGPOLICYNO As String, _
                                   ByVal CREATEDBY As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(4) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@CLAIMNO", SqlDbType.VarChar)
        oParam(0).Value = CType(CLAIMNO, String)

        oParam(1) = New SqlClient.SqlParameter("@POLICYNO", SqlDbType.VarChar)
        oParam(1).Value = CType(POLICYNO, String)

        oParam(2) = New SqlClient.SqlParameter("@FLAGCLAIMNO", SqlDbType.VarChar)
        oParam(2).Value = CType(FLAGCLAIMNO, String)

        oParam(3) = New SqlClient.SqlParameter("@FLAGPOLICYNO", SqlDbType.VarChar)
        oParam(3).Value = CType(FLAGPOLICYNO, String)

        oParam(4) = New SqlClient.SqlParameter("@CREATEDBY", SqlDbType.VarChar)
        oParam(4).Value = CType(CREATEDBY, String)


        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Sel_PAYMENT_REPORT_INS, CommandType.StoredProcedure, oParam)

        Return dt

    End Function
    Public Function f_SEL_Download_Failed_Upload(ByVal CorpCode As String, ByVal StartDate As Date, _
                                  ByVal toDate As Date, ByVal FLAGCorpCode As String, _
                                  ByVal FLAGStartDate As String, ByVal CREATEDBY As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(5) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@CorpCode", SqlDbType.VarChar)
        oParam(0).Value = CType(CorpCode, String)

        oParam(1) = New SqlClient.SqlParameter("@startDate", SqlDbType.VarChar)
        oParam(1).Value = CType(StartDate, String)

        oParam(2) = New SqlClient.SqlParameter("@toDate", SqlDbType.VarChar)
        oParam(2).Value = CType(toDate, String)

        oParam(3) = New SqlClient.SqlParameter("@FLAG_CorpCode", SqlDbType.VarChar)
        oParam(3).Value = CType(FLAGCorpCode, String)

        oParam(4) = New SqlClient.SqlParameter("@FLAG_DAY_startDate", SqlDbType.VarChar)
        oParam(4).Value = CType(FLAGStartDate, String)

        oParam(5) = New SqlClient.SqlParameter("@CREATEDBY", SqlDbType.VarChar)
        oParam(5).Value = CType(CREATEDBY, String)


        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_download_failed_upload, CommandType.StoredProcedure, oParam)

        Return dt

    End Function
    Public Function f_SEL_ESCALATION_LETTER(ByVal CLAIMNO As String, ByVal POLICYNO As String, _
                                   ByVal FLAGCLAIMNO As String, ByVal FLAGPOLICYNO As String, _
                                   ByVal CREATEDBY As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(4) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@CLAIMNO", SqlDbType.VarChar)
        oParam(0).Value = CType(CLAIMNO, String)

        oParam(1) = New SqlClient.SqlParameter("@POLICYNO", SqlDbType.VarChar)
        oParam(1).Value = CType(POLICYNO, String)

        oParam(2) = New SqlClient.SqlParameter("@FLAGCLAIMNO", SqlDbType.VarChar)
        oParam(2).Value = CType(FLAGCLAIMNO, String)

        oParam(3) = New SqlClient.SqlParameter("@FLAGPOLICYNO", SqlDbType.VarChar)
        oParam(3).Value = CType(FLAGPOLICYNO, String)

        oParam(4) = New SqlClient.SqlParameter("@CREATEDBY", SqlDbType.VarChar)
        oParam(4).Value = CType(CREATEDBY, String)


        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_SEL_ESCALATION_LETTER, CommandType.StoredProcedure, oParam)

        Return dt

    End Function
    Public Function f_SEL_ESCALATION_LETTER_DETAIL(ByVal CLAIMNO As String, ByVal POLICYNO As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(1) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@CLAIMNO", SqlDbType.VarChar)
        oParam(0).Value = CType(CLAIMNO, String)

        oParam(1) = New SqlClient.SqlParameter("@POLICYNO", SqlDbType.VarChar)
        oParam(1).Value = CType(POLICYNO, String)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_SEL_ESCALATION_LETTER_DETAIL, CommandType.StoredProcedure, oParam)

        Return dt

    End Function


    Public Function f_Sel_PendingLetter(ByVal CLAIMNO As String, ByVal POLICYNO As String, ByVal FLAGSTAT As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(2) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@CLAIMNO", SqlDbType.VarChar)
        oParam(0).Value = CType(CLAIMNO, String)

        oParam(1) = New SqlClient.SqlParameter("@POLICYNO", SqlDbType.VarChar)
        oParam(1).Value = CType(POLICYNO, String)


        oParam(2) = New SqlClient.SqlParameter("@FLAGSTAT", SqlDbType.VarChar)
        oParam(2).Value = CType(FLAGSTAT, String)



        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Sel_DOWNLOAD_PENDING_LETTER, CommandType.StoredProcedure, oParam)

        Return dt

    End Function
    Public Function f_Sel_SMSTYPE(ByVal SMSTYPE As String, ByVal ENTITY As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(1) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@SMSTYPE", SqlDbType.VarChar)
        oParam(0).Value = CType(SMSTYPE, String)

        oParam(1) = New SqlClient.SqlParameter("@ENTITY", SqlDbType.VarChar)
        oParam(1).Value = CType(ENTITY, String)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Sel_SMSTYPE, CommandType.StoredProcedure, oParam)

        Return dt

    End Function

    Public Function f_SEL_SUM_FBA_CASHBACK_BENEFIT(ByVal CLAIMNO As String, ByVal POLICYNO As String, _
                                           ByVal PAYDETAILS As String, ByVal IDXFBA As Integer) As DataTable

        Dim dt As New DataTable
        Dim oParam(3) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@CLAIMNO", SqlDbType.VarChar)
        oParam(0).Value = CType(CLAIMNO, String)

        oParam(1) = New SqlClient.SqlParameter("@POLICYNO", SqlDbType.VarChar)
        oParam(1).Value = CType(POLICYNO, String)

        oParam(2) = New SqlClient.SqlParameter("@PAYDETAILS", SqlDbType.VarChar)
        oParam(2).Value = CType(PAYDETAILS, String)

        oParam(3) = New SqlClient.SqlParameter("@IDXFBA", SqlDbType.Int)
        oParam(3).Value = CType(IDXFBA, Integer)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_SEL_SUM_FBA_CASHBACK_BENEFIT, CommandType.StoredProcedure, oParam)

        Return dt

    End Function

    Public Function f_SEL_SUM_INELIG_AMOUNT(ByVal CLAIMNO As String, ByVal POLICYNO As String, _
                                            ByVal PAYDETAILS As String, ByVal IDXFBA As Integer) As DataTable

        Dim dt As New DataTable
        Dim oParam(3) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@CLAIMNO", SqlDbType.VarChar)
        oParam(0).Value = CType(CLAIMNO, String)

        oParam(1) = New SqlClient.SqlParameter("@POLICYNO", SqlDbType.VarChar)
        oParam(1).Value = CType(POLICYNO, String)

        oParam(2) = New SqlClient.SqlParameter("@PAYDETAILS", SqlDbType.VarChar)
        oParam(2).Value = CType(PAYDETAILS, String)

        oParam(3) = New SqlClient.SqlParameter("@IDXFBA", SqlDbType.Int)
        oParam(3).Value = CType(IDXFBA, Integer)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_SEL_SUM_INELIG_AMOUNT, CommandType.StoredProcedure, oParam)

        Return dt

    End Function

    Public Function f_Sel_BORDERAUX_ALL(ByVal IDX As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@IDX", SqlDbType.VarChar)
        oParam(0).Value = CType(IDX, String)


        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Sel_Borderaux_all, CommandType.StoredProcedure, oParam)

        Return dt

    End Function
    Public Function f_Sel_TRN_SMS_LETTER(ByVal IDX As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@IDX", SqlDbType.VarChar)
        oParam(0).Value = CType(IDX, String)


        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_SEL_TRN_SMS, CommandType.StoredProcedure, oParam)

        Return dt

    End Function


    Public Function f_Sel_BORDERAUX_Claim(ByVal IDX As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@IDX", SqlDbType.VarChar)
        oParam(0).Value = CType(IDX, String)


        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Sel_Borderaux_Claim, CommandType.StoredProcedure, oParam)

        Return dt

    End Function

    Public Function f_Sel_BORDERAUX_Claim_LETTER(ByVal IDX As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@IDX", SqlDbType.VarChar)
        oParam(0).Value = CType(IDX, String)


        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Sel_Borderaux_Claim_LETTER, CommandType.StoredProcedure, oParam)

        Return dt

    End Function


    Public Function f_Sel_RequestLetterDraft(ByVal CLAIMNO As String, ByVal POLICYNO As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(1) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@CLAIMNO", SqlDbType.VarChar)
        oParam(0).Value = CType(CLAIMNO, String)

        oParam(1) = New SqlClient.SqlParameter("@POLICYNO", SqlDbType.VarChar)
        oParam(1).Value = CType(POLICYNO, String)


        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Sel_REQUEST_LETTER_DRAFT, CommandType.StoredProcedure, oParam)

        Return dt

    End Function

    Public Function f_Sel_RequestLetterDraftList(ByVal CLAIMNO As String, ByVal POLICYNO As String, ByVal NAMEINSURED As String, _
                                                 ByVal FLAGCLAIMNO As String, ByVal FLAGPOLICYNO As String, ByVal FLAGNAMEINSURED As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(5) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@CLAIMNO", SqlDbType.VarChar)
        oParam(0).Value = CType(CLAIMNO, String)

        oParam(1) = New SqlClient.SqlParameter("@POLICYNO", SqlDbType.VarChar)
        oParam(1).Value = CType(POLICYNO, String)

        oParam(2) = New SqlClient.SqlParameter("@NAMEINSURED", SqlDbType.VarChar)
        oParam(2).Value = CType(NAMEINSURED, String)

        oParam(3) = New SqlClient.SqlParameter("@FLAGCLAIMNO", SqlDbType.VarChar)
        oParam(3).Value = CType(FLAGCLAIMNO, String)

        oParam(4) = New SqlClient.SqlParameter("@FLAGPOLICYNO", SqlDbType.VarChar)
        oParam(4).Value = CType(FLAGPOLICYNO, String)

        oParam(5) = New SqlClient.SqlParameter("@FLAGNAMEINSURED", SqlDbType.VarChar)
        oParam(5).Value = CType(FLAGNAMEINSURED, String)


        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Sel_REQUEST_LETTER_DRAFT_LIST, CommandType.StoredProcedure, oParam)

        Return dt

    End Function

    Public Function f_Sel_PendingLetter_Download(ByVal FLAGSTAT As String, ByVal POLICYNO As String, _
                                                 ByVal CLAIMNO As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(2) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@FLAGSTAT", SqlDbType.VarChar)
        oParam(0).Value = CType(FLAGSTAT, String)

        oParam(1) = New SqlClient.SqlParameter("@POLICYNO", SqlDbType.VarChar)
        oParam(1).Value = CType(POLICYNO, String)

        oParam(2) = New SqlClient.SqlParameter("@CLAIMNO", SqlDbType.VarChar)
        oParam(2).Value = CType(CLAIMNO, String)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Sel_DOWNLOAD_PENDING_LETTER_EXPORT, CommandType.StoredProcedure, oParam)

        Return dt

    End Function
    Public Function f_Sel_CLAIM_SUMMARY_LETTER_DOWNLOAD(ByVal POLICYNO As String, _
                                              ByVal CLAIMNO As String, ByVal PAYDETAILS As String, ByVal IDXFBA As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(3) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@POLICYNO", SqlDbType.VarChar)
        oParam(0).Value = CType(POLICYNO, String)

        oParam(1) = New SqlClient.SqlParameter("@CLAIMNO", SqlDbType.VarChar)
        oParam(1).Value = CType(CLAIMNO, String)

        oParam(2) = New SqlClient.SqlParameter("@PAYDETAILS", SqlDbType.VarChar)
        oParam(2).Value = CType(PAYDETAILS, String)

        oParam(3) = New SqlClient.SqlParameter("@IDXFBA", SqlDbType.VarChar)
        oParam(3).Value = CType(IDXFBA, String)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_SEL_DOWNLOAD_CLAIM_SUMMARY_LETTER, CommandType.StoredProcedure, oParam)

        Return dt

    End Function


    Public Function f_SEL_PAYMENT_REPORT_EDIT(ByVal CLAIMNO As String, ByVal POLICYNO As String, _
                                  ByVal FLAGCLAIMNO As String, ByVal FLAGPOLICYNO As String, _
                                  ByVal CREATEDBY As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(4) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@CLAIMNO", SqlDbType.VarChar)
        oParam(0).Value = CType(CLAIMNO, String)

        oParam(1) = New SqlClient.SqlParameter("@POLICYNO", SqlDbType.VarChar)
        oParam(1).Value = CType(POLICYNO, String)

        oParam(2) = New SqlClient.SqlParameter("@FLAGCLAIMNO", SqlDbType.VarChar)
        oParam(2).Value = CType(FLAGCLAIMNO, String)

        oParam(3) = New SqlClient.SqlParameter("@FLAGPOLICYNO", SqlDbType.VarChar)
        oParam(3).Value = CType(FLAGPOLICYNO, String)

        oParam(4) = New SqlClient.SqlParameter("@CREATEDBY", SqlDbType.VarChar)
        oParam(4).Value = CType(CREATEDBY, String)


        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Sel_PAYMENT_REPORT_EDIT, CommandType.StoredProcedure, oParam)

        Return dt

    End Function

    Public Function f_SEL_PAYMENT_REPORT_DOWNLOAD_DATA(ByVal CREATEDDATE As Date, ByVal CREATEDDATETO As Date, ByVal ENTITY As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(2) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@CREATEDDATE", SqlDbType.Date)
        oParam(0).Value = CType(CREATEDDATE, Date)

        oParam(1) = New SqlClient.SqlParameter("@CREATEDDATETO", SqlDbType.Date)
        oParam(1).Value = CType(CREATEDDATETO, Date)

        oParam(2) = New SqlClient.SqlParameter("@ENTITY", SqlDbType.VarChar)
        oParam(2).Value = CType(ENTITY, String)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Sel_DOWNLOAD_PAYMENT_REPORT, CommandType.StoredProcedure, oParam)

        Return dt

    End Function
  
    Public Function f_SEL_PAYMENT_REPORT_DOWNLOAD_DATA_FOR_UPDATE(ByVal CREATEDDATE As Date, ByVal CREATEDDATETO As Date, ByVal ENTITY As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(2) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@CREATEDDATE", SqlDbType.Date)
        oParam(0).Value = CType(CREATEDDATE, Date)

        oParam(1) = New SqlClient.SqlParameter("@CREATEDDATETO", SqlDbType.Date)
        oParam(1).Value = CType(CREATEDDATETO, Date)

        oParam(2) = New SqlClient.SqlParameter("@ENTITY", SqlDbType.VarChar)
        oParam(2).Value = CType(ENTITY, String)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Sel_DOWNLOAD_PAYMENT_REPORT_FOR_UPDATE, CommandType.StoredProcedure, oParam)

        Return dt

    End Function

    Public Function f_SEL_PAYMENT_REPORT_DOWNLOAD_DATA_FOR_UPDATE_2(ByVal CREATEDDATE As Date, ByVal CREATEDDATETO As Date, ByVal ENTITY As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(2) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@CREATEDDATE", SqlDbType.Date)
        oParam(0).Value = CType(CREATEDDATE, Date)

        oParam(1) = New SqlClient.SqlParameter("@CREATEDDATETO", SqlDbType.Date)
        oParam(1).Value = CType(CREATEDDATETO, Date)

        oParam(2) = New SqlClient.SqlParameter("@ENTITY", SqlDbType.VarChar)
        oParam(2).Value = CType(ENTITY, String)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Sel_DOWNLOAD_PAYMENT_REPORT_FOR_UPDATE_2, CommandType.StoredProcedure, oParam)

        Return dt

    End Function

    Public Function f_SEL_PAYMENT_REPORT_DOWNLOAD_DATA2(ByVal CREATEDDATE As Date, ByVal CREATEDDATETO As Date) As DataTable

        Dim dt As New DataTable
        Dim oParam(1) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@CREATEDDATE", SqlDbType.VarChar)
        oParam(0).Value = CType(CREATEDDATE, String)

        oParam(1) = New SqlClient.SqlParameter("@CREATEDDATETO", SqlDbType.VarChar)
        oParam(1).Value = CType(CREATEDDATETO, String)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Sel_DOWNLOAD_PAYMENT_REPORT2, CommandType.StoredProcedure, oParam)

        Return dt

    End Function

    Public Function f_SEL_PAYMENT_REPORT_DOWNLOAD_DATA3() As DataTable

        Dim dt As New DataTable


        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Sel_DOWNLOAD_PAYMENT_REPORT3, CommandType.StoredProcedure)

        Return dt

    End Function

    Public Function f_SEL_PAYMENT_REPORT_DOWNLOAD(ByVal CLAIMNO As String, ByVal POLICYNO As String, _
                                 ByVal FLAGCLAIMNO As String, ByVal FLAGPOLICYNO As String, _
                                 ByVal CREATEDBY As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(4) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@CLAIMNO", SqlDbType.VarChar)
        oParam(0).Value = CType(CLAIMNO, String)

        oParam(1) = New SqlClient.SqlParameter("@POLICYNO", SqlDbType.VarChar)
        oParam(1).Value = CType(POLICYNO, String)

        oParam(2) = New SqlClient.SqlParameter("@FLAGCLAIMNO", SqlDbType.VarChar)
        oParam(2).Value = CType(FLAGCLAIMNO, String)

        oParam(3) = New SqlClient.SqlParameter("@FLAGPOLICYNO", SqlDbType.VarChar)
        oParam(3).Value = CType(FLAGPOLICYNO, String)

        oParam(4) = New SqlClient.SqlParameter("@CREATEDBY", SqlDbType.VarChar)
        oParam(4).Value = CType(CREATEDBY, String)


        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Sel_PAYMENT_REPORT_DOWNLOAD, CommandType.StoredProcedure, oParam)

        Return dt

    End Function

    Public Function f_SEL_EnrollMent(ByVal BANKSTATEMENTFROM As Date, ByVal BANKSTATEMENTTO As Date, _
                                     ByVal NAMEOFPOLICY As String, ByVal POLICYNO As String, _
                                     ByVal FLAGBANKSTATEMENT As String, ByVal FLAGNAMEOFPOLICY As String, _
                                     ByVal FLAGPOLICYNO As String, ByVal ENTITY As String, ByVal CREATEDBY As String)
        'ByVal CARDNUMBER As String, ByVal FLAGCARDNUMBER As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(8) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@DAY_FROM_MEMBER_EFFECTIVEDATE", SqlDbType.Date)
        oParam(0).Value = CType(BANKSTATEMENTFROM, Date)

        oParam(1) = New SqlClient.SqlParameter("@DAY_TO_MEMBER_EFFECTIVEDATE", SqlDbType.Date)
        oParam(1).Value = CType(BANKSTATEMENTTO, Date)

        oParam(2) = New SqlClient.SqlParameter("@NAMEOFPOLICY", SqlDbType.VarChar)
        oParam(2).Value = CType(NAMEOFPOLICY, String)

        oParam(3) = New SqlClient.SqlParameter("@POLICYNO", SqlDbType.VarChar)
        oParam(3).Value = CType(POLICYNO, String)

        oParam(4) = New SqlClient.SqlParameter("@FLAGBANKSTATEMENT", SqlDbType.VarChar)
        oParam(4).Value = CType(FLAGBANKSTATEMENT, String)

        oParam(5) = New SqlClient.SqlParameter("@FLAGNAMEOFPOLICY", SqlDbType.VarChar)
        oParam(5).Value = CType(FLAGNAMEOFPOLICY, String)

        oParam(6) = New SqlClient.SqlParameter("@FLAGPOLICYNO", SqlDbType.VarChar)
        oParam(6).Value = CType(FLAGPOLICYNO, String)

        oParam(7) = New SqlClient.SqlParameter("@CREATEDBY", SqlDbType.VarChar)
        oParam(7).Value = CType(CREATEDBY, String)

        oParam(8) = New SqlClient.SqlParameter("@ENTITY", SqlDbType.VarChar)
        oParam(8).Value = CType(ENTITY, String)

        'oParam(9) = New SqlClient.SqlParameter("@CARDNUMBER", SqlDbType.VarChar)
        'oParam(9).Value = CType(CARDNUMBER, String)

        'oParam(10) = New SqlClient.SqlParameter("@FLAGCARDNUMBER", SqlDbType.VarChar)
        'oParam(10).Value = CType(FLAGCARDNUMBER, String)


        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Sel_EnrollMent_List, CommandType.StoredProcedure, oParam)

        Return dt

    End Function
    Public Function f_SEL_MST_COST_SHARE() As DataTable

        Dim dt As New DataTable


        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Sel_UPGRADE_COST_SHARE, CommandType.StoredProcedure)

        Return dt

    End Function
    Public Function f_SEL_MST_PAYMENTDETAILS() As DataTable

        Dim dt As New DataTable


        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Sel_PAYMENTDETAILS3, CommandType.StoredProcedure)

        Return dt

    End Function

    Public Function f_SEL_MST_CURRENCY() As DataTable

        Dim dt As New DataTable


        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Sel_CURRENCY, CommandType.StoredProcedure)

        Return dt

    End Function

    Public Function f_SEL_MST_CURRENCY_ALL() As DataTable

        Dim dt As New DataTable


        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Sel_MST_CURRENCY, CommandType.StoredProcedure)

        Return dt

    End Function

    Public Function f_SEL_MST_FCR_TASKS(ByVal IDPRODUCT As String, ByVal CLAIMNO As String, ByVal POLICYNO As String, _
                                        ByVal CREATEDBY As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(3) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@IDPRODUCT", SqlDbType.VarChar)
        oParam(0).Value = CType(IDPRODUCT, String)

        oParam(1) = New SqlClient.SqlParameter("@CLAIMNO", SqlDbType.VarChar)
        oParam(1).Value = CType(CLAIMNO, String)

        oParam(2) = New SqlClient.SqlParameter("@POLICYNO", SqlDbType.VarChar)
        oParam(2).Value = CType(POLICYNO, String)

        oParam(3) = New SqlClient.SqlParameter("@CREATEDBY", SqlDbType.VarChar)
        oParam(3).Value = CType(CREATEDBY, String)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Sel_MST_FCR_TASKS, CommandType.StoredProcedure, oParam)

        Return dt

    End Function

    Public Function f_SEL_FBA_DETAIL_LIST(ByVal IDX As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@IDX", SqlDbType.VarChar)
        oParam(0).Value = CType(IDX, String)


        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Sel_FBA_DETAIL_LIST, CommandType.StoredProcedure, oParam)

        Return dt

    End Function
    Public Function f_SEL_FBA_DETAIL_LIST2(ByVal IDX As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@IDX", SqlDbType.VarChar)
        oParam(0).Value = CType(IDX, String)


        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Sel_FBA_DETAIL_LIST2, CommandType.StoredProcedure, oParam)

        Return dt

    End Function

    Public Function f_SEL_ENROLLMENT_ALL(ByVal IDX As String, ByVal ENTITY As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(1) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@IDX", SqlDbType.VarChar)
        oParam(0).Value = CType(IDX, String)

        oParam(1) = New SqlClient.SqlParameter("@ENTITY", SqlDbType.VarChar)
        oParam(1).Value = CType(ENTITY, String)



        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Sel_EnrollMent_ALL, CommandType.StoredProcedure, oParam)

        Return dt

    End Function

    Public Function f_SEL_PAYMENT_REPORT(ByVal IDX As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@IDX", SqlDbType.VarChar)
        oParam(0).Value = CType(IDX, String)


        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Sel_PAYMENT_REPORT, CommandType.StoredProcedure, oParam)

        Return dt

    End Function

    Public Function f_SEL_INCOMPLETE_DOCUMENT(ByVal idxFCR As String, ByVal CLAIMNO As String, ByVal POLICYNO As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(2) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@idxFCR", SqlDbType.VarChar)
        oParam(0).Value = CType(idxFCR, String)

        oParam(1) = New SqlClient.SqlParameter("@CLAIMNO", SqlDbType.VarChar)
        oParam(1).Value = CType(CLAIMNO, String)

        oParam(2) = New SqlClient.SqlParameter("@POLICYNO", SqlDbType.VarChar)
        oParam(2).Value = CType(POLICYNO, String)


        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Sel_INCOMPLETE_DOC, CommandType.StoredProcedure, oParam)

        Return dt

    End Function

    Public Function f_SEL_COMPLETE_DOCUMENT(ByVal idxFCR As String, ByVal CLAIMNO As String, ByVal POLICYNO As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(2) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@idxFCR", SqlDbType.VarChar)
        oParam(0).Value = CType(idxFCR, String)

        oParam(1) = New SqlClient.SqlParameter("@CLAIMNO", SqlDbType.VarChar)
        oParam(1).Value = CType(CLAIMNO, String)

        oParam(2) = New SqlClient.SqlParameter("@POLICYNO", SqlDbType.VarChar)
        oParam(2).Value = CType(POLICYNO, String)


        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Sel_COMPLETE_DOC, CommandType.StoredProcedure, oParam)

        Return dt

    End Function
    Public Function f_SEL_ReasonInves(ByVal idxFCR As String, ByVal CLAIMNO As String, ByVal POLICYNO As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(2) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@idxFCR", SqlDbType.VarChar)
        oParam(0).Value = CType(idxFCR, String)

        oParam(1) = New SqlClient.SqlParameter("@CLAIMNO", SqlDbType.VarChar)
        oParam(1).Value = CType(CLAIMNO, String)

        oParam(2) = New SqlClient.SqlParameter("@POLICYNO", SqlDbType.VarChar)
        oParam(2).Value = CType(POLICYNO, String)


        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_SEL_ReasonInves, CommandType.StoredProcedure, oParam)

        Return dt

    End Function

    Public Function f_SEL_POL_DOCUMENT(ByVal idxFCR As String, ByVal CLAIMNO As String, ByVal POLICYNO As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(2) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@idxFCR", SqlDbType.VarChar)
        oParam(0).Value = CType(idxFCR, String)

        oParam(1) = New SqlClient.SqlParameter("@CLAIMNO", SqlDbType.VarChar)
        oParam(1).Value = CType(CLAIMNO, String)

        oParam(2) = New SqlClient.SqlParameter("@POLICYNO", SqlDbType.VarChar)
        oParam(2).Value = CType(POLICYNO, String)


        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Sel_POL_DOC, CommandType.StoredProcedure, oParam)

        Return dt

    End Function


    Public Function f_SEL_HOSPITAL(ByVal HOSPITALNAME As String, ByVal ROOMTYPE As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(1) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@HOSPITALNAME", SqlDbType.VarChar)
        oParam(0).Value = CType(HOSPITALNAME, String)

        oParam(1) = New SqlClient.SqlParameter("@ROOMTYPE", SqlDbType.VarChar)
        oParam(1).Value = CType(ROOMTYPE, String)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Sel_HOSPITAL, CommandType.StoredProcedure, oParam)

        Return dt

    End Function

    Public Function f_SEL_HOSPITAL_ROOM_TYPE(ByVal ROOMTYPE As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@ROOMTYPE", SqlDbType.VarChar)
        oParam(0).Value = CType(ROOMTYPE, String)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Sel_HOSPITAL_ROOM_TYPE, CommandType.StoredProcedure, oParam)

        Return dt

    End Function

    Public Function f_SEL_FBA_LIST(ByVal CLAIMNO As String, ByVal POLICYNO As String, _
                                   ByVal FLAGCLAIMNO As String, ByVal FLAGPOLICYNO As String, _
                                   ByVal CREATEDBY As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(4) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@CLAIMNO", SqlDbType.VarChar)
        oParam(0).Value = CType(CLAIMNO, String)

        oParam(1) = New SqlClient.SqlParameter("@POLICYNO", SqlDbType.VarChar)
        oParam(1).Value = CType(POLICYNO, String)

        oParam(2) = New SqlClient.SqlParameter("@FLAGCLAIMNO", SqlDbType.VarChar)
        oParam(2).Value = CType(FLAGCLAIMNO, String)

        oParam(3) = New SqlClient.SqlParameter("@FLAGPOLICYNO", SqlDbType.VarChar)
        oParam(3).Value = CType(FLAGPOLICYNO, String)

        oParam(4) = New SqlClient.SqlParameter("@CREATEDBY", SqlDbType.VarChar)
        oParam(4).Value = CType(CREATEDBY, String)


        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Sel_FBA_LIST, CommandType.StoredProcedure, oParam)

        Return dt

    End Function

    Public Function f_SEL_FCR_APPROVED(ByVal CLAIMNO As String, ByVal POLICYNO As String, _
                                   ByVal FLAGCLAIMNO As String, ByVal FLAGPOLICYNO As String, _
                                   ByVal CREATEDBY As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(4) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@CLAIMNO", SqlDbType.VarChar)
        oParam(0).Value = CType(CLAIMNO, String)

        oParam(1) = New SqlClient.SqlParameter("@POLICYNO", SqlDbType.VarChar)
        oParam(1).Value = CType(POLICYNO, String)

        oParam(2) = New SqlClient.SqlParameter("@FLAGCLAIMNO", SqlDbType.VarChar)
        oParam(2).Value = CType(FLAGCLAIMNO, String)

        oParam(3) = New SqlClient.SqlParameter("@FLAGPOLICYNO", SqlDbType.VarChar)
        oParam(3).Value = CType(FLAGPOLICYNO, String)

        oParam(4) = New SqlClient.SqlParameter("@CREATEDBY", SqlDbType.VarChar)
        oParam(4).Value = CType(CREATEDBY, String)


        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Sel_FCR_APPROVED, CommandType.StoredProcedure, oParam)

        Return dt

    End Function


    Public Function f_SEL_FBANONMED(ByVal CLAIMNO As String, ByVal POLICYNO As String, _
                                     ByVal CREATEDBY As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(2) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@CLAIMNO", SqlDbType.VarChar)
        oParam(0).Value = CType(CLAIMNO, String)

        oParam(1) = New SqlClient.SqlParameter("@POLICYNO", SqlDbType.VarChar)
        oParam(1).Value = CType(POLICYNO, String)

        oParam(2) = New SqlClient.SqlParameter("@CREATEDBY", SqlDbType.VarChar)
        oParam(2).Value = CType(CREATEDBY, String)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Sel_FBANONMED, CommandType.StoredProcedure, oParam)

        Return dt

    End Function
    Public Function f_SEL_FBANONMED2(ByVal CLAIMNO As String, ByVal POLICYNO As String, _
                                     ByVal CREATEDBY As String, ByVal IDXFBA As String, ByVal PAYDETAILS As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(4) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@CLAIMNO", SqlDbType.VarChar)
        oParam(0).Value = CType(CLAIMNO, String)

        oParam(1) = New SqlClient.SqlParameter("@POLICYNO", SqlDbType.VarChar)
        oParam(1).Value = CType(POLICYNO, String)

        oParam(2) = New SqlClient.SqlParameter("@CREATEDBY", SqlDbType.VarChar)
        oParam(2).Value = CType(CREATEDBY, String)

        oParam(3) = New SqlClient.SqlParameter("@IDXFBA", SqlDbType.VarChar)
        oParam(3).Value = CType(IDXFBA, String)

        oParam(4) = New SqlClient.SqlParameter("@PAYDETAILS", SqlDbType.VarChar)
        oParam(4).Value = CType(PAYDETAILS, String)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Sel_FBANONMED2, CommandType.StoredProcedure, oParam)

        Return dt

    End Function
    Public Function f_SEL_FBA_CashBack_Benefit(ByVal CLAIMNO As String, ByVal POLICYNO As String, _
                                     ByVal CREATEDBY As String, ByVal IDXFBA As String, ByVal PAYDETAILS As String, ByVal EXCHRATE As Decimal) As DataTable

        Dim dt As New DataTable
        Dim oParam(5) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@CLAIMNO", SqlDbType.VarChar)
        oParam(0).Value = CType(CLAIMNO, String)

        oParam(1) = New SqlClient.SqlParameter("@POLICYNO", SqlDbType.VarChar)
        oParam(1).Value = CType(POLICYNO, String)

        oParam(2) = New SqlClient.SqlParameter("@CREATEDBY", SqlDbType.VarChar)
        oParam(2).Value = CType(CREATEDBY, String)

        oParam(3) = New SqlClient.SqlParameter("@IDXFBA", SqlDbType.VarChar)
        oParam(3).Value = CType(IDXFBA, String)

        oParam(4) = New SqlClient.SqlParameter("@PAYDETAILS", SqlDbType.VarChar)
        oParam(4).Value = CType(PAYDETAILS, String)

        oParam(5) = New SqlClient.SqlParameter("@EXCHRATE", SqlDbType.VarChar)
        oParam(5).Value = CType(EXCHRATE, String)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_SEL_FBACASHBACK_BENEFIT, CommandType.StoredProcedure, oParam)

        Return dt

    End Function

    Public Function f_SelFBA_GRIDVIEW(ByVal CLAIMNO As String, ByVal POLICYNO As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(1) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@CLAIMNO", SqlDbType.VarChar)
        oParam(0).Value = CType(CLAIMNO, String)

        oParam(1) = New SqlClient.SqlParameter("@POLICYNO", SqlDbType.VarChar)
        oParam(1).Value = CType(POLICYNO, String)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_SEL_FBA_GRIDVIEW, CommandType.StoredProcedure, oParam)

        Return dt

    End Function
    Public Function f_SEL_OBT_REPORT() '(ByVal CLAIMNO As String, ByVal POLICYNO As String) As DataTable

        Dim dt As New DataTable
        'Dim oParam(1) As SqlParameter

        'oParam(0) = New SqlClient.SqlParameter("@CLAIMNO", SqlDbType.VarChar)
        'oParam(0).Value = CType(CLAIMNO, String)

        'oParam(1) = New SqlClient.SqlParameter("@POLICYNO", SqlDbType.VarChar)
        'oParam(1).Value = CType(POLICYNO, String)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_SEL_OBT_REPORT, CommandType.StoredProcedure) ', oParam)

        Return dt

    End Function
    Public Function f_SEL_NONMED_REPORT() '(ByVal CLAIMNO As String, ByVal POLICYNO As String) As DataTable

        Dim dt As New DataTable
        'Dim oParam(1) As SqlParameter

        'oParam(0) = New SqlClient.SqlParameter("@CLAIMNO", SqlDbType.VarChar)
        'oParam(0).Value = CType(CLAIMNO, String)

        'oParam(1) = New SqlClient.SqlParameter("@POLICYNO", SqlDbType.VarChar)
        'oParam(1).Value = CType(POLICYNO, String)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_SEL_NONMED_REPORT, CommandType.StoredProcedure) ', oParam)

        Return dt

    End Function

    Public Function f_SEL_FBAOBT(ByVal CLAIMNO As String, ByVal POLICYNO As String, _
                                     ByVal CREATEDBY As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(2) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@CLAIMNO", SqlDbType.VarChar)
        oParam(0).Value = CType(CLAIMNO, String)

        oParam(1) = New SqlClient.SqlParameter("@POLICYNO", SqlDbType.VarChar)
        oParam(1).Value = CType(POLICYNO, String)

        oParam(2) = New SqlClient.SqlParameter("@CREATEDBY", SqlDbType.VarChar)
        oParam(2).Value = CType(CREATEDBY, String)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Sel_FBAOBT, CommandType.StoredProcedure, oParam)

        Return dt

    End Function

    Public Function f_SEL_FBAOBT2(ByVal CLAIMNO As String, ByVal POLICYNO As String, _
                                    ByVal CREATEDBY As String, ByVal IDXFBA As String, ByVal PAYDETAILS As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(4) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@CLAIMNO", SqlDbType.VarChar)
        oParam(0).Value = CType(CLAIMNO, String)

        oParam(1) = New SqlClient.SqlParameter("@POLICYNO", SqlDbType.VarChar)
        oParam(1).Value = CType(POLICYNO, String)

        oParam(2) = New SqlClient.SqlParameter("@CREATEDBY", SqlDbType.VarChar)
        oParam(2).Value = CType(CREATEDBY, String)

        oParam(3) = New SqlClient.SqlParameter("@IDXFBA", SqlDbType.VarChar)
        oParam(3).Value = CType(IDXFBA, String)

        oParam(4) = New SqlClient.SqlParameter("@PAYDETAILS", SqlDbType.VarChar)
        oParam(4).Value = CType(PAYDETAILS, String)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Sel_FBAOBT2, CommandType.StoredProcedure, oParam)

        Return dt

    End Function

    Public Function f_SEL_FCR_APPROVED_DETAIL_FBA(ByVal IDX As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@IDX", SqlDbType.VarChar)
        oParam(0).Value = CType(IDX, String)


        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Sel_FCR_APPROVED_DETAIL, CommandType.StoredProcedure, oParam)

        Return dt

    End Function
    Public Function f_SEL_FCR_DETAIL_PENDING(ByVal IDX As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@IDX", SqlDbType.VarChar)
        oParam(0).Value = CType(IDX, String)


        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Sel_FCR_DETAIL_PENDING, CommandType.StoredProcedure, oParam)

        Return dt

    End Function
    Public Function f_SEL_FCR_DETAIL_PENDING_NEW(ByVal IDX As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@IDX", SqlDbType.VarChar)
        oParam(0).Value = CType(IDX, String)


        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Sel_FCR_DETAIL_PENDING_NEW, CommandType.StoredProcedure, oParam)

        Return dt

    End Function

    Public Function f_SEL_FCR_FROM_GRIDVIEW(ByVal ClaimNo As String, ByVal PolicyNo As String, ByVal PAYMENTDETAILS As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(2) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@CLAIMNO", SqlDbType.VarChar)
        oParam(0).Value = CType(ClaimNo, String)

        oParam(1) = New SqlClient.SqlParameter("@POLICYNO", SqlDbType.VarChar)
        oParam(1).Value = CType(PolicyNo, String)

        oParam(2) = New SqlClient.SqlParameter("@PAYMENTDETAILS", SqlDbType.VarChar)
        oParam(2).Value = CType(PAYMENTDETAILS, String)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_SEL_FCR_FROM_GRIDVIEW, CommandType.StoredProcedure, oParam)

        Return dt

    End Function
    Public Function f_SEL_FBA_FROM_GRIDVIEW(ByVal ClaimNo As String, ByVal PolicyNo As String, ByVal PAYMENTDETAILS As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(2) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@CLAIMNO", SqlDbType.VarChar)
        oParam(0).Value = CType(ClaimNo, String)

        oParam(1) = New SqlClient.SqlParameter("@POLICYNO", SqlDbType.VarChar)
        oParam(1).Value = CType(PolicyNo, String)

        oParam(2) = New SqlClient.SqlParameter("@PAYMENTDETAILS", SqlDbType.VarChar)
        oParam(2).Value = CType(PAYMENTDETAILS, String)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_SEL_FBA_FROM_GRIDVIEW, CommandType.StoredProcedure, oParam)

        Return dt

    End Function

    Public Function f_SEL_FBA_DETAIL(ByVal IDX As String) As DataTable
        'ByVal ClaimNo As String, ByVal PolicyNo As String, _
        'ByVal OTBDDX As String, ByVal NONMEDIS As String, _
        'ByVal CREATEDBY As String


        Dim dt As New DataTable
        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@IDX", SqlDbType.VarChar)
        oParam(0).Value = CType(IDX, String)

        'oParam(2) = New SqlClient.SqlParameter("@PolicyNo", SqlDbType.VarChar)
        'oParam(2).Value = CType(PolicyNo, String)

        'oParam(3) = New SqlClient.SqlParameter("@OTBDDX", SqlDbType.VarChar)
        'oParam(3).Value = CType(OTBDDX, String)

        'oParam(4) = New SqlClient.SqlParameter("@NONMEDIS", SqlDbType.VarChar)
        'oParam(4).Value = CType(NONMEDIS, String)

        'oParam(5) = New SqlClient.SqlParameter("@POLICYNO", SqlDbType.VarChar)
        'oParam(5).Value = CType(PolicyNo, String)


        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Sel_FBA_DETAIL, CommandType.StoredProcedure, oParam)

        Return dt

    End Function
    Public Function f_SEL_FBA_DETAIL2(ByVal IDX As String) As DataTable
        'ByVal ClaimNo As String, ByVal PolicyNo As String, _
        'ByVal OTBDDX As String, ByVal NONMEDIS As String, _
        'ByVal CREATEDBY As String


        Dim dt As New DataTable
        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@IDX", SqlDbType.VarChar)
        oParam(0).Value = CType(IDX, String)

        'oParam(2) = New SqlClient.SqlParameter("@PolicyNo", SqlDbType.VarChar)
        'oParam(2).Value = CType(PolicyNo, String)

        'oParam(3) = New SqlClient.SqlParameter("@OTBDDX", SqlDbType.VarChar)
        'oParam(3).Value = CType(OTBDDX, String)

        'oParam(4) = New SqlClient.SqlParameter("@NONMEDIS", SqlDbType.VarChar)
        'oParam(4).Value = CType(NONMEDIS, String)

        'oParam(5) = New SqlClient.SqlParameter("@POLICYNO", SqlDbType.VarChar)
        'oParam(5).Value = CType(PolicyNo, String)


        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Sel_FBA_DETAIL2, CommandType.StoredProcedure, oParam)

        Return dt

    End Function
    Public Function f_sel_CountFBA(ByVal IDXFBA As String) As DataTable
       
        Dim dt As New DataTable
        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@IDXFBA", SqlDbType.VarChar)
        oParam(0).Value = CType(IDXFBA, String)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Count_FBA, CommandType.StoredProcedure, oParam)

        Return dt

    End Function

    Public Function f_SEL_FBA_DETAIL3(ByVal IDX As String, ByVal IDXFBA As String) As DataTable
        'ByVal ClaimNo As String, ByVal PolicyNo As String, _
        'ByVal OTBDDX As String, ByVal NONMEDIS As String, _
        'ByVal CREATEDBY As String


        Dim dt As New DataTable
        Dim oParam(1) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@IDX", SqlDbType.VarChar)
        oParam(0).Value = CType(IDX, String)

        oParam(1) = New SqlClient.SqlParameter("@IDXFBA", SqlDbType.VarChar)
        oParam(1).Value = CType(IDXFBA, String)


        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Sel_FBA_DETAIL3, CommandType.StoredProcedure, oParam)

        Return dt

    End Function


    Public Function f_CheckCurr_AFI(ByVal _AcctNumb As String, ByVal _entity As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@ACCT_NO", SqlDbType.VarChar)
        oParam(0).Value = CType(_AcctNumb, String)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_CHECK_CURRENCY_AFI, CommandType.StoredProcedure, oParam)

        Return dt

    End Function
    Public Function f_Sel_MST_PROD(ByVal COORPCODE As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@COORPCODE", SqlDbType.VarChar)
        oParam(0).Value = CType(COORPCODE, String)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Sel_MST_PRODUCT, CommandType.StoredProcedure, oParam)

        Return dt

    End Function


    Public Function f_SEL_INC_DOC() As DataTable

        Dim dt As New DataTable


        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Sel_MST_INCOMPLETE_DOC, CommandType.StoredProcedure)

        Return dt

    End Function

    Public Function f_SEL_COMPLETE_DOC() As DataTable

        Dim dt As New DataTable


        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Sel_MST_COMPLETE_DOC, CommandType.StoredProcedure)

        Return dt

    End Function

    Public Function f_SEL_POLICY_FCR() As DataTable

        Dim dt As New DataTable


        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Sel_MST_POLICY_FCR, CommandType.StoredProcedure)

        Return dt

    End Function


    Public Function f_Sel_BorderauxDetail(ByVal _IDX As String, ByVal _entity As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@IDX", SqlDbType.VarChar)
        oParam(0).Value = CType(_IDX, String)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Sel_Borderaux_DETAIL, CommandType.StoredProcedure, oParam)

        Return dt

    End Function

    Public Function f_Sel_BorderauxDetail1(ByVal _IDX As String, ByVal _entity As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@IDX", SqlDbType.VarChar)
        oParam(0).Value = CType(_IDX, String)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Sel_Borderaux_DETAIL1, CommandType.StoredProcedure, oParam)

        Return dt

    End Function
    Public Function f_Sel_BorderauxDetail2(ByVal _IDX As String, ByVal _entity As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@IDX", SqlDbType.VarChar)
        oParam(0).Value = CType(_IDX, String)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Sel_Borderaux_DETAIL2, CommandType.StoredProcedure, oParam)

        Return dt

    End Function

    Public Function f_Sel_BorderauxDetail3(ByVal _IDX As String, ByVal _entity As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@IDX", SqlDbType.VarChar)
        oParam(0).Value = CType(_IDX, String)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Sel_Borderaux_DETAIL3, CommandType.StoredProcedure, oParam)

        Return dt

    End Function

    Public Function f_Sel_BorderauxDetail4(ByVal _IDX As String, ByVal _entity As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@IDX", SqlDbType.VarChar)
        oParam(0).Value = CType(_IDX, String)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Sel_Borderaux_DETAIL4, CommandType.StoredProcedure, oParam)

        Return dt

    End Function

    Public Function f_Sel_FCR(ByVal _IDX As String, ByVal _entity As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@IDX", SqlDbType.VarChar)
        oParam(0).Value = CType(_IDX, String)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Sel_FCR, CommandType.StoredProcedure, oParam)

        Return dt

    End Function

    Public Function f_Sel_FCR_SMS(ByVal _IDX As String, ByVal _entity As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@IDX", SqlDbType.VarChar)
        oParam(0).Value = CType(_IDX, String)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Sel_FCR_SMS, CommandType.StoredProcedure, oParam)

        Return dt

    End Function

    Public Function f_Sel_FCR_PRODUCT(ByVal _IDX As String, ByVal _entity As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@IDX", SqlDbType.VarChar)
        oParam(0).Value = CType(_IDX, String)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Sel_FCR_PRODUCT, CommandType.StoredProcedure, oParam)

        Return dt

    End Function
    Public Function f_Sel_CLAIM_SUMMARY_LETTER_LIST(ByVal CLAIMNO As String, ByVal POLICYNO As String, _
                                        ByVal FLAGCLAIMNO As String, ByVal FLAGPOLICYNO As String, _
                                        ByVal FLAGPAYDETAILS As String, ByVal PAYDETAILS As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(5) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@CLAIMNO", SqlDbType.VarChar)
        oParam(0).Value = CType(CLAIMNO, String)

        oParam(1) = New SqlClient.SqlParameter("@POLICYNO", SqlDbType.VarChar)
        oParam(1).Value = CType(POLICYNO, String)

        oParam(2) = New SqlClient.SqlParameter("@FLAGCLAIMNO", SqlDbType.VarChar)
        oParam(2).Value = CType(FLAGCLAIMNO, String)

        oParam(3) = New SqlClient.SqlParameter("@FLAGPOLICYNO", SqlDbType.VarChar)
        oParam(3).Value = CType(FLAGPOLICYNO, String)

        oParam(4) = New SqlClient.SqlParameter("@FLAGPAYDETAILS", SqlDbType.VarChar)
        oParam(4).Value = CType(FLAGPAYDETAILS, String)

        oParam(5) = New SqlClient.SqlParameter("@PAYDETAILS", SqlDbType.VarChar)
        oParam(5).Value = CType(PAYDETAILS, String)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Sel_CLAIM_SUMMARY_LETTER_LIST, CommandType.StoredProcedure, oParam)

        Return dt

    End Function

    Public Function f_Sel_FCR_Pending(ByVal NAMEINSURED As String, ByVal CLAIMNO As String, ByVal POLICYNO As String, _
                                        ByVal FLAGNAMEINSURED As String, ByVal FLAGCLAIMNO As String, ByVal FLAGPOLICYNO As String, _
                                        ByVal FLAGSTAT As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(6) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@NAMEINSURED", SqlDbType.VarChar)
        oParam(0).Value = CType(NAMEINSURED, String)

        oParam(1) = New SqlClient.SqlParameter("@CLAIMNO", SqlDbType.VarChar)
        oParam(1).Value = CType(CLAIMNO, String)

        oParam(2) = New SqlClient.SqlParameter("@POLICYNO", SqlDbType.VarChar)
        oParam(2).Value = CType(POLICYNO, String)

        oParam(3) = New SqlClient.SqlParameter("@FLAGNAMEINSURED", SqlDbType.VarChar)
        oParam(3).Value = CType(FLAGNAMEINSURED, String)

        oParam(4) = New SqlClient.SqlParameter("@FLAGCLAIMNO", SqlDbType.VarChar)
        oParam(4).Value = CType(FLAGCLAIMNO, String)

        oParam(5) = New SqlClient.SqlParameter("@FLAGPOLICYNO", SqlDbType.VarChar)
        oParam(5).Value = CType(FLAGPOLICYNO, String)

        oParam(6) = New SqlClient.SqlParameter("@FLAGSTAT", SqlDbType.VarChar)
        oParam(6).Value = CType(FLAGSTAT, String)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Sel_FCR_PENDING, CommandType.StoredProcedure, oParam)

        Return dt

    End Function
    Public Function f_Sel_FCR_ALL(ByVal _ClaimNo As String, ByVal _PolicyNo As String, ByVal _INVOICENO As String, ByVal _entity As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(2) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@CLAIMNO", SqlDbType.VarChar)
        oParam(0).Value = CType(_ClaimNo, String)

        oParam(1) = New SqlClient.SqlParameter("@POLICYNO", SqlDbType.VarChar)
        oParam(1).Value = CType(_PolicyNo, String)

        oParam(2) = New SqlClient.SqlParameter("@INVOICENO", SqlDbType.VarChar)
        oParam(2).Value = CType(_INVOICENO, String)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Sel_FCR_ALL, CommandType.StoredProcedure, oParam)

        Return dt

    End Function
    Public Function f_Sel_FCR_Detail(ByVal _ClaimNo As String, ByVal _entity As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@CLAIMNO", SqlDbType.VarChar)
        oParam(0).Value = CType(_ClaimNo, String)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Sel_FCR_Detail, CommandType.StoredProcedure, oParam)

        Return dt

    End Function


    Public Function f_SEL_Borderaux(ByVal _DayFromEffDate As Date, ByVal _DayToEffDate As Date, _
                                    ByVal _DayFromExpDate As Date, ByVal _DayToxpDate As Date, _
                                    ByVal _DayFromClaimRecDate As Date, ByVal _DayToClaimRecDate As Date, _
                                    ByVal _DayFromPaymentDate As Date, ByVal _DayToPaymentDate As Date, _
                                    ByVal _DayFromDeclinedDate As Date, ByVal _DayToDeclinedDate As Date, _
                                    ByVal _NameofPolicy As String, ByVal _NameofInsured As String, _
                                    ByVal _PolicyNo As String, ByVal _ClaimNo As String, _
                                    ByVal _InvoiceNo As String, ByVal _CoorporateCode As String, _
                                    ByVal _ProdCode As String, ByVal _CountryClaim As String, _
                                    ByVal _ClaimStatCode As String, ByVal _Remarks As String, _
                                    ByVal _TreatProvCode As String, _
                                    ByVal _FlagDayEffDate As String, ByVal _FlagDayExpDate As String, _
                                    ByVal _FlagDayClaimRecDate As String, ByVal _FlagDayPaymentDate As String, _
                                    ByVal _FlagDayDeclinedDate As String, ByVal _FlagNameofPol As String, _
                                    ByVal _FlagNameofInsured As String, ByVal _FlagPolicyNo As String, _
                                    ByVal _FlagClaimNo As String, ByVal _FlagInvoiceNo As String, _
                                    ByVal _FlagCoorporateCode As String, ByVal _FlagProdCode As String, _
                                    ByVal _FlagCountryClaim As String, ByVal _FlagClaimStatusCode As String, _
                                    ByVal _FlagRemarks As String, ByVal _FlagTreatMentProvCode As String, _
                                    ByVal _CreatedBy As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(37) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@DAY_FROM_POLICY_EFFECTIVEDATE", SqlDbType.Date)
        oParam(0).Value = CType(_DayFromEffDate, Date)

        oParam(1) = New SqlClient.SqlParameter("@DAY_TO_POLICY_EFFECTIVEDATE", SqlDbType.Date)
        oParam(1).Value = CType(_DayToEffDate, Date)

        oParam(2) = New SqlClient.SqlParameter("@DAY_FROM_POLICY_EXPDATE", SqlDbType.Date)
        oParam(2).Value = CType(_DayFromExpDate, Date)

        oParam(3) = New SqlClient.SqlParameter("@DAY_TO_POLICY_EXPDATE", SqlDbType.Date)
        oParam(3).Value = CType(_DayToxpDate, Date)

        oParam(4) = New SqlClient.SqlParameter("@DAY_FROM_CLAIM_RECEIVE", SqlDbType.Date)
        oParam(4).Value = CType(_DayFromClaimRecDate, Date)

        oParam(5) = New SqlClient.SqlParameter("@DAY_TO_CLAIM_RECEIVE", SqlDbType.Date)
        oParam(5).Value = CType(_DayToClaimRecDate, Date)

        oParam(6) = New SqlClient.SqlParameter("@DAY_FROM_PAYMENTDATE", SqlDbType.Date)
        oParam(6).Value = CType(_DayFromPaymentDate, Date)

        oParam(7) = New SqlClient.SqlParameter("@DAY_TO_PAYMENTDATE", SqlDbType.Date)
        oParam(7).Value = CType(_DayToPaymentDate, Date)

        oParam(8) = New SqlClient.SqlParameter("@DAY_FROM_DECLINEDATE", SqlDbType.Date)
        oParam(8).Value = CType(_DayFromDeclinedDate, Date)

        oParam(9) = New SqlClient.SqlParameter("@DAY_TO_DECLINEDATE", SqlDbType.Date)
        oParam(9).Value = CType(_DayToDeclinedDate, Date)

        oParam(10) = New SqlClient.SqlParameter("@NAME_POLICY", SqlDbType.VarChar)
        oParam(10).Value = CType(_NameofPolicy, String)

        oParam(11) = New SqlClient.SqlParameter("@NAME_INSURED", SqlDbType.VarChar)
        oParam(11).Value = CType(_NameofInsured, String)

        oParam(12) = New SqlClient.SqlParameter("@POLICYNO", SqlDbType.VarChar)
        oParam(12).Value = CType(_PolicyNo, String)

        oParam(13) = New SqlClient.SqlParameter("@CLAIMNO", SqlDbType.VarChar)
        oParam(13).Value = CType(_ClaimNo, String)

        oParam(14) = New SqlClient.SqlParameter("@INVOICENO", SqlDbType.VarChar)
        oParam(14).Value = CType(_InvoiceNo, String)

        oParam(15) = New SqlClient.SqlParameter("@COORPORATECODE", SqlDbType.VarChar)
        oParam(15).Value = CType(_CoorporateCode, String)

        oParam(16) = New SqlClient.SqlParameter("@PRODUCTCODE", SqlDbType.VarChar)
        oParam(16).Value = CType(_ProdCode, String)

        oParam(17) = New SqlClient.SqlParameter("@COUNTRYCLAIM", SqlDbType.VarChar)
        oParam(17).Value = CType(_CountryClaim, String)

        oParam(18) = New SqlClient.SqlParameter("@CLAIMSTATUSCODE", SqlDbType.VarChar)
        oParam(18).Value = CType(_ClaimStatCode, String)

        oParam(19) = New SqlClient.SqlParameter("@REMARKS", SqlDbType.VarChar)
        oParam(19).Value = CType(_Remarks, String)

        oParam(20) = New SqlClient.SqlParameter("@TREATMENTPROVIDERCODE", SqlDbType.VarChar)
        oParam(20).Value = CType(_TreatProvCode, String)

        ' FLAG
        oParam(21) = New SqlClient.SqlParameter("@FLAG_DAY_POLICY_EFFECTIVEDATE", SqlDbType.VarChar)
        oParam(21).Value = CType(_FlagDayEffDate, String)

        oParam(22) = New SqlClient.SqlParameter("@FLAG_DAY_POLICY_EXPDATE", SqlDbType.VarChar)
        oParam(22).Value = CType(_FlagDayExpDate, String)

        oParam(23) = New SqlClient.SqlParameter("@FLAG_DAY_CLAIM_RECEIVE", SqlDbType.VarChar)
        oParam(23).Value = CType(_FlagDayClaimRecDate, String)

        oParam(24) = New SqlClient.SqlParameter("@FLAG_DAY_PAYMENTDATE", SqlDbType.VarChar)
        oParam(24).Value = CType(_FlagDayPaymentDate, String)

        oParam(25) = New SqlClient.SqlParameter("@FLAG_DAY_DECLINEDATE", SqlDbType.VarChar)
        oParam(25).Value = CType(_FlagDayDeclinedDate, String)

        oParam(26) = New SqlClient.SqlParameter("@FLAG_NAME_POLICY", SqlDbType.VarChar)
        oParam(26).Value = CType(_FlagNameofPol, String)

        oParam(27) = New SqlClient.SqlParameter("@FLAG_NAME_INSURED", SqlDbType.VarChar)
        oParam(27).Value = CType(_FlagNameofInsured, String)

        oParam(28) = New SqlClient.SqlParameter("@FLAG_POLICYNO", SqlDbType.VarChar)
        oParam(28).Value = CType(_FlagPolicyNo, String)

        oParam(29) = New SqlClient.SqlParameter("@FLAG_CLAIMNO", SqlDbType.VarChar)
        oParam(29).Value = CType(_FlagClaimNo, String)

        oParam(30) = New SqlClient.SqlParameter("@FLAG_INVOICENO", SqlDbType.VarChar)
        oParam(30).Value = CType(_FlagInvoiceNo, String)

        oParam(31) = New SqlClient.SqlParameter("@FLAG_COORPORATECODE", SqlDbType.VarChar)
        oParam(31).Value = CType(_FlagCoorporateCode, String)

        oParam(32) = New SqlClient.SqlParameter("@FLAG_PRODUCTCODE", SqlDbType.VarChar)
        oParam(32).Value = CType(_FlagProdCode, String)

        oParam(33) = New SqlClient.SqlParameter("@FLAG_COUNTRYCLAIM", SqlDbType.VarChar)
        oParam(33).Value = CType(_FlagCountryClaim, String)

        oParam(34) = New SqlClient.SqlParameter("@FLAG_CLAIMSTATUSCODE", SqlDbType.VarChar)
        oParam(34).Value = CType(_FlagClaimStatusCode, String)

        oParam(35) = New SqlClient.SqlParameter("@FLAG_REMARKS", SqlDbType.VarChar)
        oParam(35).Value = CType(_FlagRemarks, String)

        oParam(36) = New SqlClient.SqlParameter("@FLAG_TREATMENTPROVIDERCODE", SqlDbType.VarChar)
        oParam(36).Value = CType(_FlagTreatMentProvCode, String)

        oParam(37) = New SqlClient.SqlParameter("@CREATED_BY", SqlDbType.VarChar)
        oParam(37).Value = CType(_CreatedBy, String)


        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Sel_Borderaux, CommandType.StoredProcedure, oParam)

        Return dt

    End Function

    '
    Public Function f_SEL_Borderaux_Cloning(ByVal _DayFromEffDate As Date, ByVal _DayToEffDate As Date, _
                                   ByVal _DayFromExpDate As Date, ByVal _DayToxpDate As Date, _
                                   ByVal _DayFromClaimRecDate As Date, ByVal _DayToClaimRecDate As Date, _
                                   ByVal _DayFromPaymentDate As Date, ByVal _DayToPaymentDate As Date, _
                                   ByVal _DayFromDeclinedDate As Date, ByVal _DayToDeclinedDate As Date, _
                                   ByVal _NameofPolicy As String, ByVal _NameofInsured As String, _
                                   ByVal _PolicyNo As String, ByVal _ClaimNo As String, _
                                   ByVal _InvoiceNo As String, ByVal _CoorporateCode As String, _
                                   ByVal _ProdCode As String, ByVal _CountryClaim As String, _
                                   ByVal _ClaimStatCode As String, ByVal _Remarks As String, _
                                   ByVal _TreatProvCode As String, _
                                   ByVal _FlagDayEffDate As String, ByVal _FlagDayExpDate As String, _
                                   ByVal _FlagDayClaimRecDate As String, ByVal _FlagDayPaymentDate As String, _
                                   ByVal _FlagDayDeclinedDate As String, ByVal _FlagNameofPol As String, _
                                   ByVal _FlagNameofInsured As String, ByVal _FlagPolicyNo As String, _
                                   ByVal _FlagClaimNo As String, ByVal _FlagInvoiceNo As String, _
                                   ByVal _FlagCoorporateCode As String, ByVal _FlagProdCode As String, _
                                   ByVal _FlagCountryClaim As String, ByVal _FlagClaimStatusCode As String, _
                                   ByVal _FlagRemarks As String, ByVal _FlagTreatMentProvCode As String, _
                                   ByVal _CreatedBy As String, ByVal _FlagPayment_details3 As String, ByVal _Payment_details3 As String, _
                                   ByVal _FlagStatusFCR As String, ByVal _StatusFCR As String, ByVal _FlagStatusFBA As String, ByVal _StatusFBA As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(43) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@DAY_FROM_POLICY_EFFECTIVEDATE", SqlDbType.Date)
        oParam(0).Value = CType(_DayFromEffDate, Date)

        oParam(1) = New SqlClient.SqlParameter("@DAY_TO_POLICY_EFFECTIVEDATE", SqlDbType.Date)
        oParam(1).Value = CType(_DayToEffDate, Date)

        oParam(2) = New SqlClient.SqlParameter("@DAY_FROM_POLICY_EXPDATE", SqlDbType.Date)
        oParam(2).Value = CType(_DayFromExpDate, Date)

        oParam(3) = New SqlClient.SqlParameter("@DAY_TO_POLICY_EXPDATE", SqlDbType.Date)
        oParam(3).Value = CType(_DayToxpDate, Date)

        oParam(4) = New SqlClient.SqlParameter("@DAY_FROM_CLAIM_RECEIVE", SqlDbType.Date)
        oParam(4).Value = CType(_DayFromClaimRecDate, Date)

        oParam(5) = New SqlClient.SqlParameter("@DAY_TO_CLAIM_RECEIVE", SqlDbType.Date)
        oParam(5).Value = CType(_DayToClaimRecDate, Date)

        oParam(6) = New SqlClient.SqlParameter("@DAY_FROM_PAYMENTDATE", SqlDbType.Date)
        oParam(6).Value = CType(_DayFromPaymentDate, Date)

        oParam(7) = New SqlClient.SqlParameter("@DAY_TO_PAYMENTDATE", SqlDbType.Date)
        oParam(7).Value = CType(_DayToPaymentDate, Date)

        oParam(8) = New SqlClient.SqlParameter("@DAY_FROM_DECLINEDATE", SqlDbType.Date)
        oParam(8).Value = CType(_DayFromDeclinedDate, Date)

        oParam(9) = New SqlClient.SqlParameter("@DAY_TO_DECLINEDATE", SqlDbType.Date)
        oParam(9).Value = CType(_DayToDeclinedDate, Date)

        oParam(10) = New SqlClient.SqlParameter("@NAME_POLICY", SqlDbType.VarChar)
        oParam(10).Value = CType(_NameofPolicy, String)

        oParam(11) = New SqlClient.SqlParameter("@NAME_INSURED", SqlDbType.VarChar)
        oParam(11).Value = CType(_NameofInsured, String)

        oParam(12) = New SqlClient.SqlParameter("@POLICYNO", SqlDbType.VarChar)
        oParam(12).Value = CType(_PolicyNo, String)

        oParam(13) = New SqlClient.SqlParameter("@CLAIMNO", SqlDbType.VarChar)
        oParam(13).Value = CType(_ClaimNo, String)

        oParam(14) = New SqlClient.SqlParameter("@INVOICENO", SqlDbType.VarChar)
        oParam(14).Value = CType(_InvoiceNo, String)

        oParam(15) = New SqlClient.SqlParameter("@COORPORATECODE", SqlDbType.VarChar)
        oParam(15).Value = CType(_CoorporateCode, String)

        oParam(16) = New SqlClient.SqlParameter("@PRODUCTCODE", SqlDbType.VarChar)
        oParam(16).Value = CType(_ProdCode, String)

        oParam(17) = New SqlClient.SqlParameter("@COUNTRYCLAIM", SqlDbType.VarChar)
        oParam(17).Value = CType(_CountryClaim, String)

        oParam(18) = New SqlClient.SqlParameter("@CLAIMSTATUSCODE", SqlDbType.VarChar)
        oParam(18).Value = CType(_ClaimStatCode, String)

        oParam(19) = New SqlClient.SqlParameter("@REMARKS", SqlDbType.VarChar)
        oParam(19).Value = CType(_Remarks, String)

        oParam(20) = New SqlClient.SqlParameter("@TREATMENTPROVIDERCODE", SqlDbType.VarChar)
        oParam(20).Value = CType(_TreatProvCode, String)

        ' FLAG
        oParam(21) = New SqlClient.SqlParameter("@FLAG_DAY_POLICY_EFFECTIVEDATE", SqlDbType.VarChar)
        oParam(21).Value = CType(_FlagDayEffDate, String)

        oParam(22) = New SqlClient.SqlParameter("@FLAG_DAY_POLICY_EXPDATE", SqlDbType.VarChar)
        oParam(22).Value = CType(_FlagDayExpDate, String)

        oParam(23) = New SqlClient.SqlParameter("@FLAG_DAY_CLAIM_RECEIVE", SqlDbType.VarChar)
        oParam(23).Value = CType(_FlagDayClaimRecDate, String)

        oParam(24) = New SqlClient.SqlParameter("@FLAG_DAY_PAYMENTDATE", SqlDbType.VarChar)
        oParam(24).Value = CType(_FlagDayPaymentDate, String)

        oParam(25) = New SqlClient.SqlParameter("@FLAG_DAY_DECLINEDATE", SqlDbType.VarChar)
        oParam(25).Value = CType(_FlagDayDeclinedDate, String)

        oParam(26) = New SqlClient.SqlParameter("@FLAG_NAME_POLICY", SqlDbType.VarChar)
        oParam(26).Value = CType(_FlagNameofPol, String)

        oParam(27) = New SqlClient.SqlParameter("@FLAG_NAME_INSURED", SqlDbType.VarChar)
        oParam(27).Value = CType(_FlagNameofInsured, String)

        oParam(28) = New SqlClient.SqlParameter("@FLAG_POLICYNO", SqlDbType.VarChar)
        oParam(28).Value = CType(_FlagPolicyNo, String)

        oParam(29) = New SqlClient.SqlParameter("@FLAG_CLAIMNO", SqlDbType.VarChar)
        oParam(29).Value = CType(_FlagClaimNo, String)

        oParam(30) = New SqlClient.SqlParameter("@FLAG_INVOICENO", SqlDbType.VarChar)
        oParam(30).Value = CType(_FlagInvoiceNo, String)

        oParam(31) = New SqlClient.SqlParameter("@FLAG_COORPORATECODE", SqlDbType.VarChar)
        oParam(31).Value = CType(_FlagCoorporateCode, String)

        oParam(32) = New SqlClient.SqlParameter("@FLAG_PRODUCTCODE", SqlDbType.VarChar)
        oParam(32).Value = CType(_FlagProdCode, String)

        oParam(33) = New SqlClient.SqlParameter("@FLAG_COUNTRYCLAIM", SqlDbType.VarChar)
        oParam(33).Value = CType(_FlagCountryClaim, String)

        oParam(34) = New SqlClient.SqlParameter("@FLAG_CLAIMSTATUSCODE", SqlDbType.VarChar)
        oParam(34).Value = CType(_FlagClaimStatusCode, String)

        oParam(35) = New SqlClient.SqlParameter("@FLAG_REMARKS", SqlDbType.VarChar)
        oParam(35).Value = CType(_FlagRemarks, String)

        oParam(36) = New SqlClient.SqlParameter("@FLAG_TREATMENTPROVIDERCODE", SqlDbType.VarChar)
        oParam(36).Value = CType(_FlagTreatMentProvCode, String)

        oParam(37) = New SqlClient.SqlParameter("@CREATED_BY", SqlDbType.VarChar)
        oParam(37).Value = CType(_CreatedBy, String)

        oParam(38) = New SqlClient.SqlParameter("@FLAG_PAYMENTDETAILS3", SqlDbType.VarChar)
        oParam(38).Value = CType(_FlagPayment_details3, String)

        oParam(39) = New SqlClient.SqlParameter("@PAYMENTDETAILS3", SqlDbType.VarChar)
        oParam(39).Value = CType(_Payment_details3, String)

        oParam(40) = New SqlClient.SqlParameter("@FlagStatusFCR", SqlDbType.VarChar)
        oParam(40).Value = CType(_FlagStatusFCR, String)

        oParam(41) = New SqlClient.SqlParameter("@StatusFCR", SqlDbType.VarChar)
        oParam(41).Value = CType(_StatusFCR, String)

        oParam(42) = New SqlClient.SqlParameter("@FlagStatusFBA", SqlDbType.VarChar)
        oParam(42).Value = CType(_FlagStatusFBA, String)

        oParam(43) = New SqlClient.SqlParameter("@StatusFBA", SqlDbType.VarChar)
        oParam(43).Value = CType(_StatusFBA, String)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Sel_Borderaux_Cloning, CommandType.StoredProcedure, oParam)

        Return dt

    End Function
    Public Function f_SEL_FCR_LIST(ByVal _DayFromEffDate As Date, ByVal _DayToEffDate As Date, _
                                   ByVal _DayFromExpDate As Date, ByVal _DayToxpDate As Date, _
                                   ByVal _DayFromClaimRecDate As Date, ByVal _DayToClaimRecDate As Date, _
                                   ByVal _DayFromPaymentDate As Date, ByVal _DayToPaymentDate As Date, _
                                   ByVal _DayFromDeclinedDate As Date, ByVal _DayToDeclinedDate As Date, _
                                   ByVal _NameofPolicy As String, ByVal _NameofInsured As String, _
                                   ByVal _PolicyNo As String, ByVal _ClaimNo As String, _
                                   ByVal _InvoiceNo As String, ByVal _CoorporateCode As String, _
                                   ByVal _ProdCode As String, ByVal _CountryClaim As String, _
                                   ByVal _ClaimStatCode As String, ByVal _Remarks As String, _
                                   ByVal _TreatProvCode As String, _
                                   ByVal _FlagDayEffDate As String, ByVal _FlagDayExpDate As String, _
                                   ByVal _FlagDayClaimRecDate As String, ByVal _FlagDayPaymentDate As String, _
                                   ByVal _FlagDayDeclinedDate As String, ByVal _FlagNameofPol As String, _
                                   ByVal _FlagNameofInsured As String, ByVal _FlagPolicyNo As String, _
                                   ByVal _FlagClaimNo As String, ByVal _FlagInvoiceNo As String, _
                                   ByVal _FlagCoorporateCode As String, ByVal _FlagProdCode As String, _
                                   ByVal _FlagCountryClaim As String, ByVal _FlagClaimStatusCode As String, _
                                   ByVal _FlagRemarks As String, ByVal _FlagTreatMentProvCode As String, _
                                   ByVal _CreatedBy As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(37) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@DAY_FROM_POLICY_EFFECTIVEDATE", SqlDbType.Date)
        oParam(0).Value = CType(_DayFromEffDate, Date)

        oParam(1) = New SqlClient.SqlParameter("@DAY_TO_POLICY_EFFECTIVEDATE", SqlDbType.Date)
        oParam(1).Value = CType(_DayToEffDate, Date)

        oParam(2) = New SqlClient.SqlParameter("@DAY_FROM_POLICY_EXPDATE", SqlDbType.Date)
        oParam(2).Value = CType(_DayFromExpDate, Date)

        oParam(3) = New SqlClient.SqlParameter("@DAY_TO_POLICY_EXPDATE", SqlDbType.Date)
        oParam(3).Value = CType(_DayToxpDate, Date)

        oParam(4) = New SqlClient.SqlParameter("@DAY_FROM_CLAIM_RECEIVE", SqlDbType.Date)
        oParam(4).Value = CType(_DayFromClaimRecDate, Date)

        oParam(5) = New SqlClient.SqlParameter("@DAY_TO_CLAIM_RECEIVE", SqlDbType.Date)
        oParam(5).Value = CType(_DayToClaimRecDate, Date)

        oParam(6) = New SqlClient.SqlParameter("@DAY_FROM_PAYMENTDATE", SqlDbType.Date)
        oParam(6).Value = CType(_DayFromPaymentDate, Date)

        oParam(7) = New SqlClient.SqlParameter("@DAY_TO_PAYMENTDATE", SqlDbType.Date)
        oParam(7).Value = CType(_DayToPaymentDate, Date)

        oParam(8) = New SqlClient.SqlParameter("@DAY_FROM_DECLINEDATE", SqlDbType.Date)
        oParam(8).Value = CType(_DayFromDeclinedDate, Date)

        oParam(9) = New SqlClient.SqlParameter("@DAY_TO_DECLINEDATE", SqlDbType.Date)
        oParam(9).Value = CType(_DayToDeclinedDate, Date)

        oParam(10) = New SqlClient.SqlParameter("@NAME_POLICY", SqlDbType.VarChar)
        oParam(10).Value = CType(_NameofPolicy, String)

        oParam(11) = New SqlClient.SqlParameter("@NAME_INSURED", SqlDbType.VarChar)
        oParam(11).Value = CType(_NameofInsured, String)

        oParam(12) = New SqlClient.SqlParameter("@POLICYNO", SqlDbType.VarChar)
        oParam(12).Value = CType(_PolicyNo, String)

        oParam(13) = New SqlClient.SqlParameter("@CLAIMNO", SqlDbType.VarChar)
        oParam(13).Value = CType(_ClaimNo, String)

        oParam(14) = New SqlClient.SqlParameter("@INVOICENO", SqlDbType.VarChar)
        oParam(14).Value = CType(_InvoiceNo, String)

        oParam(15) = New SqlClient.SqlParameter("@COORPORATECODE", SqlDbType.VarChar)
        oParam(15).Value = CType(_CoorporateCode, String)

        oParam(16) = New SqlClient.SqlParameter("@PRODUCTCODE", SqlDbType.VarChar)
        oParam(16).Value = CType(_ProdCode, String)

        oParam(17) = New SqlClient.SqlParameter("@COUNTRYCLAIM", SqlDbType.VarChar)
        oParam(17).Value = CType(_CountryClaim, String)

        oParam(18) = New SqlClient.SqlParameter("@CLAIMSTATUSCODE", SqlDbType.VarChar)
        oParam(18).Value = CType(_ClaimStatCode, String)

        oParam(19) = New SqlClient.SqlParameter("@REMARKS", SqlDbType.VarChar)
        oParam(19).Value = CType(_Remarks, String)

        oParam(20) = New SqlClient.SqlParameter("@TREATMENTPROVIDERCODE", SqlDbType.VarChar)
        oParam(20).Value = CType(_TreatProvCode, String)

        ' FLAG
        oParam(21) = New SqlClient.SqlParameter("@FLAG_DAY_POLICY_EFFECTIVEDATE", SqlDbType.VarChar)
        oParam(21).Value = CType(_FlagDayEffDate, String)

        oParam(22) = New SqlClient.SqlParameter("@FLAG_DAY_POLICY_EXPDATE", SqlDbType.VarChar)
        oParam(22).Value = CType(_FlagDayExpDate, String)

        oParam(23) = New SqlClient.SqlParameter("@FLAG_DAY_CLAIM_RECEIVE", SqlDbType.VarChar)
        oParam(23).Value = CType(_FlagDayClaimRecDate, String)

        oParam(24) = New SqlClient.SqlParameter("@FLAG_DAY_PAYMENTDATE", SqlDbType.VarChar)
        oParam(24).Value = CType(_FlagDayPaymentDate, String)

        oParam(25) = New SqlClient.SqlParameter("@FLAG_DAY_DECLINEDATE", SqlDbType.VarChar)
        oParam(25).Value = CType(_FlagDayDeclinedDate, String)

        oParam(26) = New SqlClient.SqlParameter("@FLAG_NAME_POLICY", SqlDbType.VarChar)
        oParam(26).Value = CType(_FlagNameofPol, String)

        oParam(27) = New SqlClient.SqlParameter("@FLAG_NAME_INSURED", SqlDbType.VarChar)
        oParam(27).Value = CType(_FlagNameofInsured, String)

        oParam(28) = New SqlClient.SqlParameter("@FLAG_POLICYNO", SqlDbType.VarChar)
        oParam(28).Value = CType(_FlagPolicyNo, String)

        oParam(29) = New SqlClient.SqlParameter("@FLAG_CLAIMNO", SqlDbType.VarChar)
        oParam(29).Value = CType(_FlagClaimNo, String)

        oParam(30) = New SqlClient.SqlParameter("@FLAG_INVOICENO", SqlDbType.VarChar)
        oParam(30).Value = CType(_FlagInvoiceNo, String)

        oParam(31) = New SqlClient.SqlParameter("@FLAG_COORPORATECODE", SqlDbType.VarChar)
        oParam(31).Value = CType(_FlagCoorporateCode, String)

        oParam(32) = New SqlClient.SqlParameter("@FLAG_PRODUCTCODE", SqlDbType.VarChar)
        oParam(32).Value = CType(_FlagProdCode, String)

        oParam(33) = New SqlClient.SqlParameter("@FLAG_COUNTRYCLAIM", SqlDbType.VarChar)
        oParam(33).Value = CType(_FlagCountryClaim, String)

        oParam(34) = New SqlClient.SqlParameter("@FLAG_CLAIMSTATUSCODE", SqlDbType.VarChar)
        oParam(34).Value = CType(_FlagClaimStatusCode, String)

        oParam(35) = New SqlClient.SqlParameter("@FLAG_REMARKS", SqlDbType.VarChar)
        oParam(35).Value = CType(_FlagRemarks, String)

        oParam(36) = New SqlClient.SqlParameter("@FLAG_TREATMENTPROVIDERCODE", SqlDbType.VarChar)
        oParam(36).Value = CType(_FlagTreatMentProvCode, String)

        oParam(37) = New SqlClient.SqlParameter("@CREATED_BY", SqlDbType.VarChar)
        oParam(37).Value = CType(_CreatedBy, String)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Sel_FCR_LIST, CommandType.StoredProcedure, oParam)

        Return dt

    End Function
    '
    Public Function f_SEL_TODOLIST(ByVal _DayFrom As DateTime, ByVal _DayTo As DateTime, ByVal _List As String, _
                                   ByVal _flagDay As String, ByVal _FlagList As String, ByVal _CreatedBy As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(5) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@DAY_FROM", SqlDbType.DateTime)
        oParam(0).Value = CType(_DayFrom, DateTime)

        oParam(1) = New SqlClient.SqlParameter("@DAY_TO", SqlDbType.DateTime)
        oParam(1).Value = CType(_DayTo, DateTime)

        oParam(2) = New SqlClient.SqlParameter("@LIST", SqlDbType.VarChar)
        oParam(2).Value = CType(_List, String)

        oParam(3) = New SqlClient.SqlParameter("@FLAG_DAY", SqlDbType.VarChar)
        oParam(3).Value = CType(_flagDay, String)

        oParam(4) = New SqlClient.SqlParameter("@FLAG_LIST", SqlDbType.VarChar)
        oParam(4).Value = CType(_FlagList, String)

        oParam(5) = New SqlClient.SqlParameter("@CREATED_BY", SqlDbType.VarChar)
        oParam(5).Value = CType(_CreatedBy, String)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Sel_List, CommandType.StoredProcedure, oParam)

        Return dt

    End Function
    Public Function f_SEL_LIFECYCLE(ByVal _ClaimNo As String, ByVal _PolicyNo As String, ByVal _NameOfInsured As String, _
                                   ByVal _flagClaim As String, ByVal _FlagPolicyNo As String, ByVal _FlagNameOfInsured As String, ByVal _CreatedBy As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(6) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@CLAIMNO", SqlDbType.VarChar)
        oParam(0).Value = CType(_ClaimNo, String)

        oParam(1) = New SqlClient.SqlParameter("@POLICYNO", SqlDbType.VarChar)
        oParam(1).Value = CType(_PolicyNo, String)

        oParam(2) = New SqlClient.SqlParameter("@NAMEINSURED", SqlDbType.VarChar)
        oParam(2).Value = CType(_NameOfInsured, String)

        oParam(3) = New SqlClient.SqlParameter("@FLAG_CLAIMNO", SqlDbType.VarChar)
        oParam(3).Value = CType(_flagClaim, String)

        oParam(4) = New SqlClient.SqlParameter("@FLAG_POLICYNO", SqlDbType.VarChar)
        oParam(4).Value = CType(_FlagPolicyNo, String)

        oParam(5) = New SqlClient.SqlParameter("@FLAG_NAMEINSURED", SqlDbType.VarChar)
        oParam(5).Value = CType(_FlagNameOfInsured, String)

        oParam(6) = New SqlClient.SqlParameter("@CREATED_BY", SqlDbType.VarChar)
        oParam(6).Value = CType(_CreatedBy, String)


        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Sel_LIFE_CYCLE, CommandType.StoredProcedure, oParam)

        Return dt

    End Function
    Public Function f_SEL_LIFECYCLE_DETAIL(ByVal _IDX As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@IDX", SqlDbType.VarChar)
        oParam(0).Value = CType(_IDX, String)



        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Sel_LIFE_CYCLE_DETAIL, CommandType.StoredProcedure, oParam)

        Return dt

    End Function
    Public Function f_SEL_TODOLIST_LOAD(ByVal _CreatedBy As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@CREATED_BY", SqlDbType.VarChar)
        oParam(0).Value = CType(_CreatedBy, String)


        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Sel_List_Load, CommandType.StoredProcedure, oParam)

        Return dt

    End Function
    Public Function f_SelDept() As DataTable

        Dim dt As New DataTable


        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Sel_Dept, CommandType.StoredProcedure)

        Return dt

    End Function


    Public Function f_CheckCriteria_Worksite(ByVal _rkNo As String, ByVal _entity As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@RKNO", SqlDbType.VarChar)
        oParam(0).Value = CType(_rkNo, String)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_CHECK_CRITERIA_UPLOAD_WORKSITE, CommandType.StoredProcedure, oParam)

        Return dt

    End Function

    Public Function f_CheckDatePolicy(ByVal _rekKoran As String, ByVal _Date As Date, ByVal _entity As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(1) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@REKKORAN", SqlDbType.VarChar)
        oParam(0).Value = CType(_rekKoran, String)

        oParam(1) = New SqlClient.SqlParameter("@DATE", SqlDbType.Date)
        oParam(1).Value = CType(_Date, Date)


        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_CHECK_DATE_POLICY, CommandType.StoredProcedure, oParam)

        Return dt

    End Function
    Public Function f_CheckPolicy(ByVal _Policy As String, ByVal _entity As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@POLICYNO", SqlDbType.VarChar)
        oParam(0).Value = CType(_Policy, String)


        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_CHECK_POLICY, CommandType.StoredProcedure, oParam)

        Return dt

    End Function
    Public Function f_SelectDetail(ByVal _rekKoran As String, ByVal _entity As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@RekKoran", SqlDbType.VarChar)
        oParam(0).Value = CType(_rekKoran, String)


        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Sel_DetailRek_Koran, CommandType.StoredProcedure, oParam)

        Return dt

    End Function
    Public Function f_CheckCURR_BSM(ByVal _AccountNumb As String, ByVal _entity As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@ACCT_Num", SqlDbType.VarChar)
        oParam(0).Value = CType(_AccountNumb, String)


        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_CHECK_CURR_BSM, CommandType.StoredProcedure, oParam)

        Return dt

    End Function

    Public Function f_CheckCURR_BSM_By_RekKoran(ByVal _RekKoran As String, ByVal _entity As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@RekKoran", SqlDbType.VarChar)
        oParam(0).Value = CType(_RekKoran, String)


        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_CHECK_CURR_BSM_by_RekKoran, CommandType.StoredProcedure, oParam)

        Return dt

    End Function
    Public Function f_InsertLogin(ByVal _userid As String, ByVal _ip As String, ByVal _entity As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(1) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@USERID", SqlDbType.VarChar)
        oParam(0).Value = CType(_userid, String)

        oParam(1) = New SqlClient.SqlParameter("@IP", SqlDbType.VarChar)
        oParam(1).Value = CType(_ip, String)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_InsertLogin, CommandType.StoredProcedure, oParam)

        Return dt

    End Function

    Public Function f_SelRekeningKoran(ByVal _bankstatementfrom As DateTime, ByVal _bankstatementto As DateTime, ByVal _policyno As String, ByVal _flagstatement As String, ByVal _flagpolicyno As String, _
                                        ByVal _amountfrom As Decimal, ByVal _amountto As Decimal, ByVal _flagamount As String, _
                                        ByVal _premiumfrom As String, ByVal _premiumto As String, ByVal _flagpremium As String, _
                                        ByVal _lastupdate_from As DateTime, ByVal _lastupdate_to As DateTime, ByVal _flaglastupdate As String, _
                                        ByVal _description As String, ByVal _flagdescription As String, ByVal _branch As String, ByVal _flagbranch As String, _
                                        ByVal _refund As String, ByVal _flagrefund As String, ByVal _atp As String, ByVal _flagatp As String, _
                                        ByVal _remark As String, ByVal _flagremark As String, ByVal _status As String, ByVal _flagstatus As String, _
                                        ByVal _lastupdateby As String, ByVal _flaglastupdateby As String, ByVal _bankaccno As String, ByVal _flagaccno As String, ByVal _entity As String, _
                                        ByVal _createdOn_from As DateTime, ByVal _createdOn_to As DateTime, ByVal _flagcreatedOn As String, _
                                        ByVal _refundAmount_from As Decimal, ByVal _refundAmount_to As Decimal, ByVal _flagRefundAmount As String, _
                                        ByVal _seq_from As String, ByVal _seq_To As String, ByVal _flagSeq As String, _
                                        ByVal _refNumber As String, ByVal _flagref As String, ByVal _rekNumber As String, ByVal _flagrek As String) As DataTable

        Dim oParam(42) As SqlParameter
        Dim dt As New DataTable

        oParam(0) = New SqlClient.SqlParameter("@BANKSTATEMENT_FROM", SqlDbType.DateTime)
        oParam(0).Value = CType(_bankstatementfrom, DateTime)

        oParam(1) = New SqlClient.SqlParameter("@BANKSTATEMENT_TO", SqlDbType.DateTime)
        oParam(1).Value = CType(_bankstatementto, DateTime)

        oParam(2) = New SqlClient.SqlParameter("@POLICYNO", SqlDbType.VarChar)
        oParam(2).Value = CType(_policyno, String)

        oParam(3) = New SqlClient.SqlParameter("@FLAG_BANKSTATEMENT", SqlDbType.VarChar)
        oParam(3).Value = CType(_flagstatement, String)

        oParam(4) = New SqlClient.SqlParameter("@FLAG_POLICYNO", SqlDbType.VarChar)
        oParam(4).Value = CType(_flagpolicyno, String)

        oParam(5) = New SqlClient.SqlParameter("@AMOUNT_FROM", SqlDbType.Float)
        oParam(5).Value = CType(_amountfrom, Decimal)

        oParam(6) = New SqlClient.SqlParameter("@AMOUNT_TO", SqlDbType.Float)
        oParam(6).Value = CType(_amountto, Decimal)

        oParam(7) = New SqlClient.SqlParameter("@FLAG_AMOUNT", SqlDbType.VarChar)
        oParam(7).Value = CType(_flagamount, String)

        oParam(8) = New SqlClient.SqlParameter("@PREMIUM_FROM", SqlDbType.VarChar)
        oParam(8).Value = CType(_premiumfrom, String)

        oParam(9) = New SqlClient.SqlParameter("@PREMIUM_TO", SqlDbType.VarChar)
        oParam(9).Value = CType(_premiumto, String)

        oParam(10) = New SqlClient.SqlParameter("@FLAG_PREMIUM", SqlDbType.VarChar)
        oParam(10).Value = CType(_flagpremium, String)

        oParam(11) = New SqlClient.SqlParameter("@LASTUPDATE_FROM", SqlDbType.DateTime)
        oParam(11).Value = CType(_lastupdate_from, DateTime)

        oParam(12) = New SqlClient.SqlParameter("@LASTUPDATE_TO", SqlDbType.DateTime)
        oParam(12).Value = CType(_lastupdate_to, DateTime)

        oParam(13) = New SqlClient.SqlParameter("@FLAG_LASTUPDATE", SqlDbType.VarChar)
        oParam(13).Value = CType(_flaglastupdate, String)

        oParam(14) = New SqlClient.SqlParameter("@DESCRIPTION", SqlDbType.VarChar)
        oParam(14).Value = CType(_description, String)

        oParam(15) = New SqlClient.SqlParameter("@FLAG_DESCRIPTION", SqlDbType.VarChar)
        oParam(15).Value = CType(_flagdescription, String)

        oParam(16) = New SqlClient.SqlParameter("@BRANCH", SqlDbType.VarChar)
        oParam(16).Value = CType(_branch, String)

        oParam(17) = New SqlClient.SqlParameter("@FLAG_BRANCH", SqlDbType.VarChar)
        oParam(17).Value = CType(_flagbranch, String)

        oParam(18) = New SqlClient.SqlParameter("@REFUND", SqlDbType.VarChar)
        oParam(18).Value = CType(_refund, String)

        oParam(19) = New SqlClient.SqlParameter("@FLAG_REFUND", SqlDbType.VarChar)
        oParam(19).Value = CType(_flagrefund, String)

        oParam(20) = New SqlClient.SqlParameter("@ATP", SqlDbType.VarChar)
        oParam(20).Value = CType(_atp, String)

        oParam(21) = New SqlClient.SqlParameter("@FLAG_ATP", SqlDbType.VarChar)
        oParam(21).Value = CType(_flagatp, String)

        oParam(22) = New SqlClient.SqlParameter("@REMARK", SqlDbType.VarChar)
        oParam(22).Value = CType(_remark, String)

        oParam(23) = New SqlClient.SqlParameter("@FLAG_REMARK", SqlDbType.VarChar)
        oParam(23).Value = CType(_flagremark, String)

        oParam(24) = New SqlClient.SqlParameter("@STATUS", SqlDbType.VarChar)
        oParam(24).Value = CType(_status, String)

        oParam(25) = New SqlClient.SqlParameter("@FLAG_STATUS", SqlDbType.VarChar)
        oParam(25).Value = CType(_flagstatus, String)

        oParam(26) = New SqlClient.SqlParameter("@LASTUPDATEBY", SqlDbType.VarChar)
        oParam(26).Value = CType(_lastupdateby, String)

        oParam(27) = New SqlClient.SqlParameter("@FLAG_LASTUPDATEBY", SqlDbType.VarChar)
        oParam(27).Value = CType(_flaglastupdateby, String)

        oParam(28) = New SqlClient.SqlParameter("@BANKACCNO", SqlDbType.VarChar)
        oParam(28).Value = CType(_bankaccno, String)

        oParam(29) = New SqlClient.SqlParameter("@FLAG_BANKACCNO", SqlDbType.VarChar)
        oParam(29).Value = CType(_flagaccno, String)

        oParam(30) = New SqlClient.SqlParameter("@CREATEDON_FROM", SqlDbType.DateTime)
        oParam(30).Value = CType(_createdOn_from, DateTime)

        oParam(31) = New SqlClient.SqlParameter("@CREATEDON_TO", SqlDbType.DateTime)
        oParam(31).Value = CType(_createdOn_to, DateTime)

        oParam(32) = New SqlClient.SqlParameter("@FLAG_CREATEDON", SqlDbType.VarChar)
        oParam(32).Value = CType(_flagcreatedOn, String)

        oParam(33) = New SqlClient.SqlParameter("@REFUND_FROM", SqlDbType.Float)
        oParam(33).Value = CType(_refundAmount_from, Decimal)

        oParam(34) = New SqlClient.SqlParameter("@REFUND_TO", SqlDbType.Float)
        oParam(34).Value = CType(_refundAmount_to, Decimal)

        oParam(35) = New SqlClient.SqlParameter("@FLAG_REFUNDAMOUNT", SqlDbType.VarChar)
        oParam(35).Value = CType(_flagRefundAmount, String)

        oParam(36) = New SqlClient.SqlParameter("@SEQ_FROM", SqlDbType.VarChar)
        oParam(36).Value = CType(_seq_from, String)

        oParam(37) = New SqlClient.SqlParameter("@SEQ_TO", SqlDbType.VarChar)
        oParam(37).Value = CType(_seq_To, String)

        oParam(38) = New SqlClient.SqlParameter("@FLAG_SEQ", SqlDbType.VarChar)
        oParam(38).Value = CType(_flagSeq, String)

        oParam(39) = New SqlClient.SqlParameter("@REF_NUM", SqlDbType.VarChar)
        oParam(39).Value = CType(_refNumber, String)

        oParam(40) = New SqlClient.SqlParameter("@FLAG_REF", SqlDbType.VarChar)
        oParam(40).Value = CType(_flagref, String)

        oParam(41) = New SqlClient.SqlParameter("@REK_NUM", SqlDbType.VarChar)
        oParam(41).Value = CType(_rekNumber, String)

        oParam(42) = New SqlClient.SqlParameter("@FLAG_REK", SqlDbType.VarChar)
        oParam(42).Value = CType(_flagrek, String)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Sel_RekeningKoran, CommandType.StoredProcedure, oParam)

        Return dt

    End Function

    Public Function f_SelRekeningKoran_Item(ByVal _rekeningkoran As String, ByVal _entity As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@REKKORAN", SqlDbType.VarChar)
        oParam(0).Value = CType(_rekeningkoran, String)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Sel_RekeningKoranItem, CommandType.StoredProcedure, oParam)

        Return dt

    End Function

    Public Function f_InsertUploadFile(ByVal _filename As String, ByVal _createdby As String, ByVal _entity As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(1) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@FILENAME", SqlDbType.VarChar)
        oParam(0).Value = CType(_filename, String)

        oParam(1) = New SqlClient.SqlParameter("@CREATEDBY", SqlDbType.VarChar)
        oParam(1).Value = CType(_createdby, String)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_InsertUploadFile, CommandType.StoredProcedure, oParam)

        Return dt

    End Function

    Public Function f_Select_DCR_Report(ByVal _entity As String) As DataTable

        Dim dt As New DataTable

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Sel_DCRReport, CommandType.StoredProcedure)

        Return dt

    End Function

    Public Function f_Select_DCR_Report_FAILED(ByVal _entity As String) As DataTable

        Dim dt As New DataTable

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Sel_DCRReport_Failed_DCR, CommandType.StoredProcedure)

        Return dt

    End Function

    Public Function f_Select_DCR_Report_Failed_AFI(ByVal _entity As String) As DataTable

        Dim dt As New DataTable

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Sel_DCRReport_FAILED_AFI, CommandType.StoredProcedure)

        Return dt

    End Function

    Public Function f_Select_DCR_Report_Failed(ByVal _desc As String, ByVal _entity As String) As DataTable

        Dim dt As New DataTable

        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@Desc", SqlDbType.VarChar)
        oParam(0).Value = CType(_desc, String)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_Sel_DCRReport_Failed, CommandType.StoredProcedure, oParam)

        Return dt

    End Function

    Public Function f_CheckCriteria(ByVal _uploadid As Integer, ByVal _entity As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@UPLOADID", SqlDbType.Int)
        oParam(0).Value = CType(_uploadid, Integer)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_CHECK_CRITERIA, CommandType.StoredProcedure, oParam)

        Return dt

    End Function
    Public Function f_CheckCriteria_FAILED(ByVal _uploadid As Integer, ByVal _entity As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@UPLOADID", SqlDbType.Int)
        oParam(0).Value = CType(_uploadid, Integer)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_CHECK_CRITERIA_FAILED, CommandType.StoredProcedure, oParam)

        Return dt

    End Function

    Public Function f_SelectBalance(ByVal _rekKoran As String, ByVal _entity As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@REK_KORAN", SqlDbType.VarChar)
        oParam(0).Value = CType(_rekKoran, String)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_CHECK_BALANCE, CommandType.StoredProcedure, oParam)

        Return dt

    End Function

    Public Function f_SelectAmount(ByVal _rekKoran As String, ByVal _entity As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@REK_KORAN", SqlDbType.VarChar)
        oParam(0).Value = CType(_rekKoran, String)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_CHECK_AMOUNT, CommandType.StoredProcedure, oParam)

        Return dt

    End Function

    Public Function f_SelAcct(ByVal _entity As String) As DataTable
        Dim dt As New DataTable
        Dim _connectionString As String = _connectionString_AFI
        'If _entity = "AMFS" Then
        dt = FillDataset(_connectionString, const_sp_SEL_ACCT, CommandType.StoredProcedure)
        'End If
        Return dt
    End Function

    Public Function f_CheckDouble_BSM(ByVal _det1 As DateTime, ByVal _ref As String, ByVal _det2 As String, ByVal _debit As Decimal, _
                                      ByVal _credit As Decimal, ByVal _branch_Code As String, ByVal _entity As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(5) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@DET1", SqlDbType.DateTime)
        oParam(0).Value = CType(_det1, DateTime)

        oParam(1) = New SqlClient.SqlParameter("@REF", SqlDbType.VarChar)
        oParam(1).Value = CType(_ref, String)

        oParam(2) = New SqlClient.SqlParameter("@DET2", SqlDbType.VarChar)
        oParam(2).Value = CType(_det2, String)

        oParam(3) = New SqlClient.SqlParameter("@DB", SqlDbType.Float)
        oParam(3).Value = CType(_debit, Decimal)

        oParam(4) = New SqlClient.SqlParameter("@CR", SqlDbType.Float)
        oParam(4).Value = CType(_credit, Decimal)

        oParam(5) = New SqlClient.SqlParameter("@Branch_CODE", SqlDbType.VarChar)
        oParam(5).Value = CType(_branch_Code, String)


        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_CHECK_DOUBLE_DATA_BSM, CommandType.StoredProcedure, oParam)

        Return dt

    End Function

    Public Function f_CheckDouble_MCM(ByVal _tgl As DateTime, ByVal _rincianTrans As String, _
                                      ByVal _credit As Decimal, ByVal _branch_Code As String, ByVal _entity As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(3) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@TGL", SqlDbType.DateTime)
        oParam(0).Value = CType(_tgl, DateTime)

        oParam(1) = New SqlClient.SqlParameter("@RINCIAN", SqlDbType.VarChar)
        oParam(1).Value = CType(_rincianTrans, String)

        oParam(2) = New SqlClient.SqlParameter("@CR", SqlDbType.Float)
        oParam(2).Value = CType(_credit, Decimal)

        oParam(3) = New SqlClient.SqlParameter("@Branch_CODE", SqlDbType.VarChar)
        oParam(3).Value = CType(_branch_Code, String)


        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_CHECK_DOUBLE_DATA_MCM, CommandType.StoredProcedure, oParam)

        Return dt

    End Function

    Public Function f_CheckDouble_UploadSeq(ByVal _Policy As String, ByVal _amount As Decimal, ByVal _entity As String) As DataTable
        Dim dt As New DataTable

        Dim oParam(1) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@Policy", SqlDbType.VarChar)
        oParam(0).Value = CType(_Policy, String)

        oParam(1) = New SqlClient.SqlParameter("@amount", SqlDbType.Float)
        oParam(1).Value = CType(_amount, Decimal)


        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_CHECK_DOUBLE_DATA_Upload, CommandType.StoredProcedure, oParam)

        Return dt
    End Function

    Public Function f_CheckDouble_Upload_PAYMENT(ByVal _RekKoranDate As Date, ByVal _RekKoran As String, _
                                                 ByVal _Bank_Account_No As String, ByVal _Amount_RK As Decimal, _
                                                 ByVal _Policy As String, ByVal _amount As Decimal, _
                                                 ByVal _Currency As String, ByVal _Is_Refund As String, _
                                                 ByVal _Refund_Amount As Decimal, ByVal _Remarks As String, ByVal _TC_Code As Integer, ByVal _entity As String) As DataTable
        'ByVal _Remarks As String, _

        Dim dt As New DataTable

        Dim oParam(10) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@RekKoranDate", SqlDbType.Date)
        oParam(0).Value = CType(_RekKoranDate, Date)

        oParam(1) = New SqlClient.SqlParameter("@RekKoran", SqlDbType.VarChar)
        oParam(1).Value = CType(_RekKoran, String)

        oParam(2) = New SqlClient.SqlParameter("@Bank_Account_No", SqlDbType.VarChar)
        oParam(2).Value = CType(_Bank_Account_No, String)

        oParam(3) = New SqlClient.SqlParameter("@Amount_RK", SqlDbType.Float)
        oParam(3).Value = CType(_Amount_RK, Decimal)

        oParam(4) = New SqlClient.SqlParameter("@Policy", SqlDbType.VarChar)
        oParam(4).Value = CType(_Policy, String)

        oParam(5) = New SqlClient.SqlParameter("@amount", SqlDbType.Float)
        oParam(5).Value = CType(_amount, Decimal)

        oParam(6) = New SqlClient.SqlParameter("@Currency", SqlDbType.VarChar)
        oParam(6).Value = CType(_Currency, String)

        oParam(7) = New SqlClient.SqlParameter("@Is_Refund", SqlDbType.VarChar)
        oParam(7).Value = CType(_Is_Refund, String)

        oParam(8) = New SqlClient.SqlParameter("@Refund_Amount", SqlDbType.Float)
        oParam(8).Value = CType(_Refund_Amount, Decimal)

        oParam(9) = New SqlClient.SqlParameter("@Remarks", SqlDbType.VarChar)
        oParam(9).Value = CType(_Remarks, String)

        oParam(10) = New SqlClient.SqlParameter("@TC_Code", SqlDbType.Int)
        oParam(10).Value = CType(_TC_Code, Integer)


        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_CHECK_UPLOAD_FILE_DOUBLE_PAYMENT, CommandType.StoredProcedure, oParam)

        Return dt
    End Function
    Public Function f_CheckAmountRK(ByVal _RekKoran As String, ByVal _Amount As Decimal, ByVal _Bank_Account As String, ByVal _entity As String) As DataTable
        Dim dt As New DataTable

        Dim oParam(2) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@RekKoran", SqlDbType.VarChar)
        oParam(0).Value = CType(_RekKoran, String)

        oParam(1) = New SqlClient.SqlParameter("@Amount", SqlDbType.Float)
        oParam(1).Value = CType(_Amount, Decimal)

        oParam(2) = New SqlClient.SqlParameter("@Bank_Account", SqlDbType.VarChar)
        oParam(2).Value = CType(_Bank_Account, String)


        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_CHECK_AMOUNT_RK, CommandType.StoredProcedure, oParam)

        Return dt
    End Function
    Public Function f_CheckStatusRekKor(ByVal _RekKoran As String, ByVal _entity As String) As DataTable
        Dim dt As New DataTable

        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@RekKoran", SqlDbType.VarChar)
        oParam(0).Value = CType(_RekKoran, String)


        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_CHECK_STATUS_REK_KORAN, CommandType.StoredProcedure, oParam)

        Return dt
    End Function

    Public Function f_CheckMMenus(ByVal _UserName As String, ByVal _MenuID As String, ByVal _entity As String) As DataTable
        Dim dt As New DataTable

        Dim oParam(1) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@UserName", SqlDbType.VarChar)
        oParam(0).Value = CType(_UserName, String)

        oParam(1) = New SqlClient.SqlParameter("@IDMenu", SqlDbType.VarChar)
        oParam(1).Value = CType(_MenuID, String)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_CHECK_MENU, CommandType.StoredProcedure, oParam)

        Return dt
    End Function

    Public Function f_CheckMMenu(ByVal _UserName As String, ByVal _MenuID As String, ByVal _entity As String) As DataTable
        Dim dt As New DataTable

        Dim oParam(1) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@UserName", SqlDbType.VarChar)
        oParam(0).Value = CType(_UserName, String)

        oParam(1) = New SqlClient.SqlParameter("@IDMenu", SqlDbType.VarChar)
        oParam(1).Value = CType(_MenuID, String)

        Dim _connectionString As String = _connectionString_AFI
        'dt = FillDataset(_connectionString, const_sp_CHECK_MENUS, CommandType.StoredProcedure, oParam)
        dt = FillDataset(_connectionString, const_sp_CHECK_MENU_NAME_MASTER, CommandType.StoredProcedure, oParam)

        Return dt
    End Function
    'Public Function f_CheckMMenu(ByVal _MenuID As String, ByVal _entity As String) As DataTable
    '    Dim dt As New DataTable

    '    Dim oParam(0) As SqlParameter

    '    oParam(0) = New SqlClient.SqlParameter("@IDMenu", SqlDbType.VarChar)
    '    oParam(0).Value = CType(_MenuID, String)

    '    Dim _connectionString As String = _connectionString_AFI
    '    dt = FillDataset(_connectionString, const_sp_CHECK_MENU_NAME_MASTER, CommandType.StoredProcedure, oParam)

    '    Return dt
    'End Function
    Public Function f_CheckPrefix(ByVal _Policy As String, ByVal _entity As String) As DataTable
        Dim dt As New DataTable

        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@Policy", SqlDbType.VarChar)
        oParam(0).Value = CType(_Policy, String)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_CHECK_PREFIX_POLICY, CommandType.StoredProcedure, oParam)

        Return dt
    End Function

    Public Function f_BalanceReject(ByVal _rekKoran As String, ByVal _entity As String) As DataTable
        Dim dt As New DataTable

        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@REKKORAN", SqlDbType.VarChar)
        oParam(0).Value = CType(_rekKoran, String)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_BALANCE_RK, CommandType.StoredProcedure, oParam)

        Return dt
    End Function
    Public Function f_CheckUpload(ByVal _fileName As String, ByVal _entity As String) As DataTable
        Dim dt As New DataTable

        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@FILENAME", SqlDbType.VarChar)
        oParam(0).Value = CType(_fileName, String)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_CHECK_UPLOAD_FILE, CommandType.StoredProcedure, oParam)

        Return dt
    End Function
    Public Function f_SEL_FAILED_FILE(ByVal _FromDate As DateTime, ByVal _ToDate As DateTime, ByVal _AcctNum As String, ByVal _entity As String) As DataTable
        Dim dt As New DataTable

        Dim oParam(2) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@FromDate", SqlDbType.DateTime)
        oParam(0).Value = CType(_FromDate, DateTime)


        oParam(1) = New SqlClient.SqlParameter("@ToDate", SqlDbType.DateTime)
        oParam(1).Value = CType(_ToDate, DateTime)

        oParam(2) = New SqlClient.SqlParameter("@ACCT_Number", SqlDbType.VarChar)
        oParam(2).Value = CType(_AcctNum, String)


        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_SEL_FAILED_FILE, CommandType.StoredProcedure, oParam)

        Return dt
    End Function

End Class
