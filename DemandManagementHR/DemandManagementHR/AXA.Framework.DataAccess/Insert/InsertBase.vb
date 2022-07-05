Imports System.Configuration
Imports System.Data.SqlClient

Public Class InsertBase
    Inherits AXA.Framework.DataAccess.DataAccessBase

    'Dim _connectionString As String = ConfigurationManager.ConnectionStrings("Consql").ToString
    Dim _connectionString_AFI As String = ConfigurationManager.ConnectionStrings("ConSql").ToString
    Dim _connectionString_AHS As String = ConfigurationManager.ConnectionStrings("ConSql").ToString
#Region "Constanta"
    Dim const_SP_INSERT_UPLOAD_DATA_FAILED As String = "sp_TRN_UPLOAD_DATA_FAILED"
    Dim const_SP_INSERT_FCR_REASON_INVEST As String = "SP_INSERT_FCR_REASON_INVEST"
    Dim const_SP_INSERT_FBA_CASHBACK_BENEFIT As String = "SP_INSERT_FBA_CASHBACK_BENEFIT"
    Dim const_SP_INS_MST_MENU As String = "sp_Add_Master_Menu"
    Dim const_SP_INS_MST_DEPT As String = "sp_Add_Master_Dept"
    Dim const_SP_INSERT_DEPT_MATRIX As String = "sp_ADD_DEPT_MATRIX"
    Dim const_SP_EDIT_DEPT_MATRIX As String = "sp_EDIT_DEPT_MATRIX"
    Dim const_SP_INSERT_LOG_ERROR_UPLOAD_FILE As String = "sp_INS_LOG_ERROR_UPLOAD_FILE"
    Dim const_SP_INSERT_UPLOAD_DATA As String = "sp_TRN_UPLOAD_DATA"
    Dim const_SP_INSERT_TODO_LIST As String = "sp_ADD_TODO_LIST"
    Dim const_SP_INSERT_UPLOAD_ENROLLMENT As String = "sp_TRN_ENROLLMENT_UPLOAD"
    Dim const_SP_INSERT_BORDERAUX_DETAIL As String = "SP_INS_BORDERAUX_DETAIL"
    Dim const_SP_INSERT_FCR As String = "sp_INSERT_FCR"
    Dim const_SP_INSERT_FCR_DETAIL As String = "sp_INSERT_FCR_DETAIL"
    Dim const_SP_INSERT_LIFE_CYCLE As String = "sp_INSERT_LIFE_CYCLE"
    Dim const_SP_INSERT_FCR_INC_DOC As String = "sp_INSERT_FCR_INCOMPLETE_DOC"
    Dim const_SP_INSERT_FCR_Complete_DOC As String = "[sp_INSERT_FCR_COMPLETE_DOC]"
    Dim const_SP_INSERT_FCR_POL_DOC As String = "[sp_INSERT_FCR_POL_DOC]"
    Dim const_SP_INSERT_FCR_TASKS As String = "sp_INSERT_FCR_TASKS"
    Dim const_SP_INSERT_FBA_NON_MED As String = "[sp_INSERT_TRN_FBA_NONMEDIS]"
    Dim const_SP_INSERT_FBA_OBT As String = "[sp_INSERT_TRN_FBA_OTBDDX]"
    Dim const_SP_INSERT_FBA As String = "sp_INSERT_TRN_FBA"
    Dim const_SP_INSERT_FBA2 As String = "sp_INSERT_TRN_FBA2"
    Dim const_SP_INSERT_PAYMENT_REPORT As String = "sp_INSERT_TRN_PAYMENT_REPORT"
    Dim const_SP_INSERT_MST_CURRENCY As String = "sp_INS_MASTER_CURRENCY"
    Dim const_SP_INSERT_TRN_SMS As String = "sp_INS_TRN_SMS"
    Dim const_SP_INSERT_TRN_CASE_FOLLOW_UP As String = "sp_INSERT_CASE_FOLLOWUP"
    Dim const_SP_INSERT_MST_CURR As String = "sp_INSERT_MST_CURR"

    Dim const_SP_DOWNLOAD_UPLOADDATABDX As String = "sp_Download_UploadData_BDX"


    'Dim const_SP_INSERT_REKKORAN As String = "sp_INSERT_REKENINGKORAN_MAPPING"
    'Dim const_SP_INSERT_REKKORAN_FAILED As String = "sp_INSERT_REKENINGKORAN_MAPPING_FAILED"
    'Dim const_SP_INSERT_REKKORAN_ITEM As String = "sp_ADD_REKENINGKORAN_ITEM"
    'Dim const_SP_INSERT_AUDITTRAIL As String = "sp_ADD_AUDITTRAIL"
    Dim const_SP_INSERT_USER_MATRIX As String = "sp_ADD_USER_MATRIX"
    Dim const_SP_EDIT_USER_MATRIX As String = "sp_EDIT_USER_MATRIX"
    Dim const_SP_INS_MST_MENU_CHILD As String = "sp_Add_Master_Menu_Child"
#End Region
    Public Function f_Insert_MST_CURR(ByVal _Source As String, ByVal _Currency As String, ByVal Amount As Decimal, _
                                        ByVal CreatedBy As String)

        Dim oParam(3) As SqlParameter

        oParam(0) = New SqlParameter("@Currency", Data.SqlDbType.VarChar)
        oParam(0).Value = CType(_Currency, String)

        oParam(1) = New SqlParameter("@Source", Data.SqlDbType.VarChar)
        oParam(1).Value = CType(_Source, String)

        oParam(2) = New SqlParameter("@Amount", Data.SqlDbType.Float)
        oParam(2).Value = CType(Amount, Decimal)

        oParam(3) = New SqlParameter("@CreatedBy", Data.SqlDbType.VarChar)
        oParam(3).Value = CType(CreatedBy, String)


        Dim _connectionString As String = _connectionString_AFI

        Return (ExecuteNonQuery(_connectionString, const_SP_INSERT_MST_CURR, Data.CommandType.StoredProcedure, oParam))

    End Function
    Public Function f_Insert_PAYMENT_REPORT(ByVal ClaimNo As String, ByVal PolicyNo As String, _
                                         ByVal PreformatCode As String, ByVal DebitAccountNumber As String, _
                                         ByVal AccountCurrency As String, ByVal AccountName As String, _
                                         ByVal PaymentCurrency As String, ByVal PaymentAmount As Decimal, _
                                         ByVal PaymentMethod As String, ByVal PaymentType As String, _
                                         ByVal TransactionReferenceNumber As String, ByVal Confidential As String, _
                                         ByVal IntraCompany As String, ByVal OrderingPartyNameAddress As String, _
                                         ByVal ValueDate As Date, ByVal BeneficiaryAccountorOtherID As String, _
                                         ByVal BeneficiaryIs As String, ByVal BeneficiaryNameAddress As String, _
                                         ByVal BeneficiaryBankRoutingMethod As String, ByVal BeneficiaryBankRoutingCode As String, _
                                         ByVal BeneficiaryBankNameAddress As String, ByVal ExchangeRate As String, _
                                         ByVal FXContract As String, ByVal PaymentDetails As String, _
                                         ByVal InvoiceOtherSubForms As String, ByVal IntermediaryBankRoutingMethod As String, _
                                         ByVal IntermediaryBankRoutingCode As String, ByVal IntermediaryBankNameAddress As String, _
                                         ByVal IntermediaryBankCountryCode As String, ByVal ChargesIndicator As String, _
                                         ByVal BankDetails As String, _
                                         ByVal Status As String, _
                                         ByVal SubStatus As String, ByVal StatusPayment As String, _
                                         ByVal OrderingPartyNameAddress2 As String, ByVal BeneficiaryNameAddress2 As String, _
                                         ByVal BeneficiaryBankNameAddress2 As String, ByVal IntermediaryBankNameAddress2 As String, _
                                         ByVal PaymentDetails1 As String, ByVal PaymentDetails2 As String, _
                                         ByVal BankDetails1 As String, ByVal BankDetails2 As String, _
                                         ByVal BeneficiaryAccountorOtherIDType As String, ByVal BeneficiaryStatus As String, _
                                         ByVal ChargesAccount As String, ByVal CreatedBy As String)

        Dim oParam(45) As SqlParameter

        oParam(0) = New SqlParameter("@ClaimNo", Data.SqlDbType.VarChar)
        oParam(0).Value = CType(ClaimNo, String)

        oParam(1) = New SqlParameter("@PolicyNo", Data.SqlDbType.VarChar)
        oParam(1).Value = CType(PolicyNo, String)

        oParam(2) = New SqlParameter("@PreformatCode", Data.SqlDbType.VarChar)
        oParam(2).Value = CType(PreformatCode, String)

        oParam(3) = New SqlParameter("@DebitAccountNumber", Data.SqlDbType.VarChar)
        oParam(3).Value = CType(DebitAccountNumber, String)

        oParam(4) = New SqlParameter("@AccountCurrency", Data.SqlDbType.VarChar)
        oParam(4).Value = CType(AccountCurrency, String)

        oParam(5) = New SqlParameter("@AccountName", Data.SqlDbType.VarChar)
        oParam(5).Value = CType(AccountName, String)

        oParam(6) = New SqlParameter("@PaymentCurrency", Data.SqlDbType.VarChar)
        oParam(6).Value = CType(PaymentCurrency, String)

        oParam(7) = New SqlParameter("@PaymentAmount", Data.SqlDbType.Decimal)
        oParam(7).Value = CType(PaymentAmount, Decimal)

        oParam(8) = New SqlParameter("@PaymentMethod", Data.SqlDbType.VarChar)
        oParam(8).Value = CType(PaymentMethod, String)

        oParam(9) = New SqlParameter("@PaymentType", Data.SqlDbType.VarChar)
        oParam(9).Value = CType(PaymentType, String)

        oParam(10) = New SqlParameter("@TransactionReferenceNumber", Data.SqlDbType.VarChar)
        oParam(10).Value = CType(TransactionReferenceNumber, String)

        oParam(11) = New SqlParameter("@Confidential", Data.SqlDbType.VarChar)
        oParam(11).Value = CType(Confidential, String)

        oParam(12) = New SqlParameter("@IntraCompany", Data.SqlDbType.VarChar)
        oParam(12).Value = CType(IntraCompany, String)

        oParam(13) = New SqlParameter("@OrderingPartyNameAddress", Data.SqlDbType.VarChar)
        oParam(13).Value = CType(OrderingPartyNameAddress, String)

        oParam(14) = New SqlParameter("@ValueDate", Data.SqlDbType.Date)
        oParam(14).Value = CType(ValueDate, Date)

        oParam(15) = New SqlParameter("@BeneficiaryAccountorOtherID ", Data.SqlDbType.VarChar)
        oParam(15).Value = CType(BeneficiaryAccountorOtherID, String)

        oParam(16) = New SqlParameter("@BeneficiaryIs", Data.SqlDbType.VarChar)
        oParam(16).Value = CType(BeneficiaryIs, String)

        oParam(17) = New SqlParameter("@BeneficiaryNameAddress", Data.SqlDbType.VarChar)
        oParam(17).Value = CType(BeneficiaryNameAddress, String)

        oParam(18) = New SqlParameter("@BeneficiaryBankRoutingMethod", Data.SqlDbType.VarChar)
        oParam(18).Value = CType(BeneficiaryBankRoutingMethod, String)

        oParam(19) = New SqlParameter("@BeneficiaryBankRoutingCode", Data.SqlDbType.VarChar)
        oParam(19).Value = CType(BeneficiaryBankRoutingCode, String)

        oParam(20) = New SqlParameter("@BeneficiaryBankNameAddress", Data.SqlDbType.VarChar)
        oParam(20).Value = CType(BeneficiaryBankNameAddress, String)

        oParam(21) = New SqlParameter("@ExchangeRate", Data.SqlDbType.VarChar)
        oParam(21).Value = CType(ExchangeRate, String)

        oParam(22) = New SqlParameter("@FXContract", Data.SqlDbType.VarChar)
        oParam(22).Value = CType(FXContract, String)

        oParam(23) = New SqlParameter("@PaymentDetails", Data.SqlDbType.VarChar)
        oParam(23).Value = CType(PaymentDetails, String)

        oParam(24) = New SqlParameter("@InvoiceOtherSubForms", Data.SqlDbType.VarChar)
        oParam(24).Value = CType(InvoiceOtherSubForms, String)

        oParam(25) = New SqlParameter("@IntermediaryBankRoutingMethod", Data.SqlDbType.VarChar)
        oParam(25).Value = CType(IntermediaryBankRoutingMethod, String)

        oParam(26) = New SqlParameter("@IntermediaryBankRoutingCode", Data.SqlDbType.VarChar)
        oParam(26).Value = CType(IntermediaryBankRoutingCode, String)

        oParam(27) = New SqlParameter("@IntermediaryBankNameAddress", Data.SqlDbType.VarChar)
        oParam(27).Value = CType(IntermediaryBankNameAddress, String)

        oParam(28) = New SqlParameter("@IntermediaryBankCountryCode", Data.SqlDbType.VarChar)
        oParam(28).Value = CType(IntermediaryBankCountryCode, String)

        oParam(29) = New SqlParameter("@ChargesIndicator", Data.SqlDbType.VarChar)
        oParam(29).Value = CType(ChargesIndicator, String)

        oParam(30) = New SqlParameter("@BankDetails", Data.SqlDbType.VarChar)
        oParam(30).Value = CType(BankDetails, String)

        'oParam(31) = New SqlParameter("@SubmittedBy", Data.SqlDbType.VarChar)
        'oParam(31).Value = CType(SubmittedBy, String)

        'oParam(32) = New SqlParameter("@SubmissionDateTime", Data.SqlDbType.DateTime)
        'oParam(32).Value = CType(SubmissionDateTime, DateTime)

        oParam(31) = New SqlParameter("@Status", Data.SqlDbType.VarChar)
        oParam(31).Value = CType(Status, String)

        oParam(32) = New SqlParameter("@SubStatus", Data.SqlDbType.VarChar)
        oParam(32).Value = CType(SubStatus, String)

        oParam(33) = New SqlParameter("@StatusPayment", Data.SqlDbType.VarChar)
        oParam(33).Value = CType(StatusPayment, String)

        oParam(34) = New SqlParameter("@CreatedBy", Data.SqlDbType.VarChar)
        oParam(34).Value = CType(CreatedBy, String)

        oParam(35) = New SqlParameter("@OrderingPartyNameAddress2", Data.SqlDbType.VarChar)
        oParam(35).Value = CType(OrderingPartyNameAddress2, String)

        oParam(36) = New SqlParameter("@BeneficiaryNameAddress2", Data.SqlDbType.VarChar)
        oParam(36).Value = CType(BeneficiaryNameAddress2, String)

        oParam(37) = New SqlParameter("@BeneficiaryBankNameAddress2", Data.SqlDbType.VarChar)
        oParam(37).Value = CType(BeneficiaryBankNameAddress2, String)

        oParam(38) = New SqlParameter("@IntermediaryBankNameAddress2", Data.SqlDbType.VarChar)
        oParam(38).Value = CType(IntermediaryBankNameAddress2, String)

        oParam(39) = New SqlParameter("@PaymentDetails1", Data.SqlDbType.VarChar)
        oParam(39).Value = CType(PaymentDetails1, String)

        oParam(40) = New SqlParameter("@PaymentDetails2", Data.SqlDbType.VarChar)
        oParam(40).Value = CType(PaymentDetails2, String)

        oParam(41) = New SqlParameter("@BankDetails1", Data.SqlDbType.VarChar)
        oParam(41).Value = CType(BankDetails1, String)

        oParam(42) = New SqlParameter("@BankDetails2", Data.SqlDbType.VarChar)
        oParam(42).Value = CType(BankDetails2, String)

        oParam(43) = New SqlParameter("@BeneficiaryAccountorOtherIDType", Data.SqlDbType.VarChar)
        oParam(43).Value = CType(BeneficiaryAccountorOtherIDType, String)

        oParam(44) = New SqlParameter("@BeneficiaryStatus", Data.SqlDbType.VarChar)
        oParam(44).Value = CType(BeneficiaryStatus, String)

        oParam(45) = New SqlParameter("@ChargesAccount", Data.SqlDbType.VarChar)
        oParam(45).Value = CType(ChargesAccount, String)





        Dim _connectionString As String = _connectionString_AFI


        Return (ExecuteNonQuery(_connectionString, const_SP_INSERT_PAYMENT_REPORT, Data.CommandType.StoredProcedure, oParam))

    End Function

    Public Function f_Insert_FBA(ByVal ClaimNo As String, ByVal PolicyNo As String, _
                                         ByVal Total_Invoiced_amount As Decimal, ByVal Eligible_Charges As Decimal, _
                                         ByVal Ineligible_Charges As String, ByVal Hospitally_in_Indonesia As String, _
                                         ByVal RoomCharges As Decimal, ByVal RoomType As String, _
                                         ByVal HospitalName As String, ByVal Indicative_Lowest_Cost_Room_Rate As Decimal, _
                                         ByVal SuspectedUpgrade As String, ByVal ActualUpgrade As String, _
                                         ByVal ActualLowestCostAvailableRoom As Decimal, _
                                         ByVal DeterminingUpgradeCostShare As String, ByVal UpgradeLimit As Decimal, _
                                         ByVal NumberOfNights As Integer, ByVal TotalCostForStay As Decimal, _
                                         ByVal AboveLimit As String, ByVal UPGRADE_TYPE As String, _
                                         ByVal UPGRADE_Percent As String, ByVal NationalRoomChargeBorneByMember As Decimal, _
                                         ByVal PayableToCust As Decimal, ByVal NotPayable As Decimal, _
                                         ByVal Beneficiary_Bank_Name As String, ByVal Beneficiary_Branch As String, _
                                         ByVal Beneficiary_Account_No As String, ByVal Beneficiary_Name As String, _
                                         ByVal Remarks As String, ByVal CreatedBy As String, ByVal CURRENCY As String, ByVal PAYMENTDETAILS3 As String, _
                                         ByVal CURRENCYTTOTAL As String, ByVal CURRENCYHOSPITAL As String, ByVal STATUSSEND As String, ByVal STATUSSENDING As String, _
                                         ByVal Total_Invoiced_amount_Convert As Decimal, ByVal Eligible_Charges_Convert As Decimal, _
                                         ByVal Ineligible_Charges_Convert As Decimal, ByVal EXCH As Decimal, ByVal PayableToCustConvert As Decimal)

        Dim oParam(39) As SqlParameter

        oParam(0) = New SqlParameter("@ClaimNo", Data.SqlDbType.VarChar)
        oParam(0).Value = CType(ClaimNo, String)

        oParam(1) = New SqlParameter("@PolicyNo", Data.SqlDbType.VarChar)
        oParam(1).Value = CType(PolicyNo, String)

        oParam(2) = New SqlParameter("@Total_Invoiced_amount", Data.SqlDbType.Decimal)
        oParam(2).Value = CType(Total_Invoiced_amount, Decimal)

        oParam(3) = New SqlParameter("@Eligible_Charges", Data.SqlDbType.Decimal)
        oParam(3).Value = CType(Eligible_Charges, Decimal)

        oParam(4) = New SqlParameter("@Ineligible_Charges", Data.SqlDbType.Decimal)
        oParam(4).Value = CType(Ineligible_Charges, Decimal)

        oParam(5) = New SqlParameter("@Hospitally_in_Indonesia", Data.SqlDbType.VarChar)
        oParam(5).Value = CType(Hospitally_in_Indonesia, String)

        oParam(6) = New SqlParameter("@RoomCharges", Data.SqlDbType.Decimal)
        oParam(6).Value = CType(RoomCharges, Decimal)

        oParam(7) = New SqlParameter("@RoomType", Data.SqlDbType.VarChar)
        oParam(7).Value = CType(RoomType, String)

        oParam(8) = New SqlParameter("@HospitalName", Data.SqlDbType.VarChar)
        oParam(8).Value = CType(HospitalName, String)

        oParam(9) = New SqlParameter("@Indicative_Lowest_Cost_Room_Rate", Data.SqlDbType.Decimal)
        oParam(9).Value = CType(Indicative_Lowest_Cost_Room_Rate, Decimal)

        oParam(10) = New SqlParameter("@SuspectedUpgrade", Data.SqlDbType.VarChar)
        oParam(10).Value = CType(SuspectedUpgrade, String)

        oParam(11) = New SqlParameter("@ActualUpgrade", Data.SqlDbType.VarChar)
        oParam(11).Value = CType(ActualUpgrade, String)

        oParam(12) = New SqlParameter("@ActualLowestCostAvailableRoom", Data.SqlDbType.Decimal)
        oParam(12).Value = CType(ActualLowestCostAvailableRoom, Decimal)

        oParam(13) = New SqlParameter("@DeterminingUpgradeCostShare", Data.SqlDbType.VarChar)
        oParam(13).Value = CType(DeterminingUpgradeCostShare, String)

        oParam(14) = New SqlParameter("@UpgradeLimit", Data.SqlDbType.Decimal)
        oParam(14).Value = CType(UpgradeLimit, Decimal)

        oParam(15) = New SqlParameter("@NumberOfNights", Data.SqlDbType.Int)
        oParam(15).Value = CType(NumberOfNights, Integer)

        oParam(16) = New SqlParameter("@TotalCostForStay", Data.SqlDbType.Decimal)
        oParam(16).Value = CType(TotalCostForStay, Decimal)

        oParam(17) = New SqlParameter("@AboveLimit", Data.SqlDbType.VarChar)
        oParam(17).Value = CType(AboveLimit, String)

        oParam(18) = New SqlParameter("@UPGRADE_TYPE", Data.SqlDbType.VarChar)
        oParam(18).Value = CType(UPGRADE_TYPE, String)

        oParam(19) = New SqlParameter("@UPGRADE_Percent", Data.SqlDbType.VarChar)
        oParam(19).Value = CType(UPGRADE_Percent, String)

        oParam(20) = New SqlParameter("@NationalRoomChargeBorneByMember", Data.SqlDbType.Decimal)
        oParam(20).Value = CType(NationalRoomChargeBorneByMember, Decimal)

        oParam(21) = New SqlParameter("@PayableToCust", Data.SqlDbType.Decimal)
        oParam(21).Value = CType(PayableToCust, Decimal)

        oParam(22) = New SqlParameter("@NotPayable", Data.SqlDbType.Decimal)
        oParam(22).Value = CType(NotPayable, Decimal)

        oParam(23) = New SqlParameter("@Beneficiary_Bank_Name", Data.SqlDbType.VarChar)
        oParam(23).Value = CType(Beneficiary_Bank_Name, String)

        oParam(24) = New SqlParameter("@Beneficiary_Branch", Data.SqlDbType.VarChar)
        oParam(24).Value = CType(Beneficiary_Branch, String)

        oParam(25) = New SqlParameter("@Beneficiary_Account_No", Data.SqlDbType.VarChar)
        oParam(25).Value = CType(Beneficiary_Account_No, String)

        oParam(26) = New SqlParameter("@Beneficiary_Name", Data.SqlDbType.VarChar)
        oParam(26).Value = CType(Beneficiary_Name, String)

        oParam(27) = New SqlParameter("@Remarks", Data.SqlDbType.VarChar)
        oParam(27).Value = CType(Remarks, String)

        oParam(28) = New SqlParameter("@CreatedBy", Data.SqlDbType.VarChar)
        oParam(28).Value = CType(CreatedBy, String)

        oParam(29) = New SqlParameter("@CURRENCY", Data.SqlDbType.VarChar)
        oParam(29).Value = CType(CURRENCY, String)

        oParam(30) = New SqlParameter("@PAYMENTDETAILS3", Data.SqlDbType.VarChar)
        oParam(30).Value = CType(PAYMENTDETAILS3, String)

        oParam(31) = New SqlParameter("@CURRENCYTTOTAL", Data.SqlDbType.VarChar)
        oParam(31).Value = CType(CURRENCYTTOTAL, String)

        oParam(32) = New SqlParameter("@CURRENCYHOSPITAL", Data.SqlDbType.VarChar)
        oParam(32).Value = CType(CURRENCYHOSPITAL, String)

        oParam(33) = New SqlParameter("@STATUSSEND", Data.SqlDbType.VarChar)
        oParam(33).Value = CType(STATUSSEND, String)

        oParam(34) = New SqlParameter("@STATUSSENDING", Data.SqlDbType.VarChar)
        oParam(34).Value = CType(STATUSSENDING, String)

        oParam(35) = New SqlParameter("@Total_Invoiced_amount_Convert", Data.SqlDbType.Decimal)
        oParam(35).Value = CType(Total_Invoiced_amount, Decimal)

        oParam(36) = New SqlParameter("@Eligible_Charges_Convert", Data.SqlDbType.Decimal)
        oParam(36).Value = CType(Eligible_Charges, Decimal)

        oParam(37) = New SqlParameter("@Ineligible_Charges_Convert", Data.SqlDbType.Decimal)
        oParam(37).Value = CType(Ineligible_Charges, Decimal)

        oParam(38) = New SqlParameter("@EXCH", Data.SqlDbType.Decimal)
        oParam(38).Value = CType(EXCH, Decimal)

        oParam(39) = New SqlParameter("@PayableToCustConvert", Data.SqlDbType.Decimal)
        oParam(39).Value = CType(PayableToCustConvert, Decimal)

        Dim _connectionString As String = _connectionString_AFI


        Return (ExecuteNonQuery(_connectionString, const_SP_INSERT_FBA, Data.CommandType.StoredProcedure, oParam))

    End Function

    Public Function f_Insert_FBA2_PROD(ByVal ClaimNo As String, ByVal PolicyNo As String, _
                                        ByVal Total_Invoiced_amount As Decimal, ByVal Eligible_Charges As Decimal, _
                                        ByVal Ineligible_Charges As String, ByVal Hospitally_in_Indonesia As String, _
                                        ByVal RoomCharges As Decimal, ByVal RoomType As String, _
                                        ByVal HospitalName As String, ByVal Indicative_Lowest_Cost_Room_Rate As Decimal, _
                                        ByVal SuspectedUpgrade As String, ByVal ActualUpgrade As String, _
                                        ByVal ActualLowestCostAvailableRoom As Decimal, _
                                        ByVal DeterminingUpgradeCostShare As String, ByVal UpgradeLimit As Decimal, _
                                        ByVal NumberOfNights As Integer, ByVal TotalCostForStay As Decimal, _
                                        ByVal AboveLimit As String, ByVal UPGRADE_TYPE As String, _
                                        ByVal UPGRADE_Percent As String, ByVal NationalRoomChargeBorneByMember As Decimal, _
                                        ByVal PayableToCust As Decimal, ByVal NotPayable As Decimal, _
                                        ByVal Beneficiary_Bank_Name As String, ByVal Beneficiary_Branch As String, _
                                        ByVal Beneficiary_Account_No As String, ByVal Beneficiary_Name As String, _
                                        ByVal Remarks As String, ByVal CreatedBy As String, ByVal CURRENCY As String, ByVal PAYMENTDETAILS3 As String, _
                                        ByVal CURRENCYTTOTAL As String, ByVal CURRENCYHOSPITAL As String, ByVal STATUSSEND As String, ByVal STATUSSENDING As String, _
                                        ByVal Total_Invoiced_amount_Convert As Decimal, ByVal Eligible_Charges_Convert As Decimal, _
                                        ByVal Ineligible_Charges_Convert As Decimal, ByVal EXCH As Decimal, ByVal PayableToCustConvert As Decimal, ByVal PayDetails As String, _
                                        ByVal CountPayment As Integer, ByVal IDXFBA As Integer, ByVal btnParam As String, _
                                        ByVal FBAHeader As String, ByVal FBADetail As String, _
                                        ByVal ActualRB As Decimal, ByVal SumActualRB As Decimal, _
                                        ByVal Plan As Decimal, ByVal SumPlan As Decimal, ByVal CashBen_Night As Integer, _
                                        ByVal CashBen_Unit As Integer, ByVal CashBen_UnitTambahan As Decimal, _
                                        ByVal CashBen_UnitDasar As Decimal, ByVal CashBen_UnitNasabah As Decimal, ByVal TotalCashBen_Unit As Decimal, _
                                        ByVal TotalPayAble As Decimal, ByVal CashBackDetail As String, ByVal DateExhRate As Date)
        'ByVal StatusFBA As String)

        Dim oParam(58) As SqlParameter

        oParam(0) = New SqlParameter("@ClaimNo", Data.SqlDbType.VarChar)
        oParam(0).Value = CType(ClaimNo, String)

        oParam(1) = New SqlParameter("@PolicyNo", Data.SqlDbType.VarChar)
        oParam(1).Value = CType(PolicyNo, String)

        oParam(2) = New SqlParameter("@Total_Invoiced_amount", Data.SqlDbType.Decimal)
        oParam(2).Value = CType(Total_Invoiced_amount, Decimal)

        oParam(3) = New SqlParameter("@Eligible_Charges", Data.SqlDbType.Decimal)
        oParam(3).Value = CType(Eligible_Charges, Decimal)

        oParam(4) = New SqlParameter("@Ineligible_Charges", Data.SqlDbType.Decimal)
        oParam(4).Value = CType(Ineligible_Charges, Decimal)

        oParam(5) = New SqlParameter("@Hospitally_in_Indonesia", Data.SqlDbType.VarChar)
        oParam(5).Value = CType(Hospitally_in_Indonesia, String)

        oParam(6) = New SqlParameter("@RoomCharges", Data.SqlDbType.Decimal)
        oParam(6).Value = CType(RoomCharges, Decimal)

        oParam(7) = New SqlParameter("@RoomType", Data.SqlDbType.VarChar)
        oParam(7).Value = CType(RoomType, String)

        oParam(8) = New SqlParameter("@HospitalName", Data.SqlDbType.VarChar)
        oParam(8).Value = CType(HospitalName, String)

        oParam(9) = New SqlParameter("@Indicative_Lowest_Cost_Room_Rate", Data.SqlDbType.Decimal)
        oParam(9).Value = CType(Indicative_Lowest_Cost_Room_Rate, Decimal)

        oParam(10) = New SqlParameter("@SuspectedUpgrade", Data.SqlDbType.VarChar)
        oParam(10).Value = CType(SuspectedUpgrade, String)

        oParam(11) = New SqlParameter("@ActualUpgrade", Data.SqlDbType.VarChar)
        oParam(11).Value = CType(ActualUpgrade, String)

        oParam(12) = New SqlParameter("@ActualLowestCostAvailableRoom", Data.SqlDbType.Decimal)
        oParam(12).Value = CType(ActualLowestCostAvailableRoom, Decimal)

        oParam(13) = New SqlParameter("@DeterminingUpgradeCostShare", Data.SqlDbType.VarChar)
        oParam(13).Value = CType(DeterminingUpgradeCostShare, String)

        oParam(14) = New SqlParameter("@UpgradeLimit", Data.SqlDbType.Decimal)
        oParam(14).Value = CType(UpgradeLimit, Decimal)

        oParam(15) = New SqlParameter("@NumberOfNights", Data.SqlDbType.Int)
        oParam(15).Value = CType(NumberOfNights, Integer)

        oParam(16) = New SqlParameter("@TotalCostForStay", Data.SqlDbType.Decimal)
        oParam(16).Value = CType(TotalCostForStay, Decimal)

        oParam(17) = New SqlParameter("@AboveLimit", Data.SqlDbType.VarChar)
        oParam(17).Value = CType(AboveLimit, String)

        oParam(18) = New SqlParameter("@UPGRADE_TYPE", Data.SqlDbType.VarChar)
        oParam(18).Value = CType(UPGRADE_TYPE, String)

        oParam(19) = New SqlParameter("@UPGRADE_Percent", Data.SqlDbType.VarChar)
        oParam(19).Value = CType(UPGRADE_Percent, String)

        oParam(20) = New SqlParameter("@NationalRoomChargeBorneByMember", Data.SqlDbType.Decimal)
        oParam(20).Value = CType(NationalRoomChargeBorneByMember, Decimal)

        oParam(21) = New SqlParameter("@PayableToCust", Data.SqlDbType.Decimal)
        oParam(21).Value = CType(PayableToCust, Decimal)

        oParam(22) = New SqlParameter("@NotPayable", Data.SqlDbType.Decimal)
        oParam(22).Value = CType(NotPayable, Decimal)

        oParam(23) = New SqlParameter("@Beneficiary_Bank_Name", Data.SqlDbType.VarChar)
        oParam(23).Value = CType(Beneficiary_Bank_Name, String)

        oParam(24) = New SqlParameter("@Beneficiary_Branch", Data.SqlDbType.VarChar)
        oParam(24).Value = CType(Beneficiary_Branch, String)

        oParam(25) = New SqlParameter("@Beneficiary_Account_No", Data.SqlDbType.VarChar)
        oParam(25).Value = CType(Beneficiary_Account_No, String)

        oParam(26) = New SqlParameter("@Beneficiary_Name", Data.SqlDbType.VarChar)
        oParam(26).Value = CType(Beneficiary_Name, String)

        oParam(27) = New SqlParameter("@Remarks", Data.SqlDbType.VarChar)
        oParam(27).Value = CType(Remarks, String)

        oParam(28) = New SqlParameter("@CreatedBy", Data.SqlDbType.VarChar)
        oParam(28).Value = CType(CreatedBy, String)

        oParam(29) = New SqlParameter("@CURRENCY", Data.SqlDbType.VarChar)
        oParam(29).Value = CType(CURRENCY, String)

        oParam(30) = New SqlParameter("@PAYMENTDETAILS3", Data.SqlDbType.VarChar)
        oParam(30).Value = CType(PAYMENTDETAILS3, String)

        oParam(31) = New SqlParameter("@CURRENCYTTOTAL", Data.SqlDbType.VarChar)
        oParam(31).Value = CType(CURRENCYTTOTAL, String)

        oParam(32) = New SqlParameter("@CURRENCYHOSPITAL", Data.SqlDbType.VarChar)
        oParam(32).Value = CType(CURRENCYHOSPITAL, String)

        oParam(33) = New SqlParameter("@STATUSSEND", Data.SqlDbType.VarChar)
        oParam(33).Value = CType(STATUSSEND, String)

        oParam(34) = New SqlParameter("@STATUSSENDING", Data.SqlDbType.VarChar)
        oParam(34).Value = CType(STATUSSENDING, String)

        oParam(35) = New SqlParameter("@Total_Invoiced_amount_Convert", Data.SqlDbType.Decimal)
        oParam(35).Value = CType(Total_Invoiced_amount, Decimal)

        oParam(36) = New SqlParameter("@Eligible_Charges_Convert", Data.SqlDbType.Decimal)
        oParam(36).Value = CType(Eligible_Charges, Decimal)

        oParam(37) = New SqlParameter("@Ineligible_Charges_Convert", Data.SqlDbType.Decimal)
        oParam(37).Value = CType(Ineligible_Charges, Decimal)

        oParam(38) = New SqlParameter("@EXCH", Data.SqlDbType.Decimal)
        oParam(38).Value = CType(EXCH, Decimal)

        oParam(39) = New SqlParameter("@PayableToCustConvert", Data.SqlDbType.Decimal)
        oParam(39).Value = CType(PayableToCustConvert, Decimal)

        oParam(40) = New SqlParameter("@PayDetails", Data.SqlDbType.VarChar)
        oParam(40).Value = CType(PayDetails, String)

        oParam(41) = New SqlParameter("@CountPayment", Data.SqlDbType.Int)
        oParam(41).Value = CType(CountPayment, Integer)

        oParam(42) = New SqlParameter("@IDXFBA", Data.SqlDbType.Int)
        oParam(42).Value = CType(IDXFBA, Integer)

        oParam(43) = New SqlParameter("@btnParam", Data.SqlDbType.VarChar)
        oParam(43).Value = CType(btnParam, String)

        oParam(44) = New SqlParameter("@FBAHeader", Data.SqlDbType.VarChar)
        oParam(44).Value = CType(FBAHeader, String)

        oParam(45) = New SqlParameter("@FBADetail", Data.SqlDbType.VarChar)
        oParam(45).Value = CType(FBADetail, String)

        oParam(46) = New SqlParameter("@ActualRB", Data.SqlDbType.Decimal)
        oParam(46).Value = CType(ActualRB, Decimal)

        oParam(47) = New SqlParameter("@SumActualRB", Data.SqlDbType.Decimal)
        oParam(47).Value = CType(SumActualRB, Decimal)

        oParam(48) = New SqlParameter("@Plan", Data.SqlDbType.Decimal)
        oParam(48).Value = CType(Plan, Decimal)

        oParam(49) = New SqlParameter("@SumPlan", Data.SqlDbType.Decimal)
        oParam(49).Value = CType(SumPlan, Decimal)

        oParam(50) = New SqlParameter("@CashBen_Night", Data.SqlDbType.Int)
        oParam(50).Value = CType(CashBen_Night, Integer)

        oParam(51) = New SqlParameter("@CashBen_Unit", Data.SqlDbType.Int)
        oParam(51).Value = CType(CashBen_Unit, Integer)

        oParam(52) = New SqlParameter("@CashBen_UnitTambahan", Data.SqlDbType.Decimal)
        oParam(52).Value = CType(CashBen_UnitTambahan, Decimal)

        oParam(53) = New SqlParameter("@CashBen_UnitDasar", Data.SqlDbType.Decimal)
        oParam(53).Value = CType(CashBen_UnitDasar, Decimal)

        oParam(54) = New SqlParameter("@CashBen_UnitNasabah", Data.SqlDbType.Decimal)
        oParam(54).Value = CType(CashBen_UnitNasabah, Decimal)

        oParam(55) = New SqlParameter("@TotalCashBen_Unit", Data.SqlDbType.Decimal)
        oParam(55).Value = CType(TotalCashBen_Unit, Decimal)

        oParam(56) = New SqlParameter("@TotalPayAble", Data.SqlDbType.Decimal)
        oParam(56).Value = CType(TotalPayAble, Decimal)

        oParam(57) = New SqlParameter("@CashBackDetail", Data.SqlDbType.VarChar)
        oParam(57).Value = CType(CashBackDetail, String)

        oParam(58) = New SqlParameter("@DateExhRate", Data.SqlDbType.Date)
        oParam(58).Value = CType(DateExhRate, Date)

        'oParam(59) = New SqlParameter("@StatusFBA", Data.SqlDbType.VarChar)
        'oParam(59).Value = CType(StatusFBA, String)

        Dim _connectionString As String = _connectionString_AFI

        Return (ExecuteNonQuery(_connectionString, const_SP_INSERT_FBA2, Data.CommandType.StoredProcedure, oParam))

    End Function

    Public Function f_Insert_FBA2(ByVal ClaimNo As String, ByVal PolicyNo As String, _
                                         ByVal Total_Invoiced_amount As Decimal, ByVal Eligible_Charges As Decimal, _
                                         ByVal Ineligible_Charges As String, ByVal Hospitally_in_Indonesia As String, _
                                         ByVal RoomCharges As Decimal, ByVal RoomType As String, _
                                         ByVal HospitalName As String, ByVal Indicative_Lowest_Cost_Room_Rate As Decimal, _
                                         ByVal SuspectedUpgrade As String, ByVal ActualUpgrade As String, _
                                         ByVal ActualLowestCostAvailableRoom As Decimal, _
                                         ByVal DeterminingUpgradeCostShare As String, ByVal UpgradeLimit As Decimal, _
                                         ByVal NumberOfNights As Integer, ByVal TotalCostForStay As Decimal, _
                                         ByVal AboveLimit As String, ByVal UPGRADE_TYPE As String, _
                                         ByVal UPGRADE_Percent As String, ByVal NationalRoomChargeBorneByMember As Decimal, _
                                         ByVal PayableToCust As Decimal, ByVal NotPayable As Decimal, _
                                         ByVal Beneficiary_Bank_Name As String, ByVal Beneficiary_Branch As String, _
                                         ByVal Beneficiary_Account_No As String, ByVal Beneficiary_Name As String, _
                                         ByVal Remarks As String, ByVal CreatedBy As String, ByVal CURRENCY As String, ByVal PAYMENTDETAILS3 As String, _
                                         ByVal CURRENCYTTOTAL As String, ByVal CURRENCYHOSPITAL As String, ByVal STATUSSEND As String, ByVal STATUSSENDING As String, _
                                         ByVal Total_Invoiced_amount_Convert As Decimal, ByVal Eligible_Charges_Convert As Decimal, _
                                         ByVal Ineligible_Charges_Convert As Decimal, ByVal EXCH As Decimal, ByVal PayableToCustConvert As Decimal, ByVal PayDetails As String, _
                                         ByVal CountPayment As Integer, ByVal IDXFBA As Integer, ByVal btnParam As String, _
                                         ByVal FBAHeader As String, ByVal FBADetail As String, _
                                         ByVal ActualRB As Decimal, ByVal SumActualRB As Decimal, _
                                         ByVal Plan As Decimal, ByVal SumPlan As Decimal, ByVal CashBen_Night As Integer, _
                                         ByVal CashBen_Unit As Integer, ByVal CashBen_UnitTambahan As Decimal, _
                                         ByVal CashBen_UnitDasar As Decimal, ByVal CashBen_UnitNasabah As Decimal, ByVal TotalCashBen_Unit As Decimal, _
                                         ByVal TotalPayAble As Decimal, ByVal CashBackDetail As String, ByVal DateExhRate As Date, _
                                         ByVal StatusFBA As String)

        Dim oParam(59) As SqlParameter

        oParam(0) = New SqlParameter("@ClaimNo", Data.SqlDbType.VarChar)
        oParam(0).Value = CType(ClaimNo, String)

        oParam(1) = New SqlParameter("@PolicyNo", Data.SqlDbType.VarChar)
        oParam(1).Value = CType(PolicyNo, String)

        oParam(2) = New SqlParameter("@Total_Invoiced_amount", Data.SqlDbType.Decimal)
        oParam(2).Value = CType(Total_Invoiced_amount, Decimal)

        oParam(3) = New SqlParameter("@Eligible_Charges", Data.SqlDbType.Decimal)
        oParam(3).Value = CType(Eligible_Charges, Decimal)

        oParam(4) = New SqlParameter("@Ineligible_Charges", Data.SqlDbType.Decimal)
        oParam(4).Value = CType(Ineligible_Charges, Decimal)

        oParam(5) = New SqlParameter("@Hospitally_in_Indonesia", Data.SqlDbType.VarChar)
        oParam(5).Value = CType(Hospitally_in_Indonesia, String)

        oParam(6) = New SqlParameter("@RoomCharges", Data.SqlDbType.Decimal)
        oParam(6).Value = CType(RoomCharges, Decimal)

        oParam(7) = New SqlParameter("@RoomType", Data.SqlDbType.VarChar)
        oParam(7).Value = CType(RoomType, String)

        oParam(8) = New SqlParameter("@HospitalName", Data.SqlDbType.VarChar)
        oParam(8).Value = CType(HospitalName, String)

        oParam(9) = New SqlParameter("@Indicative_Lowest_Cost_Room_Rate", Data.SqlDbType.Decimal)
        oParam(9).Value = CType(Indicative_Lowest_Cost_Room_Rate, Decimal)

        oParam(10) = New SqlParameter("@SuspectedUpgrade", Data.SqlDbType.VarChar)
        oParam(10).Value = CType(SuspectedUpgrade, String)

        oParam(11) = New SqlParameter("@ActualUpgrade", Data.SqlDbType.VarChar)
        oParam(11).Value = CType(ActualUpgrade, String)

        oParam(12) = New SqlParameter("@ActualLowestCostAvailableRoom", Data.SqlDbType.Decimal)
        oParam(12).Value = CType(ActualLowestCostAvailableRoom, Decimal)

        oParam(13) = New SqlParameter("@DeterminingUpgradeCostShare", Data.SqlDbType.VarChar)
        oParam(13).Value = CType(DeterminingUpgradeCostShare, String)

        oParam(14) = New SqlParameter("@UpgradeLimit", Data.SqlDbType.Decimal)
        oParam(14).Value = CType(UpgradeLimit, Decimal)

        oParam(15) = New SqlParameter("@NumberOfNights", Data.SqlDbType.Int)
        oParam(15).Value = CType(NumberOfNights, Integer)

        oParam(16) = New SqlParameter("@TotalCostForStay", Data.SqlDbType.Decimal)
        oParam(16).Value = CType(TotalCostForStay, Decimal)

        oParam(17) = New SqlParameter("@AboveLimit", Data.SqlDbType.VarChar)
        oParam(17).Value = CType(AboveLimit, String)

        oParam(18) = New SqlParameter("@UPGRADE_TYPE", Data.SqlDbType.VarChar)
        oParam(18).Value = CType(UPGRADE_TYPE, String)

        oParam(19) = New SqlParameter("@UPGRADE_Percent", Data.SqlDbType.VarChar)
        oParam(19).Value = CType(UPGRADE_Percent, String)

        oParam(20) = New SqlParameter("@NationalRoomChargeBorneByMember", Data.SqlDbType.Decimal)
        oParam(20).Value = CType(NationalRoomChargeBorneByMember, Decimal)

        oParam(21) = New SqlParameter("@PayableToCust", Data.SqlDbType.Decimal)
        oParam(21).Value = CType(PayableToCust, Decimal)

        oParam(22) = New SqlParameter("@NotPayable", Data.SqlDbType.Decimal)
        oParam(22).Value = CType(NotPayable, Decimal)

        oParam(23) = New SqlParameter("@Beneficiary_Bank_Name", Data.SqlDbType.VarChar)
        oParam(23).Value = CType(Beneficiary_Bank_Name, String)

        oParam(24) = New SqlParameter("@Beneficiary_Branch", Data.SqlDbType.VarChar)
        oParam(24).Value = CType(Beneficiary_Branch, String)

        oParam(25) = New SqlParameter("@Beneficiary_Account_No", Data.SqlDbType.VarChar)
        oParam(25).Value = CType(Beneficiary_Account_No, String)

        oParam(26) = New SqlParameter("@Beneficiary_Name", Data.SqlDbType.VarChar)
        oParam(26).Value = CType(Beneficiary_Name, String)

        oParam(27) = New SqlParameter("@Remarks", Data.SqlDbType.VarChar)
        oParam(27).Value = CType(Remarks, String)

        oParam(28) = New SqlParameter("@CreatedBy", Data.SqlDbType.VarChar)
        oParam(28).Value = CType(CreatedBy, String)

        oParam(29) = New SqlParameter("@CURRENCY", Data.SqlDbType.VarChar)
        oParam(29).Value = CType(CURRENCY, String)

        oParam(30) = New SqlParameter("@PAYMENTDETAILS3", Data.SqlDbType.VarChar)
        oParam(30).Value = CType(PAYMENTDETAILS3, String)

        oParam(31) = New SqlParameter("@CURRENCYTTOTAL", Data.SqlDbType.VarChar)
        oParam(31).Value = CType(CURRENCYTTOTAL, String)

        oParam(32) = New SqlParameter("@CURRENCYHOSPITAL", Data.SqlDbType.VarChar)
        oParam(32).Value = CType(CURRENCYHOSPITAL, String)

        oParam(33) = New SqlParameter("@STATUSSEND", Data.SqlDbType.VarChar)
        oParam(33).Value = CType(STATUSSEND, String)

        oParam(34) = New SqlParameter("@STATUSSENDING", Data.SqlDbType.VarChar)
        oParam(34).Value = CType(STATUSSENDING, String)

        oParam(35) = New SqlParameter("@Total_Invoiced_amount_Convert", Data.SqlDbType.Decimal)
        oParam(35).Value = CType(Total_Invoiced_amount, Decimal)

        oParam(36) = New SqlParameter("@Eligible_Charges_Convert", Data.SqlDbType.Decimal)
        oParam(36).Value = CType(Eligible_Charges, Decimal)

        oParam(37) = New SqlParameter("@Ineligible_Charges_Convert", Data.SqlDbType.Decimal)
        oParam(37).Value = CType(Ineligible_Charges, Decimal)

        oParam(38) = New SqlParameter("@EXCH", Data.SqlDbType.Decimal)
        oParam(38).Value = CType(EXCH, Decimal)

        oParam(39) = New SqlParameter("@PayableToCustConvert", Data.SqlDbType.Decimal)
        oParam(39).Value = CType(PayableToCustConvert, Decimal)

        oParam(40) = New SqlParameter("@PayDetails", Data.SqlDbType.VarChar)
        oParam(40).Value = CType(PayDetails, String)

        oParam(41) = New SqlParameter("@CountPayment", Data.SqlDbType.Int)
        oParam(41).Value = CType(CountPayment, Integer)

        oParam(42) = New SqlParameter("@IDXFBA", Data.SqlDbType.Int)
        oParam(42).Value = CType(IDXFBA, Integer)

        oParam(43) = New SqlParameter("@btnParam", Data.SqlDbType.VarChar)
        oParam(43).Value = CType(btnParam, String)

        oParam(44) = New SqlParameter("@FBAHeader", Data.SqlDbType.VarChar)
        oParam(44).Value = CType(FBAHeader, String)

        oParam(45) = New SqlParameter("@FBADetail", Data.SqlDbType.VarChar)
        oParam(45).Value = CType(FBADetail, String)

        oParam(46) = New SqlParameter("@ActualRB", Data.SqlDbType.Decimal)
        oParam(46).Value = CType(ActualRB, Decimal)

        oParam(47) = New SqlParameter("@SumActualRB", Data.SqlDbType.Decimal)
        oParam(47).Value = CType(SumActualRB, Decimal)

        oParam(48) = New SqlParameter("@Plan", Data.SqlDbType.Decimal)
        oParam(48).Value = CType(Plan, Decimal)

        oParam(49) = New SqlParameter("@SumPlan", Data.SqlDbType.Decimal)
        oParam(49).Value = CType(SumPlan, Decimal)

        oParam(50) = New SqlParameter("@CashBen_Night", Data.SqlDbType.Int)
        oParam(50).Value = CType(CashBen_Night, Integer)

        oParam(51) = New SqlParameter("@CashBen_Unit", Data.SqlDbType.Int)
        oParam(51).Value = CType(CashBen_Unit, Integer)

        oParam(52) = New SqlParameter("@CashBen_UnitTambahan", Data.SqlDbType.Decimal)
        oParam(52).Value = CType(CashBen_UnitTambahan, Decimal)

        oParam(53) = New SqlParameter("@CashBen_UnitDasar", Data.SqlDbType.Decimal)
        oParam(53).Value = CType(CashBen_UnitDasar, Decimal)

        oParam(54) = New SqlParameter("@CashBen_UnitNasabah", Data.SqlDbType.Decimal)
        oParam(54).Value = CType(CashBen_UnitNasabah, Decimal)

        oParam(55) = New SqlParameter("@TotalCashBen_Unit", Data.SqlDbType.Decimal)
        oParam(55).Value = CType(TotalCashBen_Unit, Decimal)

        oParam(56) = New SqlParameter("@TotalPayAble", Data.SqlDbType.Decimal)
        oParam(56).Value = CType(TotalPayAble, Decimal)

        oParam(57) = New SqlParameter("@CashBackDetail", Data.SqlDbType.VarChar)
        oParam(57).Value = CType(CashBackDetail, String)

        oParam(58) = New SqlParameter("@DateExhRate", Data.SqlDbType.Date)
        oParam(58).Value = CType(DateExhRate, Date)

        oParam(59) = New SqlParameter("@StatusFBA", Data.SqlDbType.VarChar)
        oParam(59).Value = CType(StatusFBA, String)

        Dim _connectionString As String = _connectionString_AFI

        Return (ExecuteNonQuery(_connectionString, const_SP_INSERT_FBA2, Data.CommandType.StoredProcedure, oParam))

    End Function

    'Public Function f_Insert_Upload_Enrollment(ByVal _PathFile As String, ByVal UploadID As String, ByVal EntityName As String, ByVal CreatedBy As String)

    '    Dim oParam(3) As SqlParameter

    '    oParam(0) = New SqlParameter("@PathFileName", Data.SqlDbType.VarChar)
    '    oParam(0).Value = CType(_PathFile, String)

    '    oParam(1) = New SqlParameter("@UPLOADID", Data.SqlDbType.VarChar)
    '    oParam(1).Value = CType(UploadID, String)

    '    oParam(2) = New SqlParameter("@ENTITYNAME", Data.SqlDbType.VarChar)
    '    oParam(2).Value = CType(EntityName, String)

    '    oParam(3) = New SqlParameter("@CREATEDBY", Data.SqlDbType.VarChar)
    '    oParam(3).Value = CType(CreatedBy, String)


    '    Dim _connectionString As String = _connectionString_AHS


    '    Return (ExecuteNonQuery(_connectionString, const_SP_INSERT_UPLOAD_ENROLLMENT, Data.CommandType.StoredProcedure, oParam))

    'End Function
    Public Function f_Insert_TRN_FOLLOW_UP(ByVal ClaimNo As String, ByVal PolicyNo As String, _
                                       ByVal DATES As Date, ByVal REMARKS As String, _
                                       ByVal CreatedBy As String)
        Dim oParam(4) As SqlParameter

        oParam(0) = New SqlParameter("@ClaimNo", Data.SqlDbType.VarChar)
        oParam(0).Value = CType(ClaimNo, String)

        oParam(1) = New SqlParameter("@PolicyNo", Data.SqlDbType.VarChar)
        oParam(1).Value = CType(PolicyNo, String)

        oParam(2) = New SqlParameter("@DATE", Data.SqlDbType.Date)
        oParam(2).Value = CType(DATES, Date)

        oParam(3) = New SqlParameter("@REMARKS", Data.SqlDbType.VarChar)
        oParam(3).Value = CType(REMARKS, String)

        oParam(4) = New SqlParameter("@CREATEDBY", Data.SqlDbType.VarChar)
        oParam(4).Value = CType(CreatedBy, String)

        Dim _connectionString As String = _connectionString_AFI


        Return (ExecuteNonQuery(_connectionString, const_SP_INSERT_TRN_CASE_FOLLOW_UP, Data.CommandType.StoredProcedure, oParam))

    End Function
    Public Function f_Insert_FBA_NON_MED(ByVal ClaimNo As String, ByVal PolicyNo As String, _
                                         ByVal NonMedisDesc As String, ByVal NonMedisPay As Decimal, ByVal NonMedisPayConvert As Decimal, _
                                         ByVal CreatedBy As String, ByVal IDX As String, ByVal CURRENCY As String)
        'ByVal IDXFBA As String, ByVal PAYDETAILS As String)

        Dim oParam(7) As SqlParameter

        oParam(0) = New SqlParameter("@ClaimNo", Data.SqlDbType.VarChar)
        oParam(0).Value = CType(ClaimNo, String)

        oParam(1) = New SqlParameter("@PolicyNo", Data.SqlDbType.VarChar)
        oParam(1).Value = CType(PolicyNo, String)

        oParam(2) = New SqlParameter("@NonMedisDesc", Data.SqlDbType.VarChar)
        oParam(2).Value = CType(NonMedisDesc, String)

        oParam(3) = New SqlParameter("@CREATEDBY", Data.SqlDbType.VarChar)
        oParam(3).Value = CType(CreatedBy, String)

        oParam(4) = New SqlParameter("@NonMedisPay", Data.SqlDbType.Decimal)
        oParam(4).Value = CType(NonMedisPay, Decimal)

        oParam(5) = New SqlParameter("@NonMedisPayConvert", Data.SqlDbType.Decimal)
        oParam(5).Value = CType(NonMedisPayConvert, Decimal)

        oParam(6) = New SqlParameter("@IDX", Data.SqlDbType.VarChar)
        oParam(6).Value = CType(IDX, String)

        oParam(7) = New SqlParameter("@CURRENCY", Data.SqlDbType.VarChar)
        oParam(7).Value = CType(CURRENCY, String)

        'oParam(8) = New SqlParameter("@IDXFBA", Data.SqlDbType.VarChar)
        'oParam(8).Value = CType(IDXFBA, String)

        'oParam(9) = New SqlParameter("@PAYDETAILS", Data.SqlDbType.VarChar)
        'oParam(9).Value = CType(PAYDETAILS, String)

        Dim _connectionString As String = _connectionString_AFI


        Return (ExecuteNonQuery(_connectionString, const_SP_INSERT_FBA_NON_MED, Data.CommandType.StoredProcedure, oParam))

    End Function
    Public Function f_Insert_FBA_NON_MED2(ByVal ClaimNo As String, ByVal PolicyNo As String, _
                                         ByVal NonMedisDesc As String, ByVal NonMedisPay As Decimal, ByVal NonMedisPayConvert As Decimal, _
                                         ByVal CreatedBy As String, ByVal IDX As String, ByVal CURRENCY As String, _
                                         ByVal IDXFBA As String, ByVal PAYDETAILS As String)

        Dim oParam(9) As SqlParameter

        oParam(0) = New SqlParameter("@ClaimNo", Data.SqlDbType.VarChar)
        oParam(0).Value = CType(ClaimNo, String)

        oParam(1) = New SqlParameter("@PolicyNo", Data.SqlDbType.VarChar)
        oParam(1).Value = CType(PolicyNo, String)

        oParam(2) = New SqlParameter("@NonMedisDesc", Data.SqlDbType.VarChar)
        oParam(2).Value = CType(NonMedisDesc, String)

        oParam(3) = New SqlParameter("@CREATEDBY", Data.SqlDbType.VarChar)
        oParam(3).Value = CType(CreatedBy, String)

        oParam(4) = New SqlParameter("@NonMedisPay", Data.SqlDbType.Decimal)
        oParam(4).Value = CType(NonMedisPay, Decimal)

        oParam(5) = New SqlParameter("@NonMedisPayConvert", Data.SqlDbType.Decimal)
        oParam(5).Value = CType(NonMedisPayConvert, Decimal)

        oParam(6) = New SqlParameter("@IDX", Data.SqlDbType.VarChar)
        oParam(6).Value = CType(IDX, String)

        oParam(7) = New SqlParameter("@CURRENCY", Data.SqlDbType.VarChar)
        oParam(7).Value = CType(CURRENCY, String)

        oParam(8) = New SqlParameter("@IDXFBA", Data.SqlDbType.VarChar)
        oParam(8).Value = CType(IDXFBA, String)

        oParam(9) = New SqlParameter("@PAYDETAILS", Data.SqlDbType.VarChar)
        oParam(9).Value = CType(PAYDETAILS, String)

        Dim _connectionString As String = _connectionString_AFI


        Return (ExecuteNonQuery(_connectionString, const_SP_INSERT_FBA_NON_MED, Data.CommandType.StoredProcedure, oParam))

    End Function

    Public Function f_Insert_FBA_CASHBACK_BENEFIT(ByVal ClaimNo As String, ByVal PolicyNo As String, _
                                         ByVal Currency As String, ByVal BaseUnit As Decimal, ByVal ExtraUnit As Decimal, _
                                         ByVal TotalBaseExtraUnit As Decimal, ByVal PriceNight As Decimal, _
                                         ByVal Night As Integer, ByVal IDXFBA As Integer, ByVal PAYDETAILS As String, _
                                         ByVal CreatedBy As String, ByVal Pay As Decimal, ByVal PayConvert As Decimal, ByVal IDX As Integer)

        Dim oParam(13) As SqlParameter

        oParam(0) = New SqlParameter("@ClaimNo", Data.SqlDbType.VarChar)
        oParam(0).Value = CType(ClaimNo, String)

        oParam(1) = New SqlParameter("@PolicyNo", Data.SqlDbType.VarChar)
        oParam(1).Value = CType(PolicyNo, String)

        oParam(2) = New SqlParameter("@Currency", Data.SqlDbType.VarChar)
        oParam(2).Value = CType(Currency, String)

        oParam(3) = New SqlParameter("@BaseUnit", Data.SqlDbType.Decimal)
        oParam(3).Value = CType(BaseUnit, Decimal)

        oParam(4) = New SqlParameter("@ExtraUnit", Data.SqlDbType.Decimal)
        oParam(4).Value = CType(ExtraUnit, Decimal)

        oParam(5) = New SqlParameter("@TotalBaseExtraUnit", Data.SqlDbType.Decimal)
        oParam(5).Value = CType(TotalBaseExtraUnit, Decimal)

        oParam(6) = New SqlParameter("@PriceNight", Data.SqlDbType.Decimal)
        oParam(6).Value = CType(PriceNight, Decimal)

        oParam(7) = New SqlParameter("@Night", Data.SqlDbType.Int)
        oParam(7).Value = CType(Night, Integer)

        oParam(8) = New SqlParameter("@IDXFBA", Data.SqlDbType.Int)
        oParam(8).Value = CType(IDXFBA, Integer)

        oParam(9) = New SqlParameter("@PAYDETAILS", Data.SqlDbType.VarChar)
        oParam(9).Value = CType(PAYDETAILS, String)

        oParam(10) = New SqlParameter("@CREATEDBY", Data.SqlDbType.VarChar)
        oParam(10).Value = CType(CreatedBy, String)

        oParam(11) = New SqlParameter("@Pay", Data.SqlDbType.Decimal)
        oParam(11).Value = CType(Pay, Decimal)

        oParam(12) = New SqlParameter("@PayConvert", Data.SqlDbType.Decimal)
        oParam(12).Value = CType(PayConvert, Decimal)

        oParam(13) = New SqlParameter("@IDX", Data.SqlDbType.Int)
        oParam(13).Value = CType(IDX, Integer)

        Dim _connectionString As String = _connectionString_AFI


        Return (ExecuteNonQuery(_connectionString, const_SP_INSERT_FBA_CASHBACK_BENEFIT, Data.CommandType.StoredProcedure, oParam))

    End Function

    Public Function f_Insert_FBA_OBT(ByVal ClaimNo As String, ByVal PolicyNo As String, _
                                         ByVal OTBDDXDesc As String, ByVal OTBDDXPay As Decimal, ByVal OTBDDXPayConvert As Decimal, _
                                         ByVal CreatedBy As String, ByVal IDX As String, ByVal CURRENCY As String)
        'ByVal IDXFBA As String, ByVal PAYDETAILS As String)

        Dim oParam(7) As SqlParameter

        oParam(0) = New SqlParameter("@ClaimNo", Data.SqlDbType.VarChar)
        oParam(0).Value = CType(ClaimNo, String)

        oParam(1) = New SqlParameter("@PolicyNo", Data.SqlDbType.VarChar)
        oParam(1).Value = CType(PolicyNo, String)

        oParam(2) = New SqlParameter("@OTBDDXDesc", Data.SqlDbType.VarChar)
        oParam(2).Value = CType(OTBDDXDesc, String)

        oParam(3) = New SqlParameter("@CREATEDBY", Data.SqlDbType.VarChar)
        oParam(3).Value = CType(CreatedBy, String)

        oParam(4) = New SqlParameter("@OTBDDXPay", Data.SqlDbType.Float)
        oParam(4).Value = CType(OTBDDXPay, Decimal)

        oParam(5) = New SqlParameter("@OTBDDXPayCONVERT", Data.SqlDbType.Float)
        oParam(5).Value = CType(OTBDDXPayConvert, Decimal)

        oParam(6) = New SqlParameter("@IDX", Data.SqlDbType.VarChar)
        oParam(6).Value = CType(IDX, String)

        oParam(7) = New SqlParameter("@CURRENCY", Data.SqlDbType.VarChar)
        oParam(7).Value = CType(CURRENCY, String)

        'oParam(8) = New SqlParameter("@IDXFBA", Data.SqlDbType.VarChar)
        'oParam(8).Value = CType(IDXFBA, String)

        'oParam(9) = New SqlParameter("@PAYDETAILS", Data.SqlDbType.VarChar)
        'oParam(9).Value = CType(PAYDETAILS, String)

        Dim _connectionString As String = _connectionString_AFI


        Return (ExecuteNonQuery(_connectionString, const_SP_INSERT_FBA_OBT, Data.CommandType.StoredProcedure, oParam))

    End Function
    Public Function f_Insert_FBA_OBT2(ByVal ClaimNo As String, ByVal PolicyNo As String, _
                                         ByVal OTBDDXDesc As String, ByVal OTBDDXPay As Decimal, ByVal OTBDDXPayConvert As Decimal, _
                                         ByVal CreatedBy As String, ByVal IDX As String, ByVal CURRENCY As String, _
                                         ByVal IDXFBA As String, ByVal PAYDETAILS As String)

        Dim oParam(9) As SqlParameter

        oParam(0) = New SqlParameter("@ClaimNo", Data.SqlDbType.VarChar)
        oParam(0).Value = CType(ClaimNo, String)

        oParam(1) = New SqlParameter("@PolicyNo", Data.SqlDbType.VarChar)
        oParam(1).Value = CType(PolicyNo, String)

        oParam(2) = New SqlParameter("@OTBDDXDesc", Data.SqlDbType.VarChar)
        oParam(2).Value = CType(OTBDDXDesc, String)

        oParam(3) = New SqlParameter("@CREATEDBY", Data.SqlDbType.VarChar)
        oParam(3).Value = CType(CreatedBy, String)

        oParam(4) = New SqlParameter("@OTBDDXPay", Data.SqlDbType.Float)
        oParam(4).Value = CType(OTBDDXPay, Decimal)

        oParam(5) = New SqlParameter("@OTBDDXPayCONVERT", Data.SqlDbType.Float)
        oParam(5).Value = CType(OTBDDXPayConvert, Decimal)

        oParam(6) = New SqlParameter("@IDX", Data.SqlDbType.VarChar)
        oParam(6).Value = CType(IDX, String)

        oParam(7) = New SqlParameter("@CURRENCY", Data.SqlDbType.VarChar)
        oParam(7).Value = CType(CURRENCY, String)

        oParam(8) = New SqlParameter("@IDXFBA", Data.SqlDbType.VarChar)
        oParam(8).Value = CType(IDXFBA, String)

        oParam(9) = New SqlParameter("@PAYDETAILS", Data.SqlDbType.VarChar)
        oParam(9).Value = CType(PAYDETAILS, String)

        Dim _connectionString As String = _connectionString_AFI


        Return (ExecuteNonQuery(_connectionString, const_SP_INSERT_FBA_OBT, Data.CommandType.StoredProcedure, oParam))

    End Function


    Public Function f_Insert_FCR_TASKS(ByVal IDX As String, ByVal CLAIMNO As String, ByVal POLICYNO As String, ByVal PRODUCT As String, _
                                       ByVal ID_TEMPLATE As String, ByVal DAY As String, ByVal DATEBEGIN As Date, _
                                       ByVal TASKS As String, ByVal DATECOMPLETED As Date, ByVal CreatedBy As String)

        Dim oParam(9) As SqlParameter

        oParam(0) = New SqlParameter("@CLAIMNO", Data.SqlDbType.VarChar)
        oParam(0).Value = CType(CLAIMNO, String)

        oParam(1) = New SqlParameter("@POLICYNO", Data.SqlDbType.VarChar)
        oParam(1).Value = CType(POLICYNO, String)

        oParam(2) = New SqlParameter("@PRODUCT", Data.SqlDbType.VarChar)
        oParam(2).Value = CType(PRODUCT, String)

        oParam(3) = New SqlParameter("@ID_TEMPLATE", Data.SqlDbType.VarChar)
        oParam(3).Value = CType(ID_TEMPLATE, String)

        oParam(4) = New SqlParameter("@DAY", Data.SqlDbType.VarChar)
        oParam(4).Value = CType(DAY, String)

        oParam(5) = New SqlParameter("@DATEBEGIN", Data.SqlDbType.Date)
        oParam(5).Value = CType(DATEBEGIN, Date)

        oParam(6) = New SqlParameter("@TASKS", Data.SqlDbType.VarChar)
        oParam(6).Value = CType(TASKS, String)

        oParam(7) = New SqlParameter("@DATECOMPLETED", Data.SqlDbType.Date)
        oParam(7).Value = CType(DATECOMPLETED, Date)

        oParam(8) = New SqlParameter("@CREATEDBY", Data.SqlDbType.VarChar)
        oParam(8).Value = CType(CreatedBy, String)

        oParam(9) = New SqlParameter("@IDX", Data.SqlDbType.VarChar)
        oParam(9).Value = CType(IDX, String)

        Dim _connectionString As String = _connectionString_AFI


        Return (ExecuteNonQuery(_connectionString, const_SP_INSERT_FCR_TASKS, Data.CommandType.StoredProcedure, oParam))

    End Function

    Public Function f_Insert_FCR_INCOMPLETE_DOC(ByVal IDX As String, ByVal _CLAIMNO As String, ByVal _POLICYNO As String, ByVal _INC_DOC As String, ByVal CreatedBy As String)

        Dim oParam(4) As SqlParameter

        oParam(0) = New SqlParameter("@CLAIMNO", Data.SqlDbType.VarChar)
        oParam(0).Value = CType(_CLAIMNO, String)

        oParam(1) = New SqlParameter("@POLICYNO", Data.SqlDbType.VarChar)
        oParam(1).Value = CType(_POLICYNO, String)

        oParam(2) = New SqlParameter("@INCOMPLETE_DOCUMENT", Data.SqlDbType.VarChar)
        oParam(2).Value = CType(_INC_DOC, String)

        oParam(3) = New SqlParameter("@CREATEDBY", Data.SqlDbType.VarChar)
        oParam(3).Value = CType(CreatedBy, String)

        oParam(4) = New SqlParameter("@IDX", Data.SqlDbType.VarChar)
        oParam(4).Value = CType(IDX, String)


        Dim _connectionString As String = _connectionString_AFI


        Return (ExecuteNonQuery(_connectionString, const_SP_INSERT_FCR_INC_DOC, Data.CommandType.StoredProcedure, oParam))

    End Function

    Public Function f_Insert_FCR_REASON_INVEST(ByVal IDX As String, ByVal _CLAIMNO As String, ByVal _POLICYNO As String, ByVal REASONINVEST As String, ByVal CreatedBy As String)

        Dim oParam(4) As SqlParameter

        oParam(0) = New SqlParameter("@CLAIMNO", Data.SqlDbType.VarChar)
        oParam(0).Value = CType(_CLAIMNO, String)

        oParam(1) = New SqlParameter("@POLICYNO", Data.SqlDbType.VarChar)
        oParam(1).Value = CType(_POLICYNO, String)

        oParam(2) = New SqlParameter("@REASONINVEST", Data.SqlDbType.VarChar)
        oParam(2).Value = CType(REASONINVEST, String)

        oParam(3) = New SqlParameter("@CREATEDBY", Data.SqlDbType.VarChar)
        oParam(3).Value = CType(CreatedBy, String)

        oParam(4) = New SqlParameter("@IDX", Data.SqlDbType.VarChar)
        oParam(4).Value = CType(IDX, String)


        Dim _connectionString As String = _connectionString_AFI


        Return (ExecuteNonQuery(_connectionString, const_SP_INSERT_FCR_REASON_INVEST, Data.CommandType.StoredProcedure, oParam))

    End Function

    Public Function f_Insert_FCR_COMPLETE_DOC(ByVal IDX As String, ByVal _CLAIMNO As String, ByVal _POLICYNO As String, ByVal _INC_DOC As String, ByVal CreatedBy As String)

        Dim oParam(4) As SqlParameter

        oParam(0) = New SqlParameter("@CLAIMNO", Data.SqlDbType.VarChar)
        oParam(0).Value = CType(_CLAIMNO, String)

        oParam(1) = New SqlParameter("@POLICYNO", Data.SqlDbType.VarChar)
        oParam(1).Value = CType(_POLICYNO, String)

        oParam(2) = New SqlParameter("@COMPLETE_DOCUMENT", Data.SqlDbType.VarChar)
        oParam(2).Value = CType(_INC_DOC, String)

        oParam(3) = New SqlParameter("@CREATEDBY", Data.SqlDbType.VarChar)
        oParam(3).Value = CType(CreatedBy, String)

        oParam(4) = New SqlParameter("@IDX", Data.SqlDbType.VarChar)
        oParam(4).Value = CType(IDX, String)


        Dim _connectionString As String = _connectionString_AFI


        Return (ExecuteNonQuery(_connectionString, const_SP_INSERT_FCR_Complete_DOC, Data.CommandType.StoredProcedure, oParam))

    End Function
    Public Function f_Insert_BDX(ByVal FileName As String, ByVal CreatedBy As String, ByVal UploadID As Integer)

        Dim oParam(2) As SqlParameter

        oParam(0) = New SqlParameter("@FILENAME", Data.SqlDbType.VarChar)
        oParam(0).Value = CType(FileName, String)

        oParam(1) = New SqlParameter("@CREATEDBY", Data.SqlDbType.VarChar)
        oParam(1).Value = CType(CreatedBy, String)

        oParam(2) = New SqlParameter("@IDENTITY", Data.SqlDbType.Int)
        oParam(2).Value = CType(UploadID, Integer)



        Dim _connectionString As String = _connectionString_AFI


        Return (ExecuteNonQuery(_connectionString, const_SP_DOWNLOAD_UPLOADDATABDX, Data.CommandType.StoredProcedure, oParam))

    End Function


    Public Function f_Insert_FCR_POL_DOC(ByVal IDX As String, ByVal _CLAIMNO As String, ByVal _POLICYNO As String, ByVal _INC_DOC As String, ByVal CreatedBy As String, ByVal DATES As Date)

        Dim oParam(5) As SqlParameter

        oParam(0) = New SqlParameter("@CLAIMNO", Data.SqlDbType.VarChar)
        oParam(0).Value = CType(_CLAIMNO, String)

        oParam(1) = New SqlParameter("@POLICYNO", Data.SqlDbType.VarChar)
        oParam(1).Value = CType(_POLICYNO, String)

        oParam(2) = New SqlParameter("@POL_DOCUMENT", Data.SqlDbType.VarChar)
        oParam(2).Value = CType(_INC_DOC, String)

        oParam(3) = New SqlParameter("@CREATEDBY", Data.SqlDbType.VarChar)
        oParam(3).Value = CType(CreatedBy, String)

        oParam(4) = New SqlParameter("@IDX", Data.SqlDbType.VarChar)
        oParam(4).Value = CType(IDX, String)


        oParam(5) = New SqlParameter("@DATES", Data.SqlDbType.Date)
        oParam(5).Value = CType(DATES, Date)



        Dim _connectionString As String = _connectionString_AFI


        Return (ExecuteNonQuery(_connectionString, const_SP_INSERT_FCR_POL_DOC, Data.CommandType.StoredProcedure, oParam))

    End Function

    Public Function f_Insert_MST_CURRENCY(ByVal AMOUNT As Decimal, ByVal CreatedBy As String, ByVal CURRENCY As String)

        Dim oParam(2) As SqlParameter

        oParam(0) = New SqlParameter("@AMOUNT", Data.SqlDbType.Decimal)
        oParam(0).Value = CType(AMOUNT, Decimal)

        oParam(1) = New SqlParameter("@CreatedBy", Data.SqlDbType.VarChar)
        oParam(1).Value = CType(CreatedBy, String)

        oParam(2) = New SqlParameter("@CURRENCY", Data.SqlDbType.VarChar)
        oParam(2).Value = CType(CURRENCY, String)

        Dim _connectionString As String = _connectionString_AFI


        Return (ExecuteNonQuery(_connectionString, const_SP_INSERT_MST_CURRENCY, Data.CommandType.StoredProcedure, oParam))

    End Function


    Public Function f_Insert_FCR(ByVal _ClaimNo As String, ByVal _PolicyNo As String, _
                                 ByVal _Name As String, ByVal _Product As String, _
                                 ByVal _DateRec As Date, ByVal _FCRDONE As String, _
                                 ByVal _FAName As String, ByVal _Status As String, _
                                 ByVal _Notes As String, ByVal _INCOMPLETEDOC As String, _
                                 ByVal _MEDICALENQ As String, ByVal _DRAFTEDBY As String, _
                                 ByVal _DRAFTEDATE As Date, ByVal _TRANSDBY As String, _
                                 ByVal _TRANSDATE As Date, ByVal CreatedBy As String, _
                                 ByVal PREMIUM As Decimal, ByVal LEADERNAME As String, ByVal SalesOffice As String, _
                                 ByVal PHONE As String, ByVal EMAIL As String, ByVal Doctor As String, _
                                 ByVal CLAIMSTATUSCODE As String, ByVal FCRCLAIMSTATUS As String, ByVal REASONIVESTIGATION As String, _
                                 ByVal SUBSTATUSPENDING As String, ByVal SUBSTATUSAPPROVED As String)

        Dim oParam(26) As SqlParameter

        oParam(0) = New SqlParameter("@CLAIMNO", Data.SqlDbType.VarChar)
        oParam(0).Value = CType(_ClaimNo, String)

        oParam(1) = New SqlParameter("@POLICYNO", Data.SqlDbType.VarChar)
        oParam(1).Value = CType(_PolicyNo, String)

        oParam(2) = New SqlParameter("@NAME", Data.SqlDbType.VarChar)
        oParam(2).Value = CType(_Name, String)

        oParam(3) = New SqlParameter("@PRODUCT", Data.SqlDbType.VarChar)
        oParam(3).Value = CType(_Product, String)

        oParam(4) = New SqlParameter("@DATEREC", Data.SqlDbType.Date)
        oParam(4).Value = CType(_DateRec, Date)

        oParam(5) = New SqlParameter("@FCRDONE", Data.SqlDbType.VarChar)
        oParam(5).Value = CType(_FCRDONE, String)

        oParam(6) = New SqlParameter("@FANAME", Data.SqlDbType.VarChar)
        oParam(6).Value = CType(_FAName, String)

        oParam(7) = New SqlParameter("@STATUS", Data.SqlDbType.VarChar)
        oParam(7).Value = CType(_Status, String)

        oParam(8) = New SqlParameter("@NOTES", Data.SqlDbType.VarChar)
        oParam(8).Value = CType(_Notes, String)

        oParam(9) = New SqlParameter("@INCOMPLETEDOC", Data.SqlDbType.VarChar)
        oParam(9).Value = CType(_INCOMPLETEDOC, String)

        oParam(10) = New SqlParameter("@MEDICALENQ", Data.SqlDbType.VarChar)
        oParam(10).Value = CType(_MEDICALENQ, String)

        oParam(11) = New SqlParameter("@DRAFTEDBY", Data.SqlDbType.VarChar)
        oParam(11).Value = CType(_DRAFTEDBY, String)

        oParam(12) = New SqlParameter("@DRAFTEDATE", Data.SqlDbType.Date)
        oParam(12).Value = CType(_DRAFTEDATE, Date)

        oParam(13) = New SqlParameter("@TRANSDBY", Data.SqlDbType.VarChar)
        oParam(13).Value = CType(_TRANSDBY, String)

        oParam(14) = New SqlParameter("@TRANSDDATE", Data.SqlDbType.Date)
        oParam(14).Value = CType(_TRANSDATE, Date)

        oParam(15) = New SqlParameter("@CREATEDBY", Data.SqlDbType.VarChar)
        oParam(15).Value = CType(CreatedBy, String)

        oParam(16) = New SqlParameter("@PREMIUM", Data.SqlDbType.Decimal)
        oParam(16).Value = CType(PREMIUM, Decimal)

        oParam(17) = New SqlParameter("@LEADERNAME", Data.SqlDbType.VarChar)
        oParam(17).Value = CType(LEADERNAME, String)

        oParam(18) = New SqlParameter("@SALESOFFICE", Data.SqlDbType.VarChar)
        oParam(18).Value = CType(SalesOffice, String)

        oParam(19) = New SqlParameter("@PHONE", Data.SqlDbType.VarChar)
        oParam(19).Value = CType(PHONE, String)

        oParam(20) = New SqlParameter("@EMAIL", Data.SqlDbType.VarChar)
        oParam(20).Value = CType(EMAIL, String)

        oParam(21) = New SqlParameter("@DOCTORNAME", Data.SqlDbType.VarChar)
        oParam(21).Value = CType(Doctor, String)

        oParam(22) = New SqlParameter("@CLAIMSTATUSCODE", Data.SqlDbType.VarChar)
        oParam(22).Value = CType(CLAIMSTATUSCODE, String)

        oParam(23) = New SqlParameter("@FCRCLAIMSTATUS", Data.SqlDbType.VarChar)
        oParam(23).Value = CType(FCRCLAIMSTATUS, String)

        oParam(24) = New SqlParameter("@REASONIVESTIGATION", Data.SqlDbType.VarChar)
        oParam(24).Value = CType(REASONIVESTIGATION, String)

        oParam(25) = New SqlParameter("@SUBSTATUSPENDING", Data.SqlDbType.VarChar)
        oParam(25).Value = CType(SUBSTATUSPENDING, String)

        oParam(26) = New SqlParameter("@SUBSTATUSAPPROVED", Data.SqlDbType.VarChar)
        oParam(26).Value = CType(SUBSTATUSAPPROVED, String)

        Dim _connectionString As String = _connectionString_AFI


        Return (ExecuteNonQuery(_connectionString, const_SP_INSERT_FCR, Data.CommandType.StoredProcedure, oParam))

    End Function

    Public Function f_Insert_LifeCycle(ByVal _ClaimNo As String, ByVal _PolicyNo As String, _
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

        Dim oParam(48) As SqlParameter

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

        'oParam(49) = New SqlParameter("@UploadID", Data.SqlDbType.VarChar)
        'oParam(49).Value = CType(UploadID, String)

        Dim _connectionString As String = _connectionString_AFI


        Return (ExecuteNonQuery(_connectionString, const_SP_INSERT_LIFE_CYCLE, Data.CommandType.StoredProcedure, oParam))

    End Function



    Public Function f_Insert_FCR_Detail(ByVal _ClaimNo As String, ByVal _policyno As String, ByVal _DateSent As Date, ByVal _DateFollowUp As Date, ByVal CreatedBy As String)

        Dim oParam(4) As SqlParameter

        oParam(0) = New SqlParameter("@CLAIMNO", Data.SqlDbType.VarChar)
        oParam(0).Value = CType(_ClaimNo, String)

        oParam(1) = New SqlParameter("@DATESENT", Data.SqlDbType.VarChar)
        oParam(1).Value = CType(_DateSent, String)

        oParam(2) = New SqlParameter("@DATEFOLLOWUP", Data.SqlDbType.VarChar)
        oParam(2).Value = CType(_DateFollowUp, String)

        oParam(3) = New SqlParameter("@CREATEDBY", Data.SqlDbType.VarChar)
        oParam(3).Value = CType(CreatedBy, String)

        oParam(4) = New SqlParameter("@POLICYNO", Data.SqlDbType.VarChar)
        oParam(4).Value = CType(_policyno, String)


        Dim _connectionString As String = _connectionString_AFI


        Return (ExecuteNonQuery(_connectionString, const_SP_INSERT_FCR_DETAIL, Data.CommandType.StoredProcedure, oParam))

    End Function


    Public Function f_Insert_BORDERAUX_DETAIL(ByVal _idx As String, ByVal EntityName As String, ByVal Notes As String, ByVal CreatedBy As String, ByVal FlagStatus As String, ByVal Dates As Date)

        Dim oParam(5) As SqlParameter

        oParam(0) = New SqlParameter("@IDX", Data.SqlDbType.VarChar)
        oParam(0).Value = CType(_idx, String)

        oParam(1) = New SqlParameter("@ENTITYNAME", Data.SqlDbType.VarChar)
        oParam(1).Value = CType(EntityName, String)

        oParam(2) = New SqlParameter("@CREATEDBY", Data.SqlDbType.VarChar)
        oParam(2).Value = CType(CreatedBy, String)

        oParam(3) = New SqlParameter("@NOTES", Data.SqlDbType.VarChar)
        oParam(3).Value = CType(Notes, String)

        oParam(4) = New SqlParameter("@FLAGSTATUS", Data.SqlDbType.VarChar)
        oParam(4).Value = CType(FlagStatus, String)

        oParam(5) = New SqlParameter("@DATES", Data.SqlDbType.Date)
        oParam(5).Value = CType(Dates, Date)

        Dim _connectionString As String = _connectionString_AFI


        Return (ExecuteNonQuery(_connectionString, const_SP_INSERT_BORDERAUX_DETAIL, Data.CommandType.StoredProcedure, oParam))

    End Function

    Public Function f_Insert_Dept_Matrix(ByVal _DeptName As String, ByVal _IdMenuChild As String, _
                                         ByVal _CreatedBy As String, ByVal _entity As String)

        Dim oParam(3) As SqlParameter

        oParam(0) = New SqlParameter("@DeptName", Data.SqlDbType.VarChar)
        oParam(0).Value = CType(_DeptName, String)

        oParam(1) = New SqlParameter("@Entity", Data.SqlDbType.VarChar)
        oParam(1).Value = CType(_entity, String)

        oParam(2) = New SqlParameter("@IdMenuChild", Data.SqlDbType.VarChar)
        oParam(2).Value = CType(_IdMenuChild, String)

        oParam(3) = New SqlParameter("@CREATED_BY", Data.SqlDbType.VarChar)
        oParam(3).Value = CType(_CreatedBy, String)

        Dim _connectionString As String = _connectionString_AFI

        Return (ExecuteNonQuery(_connectionString, const_SP_INSERT_DEPT_MATRIX, Data.CommandType.StoredProcedure, oParam))

    End Function

    Public Function f_Insert_ToDo_List(ByVal _EventName As String, ByVal _DateEvent As Date, _
                                        ByVal _CreatedBy As String, ByVal _entity As String, ByVal _Name As String)

        Dim oParam(3) As SqlParameter

        oParam(0) = New SqlParameter("@EVENT_NAME", Data.SqlDbType.VarChar)
        oParam(0).Value = CType(_EventName, String)

        oParam(1) = New SqlParameter("@DATE", Data.SqlDbType.Date)
        oParam(1).Value = CType(_DateEvent, String)

        oParam(2) = New SqlParameter("@CREATED_BY", Data.SqlDbType.VarChar)
        oParam(2).Value = CType(_CreatedBy, String)

        oParam(3) = New SqlParameter("@Name", Data.SqlDbType.VarChar)
        oParam(3).Value = CType(_Name, String)

        Dim _connectionString As String = _connectionString_AFI

        Return (ExecuteNonQuery(_connectionString, const_SP_INSERT_TODO_LIST, Data.CommandType.StoredProcedure, oParam))

    End Function

    Public Function f_Edit_Dept_Matrix(ByVal _DeptName As String, ByVal _IdMenuChild As String, _
                                       ByVal _CreatedBy As String, ByVal _entity As String)

        Dim oParam(3) As SqlParameter

        oParam(0) = New SqlParameter("@DeptName", Data.SqlDbType.VarChar)
        oParam(0).Value = CType(_DeptName, String)

        oParam(1) = New SqlParameter("@Entity", Data.SqlDbType.VarChar)
        oParam(1).Value = CType(_entity, String)

        oParam(2) = New SqlParameter("@IdMenuChild", Data.SqlDbType.VarChar)
        oParam(2).Value = CType(_IdMenuChild, String)

        oParam(3) = New SqlParameter("@CREATED_BY", Data.SqlDbType.VarChar)
        oParam(3).Value = CType(_CreatedBy, String)


        Dim _connectionString As String = _connectionString_AFI

        Return (ExecuteNonQuery(_connectionString, const_SP_EDIT_DEPT_MATRIX, Data.CommandType.StoredProcedure, oParam))

    End Function


    Public Function f_Insert_Log_Error(ByVal _uploadid As Integer, ByVal _fileName As String, _
                                       ByVal _msgError As String, ByVal _row As Integer, ByVal _UserName As String, _
                                       ByVal _entity As String)

        Dim oParam(4) As SqlParameter

        oParam(0) = New SqlParameter("@UPLOADID", Data.SqlDbType.VarChar)
        oParam(0).Value = CType(_uploadid, String)

        oParam(1) = New SqlParameter("@FILENAME", Data.SqlDbType.VarChar)
        oParam(1).Value = CType(_fileName, String)

        oParam(2) = New SqlParameter("@MESSAGEERROR", Data.SqlDbType.VarChar)
        oParam(2).Value = CType(_msgError, String)

        oParam(3) = New SqlParameter("@ROW", Data.SqlDbType.Int)
        oParam(3).Value = CType(_row, Integer)

        oParam(4) = New SqlParameter("@UPLOADBY", Data.SqlDbType.VarChar)
        oParam(4).Value = CType(_UserName, String)

        Dim _connectionString As String = _connectionString_AFI

        Return (ExecuteNonQuery(_connectionString, const_SP_INSERT_LOG_ERROR_UPLOAD_FILE, Data.CommandType.StoredProcedure, oParam))

    End Function

    Public Function f_Insert_User_Matrix(ByVal _UserName As String, ByVal _Entitys As String, ByVal _IdMenuChild As String, _
                                         ByVal _CreatedBy As String, ByVal _entity As String)

        Dim oParam(3) As SqlParameter

        oParam(0) = New SqlParameter("@UserName", Data.SqlDbType.VarChar)
        oParam(0).Value = CType(_UserName, String)

        oParam(1) = New SqlParameter("@Entity", Data.SqlDbType.VarChar)
        oParam(1).Value = CType(_Entitys, String)

        oParam(2) = New SqlParameter("@IdMenuChild", Data.SqlDbType.VarChar)
        oParam(2).Value = CType(_IdMenuChild, String)

        oParam(3) = New SqlParameter("@CREATED_BY", Data.SqlDbType.VarChar)
        oParam(3).Value = CType(_CreatedBy, String)

        Dim _connectionString As String = _connectionString_AFI

        Return (ExecuteNonQuery(_connectionString, const_SP_INSERT_USER_MATRIX, Data.CommandType.StoredProcedure, oParam))

    End Function

    Public Function f_Insert_Mst_Dept(ByVal _DeptName As String)

        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlParameter("@DeptName", Data.SqlDbType.VarChar)
        oParam(0).Value = CType(_DeptName, String)

        Dim _connectionString As String = _connectionString_AFI

        Return (ExecuteNonQuery(_connectionString, const_SP_INS_MST_DEPT, Data.CommandType.StoredProcedure, oParam))

    End Function
    Public Function f_Insert_TRN_SMS(ByVal DAYS As String, ByVal CLAIMNO As String, ByVal POLICYNO As String, ByVal REMARKS As String, _
                                     ByVal SMSVALUE As String, ByVal SMSTYPE As String, ByVal ENTITY As String, _
                                     ByVal CREATEDBY As String, ByVal CREATEDDATEFROM As Date, ByVal CREATEDDATETO As Date, ByVal DOC As String, _
                                     ByVal TOTALINVAMOUNTPARAM As Decimal, ByVal ELIGLAMOUNTPARAM As Decimal, ByVal EXCAMOUNTPARAM As Decimal, _
                                     ByVal DATEOFADMSPARAM As String, ByVal DATEOFDISCHPARAM As String, _
                                     ByVal DOC2 As String, ByVal MobileNo As String, ByVal MobileNoAgent As String) ', ByVal SUBSTATUSPENDING As String)

        Dim oParam(18) As SqlParameter

        oParam(0) = New SqlParameter("@CLAIMNO", Data.SqlDbType.VarChar)
        oParam(0).Value = CType(CLAIMNO, String)

        oParam(1) = New SqlParameter("@POLICYNO", Data.SqlDbType.VarChar)
        oParam(1).Value = CType(POLICYNO, String)

        oParam(2) = New SqlParameter("@REMARKS", Data.SqlDbType.VarChar)
        oParam(2).Value = CType(REMARKS, String)

        oParam(3) = New SqlParameter("@SMSVALUE", Data.SqlDbType.VarChar)
        oParam(3).Value = CType(SMSVALUE, String)

        oParam(4) = New SqlParameter("@SMSTYPE", Data.SqlDbType.VarChar)
        oParam(4).Value = CType(SMSTYPE, String)

        oParam(5) = New SqlParameter("@ENTITY", Data.SqlDbType.VarChar)
        oParam(5).Value = CType(ENTITY, String)

        oParam(6) = New SqlParameter("@CREATEDBY", Data.SqlDbType.VarChar)
        oParam(6).Value = CType(CREATEDBY, String)

        oParam(7) = New SqlParameter("@CREATEDDATEFROM", Data.SqlDbType.Date)
        oParam(7).Value = CType(CREATEDDATEFROM, Date)

        oParam(8) = New SqlParameter("@CREATEDDATETO", Data.SqlDbType.Date)
        oParam(8).Value = CType(CREATEDDATETO, Date)

        oParam(9) = New SqlParameter("@DOC", Data.SqlDbType.VarChar)
        oParam(9).Value = CType(DOC, String)

        oParam(10) = New SqlParameter("@TOTALINVAMOUNTPARAM", Data.SqlDbType.Decimal)
        oParam(10).Value = CType(TOTALINVAMOUNTPARAM, Decimal)

        oParam(11) = New SqlParameter("@ELIGLAMOUNTPARAM", Data.SqlDbType.Decimal)
        oParam(11).Value = CType(ELIGLAMOUNTPARAM, Decimal)

        oParam(12) = New SqlParameter("@EXCAMOUNTPARAM", Data.SqlDbType.Decimal)
        oParam(12).Value = CType(EXCAMOUNTPARAM, Decimal)

        oParam(13) = New SqlParameter("@DATEOFADMSPARAM", Data.SqlDbType.VarChar)
        oParam(13).Value = CType(DATEOFADMSPARAM, String)

        oParam(14) = New SqlParameter("@DATEOFDISCHPARAM", Data.SqlDbType.VarChar)
        oParam(14).Value = CType(DATEOFDISCHPARAM, String)

        oParam(15) = New SqlParameter("@DOC2", Data.SqlDbType.VarChar)
        oParam(15).Value = CType(DOC2, String)

        oParam(16) = New SqlParameter("@MOBILENO", Data.SqlDbType.VarChar)
        oParam(16).Value = CType(MobileNo, String)

        oParam(17) = New SqlParameter("@MOBILENOAGENT", Data.SqlDbType.VarChar)
        oParam(17).Value = CType(MobileNoAgent, String)

        oParam(18) = New SqlParameter("@DAYS", Data.SqlDbType.Int)
        oParam(18).Value = CType(DAYS, Integer)

        'oParam(19) = New SqlParameter("@SUBSTATUSPENDING", Data.SqlDbType.VarChar)
        'oParam(19).Value = CType(SUBSTATUSPENDING, String)



        Dim _connectionString As String = _connectionString_AFI

        Return (ExecuteNonQuery(_connectionString, const_SP_INSERT_TRN_SMS, Data.CommandType.StoredProcedure, oParam))

    End Function


    Public Function f_Insert_Mst_Menu(ByVal _MenuName As String, ByVal _entity As String)

        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlParameter("@MenuName", Data.SqlDbType.VarChar)
        oParam(0).Value = CType(_MenuName, String)

        Dim _connectionString As String = _connectionString_AFI

        Return (ExecuteNonQuery(_connectionString, const_SP_INS_MST_MENU, Data.CommandType.StoredProcedure, oParam))

    End Function

    Public Function f_Insert_Mst_Menu_Child(ByVal _MenuChildName As String, ByVal _path As String, ByVal _IDMenu As String, ByVal _entity As String)

        Dim oParam(2) As SqlParameter

        oParam(0) = New SqlParameter("@MenuChildName", Data.SqlDbType.VarChar)
        oParam(0).Value = CType(_MenuChildName, String)

        oParam(1) = New SqlParameter("@IDMenu", Data.SqlDbType.VarChar)
        oParam(1).Value = CType(_IDMenu, String)

        oParam(2) = New SqlParameter("@path", Data.SqlDbType.VarChar)
        oParam(2).Value = CType(_path, String)

        Dim _connectionString As String = _connectionString_AFI

        Return (ExecuteNonQuery(_connectionString, const_SP_INS_MST_MENU_CHILD, Data.CommandType.StoredProcedure, oParam))

    End Function

    Public Function f_Edit_User_Matrix(ByVal _UserName As String, ByVal _Entitys As String, ByVal _IdMenuChild As String, _
                                       ByVal _CreatedBy As String, ByVal _entity As String)

        Dim oParam(3) As SqlParameter

        oParam(0) = New SqlParameter("@UserName", Data.SqlDbType.VarChar)
        oParam(0).Value = CType(_UserName, String)

        oParam(1) = New SqlParameter("@Entity", Data.SqlDbType.VarChar)
        oParam(1).Value = CType(_Entitys, String)

        oParam(2) = New SqlParameter("@IdMenuChild", Data.SqlDbType.VarChar)
        oParam(2).Value = CType(_IdMenuChild, String)

        oParam(3) = New SqlParameter("@CREATED_BY", Data.SqlDbType.VarChar)
        oParam(3).Value = CType(_CreatedBy, String)


        Dim _connectionString As String = _connectionString_AFI

        Return (ExecuteNonQuery(_connectionString, const_SP_EDIT_USER_MATRIX, Data.CommandType.StoredProcedure, oParam))

    End Function
    Public Function f_Insert_Upload_Data(ByVal _INVOICE_NO As String, ByVal _CLAIM_NO As String, _
                                         ByVal _CORPORATE_CODE As String, ByVal _Product As String, _
                                         ByVal _Plan_Description As String, ByVal _IPOP As String, _
                                         ByVal _RC As String, ByVal _PREAUTH As String, ByVal _Name_of_Policy_holder As String, ByVal _Policy_no As String, _
                                         ByVal _Name_of_insured As String, ByVal _Insured_Gender As String, ByVal _Insured_Date_of_birth As Date, ByVal _Policy_effective_date As Date, _
                                         ByVal _Policy_expiry_date As Date, ByVal _Date_of_Admission As Date, _
                                         ByVal _Date_of_Discharge As Date, _
                                         ByVal _No_Of_Days As Integer, ByVal _Country_of_claims As String, ByVal _Payee_Name As String, _
                                         ByVal _Date_of_Claim_receive As Date, ByVal _Date_of_LOG_sent_to As Date, ByVal _Duration_to_issue_L As Integer, _
                                         ByVal _Date_of_Decline_LoG As Date, ByVal _Claims_Status_Code As String, _
                                         ByVal _Claim_Status_Desc As String, ByVal _Total_Claim_Invoice As Decimal, _
                                         ByVal _Eligible_Amount As Decimal, ByVal _Excess_Amount As Decimal, ByVal _Amount_rejected As Decimal, _
                                         ByVal _ICD_Code As String, ByVal _ICD_Description As String, ByVal _Remarks As String, _
                                         ByVal _Treatment_provider_code As String, ByVal _Treatment_provider As String, ByVal _PAYMENT_DATE As Date, _
                                         ByVal _Days_to_Pay As Integer, ByVal _LAST_EDIT_DATE As Date, ByVal _Days_Since_Last_Action As Integer, _
                                         ByVal _Date_Full_Info_Receive As Date, ByVal _Days_Since_Claim_Receive As Integer, _
                                         ByVal _DECLINE_DATE As Date, ByVal _USER_NAME As String, ByVal _UPLOAD_ID As Integer, ByVal _CREATED_BY As String)

        Dim oParam(44) As SqlParameter

        oParam(0) = New SqlParameter("@INVOICE_NO", Data.SqlDbType.VarChar)
        oParam(0).Value = CType(_INVOICE_NO, String)

        oParam(1) = New SqlParameter("@CLAIM_NO", Data.SqlDbType.VarChar)
        oParam(1).Value = CType(_CLAIM_NO, String)

        oParam(2) = New SqlParameter("@CORPORATE_CODE", Data.SqlDbType.VarChar)
        oParam(2).Value = CType(_CORPORATE_CODE, String)

        oParam(3) = New SqlParameter("@Product", Data.SqlDbType.VarChar)
        oParam(3).Value = CType(_Product, String)

        oParam(4) = New SqlParameter("@Plan_Description", Data.SqlDbType.VarChar)
        oParam(4).Value = CType(_Plan_Description, String)

        oParam(5) = New SqlParameter("@IPOP", Data.SqlDbType.VarChar)
        oParam(5).Value = CType(_IPOP, String)

        oParam(6) = New SqlParameter("@RC", Data.SqlDbType.VarChar)
        oParam(6).Value = CType(_RC, String)

        oParam(7) = New SqlParameter("@PREAUTH", Data.SqlDbType.VarChar)
        oParam(7).Value = CType(_PREAUTH, String)

        oParam(8) = New SqlParameter("@Name_of_Policy_holder", Data.SqlDbType.VarChar)
        oParam(8).Value = CType(_Name_of_Policy_holder, String)

        oParam(9) = New SqlParameter("@Policy_no", Data.SqlDbType.VarChar)
        oParam(9).Value = CType(_Policy_no, String)

        oParam(10) = New SqlParameter("@Name_of_insured", Data.SqlDbType.VarChar)
        oParam(10).Value = CType(_Name_of_insured, String)

        oParam(11) = New SqlParameter("@Insured_Gender", Data.SqlDbType.VarChar)
        oParam(11).Value = CType(_Insured_Gender, String)

        oParam(12) = New SqlParameter("@Insured_Date_of_birth", Data.SqlDbType.Date)
        oParam(12).Value = CType(_Insured_Date_of_birth, Date)

        oParam(13) = New SqlParameter("@Policy_effective_date", Data.SqlDbType.Date)
        oParam(13).Value = CType(_Policy_effective_date, Date)

        oParam(14) = New SqlParameter("@Policy_expiry_date", Data.SqlDbType.Date)
        oParam(14).Value = CType(_Policy_expiry_date, Date)

        oParam(15) = New SqlParameter("@Date_of_Admission", Data.SqlDbType.Date)
        oParam(15).Value = CType(_Date_of_Admission, Date)

        oParam(16) = New SqlParameter("@Date_of_Discharge", Data.SqlDbType.Date)
        oParam(16).Value = CType(_Date_of_Discharge, Date)

        oParam(17) = New SqlParameter("@No_Of_Days", Data.SqlDbType.Int)
        oParam(17).Value = CType(_No_Of_Days, Integer)

        oParam(18) = New SqlParameter("@Country_of_claims", Data.SqlDbType.VarChar)
        oParam(18).Value = CType(_Country_of_claims, String)

        oParam(19) = New SqlParameter("@Payee_Name", Data.SqlDbType.VarChar)
        oParam(19).Value = CType(_Payee_Name, String)

        oParam(20) = New SqlParameter("@Date_of_Claim_receive", Data.SqlDbType.Date)
        oParam(20).Value = CType(_Date_of_Claim_receive, Date)

        oParam(21) = New SqlParameter("@Date_of_LOG_sent_to", Data.SqlDbType.Date)
        oParam(21).Value = CType(_Date_of_LOG_sent_to, Date)

        oParam(22) = New SqlParameter("@Duration_to_issue_L", Data.SqlDbType.Int)
        oParam(22).Value = CType(_Duration_to_issue_L, String)

        oParam(23) = New SqlParameter("@Date_of_Decline_LoG", Data.SqlDbType.Date)
        oParam(23).Value = CType(_Date_of_Decline_LoG, Date)

        oParam(24) = New SqlParameter("@Claims_Status_Code", Data.SqlDbType.VarChar)
        oParam(24).Value = CType(_Claims_Status_Code, String)

        oParam(25) = New SqlParameter("@Claim_Status_Desc", Data.SqlDbType.VarChar)
        oParam(25).Value = CType(_Claim_Status_Desc, String)

        oParam(26) = New SqlParameter("@Total_Claim_Invoice", Data.SqlDbType.Float)
        oParam(26).Value = CType(_Total_Claim_Invoice, Decimal)

        oParam(27) = New SqlParameter("@Eligible_Amount", Data.SqlDbType.Float)
        oParam(27).Value = CType(_Eligible_Amount, Decimal)

        oParam(28) = New SqlParameter("@Excess_Amount", Data.SqlDbType.Float)
        oParam(28).Value = CType(_Excess_Amount, Decimal)

        oParam(29) = New SqlParameter("@Amount_rejected", Data.SqlDbType.Float)
        oParam(29).Value = CType(_Amount_rejected, Decimal)

        oParam(30) = New SqlParameter("@ICD_Code", Data.SqlDbType.VarChar)
        oParam(30).Value = CType(_ICD_Code, String)

        oParam(31) = New SqlParameter("@ICD_Description", Data.SqlDbType.VarChar)
        oParam(31).Value = CType(_ICD_Description, String)

        oParam(32) = New SqlParameter("@Remarks", Data.SqlDbType.VarChar)
        oParam(32).Value = CType(_Remarks, String)

        oParam(33) = New SqlParameter("@Treatment_provider_code", Data.SqlDbType.VarChar)
        oParam(33).Value = CType(_Treatment_provider_code, String)

        oParam(34) = New SqlParameter("@Treatment_provider", Data.SqlDbType.VarChar)
        oParam(34).Value = CType(_Treatment_provider, String)

        oParam(35) = New SqlParameter("@PAYMENT_DATE", Data.SqlDbType.Date)
        oParam(35).Value = CType(_PAYMENT_DATE, Date)

        oParam(36) = New SqlParameter("@Days_to_Pay", Data.SqlDbType.Int)
        oParam(36).Value = CType(_Days_to_Pay, Integer)

        oParam(37) = New SqlParameter("@LAST_EDIT_DATE", Data.SqlDbType.Date)
        oParam(37).Value = CType(_LAST_EDIT_DATE, Date)

        oParam(38) = New SqlParameter("@Days_Since_Last_Action", Data.SqlDbType.Int)
        oParam(38).Value = CType(_Days_Since_Last_Action, Integer)

        oParam(39) = New SqlParameter("@Date_Full_Info_Receive", Data.SqlDbType.Date)
        oParam(39).Value = CType(_Date_Full_Info_Receive, Date)

        oParam(40) = New SqlParameter("@Days_Since_Claim_Receive", Data.SqlDbType.Int)
        oParam(40).Value = CType(_Days_Since_Claim_Receive, String)

        oParam(41) = New SqlParameter("@DECLINE_DATE", Data.SqlDbType.Date)
        oParam(41).Value = CType(_DECLINE_DATE, Date)

        oParam(42) = New SqlParameter("@USER_NAME", Data.SqlDbType.VarChar)
        oParam(42).Value = CType(_USER_NAME, String)

        oParam(43) = New SqlParameter("@UPLOAD_ID", Data.SqlDbType.VarChar)
        oParam(43).Value = CType(_UPLOAD_ID, String)

        oParam(44) = New SqlParameter("@CREATED_BY", Data.SqlDbType.VarChar)
        oParam(44).Value = CType(_CREATED_BY, String)



        Dim _connectionString As String = _connectionString_AFI

        Return (ExecuteNonQuery(_connectionString, const_SP_INSERT_UPLOAD_DATA, Data.CommandType.StoredProcedure, oParam))

    End Function
    Public Function f_Insert_Upload_Data_FAILED(ByVal _INVOICE_NO As String, ByVal _CLAIM_NO As String, _
                                         ByVal _CORPORATE_CODE As String, ByVal _Product As String, _
                                         ByVal _Plan_Description As String, ByVal _IPOP As String, _
                                         ByVal _RC As String, ByVal _PREAUTH As String, ByVal _Name_of_Policy_holder As String, ByVal _Policy_no As String, _
                                         ByVal _Name_of_insured As String, ByVal _Insured_Gender As String, ByVal _Insured_Date_of_birth As String, ByVal _Policy_effective_date As String, _
                                         ByVal _Policy_expiry_date As String, ByVal _Date_of_Admission As String, _
                                         ByVal _Date_of_Discharge As String, _
                                         ByVal _No_Of_Days As String, ByVal _Country_of_claims As String, ByVal _Payee_Name As String, _
                                         ByVal _Date_of_Claim_receive As String, ByVal _Date_of_LOG_sent_to As String, ByVal _Duration_to_issue_L As String, _
                                         ByVal _Date_of_Decline_LoG As String, ByVal _Claims_Status_Code As String, _
                                         ByVal _Claim_Status_Desc As String, ByVal _Total_Claim_Invoice As String, _
                                         ByVal _Eligible_Amount As String, ByVal _Excess_Amount As String, ByVal _Amount_rejected As String, _
                                         ByVal _ICD_Code As String, ByVal _ICD_Description As String, ByVal _Remarks As String, _
                                         ByVal _Treatment_provider_code As String, ByVal _Treatment_provider As String, ByVal _PAYMENT_DATE As String, _
                                         ByVal _Days_to_Pay As String, ByVal _LAST_EDIT_DATE As String, ByVal _Days_Since_Last_Action As String, _
                                         ByVal _Date_Full_Info_Receive As String, ByVal _Days_Since_Claim_Receive As String, _
                                         ByVal _DECLINE_DATE As String, ByVal _USER_NAME As String, _
                                         ByVal _UPLOAD_ID As String, ByVal _CREATED_BY As String, ByVal _REASON As String)

        Dim oParam(45) As SqlParameter

        oParam(0) = New SqlParameter("@INVOICE_NO", Data.SqlDbType.VarChar)
        oParam(0).Value = CType(_INVOICE_NO, String)

        oParam(1) = New SqlParameter("@CLAIM_NO", Data.SqlDbType.VarChar)
        oParam(1).Value = CType(_CLAIM_NO, String)

        oParam(2) = New SqlParameter("@CORPORATE_CODE", Data.SqlDbType.VarChar)
        oParam(2).Value = CType(_CORPORATE_CODE, String)

        oParam(3) = New SqlParameter("@Product", Data.SqlDbType.VarChar)
        oParam(3).Value = CType(_Product, String)

        oParam(4) = New SqlParameter("@Plan_Description", Data.SqlDbType.VarChar)
        oParam(4).Value = CType(_Plan_Description, String)

        oParam(5) = New SqlParameter("@IPOP", Data.SqlDbType.VarChar)
        oParam(5).Value = CType(_IPOP, String)

        oParam(6) = New SqlParameter("@RC", Data.SqlDbType.VarChar)
        oParam(6).Value = CType(_RC, String)

        oParam(7) = New SqlParameter("@PREAUTH", Data.SqlDbType.VarChar)
        oParam(7).Value = CType(_PREAUTH, String)

        oParam(8) = New SqlParameter("@Name_of_Policy_holder", Data.SqlDbType.VarChar)
        oParam(8).Value = CType(_Name_of_Policy_holder, String)

        oParam(9) = New SqlParameter("@Policy_no", Data.SqlDbType.VarChar)
        oParam(9).Value = CType(_Policy_no, String)

        oParam(10) = New SqlParameter("@Name_of_insured", Data.SqlDbType.VarChar)
        oParam(10).Value = CType(_Name_of_insured, String)

        oParam(11) = New SqlParameter("@Insured_Gender", Data.SqlDbType.VarChar)
        oParam(11).Value = CType(_Insured_Gender, String)

        oParam(12) = New SqlParameter("@Insured_Date_of_birth", Data.SqlDbType.VarChar)
        oParam(12).Value = CType(_Insured_Date_of_birth, String)

        oParam(13) = New SqlParameter("@Policy_effective_date", Data.SqlDbType.VarChar)
        oParam(13).Value = CType(_Policy_effective_date, String)

        oParam(14) = New SqlParameter("@Policy_expiry_date", Data.SqlDbType.VarChar)
        oParam(14).Value = CType(_Policy_expiry_date, String)

        oParam(15) = New SqlParameter("@Date_of_Admission", Data.SqlDbType.VarChar)
        oParam(15).Value = CType(_Date_of_Admission, String)

        oParam(16) = New SqlParameter("@Date_of_Discharge", Data.SqlDbType.VarChar)
        oParam(16).Value = CType(_Date_of_Discharge, String)

        oParam(17) = New SqlParameter("@No_Of_Days", Data.SqlDbType.VarChar)
        oParam(17).Value = CType(_No_Of_Days, String)

        oParam(18) = New SqlParameter("@Country_of_claims", Data.SqlDbType.VarChar)
        oParam(18).Value = CType(_Country_of_claims, String)

        oParam(19) = New SqlParameter("@Payee_Name", Data.SqlDbType.VarChar)
        oParam(19).Value = CType(_Payee_Name, String)

        oParam(20) = New SqlParameter("@Date_of_Claim_receive", Data.SqlDbType.VarChar)
        oParam(20).Value = CType(_Date_of_Claim_receive, String)

        oParam(21) = New SqlParameter("@Date_of_LOG_sent_to", Data.SqlDbType.VarChar)
        oParam(21).Value = CType(_Date_of_LOG_sent_to, String)

        oParam(22) = New SqlParameter("@Duration_to_issue_L", Data.SqlDbType.VarChar)
        oParam(22).Value = CType(_Duration_to_issue_L, String)

        oParam(23) = New SqlParameter("@Date_of_Decline_LoG", Data.SqlDbType.VarChar)
        oParam(23).Value = CType(_Date_of_Decline_LoG, String)

        oParam(24) = New SqlParameter("@Claims_Status_Code", Data.SqlDbType.VarChar)
        oParam(24).Value = CType(_Claims_Status_Code, String)

        oParam(25) = New SqlParameter("@Claim_Status_Desc", Data.SqlDbType.VarChar)
        oParam(25).Value = CType(_Claim_Status_Desc, String)

        oParam(26) = New SqlParameter("@Total_Claim_Invoice", Data.SqlDbType.VarChar)
        oParam(26).Value = CType(_Total_Claim_Invoice, String)

        oParam(27) = New SqlParameter("@Eligible_Amount", Data.SqlDbType.VarChar)
        oParam(27).Value = CType(_Eligible_Amount, String)

        oParam(28) = New SqlParameter("@Excess_Amount", Data.SqlDbType.VarChar)
        oParam(28).Value = CType(_Excess_Amount, String)

        oParam(29) = New SqlParameter("@Amount_rejected", Data.SqlDbType.VarChar)
        oParam(29).Value = CType(_Amount_rejected, String)

        oParam(30) = New SqlParameter("@ICD_Code", Data.SqlDbType.VarChar)
        oParam(30).Value = CType(_ICD_Code, String)

        oParam(31) = New SqlParameter("@ICD_Description", Data.SqlDbType.VarChar)
        oParam(31).Value = CType(_ICD_Description, String)

        oParam(32) = New SqlParameter("@Remarks", Data.SqlDbType.VarChar)
        oParam(32).Value = CType(_Remarks, String)

        oParam(33) = New SqlParameter("@Treatment_provider_code", Data.SqlDbType.VarChar)
        oParam(33).Value = CType(_Treatment_provider_code, String)

        oParam(34) = New SqlParameter("@Treatment_provider", Data.SqlDbType.VarChar)
        oParam(34).Value = CType(_Treatment_provider, String)

        oParam(35) = New SqlParameter("@PAYMENT_DATE", Data.SqlDbType.VarChar)
        oParam(35).Value = CType(_PAYMENT_DATE, String)

        oParam(36) = New SqlParameter("@Days_to_Pay", Data.SqlDbType.VarChar)
        oParam(36).Value = CType(_Days_to_Pay, String)

        oParam(37) = New SqlParameter("@LAST_EDIT_DATE", Data.SqlDbType.VarChar)
        oParam(37).Value = CType(_LAST_EDIT_DATE, String)

        oParam(38) = New SqlParameter("@Days_Since_Last_Action", Data.SqlDbType.VarChar)
        oParam(38).Value = CType(_Days_Since_Last_Action, String)

        oParam(39) = New SqlParameter("@Date_Full_Info_Receive", Data.SqlDbType.VarChar)
        oParam(39).Value = CType(_Date_Full_Info_Receive, String)

        oParam(40) = New SqlParameter("@Days_Since_Claim_Receive", Data.SqlDbType.VarChar)
        oParam(40).Value = CType(_Days_Since_Claim_Receive, String)

        oParam(41) = New SqlParameter("@DECLINE_DATE", Data.SqlDbType.VarChar)
        oParam(41).Value = CType(_DECLINE_DATE, String)

        oParam(42) = New SqlParameter("@USER_NAME", Data.SqlDbType.VarChar)
        oParam(42).Value = CType(_USER_NAME, String)

        oParam(43) = New SqlParameter("@UPLOAD_ID", Data.SqlDbType.VarChar)
        oParam(43).Value = CType(_UPLOAD_ID, String)

        oParam(44) = New SqlParameter("@CREATED_BY", Data.SqlDbType.VarChar)
        oParam(44).Value = CType(_CREATED_BY, String)

        oParam(45) = New SqlParameter("@REASON", Data.SqlDbType.VarChar)
        oParam(45).Value = CType(_REASON, String)




        Dim _connectionString As String = _connectionString_AFI

        Return (ExecuteNonQuery(_connectionString, const_SP_INSERT_UPLOAD_DATA_FAILED, Data.CommandType.StoredProcedure, oParam))

    End Function


    'Public Function f_Insert_RekKoran(ByVal _daterekeningkoran As DateTime, ByVal _datereceived As DateTime, ByVal _currency As String, _
    '                                  ByVal _Amount As Decimal, ByVal _Payorbank As String, ByVal _PayorbankAcc As String, ByVal _description As String, ByVal _Createdby As String, ByVal _payorBankBranch As String, _
    '                                  ByVal _Filename As String, ByVal _IsATP As String, ByVal _uploadid As Integer, ByVal _entity As String, ByVal _ref As String)
    '    Dim oParam(12) As SqlParameter

    '    oParam(0) = New SqlParameter("@DATEREKENINGKORAN", Data.SqlDbType.DateTime)
    '    oParam(0).Value = CType(_daterekeningkoran, DateTime)

    '    oParam(1) = New SqlParameter("@DATERECEIVED", Data.SqlDbType.DateTime)
    '    oParam(1).Value = CType(_datereceived, DateTime)

    '    oParam(2) = New SqlParameter("@CURRENCY", Data.SqlDbType.VarChar)
    '    oParam(2).Value = CType(_currency, String)

    '    oParam(3) = New SqlParameter("@AMOUNT", Data.SqlDbType.Float)
    '    oParam(3).Value = CType(_Amount, Decimal)

    '    oParam(4) = New SqlParameter("@PAYORBANK", Data.SqlDbType.VarChar)
    '    oParam(4).Value = CType(_Payorbank, String)

    '    oParam(5) = New SqlParameter("@PAYORBANK_ACCOUNTNO", Data.SqlDbType.VarChar)
    '    oParam(5).Value = CType(_PayorbankAcc, String)

    '    oParam(6) = New SqlParameter("@DESCRIPTION", Data.SqlDbType.VarChar)
    '    oParam(6).Value = CType(_description, String)

    '    oParam(7) = New SqlParameter("@CREATEDBY", Data.SqlDbType.VarChar)
    '    oParam(7).Value = CType(_Createdby, String)

    '    oParam(8) = New SqlParameter("@PAYORBANKBRANCH", Data.SqlDbType.VarChar)
    '    oParam(8).Value = CType(_payorBankBranch, String)

    '    oParam(9) = New SqlParameter("@FILENAME", Data.SqlDbType.VarChar)
    '    oParam(9).Value = CType(_Filename, String)

    '    oParam(10) = New SqlParameter("@ISATP", Data.SqlDbType.VarChar)
    '    oParam(10).Value = CType(_IsATP, String)

    '    oParam(11) = New SqlParameter("@UPLOADID", Data.SqlDbType.Int)
    '    oParam(11).Value = CType(_uploadid, Integer)

    '    If _entity = "AMFS" Then
    '        oParam(12) = New SqlParameter("@REFERENCE", Data.SqlDbType.VarChar)
    '        oParam(12).Value = CType(_ref, String)
    '    ElseIf _entity = "AFI" Then
    '        oParam(12) = New SqlParameter("@REFERENCE", Data.SqlDbType.VarChar)
    '        oParam(12).Value = CType(_ref, String)
    '    End If

    '    Dim _connectionString As String = _connectionString_AFI

    '    Return (ExecuteNonQuery(_connectionString, const_SP_INSERT_REKKORAN, Data.CommandType.StoredProcedure, oParam))
    'End Function
    ''
    'Public Function f_Insert_RekKoran_FAILED(ByVal _daterekeningkoran As String, ByVal _datereceived As String, ByVal _currency As String, _
    '                                 ByVal _Amount As String, ByVal _Payorbank As String, ByVal _PayorbankAcc As String, ByVal _description As String, ByVal _Createdby As String, ByVal _payorBankBranch As String, _
    '                                 ByVal _Filename As String, ByVal _IsATP As String, ByVal _uploadid As Integer, ByVal _entity As String, ByVal _ref As String, ByVal _errReason As String)
    '    Dim oParam(13) As SqlParameter

    '    oParam(0) = New SqlParameter("@DATEREKENINGKORAN", Data.SqlDbType.VarChar)
    '    oParam(0).Value = CType(_daterekeningkoran, String)

    '    oParam(1) = New SqlParameter("@DATERECEIVED", Data.SqlDbType.VarChar)
    '    oParam(1).Value = CType(_datereceived, String)

    '    oParam(2) = New SqlParameter("@CURRENCY", Data.SqlDbType.VarChar)
    '    oParam(2).Value = CType(_currency, String)

    '    oParam(3) = New SqlParameter("@AMOUNT", Data.SqlDbType.VarChar)
    '    oParam(3).Value = CType(_Amount, String)

    '    oParam(4) = New SqlParameter("@PAYORBANK", Data.SqlDbType.VarChar)
    '    oParam(4).Value = CType(_Payorbank, String)

    '    oParam(5) = New SqlParameter("@PAYORBANK_ACCOUNTNO", Data.SqlDbType.VarChar)
    '    oParam(5).Value = CType(_PayorbankAcc, String)

    '    oParam(6) = New SqlParameter("@DESCRIPTION", Data.SqlDbType.VarChar)
    '    oParam(6).Value = CType(_description, String)

    '    oParam(7) = New SqlParameter("@CREATEDBY", Data.SqlDbType.VarChar)
    '    oParam(7).Value = CType(_Createdby, String)

    '    oParam(8) = New SqlParameter("@PAYORBANKBRANCH", Data.SqlDbType.VarChar)
    '    oParam(8).Value = CType(_payorBankBranch, String)

    '    oParam(9) = New SqlParameter("@FILENAME", Data.SqlDbType.VarChar)
    '    oParam(9).Value = CType(_Filename, String)

    '    oParam(10) = New SqlParameter("@ISATP", Data.SqlDbType.VarChar)
    '    oParam(10).Value = CType(_IsATP, String)

    '    oParam(11) = New SqlParameter("@UPLOADID", Data.SqlDbType.Int)
    '    oParam(11).Value = CType(_uploadid, Integer)

    '    oParam(12) = New SqlParameter("@ERRREASON", Data.SqlDbType.VarChar)
    '    oParam(12).Value = CType(_errReason, String)

    '    If _entity = "AMFS" Then
    '        oParam(13) = New SqlParameter("@REFERENCE", Data.SqlDbType.VarChar)
    '        oParam(13).Value = CType(_ref, String)
    '    ElseIf _entity = "AFI" Then
    '        oParam(13) = New SqlParameter("@REFERENCE", Data.SqlDbType.VarChar)
    '        oParam(13).Value = CType(_ref, String)
    '    End If



    '    Dim _connectionString As String = _connectionString_AFI

    '    Return (ExecuteNonQuery(_connectionString, const_SP_INSERT_REKKORAN_FAILED, Data.CommandType.StoredProcedure, oParam))
    'End Function
    'Public Function f_Insert_RekKoran_Item(ByVal _rekkoran As String, ByVal _policyno As String, ByVal _currency As String, ByVal _amount As Decimal, ByVal _createdby As String, ByVal _refund As String, ByVal _remark As String, ByVal _entity As String, _
    '                                       ByVal _tcCode As Integer, ByVal _REFUND_AMOUNTS As Decimal)

    '    Dim oParam(8) As SqlParameter

    '    oParam(0) = New SqlParameter("@REKKORAN", Data.SqlDbType.VarChar)
    '    oParam(0).Value = CType(_rekkoran, String)

    '    oParam(1) = New SqlParameter("@POLICYNO", Data.SqlDbType.VarChar)
    '    oParam(1).Value = CType(_policyno, String)

    '    oParam(2) = New SqlParameter("@CURRENCY", Data.SqlDbType.VarChar)
    '    oParam(2).Value = CType(_currency, String)

    '    oParam(3) = New SqlParameter("@AMOUNT", Data.SqlDbType.Float)
    '    oParam(3).Value = CType(_amount, Decimal)

    '    oParam(4) = New SqlParameter("@CREATEDBY", Data.SqlDbType.VarChar)
    '    oParam(4).Value = CType(_createdby, String)

    '    oParam(5) = New SqlParameter("@REFUND", Data.SqlDbType.VarChar)
    '    oParam(5).Value = CType(_refund, String)

    '    oParam(6) = New SqlParameter("@REMARK", Data.SqlDbType.VarChar)
    '    oParam(6).Value = CType(_remark, String)

    '    oParam(7) = New SqlParameter("@TC_CODE", Data.SqlDbType.Int)
    '    oParam(7).Value = CType(_tcCode, Integer)

    '    oParam(8) = New SqlParameter("@REFUND_AMOUNTS", Data.SqlDbType.Float)
    '    oParam(8).Value = CType(_REFUND_AMOUNTS, Decimal)

    '    Dim _connectionString As String = _connectionString_AFI

    '    Return (ExecuteNonQuery(_connectionString, const_SP_INSERT_REKKORAN_ITEM, Data.CommandType.StoredProcedure, oParam))

    'End Function

    'Public Function f_Insert_Trail(ByVal _menutype As String, ByVal _oldvaluebalance As Decimal, ByVal _newvaluebalance As Decimal, _
    '                               ByVal _oldvaluerls As Decimal, ByVal _newvaluerls As Decimal, _
    '                               ByVal _oldvaluecurrency As String, ByVal _newvaluecurrency As String, _
    '                               ByVal _oldvalueisrefund As String, ByVal _newvalueisrefund As String, _
    '                                ByVal _oldvalueremarks As String, ByVal _newvalueremarks As String, _
    '                               ByVal _task As String, ByVal _createdby As String, ByVal _entity As String, _
    '                               ByVal _OldrefAmount As Decimal, ByVal _NewrefAmount As Decimal, ByVal _RekKoran As String)

    '    Dim oParam(15) As SqlParameter

    '    oParam(0) = New SqlParameter("@MENUTYPE", Data.SqlDbType.VarChar)
    '    oParam(0).Value = CType(_menutype, String)

    '    oParam(1) = New SqlParameter("@OLD_VALUE_BALANCE", Data.SqlDbType.Float)
    '    oParam(1).Value = CType(_oldvaluebalance, Decimal)

    '    oParam(2) = New SqlParameter("@NEW_VALUE_BALANCE", Data.SqlDbType.Float)
    '    oParam(2).Value = CType(_newvaluebalance, Decimal)

    '    oParam(3) = New SqlParameter("@OLD_VALUE_RLS", Data.SqlDbType.Float)
    '    oParam(3).Value = CType(_oldvaluerls, Decimal)

    '    oParam(4) = New SqlParameter("@NEW_VALUE_RLS", Data.SqlDbType.Float)
    '    oParam(4).Value = CType(_newvaluerls, Decimal)

    '    oParam(5) = New SqlParameter("@OLD_VALUE_CURRENCY", Data.SqlDbType.VarChar)
    '    oParam(5).Value = CType(_oldvaluecurrency, String)

    '    oParam(6) = New SqlParameter("@NEW_VALUE_CURRENCY", Data.SqlDbType.VarChar)
    '    oParam(6).Value = CType(_newvaluecurrency, String)

    '    oParam(7) = New SqlParameter("@OLD_VALUE_ISREFUND", Data.SqlDbType.VarChar)
    '    oParam(7).Value = CType(_oldvalueisrefund, String)

    '    oParam(8) = New SqlParameter("@NEW_VALUE_ISREFUND", Data.SqlDbType.VarChar)
    '    oParam(8).Value = CType(_newvalueisrefund, String)

    '    oParam(9) = New SqlParameter("@OLD_VALUE_REMARKS", Data.SqlDbType.VarChar)
    '    oParam(9).Value = CType(_oldvalueremarks, String)

    '    oParam(10) = New SqlParameter("@NEW_VALUE_REMARKS", Data.SqlDbType.VarChar)
    '    oParam(10).Value = CType(_newvalueremarks, String)

    '    oParam(11) = New SqlParameter("@TASK", Data.SqlDbType.VarChar)
    '    oParam(11).Value = CType(_task, String)

    '    oParam(12) = New SqlParameter("@CREATED_BY", Data.SqlDbType.VarChar)
    '    oParam(12).Value = CType(_createdby, String)

    '    oParam(13) = New SqlParameter("@OLD_VALUE_REFUND_AMOUNT", Data.SqlDbType.Float)
    '    oParam(13).Value = CType(_OldrefAmount, Decimal)

    '    oParam(14) = New SqlParameter("@NEW_VALUE_REFUND_AMOUNT", Data.SqlDbType.Float)
    '    oParam(14).Value = CType(_NewrefAmount, Decimal)

    '    oParam(15) = New SqlParameter("@RekKoranNo", Data.SqlDbType.VarChar)
    '    oParam(15).Value = CType(_RekKoran, String)


    '    Dim _connectionString As String = _connectionString_AFI

    '    Return (ExecuteNonQuery(_connectionString, const_SP_INSERT_AUDITTRAIL, Data.CommandType.StoredProcedure, oParam))

    'End Function


End Class
