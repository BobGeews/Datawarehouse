using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonPhoneApp
{
    public partial class Person
    {
        public Person()
        {
            Phone = new HashSet<Phone>();
        }

        public long id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public short? Age { get; set; }

        [InverseProperty("Person")]
        public virtual ICollection<Phone> Phone { get; set; }
    }
}