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
            return Console.ReadLine();
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




        public static bool YesOrNo(string answerToQuestion)
        {
                      

            if (answerToQuestion == "yes")
            {
                Console.WriteLine("(You have chosen yes.)");
                return true;
            }
            else if (answerToQuestion == "no")
            {
                Console.WriteLine("(You have chosen no.)");
                return false;
            }
            else
            {
                Console.WriteLine("That is not an option. Choose again!");
                return false;
            }
        }


        public static void StoryDialogue(string dialogue)
        {
            Console.WriteLine(dialogue);
        }



       








    }

}
