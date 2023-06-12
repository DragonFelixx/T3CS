using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace T3CS
{
    internal class Train
    {
        public List<Wagon> wagons = new List<Wagon> ();


        public void LoadFromFile(string filePath)
        {
            wagons.Clear();
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] fields = line.Split(',');

                Wagon wagon = new Wagon();
                wagon.PassengerCount = int.Parse(fields[0]);
                wagon.LuggageCount = int.Parse(fields[1]);
                wagon.ComfortLevel = int.Parse(fields[2]);
                wagon.Number = int.Parse(fields[3]);

                wagons.Add(wagon);
            }
        }

        public int GetTotalPassangers()
        {
            int totalPassangers = 0;
            foreach (Wagon wagon in wagons)
            {
                totalPassangers += wagon.PassengerCount;
            }
            return totalPassangers;
        }

        public int GetTotalLuggage()
        {
            int totalLuggage = 0;
            foreach (Wagon wagon in wagons)
            {
                totalLuggage += wagon.LuggageCount;
            }
            return totalLuggage;
        }

        public void SortByComfort()
        {
            wagons.Sort((wagon1, wagon2) => wagon1.ComfortLevel.CompareTo(wagon2.ComfortLevel));
        }

        public List<Wagon> GetWagonsByPassengerCountRange(int minPassanger, int maxPassanger)
        {
            List<Wagon> matchingWagons = new List<Wagon>();
            foreach (Wagon wagon in wagons)
            {
                if (wagon.PassengerCount >= minPassanger && wagon.PassengerCount <= maxPassanger)
                {
                    matchingWagons.Add(wagon);
                }
            }
            return matchingWagons;
        }

        

        
    }
}
