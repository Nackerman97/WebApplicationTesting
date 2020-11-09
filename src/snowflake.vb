'==============================================================================
'DEVELOPER NOTES
'CREATED: NICHOLAS ACKERMAN <nicholas.ackerman@albertson.com>
' -----------------------------------------------------------------------------
' PACKAGE INCLUDES:
'PURPOSE: SQL CONNECTION FOR SNOWFLAKE
'CURRENT FUNCTIONS:INSERT=(INSERT,DELETE,UPDATE), PULL
'==============================================================================

'Created 10/28/2020
'BY:@Nicholas Ackerman <nicholas.ackerman@albertsons.com>
Public Function IsRecordsetEmpty(ByRef rs As ADODB.Recordset) As Boolean
    IsRecordsetEmpty = rs.EOF
End Function

'Created 10/28/2020
'BY:@Nicholas Ackerman <nicholas.ackerman@albertsons.com>
Public Function RunQuery(connectionString As String, query As String) As Recordset
    Set RunQuery = New ADODB.Recordset
    
    Dim connection As New ADODB.connection
    
    ' Potential Error, bad connection string, network error.
    connection.Open connectionString
    RunQuery.ActiveConnection = connection
    
    ' Petential Error, bad SQL, wrong SQL.
    RunQuery.Open query
    
End Function

'Created 10/28/2020
'BY:@Nicholas Ackerman <nicholas.ackerman@albertsons.com>
Public Function QuerySnowFlake(ByVal query As String) As ADODB.Recordset
    Set QuerySnowFlake = RunQuery("Provider=MSDASQL.1;DSN=Snowflake_PRD;HDR=Yes';Warehouse=PROD_OTHER_WH", query)
End Function

'Created 10/28/2020
'BY:@Nicholas Ackerman <nicholas.ackerman@albertsons.com>
'Purpose: To insert data into a Snowflake database
'Requires for a query to be sent to this function
Public Sub InsertDataIntoSnowflake(query As String)
On Error GoTo catch

    Dim Conn As ADODB.connection
    Set Conn = New ADODB.connection
    
    Conn.Open "Provider=MSDASQL.1;DSN=Snowflake_PRD;HDR=Yes';Warehouse=PROD_OTHER_WH"
    Conn.Execute query
    Conn.Close
    
    Exit Sub
catch:
    Dim errorMessage As String
    errorMessage = Err.description

    Application.ScreenUpdating = True
    Console.error errorMessage, "SQLConnection.InsertDataIntoSnowflake"
    
    DisplayErrorMessage errorMessage
End Sub

'Created 10/28/2020
'BY:@Nicholas Ackerman <nicholas.ackerman@albertsons.com>
'This function will read the number of fields that exist and return a
'Collection of Strings. These Strings will maintan the format of the
'the database, but will be split by '_'.
'Example: ["R1:Column1_Column2_Column3_Column4"]
'         ["R2:Column1_Column2_Column3_Column4"]
'INPUTS: QUERY and Array of COLUMN FIELD HEADERS
'---------------------------------------------------
Public Function PullSnowflakeDataV2(query As String, ColumnHeaders As Variant) As Collection
On Error GoTo catch
    Set PullSnowflakeDataV2 = New Collection
    
    'dialog open
    Dialog.show
    
    Dim rs As ADODB.Recordset
 
    If IsRecordsetEmpty(rs) Then
        Exit Function
    End If
    
    Dim Item As Variant
    Dim DataString As String
    Do While Not rs.EOF
        DataString = ""
        
        'Loop Through Fields
        For Each Item In ColumnHeaders
            DataString = DataString + (rs.Fields(Item).value & "_")
        Next Item
        
        'Add String of Values to Collection
        PullSnowflakeDataV2.Add DataString
        
    rs.MoveNext
    Loop
    
    'dialog close
    Dialog.Hide
    
    rs.Close
    
    Exit Function
catch:
    Dim errorMessage As String
    errorMessage = Err.description

    Application.ScreenUpdating = True
    Console.error errorMessage, "SQLConnection.PullSnowflakeDataV2"
    
    DisplayErrorMessage errorMessage
End Function