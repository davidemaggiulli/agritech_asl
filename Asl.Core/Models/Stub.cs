using System;
using System.Collections.Generic;
using System.Text;

namespace Asl.Core.Models
{
    public class Stub
    {
        public string Id { get; set; }

        public DateTime ReservationDate { get; set; }

        public DateTime ExecutionDate { get; set; }
        public DateTime? ExecutedDate { get; set; }

        public string StubResult { get; set; }
        public StubResult Result { get; set; }

        public int DoctorId { get; set; }
        public Doctor PrescribeDoctor { get; set; }

        public string PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}
