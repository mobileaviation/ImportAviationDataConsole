using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace osmLib
{
    public class Node
    {
        public Node()
        {
            tags = new List<Tag>();
        }

        public List<Tag> tags;
        public void AddTag(String k, String v)
        {
            Tag t = new Tag();
            t.k = k;
            t.v = v;
            Console.WriteLine("Tag Added:  K:" + t.k + " : V:" + t.v);
            tags.Add(t);
        }

        public Int64 id { get; set; }
        public double lat { get; set; }
        public double lon { get; set; }
        public Int64 version { get; set; }
        public DateTime timestamp { get; set; }
        public Int64 changeset { get; set; }
        public Int64 uid { get; set; }
        public String user { get; set; }
        public Boolean visible { get; set; }
    }

    public class Tag
    {
        public String k { get; set; }
        public String v { get; set; }
    }
}
