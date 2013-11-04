using System.Windows.Forms;
using Microsoft.Maps.MapControl.WPF;
using Model;
using System.Windows.Documents;
using System.Collections.Generic;
using System;
using System.Windows;

namespace MapApplication
{
    public partial class Form1 : Form
    {
        Search src = new Search();
        bool clearMap = false;

        class SearchType
        {
            public int id { get; set; }
            public string name { get; set; }
        }

        public Form1()
        {
            try
            {

                InitializeComponent();

                //Set Credentials for map
                MyMapUserControl.MyMap.CredentialsProvider = new ApplicationIdCredentialsProvider("AkPH2143BSEA_9eIVgTqOvSgVUwI7ddgTa39vVjqow_m5_MARIXVMiJ7s3DsMiFS");

                List<Stop> destSrc = new List<Stop>(Route_stops.AllStops);

                comboBoxSource.DataSource = Route_stops.AllStops;
                comboBoxSource.DisplayMember = "name";
                comboBoxSource.ValueMember = "id";

                comboBoxDestination.DataSource = destSrc;
                comboBoxDestination.DisplayMember = "name";
                comboBoxDestination.ValueMember = "id";

                List<SearchType> types = new List<SearchType>();
                types.Add(new SearchType() { id = 1, name = "BFS Tree" });
                types.Add(new SearchType() { id = 2, name = "BFS Graph" });
                types.Add(new SearchType() { id = 3, name = "DFS Tree(Recursive)" });
                types.Add(new SearchType() { id = 4, name = "DFS Graph(Recursive)" });
                types.Add(new SearchType() { id = 5, name = "DFS Tree(Non-recursive)" });
                types.Add(new SearchType() { id = 6, name = "DFS Graph(Non-ecursive)" });
                types.Add(new SearchType() { id = 7, name = "A* With Least Route Heuristic" });
                types.Add(new SearchType() { id = 8, name = "A* Search" });

                types.Reverse();
                searchMethod.DataSource = types;
                searchMethod.DisplayMember = "name";
                searchMethod.ValueMember = "id";
            }
            catch(Exception e)
            {
                notification.Text = "CSV files must be in the same directory with exe file. " + e.Message;
            }
        }

        private void searchButton_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (comboBoxSource.SelectedValue != null && comboBoxDestination.SelectedValue != null && (int)comboBoxDestination.SelectedValue != 0 && (int)comboBoxSource.SelectedValue != 0)
                {
                    if (clearMap)
                    {
                        routes.DataSource = null;
                        routes.Items.Clear();
                        MyMapUserControl.DataLayer.Children.Clear();
                        MyMapUserControl.MyMap.Children.RemoveAt(2);
                    }
                    pleaseWait.Visible = true;

                    Solution result = new Solution();
                    switch ((int)searchMethod.SelectedValue)
                    {
                        case 1:
                            result = src.BFSTreeSearch((int)comboBoxSource.SelectedValue, (int)comboBoxDestination.SelectedValue);
                            break;
                        case 2:
                            result = src.BFSGraphSearch((int)comboBoxSource.SelectedValue, (int)comboBoxDestination.SelectedValue);
                            break;
                        case 3:
                            result = src.DFSTreeSearchRecursive((int)comboBoxSource.SelectedValue, (int)comboBoxDestination.SelectedValue);
                            break;
                        case 4:
                            result = src.DFSGraphSearchRecursive((int)comboBoxSource.SelectedValue, (int)comboBoxDestination.SelectedValue);
                            break;
                        case 5:
                            result = src.DFSTreeSearchNonRecursive((int)comboBoxSource.SelectedValue, (int)comboBoxDestination.SelectedValue);
                            break;
                        case 6:
                            result = src.DFSGraphSearchNonRecursive((int)comboBoxSource.SelectedValue, (int)comboBoxDestination.SelectedValue);
                            break;
                        case 7:
                            result = src.AstarLeastRoute((int)comboBoxSource.SelectedValue, (int)comboBoxDestination.SelectedValue);
                            break;
                        case 8:
                            result = src.Astar((int)comboBoxSource.SelectedValue, (int)comboBoxDestination.SelectedValue);
                            break;
                        default:
                            break;
                    }

                    if (result.isSolved)
                    {
                        LocationCollection locColl = new LocationCollection();
                        double totalDistance = 0;
                        Stop before = null;
                        foreach (Stop s in result.stops)
                        {
                            MyMapUserControl.AddPushpin(new Location(s.latitude, s.longitude), "" + s.id, s.name);
                            locColl.Add(new Location(s.latitude, s.longitude));
                            if (before != null)
                                totalDistance += s.Distance(before);
                            before = s;
                        }

                        double zoom = 12;
                        MyMapUserControl.MyMap.SetView(new Location(result.stops[0].latitude, result.stops[0].longitude), zoom);

                        MapPolyline polyline = new MapPolyline();
                        polyline.Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Blue);
                        polyline.StrokeThickness = 5;
                        polyline.Opacity = 0.7;
                        polyline.Locations = locColl;

                        MyMapUserControl.MyMap.Children.Add(polyline);

                        clearMap = true;
                        routes.DataSource = result.routes;
                        routes.DisplayMember = "name";
                        routes.ValueMember = "id";
                        distanceLabel.Text = "Total Distance (meters): " + (int)totalDistance;
                        timeLabel.Text = "Total Time (miliseconds): " + src.time;
                        notification.Text = "Problem solved.";
                        memorySizeLabel.Text = "Memory Size: " + src.memorySize;
                    }
                    else
                    {
                        notification.Text = "Problem cannot be solved.";
                    }
                }
            }
            catch (Exception ex)
            {
                notification.Text = ex.Message;
            }
            finally
            {
                pleaseWait.Visible = false;
            }
        }

    }
}
