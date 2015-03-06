using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenAipLib;
using osmLib;

namespace ImportAviationDataConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //Airspaces airspaces = new Airspaces();
            //airspaces.ReadFile(@"C:\Users\Rob Verhoef.WIN7-ROBVERHOEF\Documents\GIS DataBase\Airspaces\openaip_airspace_netherlands_nl.aip");

            OsmReader reader = new OsmReader();
            reader.readOsmFile("map.osm");

            Console.ReadKey();
        }
    }
}
