using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKZ_06
{
    static class Xor
    {
        static private string alf = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя 0123456789";
        static private int k, x, z;
        static private string res;

        static public string Encryption(string source, string key)
        {
            res = string.Empty;

            while (key.Length < source.Length)
            {
                key += key;
                if (key.Length > source.Length) key = key.Remove(source.Length);
            }
            for (int i = 0; i < source.Length; i++)
            {
                for (int id = 0; id < alf.Length; id++)
                {
                    if (key[i] == alf[id]) k = id;
                    if (source[i] == alf[id]) x = id;
                    z = (x + k) % alf.Length;
                }
                res += alf[z];
            }
            return res;
        }

        static public string Decryption(string source, string key)
        {
            res = string.Empty;

            while (key.Length < source.Length)
            {
                key += key;
                if (key.Length > source.Length) key = key.Remove(source.Length);
            }
            for (int i = 0; i < source.Length; i++)
            {
                for (int id = 0; id < alf.Length; id++)
                {
                    if (key[i] == alf[id]) k = id;
                    if (source[i] == alf[id]) x = id;
                    z = ((source[i] - key[i]) + alf.Length) % alf.Length;
                }
                res += alf[z];
            }
            return res;
        }
    }

    public partial class Analit
    { 
        public static void Encryption(string text)
        {

            int ch, a = 0;
            string[] mas1 = new string[32] { "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п", "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ь", "ы", "ъ", "э", "ю", "я" };
            int[] mas2 = new int[32]       {  1,   2,   3,   4,   5,   6,   7,   8,   9,  10,  11,  12,  13,  14,  15,  16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32 };
             
            string str1 = new string(' ', 0);
            string str2 = new string(' ', 0);
            str1 = text;
            ch = 3;
            int[,] mas3 = new int[ch, ch];
            int[] kod = new int[ch];
            int[] vyv = new int[ch];
            Random rnd = new Random();
            
                // заполняем массив двумерный
                for (int i = 0; i < ch; i++)
                {
                    for (int j = 0; j < ch; j++)
                    {
                        mas3[i, j] = rnd.Next(0, 9);
                    }
                }
                // записываем текст в числа
                for (int q = 0; q < ch; q++)
                {
                    for (int z = 0; z < 32; z++)
                    {
                        if (str1[q].ToString() == mas1[z])
                        {
                            kod[q] = mas2[z];

                        }
                    }
                }
                // кодируем 
                for (int z = 0; z < ch; z++)
                {
                    for (int x = 0; x < ch; x++)
                    {
                        a = a + mas3[x, z] * kod[z];
                    }
                    vyv[z] = a;
                }
            string temp1 = "", temp2, temp3 = "";
                // выводим на экран закодировонное сообщение
                foreach (int d in vyv)
                {
                    temp1 += (d.ToString() + "  ");
                }
                for (int c = 0; c < ch; c++)
                {
                    str2 = str2 + kod[c];
                }
                temp2 = str2;
                foreach (int d in mas3)
                {
                    temp3 += (d.ToString() + "  ");
                }

            Console.WriteLine($"Зашифроване  повідомлення:{temp1}");
            Console.WriteLine($"Розшифроване повідомлення:{text}");


        }
    }

    

    class Program
    {
        static void Main(string[] args)
        {
            int vb = Convert.ToInt32(Console.ReadLine());


            if (vb == 1)
            {
                string text, key = "сба";
                Console.Write("Введіть повідомлення:");
                text = Console.ReadLine();
                Console.WriteLine($"Зашифроване повідомлення:{Xor.Encryption(text, key)}\nРозшифроване повідомлення:{text}");
                Console.ReadKey();
            }

            else if (vb == 2)
            {
                string text;
                Console.Write("Введіть повідомлення:");
                text = Console.ReadLine();
                Analit.Encryption(text);
                Console.ReadKey();
            }

            else if (vb == 3)
            {


            }
        }
    }
}
