using System.Collections.Generic;

namespace HollowCreek
{
    public class Location
    {
        private string _name;
        private string _description;
        private Dictionary<string, string> _exits;
        private List<Discoverable> _contents;
        private bool _locked;
        private string _ItemName;

        public Location(string name, string description)
        {
            _name = name;
            _description = description;
            _exits = new Dictionary<string, string>();
            _contents = new List<Discoverable>();
            _locked = false;
            _ItemName = "";
        }

        public string GetName()
        {
            return _name;
        }

        public string GetDescription()
        {
            return _description;
        }

        public void AddExit(string direction, string destinationLocationName)
        {
            _exits.Add(direction, destinationLocationName);
        }

        public bool HasanExit(string direction)
        {
            return _exits.ContainsKey(direction);
        }

        public string GetExitDestination(string direction)
        {
            return _exits[direction];
        }

        public Dictionary<string, string> GetExits()
        {
            return _exits;
        }

        public void AddObject(Discoverable obj)
        {
            _contents.Add(obj);
        }

        public void RemoveObject(Discoverable obj)
        {
            _contents.Remove(obj);
        }

        public Discoverable FindObj(string name)
        {
            foreach (Discoverable obj in _contents)
            {
                if (obj.GetName().ToLower() == name.ToLower())
                {
                    return obj;
                }
            }
            return null;
        }

        public bool Locked()
        {
            return _locked;
        }

        public void SetLocked(bool locked)
        {
            _locked = locked;
        }

        public string GetItemName()
        {
            return _ItemName;
        }

        public void SetItemName(string itemname)
        {
            _ItemName = itemname;
        }

        public List<Discoverable> Getcontents()
        {
            return new List<Discoverable>(_contents);
        }

        public string GetEntireDes()
        {
            string text = _description;

            if (_exits.Count > 0)
            {
                text = text + "\n\nExits:";
                foreach (string direction in _exits.Keys)
                {
                    text = text + " " + direction;
                }
            }
            return text;
        }
    }
}