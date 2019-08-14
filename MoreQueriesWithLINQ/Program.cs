using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoreQueriesWithLINQ
{
    class Program
    {

        static void Main(string[] args)
        {
            int[] Num = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Console.ForegroundColor = ConsoleColor.Green;
            IEnumerable<int> resultQuerySyntax = from numbers in Num
                                                 where numbers > 3
                                                 select numbers;
            foreach (var item in resultQuerySyntax)
            {
                Console.WriteLine(item);
            }

            Console.ForegroundColor = ConsoleColor.Red;
            IEnumerable<int> resultMethodSyntax = Num.Where(n => n > 3).ToList();
            foreach (var item in resultMethodSyntax)
            {
                Console.WriteLine(item);
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            List<string> countries = new List<string>();
            countries.Add("india");
            countries.Add("us");
            countries.Add("australia");
            countries.Add("russia");
            countries.Add("uk");
            IEnumerable<string> resultOfLambda = countries.Select(x => x);
            foreach (var item in resultOfLambda)
            {
                Console.WriteLine(item);
            }

            //lambda
            Console.ForegroundColor = ConsoleColor.Magenta;
            int[] evenodd = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            IEnumerable<int> evennumber = evenodd.Where(x => x % 2 == 0);
            foreach (var item in evennumber)
            {
                Console.WriteLine(item + " is an even number");
            }
            Console.WriteLine(" --------- ");
            Console.WriteLine("Below are the odd numbers");
            IEnumerable<int> oddnumber = evenodd.Where(x => x % 2 != 0);
            foreach (var item in oddnumber)
            {
                Console.WriteLine(item + " is an odd number");
            }


            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("The Minimum value in the given array is:");
            int minimumNum = Num.Min();
            Console.WriteLine(minimumNum);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("The Sum value in the given array is:");
            int sumNum = Num.Sum();
            Console.WriteLine(sumNum);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Find the average of Num: ");
            double averageNum = Num.Average();
            Console.WriteLine(averageNum);

            //aggregate
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Find the Product of the elements:");
            double product = Num.Aggregate((a, b) => a * b);
            Console.WriteLine(product); //Output 362880 ((((((((1*2)*3)*4)*5)*6)*7)*8)*9)

            //projection operators
            Console.ForegroundColor = ConsoleColor.Red;
            List<Student> Objstudent = new List<Student>()
            {
            new Student() { StudentId = 1, Name = "Suresh", Marks = 500 },
            new Student() { StudentId = 2, Name = "Rohini", Marks = 300 },
            new Student() { StudentId = 3, Name = "Madhav", Marks = 400 },
            new Student() { StudentId = 4, Name = "Sateesh", Marks = 550 },
            new Student() { StudentId = 5, Name = "Praveen", Marks = 600 },
            new Student() { StudentId = 6, Name = "Sudheer", Marks = 700 },
            new Student() { StudentId = 7, Name = "Prasad", Marks = 550 }
            };
            //query syntax
            var result = from s in Objstudent
                         select new { SName = s.Name, SID = s.StudentId, SMarks = s.Marks };
            //method syntax
            //var result2 = Objstudent.Select(student => new
            //{
            //    SName = student.Name,
            //    SID = student.StudentId,
            //    SMarks = student.Marks,
            //});
            foreach (var item in result)
            {
                Console.WriteLine("The student name is {0}, ID is {1}, Marks are {2}", item.SName, item.SID, item.SMarks);
            }

            Console.ForegroundColor = ConsoleColor.Yellow;

            List<Student> NewStudent = new List<Student>()
            {
                new Student() { Name = "Ravi Varma", Gender = "Male", Subjects = new List<string> { "Mathematics", "Physics" } },
                new Student() { Name = "Vikram Sharma", Gender = "Male", Subjects = new List<string> { "Social Studies", "Chemistry" } },
                new Student() { Name = "Harish Dutt", Gender = "Male", Subjects = new List<string> { "Biology", "History", "Geography" } },
                new Student() { Name = "Akansha Wadhwani", Gender = "Female", Subjects = new List<string> { "English", "Zoology", "Botany" } },
                new Student() { Name = "Vikrant Seth", Gender = "Male", Subjects = new List<string> { "Civics", "Drawing" } }
            };

            var Subjects = NewStudent.SelectMany(x => x.Subjects);
            foreach (var Subject in Subjects)
            {
                Console.WriteLine(Subject);
            }

            Console.ForegroundColor = ConsoleColor.White;
            string[] countriesString = { "usa", "australia", "india", "argentina", "peru", "china" };
            IEnumerable<string> resultOfWhere = countriesString.Where(x => x.StartsWith("a"));
            foreach (var country in resultOfWhere)
            {
                Console.WriteLine(country);
            }

            Console.ForegroundColor = ConsoleColor.Magenta;
            var studentname = Objstudent.OrderBy(x => x.Name).ThenBy(x => x.StudentId);
            foreach (var student in studentname)
            {
                Console.WriteLine("Name={0} StudentId={1}", student.Name, student.StudentId);
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            IEnumerable<Student> Students = Objstudent;
            foreach (var item in Students)
            {
                Console.WriteLine("Name={0} StudentId={1}", item.Name, item.StudentId);
            }
            IEnumerable<Student> resultInReverse = Students.Reverse();
            foreach (var item in resultInReverse)
            {
                Console.WriteLine("Name={0} StudentId={1}", item.Name, item.StudentId);
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            IEnumerable<string> resultOfTake = countriesString.TakeWhile(x => x.StartsWith("u"));
            foreach (string s in resultOfTake)
            {
                Console.WriteLine(s);
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            string[] countries2 = { "US", "UK", "India", "Russia", "China", "Australia", "Argentina" };
            IEnumerable<string> resultofSkipWhile = countries2.SkipWhile(x => x.StartsWith("U"));
            foreach (string s in resultofSkipWhile)
            {
                Console.WriteLine(s);
            }

            //to lookup example
            Console.ForegroundColor = ConsoleColor.Green;
            List<Employee> objEmployee = new List<Employee>()
            {
                new Employee() { Name = "Ron", Department ="Marketing", Country="El Salvador" },
                new Employee() { Name = "Randy", Department ="IT", Country="Argentina" },
                new Employee() { Name = "Jim", Department ="HR", Country="Canada" },
                new Employee() { Name = "Phil Collins", Department ="Dirty Burger", Country="Latvia" },
                new Employee() { Name = "Julian", Department ="Operations", Country="Puerto Rico" }
            };
            var emp = objEmployee.ToLookup(x => x.Department);
            Console.WriteLine(" grouping employees by department ");
            Console.WriteLine(" ------------------");
            foreach (var KeyValuePair in emp)
            {
                Console.WriteLine(KeyValuePair.Key);
                //lookup employees by department
                foreach (var item in emp[KeyValuePair.Key])
                {
                    Console.WriteLine("\t" + item.Name + "\t" + item.Department + "\t" + item.Country);
                }
            }
                Console.ReadLine();
            }
        
        }
    }


