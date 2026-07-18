using System;

namespace HollowCreek
{
    public class Items : Object
    {
        private bool _Takeit;

        public Items(string name, string description)
        {
            _Takeit = Takeit;
        }
        public bool canTakeit()
        {
            return _Takeit;
        }

        public override string Interact(PC player)
        {
           if (!_Takeit)
            {
                return " You tried to grab it but something in you tells you to leave it.";
            }
            player.GetInventory().Store(this);
            return "You take the "+GetName()+ ".";
        }
    }
}