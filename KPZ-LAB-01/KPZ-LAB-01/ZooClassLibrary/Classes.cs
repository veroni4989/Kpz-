using System.Collections.Generic;

namespace ZooClassLibrary
{
    public class Animal
    {
        public string Species { get; set; }
        public string Subspecies { get; set; }
        public int Age { get; set; }
    }
    public class Enclosure
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public double Area { get; set; }
        public List<Animal> Animals { get; set; } = new List<Animal>();
    }
    public class Employee
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Position { get; set; }
    }
    public class Food
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
    public class Zoo
    {
        public List<Food> Foods { get; set; }
        public List<Animal> Animals { get; set; }
        public List<Enclosure> Enclosures { get; set; }
        public List<Employee> Employees { get; set; }

        public Zoo()
        {
            Foods = new List<Food>();
            Animals = new List<Animal>();
            Enclosures = new List<Enclosure>();
            Employees = new List<Employee>();
        }
    }
}
