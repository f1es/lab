<?php
try
{
    echo 1/0;
}
catch(Throwable $ex)
{
    echo "Error file - ".$ex->getFile()."\n";
    echo "Error - ".$ex->getMessage()."\n";
    echo "On line - ".$ex->getLine();
}