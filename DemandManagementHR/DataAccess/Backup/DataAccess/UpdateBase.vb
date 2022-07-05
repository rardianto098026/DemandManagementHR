Imports System.Configuration
Imports System.Data.SqlClient

Public Class UpdateBase
    Inherits DataAccessBase

    Dim _connectionString_AFI As String = ConfigurationManager.ConnectionStrings("ConSql").ToString

    Dim _connectionString As String = ConfigurationManager.ConnectionStrings("ConSql").ToString
#Region "Constanta"

    Dim const_sp_Update_Menu As String = "sp_ReportApp_Update_Menu"
    Dim const_sp_Update_User As String = "sp_ReportApp_UpdateUser"
    Dim const_sp_UPDATE_LOGOUT As String = "sp_UPDATE_LOGOUT"
    Dim const_sp_UPDATE_NOTIF_EMAIL_MST_EMPL As String = "sp_UPDATE_NOTIF_EMAIL_MST_EMPL"
    Dim const_SP_UPDATE_MST_EMPL As String = "SP_INS_UPD_MST_EMPLOYEE"

#End Region

    Public Function f_INS_UPD_MST_EMPLOYEE(ByVal EMPID As String, ByVal EMPNAME As String,
                                           ByVal ENTITY As String, ByVal DEPARTMENT As String,
                                           ByVal AREA As String, ByVal IDMANAGER As String,
                                           ByVal HIRED As Date, ByVal EXPIRED As Date,
                                           ByVal DURATION As Int32, ByVal STATUS As String, ByVal FLAG As Int32,
                                           ByVal CREATED_BY As String, ByVal UPDATED_BY As String, ByVal idx As String, ByVal COMMAND As String)

        Dim oParam(14) As SqlParameter

        oParam(0) = New SqlParameter("@EMPID", Data.SqlDbType.VarChar)
        oParam(0).Value = CType(EMPID, String)

        oParam(1) = New SqlParameter("@EMPNAME", Data.SqlDbType.VarChar)
        oParam(1).Value = CType(EMPNAME, String)

        oParam(2) = New SqlParameter("@ENTITY", Data.SqlDbType.VarChar)
        oParam(2).Value = CType(ENTITY, String)

        oParam(3) = New SqlParameter("@DEPARTMENT", Data.SqlDbType.VarChar)
        oParam(3).Value = CType(DEPARTMENT, String)

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

        Return (ExecuteNonQuery(_connectionString, const_SP_UPDATE_MST_EMPL, Data.CommandType.StoredProcedure, oParam))

    End Function
    Public Function f_UPDATE_NOTIF_EMAIL_MST_EMPL(ByVal _userid As String, ByVal _Flag As String, ByVal _IDX As String,
                                                  ByVal PARAM As String) As Integer

        Dim oParam(3) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@USERID", SqlDbType.VarChar)
        oParam(0).Value = CType(_userid, String)

        oParam(1) = New SqlClient.SqlParameter("@FLAG", SqlDbType.VarChar)
        oParam(1).Value = CType(_Flag, String)

        oParam(2) = New SqlClient.SqlParameter("@IDX", SqlDbType.VarChar)
        oParam(2).Value = CType(_IDX, String)

        oParam(3) = New SqlClient.SqlParameter("@PARAM", SqlDbType.VarChar)
        oParam(3).Value = CType(PARAM, String)

        Dim _connectionString As String = _connectionString_AFI
        Return ExecuteNonQuery(_connectionString, const_sp_UPDATE_NOTIF_EMAIL_MST_EMPL, CommandType.StoredProcedure, oParam)

    End Function
    Public Function f_UpdateLogout(ByVal _userid As String, ByVal _entity As String) As Integer

        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@USERID", SqlDbType.VarChar)
        oParam(0).Value = CType(_userid, String)

        Dim _connectionString As String = _connectionString_AFI
        Return ExecuteNonQuery(_connectionString, const_sp_UPDATE_LOGOUT, CommandType.StoredProcedure, oParam)

    End Function

    Public Function Update_Menu(ByVal _menuid As Integer, ByVal _menuname As String, ByVal _modifiedby As String) As Integer
        Dim oParam(2) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@menuid", SqlDbType.Int)
        oParam(0).Value = CType(_menuid, Integer)


        oParam(1) = New SqlClient.SqlParameter("@menuname", SqlDbType.VarChar)
        oParam(1).Value = CType(_menuname, String)

        oParam(2) = New SqlClient.SqlParameter("@modifiedby", SqlDbType.VarChar)
        oParam(2).Value = CType(_modifiedby, String)

        Return ExecuteNonQuery(_connectionString, const_sp_Update_Menu, CommandType.StoredProcedure, oParam)

    End Function

    Public Function Update_User(ByVal _userid As Integer, ByVal _username As String, ByVal _isactive As String,
                                ByVal _datemodified As DateTime, ByVal _modifiedby As String, ByVal _rolemenu As String) As Integer
        Dim oParam(5) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@userid", SqlDbType.Int)
        oParam(0).Value = CType(_userid, Integer)

        oParam(1) = New SqlClient.SqlParameter("@username", SqlDbType.VarChar)
        oParam(1).Value = CType(_username, String)

        oParam(2) = New SqlClient.SqlParameter("@isactive", SqlDbType.VarChar)
        oParam(2).Value = CType(_isactive, String)

        oParam(3) = New SqlClient.SqlParameter("@datemodified", SqlDbType.DateTime)
        oParam(3).Value = CType(_datemodified, DateTime)

        oParam(4) = New SqlClient.SqlParameter("@modifiedby", SqlDbType.VarChar)
        oParam(4).Value = CType(_modifiedby, String)

        oParam(5) = New SqlClient.SqlParameter("@rolemenu", SqlDbType.VarChar)
        oParam(5).Value = CType(_rolemenu, String)

        Return ExecuteNonQuery(_connectionString, const_sp_Update_User, CommandType.StoredProcedure, oParam)

    End Function

End Class
