using System;
using System.Linq;
using System.Collections.Generic;

namespace KinoKata
{
    public class Cashier
    {
        private readonly Movie movie;
        private readonly IList<int> ages;

        public Cashier(Movie movie)
        {
            this.movie = movie;
            this.ages = new List<int>();
        }

        public void AddTicket(int age)
        {
            if (age < 0)
                throw new ArgumentException("Age should not be negative", "age");

            this.ages.Add(age);
        }

        public decimal GetTotalPrice()
        {
            decimal result = 0;

            if(ages.Count >= 10)
            {
                int children = ages.Count(age => age < 15);
                int adults = ages.Count(age => age > 14);

                if(movie.OverLength)
                {
                    return children * 6.5m + adults*7m;
                }

                return children*5.5m + adults*6m;
            }

            result = ages.Sum(age => age <= 14 ? 5.5m : 8m);

            if(movie.OverLength)
            {
                result += ages.Count;
            }

            return result;
        }
    }
}
