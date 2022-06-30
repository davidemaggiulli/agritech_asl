using System;
using System.Collections.Generic;
using System.Text;

namespace Asl.Core.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public string City { get; set; }
        public string Cap { get; set; }
    }
}
