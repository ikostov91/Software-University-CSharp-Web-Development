class Person
{
    public string address;
    public string name;

    public Person(string address)
    {
        this.address = address;
    }
}

class Teacher : Person
{
    public Teacher(string address) : base(address)
    {
        
    }
}

class Employee : Person
{
    public Employee(string address) : base(address)
    {
        
    }
}

class Student : Person
{
    public Student(string address) : base(address)
    {
        
    }
}

class BusDriver : Person
{
    public BusDriver(string address) : base(address)
    {
        
    }
}

