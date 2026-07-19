using System;

namespace HollowCreek
{
    public class Commandsparsed
    {
        private string _verb;
        private string _target;

        public Commandsparsed(string verb, string target)
        {
            _verb = verb;
            _target = target;
        }

        public string GetVerb()
        {
            return _verb;
        }

        public string GetTarget()
        {
            return _target;
        }
    }

    public class Commands
    {
        public Commandsparsed Parse(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return new Commandsparsed("", "");
            }
            input = input.Trim().ToLower();
            string[] parts = input.Split(new[] { ' ' }, 2, StringSplitOptions.RemoveEmptyEntries);
            string verb = "";
            string target = "";

            if (parts.Length > 0)
            {
                verb = parts[0];
            }
            if (parts.Length > 1)
            {
                target = parts[1];
            }

            if (verb == "n") { verb = "go"; target = "north"; }
            else if (verb == "e") { verb = "go"; target = "east"; }
            else if (verb == "s") { verb = "go"; target = "south"; }
            else if (verb == "w") { verb = "go"; target = "west"; }
            else if (verb == "c") { verb = "check"; }
            else if (verb == "i") { verb = "inventory"; }

            return new Commandsparsed(verb, target);
        }
    }
}