Imports System.Configuration
Imports System.Data.SqlClient

Public Class DeleteBase
    Inherits DataAccessBase

    Dim _connectionString_AFI As String = ConfigurationManager.ConnectionStrings("ConSql").ToString

#Region "Constanta"
    Dim const_sp_Delete_CASH_BENEFIT_DETAIL As String = "sp_DEL_CASHBEN_DETAIL"
    Dim const_sp_Delete_Department As String = "sp_DEL_DEPARTMENT"
    Dim const_sp_Delete_CashBack As String = "sp_DEL_CashBack_GRIDVIEW"
    Dim const_sp_TRN_FBA_NONMED As String = "sp_DEL_TRN_FBA_NON_MED"
    Dim const_sp_TRN_FBA_OBT As String = "sp_DEL_TRN_FBA_OBT"
    Dim const_sp_DEL_USER_MATRIX As String = "sp_DEL_USER_MATRIX"
    'Dim const_sp_Delete_RekKoranItem_NEW As String = "sp_DEL_REKENINGKORANITEM_NEW"
    'Dim const_sp_Delete_RekKoranItem As String = "sp_DEL_REKENINGKORANITEM"
    'Dim const_SP_Delete_Rek_Koran_New As String = "sp_DEL_REKKORAN"
    'Dim const_SP_Delete_Rek_Koran As String = "sp_DEL_REKKORAN_Old"
    'Dim const_SP_Delete_Rek_Koran_ITEM As String = "DELETE_POLICY"
#End Region
    Public Function Del_FBA_NON_MED(ByVal _IDX As Integer) As Integer

        Dim int_i As Integer

        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@IDX", SqlDbType.Int)
        oParam(0).Value = CType(_IDX, Integer)

        Dim _connectionString As String = _connectionString_AFI

        int_i = ExecuteNonQuery(_connectionString, const_sp_TRN_FBA_NONMED, CommandType.StoredProcedure, oParam)

        Return int_i

    End Function
    Public Function Del_CASH_BEN_DETAIL(ByVal _IDX As Integer) As Integer

        Dim int_i As Integer

        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@IDX", SqlDbType.Int)
        oParam(0).Value = CType(_IDX, Integer)

        Dim _connectionString As String = _connectionString_AFI

        int_i = ExecuteNonQuery(_connectionString, const_sp_Delete_CASH_BENEFIT_DETAIL, CommandType.StoredProcedure, oParam)

        Return int_i

    End Function


    Public Function Del_USER_MATRIX(ByVal _USERNAME As String) As Integer

        Dim int_i As Integer

        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@USERNAME", SqlDbType.VarChar)
        oParam(0).Value = CType(_USERNAME, String)

        Dim _connectionString As String = _connectionString_AFI

        int_i = ExecuteNonQuery(_connectionString, const_sp_DEL_USER_MATRIX, CommandType.StoredProcedure, oParam)

        Return int_i

    End Function

    Public Function Del_FBA_OBT(ByVal _IDX As Integer) As Integer

        Dim int_i As Integer

        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@IDX", SqlDbType.Int)
        oParam(0).Value = CType(_IDX, Integer)

        Dim _connectionString As String = _connectionString_AFI

        int_i = ExecuteNonQuery(_connectionString, const_sp_TRN_FBA_OBT, CommandType.StoredProcedure, oParam)

        Return int_i

    End Function

    Public Function Del_Dept(ByVal _DeptID As Integer) As Integer

        Dim int_i As Integer

        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@DeptID", SqlDbType.Int)
        oParam(0).Value = CType(_DeptID, Integer)

        Dim _connectionString As String = _connectionString_AFI

        int_i = ExecuteNonQuery(_connectionString, const_sp_Delete_Department, CommandType.StoredProcedure, oParam)

        Return int_i

    End Function

    Public Function Del_CASHBACK_GRIDVEIW(ByVal PAYDETAILS As String, ByVal CLAIMNO As String, _
                                          ByVal POLICYNO As String, ByVal IDXFBA As String) As Integer

        Dim int_i As Integer

        Dim oParam(3) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@PAYDETAILS", SqlDbType.VarChar)
        oParam(0).Value = CType(PAYDETAILS, String)

        oParam(1) = New SqlClient.SqlParameter("@CLAIMNO", SqlDbType.VarChar)
        oParam(1).Value = CType(CLAIMNO, String)

        oParam(2) = New SqlClient.SqlParameter("@POLICYNO", SqlDbType.VarChar)
        oParam(2).Value = CType(POLICYNO, String)

        oParam(3) = New SqlClient.SqlParameter("@IDXFBA", SqlDbType.VarChar)
        oParam(3).Value = CType(IDXFBA, String)

        Dim _connectionString As String = _connectionString_AFI

        int_i = ExecuteNonQuery(_connectionString, const_sp_Delete_CashBack, CommandType.StoredProcedure, oParam)

        Return int_i

    End Function
    'Public Function Del_RekKoranItem(ByVal _rowid As Integer, ByVal _rekkoran As String, ByVal _entity As String) As Integer

    '    Dim int_i As Integer

    '    Dim oParam(1) As SqlParameter

    '    oParam(0) = New SqlClient.SqlParameter("@ROWID", SqlDbType.Int)
    '    oParam(0).Value = CType(_rowid, Integer)

    '    oParam(1) = New SqlClient.SqlParameter("@REKKORAN", SqlDbType.VarChar)
    '    oParam(1).Value = CType(_rekkoran, String)

    '    Dim _connectionString As String = _connectionString_AFI

    '    int_i = ExecuteNonQuery(_connectionString, const_sp_Delete_RekKoranItem, CommandType.StoredProcedure, oParam)

    '    Return int_i

    'End Function

    'Public Function Del_RekKoranItem_New(ByVal _rowid As Integer, ByVal _rekkoran As String, ByVal _entity As String) As Integer

    '    Dim int_i As Integer

    '    Dim oParam(1) As SqlParameter

    '    oParam(0) = New SqlClient.SqlParameter("@ROWID", SqlDbType.Int)
    '    oParam(0).Value = CType(_rowid, Integer)

    '    oParam(1) = New SqlClient.SqlParameter("@REKKORAN", SqlDbType.VarChar)
    '    oParam(1).Value = CType(_rekkoran, String)

    '    Dim _connectionString As String = _connectionString_AFI

    '    int_i = ExecuteNonQuery(_connectionString, const_sp_Delete_RekKoranItem_NEW, CommandType.StoredProcedure, oParam)

    '    Return int_i

    'End Function

    'Public Function f_Delete_RekKoran_policy(ByVal _rekKoran As String, ByVal _policyNo As String, ByVal _entity As String)
    '    Dim oParam(1) As SqlParameter

    '    oParam(0) = New SqlParameter("@REKKORAN", Data.SqlDbType.VarChar)
    '    oParam(0).Value = CType(_rekKoran, String)

    '    oParam(1) = New SqlParameter("@POLICYNO", Data.SqlDbType.VarChar)
    '    oParam(1).Value = CType(_policyNo, String)


    '    Dim _connectionString As String = _connectionString_AFI

    '    Return (ExecuteNonQuery(_connectionString, const_SP_Delete_Rek_Koran_ITEM, Data.CommandType.StoredProcedure, oParam))
    'End Function

    'Public Function f_Delete_RekKoran_New(ByVal _uploadid As Integer, ByVal _entity As String)
    '    Dim oParam(0) As SqlParameter

    '    oParam(0) = New SqlParameter("@UPLOADID", Data.SqlDbType.Int)
    '    oParam(0).Value = CType(_uploadid, Integer)

    '    Dim _connectionString As String = _connectionString_AFI

    '    Return (ExecuteNonQuery(_connectionString, const_SP_Delete_Rek_Koran_New, Data.CommandType.StoredProcedure, oParam))
    'End Function

    'Public Function f_Delete_RekKoran(ByVal _uploadid As Integer, ByVal _entity As String)
    '    Dim oParam(0) As SqlParameter

    '    oParam(0) = New SqlParameter("@UPLOADID", Data.SqlDbType.Int)
    '    oParam(0).Value = CType(_uploadid, Integer)

    '    Dim _connectionString As String = _connectionString_AFI

    '    Return (ExecuteNonQuery(_connectionString, const_SP_Delete_Rek_Koran, Data.CommandType.StoredProcedure, oParam))
    'End Function
End Class
