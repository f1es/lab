<?php
$read_file = fopen("2.txt", 'r');

echo "Write the line to be deleted\n";
$line_number = readline();

$lines_counter = 0;
$write_str = "";
while(!feof($read_file))
{
    $lines_counter++;
    if ($lines_counter == $line_number)
    {
        fgets($read_file);
        continue;
    }

    $current_line = htmlentities(fgets($read_file));
    //echo $current_line;
    $write_str = $write_str . $current_line;
}

$write_file = fopen("2.txt", 'w');
fwrite($write_file, $write_str);


