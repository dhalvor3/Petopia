using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            var database = new DataContext();

            Console.WriteLine("#1");
            Console.WriteLine("Basic Query");
            var dogs = database.Dogs.ToList();
// green Dog ties to the class Dog.
            foreach(Dog dog in dogs) {
                Console.WriteLine($"{dog.Id} : {dog.Name}");
            }

            Console.WriteLine("#2");
            Console.WriteLine("using the where");
            database.Dogs.Where(d => d.Id > 1).OrderBy(d => d.Name).ToList().ForEach(dog => Console.WriteLine(dog.Name));

            Console.WriteLine("#3");
            Console.WriteLine("add data to database");
            var puppies = new List<Dog>{new Dog {Name = "Frodo"}, new Dog {Name = "Gandalf"}};
            database.AddRange(puppies);
            database.SaveChanges();

            //following are all in done using LINQ
            Console.WriteLine("basic query in linq");
            var dogs1 = from dog in database.Dogs
                select dog;
                dogs1.ToList().ForEach(dog => Console.WriteLine($"{dog.Name}"));

            Console.WriteLine("basic query in linq - ascending");
            dogs1 = from dog in database.Dogs
                orderby dog.Name ascending
                select dog;
                dogs1.ToList().ForEach(dog => Console.WriteLine($"{dog.Name}"));

            Console.WriteLine("basic query in linq - where");
            var objects = from dog in database.Dogs
                where dog.Id > 1
                select new {Name = dog.Name, Id = dog.Id};
                objects.ToList().ForEach(dog => Console.WriteLine($"{dog.Id} : {dog.Name}"));


        }
    }
}
