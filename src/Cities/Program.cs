using System;
using System.Collections.Generic;
using Cities.Comparers;

namespace Cities
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<City> cities = CityDataImporter.LoadData();

            // TODO Swap out comparers as desired
            IComparer<City> nameComparer = new NameComparer();
            IComparer<City> stateComparer = new StateComparer();
            IComparer<City> areaComparer = new AreaComparer();
            IComparer<City> populationComparer = new PopulationComparer();

            CompoundComparer compoundComparer = new CompoundComparer();
            compoundComparer.Comparers.Add(new StateComparer());
            compoundComparer.Comparers.Add(new PopulationComparer());

            cities.Sort(compoundComparer);

            PrintCities(cities);

            Console.ReadLine();
        }

        private static void PrintCities(List<City> cities)
        {
            Console.WriteLine(City.GetTableHeader());

            foreach (var city in cities)
            {
                Console.WriteLine(city);
            }

        }
    }
}
