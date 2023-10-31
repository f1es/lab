<?php
class Worker
{
    private $name;
    private $age;
    private $salary;

    public function __construct($_name, $_age, $_salary)
    {
        $this->name = $_name;
        $this->age = $_age;
        $this->salary = $_salary;
    }

    public function getName()
    {
        return $this->name;
    }
    public function getAge()
    {
        return $this->age;
    }
    public function getSalary()
    {
        return $this->salary;
    }
}

$ivan = new Worker("Иван", 25, 1000);
$vasya = new Worker("Вася", 26, 2000);

echo "Зарплата Васи и Ивана :" . $ivan->getSalary() + $vasya->getSalary() . "\n";
echo "Возраст Васи и Ивана :" . $ivan->getAge() + $vasya->getAge() . "\n";
