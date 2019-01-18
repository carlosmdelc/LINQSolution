using System;
using System.Linq;

namespace LINQExamples
{   
    /// <summary>
    /// Person class
    /// </summary>
    class Person
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int height { get; set; }
        public int age { get; set; }
        public Gender gender { get; set; }
        internal enum Gender
        {
            Male,
            Female
        }

        public Person(int id, string firstName, string lastName, int height, int age, Gender gender)
        {
            this.id = id;
            this.firstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            this.lastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            this.height = height;
            this.age = age;
            this.gender = gender;
        }
    }
}
