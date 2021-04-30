using System;
using System.Linq;
using System.Collections.Generic;

namespace NuclearWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            UserInteraction.GameHeader();
            UserInteraction.PressEnter();


            UserInteraction.IntroDialogue();
            UserInteraction.PressEnter();
            

            UserInteraction.StoryDialogue(" Here comes another one! Prepare to open fire!\n Oh, you're not a raider or a mutant.\n Partner, you almost got filled with lead!\n" +
                " Well look-ee here. Survived the bombs, did you?\n What's your name, friend?");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            UserInteraction.StoryDialogue("(Please enter the name of your survivor:)");
            Console.ForegroundColor = ConsoleColor.Green;
            var adventurerName = Console.ReadLine();

            var mainCharacter = new MainCharacter();
            {
                mainCharacter.Name = adventurerName;
                mainCharacter.Health = 100;
            };            


            UserInteraction.StoryDialogue($" Interesting name you got there, {adventurerName}. My name's Colt Peacemaker.\n" +
                $" I'm the guardian of 'Bunker 34' here, so you'd best mind yer manners.\n" +
                $" If you're gonna be ridin' with us you'll be needing a weapon, partner.. any preference?");
            UserInteraction.PressEnter();


            string fighterClass;

            do
            {                
                fighterClass = UserInteraction.GetUserClass();

                UserInteraction.FighterClassSelection(fighterClass);

            } while (fighterClass != "a" && fighterClass != "b");
            UserInteraction.PressEnter();


            if (fighterClass == "a")
            {
                var gun = new Weapon()
                {
                    Name = "Smith & Wesson Model 351PD",
                    DamageValue = 30,
                };
                
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                UserInteraction.StoryDialogue($"{gun.Name} added to inventory.");
            }
            else if (fighterClass == "b")
            {
                var sword = new Weapon()
                {
                    Name = "Katana",
                    DamageValue = 30,
                };

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                UserInteraction.StoryDialogue($"{sword.Name} added to inventory.");
            }
            UserInteraction.PressEnter();


            UserInteraction.StoryDialogue(" To be quite honest, friend, we could use someone with some outside experience.\n" +
                " There's a whole nasty world out there and most folks ain't the friendly type.\n" +
                " We could pay you in technology, or if you're looking for somewhere to settle down we could offer safe harbor.\n" +
                " Sound like a deal? Good.");

            UserInteraction.PressEnter();

            UserInteraction.StoryDialogue(" Time to leave the bunker and enter the wasteland! We are running low on most of our rations and supplies.\n" +
                " It's been 10 days since we've found food or fresh water. We need to scout for some if we are going to survive!\n" +
                " We could try the nearby settlements and ask for trade, or maybe search abandoned shelters for supplies.\n" +
                " We have been down in the bunker for most of our lives, so I am not familiar with the local territory.\n Only one way to find out what's out there.");
            UserInteraction.PressEnter();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            UserInteraction.StoryDialogue("Now first, which way are we heading?");
            UserInteraction.StoryDialogue(" A: North\n B: East\n C: South\n D: West");
            UserInteraction.StoryDialogue("(Type 'a', 'b', 'c', or 'd')");
            Console.ForegroundColor = ConsoleColor.Green;

            string currentDirection;
            do
            {
                currentDirection = Console.ReadLine();

                UserInteraction.CheckDirection(currentDirection);

            } while (currentDirection != "a" && currentDirection != "b" && currentDirection != "c" && currentDirection != "d");




            UserInteraction.StoryDialogue("Alright then, let's head out.");
            UserInteraction.PressEnter();


            if (currentDirection == "a")
            {
                UserInteraction.StoryDialogue("An irradiated bee stings you along the way. You have minor radiation poisoning. (-10 Health)");
                UserInteraction.PressEnter();
            
                var health = UserInteraction.Combat(mainCharacter.Health, 10);
            UserInteraction.StoryDialogue($"Health =  100 - 10\n " +
                $"Health = {health}.");
            UserInteraction.PressEnter();
            }
            else if (currentDirection == "b")
            {
                UserInteraction.StoryDialogue("You fall off a ledge unexpectedly and break a leg. You are critically injured. (-70 Health)");
                UserInteraction.PressEnter();

                var health = UserInteraction.Combat(mainCharacter.Health, 70);
                UserInteraction.StoryDialogue($"Health =  100 - 70\n " +
                    $"Health = {health}.");
                UserInteraction.PressEnter();
            }
            else if (currentDirection == "c")
            {
                UserInteraction.StoryDialogue("You feel good about your choice of direction.");
                UserInteraction.PressEnter();
            }
            else if (currentDirection == "d")
            {
                var treat = new Consumables()
                {
                    Name = "Cracker Jox",
                    HealValue = 10,
                };

                UserInteraction.StoryDialogue(" Walking along the road you see what appears to be some kind of packaging poking out from underneath a car door.\n " +
                    $"Moving it aside, you find some {treat.Name}. Nice!");
                UserInteraction.PressEnter();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                UserInteraction.StoryDialogue($"{treat.Name} added to inventory.");
                mainCharacter.MainInventory.Add(treat);
                UserInteraction.PressEnter();
            }


            UserInteraction.StoryDialogue("Approaching a clearing, you see what appears to be the outline of some kind of structure.\n" +
                "As you start to get closer, you can see that it is an old abandoned shack.\nIt doesn't doesn't look like anyone has been there in some time.\n" +
                "Will you search it?");
            
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            UserInteraction.StoryDialogue("(Type yes or no.)");
            Console.ForegroundColor = ConsoleColor.Green;
            bool willSearch = UserInteraction.YesOrNo(Console.ReadLine());

            if (willSearch)
            {
                Item snack1 = new Consumables()
                {
                    Name = "Twonkies Snack Cake",
                    HealValue = 10
                };

                mainCharacter.MainInventory.Add(snack1);
                                
                UserInteraction.StoryDialogue($"You search the abandoned shack thoroughly. In one of the kitchen cabinets you find a {snack1.Name}.");
                UserInteraction.PressEnter();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                UserInteraction.StoryDialogue($"{snack1.Name} added to inventory.");
                Console.ForegroundColor = ConsoleColor.Green;

            }
            if else
            {
                UserInteraction.StoryDialogue("Realizing that there may be danger inside, you decide to keep traveling.");
            }
            else
            {
                UserInteraction.StoryDialogue("That is not an option. Try again.");
            }


            UserInteraction.PressEnter();


            UserInteraction.StoryDialogue($"Woah, {adventurerName}! Look over there!");

            UserInteraction.PressEnter();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            UserInteraction.StoryDialogue("(You observe a 2-headed cow.)");
            UserInteraction.PressEnter();

            UserInteraction.StoryDialogue($"We are having steaks tonight! Whattaya say, {adventurerName}?\n We taking this home?");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            UserInteraction.StoryDialogue("(Type yes or no.)");
            Console.ForegroundColor = ConsoleColor.Green;

            bool getFood = UserInteraction.YesOrNo(Console.ReadLine());

            if (getFood)
            {
                var beef = new Consumables()
                {
                    Name = "Irradiated Beef",
                    HealValue = 10,
                };

                var saltedBeef = new Consumables()
                {
                    Name = "Salted Irradiated Beef",
                    HealValue = 10,
                };

                UserInteraction.StoryDialogue("You butcher the cow, taking enough to eat now and puting the rest in salt to store for later.");
                UserInteraction.PressEnter();
                
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                mainCharacter.MainInventory.Add(beef);
                mainCharacter.MainInventory.Add(saltedBeef);
                UserInteraction.StoryDialogue($"{beef.Name} and {saltedBeef.Name} added to inventory.");
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else
            {
                UserInteraction.StoryDialogue("You decide not to kill the cow. I mean who needs to eat, right?\n You're only starving.");
            }

            UserInteraction.PressEnter();


            if (mainCharacter.MainInventory.Count >= 1)
            {
                UserInteraction.StoryDialogue("You eat a snack, replenishing your health.");
                MainCharacter.Heal(mainCharacter.Health, mainCharacter.MainInventory[0].HealValue);
                UserInteraction.StoryDialogue($"You have eaten {mainCharacter.MainInventory[0].Name}");
                mainCharacter.MainInventory.Remove(mainCharacter.MainInventory[0]);
                UserInteraction.PressEnter();

                UserInteraction.StoryDialogue($"Health =  90 + 10\n " +
                   $"Health = {mainCharacter.Health}.");

                UserInteraction.PressEnter();
            }
            else
            {
                UserInteraction.StoryDialogue("Your stomach growls with hunger.");
                UserInteraction.PressEnter();
            }


            UserInteraction.StoryDialogue($"Congratulations! You have survived with a score of {mainCharacter.Health}");
            UserInteraction.PressEnter();
            UserInteraction.StoryDialogue("GAME OVER.");







        }



    }
}
