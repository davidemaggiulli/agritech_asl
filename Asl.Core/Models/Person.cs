using System;
using System.Collections.Generic;
using System.Text;

namespace Asl.Core.Models
{
    public abstract class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public DateTime? Birthdate { get; set; }
        public string BirthPlace { get; set; }

    }
}
