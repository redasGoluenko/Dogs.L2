using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dogs
{
    /// <summary>
    /// stores information of vaccinated dogs
    /// </summary>
    class Vaccination
    {
        public int DogID { get; set; }  
        public DateTime Date { get; set; }

        public static bool operator <(Vaccination vaccination, DateTime date)
        {
            return vaccination.Date.CompareTo(date) < 0;
        }
        public static bool operator >(Vaccination vaccination, DateTime date)
        {
            return vaccination.Date.CompareTo(date) > 0;
        }

        /// <summary>
        /// constructor for vaccination information
        /// </summary>
        /// <param name="dogID"> ID of dog </param>
        /// <param name="date"> date of dogs vaccination </param>
        public Vaccination(int dogID, DateTime date)
        {
            DogID = dogID;
            Date = date;
        }
    }
}
