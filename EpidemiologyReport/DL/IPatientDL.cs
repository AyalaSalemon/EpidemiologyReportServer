using EpidemiologyReport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemiologyReport.DL
{
   public interface IPatientDL
    {
        public void WriteData(List<Patient> patients);
        public List<Patient> ReadData();
        public List<Location> GetAllLocations();
        public List<Location> GetLocationsByCity(string city);
        public List<Location> GetLocationsByPatientId(string id);
        public void AddLocation(Patient newPatient);        
        public void DeleteLocation(string patientId, int locationId);
    }
}
