using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemiologyReport.Models
{
    public class Patient
    {
        public Patient(string id)
        {
            this.Id = id;
            this.Locations = new List<Location>();
        }
        public string Id { get; set; }
        public List<Location>  Locations { get; set; }
    }
}
