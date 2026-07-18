using System;

namespace HollowCreek
{
    public abstract class Object
    {
        private string _name;
        private string _description;
        public Object(string name, string description)
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

        public abstract string Interact(Player player);

        public virtual string GetDesText()
        {
            return _name;
        }
    }
}