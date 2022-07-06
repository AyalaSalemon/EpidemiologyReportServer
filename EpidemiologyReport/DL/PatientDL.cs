using EpidemiologyReport.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text.Json;
namespace EpidemiologyReport.DL
{
    public class PatientDL:IPatientDL
    {

        public void WriteData(List<Patient> patients)
        {           
           File.WriteAllText("./DB.json", System.Text.Json.JsonSerializer.Serialize(patients));
        }
        public List<Patient> ReadData()
        {
            StreamReader r = new StreamReader("./DB.json");
            string patientsString = r.ReadToEnd();
            List<Patient> patients = JsonConvert.DeserializeObject<List<Patient>>(patientsString);
            r.Close();
            return patients;

        }
        public List<Location> GetAllLocations()
        {
            List < Patient > patients= ReadData();
            List<Location> locations=new List<Location>();
            patients.ForEach(pat => pat.Locations.ForEach(loc => locations.Add(loc)));
            return locations;
        }
        public List<Location> GetLocationsByCity(string city)
        {
            if (city == null)
                return GetAllLocations();
            city = city.ToLower();
            List<Patient> patients = ReadData();
            List<Location> locations = new List<Location>();
            patients.ForEach(pat => pat.Locations.ForEach(loc => { 
                if(loc.City.ToLower().Contains(city))
                locations.Add(loc); 
            }));
            return locations;
        }
        public List<Location> GetLocationsByPatientId(string id)
        {
            
            List<Patient> patients = ReadData();
            Patient patient = patients.Find(pat => pat.Id == id);
            if(patient!=null)
            return patient.Locations;
            return null;
           
        }
        public void AddLocation(Patient newPatient)
        {
              List<Patient> patients = ReadData();
              Patient patient = patients.Find(pat => pat.Id == newPatient.Id);
            if (patient == null)
            {
                patients.Add(newPatient);
            }
            else
            {
                patient.Locations.Add(newPatient.Locations[0]);
            }
            WriteData(patients);
        }
        public void DeleteLocation(string patientId, int locationId)
        {
            List<Patient> patients = ReadData();
            Patient patient = patients.Find(pat => pat.Id == patientId);
            if (patient == null)
            {
                return;
            }
            else
            {
                patient.Locations.Remove(patient.Locations.Find(loc=>loc.Id==locationId));
            }
            WriteData(patients);
        }

    }
}
