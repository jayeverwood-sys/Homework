using System.Collections.Generic;

namespace HollowCreek
{
    public class Journal
    {
        private List<foundDocuments> _readDocuments;

        public Journal()
        {
            _readDocuments = new List<foundDocuments>();
        }

        public bool HasRead(foundDocuments document)
        {
            foreach (foundDocuments entry in _readDocuments)
            {
                if (entry.GetName() == document.GetName())
                {
                    return true;
                }
            }
            return false;
        }

        public void AddEntry(foundDocuments document)
        {
            if (!HasRead(document))
            {
                _readDocuments.Add(document);
            }
        }

        public List<foundDocuments> GetReadDocuments()
        {
            return new List<foundDocuments>(_readDocuments);
        }

        public foundDocuments FindByKeyofWords(string target)
        {
            foreach (foundDocuments document in _readDocuments)
            {
                if (document.keyofWordsMatch(target))
                {
                    return document;
                }
            }
            return null;
        }

        public string GetSummary()
        {
            if (_readDocuments.Count == 0)
            {
                return "Haven't found anything notable yet to fill your journal.";
            }
            string text = " == Journal entries ==";
            foreach (foundDocuments document in _readDocuments)
            {
                text = text + "\n Title :" + document.GetName();
            }
            return text;
        }
    }
}