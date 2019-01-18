using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQExamples
{
    class EntryPoint
    {
        static void Main(string[] args)
        {
            string sentence = "I love cats";
            string[] catNames = {"Lucky", "Bella", "Luna", "Oreo", "Simba", "Toby", "Loki", "Oscar"};
            int[] numbers = {5, 6, 3, 2, 1, 5, 6, 7, 8, 4, 234, 54, 14, 653, 3, 4, 5, 6, 7};

            // Extract all the cat names that have the character A in their names.
            // Add condition to get the names with length less than five.
            var catsWithA = 
                from cat in catNames
                where (cat.Contains("a")) && (cat.Length < 5)
                select cat;

            Console.WriteLine(string.Join(", ", catsWithA));

            // Get the numbers greater than 5 but less than 10.
            var getTheNumbers = 
                from number in numbers
                where (number > 5) && (number < 10)
                orderby number descending 
                select number;

            // There is another way to do it, add multiple where instead of &&
            // Approach used when you have multiple conditions.
            var getTheNumbersWithWhere =
                from n in numbers
                where n > 5
                where n < 10
                select n;

            Console.WriteLine(string.Join(", ", getTheNumbers));
            Console.WriteLine(string.Join(", ", getTheNumbersWithWhere));

            // Working with Objects

            List<Person> people = new List<Person>()
            {
                new Person(1, "Tod", "Vachev", 180, 26, Person.Gender.Male),
                new Person(2, "John", "Johnson", 170, 21, Person.Gender.Male),
                new Person(3, "Anna", "Maria", 150, 22, Person.Gender.Female),
                new Person(4, "Kyle", "Wilson", 164, 29, Person.Gender.Male),
                new Person(5, "Anna", "Williams", 164, 28, Person.Gender.Male),
                new Person(6, "Maria", "Ann", 160, 43, Person.Gender.Female),
                new Person(7, "John", "Jones", 160, 37, Person.Gender.Female),
                new Person(8, "Samba", "TheLion", 160, 33, Person.Gender.Male),
                new Person(9, "Aaron", "Myers", 160, 21, Person.Gender.Male),
                new Person(10, "Aby", "Wood", 160, 20, Person.Gender.Female),
                new Person(11, "Maddie", "Lewis", 160, 19, Person.Gender.Female),
                new Person(12, "Lara", "Croft", 160, 18, Person.Gender.Female),
            };

            // Retrieve all people whose name is exactly four characters long and have them in a new collection and have them to separate them from the others
            var fourCharPeople =
                from p in people
                where p.firstName.Length == 4
                orderby p.firstName descending, p.age descending 
                select p;
                //select p.firstName;   ---> Used when we only want that property.

            foreach (var person in fourCharPeople)
            {
                // Since we are getting p.firstName we cannot use person.height or any other property
                Console.WriteLine("Information: {0} {1} {2} {3}", person.firstName, person.height, person.age, person.gender); 
                // Console.WriteLine($"Name: {person}");
            }

            // When we want to get more than one property.
            // We need to use an anonymous object with the properties we want to get.
            // We will end with a collection of anonymous objects.
            var youngPeople =
                from p in people
                where p.age < 25
                select new
                {
                    Name = p.firstName,
                    Age = p.age
                };

            foreach (var p in youngPeople)
            {
                Console.WriteLine($"{p.Name} my age is {p.Age}");
            }

            // Instead of creating a new anonymous object we can also instantiate object types that we already have.
            // Using YoungPerson class to get the properties.
            var youngPeopleObj =
                from p in people
                where p.age < 25
                select new YoungPerson
                {
                    //fullName = p.firstName + " " + p.lastName,
                    fullName = string.Format($"{p.firstName} {p.lastName}"),
                    age = p.age
                };

            foreach (var p in youngPeopleObj)
            {
                Console.WriteLine($"{p.fullName} my age is {p.age}");
            }

            // Using let keyword
            // Extract all people whose name starts with the character A
            Console.WriteLine("Using let keyword Section.");

            var peopleWithA =
                from p in people
                let firstCharacter = p.firstName.ToLower()[0]
                where firstCharacter == 'a'
                let fullName = string.Format($"{p.firstName} {p.lastName}")
                select new YoungPerson {age = p.age, fullName = fullName};

            foreach (var p in peopleWithA)
            {
                Console.WriteLine($"{p.fullName}");
            }

            // List of lists of integers, so a collection of collections.
            List<List<int>> lists = new List<List<int>>
            {
                new List<int>() {1, 2, 3},
                new List<int>() {4, 5, 6},
                new List<int>() {7, 8, 9}
            };

            // Put all of these numbers into one single collection.
            // Get all of these numbers squared and only those that being under 50.
            var allNumbers =
                from l in lists         // this will iterate in each list not each number in list
                let listNumbers = l     // listNumbers will containt the value of the list on each iteration
                from n in listNumbers   // this will iterate in each number in the current list iteration
                select n;

            foreach (var item in allNumbers)
            {
                Console.WriteLine(item);
            }

            var allTheNumbers =
                from l in lists
                from n in l
                let sqNumber = n * n
                where sqNumber < 50
                select sqNumber;

            foreach (var item in allTheNumbers)
            {
                Console.WriteLine($"{item}");
            }

        Console.ReadKey();
        }
    }
}
