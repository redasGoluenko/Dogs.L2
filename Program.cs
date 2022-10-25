using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Dogs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DogsRegister register = InOutUtils.ReadDogs(@"Dogs.csv");
            Console.WriteLine("Registro informacija:");
           InOutUtils.PrintDogs(register);
            Console.WriteLine("Iš viso šunų: {0}", register.DogsCount());
            Console.WriteLine("Patinų: {0}", register.CountByGender(Gender.Male));
            Console.WriteLine("Patelių: {0}", register.CountByGender(Gender.Female));
            Console.WriteLine();
            Dog oldest = register.FindOldestDog();
            Console.WriteLine("Seniausias šuo");
            Console.WriteLine("Vardas: {0}, Veislė: {1}, Amžius: {2}",
            oldest.Name, oldest.Breed, oldest.Age);
            List<string> Breeds = register.FindBreeds();
            Console.WriteLine("Šunų veislės:");
            InOutUtils.PrintBreeds(Breeds);
            Console.WriteLine();
            Console.WriteLine("Kokios veislės šunis atrinkti?");
            string selectedBreed = Console.ReadLine();
            InOutUtils.PrintByBreed(register, selectedBreed);
            string fileName = selectedBreed + ".csv";
            InOutUtils.PrintDogsToCSVFile(fileName, register, selectedBreed);
            List<Vaccination> VaccinationsData = InOutUtils.ReadVaccinations(@"Vaccinations.csv");
            register.UpdateVaccinationsInfo(VaccinationsData);
            Console.WriteLine();
            Console.WriteLine("Šunys, kuriuos reikia paskiepyti:");
            DogsRegister Filtered = register.FilterByVaccinationExpired();               // 2 savarankiška užduotis
            InOutUtils.PrintDogs(Filtered);


        }
    }
}
