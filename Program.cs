using System;

namespace NuclearWorld
{
    class Program
    {
        static void Main(string[] args)
        {


            Console.ForegroundColor = ConsoleColor.Cyan;
            UserInteraction.StoryDialogue(@"       Seth Bowman presents:");            
            Console.ForegroundColor = ConsoleColor.Blue;
            UserInteraction.StoryDialogue(@"  |\ |    _| _  _.._ \    /_ ._| _|");
            UserInteraction.StoryDialogue(@"  | \||_|(_|(/_(_||   \/\/(_)| |(_|");
            Console.ForegroundColor = ConsoleColor.Green;
            UserInteraction.PressEnter();



            Console.ForegroundColor = ConsoleColor.Green;
            UserInteraction.StoryDialogue(" Life. Life is hard.\n The Romans waged war to gather slaves and wealth.\n" +
                " Spain built an empire from its lust for gold and territory.\n" +
                " Hitler shaped a battered Germany into an economic superpower. Yes, indeed, life is hard.\n" +
                " In the 21st century, war was still waged over the resources that could be acquired from winning.\n" +
                " Only this time, the spoils of war were also its weapons: Petroleum and Uranium.\n"+
                " For these resources, China would invade Alaska, the US would annex Canada..\n" +
                " The European Commonwealth, which had lasted centuries,\n" +
                " would dissolve into quarreling, bickering nation-states bent on controlling the last remaining resources on Earth.\n" +
                " In 2052, the storm of world war had come again. In two brief hours, most of the planet was reduced to cinders.\n" +
                " And from the ashes of nuclear devastation, a new civilization would struggle to arise.\n" +
                " A few were able to reach the relative safety of the large underground bunkers.\n" +
                " Your family was part of a group that entered 'Bunker 33', a mysterious government owned facility.\n" +
                " Imprisoned safely behind the large bunker door, under a mountain of stone,\n" +
                " a generation has lived without knowledge of the outside world.\n" +
                " Life in the bunker is about to change.\n" +
                " The bunker you call home has become unlivable due to the unforseen conditons of nuclear holocaust.\n" +
                " You and your people have no choice but to search for refuge elsewhere.\n" +
                " The elders have informed you of the discovery of a bunker that is suppoed to be located nearby,\n" +
                " thanks to bunker records kept from before the Great War.\n" +
                " Your journey begins as you head for the bunker..");

            UserInteraction.PressEnter();



            

            UserInteraction.StoryDialogue(" Here comes another one! Prepare to open fire!\n Oh, you're not a raider or a mutant.\n Parter, you almost got filled with lead!\n" +
                " Well look-ee here. Survived the bombs, did you?\n What's your name, friend?");
            UserInteraction.StoryDialogue("(Please enter the name of your survivor:)");
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

            UserInteraction.StoryDialogue("Now first, which way are we heading?");

            UserInteraction.StoryDialogue(" A: North\n B: East\n C: South\n D: West");

            UserInteraction.StoryDialogue("(Type 'a', 'b', 'c', or 'd')");

            string currentDirection;
            do
            {
                currentDirection = Console.ReadLine();

                UserInteraction.CheckDirection(currentDirection);

            } while (currentDirection != "a" && currentDirection != "b" && currentDirection != "c" && currentDirection != "d");




            UserInteraction.StoryDialogue("Alright then, let's head out.");

            UserInteraction.PressEnter();


            UserInteraction.StoryDialogue("An irradiated bee stings you along the way. You have minor radiation poisoning. (-10 Health)");

            UserInteraction.PressEnter();

            var health = UserInteraction.Combat(mainCharacter.Health, 10);

            UserInteraction.StoryDialogue($"Health =  100 - 10\n " +
                $"Health = {health}.");


            UserInteraction.PressEnter();

            UserInteraction.StoryDialogue("Approaching a clearing, you see what appears to be the outline of some kind of structure.\n" +
                "As you start to get closer, you can see that it is an old abandoned shack.\nIt doesn't doesn't look like anyone has been there in some time.\n" +
                "Will you search it?");

            UserInteraction.StoryDialogue("(Type yes or no.)");
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

                UserInteraction.StoryDialogue($"{snack1.Name} added to inventory.");
                
            }
            else
            {
                UserInteraction.StoryDialogue("Realizing that there may be danger inside, you decide to keep traveling.");
            }


            UserInteraction.PressEnter();


            UserInteraction.StoryDialogue($"Woah, {adventurerName}! Look over there!");

            UserInteraction.PressEnter();
            UserInteraction.StoryDialogue("(You observe a 2-headed cow.)");
            UserInteraction.PressEnter();

            UserInteraction.StoryDialogue($"We are having steaks tonight! Whattaya say, {adventurerName}?\n We taking this home?");
            UserInteraction.StoryDialogue("(Type yes or no.)");

            bool getFood = UserInteraction.YesOrNo(Console.ReadLine());

            if (getFood)
            {
                UserInteraction.StoryDialogue("You butcher the cow, taking enough to eat now and puting the rest in salt to store for later.");
            }
            else
            {
                UserInteraction.StoryDialogue("You decide not to kill the cow. I mean who needs to eat, right?\n You're only starving.");
            }

            UserInteraction.PressEnter();


            UserInteraction.StoryDialogue("You eat a snack, replenishing your health.");

            MainCharacter.Heal(mainCharacter.Health, mainCharacter.MainInventory[0].HealValue);
            UserInteraction.StoryDialogue($"You have eaten {mainCharacter.MainInventory[0].Name}");
            mainCharacter.MainInventory.Remove(mainCharacter.MainInventory[0]);
            UserInteraction.PressEnter();

            UserInteraction.StoryDialogue($"Health =  90 + 10\n " +
               $"Health = {mainCharacter.Health}.");

            UserInteraction.PressEnter();


            UserInteraction.StoryDialogue("MORE TO COME SOON..");
            UserInteraction.PressEnter();







        }



    }
}
