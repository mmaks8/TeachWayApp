<?php

//for database connection
include ("config.php");


//for post http request
if ($_SERVER['REQUEST_METHOD'] == "POST") {
	//retrieves json messsage
    $json = file_get_contents("php://input");
	$obj = json_decode($json,true);

	 //for user account number
	$ISGRAD = $obj[ISGRAD];


	//connect to the database
	$connection = mysqli_connect(DB_HOST, DB_USER, DB_PASS,DB_DATABASE,DB_PORT);
    if (!$connection)
        die("Connection failed: " . mysqli_connect_error());


	if($ISGRAD == 0){

		$SQLstring = "SELECT REQUIREMENTS.TITLE AS TITLE, REQUIREMENTS.DESCRIPTION AS DESCRIPTION, REQUIREMENTS.ID AS ID FROM REQUIREMENTS,CATEGORY WHERE REQUIREMENTS.CATEGORY = CATEGORY.ID AND CATEGORY.ISUNDER = 1";

	}else if($ISGRAD == 1){

		//sql string 
    	$SQLstring = "SELECT REQUIREMENTS.TITLE AS TITLE, REQUIREMENTS.DESCRIPTION AS DESCRIPTION, REQUIREMENTS.ID AS ID FROM REQUIREMENTS,CATEGORY WHERE REQUIREMENTS.CATEGORY = CATEGORY.ID AND CATEGORY.ISPOST = 1";

	}
		//query being executed
    	$QueryResult = mysqli_query($connection,$SQLstring)
        	Or die("<p>Unable to execute the query.</p>");

        //fetching results 
    	$Row = mysqli_fetch_assoc($QueryResult);
        
        //number of rows
    	$num = mysqli_num_rows($QueryResult);

        //add to array
		for($i=0;$i<$num;$i++){

			$myObj[] = array(
			ID=>$Row['ID'],
			TITLE=>$Row['TITLE'],
			DESCRIPTION=>$Row['DESCRIPTION']
			);

			$Row = mysqli_fetch_assoc($QueryResult);
		}	
	//encode into json
    $myJSON = json_encode($myObj,JSON_PRETTY_PRINT);
    
    //send the results in json
    echo $myJSON;

}
