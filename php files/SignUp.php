<?php

//for database connection
include ("config.php");

//for post http request
if ($_SERVER['REQUEST_METHOD'] == "POST") {
	//retrieves json messsage
    $json = file_get_contents("php://input");
	$obj = json_decode($json,true);

    //for user account information
    $FIRSTNAME = strtoupper($obj[FIRSTNAME]);
    $LASTNAME = strtoupper($obj[LASTNAME]);
    $USERNAME = strtoupper($obj[USERNAME]);
	$EMAIL = strtoupper($obj[EMAIL]);
	$PASSWORD = $obj[PASSWORD];
	$ISUNDER = ($obj[ISUNDER] ? '1' : '0');
	$ISPOST = ($obj[ISPOST] ? '1' : '0');



    //connect to the database
	$connection = mysqli_connect(DB_HOST, DB_USER, DB_PASS,DB_DATABASE,DB_PORT);
    if (!$connection)
        die("Connection failed: " . mysqli_connect_error());
    
    //sql string 
    $SQLstring = "SELECT * FROM USER WHERE EMAIL = '$EMAIL' OR USERNAME = '$USERNAME'";

    //query being executed
    $QueryResult = mysqli_query($connection,$SQLstring)
        Or die("<p>Unable to execute the query.</p>");

    //number of rows
    $num = mysqli_num_rows($QueryResult);
    
	//if Email already exist
     if($num > 0 ){
     	http_response_code(400);
        exit();
     } 

    // if email doesnt exist
    else if($num == 0 ){
     	
        //sql string
     	$SQLstring = "INSERT INTO USER(FIRSTNAME,LASTNAME,USERNAME,EMAIL,PASSWORD,ISUNDER,ISPOST)
     					VALUES('$FIRSTNAME','$LASTNAME','$USERNAME','$EMAIL','$PASSWORD','$ISUNDER','$ISPOST')";

    	//query being executed
     	$QueryResult = mysqli_query($connection,$SQLstring)
            Or die("<p>Unable to execute the query.</p>");

		if ($QueryResult){ 
			//sql string
			$SQLstring = "SELECT ACCOUNT FROM USER WHERE USERNAME = '$USERNAME' AND PASSWORD = '$PASSWORD'";

            //query being executed
			$QueryResult = mysqli_query($connection,$SQLstring)
       			Or die("<p>Unable to execute the query.</p>");
       		
       		//fetching results and encodeing in json format
    		$Row = mysqli_fetch_assoc($QueryResult);
			$myObj->ACCOUNT =  $Row['ACCOUNT'];
			$myJSON = json_encode($myObj);
			
            //send the json object
        	echo $myJSON;
            http_response_code(200);
            exit();
		}
		
     }
     else{
        http_response_code(400);
        exit();
     }

} 
//send error code
else {
    http_response_code(405);
    exit();
}


?>