<?php
session_start();
if (isset($_SESSION["name"]) && isset($_SESSION["age"])) {
    echo "name: ".$_SESSION["name"]."\n"."age: ".$_SESSION["age"];
}
?>