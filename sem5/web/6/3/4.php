<?php
function getFolderSize($file)
{
    $totalSize = 0;
    $files = glob($file . "/*");
    foreach ($files as $file) {
        $totalSize += is_file($file) ? filesize($file) : getFolderSize($file);
    }
    return $totalSize;
}

$files = glob('test/*');
foreach ($files as $file) {
    if(!is_file($file)){
        echo "Размер папки " . $file . " - " . getFolderSize($file) . "<br>";
    }
}