using System.Xml.Linq;

namespace homework_Thread
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] toplam = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        // 1-chi thread: Elementlarni faylga yozish
        Thread thread1 = new Thread(() =>
        {
            using (StreamWriter writer = new StreamWriter("elements.txt"))
            {
                foreach (int element in toplam)
                {
                    writer.WriteLine(element);
                }
            }

            Console.WriteLine("Elementlar faylga yozildi.");
        });

            // 2-chi thread: Elementlarni ekranga chiqarish
            Thread thread2 = new Thread(() =>
            {
                Console.WriteLine("To'plamdagi elementlar:");
                foreach (int element in toplam)
                {
                    Console.WriteLine(element);
                }
            });

            // Threadlarni ishga tushiramiz
            thread1.Start();
            thread2.Start();

            // Threadlarning tugashini kuzatish
            thread1.Join();
            thread2.Join();

            Console.WriteLine("Dastur tugadi.");
        }
    }
}