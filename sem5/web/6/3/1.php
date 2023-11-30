<?php
$files = glob('test/*.txt');
foreach ($files as $file) {
    if (is_file($file)) {
        $content = file_get_contents($file);
        $startTag = '<h1>';
        $endTag = '</h1>';
        $startPos = strpos($content, $startTag);
        $endPos = strpos($content, $endTag);
        if ($startPos !== false && $endPos !== false) {
            $h1Text = substr($content, $startPos + strlen($startTag), $endPos - ($startPos + strlen($startTag)));
            $newFilename = $h1Text . '.txt';
            rename($file, 'test/' . $newFilename);
        }
    }
}
