namespace HollowCreek
{
    public class Items : Discoverable
    {
        private bool _Takeit;

        public Items(string name, string description, bool takeit) : base(name, description)
        {
            _Takeit = takeit;
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
            return "You take the " + GetName() + ".";
        }
    }
}