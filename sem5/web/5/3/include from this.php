<?php

function include_by_name($name)
{
    //echo getcwd()."\n";
    include getcwd()."\\".$name;
}

include_by_name("helloworld.php");
SayHello();