using System;

namespace HollowCreek
{
    public abstract class Discoverable
    {
        private string _name;
        private string _description;

        public Discoverable(string name, string description)
        {
            _name = name;
            _description = description;
        }

        public string GetName()
        {
            return _name;
        }

        public string GetDescription()
        {
            return _description;
        }

        public abstract string Interact(PC player);

        public virtual string GetDesText()
        {
            return _name;
        }
    }
}