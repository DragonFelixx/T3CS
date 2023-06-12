using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3CS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Train train = new Train();
            string filePath = @"C:\\Users\\wyvern\\source\\repos\\T3CS\\T3CS\\Trains.txt";
            //string fliePath = Console.ReadLine();
            train.LoadFromFile(filePath);

            int totalPassangers = train.GetTotalPassangers();
            int totalLuggage = train.GetTotalLuggage();

            Console.WriteLine($"Общее кол-во пассажиров: {totalPassangers}");
            Console.WriteLine($"Общее кол-во багажа: {totalLuggage}");

            Console.WriteLine("Информация о вагонах, отсортированная по классу комфорта:");
            train.SortByComfort();
            foreach (Wagon wag in train.wagons)
            {
                Console.WriteLine($"Номер вагона:{wag.Number} = Пассажиров: {wag.PassengerCount}, багажа: {wag.LuggageCount} , уровень комфорта: {wag.ComfortLevel}");
            }

            Console.WriteLine("Введите минимальное кол-во пассажиров диапазона:");
            int minPassangerCount = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите максимальное кол-во пассажиров диапазона:");
            int maxPassangerCount = int.Parse(Console.ReadLine());

            Console.WriteLine("Вагоны, колличествво пасажиров которых укладываются в заданный диапазон: ");
            List<Wagon> matchingWagons = train.GetWagonsByPassengerCountRange(minPassangerCount, maxPassangerCount);
            foreach (Wagon wagon in matchingWagons)
            {
                Console.WriteLine($"Номер вагона:{wagon.Number} = Пассажиров: {wagon.PassengerCount}, уровень комфорта: {wagon.ComfortLevel}");
            }
            Console.ReadLine();
        }
    }
}
