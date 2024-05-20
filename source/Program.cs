using System;
using System.Collections.Generic;

namespace Encryptor
{
    class Program
    {
        static void Main(string[] args)
        {
            string punctuation = ".,!?;:'\"-–—()[]{}…/\\&*@#$%^_~|<>";
            string digits = "1234567890";
            string ascii_letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            string chars = punctuation + digits + ascii_letters;

            List<char> charList = new List<char>(chars);
            List<char> keyList = new List<char>(chars);

            Shuffle(keyList);

            // ENCRYPT
            Console.WriteLine("Enter the plain text:");
            string plain_text = Console.ReadLine();
            string cipher_text = "";

            foreach (char i in plain_text)
            {
                int index = chars.IndexOf(i);
                if (index != -1) // Check if the character is found in chars
                {
                    cipher_text += keyList[index];
                }
                else
                {
                    // Handle characters not found in chars
                    cipher_text += i;
                }
            }

            Console.WriteLine("Original: " + plain_text);
            Console.WriteLine("Cipher: " + cipher_text);
        }

        static void Shuffle<T>(List<T> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
