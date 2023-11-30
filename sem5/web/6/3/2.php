<?php
$files = glob('test/*');
foreach ($files as $file) {
    if (is_file($file) && filesize($file) > 1024 * 1024) {
        unlink($file);
    }
}
