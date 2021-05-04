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

            Weapon.DamageValue = 30;
            var mainCharacter = new MainCharacter();
            {
                mainCharacter.Name = adventurerName;
                MainCharacter.Health = 100;
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
                    
                };
                
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                UserInteraction.StoryDialogue($"{gun.Name} added to inventory.");
            }
            else if (fighterClass == "b")
            {
                var sword = new Weapon()
                {
                    Name = "Katana",
                   
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
                currentDirection = Console.ReadLine().ToLower();

                UserInteraction.CheckDirection(currentDirection);

            } while (currentDirection != "a" && currentDirection != "b" && currentDirection != "c" && currentDirection != "d");




            UserInteraction.StoryDialogue(" Alright then, let's head out.");
            UserInteraction.PressEnter();


            if (currentDirection == "a")
            {
                UserInteraction.StoryDialogue(" An irradiated bee stings you along the way. You have minor radiation poisoning. (-10 Health)");
                UserInteraction.PressEnter();
            
                MainCharacter.TakeDamage(10);
            UserInteraction.StoryDialogue($" Health - 10\n Your Health = {MainCharacter.Health}");
            UserInteraction.PressEnter();
            }
            else if (currentDirection == "b")
            {
                UserInteraction.StoryDialogue(" You fall off a ledge unexpectedly and break a leg. You are critically injured. (-70 Health)");
                UserInteraction.PressEnter();

                MainCharacter.TakeDamage(70);
                UserInteraction.StoryDialogue($" Health - 70\n Your Health = {MainCharacter.Health}");
                UserInteraction.PressEnter();
            }
            else if (currentDirection == "c")
            {
                UserInteraction.StoryDialogue(" You feel good about your choice of direction.");
                UserInteraction.PressEnter();
            }
            else if (currentDirection == "d")
            {
                var drink = new Consumables()
                {
                    Name = "Bottle of Dasun Water",
                    HealValue = 10,
                };

                UserInteraction.StoryDialogue(" Walking along the road you see what appears to be some kind of packaging poking out from underneath a car door. \n " +
                    $"Moving it aside, you find a {drink.Name}. Nice!");
                UserInteraction.PressEnter();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                UserInteraction.StoryDialogue($"{drink.Name} added to inventory.");
                mainCharacter.MainInventory.Add(drink);
                UserInteraction.PressEnter();
            }


            UserInteraction.StoryDialogue(" Approaching a clearing, you see what appears to be the outline of some kind of structure.\n" +
                " As you start to get closer, you can see that it is an old abandoned shack.\n It doesn't doesn't look like anyone has been there in some time.\n" +
                " Will you search it?");
            
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            UserInteraction.StoryDialogue("(Type yes or no.)");
            Console.ForegroundColor = ConsoleColor.Green;
            
            bool willSearch = UserInteraction.YesOrNo(Console.ReadLine().ToLower());

            if (willSearch)
            {
                Item snack1 = new Consumables()
                {
                    Name = "Twonkies Snack Cake",
                    HealValue = 30
                };

                mainCharacter.MainInventory.Add(snack1);
                                
                UserInteraction.StoryDialogue($" You search the abandoned shack thoroughly. In one of the kitchen cabinets you find a {snack1.Name}.");
                UserInteraction.PressEnter();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                UserInteraction.StoryDialogue($"{snack1.Name} added to inventory.");
                Console.ForegroundColor = ConsoleColor.Green;

            }
            else
            {
                UserInteraction.StoryDialogue(" Realizing that there may be danger inside, you decide to keep traveling.");
            }
            UserInteraction.PressEnter();


            if (MainCharacter.Health < 50 && mainCharacter.MainInventory.Count >= 1)
            {
                UserInteraction.StoryDialogue("Would you like to use a consumable and heal?");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                UserInteraction.StoryDialogue("(Type yes or no.)");
                Console.ForegroundColor = ConsoleColor.Green;
                var replenish = UserInteraction.YesOrNo(Console.ReadLine().ToLower());

                if (replenish)
                {
                    UserInteraction.StoryDialogue(" You use a consumable, replenishing your health.");
                    MainCharacter.Heal(mainCharacter.MainInventory[0].HealValue);
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    UserInteraction.StoryDialogue($"You have consumed {mainCharacter.MainInventory[0].Name}");
                    mainCharacter.MainInventory.Remove(mainCharacter.MainInventory[0]);
                    Console.ForegroundColor = ConsoleColor.Green;
                    UserInteraction.StoryDialogue($" Your Health = {MainCharacter.Health}");
                    UserInteraction.PressEnter();
                }
                else
                {
                    UserInteraction.StoryDialogue("You continue on your journey..");
                    UserInteraction.PressEnter();
                }

            }


            var monster = new Enemy()
            {
                Name = "Death Claw",
                AttackDamage = 70,
            };



            var badGuy = new Enemy()
            {
                Name = "Raider Gunner",
                AttackDamage = 30,
            };

            var otherBadGuy = new Enemy()
            {
                Name = "Super Mutant",
                AttackDamage = 50,
            };

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            UserInteraction.StoryDialogue("You come to a crossroads.. which direction will you go?");
            UserInteraction.StoryDialogue(" A: North\n B: East\n C: South\n D: West");
            UserInteraction.StoryDialogue("(Type 'a', 'b', 'c', or 'd')");
            Console.ForegroundColor = ConsoleColor.Green;


            do
            {
                currentDirection = Console.ReadLine().ToLower();

                UserInteraction.CheckDirection(currentDirection);

            } while (currentDirection != "a" && currentDirection != "b" && currentDirection != "c" && currentDirection != "d");

            if(currentDirection == "a")
            {
                UserInteraction.StoryDialogue($" Under a bridge, you fall victim a trap set by a {badGuy.Name}.. Will you fight or run?");
                
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                UserInteraction.StoryDialogue($"(Type 'yes' to fight or 'no' to run.)");
                

                bool fightOrRun = UserInteraction.YesOrNo(Console.ReadLine().ToLower());

                if (fightOrRun)
                {
                    UserInteraction.StoryDialogue($" The {badGuy.Name} opens fire at you, hiting you in the side.\n The warm sting from the bullet sends a chill down your spine.");
                    MainCharacter.TakeDamage(badGuy.AttackDamage);
                    UserInteraction.GameOver();
                    UserInteraction.StoryDialogue($" Health - {badGuy.AttackDamage}\n Your Health = {MainCharacter.Health}");
                    UserInteraction.PressEnter();
                    if (fighterClass == "a")
                    {
                        UserInteraction.StoryDialogue($" You return fire at the enemy, hitting him directly in the head and killing him instantly.");
                        Combat.Fighting(Weapon.DamageValue, Enemy.Health);
                        UserInteraction.StoryDialogue($" {badGuy.Name} Health - {Weapon.DamageValue}\n Health = {Enemy.Health}");
                    }
                    else if (fighterClass == "b")
                    {
                        UserInteraction.StoryDialogue($" You take your chance while the {badGuy.Name} is reloading.. You charge him full force.\n Swinging with all your might, you decapitate him.");
                        Combat.Fighting(Weapon.DamageValue, Enemy.Health);
                        UserInteraction.StoryDialogue($" {badGuy.Name} Health - {Weapon.DamageValue}\n Health = {Enemy.Health}");
                    }
                }
                else
                {
                    UserInteraction.StoryDialogue(" You turn and run with your tail between your legs.");
                }
                UserInteraction.PressEnter();
            }
            else if (currentDirection == "b")
            {
                UserInteraction.StoryDialogue($" Woah, {adventurerName}! Look over there!");

                UserInteraction.PressEnter();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                UserInteraction.StoryDialogue("(You observe a 2-headed cow.)");
                UserInteraction.PressEnter();

                UserInteraction.StoryDialogue($" We are having steaks tonight! Whattaya say, {adventurerName}?\n We taking this home?");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                UserInteraction.StoryDialogue("(Type yes or no.)");
                Console.ForegroundColor = ConsoleColor.Green;

                bool getFood = UserInteraction.YesOrNo(Console.ReadLine().ToLower());

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

                    UserInteraction.StoryDialogue(" You butcher the cow, taking enough to eat now and puting the rest in salt to store for later.");
                    UserInteraction.PressEnter();

                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    mainCharacter.MainInventory.Add(beef);
                    mainCharacter.MainInventory.Add(saltedBeef);
                    UserInteraction.StoryDialogue($"{beef.Name} and {saltedBeef.Name} added to inventory.");
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    UserInteraction.StoryDialogue(" You decide not to kill the cow. I mean who needs to eat, right?\n You're only starving.");
                }
                UserInteraction.PressEnter();
            }
            else if (currentDirection == "c")
            {
                UserInteraction.StoryDialogue($" Walking along the road a {monster.Name} attacks you.. such bad luck..");
                MainCharacter.TakeDamage(monster.AttackDamage);
                UserInteraction.StoryDialogue($" Health - {monster.AttackDamage}\n Your Health = {MainCharacter.Health}");
                UserInteraction.GameOver();
                
                UserInteraction.StoryDialogue($" You manage to crawl under a car and bandage your wounds. You wait for a few hours until the {monster.Name} leaves.");
                UserInteraction.PressEnter();
            }
            else if (currentDirection == "d")
            {
                UserInteraction.StoryDialogue($" Looking to the horizon.. you can see a {otherBadGuy.Name} charging at you.. Will you fight or run?");

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                UserInteraction.StoryDialogue($"(Type 'yes' to fight or 'no' to run.)");

                bool fightOrRun = UserInteraction.YesOrNo(Console.ReadLine().ToLower());

                if (fightOrRun)
                {
                    UserInteraction.StoryDialogue($" The {otherBadGuy.Name} opens fire at you, hitting you multiple times in your legs.\n The pain is agonizing.");
                    MainCharacter.TakeDamage(otherBadGuy.AttackDamage);
                    UserInteraction.GameOver();
                    UserInteraction.StoryDialogue($" Health - {otherBadGuy.AttackDamage}\n Your Health = {MainCharacter.Health}");
                    UserInteraction.PressEnter();
                    if (fighterClass == "a")
                    {
                        UserInteraction.StoryDialogue($" You return fire at the {otherBadGuy.Name}.. your bullets pierce his skull, fatally wounding him.");
                        Combat.Fighting(Weapon.DamageValue, Enemy.Health);
                        UserInteraction.StoryDialogue($" {otherBadGuy.Name} Health - {Weapon.DamageValue}\n Health = {Enemy.Health}");
                    }
                    else if (fighterClass == "b")
                    {
                        UserInteraction.StoryDialogue($" You take your chance while the {otherBadGuy.Name} is reloading.. You charge him full force.\n You cut into his chest deeply, fatally wounding him.");
                        Combat.Fighting(Weapon.DamageValue, Enemy.Health);
                        UserInteraction.StoryDialogue($" {otherBadGuy.Name} Health - {Weapon.DamageValue}\n Health = {Enemy.Health}");
                    }
                    UserInteraction.StoryDialogue($" You leave the {otherBadGuy.Name} to bleed out and perish.");
                }
                else
                {
                    UserInteraction.StoryDialogue(" You turn and run with your tail between your legs.");
                }
                UserInteraction.PressEnter();
            }



            if (mainCharacter.MainInventory.Count >= 1)
            {
                UserInteraction.StoryDialogue(" You use a consumable, replenishing your health.");
                MainCharacter.Heal(mainCharacter.MainInventory[0].HealValue);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                UserInteraction.StoryDialogue($"You have consumed {mainCharacter.MainInventory[0].Name}");
                mainCharacter.MainInventory.Remove(mainCharacter.MainInventory[0]);
                UserInteraction.PressEnter();

                UserInteraction.StoryDialogue($" Health = {MainCharacter.Health} + 10\n " +
                   $"Health = {MainCharacter.Health}.");

                UserInteraction.PressEnter();
            }
            else
            {
                UserInteraction.StoryDialogue(" Your stomach growls with hunger.");
                UserInteraction.PressEnter();
            }

            UserInteraction.StoryDialogue($" Congratulations! You have survived with a score of {MainCharacter.Health}");
            UserInteraction.PressEnter();
            UserInteraction.StoryDialogue(" GAME OVER.");







        }



    }
}
