using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Stop
    {
        public int id { get; set; }
        public string name { get; set; }
        public double latitude;
        public double longitude;

        public Stop()
        {

        }

        public Stop(int nid, double nlatitude, double nlongitude, string nname)
        {
            id = nid;
            latitude = nlatitude;
            longitude = nlongitude;
            name = nname;
        }

        public double Distance(Stop other)
        {
            var sCoord = new System.Device.Location.GeoCoordinate(latitude, longitude);
            var eCoord = new System.Device.Location.GeoCoordinate(other.latitude, other.longitude);

            return sCoord.GetDistanceTo(eCoord);
        }
    }
}
