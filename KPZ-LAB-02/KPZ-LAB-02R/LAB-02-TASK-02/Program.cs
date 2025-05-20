using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TechFactory
{
    public interface IDeviceFactory
    {
        IDevice CreateDevice();
    }

    public interface IDevice
    {
        string Brand { get; }
        string Model { get; }
        string Processor { get; }
        string Screen { get; }
        string ID { get; }
    }
    public class Phone : IDevice
    {
        public string Brand { get; }
        public string Model { get; }
        public string Processor { get; }
        public string Screen { get; }
        public string ID { get; }

        public Phone(string brand, string model, string processor, string screen, string id)
        {
            Brand = brand;
            Model = model;
            Processor = processor;
            Screen = screen;
            ID = id;
        }
    }

    public class PhoneFactory : IDeviceFactory
    {
        public IDevice CreateDevice()
        {
            Console.Clear();
            Console.WriteLine("Creating a new phone...");

            string brand = GetValidInput("Enter brand: ", @"^[A-Za-z0-9\s]+$");
            string model = GetValidInput("Enter model (format: X-4567): ", @"^[A-Za-z]-\d{4}$");
            string processor = GetValidInput("Enter processor model (format: X-4567): ", @"^[A-Za-z]-\d{4}$");
            string screen = GetValidInput("Enter screen model (format: X-4567): ", @"^[A-Za-z]-\d{4}$");
            string id = GetValidInput("Enter ID (6 digits): ", @"^\d{6}$");

            return new Phone(brand, model, processor, screen, id);
        }

        private string GetValidInput(string prompt, string pattern)
        {
            string input;
            Regex regex = new Regex(pattern);
            do
            {
                Console.Write(prompt);
                input = Console.ReadLine();
                if (!regex.IsMatch(input))
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }
            } while (!regex.IsMatch(input));

            return input;
        }
    }

    public class Laptop : IDevice
    {
        public string Brand { get; }
        public string Model { get; }
        public string Processor { get; }
        public string Screen { get; }
        public string ID { get; }

        public Laptop(string brand, string model, string processor, string screen, string id)
        {
            Brand = brand;
            Model = model;
            Processor = processor;
            Screen = screen;
            ID = id;
        }
    }

    public class LaptopFactory : IDeviceFactory
    {
        public IDevice CreateDevice()
        {
            Console.Clear();
            Console.WriteLine("Creating a new laptop...");

            string brand = GetValidInput("Enter brand: ", @"^[A-Za-z0-9\s]+$");
            string model = GetValidInput("Enter model (format: X-4567): ", @"^[A-Za-z]-\d{4}$");
            string processor = GetValidInput("Enter processor model (format: X-4567): ", @"^[A-Za-z]-\d{4}$");
            string screen = GetValidInput("Enter screen model (format: X-4567): ", @"^[A-Za-z]-\d{4}$");
            string id = GetValidInput("Enter ID (6 digits): ", @"^\d{6}$");

            return new Laptop(brand, model, processor, screen, id);
        }

        private string GetValidInput(string prompt, string pattern)
        {
            string input;
            Regex regex = new Regex(pattern);
            do
            {
                Console.Write(prompt);
                input = Console.ReadLine();
                if (!regex.IsMatch(input))
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }
            } while (!regex.IsMatch(input));

            return input;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var phoneFactory = new PhoneFactory();
            var laptopFactory = new LaptopFactory();

            var devices = new List<IDevice>();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Select an option:");
                Console.WriteLine("1) Create new device");
                Console.WriteLine("2) View all devices");
                Console.WriteLine("3) Dispose of a device");
                Console.WriteLine("4) Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Select device type:");
                        Console.WriteLine("1) Phone");
                        Console.WriteLine("2) Laptop");
                        string deviceChoice = Console.ReadLine();
                        IDeviceFactory factory;
                        if (deviceChoice == "1")
                            factory = phoneFactory;
                        else if (deviceChoice == "2")
                            factory = laptopFactory;
                        else
                            continue;

                        var newDevice = factory.CreateDevice();
                        devices.Add(newDevice);
                        Console.WriteLine("Device created successfully!");
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Select device type to view:");
                        Console.WriteLine("1) Phone");
                        Console.WriteLine("2) Laptop");
                        string viewType = Console.ReadLine();
                        List<IDevice> devicesToView = new List<IDevice>();
                        if (viewType == "1")
                            devicesToView.AddRange(devices.FindAll(d => d.GetType() == typeof(Phone)));
                        else if (viewType == "2")
                            devicesToView.AddRange(devices.FindAll(d => d.GetType() == typeof(Laptop)));
                        else
                            continue;

                        Console.WriteLine("All devices:");
                        foreach (var device in devicesToView)
                        {
                            Console.WriteLine($"Brand: {device.Brand}, Model: {device.Model}, Processor: {device.Processor}, Screen: {device.Screen}, ID: {device.ID}");
                        }
                        Console.ReadKey();
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("Enter the ID of the device to dispose:");
                        string id = Console.ReadLine();
                        var deviceToRemove = devices.Find(d => d.ID == id);
                        if (deviceToRemove != null)
                        {
                            devices.Remove(deviceToRemove);
                            Console.WriteLine("Device disposed successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Device with the specified ID not found!");
                        }
                        Console.ReadKey();
                        break;
                    case "4":
                        Console.WriteLine("Exiting program...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
