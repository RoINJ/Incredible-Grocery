public class Constants
{
    public const int BUYER_ANIMATION_DURATION = 3;

    public static class Delays
    {
        public const int NEW_ORDER_CLOUD_DELAY = 5000;
        public const int ORDER_CONFIRMATION_CLOUD_DELAY = 1000;
        public const int CHECK_ORDER_CLOUD_DELAY = 500;
    }

    public static class Tags
    {
        public const string Buyer = nameof(Buyer);
        public const string GameController = nameof(GameController);
        public const string BuyerFinalPosition = nameof(BuyerFinalPosition);
    }
}