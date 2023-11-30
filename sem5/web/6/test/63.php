<?php
$dir = getcwd(); // получаем текущий каталог

if (!is_dir($dir)) return;// является ли путь каталогом

if ($dh = opendir($dir)) // открываем каталог
{
// считываем по одному файл или подкаталогу
// пока не дойдем до конца

while (($file = readdir($dh)) !== false)
{
    if($file=='.' || $file=='..') continue;
    // если каталог или файл
    if(is_dir($file)) 
        echo "каталог: $file \n";
    else 
        {
            echo "файл: $file \n";
            //fopen($file, 'r');
            $new_name = get_h1_name($file);
            if (!strpos($file, ".php") and $new_name)
                rename($file, $new_name . ".html");
        }
    }
    closedir($dh); // закрываем каталог
}



function get_h1_name($file)
{
    $read_file =  fopen((string)$file, 'r'); 

    //$str = "";
    while(!feof($read_file))
    {
        $current_line = htmlentities(fgets($read_file));
        //echo strpos($current_line, "<h1>") . "\n";
        if (strpos($current_line, "h1"))
        {

            $tag_start = strpos($current_line, "h1") + 6;
            $tag_end = strpos($current_line, "/h1");
            $name = substr($current_line, $tag_start, $tag_start - $tag_end);
            return $name;
        }
        //$str = $str . $current_line;
    }
    fclose($read_file);
    return false;
}