<?php
class Worker
{
    public $name;
    public $age;
    public $salary;
}

$ivan = new Worker();
$ivan->name = "Иван";
$ivan->age = 25;
$ivan->salary = 1000;

$vasya = new Worker();
$vasya->name = "Вася";
$vasya->age = 26;
$vasya->salary = 2000;

echo "Зарплата Васи и Ивана :" . $ivan->salary + $vasya->salary . "\n";
echo "Возраст Васи и Ивана :" . $ivan->age + $vasya->age . "\n";
