using System;
using System.Collections.Generic;

namespace personExample
{
    public partial class Person
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Sex { get; set; }
        public string EyeColor { get; set; }
        public int? ShoeSize { get; set; }
        public int? Height { get; set; }
    }
}