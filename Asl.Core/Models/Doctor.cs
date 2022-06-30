using System;
using System.Collections.Generic;
using System.Text;

namespace Asl.Core.Models
{
    public class Doctor : Person
    {
        public int Id { get; set; }

        public IList<Patient> Patients { get; set;}

        public IList<Stub> Stubs { get; set; }
    }
}
