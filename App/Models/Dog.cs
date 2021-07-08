using System;
using System.Collections.Generic;

namespace App
{
    public class Dog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Owner Owner { get; set; }
    }
}