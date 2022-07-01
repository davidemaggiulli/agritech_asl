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
        public bool InsertDoctor(Doctor doctor)
        {
            using var context = new AslDbContext();
            context.Doctors.Add(doctor);
            try
            {
                context.SaveChanges();
                return true;
            }
            catch
            {
                
            }
            return false;
        }
        public void InsertPatient(string fiscalCode, string name, string surname, string streetName, string streetNumber, string city, string cap, int doctorId, DateTime? bd = null, string ln = null)
        {
            var patient = new Patient
            {
                Name = name,
                FiscalCode = fiscalCode,
                Surname = surname,
                Birthdate = bd,
                BirthPlace = ln,
                DoctorId = doctorId,
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

        public IList<Doctor> GetAllDoctors()
        {
            using var context = new AslDbContext();
            return context.Doctors.ToList();
        }

        public Doctor GetDoctorById(int id)
        {
            using var context = new AslDbContext();
            return context.Doctors.Find(id);
        }
    }
}
