using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rocks
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0; 
            int max = 0; 
            int half = 0; 
            int k = 0; 

            Console.WriteLine("Какое количество камней нужно распределить в две максимально одинаковые кучи:");
            int num = Convert.ToInt32(Console.ReadLine());
            while (num > 23 || num < 2) //проверка колличества камней
            {
                Console.WriteLine("Введите число в диапазоне от 2 до 23]:");
                num = 0;
                num = Convert.ToInt32(Console.ReadLine());
            }

            int[] arr = new int[num];

            // Забиваем массив
            for (int i = 0; i < num; i++)
            {
                Console.WriteLine("Какой вес камня №{0}?", i + 1); //вес каждого камня и заполнение общей кучи
                int a = Convert.ToInt32(Console.ReadLine());
                arr[i] = a;
            }
            Array.Sort(arr); // сортируем по возрастанию
            max = arr[arr.Length - 1];
            // суммируем элементы массива
            for (int i = 0; i < num; i++)
            {
                sum += arr[i];
            }
            // узнаем "идеальные кучки"
            half = sum / 2;
            // сам алгоритм. Похож на Шеннона-Фано
            if (max <= half)
            {
                for (int i = arr.Length - 2; i >= 0; i--)
                {
                    if (max + arr[i] <= half) { max += arr[i]; }
                }
                k = sum - max;
                Console.WriteLine("Минимальная разность весов двух куч:");
                Console.WriteLine(k - max);
            }
            else
            {
                k = sum - max;
                Console.WriteLine("Минимальная разность весов двух куч:");
                Console.WriteLine(max - k);
            }
        }
    }
}