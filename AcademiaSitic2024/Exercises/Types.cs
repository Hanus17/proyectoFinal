using System;

namespace Exercises
{
    class Types
    {
        static void Main2(string[] args)
        {
            string courseName = "Academia SITIC";
            String courseName2 = "Academia SITIC 2";

            int studentCount = 28;
            bool isStartingNow = true;

            int? age = null;
            //1
            Console.WriteLine(age != null ? age : 0);
            //2
            if (age != null)
                Console.WriteLine(age);
            else
                Console.WriteLine(0);
            //3
            Console.WriteLine(age.GetValueOrDefault(0));
            
            Console.ReadKey();
            User user = new();
            Employer emp = new();
        }

        public class User
        {
            private int _idUser;
            private string _name;
            private string _password;

            public string Password { get => _password; set => _password = value; }
        }

        public class Person
        {
            public int PersonId { get; set; }
            public string Name { get; set; }
        }

        public class Employer : Person
        {
            public DateTime StartDate { get; set; }
        }
    }
}
