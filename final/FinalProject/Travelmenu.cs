using System;
using System.Collections.Generic;

namespace HollowCreek
{
    public class Travelmenu
    {
        private Location _location;

        public Travelmenu(Location location)
        {
            _location = location;
        }

        public bool Show(PC player)
        {
            bool exploring = true;
            bool endingWasTriggered = false;

            while (exploring)
            {
                List<Discoverable> contents = _location.Getcontents();

                Console.WriteLine();
                Console.WriteLine("You wonder what to do to start off investigating?");

                int optionNum = 1;
                foreach (Discoverable obj in contents)
                {
                    Console.WriteLine(optionNum + ". " + obj.GetDesText());
                    optionNum++;
                }

                int leaveoptionNum = optionNum;
                Console.WriteLine(leaveoptionNum + ". Leave and head back outside");

                Console.Write("> ");
                string input = Console.ReadLine();

                int choice;
                bool typedNum = int.TryParse(input, out choice);

                if (!typedNum)
                {
                    Console.WriteLine("(Type a number to choose an option.)");
                }
                else if (choice == leaveoptionNum)
                {
                    exploring = false;
                }
                else if (choice >= 1 && choice < leaveoptionNum)
                {
                    Discoverable chosen = contents[choice - 1];
                    bool wasAlreadyKnown = false;

                    if (chosen is foundDocuments)
                    {
                        foundDocuments document = (foundDocuments)chosen;
                        wasAlreadyKnown = player.GetInventory().GetJournal().HasRead(document);
                    }
                    string message = chosen.Interact(player);
                    Console.WriteLine();
                    Console.WriteLine(message);

                    if (chosen is Items)
                    {
                        Items item = (Items)chosen;
                        if (item.canTakeit())
                        {
                            _location.RemoveObject(item);
                        }
                    }
                    if (chosen is foundDocuments && !wasAlreadyKnown)
                    {
                        foundDocuments document = (foundDocuments)chosen;
                        player.IncreaseUnease(8);

                        if (document.TheFinalLetter())
                        {
                            endingWasTriggered = true;
                            exploring = false;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("You look around but it doesn't seem to be an option in this town.");
                }
            }
            return endingWasTriggered;
        }
    }
}