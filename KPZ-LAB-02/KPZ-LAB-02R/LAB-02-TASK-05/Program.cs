using System;
using System.Collections.Generic;

class Character
{
    public string Name { get; set; }
    public int Height { get; set; }
    public string Build { get; set; }
    public string HairColor { get; set; }
    public string EyeColor { get; set; }
    public string Clothing { get; set; }
    public List<string> Inventory { get; set; }
    public List<string> Actions { get; set; }

    public override string ToString()
    {
        return $"Name: {Name}, Height: {Height}, Build: {Build}, Hair Color: {HairColor}, Eye Color: {EyeColor}, Clothing: {Clothing}, Inventory: {string.Join(", ", Inventory)}, Actions: {string.Join(", ", Actions)}"; // Updated to include actions
    }
}

interface ICharacterBuilder
{
    ICharacterBuilder SetName(string name);
    ICharacterBuilder SetHeight(int height);
    ICharacterBuilder SetBuild(string build);
    ICharacterBuilder SetHairColor(string hairColor);
    ICharacterBuilder SetEyeColor(string eyeColor);
    ICharacterBuilder SetClothing(string clothing);
    ICharacterBuilder AddToInventory(string item);
    ICharacterBuilder SetActions(List<string> actions);
    Character Build();
}

class HeroBuilder : ICharacterBuilder
{
    private Character character = new Character();

    public ICharacterBuilder SetName(string name)
    {
        character.Name = name;
        return this;
    }

    public ICharacterBuilder SetHeight(int height)
    {
        character.Height = height;
        return this;
    }

    public ICharacterBuilder SetBuild(string build)
    {
        character.Build = build;
        return this;
    }

    public ICharacterBuilder SetHairColor(string hairColor)
    {
        character.HairColor = hairColor;
        return this;
    }

    public ICharacterBuilder SetEyeColor(string eyeColor)
    {
        character.EyeColor = eyeColor;
        return this;
    }

    public ICharacterBuilder SetClothing(string clothing)
    {
        character.Clothing = clothing;
        return this;
    }

    public ICharacterBuilder AddToInventory(string item)
    {
        if (character.Inventory == null)
            character.Inventory = new List<string>();

        character.Inventory.Add(item);
        return this;
    }

    public ICharacterBuilder SetActions(List<string> actions)
    {
        character.Actions = actions;
        return this;
    }

    public Character Build()
    {
        return character;
    }
}

class EnemyBuilder : ICharacterBuilder
{
    private Character character = new Character();

    public ICharacterBuilder SetName(string name)
    {
        character.Name = name;
        return this;
    }

    public ICharacterBuilder SetHeight(int height)
    {
        character.Height = height;
        return this;
    }

    public ICharacterBuilder SetBuild(string build)
    {
        character.Build = build;
        return this;
    }

    public ICharacterBuilder SetHairColor(string hairColor)
    {
        character.HairColor = hairColor;
        return this;
    }

    public ICharacterBuilder SetEyeColor(string eyeColor)
    {
        character.EyeColor = eyeColor;
        return this;
    }

    public ICharacterBuilder SetClothing(string clothing)
    {
        character.Clothing = clothing;
        return this;
    }

    public ICharacterBuilder AddToInventory(string item)
    {
        if (character.Inventory == null)
            character.Inventory = new List<string>();

        character.Inventory.Add(item);
        return this;
    }

    public ICharacterBuilder SetActions(List<string> actions)
    {
        character.Actions = actions;
        return this;
    }

    public Character Build()
    {
        return character;
    }
}

class Program
{
    static Character hero = null;
    static Character enemy = null;

    static void Main(string[] args)
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Create a hero");
            Console.WriteLine("2. Edit hero");
            Console.WriteLine("3. Delete hero");
            Console.WriteLine("4. Create enemy");
            Console.WriteLine("5. Edit enemy");
            Console.WriteLine("6. Delete enemy");
            Console.WriteLine("7. View hero");
            Console.WriteLine("8. View enemy");
            Console.WriteLine("9. Quit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    if (hero == null)
                        CreateHero();
                    else
                        Console.WriteLine("The hero has already been created.");
                    break;
                case "2":
                    EditHero();
                    break;
                case "3":
                    DeleteHero();
                    break;
                case "4":
                    if (enemy == null)
                        CreateEnemy();
                    else
                        Console.WriteLine("The enemy has already been created.");
                    break;
                case "5":
                    EditEnemy();
                    break;
                case "6":
                    DeleteEnemy();
                    break;
                case "7":
                    ViewHero();
                    break;
                case "8":
                    ViewEnemy();
                    break;
                case "9":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Wrong choice, try again.");
                    break;
            }
        }
    }

    static void CreateHero()
    {
        CreateCharacter(new HeroBuilder());
    }
    static void EditHero()
    {
        if (hero != null)
        {
            EditCharacter(hero);
        }
        else
        {
            Console.WriteLine("Hero not found.");
        }
    }
    static void DeleteHero()
    {
        if (hero != null)
        {
            hero = null;
            Console.WriteLine("Hero deleted successfully.");
        }
        else
        {
            Console.WriteLine("Hero not found.");
        }
    }

    static void CreateEnemy()
    {
        CreateCharacter(new EnemyBuilder());
    }
    static void EditEnemy()
    {
        if (enemy != null)
        {
            EditCharacter(enemy);
        }
        else
        {
            Console.WriteLine("Enemy not found.");
        }
    }
    static void DeleteEnemy()
    {
        if (enemy != null)
        {
            enemy = null;
            Console.WriteLine("Enemy deleted successfully.");
        }
        else
        {
            Console.WriteLine("Enemy not found.");
        }
    }

    static void ViewHero()
    {
        if (hero != null)
        {
            Console.WriteLine("Hero:");
            Console.WriteLine(hero);
        }
        else
        {
            Console.WriteLine("Hero has not been created yet.");
        }
    }
    static void ViewEnemy()
    {
        if (enemy != null)
        {
            Console.WriteLine("Enemy:");
            Console.WriteLine(enemy);
        }
        else
        {
            Console.WriteLine("Enemy has not been created yet.");
        }
    }

    static void EditCharacter(Character character)
    {
        Console.WriteLine($"Editing characteristics of character {character.Name}.");

        Console.WriteLine("Select a characteristic to edit:");
        Console.WriteLine("1. Height");
        Console.WriteLine("2. Statura");
        Console.WriteLine("3. Hair color");
        Console.WriteLine("4. Eye color");
        Console.WriteLine("5. Clothes");
        Console.WriteLine("6. Inventory");
        Console.WriteLine("7. Actions");

        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                int height = 0;
                bool validHeight = false;
                while (!validHeight)
                {
                    Console.WriteLine("Enter new height:");
                    if (int.TryParse(Console.ReadLine(), out height))
                    {
                        character.Height = height;
                        Console.WriteLine("Growth edited successfully.");
                        validHeight = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a number.");
                    }
                }
                break;
            case "2":
                Console.WriteLine("Enter new status:");
                string build = Console.ReadLine();
                character.Build = build;
                Console.WriteLine("Status successfully edited.");
                break;
            case "3":
                Console.WriteLine("Enter new hair color:");
                string hairColor = Console.ReadLine();
                character.HairColor = hairColor;
                Console.WriteLine("Hair color edited successfully.");
                break;
            case "4":
                Console.WriteLine("Enter new eye color:");
                string eyeColor = Console.ReadLine();
                character.EyeColor = eyeColor;
                Console.WriteLine("Eye color edited successfully.");
                break;
            case "5":
                Console.WriteLine("Enter new clothes:");
                string clothing = Console.ReadLine();
                character.Clothing = clothing;
                Console.WriteLine("Clothes edited successfully.");
                break;
            case "6":
                Console.WriteLine("Editing inventory:");
                Console.WriteLine("Enter item to add or remove ('done' to complete):");
                string item = Console.ReadLine();
                while (item != "done")
                {
                    if (character.Inventory.Contains(item))
                    {
                        character.Inventory.Remove(item);
                        Console.WriteLine($"Item '{item}' has been removed from inventory.");
                    }
                    else
                    {
                        character.Inventory.Add(item);
                        Console.WriteLine($"Item '{item}' has been added to inventory.");
                    }
                    item = Console.ReadLine();
                }
                break;
            case "7":
                Console.WriteLine("Editing actions:");
                Console.WriteLine("Enter action to add or remove ('done' to complete):");
                string action = Console.ReadLine();
                while (action != "done")
                {
                    if (character.Actions.Contains(action))
                    {
                        character.Actions.Remove(action);
                        Console.WriteLine($"Action '{action}' has been removed.");
                    }
                    else
                    {
                        character.Actions.Add(action);
                        Console.WriteLine($"Action '{action}' has been added.");
                    }
                    action = Console.ReadLine();
                }
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }

    static void CreateCharacter(ICharacterBuilder characterBuilder)
    {
        Console.Write("Enter character name: ");
        string name = Console.ReadLine();
        characterBuilder.SetName(name);

        int height = 0;
        bool validHeight = false;
        while (!validHeight)
        {
            Console.Write("Enter character height: ");
            if (int.TryParse(Console.ReadLine(), out height))
            {
                validHeight = true;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
        characterBuilder.SetHeight(height);

        Console.Write("Enter character status: ");
        string build = Console.ReadLine();
        characterBuilder.SetBuild(build);

        Console.Write("Enter character's hair color: ");
        string hairColor = Console.ReadLine();
        characterBuilder.SetHairColor(hairColor);

        Console.Write("Enter character's eye color: ");
        string eyeColor = Console.ReadLine();
        characterBuilder.SetEyeColor(eyeColor);

        Console.Write("Enter character's clothing: ");
        string clothing = Console.ReadLine();
        characterBuilder.SetClothing(clothing);

        Console.WriteLine("Add items to character's inventory (type 'done' to complete):");
        string item;
        while ((item = Console.ReadLine()) != "done")
        {
            characterBuilder.AddToInventory(item);
        }

        Console.WriteLine("Add actions of the character (type 'done' to complete):");
        string action;
        List<string> actions = new List<string>();
        while ((action = Console.ReadLine()) != "done")
        {
            actions.Add(action);
        }
        characterBuilder.SetActions(actions);

        Character character = characterBuilder.Build();

        if (characterBuilder is HeroBuilder)
        {
            hero = character;
            Console.WriteLine("Hero created successfully.");
        }
        else if (characterBuilder is EnemyBuilder)
        {
            enemy = character;
            Console.WriteLine("Enemy created successfully.");
        }
    }

}
