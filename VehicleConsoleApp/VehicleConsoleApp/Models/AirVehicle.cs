using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleConsoleApp
{
    class AirVehicle : Vehicle
    {
        public int numWings { get; set; }
        public int numPropellers { get; set; }
        public int maxAltitude { get; set; }
        public int takeOffDistanceNeeded { get; set; }
        public int numPilots { get; set; }
    }


    //class AirVehicle : Vehicle
    //{
    //    private int numWings;
    //    private int numPropellers;
    //    private int maxAltitude;
    //    private int takeOffDistanceNeeded;
    //    private int numPilots;
    //}
}
