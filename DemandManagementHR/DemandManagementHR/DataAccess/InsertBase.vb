Imports System.Configuration
Imports System.Data.SqlClient

Public Class InsertBase
    Inherits DataAccessBase

    Dim _connectionString_AFI As String = ConfigurationManager.ConnectionStrings("ConSql").ToString
    Dim _connectionString As String = ConfigurationManager.ConnectionStrings("ConSql").ToString
#Region "Constanta"

    Dim const_sp_INSERTUSER As String = "sp_ReportApp_InsertUser"
    Dim const_sp_INSERTMENU As String = "sp_ReportApp_Insert_Menu"
    Dim const_sp_INSERTPARENT As String = "sp_ReportApp_Insert_Parent"
    Dim const_sp_INSERT_GROUP_PRODUCT As String = "sp_Insert_Grouping_Product"

    Dim const_SP_INSERT_USER_MATRIX As String = "sp_ADD_USER_MATRIX"
    Dim const_SP_EDIT_USER_MATRIX As String = "sp_EDIT_USER_MATRIX"
    Dim const_SP_INS_MST_MENU As String = "sp_Add_Master_Menu"
    Dim const_SP_INS_MST_MENU_CHILD As String = "sp_Add_Master_Menu_Child"
    Dim const_SP_INS_MST_EMPLOYEE_UPLOAD As String = "sp_UPLOAD_DATA_KARYAWAN"
    Dim const_SP_INS_MST_EMPLOYEE_UPLOAD_FAILED As String = "sp_UPLOAD_DATA_KARYAWAN_FAILED"

    Dim const_SP_INS_UPD_MST_EMPLOYEE As String = "SP_INS_UPD_MST_EMPLOYEE"
#End Region
    Public Function f_INS_UPD_MST_EMPLOYEE(ByVal EMPID As String, ByVal EMPNAME As String,
                                           ByVal DEPARTMENT As String, ByVal ENTITY As String,
                                           ByVal AREA As String, ByVal IDMANAGER As String,
                                           ByVal HIRED As Date, ByVal EXPIRED As Date,
                                           ByVal DURATION As Int32, ByVal STATUS As String, ByVal FLAG As Int32,
                                           ByVal CREATED_BY As String, ByVal UPDATED_BY As String, ByVal idx As String, ByVal COMMAND As String)

        Dim oParam(14) As SqlParameter

        oParam(0) = New SqlParameter("@EMPID", Data.SqlDbType.VarChar)
        oParam(0).Value = CType(EMPID, String)

        oParam(1) = New SqlParameter("@EMPNAME", Data.SqlDbType.VarChar)
        oParam(1).Value = CType(EMPNAME, String)

        oParam(2) = New SqlParameter("@DEPARTMENT", Data.SqlDbType.VarChar)
        oParam(2).Value = CType(DEPARTMENT, String)

        oParam(3) = New SqlParameter("@ENTITY", Data.SqlDbType.VarChar)
        oParam(3).Value = CType(ENTITY, String)

        oParam(4) = New SqlParameter("@AREANAME", Data.SqlDbType.VarChar)
        oParam(4).Value = CType(AREA, String)

        oParam(5) = New SqlParameter("@IDMANAGER", Data.SqlDbType.VarChar)
        oParam(5).Value = CType(IDMANAGER, String)

        oParam(6) = New SqlParameter("@HIREDATE", Data.SqlDbType.Date)
        oParam(6).Value = CType(HIRED, Date)

        oParam(7) = New SqlParameter("@EXPIREDATE", Data.SqlDbType.Date)
        oParam(7).Value = CType(EXPIRED, Date)

        oParam(8) = New SqlParameter("@DURATION", Data.SqlDbType.Int)
        oParam(8).Value = CType(DURATION, Int32)

        oParam(9) = New SqlParameter("@STATUS", Data.SqlDbType.VarChar)
        oParam(9).Value = CType(STATUS, String)

        oParam(10) = New SqlParameter("@FLAG", Data.SqlDbType.Int)
        oParam(10).Value = CType(FLAG, Int32)

        oParam(11) = New SqlParameter("@CREATEDBY", Data.SqlDbType.VarChar)
        oParam(11).Value = CType(CREATED_BY, String)

        oParam(12) = New SqlParameter("@UPDATEDBY", Data.SqlDbType.VarChar)
        oParam(12).Value = CType(UPDATED_BY, String)

        oParam(13) = New SqlParameter("@IDX", Data.SqlDbType.VarChar)
        oParam(13).Value = CType(idx, String)

        oParam(14) = New SqlParameter("@COMMAND", Data.SqlDbType.VarChar)
        oParam(14).Value = CType(COMMAND, String)


        Dim _connectionString As String = _connectionString_AFI

        Return (ExecuteNonQuery(_connectionString, const_SP_INS_UPD_MST_EMPLOYEE, Data.CommandType.StoredProcedure, oParam))

    End Function
    Public Function f_Edit_User_Matrix(ByVal _UserName As String, ByVal _IdMenuChild As String,
                                       ByVal _CreatedBy As String, ByVal _entity As String)

        Dim oParam(2) As SqlParameter

        oParam(0) = New SqlParameter("@UserName", Data.SqlDbType.VarChar)
        oParam(0).Value = CType(_UserName, String)

        oParam(1) = New SqlParameter("@IdMenuChild", Data.SqlDbType.VarChar)
        oParam(1).Value = CType(_IdMenuChild, String)

        oParam(2) = New SqlParameter("@CREATED_BY", Data.SqlDbType.VarChar)
        oParam(2).Value = CType(_CreatedBy, String)


        Dim _connectionString As String = _connectionString_AFI

        Return (ExecuteNonQuery(_connectionString, const_SP_EDIT_USER_MATRIX, Data.CommandType.StoredProcedure, oParam))

    End Function
    Public Function f_Insert_User_Matrix(ByVal _UserName As String, ByVal _IdMenuChild As String,
                                         ByVal _CreatedBy As String, ByVal _entity As String)

        Dim oParam(2) As SqlParameter

        oParam(0) = New SqlParameter("@UserName", Data.SqlDbType.VarChar)
        oParam(0).Value = CType(_UserName, String)

        oParam(1) = New SqlParameter("@IdMenuChild", Data.SqlDbType.VarChar)
        oParam(1).Value = CType(_IdMenuChild, String)

        oParam(2) = New SqlParameter("@CREATED_BY", Data.SqlDbType.VarChar)
        oParam(2).Value = CType(_CreatedBy, String)

        Dim _connectionString As String = _connectionString_AFI

        Return (ExecuteNonQuery(_connectionString, const_SP_INSERT_USER_MATRIX, Data.CommandType.StoredProcedure, oParam))

    End Function
    Public Function Ins_User(ByVal _username As String, ByVal _isactive As String, ByVal _datecreated As DateTime, ByVal _createdby As String,
                             ByVal _datemodified As DateTime, ByVal _modifiedby As String, ByVal _rolemenu As String) As Integer

        Dim oParam(6) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@username", SqlDbType.VarChar)
        oParam(0).Value = CType(_username, String)

        oParam(1) = New SqlClient.SqlParameter("@isactive", SqlDbType.VarChar)
        oParam(1).Value = CType(_isactive, String)

        oParam(2) = New SqlClient.SqlParameter("@datecreated", SqlDbType.DateTime)
        oParam(2).Value = CType(_datecreated, DateTime)

        oParam(3) = New SqlClient.SqlParameter("@createdby", SqlDbType.VarChar)
        oParam(3).Value = CType(_createdby, String)

        oParam(4) = New SqlClient.SqlParameter("@datemodified", SqlDbType.DateTime)
        oParam(4).Value = CType(_datemodified, DateTime)

        oParam(5) = New SqlClient.SqlParameter("@modifiedby", SqlDbType.VarChar)
        oParam(5).Value = CType(_modifiedby, String)

        oParam(6) = New SqlClient.SqlParameter("@rolemenu", SqlDbType.VarChar)
        oParam(6).Value = CType(_rolemenu, String)

        Return (ExecuteNonQuery(_connectionString, const_sp_INSERTUSER, CommandType.StoredProcedure, oParam))

    End Function

    Public Function Ins_Menu(ByVal _menuname As String, ByVal _type As String, ByVal _root As String, ByVal _createdby As String,
                            ByVal _createddate As DateTime, ByVal _modifiedby As String, ByVal _modifieddate As DateTime) As Integer

        Dim oParam(6) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@menuname", SqlDbType.VarChar)
        oParam(0).Value = CType(_menuname, String)

        oParam(1) = New SqlClient.SqlParameter("@type", SqlDbType.VarChar)
        oParam(1).Value = CType(_type, String)

        oParam(2) = New SqlClient.SqlParameter("@root", SqlDbType.VarChar)
        oParam(2).Value = CType(_root, String)

        oParam(3) = New SqlClient.SqlParameter("@createdby", SqlDbType.VarChar)
        oParam(3).Value = CType(_createdby, String)

        oParam(4) = New SqlClient.SqlParameter("@createddate", SqlDbType.DateTime)
        oParam(4).Value = CType(_createddate, DateTime)

        oParam(5) = New SqlClient.SqlParameter("@modifiedby", SqlDbType.VarChar)
        oParam(5).Value = CType(_modifiedby, String)

        oParam(6) = New SqlClient.SqlParameter("@modifieddate", SqlDbType.DateTime)
        oParam(6).Value = CType(_modifieddate, DateTime)

        Return (ExecuteNonQuery(_connectionString, const_sp_INSERTMENU, CommandType.StoredProcedure, oParam))

    End Function

    Public Function Ins_Parent(ByVal _parentname As String, ByVal _createdby As String, ByVal _createddate As DateTime, ByVal _modifiedby As String, ByVal _modifieddate As DateTime) As Integer
        Dim oParam(4) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@parentname", SqlDbType.VarChar)
        oParam(0).Value = CType(_parentname, String)

        oParam(1) = New SqlClient.SqlParameter("@createdby", SqlDbType.VarChar)
        oParam(1).Value = CType(_createdby, String)

        oParam(2) = New SqlClient.SqlParameter("@createddate", SqlDbType.DateTime)
        oParam(2).Value = CType(_createddate, DateTime)

        oParam(3) = New SqlClient.SqlParameter("@modifiedby", SqlDbType.VarChar)
        oParam(3).Value = CType(_modifiedby, String)

        oParam(4) = New SqlClient.SqlParameter("@modifieddate", SqlDbType.DateTime)
        oParam(4).Value = CType(_modifieddate, DateTime)

        Return ExecuteNonQuery(_connectionString, const_sp_INSERTPARENT, CommandType.StoredProcedure, oParam)

    End Function

    Public Function Ins_GROUP_PRODUCT(ByVal _GroupID As String, ByVal _GroupName As String) As Integer
        Dim oParam(1) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@Grouping_idx", SqlDbType.VarChar)
        oParam(0).Value = CType(_GroupID, String)

        oParam(1) = New SqlClient.SqlParameter("@Grouping_Name", SqlDbType.VarChar)
        oParam(1).Value = CType(_GroupName, String)

        Return ExecuteNonQuery(_connectionString, const_sp_INSERT_GROUP_PRODUCT, CommandType.StoredProcedure, oParam)

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
    Public Function f_INSERT_MST_EMPLOYEE(ByVal JOINDATE As String, ByVal ENDDATE As String, ByVal DURATION As Integer,
                                                ByVal STATUS As String, ByVal EMOPLOYEEID As String, ByVal EMOPLOYEENAME As String, ByVal TITLE As String,
                                                ByVal DEPARTMENT As String, ByVal ENTITY As String, ByVal EMAILMANAGER As String, ByVal EMAILHRSERVICES As String,
                                                ByVal UPLOADID As Integer,
                                                ByVal CREATEDBY As String)

        Dim oParam(12) As SqlParameter

        oParam(0) = New SqlParameter("@JOINDATE", Data.SqlDbType.VarChar)
        oParam(0).Value = CType(JOINDATE, String)

        oParam(1) = New SqlParameter("@ENDDATE", Data.SqlDbType.VarChar)
        oParam(1).Value = CType(ENDDATE, String)

        oParam(2) = New SqlParameter("@DURATION", Data.SqlDbType.Int)
        oParam(2).Value = CType(DURATION, Integer)

        oParam(3) = New SqlParameter("@STATUS", Data.SqlDbType.VarChar)
        oParam(3).Value = CType(STATUS, String)

        oParam(4) = New SqlParameter("@EMOPLOYEEID", Data.SqlDbType.VarChar)
        oParam(4).Value = CType(EMOPLOYEEID, String)

        oParam(5) = New SqlParameter("@EMOPLOYEENAME", Data.SqlDbType.VarChar)
        oParam(5).Value = CType(EMOPLOYEENAME, String)

        oParam(6) = New SqlParameter("@TITLE", Data.SqlDbType.VarChar)
        oParam(6).Value = CType(TITLE, String)

        oParam(7) = New SqlParameter("@DEPARTMENT", Data.SqlDbType.VarChar)
        oParam(7).Value = CType(DEPARTMENT, String)

        oParam(8) = New SqlParameter("@ENTITY", Data.SqlDbType.VarChar)
        oParam(8).Value = CType(ENTITY, String)

        oParam(9) = New SqlParameter("@EMAILMANAGER", Data.SqlDbType.VarChar)
        oParam(9).Value = CType(EMAILMANAGER, String)

        oParam(10) = New SqlParameter("@EMAILHRSERVICES", Data.SqlDbType.VarChar)
        oParam(10).Value = CType(EMAILHRSERVICES, String)

        oParam(11) = New SqlParameter("@UPLOADID", Data.SqlDbType.Int)
        oParam(11).Value = CType(UPLOADID, Integer)

        oParam(12) = New SqlParameter("@CREATEDBY", Data.SqlDbType.VarChar)
        oParam(12).Value = CType(CREATEDBY, String)

        Dim _connectionString As String = _connectionString_AFI

        Return (ExecuteNonQuery(_connectionString, const_SP_INS_MST_EMPLOYEE_UPLOAD, Data.CommandType.StoredProcedure, oParam))

    End Function
    Public Function f_INSERT_MST_EMPLOYEE_FAILED(ByVal JOINDATE As String, ByVal ENDDATE As String, ByVal DURATION As Integer,
                                                 ByVal STATUS As String, ByVal EMOPLOYEEID As String, ByVal EMOPLOYEENAME As String, ByVal TITLE As String,
                                                 ByVal DEPARTMENT As String, ByVal ENTITY As String, ByVal EMAILMANAGER As String, ByVal EMAILHRSERVICES As String,
                                                 ByVal UPLOADID As Integer, ByVal REASON As String,
                                                 ByVal CREATEDBY As String)

        Dim oParam(13) As SqlParameter

        oParam(0) = New SqlParameter("@JOINDATE", Data.SqlDbType.Date)
        oParam(0).Value = CType(JOINDATE, Date)

        oParam(1) = New SqlParameter("@ENDDATE", Data.SqlDbType.Date)
        oParam(1).Value = CType(ENDDATE, Date)

        oParam(2) = New SqlParameter("@DURATION", Data.SqlDbType.Int)
        oParam(2).Value = CType(DURATION, Integer)

        oParam(3) = New SqlParameter("@STATUS", Data.SqlDbType.VarChar)
        oParam(3).Value = CType(STATUS, String)

        oParam(4) = New SqlParameter("@EMOPLOYEEID", Data.SqlDbType.VarChar)
        oParam(4).Value = CType(EMOPLOYEEID, String)

        oParam(5) = New SqlParameter("@EMOPLOYEENAME", Data.SqlDbType.VarChar)
        oParam(5).Value = CType(EMOPLOYEENAME, String)

        oParam(6) = New SqlParameter("@TITLE", Data.SqlDbType.VarChar)
        oParam(6).Value = CType(TITLE, String)

        oParam(7) = New SqlParameter("@DEPARTMENT", Data.SqlDbType.VarChar)
        oParam(7).Value = CType(DEPARTMENT, String)

        oParam(8) = New SqlParameter("@ENTITY", Data.SqlDbType.VarChar)
        oParam(8).Value = CType(ENTITY, String)

        oParam(9) = New SqlParameter("@EMAILMANAGER", Data.SqlDbType.VarChar)
        oParam(9).Value = CType(EMAILMANAGER, String)

        oParam(10) = New SqlParameter("@EMAILHRSERVICES", Data.SqlDbType.VarChar)
        oParam(10).Value = CType(EMAILHRSERVICES, String)

        oParam(11) = New SqlParameter("@UPLOADID", Data.SqlDbType.Int)
        oParam(11).Value = CType(UPLOADID, Integer)

        oParam(12) = New SqlParameter("@REASON", Data.SqlDbType.VarChar)
        oParam(12).Value = CType(REASON, String)

        oParam(13) = New SqlParameter("@CREATEDBY", Data.SqlDbType.VarChar)
        oParam(13).Value = CType(CREATEDBY, String)

        Dim _connectionString As String = _connectionString_AFI

        Return (ExecuteNonQuery(_connectionString, const_SP_INS_MST_EMPLOYEE_UPLOAD_FAILED, Data.CommandType.StoredProcedure, oParam))

    End Function
End Class
