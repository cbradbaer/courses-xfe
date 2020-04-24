using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleConsoleApp.Models
{
    class Trip
    {
        public string startLocation;
        public string endLocation;
        public DateTime startTime;
        public Person controller;
        public List<Person> passengerList;
        public Vehicle vehicle;

        public Trip()
        {
            passengerList = new List<Person>();

        }

	}
}
