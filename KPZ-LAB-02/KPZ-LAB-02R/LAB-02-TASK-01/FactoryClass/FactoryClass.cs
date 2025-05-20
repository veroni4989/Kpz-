using SubscriptionsClass;
using System;
using System.Text.RegularExpressions;

namespace FactoryClass
{
    public abstract class SubscriptionFactory
    {
        public abstract Subscription CreateSubscription();
    }

    public class WebSiteFactory : SubscriptionFactory
    {
        public override Subscription CreateSubscription()
        {
            string email = "";
            while (!IsValidEmail(email))
            {
                Console.WriteLine("Введіть ваш email: ");
                email = Console.ReadLine();
                if (!IsValidEmail(email))
                    Console.WriteLine("Некоректний формат email. Будь ласка, повторіть введення.");
            }

            string password = "";
            while (!IsValidPassword(password))
            {
                Console.WriteLine("Введіть пароль: ");
                password = Console.ReadLine();
                if (!IsValidPassword(password))
                    Console.WriteLine("Пароль повинен мати принаймні 8 символів та містити принаймні одну цифру, одну велику та одну маленьку літеру.");
            }

            return new DomesticSubscription();
        }

        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private bool IsValidPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password) || password.Length < 8)
                return false;

            bool hasDigit = false;
            bool hasUpper = false;
            bool hasLower = false;
            foreach (char c in password)
            {
                if (char.IsDigit(c))
                    hasDigit = true;
                else if (char.IsUpper(c))
                    hasUpper = true;
                else if (char.IsLower(c))
                    hasLower = true;
            }

            return hasDigit && hasUpper && hasLower;
        }
    }

    public class MobileAppFactory : SubscriptionFactory
    {
        public override Subscription CreateSubscription()
        {
            string phoneNumber = "";
            while (!IsValidPhoneNumber(phoneNumber))
            {
                Console.WriteLine("Введіть ваш номер телефону: ");
                phoneNumber = Console.ReadLine();
                if (!IsValidPhoneNumber(phoneNumber))
                    Console.WriteLine("Некорректний формат номера телефона. Повторіть спробу.");
            }

            string password = "";
            while (!IsValidPassword(password))
            {
                Console.WriteLine("Введіть пароль: ");
                password = Console.ReadLine();
                if (!IsValidPassword(password))
                    Console.WriteLine("Пароль повинен містити мінімум 6 символів. Повторіть спробу.");
            }

            return new EducationalSubscription();
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            return !string.IsNullOrWhiteSpace(phoneNumber) && phoneNumber.Length == 10 && long.TryParse(phoneNumber, out _);
        }

        private bool IsValidPassword(string password)
        {
            return !string.IsNullOrWhiteSpace(password) && password.Length >= 6;
        }
    }

    public class ManagerCallFactory : SubscriptionFactory
    {
        public override Subscription CreateSubscription()
        {
            Console.WriteLine("Введіть ваше ім'я та прізвище: ");
            string name = Console.ReadLine();

            while (ContainsDigits(name))
            {
                Console.WriteLine("Ім'я не повинне мати цифри. Введіть правильний формат імені");
                name = Console.ReadLine();
            }

            Console.WriteLine("Введіть пароль: ");
            string password = Console.ReadLine();

            while (!ContainsDigits(password))
            {
                Console.WriteLine("Пароль должен содержать хотя бы одну цифру. Пожалуйста, введите корректный пароль:");
                password = Console.ReadLine();
            }

            return new PremiumSubscription();
        }

        private bool ContainsDigits(string input)
        {
            return Regex.IsMatch(input, @"\d");
        }
    }
}