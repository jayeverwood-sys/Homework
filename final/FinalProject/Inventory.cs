using System.Collections.Generic;

namespace HollowCreek
{
    public class Inventory
    {
        private List<Items> _item;
        private Journal _journal;

        public Inventory()
        {
            _item = new List<Items>();
            _journal = new Journal();
        }

        public List<Items> GetItems()
        {
            return new List<Items>(_item);
        }

        public Journal GetJournal()
        {
            return _journal;
        }

        public void Store(Discoverable obj)
        {
            if (obj is Items)
            {
                Items item = (Items)obj;
                if (!_item.Contains(item))
                {
                    _item.Add(item);
                }
            }
            else if (obj is foundDocuments)
            {
                foundDocuments document = (foundDocuments)obj;
                _journal.AddEntry(document);
            }
        }

        public bool HasItem(string itemname)
        {
            foreach (Items item in _item)
            {
                if (item.GetName().ToLower() == itemname.ToLower())
                {
                    return true;
                }
            }
            return false;
        }

        public string GetSummary()
        {
            if (_item.Count == 0)
            {
                return " You thought there was something in your bag but it was all in your head.";
            }
            string text = "Checking your bag, you're carrying: ";
            foreach (Items item in _item)
            {
                text = text + "\n " + item.GetName();
            }
            return text;
        }
    }
}