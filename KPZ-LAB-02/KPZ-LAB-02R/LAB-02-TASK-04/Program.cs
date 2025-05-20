using System;
using System.Collections.Generic;
using System.Text;

class Virus : ICloneable
{
    public double Weight { get; private set; }
    public int Age { get; private set; }
    public string Name { get; private set; }
    public string Species { get; private set; }
    public List<Virus> Children { get; private set; }

    public Virus(double weight, int age, string name, string species)
    {
        Weight = weight;
        Age = age;
        Name = name;
        Species = species;
        Children = new List<Virus>();
    }

    public void AddChild(Virus child)
    {
        Children.Add(child);
    }

    public object Clone()
    {
        Virus clone = (Virus)this.MemberwiseClone();
        clone.Children = new List<Virus>();
        foreach (var child in Children)
        {
            clone.AddChild((Virus)child.Clone());
        }
        return clone;
    }

    public void Display(int depth)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(new string('-', depth));
        sb.Append($" {Name} ({Species}), Weight: {Weight}kg, Age: {Age} years");
        Console.WriteLine(sb.ToString());
        foreach (var child in Children)
        {
            child.Display(depth + 2);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Virus parent = null;

        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1) Create a new virus family");
            Console.WriteLine("2) Perform cloning");
            Console.WriteLine("3) View entire family");
            Console.WriteLine("4) Clear family");
            Console.WriteLine("5) Quit");

            Console.Write("Select option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    parent = CreateVirusFamily();
                    Console.WriteLine("A new virus family has been created.");
                    break;

                case "2":
                    if (parent == null)
                    {
                        Console.WriteLine("Create a virus family first.");
                        break;
                    }

                    Virus parentClone = (Virus)parent.Clone();
                    parent.AddChild(parentClone);
                    Console.WriteLine("Clone was successful.");
                    break;

                case "3":
                    if (parent == null)
                    {
                        Console.WriteLine("Create a virus family first.");
                        break;
                    }

                    Console.WriteLine("\nVirus family:");
                    parent.Display(0);
                    break;

                case "4":
                    parent = null;
                    Console.WriteLine("Virus family cleared.");
                    break;

                case "5":
                    Console.WriteLine("The program has ended.");
                    return;

                default:
                    Console.WriteLine("Invalid input. Try again.");
                    break;
            }
        }
    }

    static Virus CreateVirusFamily()
    {
        Console.Write("Enter parent name: ");
        string parentName = Console.ReadLine();
        Console.Write("Enter the type of virus: ");
        string parentSpecies = Console.ReadLine();
        Console.Write("Enter the weight of the virus: ");
        double parentWeight;
        while (!double.TryParse(Console.ReadLine(), out parentWeight))
        {
            Console.WriteLine("Invalid input. Enter a valid weight:");
        }
        Console.Write("Enter the age of the virus: ");
        int parentAge;
        while (!int.TryParse(Console.ReadLine(), out parentAge))
        {
            Console.WriteLine("Invalid input. Enter a valid age:");
        }

        return new Virus(parentWeight, parentAge, parentName, parentSpecies);
    }
}
