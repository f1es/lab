<?php
    session_start();
    if(!isset($_SESSION["timeVisited"])){
        $_SESSION["timeVisited"] = time();
    }
    if(time() - $_SESSION["timeVisited"] == 0){
        echo "you just visited the website";
    }
    else{
        echo "You visited the website ".(time() - $_SESSION["timeVisited"])." second ago";   
    }
?>