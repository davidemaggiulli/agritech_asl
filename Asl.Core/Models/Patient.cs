using System;
using System.Collections.Generic;
using System.Text;

namespace Asl.Core.Models
{
    public class Patient : Person
    {
        public string FiscalCode { get; set; }
        
        public int AddressId { get; set; }
        public Address Address { get; set; }

        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        public IList<Stub> Stubs { get; set; }

    }
}
