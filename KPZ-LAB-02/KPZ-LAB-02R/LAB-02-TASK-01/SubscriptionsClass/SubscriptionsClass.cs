namespace SubscriptionsClass
{
    public abstract class Subscription
    {
        public abstract override string ToString();
    }

    public class DomesticSubscription : Subscription
    {
        public override string ToString()
        {
            return "У вас підписа типу Домашня";
        }
    }

    public class EducationalSubscription : Subscription
    {
        public override string ToString()
        {
            return "У вас підписа типу Студентська";
        }
    }

    public class PremiumSubscription : Subscription
    {
        public override string ToString()
        {
            return "У вас підписа типу Преміум";
        }
    }
}
