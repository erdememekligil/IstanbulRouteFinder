using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Solution
    {
        public bool isSolved;
        public List<Stop> stops;
        public List<Route> routes;

        public Solution()
        {
        }

        public Solution(List<int> intStops, List<Route> nRoutes){
            routes = nRoutes;
            isSolved = true;
            stops = new List<Stop>();

            foreach (int s in intStops)
            {
                stops.Add(Route_stops.AllStops[s]);
            }
            logFileCreate();
        }

        private void logFileCreate()
        {
            string logFile = "output.txt";
            File.AppendAllText(logFile, "\n---------Stops---------\n");
            File.AppendAllText(logFile, "Stop id, Stop name\n");

            using (StreamWriter file = new StreamWriter(logFile,true))
            {
                foreach (Stop s in stops)
                {
                    file.WriteLine(s.id + " " + s.name);
                }
            }

            File.AppendAllText(logFile, "---------Routes---------\n");
            File.AppendAllText(logFile, "Route id, Route name\n");


            using (StreamWriter file = new StreamWriter(logFile, true))
            {
                foreach (Route r in routes)
                {
                    file.WriteLine(r.id + " " + r.name);
                }
            }
        }
    }
}
