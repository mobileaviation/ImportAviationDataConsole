using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace osmLib
{
    public class OsmReader
    {
        public OsmReader()
        {
            
        }

        public void readOsmFile(string Filename)
        {
            XmlReader xmlReader = XmlReader.Create(Filename);
            while (xmlReader.Read())
            {
                if (xmlReader.Name == "node")
                {
                    if (xmlReader.HasAttributes)
                    {
                        Console.WriteLine("Lat: " + xmlReader.GetAttribute("lat") +
                               " lon:" + xmlReader.GetAttribute("lat"));
                    }
                }
            }
        }
    }
}
