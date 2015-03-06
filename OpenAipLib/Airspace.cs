using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace OpenAipLib
{
    public class Airspaces: List<Airspace>
    {
        public Airspaces() :base()
        {
            
        }

        public void ReadFile(string Filename)
        {
            XDocument aipFile = XDocument.Load(Filename);


            var asp = from a in aipFile.Root.Elements("AIRSPACES").Elements("ASP") select a;

            foreach (XElement e in asp)
            {
                Airspace ai = new Airspace();
                ai.Version = e.Element("VERSION").Value.ToString();
                ai.ID = Convert.ToInt64(e.Element("ID").Value);
                ai.Country = e.Element("COUNTRY").Value.ToString();
                ai.Name = e.Element("NAME").Value.ToString();
                ai.Geometry = e.Element("GEOMETRY").Value.ToString();

                ai.AltLimit_Bottom.Alt = Convert.ToInt64(e.Element("ALTLIMIT_BOTTOM").Element("ALT").Value);
                ai.AltLimit_Top.Alt = Convert.ToInt64(e.Element("ALTLIMIT_TOP").Element("ALT").Value);

                this.Add(ai);
            }

            Console.ReadKey();
        }
    }

    public class Airspace
    {
        public Airspace()
        {
            AltLimit_Top = new AltLimit();
            AltLimit_Bottom = new AltLimit();
        }

        public Category Category { get; set; }
        public string Version { get; set; }
        public Int64 ID { get; set; }
        public string Country { get; set; }
        public string Name { get; set; }
        public AltLimit AltLimit_Top { get; set; }
        public AltLimit AltLimit_Bottom { get; set; }
        public string Geometry { get; set; }
    }

    public class AltLimit
    {
        public Reference Reference { get; set; }
        public Int64 Alt { get; set; }
        public Unit Unit { get; set; }
    }
}
