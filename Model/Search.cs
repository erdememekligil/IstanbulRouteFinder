using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Model
{
    public class Search
    {
        private Route_stops routes_stops = new Route_stops();
        public int stackCallCounter = 0;
        public int memorySize = 0;
        public long time;

        struct Arc
        {
            public int parent;
            public int child;
        }

        struct Node
        {
            public int node;
            public double distance;
        }

        public Solution BFSTreeSearch(int start, int stop)
        {
            List<int> solution = new List<int>();
            List<Arc> arcList = new List<Arc>();
            Queue<int> frontier = new Queue<int>();
            frontier.Enqueue(start);
            bool isFound = false;

            Stopwatch sw = new Stopwatch();
            sw.Start();
            //BFS checks if solution available
            while (isFound == false && frontier.Count != 0)
            {
                int leaf = frontier.Dequeue();
                if (stop == leaf)
                {
                    isFound = true;
                }
                for (int j = 0; j < Route_stops.AllStops.Count; j++)
                {
                    if (Route_stops.StopsGraph[leaf, j] != 0)
                    {
                        frontier.Enqueue(j);
                        Arc arc = new Arc();
                        arc.parent = leaf;
                        arc.child = j;
                        arcList.Add(arc);
                    }
                }
            }
            sw.Stop();
            time = sw.ElapsedMilliseconds;
            memorySize = frontier.Count;
            Console.WriteLine("Memory size:" + memorySize);
            System.IO.File.WriteAllText("output.txt", "Memory size:" + memorySize + "\n");
            Console.WriteLine("Search done in " + sw.ElapsedMilliseconds + " miliseconds = " + sw.Elapsed);
            System.IO.File.AppendAllText("output.txt", "Search done in " + sw.ElapsedMilliseconds + " miliseconds = " + sw.Elapsed);

            //Find Parents
            if (isFound == true)
            {
                Arc arc = arcList.First(a => a.child == stop);
                solution.Add(stop);
                while (arc.parent != start)
                {
                    arc = arcList.First(a => a.child == arc.parent);
                    solution.Add(arc.child);
                }
                solution.Add(start);
                solution.Reverse();
            }
            else return new Solution() { isSolved = false };

            return new Solution(solution, RouteFind.FindRoute(solution));
        }

        public Solution BFSGraphSearch(int start, int stop)
        {
            List<int> solution = new List<int>();
            List<Arc> arcList = new List<Arc>();
            Queue<int> frontier = new Queue<int>();
            frontier.Enqueue(start);
            List<int> explored = new List<int>();
            bool isFound = false;

            Stopwatch sw = new Stopwatch();
            sw.Start();
            //BFS checks if solution available
            while (isFound == false && frontier.Count != 0)
            {
                int leaf = frontier.Dequeue();
                if (stop == leaf)
                {
                    isFound = true;
                }
                explored.Add(leaf);
                for (int j = 0; j < Route_stops.AllStops.Count; j++) //Explore child nodes by looking into StopsGraph
                {
                    if (Route_stops.StopsGraph[leaf, j] != 0 && !explored.Contains(j) && !frontier.Contains(j))
                    {
                        frontier.Enqueue(j);
                        Arc arc = new Arc();
                        arc.parent = leaf;
                        arc.child = j;
                        arcList.Add(arc);
                    }
                }
            }
            sw.Stop();
            time = sw.ElapsedMilliseconds;
            memorySize = frontier.Count + explored.Count;
            Console.WriteLine("Memory size:" + memorySize);
            System.IO.File.WriteAllText("output.txt", "Memory size:" + memorySize + "\n");
            Console.WriteLine("Search done in " + sw.ElapsedMilliseconds + " miliseconds = " + sw.Elapsed);
            System.IO.File.AppendAllText("output.txt", "Search done in " + sw.ElapsedMilliseconds + " miliseconds = " + sw.Elapsed);

            //Find Parents
            if (isFound == true)
            {
                Arc arc = arcList.First(a => a.child == stop);
                solution.Add(stop);
                while (arc.parent != start)
                {
                    arc = arcList.First(a => a.child == arc.parent);
                    solution.Add(arc.child);
                }
                solution.Add(start);
                solution.Reverse();
            }
            else return new Solution() { isSolved = false };

            return new Solution(solution, RouteFind.FindRoute(solution));
        }

        public Solution DFSTreeSearchNonRecursive(int start, int stop)
        {
            List<int> solution = new List<int>();
            List<Arc> arcList = new List<Arc>();
            Stack<int> frontier = new Stack<int>();
            frontier.Push(start);
            bool isFound = false;

            Stopwatch sw = new Stopwatch();
            sw.Start();
            //DFS checks if solution available
            while (isFound == false && frontier.Count != 0)
            {
                if (frontier.Count > 100000)
                {
                    System.IO.File.WriteAllText("output.txt", "Function ended to prevent infinite loop.");
                    return new Solution() { isSolved = false }; //Probably stuck on infinite loop
                }
                int leaf = frontier.Pop();
                if (stop == leaf)
                {
                    isFound = true;
                }
                for (int j = 0; j < Route_stops.AllStops.Count; j++)
                {
                    if (Route_stops.StopsGraph[leaf, j] != 0)
                    {
                        frontier.Push(j);
                        Arc arc = new Arc();
                        arc.parent = leaf;
                        arc.child = j;
                        arcList.Add(arc);
                    }
                }
            }
            sw.Stop();
            time = sw.ElapsedMilliseconds;
            memorySize = frontier.Count;
            Console.WriteLine("Memory size:" + memorySize);
            System.IO.File.WriteAllText("output.txt", "Memory size:" + memorySize + "\n");
            Console.WriteLine("Search done in " + sw.ElapsedMilliseconds + " miliseconds = " + sw.Elapsed);
            System.IO.File.AppendAllText("output.txt", "Search done in " + sw.ElapsedMilliseconds + " miliseconds = " + sw.Elapsed);

            //Find Parents
            if (isFound == true)
            {
                Arc arc = arcList.First(a => a.child == stop);
                solution.Add(stop);
                while (arc.parent != start)
                {
                    arc = arcList.First(a => a.child == arc.parent);
                    solution.Add(arc.child);
                }
                solution.Add(start);
                solution.Reverse();
                //return solution;
            }
            else return new Solution() { isSolved = false };

            return new Solution(solution, RouteFind.FindRoute(solution));
        }

        public Solution DFSGraphSearchNonRecursive(int start, int stop)
        {
            List<int> solution = new List<int>();
            List<Arc> arcList = new List<Arc>();
            Stack<int> frontier = new Stack<int>();
            frontier.Push(start);
            List<int> explored = new List<int>();
            bool isFound = false;

            Stopwatch sw = new Stopwatch();
            sw.Start();
            //DFS checks if solution available
            while (isFound == false && frontier.Count != 0)
            {
                int leaf = frontier.Pop();
                if (stop == leaf)
                {
                    isFound = true;
                }
                explored.Add(leaf);
                for (int j = 0; j < Route_stops.AllStops.Count; j++) //Explore child nodes by looking into StopsGraph
                {
                    if (Route_stops.StopsGraph[leaf, j] != 0 && !explored.Contains(j) && !frontier.Contains(j))
                    {
                        frontier.Push(j);
                        Arc arc = new Arc();
                        arc.parent = leaf;
                        arc.child = j;
                        arcList.Add(arc);
                    }
                }
            }
            sw.Stop();
            time = sw.ElapsedMilliseconds;
            memorySize = frontier.Count + explored.Count;
            Console.WriteLine("Memory size:" + memorySize);
            System.IO.File.WriteAllText("output.txt", "Memory size:" + memorySize + "\n");
            Console.WriteLine("Search done in " + sw.ElapsedMilliseconds + " miliseconds = " + sw.Elapsed);
            System.IO.File.AppendAllText("output.txt", "Search done in " + sw.ElapsedMilliseconds + " miliseconds = " + sw.Elapsed);

            //Find Parents
            if (isFound == true)
            {
                Arc arc = arcList.First(a => a.child == stop);
                solution.Add(stop);
                while (arc.parent != start)
                {
                    arc = arcList.First(a => a.child == arc.parent);
                    solution.Add(arc.child);
                }
                solution.Add(start);
                solution.Reverse();
            }
            else return new Solution() { isSolved = false };

            return new Solution(solution, RouteFind.FindRoute(solution));
        }

        public Solution DFSTreeSearchRecursive(int start, int stop)
        {
            List<int> solution = new List<int>();
            List<Arc> arcList = new List<Arc>();
            Stack<int> frontier = new Stack<int>();
            frontier.Push(start);
            bool isFound = false;

            Stopwatch sw = new Stopwatch();
            sw.Start();
            //DFS checks if solution available
            isFound = DFSTreeRecursive(stop, ref frontier, ref arcList);

            sw.Stop();
            time = sw.ElapsedMilliseconds;
            memorySize = stackCallCounter;
            Console.WriteLine("Memory size:" + memorySize);
            System.IO.File.WriteAllText("output.txt", "Memory size:" + memorySize + "\n");
            Console.WriteLine("Search done in " + sw.ElapsedMilliseconds + " miliseconds = " + sw.Elapsed);
            System.IO.File.AppendAllText("output.txt", "Search done in " + sw.ElapsedMilliseconds + " miliseconds = " + sw.Elapsed);

            //Find Parents
            if (isFound == true)
            {
                Arc arc = arcList.First(a => a.child == stop);
                solution.Add(stop);
                while (arc.parent != start)
                {
                    arc = arcList.First(a => a.child == arc.parent);
                    solution.Add(arc.child);
                }
                solution.Add(start);
                solution.Reverse();
            }
            else return new Solution() { isSolved = false };

            return new Solution(solution, RouteFind.FindRoute(solution));
        }

        private bool DFSTreeRecursive(int stop, ref Stack<int> frontier, ref List<Arc> arcList)
        {
            if (stackCallCounter > 11500)
            {
                System.IO.File.WriteAllText("output.txt", "Function ended to prevent StackOverFlow.");
                return false; //Probably gives stackoverflow error if it goes deeper than this.
            }
            if (frontier.Count == 0)
            {
                return false; // return fail
            }
            int leaf = frontier.Pop();
            if (leaf == stop)
            {
                return true;
            }

            for (int j = 0; j < Route_stops.AllStops.Count; j++)
            {
                if (Route_stops.StopsGraph[leaf, j] != 0)
                {
                    frontier.Push(j);
                    Arc x = new Arc();
                    x.parent = leaf;
                    x.child = j;
                    arcList.Add(x);
                    stackCallCounter++;
                }
            }
            return DFSTreeRecursive(stop, ref frontier, ref arcList);
        }

        public Solution DFSGraphSearchRecursive(int start, int stop)
        {
            List<int> solution = new List<int>();
            List<Arc> arcList = new List<Arc>();
            Stack<int> frontier = new Stack<int>();
            List<int> explored = new List<int>();
            frontier.Push(start);
            bool isFound = false;

            Stopwatch sw = new Stopwatch();
            sw.Start();
            //DFS checks if solution available
            isFound = DFSGraphRecursive(stop, ref frontier, ref arcList, ref explored);

            sw.Stop();
            time = sw.ElapsedMilliseconds;
            memorySize = stackCallCounter;
            Console.WriteLine("Memory size:" + memorySize);
            System.IO.File.WriteAllText("output.txt", "Memory size:" + memorySize + "\n");
            Console.WriteLine("Search done in " + sw.ElapsedMilliseconds + " miliseconds = " + sw.Elapsed);
            System.IO.File.AppendAllText("output.txt", "Search done in " + sw.ElapsedMilliseconds + " miliseconds = " + sw.Elapsed);

            //Find Parents
            if (isFound == true)
            {
                Arc arc = arcList.First(a => a.child == stop);
                solution.Add(stop);
                while (arc.parent != start)
                {
                    arc = arcList.First(a => a.child == arc.parent);
                    solution.Add(arc.child);
                }
                solution.Add(start);
                solution.Reverse();
            }
            else return new Solution() { isSolved = false };

            return new Solution(solution, RouteFind.FindRoute(solution));
        }

        private bool DFSGraphRecursive(int stop, ref Stack<int> frontier, ref List<Arc> arcList, ref List<int> explored)
        {
            if (stackCallCounter > 11500)
            {
                System.IO.File.WriteAllText("output.txt", "Function ended to prevent StackOverFlow.");
                return false; //Probably gives stackoverflow error if it goes deeper than this.
            }
            if (frontier.Count == 0)
            {
                return false; // return fail
            }
            int leaf = frontier.Pop();
            if (leaf == stop)
            {
                return true;
            }
            explored.Add(leaf);

            for (int j = 0; j < Route_stops.AllStops.Count; j++)
            {
                if (Route_stops.StopsGraph[leaf, j] != 0 && !explored.Contains(j) && !frontier.Contains(j))
                {
                    frontier.Push(j);
                    Arc x = new Arc();
                    x.parent = leaf;
                    x.child = j;
                    arcList.Add(x);
                    stackCallCounter++;
                }
            }
            return DFSGraphRecursive(stop, ref frontier, ref arcList, ref explored);
        }

        public Solution Astar(int start, int stop)
        {
            List<int> solution = new List<int>();
            List<Arc> arcList = new List<Arc>();
            List<Node> frontier = new List<Node>();
            frontier.Add(new Node() { node = start, distance = Route_stops.StopDistance(start, stop) });
            List<int> explored = new List<int>();
            bool isFound = false;

            Stopwatch sw = new Stopwatch();
            sw.Start();
            //A* checks if solution available
            while (isFound == false && frontier.Count != 0)
            {
                frontier = frontier.OrderBy(c => c.distance).ToList(); //Select with least f(x)= h(x) + g(x)
                Node leafNode = frontier.First();
                int leaf = leafNode.node;
                frontier.Remove(leafNode);
                if (stop == leaf)
                {
                    isFound = true;
                }
                else
                {
                    explored.Add(leaf);
                    List<Node> children = new List<Node>();
                    for (int j = 0; j < Route_stops.AllStops.Count; j++) //Explore child nodes by looking into StopsGraph
                    {
                        if (Route_stops.StopsGraph[leaf, j] != 0 && !explored.Contains(j) && !frontier.Any(f => f.node == j))
                        {
                            double distanceUntilThisNode = 0; //heuristic

                            if (arcList.Count != 0 && explored.Count > 1)
                            {
                                Arc arc = arcList.First(a => a.child == leaf);
                                distanceUntilThisNode += Route_stops.StopsGraph[arc.child, arc.parent];
                                while (arc.parent != start)
                                {
                                    arc = arcList.First(a => a.child == arc.parent);
                                    distanceUntilThisNode += Route_stops.StopsGraph[arc.child, arc.parent];
                                }
                            }
                            frontier.Add(new Node() { node = j, distance = Route_stops.StopsGraph[leaf, j] + distanceUntilThisNode + Route_stops.StopDistance(j, stop) }); // = DistanceUntilThisNode + FlyByToDestination
                            Arc arcAdd = new Arc();
                            arcAdd.parent = leaf;
                            arcAdd.child = j;
                            arcList.Add(arcAdd);
                        }
                    }
                }
            }

            sw.Stop();
            time = sw.ElapsedMilliseconds;
            memorySize = frontier.Count + explored.Count;
            Console.WriteLine("Memory size:" + memorySize);
            System.IO.File.WriteAllText("output.txt", "Memory size:" + memorySize + "\n");
            Console.WriteLine("Search done in " + sw.ElapsedMilliseconds + " miliseconds = " + sw.Elapsed);
            System.IO.File.AppendAllText("output.txt", "Search done in " + sw.ElapsedMilliseconds + " miliseconds = " + sw.Elapsed);

            //Find Parents
            if (isFound == true)
            {
                Arc arc = arcList.First(a => a.child == stop);
                solution.Add(stop);
                while (arc.parent != start)
                {
                    arc = arcList.First(a => a.child == arc.parent);
                    solution.Add(arc.child);
                }
                solution.Add(start);
                solution.Reverse();
            }
            else return new Solution() { isSolved = false };

            return new Solution(solution, RouteFind.FindRoute(solution));
        }

        public Solution AstarLeastRoute(int start, int stop)
        {
            List<int> solution = new List<int>();
            List<Arc> arcList = new List<Arc>();
            List<Node> frontier = new List<Node>();
            frontier.Add(new Node() { node = start, distance = Route_stops.StopDistance(start, stop) });
            List<int> explored = new List<int>();
            bool isFound = false;

            Stopwatch sw = new Stopwatch();
            sw.Start();
            //A* checks if solution available
            while (isFound == false && frontier.Count != 0)
            {
                frontier = frontier.OrderBy(c => c.distance).ToList(); //Select with least f(x)= h(x) + g(x)
                Node leafNode = frontier.First();
                int leaf = leafNode.node;
                frontier.Remove(leafNode);
                if (stop == leaf)
                {
                    isFound = true;
                }
                else
                {
                    explored.Add(leaf);
                    List<Node> children = new List<Node>();
                    for (int j = 0; j < Route_stops.AllStops.Count; j++) //Explore child nodes by looking into StopsGraph
                    {
                        if (Route_stops.StopsGraph[leaf, j] != 0 && !explored.Contains(j) && !frontier.Any(f => f.node == j))
                        {
                            double distanceUntilThisNode = 0;

                            if (arcList.Count != 0 && explored.Count > 1)
                            {
                                List<int> tempStopList = new List<int>();

                                tempStopList.Add(j);
                                tempStopList.Add(leaf);
                                Arc arc = arcList.First(a => a.child == leaf);
                                while (arc.parent != start)
                                {
                                    arc = arcList.First(a => a.child == arc.parent);
                                    tempStopList.Add(arc.child);
                                }
                                tempStopList.Add(start);
                                tempStopList.Reverse();
                                distanceUntilThisNode = RouteFind.FindRoute(tempStopList).Count;
                            }
                            frontier.Add(new Node() { node = j, distance = distanceUntilThisNode }); // = h(n)
                            Arc arcAdd = new Arc();
                            arcAdd.parent = leaf;
                            arcAdd.child = j;
                            arcList.Add(arcAdd);
                        }
                    }
                }
            }

            sw.Stop();
            time = sw.ElapsedMilliseconds;
            memorySize = frontier.Count + explored.Count;
            Console.WriteLine("Memory size:" + memorySize);
            System.IO.File.WriteAllText("output.txt", "Memory size:" + memorySize + "\n");
            Console.WriteLine("Search done in " + sw.ElapsedMilliseconds + " miliseconds = " + sw.Elapsed);
            System.IO.File.AppendAllText("output.txt", "Search done in " + sw.ElapsedMilliseconds + " miliseconds = " + sw.Elapsed);

            //Find Parents
            if (isFound == true)
            {
                Arc arc = arcList.First(a => a.child == stop);
                solution.Add(stop);
                while (arc.parent != start)
                {
                    arc = arcList.First(a => a.child == arc.parent);
                    solution.Add(arc.child);
                }
                solution.Add(start);
                solution.Reverse();
            }
            else return new Solution() { isSolved = false };

            return new Solution(solution, RouteFind.FindRoute(solution));
        }
        
    }
}
