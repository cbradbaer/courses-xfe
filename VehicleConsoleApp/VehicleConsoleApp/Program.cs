using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleConsoleApp.Models;

namespace VehicleConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            LandVehicle myCar = new LandVehicle();
            Person me = new Person();
            Person passenger1 = new Person();
            Person passenger2 = new Person();
            Trip myTrip = new Trip();


            myCar.maker = "Toyota";
            myCar.model = "Corolla";

            me.name = "Cary Baer";

            passenger1.name = "John Smith";
            passenger2.name = "Jane Doe";

            myTrip.vehicle = myCar;
            myTrip.controller = me;
            myTrip.startLocation = "Los Angeles";
            myTrip.endLocation = "Houston";
            myTrip.passengerList.Add(passenger1);
            myTrip.passengerList.Add(passenger2);

            Console.Write(me.name + " is taking the " + myCar.maker + " " + myCar.model + " on a trip from " + myTrip.startLocation + " to "
                            + myTrip.endLocation + ".\r\n");

            string passengerList = string.Empty;

            foreach(Person p in myTrip.passengerList)
            {
                passengerList = passengerList + p.name + "\r\n";
            }
            Console.Write("These passengers also going: \r\n" + passengerList);
            Console.ReadKey();
                      
        }
    }
}
