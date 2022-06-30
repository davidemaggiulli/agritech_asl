using Asl.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asl.Core
{
    public class BusinessLogic : IBusinessLogic
    {
        public IList<Patient> GetAllPatients()
        {
            using var context = new AslDbContext();
            return context.Patients.ToList();
        }

        public IList<Patient> GetAllPatientsByDoctorId(int doctorId)
        {
            using var context = new AslDbContext();
            return context.Patients
                .Where(x => x.Doctor.Id == doctorId)
                .ToList();
        }

        public void InsertPatient(string fiscalCode, string name, string surname, string streetName, string streetNumber, string city, string cap, DateTime? bd = null, string ln = null)
        {
            var patient = new Patient
            {
                Name = name,
                FiscalCode = fiscalCode,
                Surname = surname,
                Birthdate = bd,
                BirthPlace = ln,
                Address = new Address
                {
                    Cap = cap,
                    City = city,
                    StreetName = streetName,
                    StreetNumber = streetNumber
                }
            };
            using var context = new AslDbContext();
            context.Patients.Add(patient);
            try
            {
                context.SaveChanges();
            }
            catch
            {

            }
        }
    }
}
