using System;
using System.Collections.Generic;

namespace App
{
    public class Owner
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        // ICollection is Like a foreign key to the Pets table
        public ICollection<Dog> Pets { get; set; }
    }
}