using System;
using System.Collections.Generic;
using System.Text;
using SubscriptionsClass;
using FactoryClass;

namespace Main
{
    class Program
    {
        static List<Subscription> subscriptions = new List<Subscription>();

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Меню:");
                Console.WriteLine("1. Додати передплату");
                Console.WriteLine("2. Скасувати підписку");
                Console.WriteLine("3. Переглянути передплати");
                Console.WriteLine("4. Вийти");
                Console.Write("Виберіть дію:");

                string choice = Console.ReadLine();
                Console.Clear();

                switch (choice)
                {
                    case "1":
                        AddSubscription();
                        break;
                    case "2":
                        CancelSubscription();
                        break;
                    case "3":
                        ViewSubscriptions();
                        break;
                    case "4":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Неправильне введення. Спробуйте знову.");
                        break;
                }
                Console.WriteLine("Натисніть будь-яку клавішу для продовження...");
                Console.ReadKey();
            }
        }

        static void AddSubscription()
        {
            Console.WriteLine("Виберіть спосіб реєстрації:");
            Console.WriteLine("1. WebSite");
            Console.WriteLine("2. MobileApp");
            Console.WriteLine("3. ManagerCall");
            Console.Write("Ваш вибір: ");

            string choice = Console.ReadLine();
            Console.Clear();

            SubscriptionFactory factory = null;

            switch (choice)
            {
                case "1":
                    factory = new WebSiteFactory();
                    break;
                case "2":
                    factory = new MobileAppFactory();
                    break;
                case "3":
                    factory = new ManagerCallFactory();
                    break;
                default:
                    Console.WriteLine("Неправильне введення");
                    return;
            }

            Subscription subscription = factory.CreateSubscription();
            if (subscriptions.Exists(sub => sub.GetType() == subscription.GetType()))
            {
                Console.WriteLine("Підписка цього типу вже існує");
                return;
            }

            subscriptions.Add(subscription);
            Console.WriteLine("Підписка успішно додана");
        }

        static void CancelSubscription()
        {
            Console.WriteLine("Виберіть передплату для скасування:");

            for (int i = 0; i < subscriptions.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {subscriptions[i]}");
            }

            Console.Write("Введіть номер передплати для скасування: ");
            int index;
            if (!int.TryParse(Console.ReadLine(), out index) || index < 1 || index > subscriptions.Count)
            {
                Console.WriteLine("Невірний номер передплати.");
                return;
            }

            subscriptions.RemoveAt(index - 1);
            Console.WriteLine("Підписка успішно скасована");
        }

        static void ViewSubscriptions()
        {
            Console.WriteLine("Ваші підписки:");
            if (subscriptions.Count == 0)
            {
                Console.WriteLine("У вас немає активних підписок");
            }
            else
            {
                foreach (var subscription in subscriptions)
                {
                    Console.WriteLine(subscription);
                }
            }
        }
    }
}
