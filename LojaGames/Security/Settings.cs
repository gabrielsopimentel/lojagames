namespace LojaGames.Security
{
    public class Settings
    {
        private static string secret = "b3e1c5fa8c39ba5570f7110cdf5eb2644c2c67acb5a7e9d2aedee3c03297c614";

        public static string Secret { get => secret; set => secret = value; }
    }
}
