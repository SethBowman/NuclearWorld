using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuclearWorld
{
    class UserInteraction
    {
        public static string GetUserClass()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Choose your fighter class!");
            Console.WriteLine("A: Gunner");
            Console.WriteLine("B: Melee");
            Console.WriteLine("(Type 'a' or 'b')");
            return Console.ReadLine().ToLower();
            Console.ForegroundColor = ConsoleColor.Green;
        }

        public static void FighterClassSelection(string aNameThatDoesntMatter)
        {
            if (aNameThatDoesntMatter == "a")
            {
                Console.WriteLine("You have chosen the way of the gun!");
            }
            else if (aNameThatDoesntMatter == "b")
            {
                Console.WriteLine("Up close and personal, eh? I like your style.");
            }
            else
            {
                Console.WriteLine("That is not an option. Choose again!");
            }
        }

        public static void PressEnter()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("(Press ENTER to continue.)");
            Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.Green;
        }



        public static void CheckDirection(string directionChoice)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            switch (directionChoice)
            {
                case "a":
                    Console.WriteLine("North, eh? Alright let's hike North then.");
                    break;
                case "b":
                    Console.WriteLine("East? I thought you said Weast!");
                    break;
                case "c":
                    Console.WriteLine("South? Some of ours headed that way a few weeks ago and never came back..");
                    break;
                case "d":
                    Console.WriteLine("I've never been west of here before. Let's give it a shot.");
                    break;
                default:
                    Console.WriteLine("That is not an option. Choose again.");
                    break;
            }
            Console.ForegroundColor = ConsoleColor.Green;
        }





        public static int Combat(int health, int damage)
        {

            if (damage > health)
            {
                return 0;
            }
            else
            { 
                return health - damage;
            }
            

        }



        private static void CheckUserInput(ref string answerToQuestion)
        {
            while (answerToQuestion != "yes" && answerToQuestion != "no")
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("That is not an option. Choose again!");
                answerToQuestion = Console.ReadLine();

            }
        }


        public static bool YesOrNo(string answerToQuestion)
        {
            CheckUserInput(ref answerToQuestion);

            if (answerToQuestion == "yes")
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("(You have chosen yes.)");
                Console.ForegroundColor = ConsoleColor.Green;
                return true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("(You have chosen no.)");
                Console.ForegroundColor = ConsoleColor.Green;
                return false;
            }

        }


        public static void StoryDialogue(string dialogue)
        {
            Console.WriteLine(dialogue);
        }



       
        public static void GameHeader()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            UserInteraction.StoryDialogue(@"                                           Seth Bowman presents:");
            Console.ForegroundColor = ConsoleColor.Blue;
            UserInteraction.StoryDialogue(@"      _____   __            ______                       ___       __            ______________");
            UserInteraction.StoryDialogue(@"      ___  | / /___  __________  /__________ ________    __ |     / /_______________  /_____  /");
            UserInteraction.StoryDialogue(@"      __   |/ /_  / / /  ___/_  /_  _ \  __ `/_  ___/    __ | /| / /_  __ \_  ___/_  /_  __  / ");
            UserInteraction.StoryDialogue(@"      _  /|  / / /_/ // /__ _  / /  __/ /_/ /_  /        __ |/ |/ / / /_/ /  /   _  / / /_/ /  ");
            UserInteraction.StoryDialogue(@"      /_/ |_/  \__,_/ \___/ /_/  \___/\__,_/ /_/         ____/|__/  \____//_/    /_/  \__,_/   ");
            Console.ForegroundColor = ConsoleColor.Green;
        }



        public static void IntroDialogue()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            UserInteraction.StoryDialogue(" Life. Life is hard.\n The Romans waged war to gather slaves and wealth.\n" +
                " Spain built an empire from its lust for gold and territory.\n" +
                " Hitler shaped a battered Germany into an economic superpower. Yes, indeed, life is hard.\n" +
                " In the 21st century, war was still waged over the resources that could be acquired from winning.\n" +
                " Only this time, the spoils of war were also its weapons: Petroleum and Uranium.\n" +
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
        }



    }

}
