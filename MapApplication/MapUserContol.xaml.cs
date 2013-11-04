using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Maps.MapControl.WPF;
using System.ComponentModel;

namespace MapApplication
{
    /// <summary>
    /// Interaction logic for MapUserControl.xaml
    /// </summary>
    public partial class MapUserControl : UserControl
    {
        public MapUserControl()
        {
            InitializeComponent();
            ZoomBar.Value = 12;
        }

        private void PanMap_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            Point p;

            MyMap.TryLocationToViewportPoint(MyMap.Center, out p);

            if (p != null)
            {
                switch (b.Tag as string)
                {
                    case "Up":
                        p.Y -= 50;
                        break;
                    case "Down":
                        p.Y += 50;
                        break;
                    case "Left":
                        p.X -= 50;
                        break;
                    case "Right":
                        p.X += 50;
                        break;
                }

                Microsoft.Maps.MapControl.WPF.Location l;
                MyMap.TryViewportPointToLocation(p, out l);
                MyMap.SetView(l, MyMap.ZoomLevel);
            }
        }

        public void AddPushpin(Location latlong, string title, string description)
        {
            Pushpin p = new Pushpin()
            {
                Location = latlong,
                Tag = new Metadata()
                {
                    Title = title,
                    Description = description
                }
            };

            p.MouseDown += PinClicked;
            //MyMap.Children.Add(p);
            DataLayer.Children.Add(p);
        }

        private void PinClicked(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Pushpin p = sender as Pushpin;
            Metadata m = (Metadata)p.Tag;

            //Ensure there is content to be displayed before modifying the infobox control
            if (!String.IsNullOrEmpty(m.Title) || !String.IsNullOrEmpty(m.Description))
            {
                InfoboxTitle.Text = m.Title;
                InfoboxDescription.Text = m.Description;

                Infobox.Visibility = Visibility.Visible;

                MapLayer.SetPosition(Infobox, p.Location);
            }
        }

        private void CloseInfobox_Click(object sender, RoutedEventArgs e)
        {
            Infobox.Visibility = System.Windows.Visibility.Collapsed;
        }

        /// <summary>
        /// Simple class for storing pushpin information
        /// </summary>
        public struct Metadata
        {
            public string Title;
            public string Description;
        }
    }
}
