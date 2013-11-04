using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Route_stops
    {
        static public List<Route> AllRoutes; // AllRoutes[i].id = i  , AllRoutes[0] is empty
        static public List<Stop> AllStops; // AllStops[i].id = i  , AllStops[0] is empty
        static public List<List<int>> RoutesWithStops; //Contains routes' stop information, 0 is empty
        static public double[,] StopsGraph;

        public Route_stops()
        {
            if (AllStops == null)
            {
                read_routes();
                read_stops();
                read_route_stops();
                Console.WriteLine("Reading from files completed.");
            }
        }

        //Reads routes.csv and fills AllRoutes List
        private void read_routes()
        {
            try
            {
                string line;
                System.IO.StreamReader file = new System.IO.StreamReader("./routes.csv");
                AllRoutes = new List<Route>();
                AllRoutes.Add(new Route());
                while ((line = file.ReadLine()) != null)
                {
                    string[] elements = line.Split(',');
                    Route newRoute = new Route(int.Parse(elements[0]), elements[1]);
                    AllRoutes.Add(newRoute);
                }
                file.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        
        //Reads route_stops.csv. Fills StopsGraph and RoutesWithStops
        private void read_route_stops()
        {
            try
            {
                string line;
                System.IO.StreamReader file = new System.IO.StreamReader("./route_stops.csv");

                StopsGraph = new double[AllStops.Count,AllStops.Count];
                RoutesWithStops = new List<List<int>>();
                List<int> route = new List<int>();

                int routeIndex , oldRouteIndex = 0, stopIndex, oldStopIndex = 0;
                while ((line = file.ReadLine()) != null)
                {
                    string[] elements = line.Split(',');
                    routeIndex = int.Parse(elements[0]);
                    stopIndex = int.Parse(elements[1]);

                    if (routeIndex == oldRouteIndex) //Add to current route
                    {
                        route.Add(stopIndex);
                        StopsGraph[stopIndex, oldStopIndex] = StopDistance(stopIndex, oldStopIndex);
                        StopsGraph[oldStopIndex, stopIndex] = StopsGraph[stopIndex, oldStopIndex]; 
                    }
                    else if (routeIndex == oldRouteIndex + 1) //Add to new route
                    {
                        RoutesWithStops.Add(route);
                        route = new List<int>();
                        route.Add(stopIndex);
                    }
                    else 
                    {
                        RoutesWithStops.Add(route);

                        //add empty lists for emtpy routes
                        for (int i = oldRouteIndex; i < routeIndex-1; i++)
                        {
                            route = new List<int>();
                            RoutesWithStops.Add(route);
                        }

                        //same as above
                        route = new List<int>();
                        route.Add(stopIndex);
                    }
                    
                    oldRouteIndex = routeIndex;
                    oldStopIndex = stopIndex;
                }
                RoutesWithStops.Add(route);
                file.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        
        //Reads stops.csv and fills AllStops List
        private void read_stops()
        {
            try
            {
                string line;
                System.IO.StreamReader file = new System.IO.StreamReader("./stops.csv");
                AllStops = new List<Stop>();
                AllStops.Add(new Stop());
                while ((line = file.ReadLine()) != null)
                {
                    string[] elements = line.Split(',');
                    Stop newStop = new Stop(int.Parse(elements[0]), double.Parse(elements[1], System.Globalization.CultureInfo.InvariantCulture),
                        double.Parse(elements[2], System.Globalization.CultureInfo.InvariantCulture), elements[3]);
                    AllStops.Add(newStop);
                }
                file.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        //Returns fly-by distance between two stops.
        static public double StopDistance(int stop1, int stop2)
        {
            return AllStops[stop1].Distance(AllStops[stop2]);
        }

    }
}
