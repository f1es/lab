<?php
function N1()
{
    echo "\tN1<br>";
    $sumFor = 0;
    for ($i = 1; $i <= 25; $i++)
    {
        $sumFor += $i;
    }
    echo "for ".$sumFor."<br>";
    $i = 0;
    $sumWhile = 0;
    while($i < 25)
    {
        $i++;
        $sumWhile += $i;
    }
    echo "while ".$sumWhile."<br>";
}

function N2()
{
    echo "\tN2<br>";
    //Меня зовут Илья
    /* Выполнил в понедельник в 18:14 */
    echo "приветствие"."<br>";
}

function N3()
{
    echo "\tN3<br>";
    $a = 3;
    $b = 5;
    $c = 8;
    echo $a." ".$b." ".$c."<br>";
    $d = $a + $b + $c;
    echo $d."<br>";
    $result = 2+6+2/5-1;
    echo $result."<br>";
}

function N4()
{
    echo "\tN4<br>";
    define("a", "41");
    define("b", "33");
    echo a + b;
    define("a", "11");
    //echo $c;
}

function N5()
{
    echo "\tN5<br>";
    $arra = ["element"=>1,2,3,4,5];
    $arrb = [1,2,3,4,5];
    unset($arrb[0]);
    echo $arra[2]."<br>";
    echo $arrb[2]."<br>";

    foreach($arra as $a)
    {
        echo $a." ";
    }
    echo "<br>";
    foreach($arrb as $a)
    {
        echo $a." ";
    }
    echo "<br>";

    $a = count($arra);
    echo "count a:".$a."<br>";
    $b = count($arrb);
    echo "count b:".$b."<br>";
    //echo $arra["element"];
}

function N6()
{
    echo "\tN6<br>";
    $a = "Боброе утро";
    $b = " дамы ";
    $c = "и господа";
    echo $a.$b.$c;
}

N1();
N2();
N3();
N4();
N5();
N6();
?>