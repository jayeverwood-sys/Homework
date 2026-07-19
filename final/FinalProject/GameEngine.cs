using System;
using System.Collections.Generic;

namespace HollowCreek
{
    public class GameEngine
    {
        private TheworldofHollowCreek _world;
        private PC _player;
        private Commands _parser;
        private Saveit _saveManager;
        private bool _running;

        private Dictionary<string, Items> _itemCatalog;
        private Dictionary<string, foundDocuments> _documentCatalog;

        public GameEngine()
        {
            _world = new TheworldofHollowCreek();
            _player = new PC();
            _parser = new Commands();
            _saveManager = new Saveit();
            _running = true;
            _itemCatalog = new Dictionary<string, Items>();
            _documentCatalog = new Dictionary<string, foundDocuments>();
        }

        public void Run()
        {
            BuildWorld();

            Console.WriteLine("=== HOLLOW CREEK ===");
            Console.WriteLine("Type 'help' for a list of commands.");

            EnterLocation(_world.GetStartLocationName());

            while (_running)
            {
                Console.Write("\n> ");
                string input = Console.ReadLine();
                Commandsparsed command = _parser.Parse(input);
                Execute(command);
            }
        }

        private void BuildWorld()
        {
            Location square = new Location("Town Square",
                "The town square is silent except for the creak of a rusted weather vane atop the old bandstand. " +
                "A dry fountain sits cracked in the center, coins still glinting at the bottom - wishes no one " +
                "came back to collect. A child's bicycle lies on its side near the fountain, one wheel still " +
                "slowly turning in the wind.");

            Location mainStreet = new Location("Main Street",
                "Storefronts line the street, their windows dark. A faded 'OPEN' sign swings on a chain outside " +
                "the general store. Newspapers, yellowed and curled, tumble across the road with each gust of " +
                "wind. Somewhere, a shutter bangs against its frame in a slow, uneven rhythm.");

            Location generalStore = new Location("General Store",
                "Shelves stand half-emptied, as though someone grabbed what they could in a hurry and never " +
                "came back for the rest. The register drawer hangs open, a few coins scattered on the counter. " +
                "Flour dust still hangs faintly in the air, undisturbed for what must be weeks.");

            Location diner = new Location("Diner",
                "Coffee cups sit half-full on the counter, their contents long since evaporated into brown " +
                "rings. A jukebox in the corner is stuck on a single scratched note, silent now that the power's " +
                "gone. A pie sits under a glass dome, untouched, grown a soft grey fuzz.");

            Location sheriffOffice = new Location("Sheriff's Office",
                "Filing cabinets stand open, folders spilling onto the floor. A corkboard on the wall is covered " +
                "in photographs connected by red string, all leading to a single word scrawled at the center: " +
                "WHY. A pot of coffee, long cold, still sits on the burner.");

            Location clinic = new Location("Clinic",
                "Glass cabinets line the walls, mostly empty, their contents either used or taken. An " +
                "examination table has a thin sheet still pulled over it, as though someone was about to check " +
                "on a patient. Charts and folders cover every surface of the doctor's desk.");

            Location chapel = new Location("Chapel",
                "Pews lie overturned near the back, though the ones near the altar remain untouched, almost " +
                "reverently so. Candle wax has pooled and hardened on every surface. A hymnal lies open on the " +
                "floor to a page about deliverance.");

            Location schoolhouse = new Location("Schoolhouse",
                "Small desks sit in neat rows, still facing a chalkboard where half-finished arithmetic waits to " +
                "be solved. Children's drawings are pinned along the wall - suns, houses, families holding " +
                "hands. One drawing, near the end of the row, is different from the rest.");

            Location cemetery = new Location("Cemetery",
                "Gravestones lean at odd angles, some worn smooth by decades of rain. Near the back, a mound of " +
                "freshly turned earth stands out from the rest, with no marker to say who lies beneath it - or " +
                "whether anyone does at all.");

            Location oldMill = new Location("Old Mill",
                "The old mill looms over the creek, its great wheel long since stopped turning. Inside, the air " +
                "is thick with dust and the smell of damp wood. Near the base of the grain chute, half-buried " +
                "under fallen boards, is a single folded letter.");

            square.AddExit("north", "Main Street");
            square.AddExit("east", "Chapel");
            square.AddExit("west", "Cemetery");

            mainStreet.AddExit("south", "Town Square");
            mainStreet.AddExit("east", "General Store");
            mainStreet.AddExit("west", "Diner");
            mainStreet.AddExit("north", "Sheriff's Office");

            generalStore.AddExit("west", "Main Street");
            diner.AddExit("east", "Main Street");

            sheriffOffice.AddExit("south", "Main Street");
            sheriffOffice.AddExit("east", "Clinic");
            clinic.AddExit("west", "Sheriff's Office");

            chapel.AddExit("west", "Town Square");
            chapel.AddExit("north", "Schoolhouse");
            schoolhouse.AddExit("south", "Chapel");

            cemetery.AddExit("east", "Town Square");
            cemetery.AddExit("west", "Old Mill");
            oldMill.AddExit("east", "Cemetery");

            oldMill.SetLocked(true);
            oldMill.SetItemName("rusted key");

            Items rustedKey = new Items("rusted key",
                "A rusted iron key with a paper tag tied to it. The handwriting reads: MILL - DO NOT USE.", true);
            sheriffOffice.AddObject(rustedKey);
            _itemCatalog.Add(rustedKey.GetName().ToLower(), rustedKey);

            foundDocuments ledger = new foundDocuments("General store ledger",
                "A worn notebook kept by the register.",
                "Entries in a cramped, hurried hand: 'Batteries - sold out again. Candles - sold out. Salt - " +
                "customers buying by the sackful, don't know why. Mrs. Hargrove asked if we had any locks left. " +
                "We didn't.' The last entry, dated weeks ago, simply reads: 'Closing early. Can't stay past dark " +
                "anymore.'",
                new List<string> { "ledger", "grocery" }, false);
            generalStore.AddObject(ledger);
            _documentCatalog.Add(ledger.GetName().ToLower(), ledger);

            foundDocuments napkinNote = new foundDocuments("Napkin note",
                "A pen scrawl on a crumpled napkin.",
                "Written in pen, smudged as if the hand that wrote it was shaking: 'Tell Daniel not to go near " +
                "the tree line after dark. The dogs won't go near it either. Something's wrong with the dogs. " +
                "Something's wrong with all of it. I keep hearing humming.'",
                new List<string> { "napkin", "note" }, false);
            diner.AddObject(napkinNote);
            _documentCatalog.Add(napkinNote.GetName().ToLower(), napkinNote);

            foundDocuments incidentReport = new foundDocuments("Incident report",
                "A typed report clipped to the corkboard.",
                "Week 1: Two reports of missing livestock. Week 3: First missing person - Arlen Voss, last seen " +
                "walking toward the mill road. Week 5: Six more names added to the list. No bodies found. No " +
                "signs of struggle. Doors locked from the inside. Week 8: I don't know what to write anymore. " +
                "There's no procedure for this.",
                new List<string> { "report" }, false);
            sheriffOffice.AddObject(incidentReport);
            _documentCatalog.Add(incidentReport.GetName().ToLower(), incidentReport);

            foundDocuments medicalJournal = new foundDocuments("Doctor's medical journal",
                "A leather-bound journal on the desk.",
                "Patient presents with a faint rash, geometric in pattern, spreading slowly across the " +
                "collarbone. No fever, no pain, but patients report identical dreams - of standing in a field of " +
                "tall grass, of something counting them. Three patients from this list are no longer among the " +
                "living town population. Their beds were found empty. Their windows were locked from inside.",
                new List<string> { "journal", "medical" }, false);
            clinic.AddObject(medicalJournal);
            _documentCatalog.Add(medicalJournal.GetName().ToLower(), medicalJournal);

            foundDocuments sermonNotes = new foundDocuments("Pastor's sermon notes",
                "Handwritten notes tucked into the hymnal.",
                "I have preached deliverance for thirty years and I no longer know what I am asking God to " +
                "deliver us from. The congregation grows thinner each Sunday, not through death that I can " +
                "bury, but through absence I cannot explain. I told them to keep their lamps burning through " +
                "the night. I do not think lamps are enough anymore.",
                new List<string> { "sermon", "notes" }, false);
            chapel.AddObject(sermonNotes);
            _documentCatalog.Add(sermonNotes.GetName().ToLower(), sermonNotes);

            foundDocuments childDrawing = new foundDocuments("Child's drawing",
                "A crayon drawing pinned to the wall, different from the rest.",
                "Pinned beneath the drawing - a tall, too-thin figure standing among crayon trees, arms far " +
                "longer than they ought to be - is a note in an adult's handwriting: 'Asked little Sarah about " +
                "her drawing. She said the tall man stands at the edge of the yard every night and counts the " +
                "houses. She said he was almost done counting.'",
                new List<string> { "drawing" }, false);
            schoolhouse.AddObject(childDrawing);
            _documentCatalog.Add(childDrawing.GetName().ToLower(), childDrawing);

            foundDocuments gravediggerLog = new foundDocuments("Gravedigger's log",
                "A small logbook left on a headstone.",
                "Buried three more today, though I use the word loosely - closed caskets, empty caskets in two " +
                "cases, but the families insisted on services all the same. Better a grave with nothing in it " +
                "than no grave at all, I suppose. Saw lights out past the tree line again last night. Didn't go " +
                "look. Won't be going to look.",
                new List<string> { "log", "gravedigger" }, false);
            cemetery.AddObject(gravediggerLog);
            _documentCatalog.Add(gravediggerLog.GetName().ToLower(), gravediggerLog);

            foundDocuments finalLetter = new foundDocuments("The final letter",
                "A folded letter, half-buried under fallen boards.",
                "If anyone finds this - if anyone is left to find this - I need you to know we tried. We " +
                "gathered here because the mill was the only building left with a working lock on the inside, " +
                "and we thought that mattered. We thought a lock would matter.\n\n" +
                "It came just after midnight, the way it always does, and for the first time I saw it clearly, " +
                "past the tree line, closer than it had ever come. It wasn't walking. It doesn't walk. It was " +
                "simply standing there, and then it was—\n\n" +
                "The letter ends there. The last word is smeared, as though the pen had been dropped mid-stroke.",
                new List<string> { "letter" }, true);
            oldMill.AddObject(finalLetter);
            _documentCatalog.Add(finalLetter.GetName().ToLower(), finalLetter);

            _world.AddLocation(square);
            _world.AddLocation(mainStreet);
            _world.AddLocation(generalStore);
            _world.AddLocation(diner);
            _world.AddLocation(sheriffOffice);
            _world.AddLocation(clinic);
            _world.AddLocation(chapel);
            _world.AddLocation(schoolhouse);
            _world.AddLocation(cemetery);
            _world.AddLocation(oldMill);

            _world.SetStartLocationName("Town Square");
        }

        private void Execute(Commandsparsed command)
        {
            string verb = command.GetVerb();
            string target = command.GetTarget();

            if (verb == "help")
            {
                ShowHelp();
            }
            else if (verb == "look" || verb == "check")
            {
                EnterLocation(_player.GetCurrentLocationName());
            }
            else if (verb == "go")
            {
                MovePlayer(target);
            }
            else if (verb == "read")
            {
                ReadFromJournal(target);
            }
            else if (verb == "journal")
            {
                Console.WriteLine(_player.GetInventory().GetJournal().GetSummary());
            }
            else if (verb == "inventory")
            {
                Console.WriteLine(_player.GetInventory().GetSummary());
            }
            else if (verb == "unease")
            {
                Console.WriteLine("Unease: " + _player.GetUnease() + "/100. " + _player.GetDescribeUnease());
            }
            else if (verb == "save")
            {
                _saveManager.Save(_player);
                Console.WriteLine("Game saved.");
            }
            else if (verb == "load")
            {
                LoadGame();
            }
            else if (verb == "quit")
            {
                _running = false;
                Console.WriteLine("You turn your back on Hollow Creek. Some questions stay unanswered.");
            }
            else if (verb == "")
            {
                // The player just pressed enter - do nothing.
            }
            else
            {
                Console.WriteLine("Nothing here responds to that. Type 'help' for a list of commands.");
            }
        }

        private void ShowHelp()
        {
            Console.WriteLine("Commands: check (or look), go [direction], read [something from your journal],");
            Console.WriteLine("          journal, inventory, unease, save, load, quit");
            Console.WriteLine("While you are exploring a location, a numbered menu will let you interact");
            Console.WriteLine("with anything found there.");
        }

        private void EnterLocation(string locationName)
        {
            _player.SetCurrentLocationName(locationName);
            Location location = _world.GetLocation(locationName);

            Console.WriteLine();
            Console.WriteLine("== " + location.GetName() + " ==");
            Console.WriteLine(location.GetEntireDes());

            if (location.Getcontents().Count > 0)
            {
                Travelmenu menu = new Travelmenu(location);
                bool endingWasTriggered = menu.Show(_player);

                if (endingWasTriggered)
                {
                    TriggerEnding();
                }
            }
        }

        private void MovePlayer(string direction)
        {
            Location current = _world.GetLocation(_player.GetCurrentLocationName());

            if (string.IsNullOrEmpty(direction) || !current.HasanExit(direction))
            {
                Console.WriteLine("You can't go that way.");
                return;
            }

            string destinationName = current.GetExitDestination(direction);
            Location destination = _world.GetLocation(destinationName);

            if (destination.Locked())
            {
                if (_player.GetInventory().HasItem(destination.GetItemName()))
                {
                    destination.SetLocked(false);
                    Console.WriteLine("You use the " + destination.GetItemName() + " to force the lock. It gives way.");
                }
                else
                {
                    Console.WriteLine("The door is locked. You'll need something to open it.");
                    return;
                }
            }

            EnterLocation(destinationName);
        }

        private void ReadFromJournal(string target)
        {
            if (string.IsNullOrEmpty(target))
            {
                Console.WriteLine("Read what?");
                return;
            }

            foundDocuments document = _player.GetInventory().GetJournal().FindByKeyofWords(target);

            if (document == null)
            {
                Console.WriteLine("Nothing like that is in your journal yet.");
                return;
            }

            Console.WriteLine("-- " + document.GetName() + " --");
            Console.WriteLine();
            Console.WriteLine(document.GetBodyBody());
        }

        private void TriggerEnding()
        {
            Console.WriteLine("\n---");
            Console.WriteLine("You stand in the dark of the mill for a long moment, the letter still in your hands.");
            Console.WriteLine("Whatever finished that sentence never made it onto the page. Whatever it was, it");
            Console.WriteLine("came for Hollow Creek and left nothing behind to explain itself - only rooms full");
            Console.WriteLine("of half-finished lives, and a town that stopped, all at once, mid-sentence.");
            Console.WriteLine("\nYou have learned everything Hollow Creek is willing to tell you.");
            Console.WriteLine("---\n");
            Console.WriteLine("THE END");
            _running = false;
        }

        private void LoadGame()
        {
            SaveData data = _saveManager.Load();
            if (data == null)
            {
                Console.WriteLine("No save file found.");
                return;
            }

            _player = new PC();
            _player.SetCurrentLocationName(data.CurrentLocationName);
            _player.IncreaseUnease(data.Unease);

            foreach (string itemName in data.InventoryItemNames)
            {
                if (_itemCatalog.ContainsKey(itemName.ToLower()))
                {
                    _player.GetInventory().Store(_itemCatalog[itemName.ToLower()]);
                }
            }

            foreach (string documentName in data.ReadDocumentNames)
            {
                if (_documentCatalog.ContainsKey(documentName.ToLower()))
                {
                    _player.GetInventory().Store(_documentCatalog[documentName.ToLower()]);
                }
            }

            Console.WriteLine("Game loaded.");
            Console.WriteLine(_world.GetLocation(_player.GetCurrentLocationName()).GetEntireDes());
        }
    }
}