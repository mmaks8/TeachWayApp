<?php
//for database connection
include ("config.php");

//if get request
if ($_SERVER['REQUEST_METHOD'] == "GET") {

    $connection = mysqli_connect(DB_HOST, DB_USER, DB_PASS,DB_DATABASE,DB_PORT);
    if (!$connection)
        die("Connection failed: " . mysqli_connect_error());

    //sql string 
    $SQLstring = "SELECT * FROM USER";
    //query being executed
$QueryResult = mysqli_query($connection,$SQLstring)
            Or die("<p>Unable to execute the query.</p>");

        //fetching results 
        $Row = mysqli_fetch_assoc($QueryResult);
        //number of rows
        $num = mysqli_num_rows($QueryResult);

        //fill array
        for($i=0;$i<$num;$i++){

            $myObj[] = array(
            LASTNAME=>$Row['LASTNAME'],
            FIRSTNAME=>$Row['FIRSTNAME'],
            USERNAME=>$Row['USERNAME'],
            ACCOUNT=>$Row['ACCOUNT'],
            EMAIL=>$Row['EMAIL'],
            PASSWORD=>$Row['PASSWORD']
            );
   
            $Row = mysqli_fetch_assoc($QueryResult);
        }
            //encode into json
           $myJSON = json_encode($myObj,JSON_PRETTY_PRINT);
            echo $myJSON;

} 
//if post request
else if ($_SERVER['REQUEST_METHOD'] == "POST") {

$json = file_get_contents("php://input");
//$obj = json_decode($json,true);

//$myJSON = json_encode($myObj,JSON_PRETTY_PRINT);
echo $json;

} else {
        http_response_code(405);
}


?>
