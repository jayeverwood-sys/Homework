namespace HollowCreek
{
    public class PC
    {
        private string _currentLocName;
        private Inventory _inventory;
        private int _unease;

        public PC()
        {
            _inventory = new Inventory();
            _unease = 0;
        }

        public string GetCurrentLocationName()
        {
            return _currentLocName;
        }

        public void SetCurrentLocationName(string locName)
        {
            _currentLocName = locName;
        }

        public int GetUnease()
        {
            return _unease;
        }

        public void IncreaseUnease(int amount)
        {
            _unease = _unease + amount;
            if (_unease > 100)
            {
                _unease = 100;
            }
        }

        public string GetDescribeUnease()
        {
            if (_unease <= 20)
            {
                return " it's quiet, it leaves you wondering what is around the next corner. But you continue investigating. ";
            }
            else if (_unease <= 40)
            {
                return " you feel your skin start to crawl, as if something is creeping over you. But you continue to investigate.";
            }
            else if (_unease <= 60)
            {
                return " Glancing over your shoulder, you swear you felt something watching you. But you must continue investigating, as if something presses you to.";
            }
            else if (_unease <= 80)
            {
                return "The silence is getting to you more, as if something is holding the air hostage. But you desperately keep searching because you NEED to.";
            }
            else
            {
                return " You're not sure what the noise was, but it wasn't natural.";
            }
        }

        public Inventory GetInventory()
        {
            return _inventory;
        }
    }
}