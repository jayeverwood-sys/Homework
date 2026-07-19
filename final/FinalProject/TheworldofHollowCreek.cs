using System.Collections.Generic;

namespace HollowCreek
{
    public class TheworldofHollowCreek
    {
        private Dictionary<string, Location> _locations;
        private string _startLocationName;

        public TheworldofHollowCreek()
        {
            _locations = new Dictionary<string, Location>();
        }

        public void AddLocation(Location location)
        {
            _locations.Add(location.GetName(), location);
        }

        public Location GetLocation(string name)
        {
            if (_locations.ContainsKey(name))
            {
                return _locations[name];
            }
            return null;
        }

        public string GetStartLocationName()
        {
            return _startLocationName;
        }

        public void SetStartLocationName(string name)
        {
            _startLocationName = name;
        }
    }
}