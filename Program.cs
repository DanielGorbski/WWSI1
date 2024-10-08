using System;
using System.Text;

namespace SingletonVault
{
    public class Vault
    {
        private string key;
        private bool isKeyUsed = false;
        private static Vault _instance = null;

        private Vault()
        {
            key = GenerateRandomKey(16); 
        }

        public static Vault GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Vault();
            }
            return _instance;
        }

        public string GetKey()
        {
            if (!isKeyUsed)
            {
                isKeyUsed = true;
                return key;
            }
            else
            {
                return "Klucz został już użyty!";
            }
        }

        private string GenerateRandomKey(int size)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            StringBuilder result = new StringBuilder(size);
            Random random = new Random();

            for (int i = 0; i < size; i++)
            {
                result.Append(chars[random.Next(chars.Length)]);
            }

            return result.ToString();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Vault vault1 = Vault.GetInstance();

            Console.WriteLine("Próba pobrania klucza z vault1: " + vault1.GetKey());

            Console.WriteLine("Ponowna próba pobrania klucza z vault1: " + vault1.GetKey());

            Vault vault2 = Vault.GetInstance();
            Console.WriteLine("Próba pobrania klucza z vault2: " + vault2.GetKey());

            Console.ReadLine();
        }
    }
}
