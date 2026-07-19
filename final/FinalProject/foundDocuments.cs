using System.Collections.Generic;

namespace HollowCreek
{
    public class foundDocuments : Discoverable
    {
        private string _bodyofit;
        private bool _finalLetter;
        private List<string> _keyofWords;

        public foundDocuments(string name, string description, string bodyofit, List<string> keyofWords, bool finalLetter)
            : base(name, description)
        {
            _bodyofit = bodyofit;
            _keyofWords = keyofWords;
            _finalLetter = finalLetter;
        }

        public string GetBodyBody()
        {
            return _bodyofit;
        }

        public bool TheFinalLetter()
        {
            return _finalLetter;
        }

        public bool keyofWordsMatch(string target)
        {
            foreach (string keyword in _keyofWords)
            {
                if (keyword == target)
                {
                    return true;
                }
            }
            return false;
        }

        public override string Interact(PC player)
        {
            player.GetInventory().Store(this);
            return _bodyofit;
        }

        public override string GetDesText()
        {
            return GetName() + " (can be read)";
        }
    }
}