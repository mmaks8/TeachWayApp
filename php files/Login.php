<?php

//for database connection
include ("config.php");

//for post http request
if ($_SERVER['REQUEST_METHOD'] == "POST") {
	//retrieves json messsage
	$json = file_get_contents("php://input");
	$obj = json_decode($json,true);

	//for user account number and id	
	$EMAIL = strtoupper($obj[EMAIL]);
	$PASSWORD = $obj[PASSWORD];

	

	//database connection
	$connection = mysqli_connect(DB_HOST, DB_USER, DB_PASS,DB_DATABASE,DB_PORT);
    if (!$connection)
        die("Connection failed: " . mysqli_connect_error());
    
    //sql string 
    $SQLstring = "SELECT * FROM USER WHERE EMAIL = '$EMAIL' OR USERNAME = '$EMAIL'";

   //query being executed
    $QueryResult = mysqli_query($connection,$SQLstring)
        Or die("<p>Unable to execute the query.</p>");
   
    //number of rows
    $num = mysqli_num_rows($QueryResult);

	//email exist in the db
	if($num == 1){

  	$SQLstring = "SELECT PASSWORD FROM USER WHERE EMAIL = '$EMAIL' OR USERNAME = '$EMAIL'";

   		//query being executed
    	$QueryResult = mysqli_query($connection,$SQLstring)
        Or die("<p>Unable to execute the query.</p>");

     	$Row = mysqli_fetch_assoc($QueryResult);
   
   		$PASS = $Row['PASSWORD'];

   		//if paswords are the same
   		if($PASS == $PASSWORD){

   			$SQLstring = "SELECT ACCOUNT FROM USER WHERE EMAIL = '$EMAIL' OR USERNAME = '$EMAIL' AND PASSWORD = '$PASSWORD'";

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
        else{
          http_response_code(400);
          exit();
        }
  }
  else{
      http_response_code(400);
      exit();
  }

}
else{
http_response_code(405);
exit();
}



?>