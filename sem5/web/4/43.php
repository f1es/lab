<?php
class Worker
{
    private $name;
    private $age = 0;
    private $salary;

    public function setName($_name)
    {
        $this->name = $_name;
    }
    public function getName()
    {
        return $this->name;
    }

    public function setAge($_age)
    {
        if (Worker::checkAge($_age))
            $this->age = $_age;
    }
    public function getAge()
    {
        return $this->age;
    }

    public function setSalary($_salary)
    {
        $this->salary = $_salary;
    }
    public function getSalary()
    {
        return $this->salary;
    }

    private function checkAge($age)
    {
        return $age >= 1 and $age <= 100 ? true : false;
    }
}

$ivan = new Worker();
$ivan->setName("Иван");
$ivan->setAge(111);
$ivan->setSalary(1000);

$vasya = new Worker();
$vasya->setName("Вася");
$vasya->setAge(-1);
$vasya->setSalary(2000);

echo "Возраст " . $ivan->getName() . " " . $ivan->getAge() . "\n";
echo "Возраст " . $vasya->getName() . " " . $vasya->getAge();

//echo "Зарплата Васи и Ивана :" . $ivan->getSalary() + $vasya->getSalary() . "\n";
//echo "Возраст Васи и Ивана :" . $ivan->getAge() + $vasya->getAge() . "\n";
