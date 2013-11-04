using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Route
    {
        public int id { get; set; }
        public string name { get; set; }

        public Route()
        {
        }

        public Route(int nid, string nname)
        {
            id = nid;
            name = nname;
        }
    }
}
