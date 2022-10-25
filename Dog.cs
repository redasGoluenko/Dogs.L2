using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dogs
{
    /// <summary>
    /// stores information of dog
    /// </summary>
    class Dog
    {       
            public int ID { get; set; }
            public string Name { get; set; }
            public string Breed { get; set; }
            public DateTime BirthDate { get; set; }
            public Gender Gender { get; set; }
            public DateTime LastVaccinationDate { get; set; }

        /// <summary>
        /// both methods ensure that no dogs with matching IDs make it to the list
        /// </summary>
        public override bool Equals(object other)
        {
            return this.ID == ((Dog)other).ID;
        }

        public override int GetHashCode()
        {
            return this.ID.GetHashCode();
        }

        /// <summary>
        /// checks if dog needs vaccination / vaccination is expired
        /// </summary>
        /// <returns> returns TRUE if vaccination is required </returns>
        public bool RequiresVaccination
        {
            get
            {
                if (LastVaccinationDate.Equals(DateTime.MinValue))
                {
                    return true;
                }
                return LastVaccinationDate.AddYears(VaccinationDuration)
                .CompareTo(DateTime.Now) < 0;
            }
        }

        /// <summary>
        /// calculates age using dogs birth date
        /// </summary>
        /// <returns> dogs age </returns>
        public int Age
        {
            get
            {
                DateTime today = DateTime.Today;
                int age = today.Year - this.BirthDate.Year;
                if (this.BirthDate.Date > today.AddYears(-age))
                {
                    age--;
                }
                return age;
            }
        }

        /// <summary>
        /// constructor for Dog class
        /// </summary>
        /// <param name="id"> ID of dog </param>
        /// <param name="name"> name of dog </param>
        /// <param name="breed"> breed of dog</param>
        /// <param name="birthDate"> birthdate of dog </param>
        /// <param name="gender"> gender of dog </param>
        public Dog(int id, string name, string breed, DateTime birthDate, Gender gender)
            {
                this.ID = id;
                this.Name = name;
                this.Breed = breed;
                this.BirthDate = birthDate;
                this.Gender = gender;
            }

        /// <summary>
        /// determines vaccination expiration date
        /// </summary>
        private const int VaccinationDuration = 1;
    }



}

