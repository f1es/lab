<?php
function getFolderSize()
{
    $totalSize = 0;
    $files = glob('D:\Git\lab\sem5\web\6\*');
    foreach ($files as $file) {
        $totalSize += is_file($file) ? filesize($file) : getFolderSize($file);
    }
    return $totalSize;
}

echo round(getFolderSize() / 1024 / 1024, 2) . " MB";