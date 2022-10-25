﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.CompilerServices;

namespace Dogs
{

/// <summary>
/// for reading and writing data
/// </summary>
    internal class InOutUtils
    {

        /// <summary>
        /// stores file information in DogsRegister Dogs 
        /// </summary>
        /// <param name="fileName"> name of file to read from </param>
        /// <returns> list of dogs from file </returns>
        public static DogsRegister ReadDogs(string fileName)
        {
            DogsRegister Dogs = new DogsRegister();
            string[] Lines = File.ReadAllLines(fileName, Encoding.UTF8);
            foreach (string line in Lines)
            {
                string[] Values = line.Split(';');
                int id = int.Parse(Values[0]);
                string name = Values[1];
                string breed = Values[2];
                DateTime birthDate = DateTime.Parse(Values[3]);

                Gender gender;
                Enum.TryParse(Values[4], out gender); //tries to convert value to enum

                Dog dog = new Dog(id, name, breed, birthDate, gender);
                if (!Dogs.Contains(dog))
                {
                    Dogs.Add(dog);
                }
            }
            return Dogs;
        }

        /// <summary>
        /// prints out all dogs into console
        /// </summary>
        /// <param name="dogs"> DogsRegister of all dogs </param>
        public static void PrintDogs(DogsRegister dogs)                                          //1 savarankiška užduotis
        {

            Console.WriteLine(new string('-', 74));
            Console.WriteLine("| {0,8} | {1,-15} | {2,-15} | {3,-12} | {4,-8} |",
            "Reg.Nr.", "Vardas", "Veislė", "Gimimo data", "Lytis");
            Console.WriteLine(new string('-', 74));
            for (int i =0;  i< dogs.DogsCount(); i ++)
            {
                Dog dog = dogs.TakeByIndex(i);
                Console.WriteLine("| {0,8} | {1,-15} | {2,-15} | {3,-12:yyyy-MM-dd} | {4,-8} |",
                dog.ID, dog.Name, dog.Breed, dog.BirthDate, dog.Gender);
            }
            Console.WriteLine(new string('-', 74));
        }

        /// <summary>
        /// prints out dogs info of specified breed
        /// </summary>
        /// <param name="dogs"> DogsRegister of dogs </param>
        /// <param name="breed"> breed to use when printing out </param>
        public static void PrintByBreed (DogsRegister dogs, string breed)
        {
            Console.WriteLine(new string('-', 74));
            for (int i = 0; i < dogs.DogsCount(); i++)
            {
                Dog dog = dogs.TakeByIndex(i);
                    if (dogs.TakeByIndex(i).Breed.ToString() == breed)
                  {
                Console.WriteLine("| {0,8} | {1,-15} | {2,-15} | {3,-12:yyyy-MM-dd} | {4,-8} |",
                dog.ID, dog.Name, dog.Breed, dog.BirthDate, dog.Gender);
                    }

            }
            Console.WriteLine(new string('-', 74)); 
        }
     
        /// <summary>
        /// prints out all breeds
        /// </summary>
        /// <param name="breeds"> all breeds </param>
        public static void PrintBreeds(List<string> breeds)
        {
            foreach (string breed in breeds)
            {

                Console.WriteLine(breed);
            }
        }

        /// <summary>
        /// prints all dogs of specified breed into .csv
        /// </summary>
        /// <param name="fileName"> name of file to print into </param>
        /// <param name="dogs"> DogsRegister of dogs </param>
        /// <param name="breed"> breed to print </param>
        public static void PrintDogsToCSVFile(string fileName, DogsRegister dogs, string breed)
        {
            string[] lines = new string[dogs.DogsCount() + 1];
            for (int i = 0; i < dogs.DogsCount(); i++)
            {
                if (dogs.TakeByIndex(i).Breed == breed)
                {
                    Dog dog = dogs.TakeByIndex(i);
                    lines[i + 1] = String.Format("{0};{1};{2};{3};{4}",
                    dog.ID, dog.Name, dog.Breed, dog.BirthDate, dog.Gender);
                }
            }
            if(File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            File.WriteAllLines(fileName, lines, Encoding.UTF8);
        }

        /// <summary>
        /// Reads vaccination information
        /// </summary>
        /// <param name="fileName"> name of vaccinated dogs file </param>
        /// <returns> list of vaccinated dogs info </returns>
        public static List<Vaccination> ReadVaccinations(string fileName)
        {
            List<Vaccination> Vaccinations = new List<Vaccination>();
            string[] Lines = File.ReadAllLines(fileName);
            foreach (string line in Lines)
            {
                string[] Values = line.Split(';');
                int id = int.Parse(Values[0]);
                DateTime vaccinationDate = DateTime.Parse(Values[1]);
                Vaccination v = new Vaccination(id, vaccinationDate);
                Vaccinations.Add(v);
            }
            return Vaccinations;
        }
    }
}
