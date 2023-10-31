<?php
class User
{
    protected $name;
    protected $age;

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
        $this->age = $_age;
    }
    public function getAge()
    {
        return $this->age;
    }
}

class Worker extends User
{
    private $salary;

    public function setSalary($_salary)
    {
        $this->salary = $_salary;
    }
    public function getSalary()
    {
        return $this->salary;
    }
}

class Student extends User
{
    private $grants;
    private $course;

    public function setGrants($_grants)
    {
        $this->grants = $_grants;
    }
    public function getGrants()
    {
        return $this->grants;
    }

    public function setCourse($_course)
    {
        $this->course = $_course;
    }
    public function getCourse()
    {
        return $this->course;
    }
}
