var express = require('express');
var app = new express();  
var port = 3000;
var data  = new String('This is the data');

/*
app.listen(port, function(err) {  
    if (typeof(err) == "undefined") {  
        console.log('Your application is running on : ' + port + ' port');  
    }  
});  

var snowflake = require('snowflake-sdk');
// Create a Connection object that we can use later to connect.
var connection = snowflake.createConnection( {
    account: 'abs_edw_prd.west-us-2.azure',
    username: 'nacke08',
    password: 'Skyl@kemagic1997'
    }
    );
// Try to connect to Snowflake, and check whether the connection was successful.
connection.connect( 
    function(err, conn) {
        if (err) {
            console.error('Unable to connect: ' + err.message);
            process.exit();
            } 
        else {
            console.log('Successfully connected to Snowflake.');
            // Optional: store the connection ID.
            connection_ID = conn.getId();
            }
        }
    );
*/
function myFunction(){
    console.log("Show the power of a webapplcaiton")
}
function VCOffer(){
    console.log("Show the power of a webapplcaiton")
}
//"Provider=MSDASQL.1;DSN=Snowflake_PRD;HDR=Yes;Warehouse=PROD_OTHER_WH"
//https://abs_edw_prd.west-us-2.azure.snowflakecomputing.com/console#/internal/worksheet
//C:\Users\nacke08\Documents\WebApplication
