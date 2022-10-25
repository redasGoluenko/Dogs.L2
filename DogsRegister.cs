using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dogs
{
    /// <summary>
    /// class used for calculations (substitute to TaskUtils.cs)
    /// </summary>
    class DogsRegister
    {

        /// <summary>
        /// declares a private list that will be used to store desired variables
        /// </summary>
        private List<Dog> AllDogs;

        /// <summary>
        /// constructor that will be used instead of list when calling out inside method
        /// </summary>
        public DogsRegister()
        {
            AllDogs = new List<Dog>();
        }

        /// <summary>
        /// constructor that stores dogs from specified list into private AllDogs list
        /// </summary>
        /// <param name="Dogs"> list of dogs </param>
        public DogsRegister(List<Dog> Dogs)
        {
            AllDogs = new List<Dog>();
            foreach (Dog dog in Dogs)
            {
                this.AllDogs.Add(dog);
            }
        }

        /// <summary>
        /// adds specified dog to AllDogs list
        /// </summary>
        /// <param name="dog"> dog to be added to AllDogs list </param>
        public void Add(Dog dog) // adds specified variable to "AllDogs" list
        {
            AllDogs.Add(dog);
        }
         /// <summary>
         /// used to get count of dogs in list
         /// </summary>
         /// <returns> count of dogs in list </returns>
        public int DogsCount()
        {
            return this.AllDogs.Count;
        }

        /// <summary>
        /// counts amount of dogs with gender specified
        /// </summary>
        /// <param name="gender"></param>
        /// <returns> amount of dogs with gender specified </returns>
        public int CountByGender(Gender gender)
        {
            int count = 0;
            foreach (Dog dog in this.AllDogs)
            {
                if (dog.Gender.Equals(gender))
                {
                    count++;
                }
            }
            return count;
        }

        /// <summary>
        /// returns list of dogs with specified breed
        /// </summary>
        /// <param name="breed"> breed to use when creating list <param>
        /// <returns> list of specified breed </returns>
        public List<Dog> FilterByBreed(string breed)
        {
            List<Dog> Filtered = new List<Dog>();
            foreach (Dog dog in this.AllDogs)
            {
                if (dog.Breed.Equals(breed)) // uses string method Equals()
                {
                    Filtered.Add(dog);
                }
            }
            return Filtered;
        }

        /// <summary>
        /// used to return oldest dog by returning method in line 119
        /// </summary>
        /// <returns> oldest dog </returns>
        public Dog FindOldestDog()
        {
            return this.FindOldestDog(this.AllDogs);
        }

        /// <summary>
        /// returns oldest dog of specified breed using local variable Filtered
        /// </summary>
        /// <param name="breed"> breed to use when filtering </param>
        /// <returns> oldest dog of specified breed </returns>
        public Dog FindOldestDog(string breed)
        {
            List<Dog> Filtered = this.FilterByBreed(breed);
            return this.FindOldestDog(Filtered);
        }

        /// <summary>
        /// finds oldest dog
        /// </summary>
        /// <param name="Dogs"> list of dogs </param>
        /// <returns> oldest dog </returns>
        private Dog FindOldestDog(List<Dog> Dogs)
        {
            Dog oldest = Dogs[0];
            for(int i = 1; i < Dogs.Count; i++)
            {
                if (DateTime.Compare(oldest.BirthDate, Dogs[i].BirthDate) > 0)
                {
                    oldest = Dogs[i];
                }
            }
            return oldest;
        }

        /// <summary>
        /// finds dogs of certain breed
        /// </summary>
        /// <returns> list of specified breed </returns>
        public List<string> FindBreeds()
        {
            List<string> Breeds = new List<string>();
            foreach (Dog dog in this.AllDogs)
            {
                string breed = dog.Breed;
                if (!Breeds.Contains(breed)) // uses List method Contains()
                {
                    Breeds.Add(breed);
                }
            }
            return Breeds;
        }

        /// <summary>
        /// finds dogs information stored in specified index
        /// </summary>
        /// <param name="index"> index of desired dog </param>
        /// <returns> information of dog stored inside specified index </returns>
        public Dog TakeByIndex(int index)                                                  // 1 savarankiška užduotis
        {                                                                                  
            return this.AllDogs[index];                                                    
        }                                                                                  

        /// <summary>
        /// finds dog with specified ID
        /// </summary>
        /// <param name="ID"> ID of dog  </param>
        /// <returns> dog of specified ID </returns>
        private Dog FindDogByID(int ID)
        {
            foreach (Dog dog in this.AllDogs)
            {
                if (dog.ID == ID)
                {
                    return dog;
                }
            }
            return null;         
        }

        /// <summary>
        /// updates "Dog" object with the most recent vaccination date by adding it to the newly made vaccinations object
        /// </summary>
        /// <param name="Vaccinations"> list containing vaccinated dogs and dates of their vaccination </param>
        public void UpdateVaccinationsInfo(List<Vaccination> Vaccinations)
        {
            foreach (Vaccination vaccination in Vaccinations)
            {
                Dog dog = this.FindDogByID(vaccination.DogID);
                if (dog != null)
                {
                    if (vaccination > dog.LastVaccinationDate)
                    {
                        dog.LastVaccinationDate = vaccination.Date;
                    }
                }
            }
        }

        /// <summary>
        /// finds dogs that require vaccination 
        /// </summary>
        /// <returns> DogsRegister of dogs that require vaccination </returns>
        public DogsRegister FilterByVaccinationExpired() // 2 savarankiska uzduotis.
        {
            DogsRegister Filtered = new DogsRegister();
            foreach(Dog dog in this.AllDogs)
            {              
                    if (dog.RequiresVaccination)
                    {
                        Filtered.Add(dog);
                    }               
            }
            return Filtered;
        }

        /// <summary>
        /// checks list for specified dog
        /// </summary>
        /// <param name="dog"> dog to look for in list </param>
        /// <returns> information of dog specified </returns>
        public bool Contains(Dog dog)
        {
            return AllDogs.Contains(dog);
        }
    }
}
