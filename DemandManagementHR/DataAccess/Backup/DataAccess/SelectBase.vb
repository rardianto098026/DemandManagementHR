Imports System.Configuration
Imports System.Data.SqlClient

Public Class SelectBase
    Inherits DataAccessBase

    Dim _connectionString_AFI As String = ConfigurationManager.ConnectionStrings("ConSql").ToString
    Dim _connectionString As String = ConfigurationManager.ConnectionStrings("ConSql").ToString
#Region "Constanta"
    Dim const_sp_InsertLogin As String = "sp_INSERT_LOGIN"
    Dim const_sp_CHECK_MENU As String = "sp_check_Menu_MASTER"
    Dim const_sp_CHECK_MENUS As String = "sp_check_Menu"
    Dim const_sp_CHECK_MENU_NAME_MASTER As String = "sp_check_Menu_name"
    Dim const_sp_InsertUploadFile As String = "sp_INSERT_UPLOADFILE"
    Dim const_sp_SEL_CheckCriteria_Upload As String = "sp_CheckCriteria_Upload"
    Dim const_sp_SEL_DOWNLOAD_FAILED As String = "sp_SEL_DOWNLOAD_FAILED"
    Dim const_sp_SEL_LIST_EMPL As String = "sp_SEL_LIST_EMPL"
    Dim const_sp_SEL_MST_NOTIF As String = "sp_SEL_MST_NOTIF"
    Dim const_sp_DETAIL_MST_EMPL As String = "sp_DETAIL_MST_EMPL"


    Dim const_sp_DATAPRODUKSI As String = "sp_ReportApp_DataProduksi"
    Dim const_sp_COLLECTIONRATIO As String = "sp_ReportApp_CollectionRatio"
    Dim const_sp_POLICYSTATUS As String = "sp_ReportApp_PolicyStatus"
    Dim const_sp_PAYMENTSTATUS As String = "sp_ReportApp_PaymentStatus"
    Dim const_sp_AUTH_USER As String = "sp_ReportApp_Auth_User"
    Dim const_sp_GetActuary As String = "sp_ReportActuary"
    Dim const_sp_PRODUCT_DISTINCT As String = "sp_ReportApp_lk_Product_GROUP"
    Dim const_sp_PRODUCT_PARAM_GROUP As String = "sp_ReportApp_lk_Product_Param_GROUP"

    'Lookup
    Dim const_sp_PRODUCT As String = "sp_ReportApp_lk_Product"
    Dim const_sp_PRODUCT_PARAM As String = "sp_ReportApp_lk_Product_Param"
    Dim const_SP_USER As String = "sp_ReportApp_lk_User"

    'Query
    Dim const_cb_PARENT As String = "select parentid,parentname from reportapp_parent where parentid <> 1 order by parentid"
    Dim const_sp_MENU As String = "sp_ReportApp_Select_Menu"
    Dim const_cb_PARENT_ALL As String = "select parentid,parentname from reportapp_parent order by parentid"

    'Testing DMTM
    Dim const_CB_REPORTING As String = "select * from BILLINGMONTHLY order by "

    'FreePA
    Dim const_sp_DATAPRODUKSI_FREEPA As String = "sp_ReportApp_DataProduksi_FreePA"
    Dim const_sp_GETPRODUCT_FREEPA As String = "sp_ReportApp_GetProductFreePA"


    Dim const_sp_LOAD_DDL As String = "SP_LOAD_DDL"
    Dim const_SP_GETEXPIREDDATE As String = "SP_GETEXPIREDDATE"
    Dim const_SP_GET_COUNT_EMPLOYEE As String = "SP_GET_COUNT_EMPLOYEE"
    Dim const_SP_SEL_CHECK_DATA As String = "SP_SEL_CHECK_DATA"
    Dim const_SP_LOAD_MANAGER_EDIT As String = "SP_LOAD_MANAGER_EDIT"
    Dim const_SP_DEPARTMENT As String = "SP_DEPARTMENT"
    Dim const_SP_AREA_NAME As String = "SP_AREA_NAME"
    Dim const_SP_GET_DEPARTMENT As String = "SP_GET_DEPARTMENT"

#End Region
    Public Function f_LOAD_MANAGER_EDIT(ByVal Manager As String, ByVal Command As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(1) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@MANAGER", SqlDbType.VarChar)
        oParam(0).Value = CType(Manager, String)

        oParam(1) = New SqlClient.SqlParameter("@COMMAND", SqlDbType.VarChar)
        oParam(1).Value = CType(Command, String)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_SP_LOAD_MANAGER_EDIT, CommandType.StoredProcedure, oParam)

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
    Public Function f_CheckCriteria_Upload(ByVal UploadID As String)
        Dim dt As New DataTable
        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@uploadid", SqlDbType.VarChar)
        oParam(0).Value = CType(UploadID, String)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_SEL_CheckCriteria_Upload, CommandType.StoredProcedure, oParam)

        Return dt
    End Function
    Public Function f_SEL_Download_Failed(ByVal StartDate As Date, ByVal toDate As Date) As DataTable

        Dim dt As New DataTable
        Dim oParam(1) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@FROMDATE", SqlDbType.VarChar)
        oParam(0).Value = CType(StartDate, String)

        oParam(1) = New SqlClient.SqlParameter("@TODATE", SqlDbType.VarChar)
        oParam(1).Value = CType(toDate, String)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_SEL_DOWNLOAD_FAILED, CommandType.StoredProcedure, oParam)

        Return dt

    End Function
    Public Function f_SEL_LIST_EMPL(ByVal EMPLID As String, ByVal EMPLNAME As String,
                                    ByVal FLAGEMPLID As String, ByVal FLAGEMPLNAME As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(3) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@EMPLID", SqlDbType.VarChar)
        oParam(0).Value = CType(EMPLID, String)

        oParam(1) = New SqlClient.SqlParameter("@EMPLNAME", SqlDbType.VarChar)
        oParam(1).Value = CType(EMPLNAME, String)

        oParam(2) = New SqlClient.SqlParameter("@FLAGEMPLNAME", SqlDbType.VarChar)
        oParam(2).Value = CType(FLAGEMPLNAME, String)

        oParam(3) = New SqlClient.SqlParameter("@FLAGEMPLID", SqlDbType.VarChar)
        oParam(3).Value = CType(FLAGEMPLID, String)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_SEL_LIST_EMPL, CommandType.StoredProcedure, oParam)

        Return dt

    End Function
    Public Function f_SEL_MST_NOTIF() As DataTable

        Dim dt As New DataTable

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_SEL_MST_NOTIF, CommandType.StoredProcedure)

        Return dt

    End Function
    Public Function f_SEL_DETAIL_MST_EMPL(ByVal IDX As Int32) As DataTable

        Dim dt As New DataTable
        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@IDX", SqlDbType.Int)
        oParam(0).Value = CType(IDX, Int32)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_DETAIL_MST_EMPL, CommandType.StoredProcedure, oParam)

        Return dt

    End Function

    ''BARU
    Public Function f_SEL_GETEXPIREDDATE(ByVal HIREDATE As String, ByVal DURATION As Integer) As DataTable

        Dim dt As New DataTable
        Dim oParam(1) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@HIREDATE", SqlDbType.VarChar)
        oParam(0).Value = CType(HIREDATE, String)

        oParam(1) = New SqlClient.SqlParameter("@DURATION", SqlDbType.Int)
        oParam(1).Value = CType(DURATION, Int32)

        dt = FillDataset(_connectionString, const_SP_GETEXPIREDDATE, CommandType.StoredProcedure, oParam)

        Return dt

    End Function

    Public Function f_SEL_GET_COUNT_EMPLOYEE(ByVal EmployeeID As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@EmployeeID", SqlDbType.VarChar)
        oParam(0).Value = CType(EmployeeID, String)


        dt = FillDataset(_connectionString, const_SP_GET_COUNT_EMPLOYEE, CommandType.StoredProcedure, oParam)
        Return dt

    End Function

    Public Function f_SEL_CHECK_DATA(ByVal EmployeeID As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@EmployeeID", SqlDbType.VarChar)
        oParam(0).Value = CType(EmployeeID, String)

        dt = FillDataset(_connectionString, const_SP_SEL_CHECK_DATA, CommandType.StoredProcedure, oParam)

        Return dt

    End Function

    Public Function f_SEL_LOAD_DATA(ByVal IDX As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@IDX", SqlDbType.VarChar)
        oParam(0).Value = CType(IDX, String)


        dt = FillDataset(_connectionString, const_sp_DETAIL_MST_EMPL, CommandType.StoredProcedure, oParam)

        Return dt

    End Function
    '' BATAS
    Public Function Get_DataProduksi(ByVal _effstart As DateTime, ByVal _effend As DateTime, ByVal _productid As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(2) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@effdatestart", SqlDbType.DateTime)
        oParam(0).Value = CType(_effstart, DateTime)

        oParam(1) = New SqlClient.SqlParameter("@effdateend", SqlDbType.DateTime)
        oParam(1).Value = CType(_effend, DateTime)

        oParam(2) = New SqlClient.SqlParameter("@productid", SqlDbType.VarChar)
        oParam(2).Value = CType(_productid, String)

        dt = FillDataset(_connectionString, const_sp_DATAPRODUKSI, CommandType.StoredProcedure, oParam)

        Return dt

    End Function

    Public Function Get_CollectionRatio(ByVal _duestart As DateTime, ByVal _dueend As DateTime, ByVal _effstart As DateTime, ByVal _effend As DateTime, ByVal _productid As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(4) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@duedatestart", SqlDbType.DateTime)
        oParam(0).Value = CType(_duestart, DateTime)

        oParam(1) = New SqlClient.SqlParameter("@duedateend", SqlDbType.DateTime)
        oParam(1).Value = CType(_dueend, DateTime)

        oParam(2) = New SqlClient.SqlParameter("@effdatestart", SqlDbType.DateTime)
        oParam(2).Value = CType(_effstart, DateTime)

        oParam(3) = New SqlClient.SqlParameter("@effdateend", SqlDbType.DateTime)
        oParam(3).Value = CType(_effend, DateTime)

        oParam(4) = New SqlClient.SqlParameter("@productid", SqlDbType.VarChar)
        oParam(4).Value = CType(_productid, String)

        dt = FillDataset(_connectionString, const_sp_COLLECTIONRATIO, CommandType.StoredProcedure, oParam)

        Return dt

    End Function

    Public Function Get_PolicyStatus(ByVal _canceldate As DateTime) As DataTable

        Dim dt As New DataTable
        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@canceldate", SqlDbType.DateTime)
        oParam(0).Value = CType(_canceldate, DateTime)

        dt = FillDataset(_connectionString, const_sp_POLICYSTATUS, CommandType.StoredProcedure, oParam)

        Return dt

    End Function

    Public Function Get_PaymentStatus(ByVal _billingdate As DateTime, ByVal _paymentdate As DateTime) As DataTable

        Dim dt As New DataTable
        Dim oParam(1) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@billingdate", SqlDbType.DateTime)
        oParam(0).Value = CType(_billingdate, DateTime)

        oParam(1) = New SqlClient.SqlParameter("@paymentdate", SqlDbType.DateTime)
        oParam(1).Value = CType(_paymentdate, DateTime)

        dt = FillDataset(_connectionString, const_sp_PAYMENTSTATUS, CommandType.StoredProcedure, oParam)

        Return dt

    End Function

    Public Function lk_Product() As DataTable

        Dim dt As New DataTable
        dt = FillDataset(_connectionString, const_sp_PRODUCT, CommandType.StoredProcedure)

        Return dt

    End Function

    Public Function lk_Product_Group() As DataTable

        Dim dt As New DataTable
        dt = FillDataset(_connectionString, const_sp_PRODUCT_DISTINCT, CommandType.StoredProcedure)

        Return dt

    End Function

    Public Function lk_Product_Param(ByVal _prmField As String, ByVal _prmName As String) As DataTable

        Dim dt As New DataTable

        Dim oParam(1) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@prmField", SqlDbType.VarChar)
        oParam(0).Value = CType(_prmField, String)

        oParam(1) = New SqlClient.SqlParameter("@prmText", SqlDbType.VarChar)
        oParam(1).Value = CType(_prmName, String)

        dt = FillDataset(_connectionString, const_sp_PRODUCT_PARAM, CommandType.StoredProcedure, oParam)

        Return dt

    End Function

    Public Function lk_Product_Param_Group(ByVal _prmField As String, ByVal _prmName As String) As DataTable

        Dim dt As New DataTable

        Dim oParam(1) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@prmField", SqlDbType.VarChar)
        oParam(0).Value = CType(_prmField, String)

        oParam(1) = New SqlClient.SqlParameter("@prmText", SqlDbType.VarChar)
        oParam(1).Value = CType(_prmName, String)

        dt = FillDataset(_connectionString, const_sp_PRODUCT_PARAM_GROUP, CommandType.StoredProcedure, oParam)

        Return dt

    End Function

    Public Function Get_RecordStatusPembayaran() As DataTable
        Dim dt As New DataTable

        dt = FillDataset(_connectionString, " select POLICYNO from tmp_ReportApp_PaymentStatus where(policyno Is Not null) ", CommandType.Text)

        Return dt
    End Function

    Public Function Get_RecordPolicyStatus() As DataTable
        Dim dt As New DataTable

        dt = FillDataset(_connectionString, " select POLICYNO from tmp_ReportApp_PolicyStatus where(policyno Is Not null) ", CommandType.Text)

        Return dt
    End Function

    Public Function lk_User(ByVal _prmField As String, ByVal _prmName As String) As DataTable

        Dim dt As New DataTable

        Dim oParam(1) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@prmField", SqlDbType.VarChar)
        oParam(0).Value = CType(_prmField, String)

        oParam(1) = New SqlClient.SqlParameter("@prmText", SqlDbType.VarChar)
        oParam(1).Value = CType(_prmName, String)

        dt = FillDataset(_connectionString, const_SP_USER, CommandType.StoredProcedure, oParam)

        Return dt

    End Function

    Public Function Get_ParentMenu() As DataTable
        Dim dt As New DataTable
        Return FillDataset(_connectionString, const_cb_PARENT, CommandType.Text)

    End Function

    Public Function Get_Menu(ByVal _param As String) As DataTable
        Dim dt As New DataTable

        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@root", SqlDbType.VarChar)
        oParam(0).Value = CType(_param, String)

        Return FillDataset(_connectionString, const_sp_MENU, CommandType.StoredProcedure, oParam)

    End Function

    Public Function Get_ParentMenu_All() As DataTable
        Dim dt As New DataTable
        Return FillDataset(_connectionString, const_cb_PARENT_ALL, CommandType.Text)

    End Function

    Public Function Auth_User(ByVal _username As String) As DataTable
        Dim dt As New DataTable

        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@username", SqlDbType.VarChar)
        oParam(0).Value = CType(_username, String)

        Return FillDataset(_connectionString, const_sp_AUTH_USER, CommandType.StoredProcedure, oParam)

    End Function
    Public Function Get_DataPolis(ByVal _effstart As DateTime, ByVal _effend As DateTime, ByVal _productid As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(2) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@effdatestart", SqlDbType.DateTime)
        oParam(0).Value = CType(_effstart, DateTime)

        oParam(1) = New SqlClient.SqlParameter("@effdateend", SqlDbType.DateTime)
        oParam(1).Value = CType(_effend, DateTime)

        oParam(2) = New SqlClient.SqlParameter("@productid", SqlDbType.VarChar)
        oParam(2).Value = CType(_productid, String)

        dt = FillDataset(_connectionString, const_sp_GetActuary, CommandType.StoredProcedure, oParam)

        Return dt

    End Function


#Region "Testing DMTM"

    Public Function Get_DMTM(ByVal _userID As String) As DataTable
        Dim dt As New DataTable

        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("userID", SqlDbType.Int)
        oParam(0).Value = CType(_userID, Integer)

        Return FillDataset(_connectionString, const_CB_REPORTING, CommandType.StoredProcedure, oParam)

    End Function

#End Region

#Region "FREE PA"


    Public Function Get_DataProduksi_FreePA(ByVal _effstart As DateTime, ByVal _effend As DateTime, ByVal _productid As String) As DataTable

        Dim dt As New DataTable

        Dim oParam(2) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@effdatestart", SqlDbType.DateTime)
        oParam(0).Value = CType(_effstart, DateTime)

        oParam(1) = New SqlClient.SqlParameter("@effdateend", SqlDbType.DateTime)
        oParam(1).Value = CType(_effend, DateTime)

        oParam(2) = New SqlClient.SqlParameter("@productid", SqlDbType.VarChar)
        oParam(2).Value = CType(_productid, String)

        Return FillDataset(_connectionString, const_sp_DATAPRODUKSI_FREEPA, CommandType.StoredProcedure, oParam)

    End Function

    Public Function Get_Product_FreePA() As DataTable

        Dim dt As New DataTable

        Return FillDataset(_connectionString, const_sp_GETPRODUCT_FREEPA, CommandType.StoredProcedure)

    End Function

    Public Function f_LOAD_DDL(ByVal load As String) As DataTable
        Dim dt As New DataTable

        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@LOAD", SqlDbType.VarChar)
        oParam(0).Value = CType(load, String)

        Dim _connectionString As String = _connectionString_AFI
        dt = FillDataset(_connectionString, const_sp_LOAD_DDL, CommandType.StoredProcedure, oParam)

        Return dt
    End Function

    Public Function f_SEL_GET_DEPARTMENT() As DataTable
        Dim dt As New DataTable

        Return FillDataset(_connectionString, const_SP_DEPARTMENT, CommandType.StoredProcedure)
    End Function
    Public Function f_SEL_GET_AREA_NAME() As DataTable
        Dim dt As New DataTable

        Return FillDataset(_connectionString, const_SP_AREA_NAME, CommandType.StoredProcedure)
    End Function

    Public Function f_SEL_GET_ONCHANGE_DEPARTMENT(ByVal Entity As String) As DataTable

        Dim dt As New DataTable
        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@Entity", SqlDbType.VarChar)
        oParam(0).Value = CType(Entity, String)


        dt = FillDataset(_connectionString, const_SP_GET_DEPARTMENT, CommandType.StoredProcedure, oParam)

        Return dt
    End Function
#End Region

End Class
