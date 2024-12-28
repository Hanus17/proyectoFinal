using System;
using System.Collections.Generic;
using System.Linq;

namespace ListLINQ
{
    class Program
    {
        //Listas con LINQ
        #region Classes
        public class People
        {
            #region Properties
            public string Name { get; set; }
            public int Age { get; set; }
            public eGender Gender { get; set; }
            //"Femenino" / "Masculino" / "Indefinido"
            //"F" / "M" / "I" <- char 
            #endregion

            #region Constructors
            public People() { }

            public People(string name, int age, eGender gender)
            {
                Name = name;
                Age = age;
                Gender = gender;
            }
            #endregion

            #region Methods
            public override string ToString()
            {
                return $"Nombre: {Name}, Edad: {Age}, Género: {this.GetStringGender(Gender)}";
            }

            private string GetStringGender(eGender gender)
            {
                string genderString;
                #region If/else
                //if (gender == eGender.Undefined)
                //    genderString = "Indefinido";
                //else if (gender == eGender.Female)
                //    genderString = "Femenino";
                //else if (gender == eGender.Male)
                //    genderString = "Masculino"; 
                //else
                //    genderString = "No válido";
                #endregion

                #region Switch
                //switch (gender)
                //{
                //    case eGender.Undefined:
                //        genderString = "Indefinido";
                //        break;
                //    case eGender.Female:
                //        genderString = "Femenino";
                //        break;
                //    case eGender.Male:
                //        genderString = "Masculino";
                //        break;
                //    default:
                //        genderString = "No válido";
                //        break;
                //} 
                #endregion

                #region Switch lambda
                genderString = gender switch
                {
                    eGender.Undefined => "Indefinido",
                    eGender.Male => "Masculino",
                    eGender.Female => "Femenino",
                    _ => "No válido"
                };
                #endregion
                return genderString;
            }
            #endregion
        }
        #endregion

        #region Enums
        public enum eGender
        {
            Undefined,
            Female, 
            Male,
        }
        #endregion

        static void Main2(string[] args)
        {
            List<People> employeers = new()
            {
                new People
                {
                    Name = "María",
                    Age = 18,
                    Gender = eGender.Female
                },
                new People
                {
                    Name = "Andrea",
                    Age = 25,
                    Gender = eGender.Female
                },
            };

            if (employeers != null)
            {
                employeers.Add(new("Ricardo", 34, eGender.Male));
                employeers.Add(new("Jazmín", 33, eGender.Female));
                employeers.Add(new("Vicente", 28, eGender.Male));
                employeers.Add(new("Abraham", 42, eGender.Male));
                employeers.Add(new("Alberto", 20, eGender.Male));
            }

            List<People> students = new()
            {
                new("Iris", 23, eGender.Female),
                new("Jesús", 26, eGender.Male),
                new("Andrés", 33, eGender.Male),
                new("América", 22, eGender.Female),
                new("Paola", 22, eGender.Female),
                new("Christian", 22, eGender.Male),
            };

            #region Where
            //Ejemplo 1: Filtrar nombres que comiencen con la letra 'A'
            //Lista de empleados

            Console.WriteLine("\nWHERE - Filtrar nombres que comiencen con la letra 'A'");
            List<People> filteredEmployeers = employeers.Where(employeer => employeer.Name.StartsWith("A")).ToList();
            WriteLine(filteredEmployeers);

            Console.WriteLine("\nWHERE - Filtrar empleados mayores a 30 años");
            filteredEmployeers = employeers.Where(employeer => employeer.Age > 30).ToList();
            WriteLine(filteredEmployeers);
            #endregion

            #region Select
            Console.WriteLine("\nSELECT - Tomar el nombre (sirve para seleccionar una propiedad en específico).");
            List<string> filteredEmployeersNames = employeers.Select(employeer => employeer.Name).ToList();
            foreach (string name in filteredEmployeersNames)
                Console.WriteLine(name);
            #endregion

            #region OrderBy & OrderByDescending
            Console.WriteLine("\nOrderBy - Ordenamiento por nombre vs la diferencia de la lista original");
            List<People> filteredStudents = students.OrderBy(student => student.Name).ToList();
            int i = 0;
            People originalStudent = null;
            foreach (var filteredStudent in filteredStudents)
            {
                originalStudent = students[i];
                Console.WriteLine($"{filteredStudent.Name} - {originalStudent.Name}");
                i++;
            }

            Console.WriteLine("\nOrderByDescending - Ordenar por edad y vamos a diferenciarlo con la lista original");
            filteredStudents = students.OrderByDescending(student => student.Age).ToList();
            i = 0;
            originalStudent = null;
            foreach (var filteredStudent in filteredStudents)
            {
                originalStudent = students[i];
                Console.WriteLine($"{filteredStudent.Name} - {originalStudent.Name}");
                i++;
            }
            #endregion

            #region GroupBy
            Console.WriteLine("\nGROUPBY - Agrupamiento por género");
            var groupedByGender = students.GroupBy(student => student.Gender);
            foreach(var group in groupedByGender)
            {
                Console.WriteLine($"Género (grupo): {group.Key}");
                foreach(var person in group)
                {
                    Console.WriteLine($"{person.Name}");
                }
            }

            //GroupBy -> Realizar el ejercicio donde agrupen EMPLEADOS por edades.
            //Muestren el nombre Y EL TOTAL POR GRUPO.
            Console.WriteLine("\nGROUPBY - Agrupamiento por edades");
            var groupedByAge = employeers.GroupBy(employeer => employeer.Age);
            foreach (var group in groupedByAge)
            {
                Console.WriteLine($"Edades (grupo): {group.Key} - Total: {group.Count()}");
                foreach (var person in group)
                {
                    Console.WriteLine($"{person.Name}");
                }
            }
            #endregion

            #region ANY
            Console.WriteLine("\nANY - Verifica si hay valores o no dentro de la lista");
            Console.WriteLine($"Existen valores en 'employeers': {employeers.Any()}");
            Console.WriteLine($"Existen empleados mayores de 30': {employeers.Any(i => i.Age > 30)}");
            #endregion
            //foreach (People employeer in employeers)
            //{
            //    Console.WriteLine($"Nombre: {employeer.Name}");
            //}

            Console.ReadKey();
        }

        private static void WriteLine(List<People> peopleList)
        {
            foreach (People people in peopleList)
            {
                Console.WriteLine(people.ToString());
            }
        }

    }
}
