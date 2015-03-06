using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

namespace osmLib
{
    public class OsmReader
    {
        public OsmReader()
        {
            nodes = new List<Node>();
            ways = new List<Way>();
        }

        private List<Node> nodes;
        private List<Way> ways;

        public void readOsmFile(string Filename)
        {
            XmlReader xmlReader = XmlReader.Create(Filename);
            while (xmlReader.Read())
            {
                readNodes(xmlReader);
                readWays(xmlReader);
            }
        }

        private void readWays(XmlReader xmlReader)
        {
            if (xmlReader.Name == "way")
            {
                if (xmlReader.HasAttributes)
                {
                    Way n = new Way();
                    n.id = Convert.ToInt64(xmlReader.GetAttribute("id"));
                    n.version = Convert.ToInt64(xmlReader.GetAttribute("version"));
                    n.timestamp = Convert.ToDateTime(xmlReader.GetAttribute("timestamp"));
                    n.uid = Convert.ToInt64(xmlReader.GetAttribute("uid"));
                    n.changeset = Convert.ToInt64(xmlReader.GetAttribute("changeset"));
                    n.user = xmlReader.GetAttribute("user");

                    Console.WriteLine("Way: " + n.id.ToString());

                    TextReader sr = new StringReader(xmlReader.ReadOuterXml());
                    XmlReader tagReader = XmlReader.Create(sr);
                    while (tagReader.Read())
                    {
                        if (tagReader.Name == "tag")
                        {
                            n.AddTag(tagReader.GetAttribute("k"), tagReader.GetAttribute("v"));
                        }
                        if (tagReader.Name == "nd")
                        {
                            n.AddNd(Convert.ToInt64(tagReader.GetAttribute("ref")));
                        }
                    }

                    ways.Add(n);
                }
            }
        }

        private void readNodes(XmlReader xmlReader)
        {
            if (xmlReader.Name == "node")
            {
                if (xmlReader.HasAttributes)
                {
                    Node n = new Node();
                    n.id = Convert.ToInt64(xmlReader.GetAttribute("id"));
                    n.lat = Convert.ToDouble(xmlReader.GetAttribute("lat"));
                    n.lon = Convert.ToDouble(xmlReader.GetAttribute("lon"));
                    n.version = Convert.ToInt64(xmlReader.GetAttribute("version"));
                    n.timestamp = Convert.ToDateTime(xmlReader.GetAttribute("timestamp"));
                    n.uid = Convert.ToInt64(xmlReader.GetAttribute("uid"));
                    n.changeset = Convert.ToInt64(xmlReader.GetAttribute("changeset"));
                    n.user = xmlReader.GetAttribute("user");
                    n.visible = true;

                    Console.WriteLine("Lat: " + n.lat.ToString() +
                           " lon:" + n.lon.ToString());

                    TextReader sr = new StringReader(xmlReader.ReadOuterXml());
                    XmlReader tagReader = XmlReader.Create(sr);
                    while (tagReader.Read())
                    {
                        if (tagReader.Name == "tag")
                        {
                            n.AddTag(tagReader.GetAttribute("k"), tagReader.GetAttribute("v"));
                        }
                    }

                    nodes.Add(n);
                }
            }
        }
    }
}
