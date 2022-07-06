using EpidemiologyReport.DL;
using EpidemiologyReport.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EpidemiologyReport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        IPatientDL ipdl;
        public PatientController(IPatientDL patientDL)
        {
            this.ipdl = patientDL;
        }

        [HttpGet]
        public List<Location> Get()
        {
            return ipdl.GetAllLocations();
        }


        [HttpGet("city")]
        
        public List<Location> Get([FromQuery]string city)
        {
            return ipdl.GetLocationsByCity(city);
        }
        [HttpGet("{id}")]

        public List<Location> GetById(string id)
        {
            return ipdl.GetLocationsByPatientId(id);
        }

        [HttpPost]
        public void Post([FromBody] Patient patient)
        {
            ipdl.AddLocation(patient);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

       
        [HttpDelete("{patientId}/{locationId}")]
        public void Delete(string patientId, int locationId)
        {
            ipdl.DeleteLocation(patientId, locationId);
        }
    }
}
