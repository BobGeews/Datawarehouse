using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonPhoneApp
{
    public partial class Phone
    {
        public long id { get; set; }
        public string Type { get; set; }
        public string Number { get; set; }
        public long? Personid { get; set; }

        [ForeignKey("Personid")]
        [InverseProperty("Phone")]
        public virtual Person Person { get; set; }
    }
}