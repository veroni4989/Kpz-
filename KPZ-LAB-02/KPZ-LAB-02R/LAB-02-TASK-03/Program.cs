using System;

public sealed class Authenticator
{
    private static readonly object padlock = new object();
    private static Authenticator instance = null;

    private Authenticator()
    {

    }

    public static Authenticator Instance
    {
        get
        {
            lock (padlock)
            {
                if (instance == null)
                {
                    instance = new Authenticator();
                }
                return instance;
            }
        }
    }

    public bool Authenticate(string username, string password)
    {
        return true;
    }
}

class Program
{
    static void Main()
    {
        Authenticator auth1 = Authenticator.Instance;
        Authenticator auth2 = Authenticator.Instance;

        Console.WriteLine("auth1 == auth2: " + (auth1 == auth2));

        string username = "user";
        string password = "password";
        bool isAuthenticated = Authenticator.Instance.Authenticate(username, password);
        Console.WriteLine("Is authenticated: " + isAuthenticated);

        Console.ReadLine();
    }
}
