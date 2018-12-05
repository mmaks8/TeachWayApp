<?php

//for database connection
include ("config.php");

//for post http request
if ($_SERVER['REQUEST_METHOD'] == "POST") {
    //retrieves json messsage
    $json = file_get_contents("php://input");
    $obj = json_decode($json,true);

    //for user account number
    $ACCOUNT = $obj[ACCOUNT];

    //connect to the database
    $connection = mysqli_connect(DB_HOST, DB_USER, DB_PASS,DB_DATABASE,DB_PORT);
    if (!$connection)
        die("Connection failed: " . mysqli_connect_error());

    //sql string 
    $SQLstring = "SELECT ISUNDER,ISPOST FROM USER WHERE ACCOUNT = '$ACCOUNT'";

     //query being executed
    $QueryResult = mysqli_query($connection,$SQLstring)
        Or die("<p>Unable to execute the query.</p>");

    //fetching results
    $Row = mysqli_fetch_assoc($QueryResult);
    $ISUNDER = $Row['ISUNDER'];
    $ISPOST = $Row['ISPOST'];

    // if the user is an undergraduate 
    if($ISUNDER == 1){
        
        //sql string 
        $SQLstring = "SELECT REQUIREMENTS.TITLE AS TITLE, REQUIREMENTS.DESCRIPTION AS DESCRIPTION, REQUIREMENTS.ID AS ID FROM REQUIREMENTS,CATEGORY WHERE REQUIREMENTS.CATEGORY = CATEGORY.ID AND CATEGORY.ISUNDER = 1";

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
            DESCRIPTION=>$Row['DESCRIPTION'],
            DONE=>0
            );

            $Row = mysqli_fetch_assoc($QueryResult);
        }
        
        //sql string 
        $SQLstring = "SELECT REQUIREMENTS.ID AS ID FROM REQUIREMENTS,CHECKOFFLIST WHERE REQUIREMENTS.ID = CHECKOFFLIST.ID AND CHECKOFFLIST.ACCOUNT = '$ACCOUNT'";

        //query being executed
        $QueryResult = mysqli_query($connection,$SQLstring)
            Or die("<p>Unable to execute the query.</p>");
        
        //fetching results 
        $Row = mysqli_fetch_assoc($QueryResult);
        //number of rows
        $num = mysqli_num_rows($QueryResult);

        //make done true for requirements checked off
        for($i=0;$i<$num;$i++){

            $temp = $Row['ID'] - 1;
            $myObj[$temp][DONE] = 1;

         
            $Row = mysqli_fetch_assoc($QueryResult);
        }
    }
    //if the user is post graduate
    if($ISPOST== 1){
        
        //sql string 
        $SQLstring = "SELECT REQUIREMENTS.TITLE AS TITLE, REQUIREMENTS.DESCRIPTION AS DESCRIPTION, REQUIREMENTS.ID AS ID FROM REQUIREMENTS,CATEGORY WHERE REQUIREMENTS.CATEGORY = CATEGORY.ID AND CATEGORY.ISPOST = 1";

        //query being executed
        $QueryResult = mysqli_query($connection,$SQLstring)
            Or die("<p>Unable to execute the query.</p>");

        //fetching results 
        $Row = mysqli_fetch_assoc($QueryResult);
        //number of rows
        $num = mysqli_num_rows($QueryResult);

        //adding to array
        for($i=0;$i<$num;$i++){

            $myObj[] = array(
            ID=>$Row['ID'],
            TITLE=>$Row['TITLE'],
            DESCRIPTION=>$Row['DESCRIPTION'],
            DONE=>0
            );
            
            $Row = mysqli_fetch_assoc($QueryResult);
        }
        //sql string 
        $SQLstring = "SELECT REQUIREMENTS.ID AS ID FROM REQUIREMENTS,CHECKOFFLIST WHERE REQUIREMENTS.ID = CHECKOFFLIST.ID AND CHECKOFFLIST.ACCOUNT = '$ACCOUNT'";

        //query being executed
        $QueryResult = mysqli_query($connection,$SQLstring)
            Or die("<p>Unable to execute the query.</p>");
        
        //fetching results 
        $Row = mysqli_fetch_assoc($QueryResult);
        //number of rows
        $num = mysqli_num_rows($QueryResult);
        
        //make done true for requirements checked off
        for($i=0;$i<$num;$i++){

            $temp = $Row['ID'] - 37;
            $myObj[$temp][DONE] = 1;
            
            $Row = mysqli_fetch_assoc($QueryResult);
        }
    }
    //encoding array in json format and sending it
    $myJSON = json_encode($myObj,JSON_PRETTY_PRINT);
    echo $myJSON;
}
else{
    http_response_code(405);
    exit();
}

?>