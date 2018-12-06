<?php

//for database connection
include ("config.php");

//for post http request
if ($_SERVER['REQUEST_METHOD'] == "POST") {
	//retrieves json messsage
    $json = file_get_contents("php://input");
	$obj = json_decode($json,true);

    //for user account number and id
	$ACCOUNT = $obj[ACCOUNT];
    $ID = $obj[ID];

    //connect to the database
	$connection = mysqli_connect(DB_HOST, DB_USER, DB_PASS,DB_DATABASE,DB_PORT);
    if (!$connection)
        die("Connection failed: " . mysqli_connect_error());

    //sql string 
    $SQLstring = "INSERT INTO CHECKOFFLIST(ACCOUNT,ID) VALUES('$ACCOUNT','$ID')";
    
    //query being executed
    $QueryResult = mysqli_query($connection,$SQLstring)
            Or die("<p>Unable to execute the query.</p>");
}
else{
    http_response_code(405);
    exit();
}
?>