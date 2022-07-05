Imports System
Imports System.IO
Imports System.Text
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Security.Cryptography

Public Class DataAccessBase

    Dim _connectionString As String = ""

#Region " Public Properties "

    ''' <summary>
    ''' Gets or sets the string used to open a SQL Server database.
    ''' </summary>
    ''' <returns>The connection string that includes the source database name, and other parameters needed to establish the initial connection.</returns>
    Public Property ConnectionString() As String
        Get
            Return _connectionString
        End Get
        Set(ByVal value As String)
            _connectionString = value
        End Set
    End Property

#End Region

#Region "Assign Parameters"

    Private Sub AssignParameters(ByVal cmd As SqlCommand, ByVal parameterValues() As Object)
        If Not (cmd.Parameters.Count - 1 = parameterValues.Length) Then Throw New ApplicationException("Stored procedure's parameters and parameter values does not match.")
        Dim i As Integer
        For Each param As SqlParameter In cmd.Parameters
            If Not (param.Direction = ParameterDirection.Output) AndAlso Not (param.Direction = ParameterDirection.ReturnValue) Then
                param.Value = parameterValues(i)
                i += 1
            End If
        Next

    End Sub

    Private Sub AssignParameters(ByVal cmd As SqlCommand, ByVal cmdParameters() As SqlParameter)
        If (cmdParameters Is Nothing) Then Exit Sub
        For Each p As SqlParameter In cmdParameters
            cmd.Parameters.Add(p)
        Next
    End Sub

#End Region

#Region "Execute Non Query"

    Public Function ExecuteNonQuery(ByVal conn As String, ByVal cmd As String, ByVal cmdType As CommandType, Optional ByVal parameters() As SqlParameter = Nothing) As Integer
        Dim connection As SqlConnection = Nothing
        Dim transaction As SqlTransaction = Nothing
        Dim command As SqlCommand = Nothing
        Dim res As Integer = -1
        Try
            connection = New SqlConnection(conn)
            command = New SqlCommand(cmd, connection)
            command.CommandType = cmdType
            command.CommandTimeout() = 7200
            Me.AssignParameters(command, parameters)
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
            connection.Open()
            'transaction = connection.BeginTransaction()
            'command.Transaction = transaction
            res = command.ExecuteNonQuery()
            'transaction.Commit()
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        Catch ex As Exception
            'If Not (transaction Is Nothing) Then
            '    transaction.Rollback()
            'End If
            'Throw New Data.DataException(ex.Message, ex.InnerException)
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
            Throw New Exception(ex.Message, ex.InnerException)
        Finally
            If Not (connection Is Nothing) AndAlso (connection.State = ConnectionState.Open) Then connection.Close()
            If Not (command Is Nothing) Then command.Dispose()
            If Not (transaction Is Nothing) Then transaction.Dispose()
        End Try
        Return res
    End Function

#End Region

#Region " FillDataset "

    ''' <summary>
    ''' Adds or refreshes rows in the System.Data.DataSet to match those in the data source using the System.Data.DataSet name, and creates a System.Data.DataTable named "Table."
    ''' </summary>
    ''' <param name="cmd">The Transact-SQL statement or stored procedure to execute at the data source.</param>
    ''' <param name="cmdType">A value indicating how the System.Data.SqlClient.SqlCommand.CommandText property is to be interpreted.</param>
    ''' <param name="parameters">The parameters of the Transact-SQL statement or stored procedure.</param>
    ''' <returns>A System.Data.Dataset object.</returns>
    Public Function FillDataset(ByVal conn As String, ByVal cmd As String, ByVal cmdType As CommandType, Optional ByVal parameters() As SqlParameter = Nothing) As DataTable
        Dim connection As SqlConnection = Nothing
        Dim command As SqlCommand = Nothing
        Dim sqlda As SqlDataAdapter = Nothing
        Dim res As New DataTable
        Try
            connection = New SqlConnection(conn)
            command = New SqlCommand(cmd, connection)
            command.CommandType = cmdType
            AssignParameters(command, parameters)
            sqlda = New SqlDataAdapter(command)

            command.CommandTimeout() = 7200

            sqlda.Fill(res)
        Catch ex As Exception
            Throw New Data.DataException(ex.Message, ex.InnerException)
        Finally
            If Not (connection Is Nothing) Then connection.Dispose()
            If Not (command Is Nothing) Then command.Dispose()
            If Not (sqlda Is Nothing) Then sqlda.Dispose()
        End Try
        Return res
    End Function

#End Region


    Public Function EncryptString128Bit(ByVal vstrTextToBeEncrypted As String, _
                                   ByVal vstrEncryptionKey As String) As String

        Dim bytValue() As Byte
        Dim bytKey() As Byte
        Dim bytEncoded() As Byte
        Dim bytIV() As Byte = {121, 241, 10, 1, 132, 74, 11, 39, 255, 91, 45, 78, 14, 211, 22, 62}
        Dim intLength As Integer
        Dim intRemaining As Integer
        Dim objMemoryStream As New MemoryStream()
        Dim objCryptoStream As CryptoStream
        Dim objRijndaelManaged As RijndaelManaged


        '   **********************************************************************
        '   ******  Strip any null character from string to be encrypted    ******
        '   **********************************************************************

        vstrTextToBeEncrypted = StripNullCharacters(vstrTextToBeEncrypted)

        '   **********************************************************************
        '   ******  Value must be within ASCII range (i.e., no DBCS chars)  ******
        '   **********************************************************************

        bytValue = Encoding.ASCII.GetBytes(vstrTextToBeEncrypted.ToCharArray)

        intLength = Len(vstrEncryptionKey)

        '   ********************************************************************
        '   ******   Encryption Key must be 256 bits long (32 bytes)      ******
        '   ******   If it is longer than 32 bytes it will be truncated.  ******
        '   ******   If it is shorter than 32 bytes it will be padded     ******
        '   ******   with upper-case Xs.                                  ****** 
        '   ********************************************************************

        If intLength >= 32 Then
            vstrEncryptionKey = Strings.Left(vstrEncryptionKey, 32)
        Else
            intLength = Len(vstrEncryptionKey)
            intRemaining = 32 - intLength
            vstrEncryptionKey = vstrEncryptionKey & Strings.StrDup(intRemaining, "X")
        End If

        bytKey = Encoding.ASCII.GetBytes(vstrEncryptionKey.ToCharArray)

        objRijndaelManaged = New RijndaelManaged()

        '   ***********************************************************************
        '   ******  Create the encryptor and write value to it after it is   ******
        '   ******  converted into a byte array                              ******
        '   ***********************************************************************

        Try

            objCryptoStream = New CryptoStream(objMemoryStream, _
              objRijndaelManaged.CreateEncryptor(bytKey, bytIV), _
              CryptoStreamMode.Write)
            objCryptoStream.Write(bytValue, 0, bytValue.Length)

            objCryptoStream.FlushFinalBlock()

            bytEncoded = objMemoryStream.ToArray
            objMemoryStream.Close()
            objCryptoStream.Close()
        Catch



        End Try

        '   ***********************************************************************
        '   ******   Return encryptes value (converted from  byte Array to   ******
        '   ******   a base64 string).  Base64 is MIME encoding)             ******
        '   ***********************************************************************

        Return Convert.ToBase64String(bytEncoded)

    End Function

    Public Function DecryptString128Bit(ByVal vstrStringToBeDecrypted As String, _
                                        ByVal vstrDecryptionKey As String) As String

        Dim bytDataToBeDecrypted() As Byte
        Dim bytTemp() As Byte
        Dim bytIV() As Byte = {121, 241, 10, 1, 132, 74, 11, 39, 255, 91, 45, 78, 14, 211, 22, 62}
        Dim objRijndaelManaged As New RijndaelManaged()
        Dim objMemoryStream As MemoryStream
        Dim objCryptoStream As CryptoStream
        Dim bytDecryptionKey() As Byte

        Dim intLength As Integer
        Dim intRemaining As Integer
        Dim intCtr As Integer
        Dim strReturnString As String = String.Empty
        Dim achrCharacterArray() As Char
        Dim intIndex As Integer

        '   *****************************************************************
        '   ******   Convert base64 encrypted value to byte array      ******
        '   *****************************************************************

        bytDataToBeDecrypted = Convert.FromBase64String(vstrStringToBeDecrypted)

        '   ********************************************************************
        '   ******   Encryption Key must be 256 bits long (32 bytes)      ******
        '   ******   If it is longer than 32 bytes it will be truncated.  ******
        '   ******   If it is shorter than 32 bytes it will be padded     ******
        '   ******   with upper-case Xs.                                  ****** 
        '   ********************************************************************

        intLength = Len(vstrDecryptionKey)

        If intLength >= 32 Then
            vstrDecryptionKey = Strings.Left(vstrDecryptionKey, 32)
        Else
            intLength = Len(vstrDecryptionKey)
            intRemaining = 32 - intLength
            vstrDecryptionKey = vstrDecryptionKey & Strings.StrDup(intRemaining, "X")
        End If

        bytDecryptionKey = Encoding.ASCII.GetBytes(vstrDecryptionKey.ToCharArray)

        ReDim bytTemp(bytDataToBeDecrypted.Length)

        objMemoryStream = New MemoryStream(bytDataToBeDecrypted)

        '   ***********************************************************************
        '   ******  Create the decryptor and write value to it after it is   ******
        '   ******  converted into a byte array                              ******
        '   ***********************************************************************

        Try

            objCryptoStream = New CryptoStream(objMemoryStream, _
               objRijndaelManaged.CreateDecryptor(bytDecryptionKey, bytIV), _
               CryptoStreamMode.Read)

            objCryptoStream.Read(bytTemp, 0, bytTemp.Length)

            objCryptoStream.FlushFinalBlock()
            objMemoryStream.Close()
            objCryptoStream.Close()

        Catch

        End Try

        '   *****************************************
        '   ******   Return decypted value     ******
        '   *****************************************

        Return StripNullCharacters(Encoding.ASCII.GetString(bytTemp))

    End Function

    Public Function StripNullCharacters(ByVal vstrStringWithNulls As String) As String

        Dim intPosition As Integer
        Dim strStringWithOutNulls As String

        intPosition = 1
        strStringWithOutNulls = vstrStringWithNulls

        Do While intPosition > 0
            intPosition = InStr(intPosition, vstrStringWithNulls, vbNullChar)

            If intPosition > 0 Then
                strStringWithOutNulls = Left$(strStringWithOutNulls, intPosition - 1) & _
                                  Right$(strStringWithOutNulls, Len(strStringWithOutNulls) - intPosition)
            End If

            If intPosition > strStringWithOutNulls.Length Then
                Exit Do
            End If
        Loop

        Return strStringWithOutNulls

    End Function

    Public Sub SQLBulkCopy(ByVal _dt As DataTable, ByVal _tablename As String)

        Dim SQLCn As New SqlConnection(_connectionString)

        Using bulkCopy As SqlBulkCopy = _
              New SqlBulkCopy(SQLCn)
            bulkCopy.DestinationTableName = _tablename

            Try
                SQLCn.Open()
                bulkCopy.WriteToServer(_dt)

            Catch ex As Exception
                Console.WriteLine(ex.Message)
            Finally
                SQLCn.Close()
            End Try

        End Using

    End Sub

End Class
