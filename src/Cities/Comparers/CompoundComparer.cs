using System;
using System.Collections.Generic;
using System.Text;

namespace Cities.Comparers
{
    class CompoundComparer : IComparer<City>
    {
        public IList<IComparer<City>> Comparers { get; set; } = new List<IComparer<City>>();
        public int Compare(City x, City y)
        {
            //foreach (IComparer<City> comparer in Comparers)
            //{
            //    while (comparer.Compare(x, y) != 0)
            //    {
            //        return comparer.Compare(x, y);
            //    }
            //}
            //return 0;

            foreach (IComparer<City> comparer in Comparers)
            {
                if (comparer.Compare(x, y) != 0)
                {
                    return comparer.Compare(x, y);
                }
            }
            return 0;
        }
    }
}
