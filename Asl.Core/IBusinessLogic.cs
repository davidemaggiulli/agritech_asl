using Asl.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asl.Core
{
    public interface IBusinessLogic
    {
        IList<Patient> GetAllPatients();

        IList<Patient> GetAllPatientsByDoctorId(int doctorId);

        void InsertPatient(string fiscalCode, string name, string surname, string streetName, string streetNumber, string city, string cap, int doctorId,  DateTime? bd = null, string ln = null);

        bool InsertDoctor(Doctor doctor);

        IList<Doctor> GetAllDoctors();
        Doctor GetDoctorById(int id);
    }
}
