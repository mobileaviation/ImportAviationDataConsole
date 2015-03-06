using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace osmLib
{
    public class Way
    {
        public Way()
        {
            tags = new List<Tag>();
            nds = new List<Nd>();
        }

        private List<Tag> tags;
        private List<Nd> nds;

        public Int64 id { get; set; }
        public Int64 version { get; set; }
        public DateTime timestamp { get; set; }
        public Int64 changeset { get; set; }
        public Int64 uid { get; set; }
        public String  user { get; set; }
        
        public void AddTag(String k, String v)
        {
            Tag t = new Tag();
            t.k = k;
            t.v = v;
            Console.WriteLine("Tag Added:  K:" + t.k + " : V:" + t.v);
            tags.Add(t);
        }

        public void AddNd(Int64 r)
        {
            Nd t = new Nd();
            t.Ref = r;
            Console.WriteLine("ND Added:  Ref:" + t.Ref.ToString());
            nds.Add(t);
        }

        
    }

    public class Nd
    {
        public Int64 Ref { get; set; }
    }
}
