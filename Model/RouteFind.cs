using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class RouteFind
    {
        //Finds routes fit to the path.
        static public List<Route> FindRoute(List<int> solutionOnlyStops)
        {
            List<Route> routeSol = new List<Route>();
            
            for (int i = 0; i < solutionOnlyStops.Count-1; i++)
            {
                //select 2 stops and find route between them
                int a = solutionOnlyStops[i];
                int b = solutionOnlyStops[i + 1];
                bool found = false;

                int routeID = 0;
                foreach (List<int> row in Route_stops.RoutesWithStops)
                {
                    
                    for (int j = 0; j < row.Count-1; j++)
                    {
                        if ((row[j] == a && row[j + 1] == b) || (row[j] == b && row[j + 1] == a))
                        {
                            found = true;
                            if (routeSol.Count == 0 || routeSol.Last().id != routeID) //If the route is same as before, dont add.
                                routeSol.Add(Route_stops.AllRoutes[routeID]);
                        }
                        if (found == true) break;
                    }
                    if (found == true) break;

                    routeID++;
                }
            }
            
            return routeSol;
        }
    }
}
