using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NuclearWorld
{
    public class Game
    {
        public static void RunGame()
        {
            var cont = "yes";
            while (cont == "yes")
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                UserInteraction.StoryDialogue("Would you like to play?\n(Type 'yes' or 'no')");
                Console.ForegroundColor = ConsoleColor.Green;
                cont = Console.ReadLine();
                Console.Clear();

                while (cont != "yes" && cont != "no")
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("That was not an option.\nType 'yes' to continue or 'no' to quit.");
                    Console.ForegroundColor = ConsoleColor.Green;
                    cont = Console.ReadLine();
                    Console.Clear();
                }
                if (cont == "yes")
                {


                    var r = new Random();

                    UserInteraction.GameHeader();
                    UserInteraction.PressEnter();
                    Console.Clear();

                    UserInteraction.IntroDialogue();
                    UserInteraction.PressEnter();
                    Console.Clear();

                    UserInteraction.StoryDialogue(" Here comes another one! Prepare to open fire!\n Oh, you're not a raider or a mutant.\n Partner, you almost got filled with lead!\n" +
                        " Well look-ee here. Survived the bombs, did you?\n What's your name, friend?");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    UserInteraction.StoryDialogue("(Please enter the name of your survivor:)");
                    Console.ForegroundColor = ConsoleColor.Green;
                    var mainCharacter = new MainCharacter();
                    var adventurerName = Console.ReadLine();
                    if (string.IsNullOrEmpty(adventurerName))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        UserInteraction.StoryDialogue("(You failed to type a name.)");
                        UserInteraction.PressEnter();
                        adventurerName = "No Name";
                    }
                    Console.Clear();

                    mainCharacter.Name = adventurerName;
                    MainCharacter.Health = 100;


                    UserInteraction.StoryDialogue($" Interesting name you got there, {adventurerName}. My name's Colt Peacemaker.\n" +
                        $" I'm the guardian of 'Bunker 34' here, so you'd best mind yer manners.\n" +
                        $" If you're gonna be ridin' with us you'll be needing a weapon, partner.. any preference?");
                    UserInteraction.PressEnter();
                    Console.Clear();

                    string fighterClass;
                    var dmg = r.Next(15, 60);

                    do
                    {
                        fighterClass = UserInteraction.GetUserClass();

                        UserInteraction.FighterClassSelection(fighterClass);

                    } while (fighterClass != "a" && fighterClass != "b");


                    if (fighterClass == "a")
                    {
                        var gun = new Weapon()
                        {
                            Name = "Smith & Wesson Model 351PD",

                        };

                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        UserInteraction.StoryDialogue($"{gun.Name} added to inventory.");
                        mainCharacter.Weapon = gun;
                        mainCharacter.Weapon.DamageValue = dmg;

                    }
                    else if (fighterClass == "b")
                    {
                        var sword = new Weapon()
                        {
                            Name = "Katana",

                        };

                        mainCharacter.Weapon = sword;
                        mainCharacter.Weapon.DamageValue = dmg;
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        UserInteraction.StoryDialogue($"{sword.Name} added to inventory.");
                    }
                    UserInteraction.PressEnter();
                    Console.Clear();

                    UserInteraction.StoryDialogue(" To be quite honest, friend, we could use someone with some outside experience.\n" +
                        " There's a whole nasty world out there and most folks ain't the friendly type.\n" +
                        " We could pay you in technology, or if you're looking for somewhere to settle down we could offer safe harbor.\n" +
                        " Sound like a deal? Good.");

                    UserInteraction.PressEnter();
                    Console.Clear();

                    UserInteraction.StoryDialogue(" Time to leave the bunker and enter the wasteland! We are running low on most of our rations and supplies.\n" +
                        " It's been 10 days since we've found food or fresh water. We need to scout for some if we are going to survive!\n" +
                        " We could try the nearby settlements and ask for trade, or maybe search abandoned shelters for supplies.\n" +
                        " We have been down in the bunker for most of our lives, so I am not familiar with the local territory.\n Only one way to find out what's out there.");
                    UserInteraction.PressEnter();
                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.DarkYellow;

                    string currentDirection;
                    do
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        UserInteraction.StoryDialogue("Now first, which way are we heading?");
                        UserInteraction.StoryDialogue(" A: North\n B: East\n C: South\n D: West");
                        UserInteraction.StoryDialogue("(Type 'a', 'b', 'c', or 'd')");

                        Console.ForegroundColor = ConsoleColor.Green;
                        currentDirection = Console.ReadLine().ToLower();

                        UserInteraction.CheckDirection(currentDirection);
                        UserInteraction.PressEnter();
                        Console.Clear();

                    } while (currentDirection != "a" && currentDirection != "b" && currentDirection != "c" && currentDirection != "d");



                    Console.Clear();
                    UserInteraction.StoryDialogue(" Alright then, let's head out.");
                    UserInteraction.PressEnter();
                    Console.Clear();
                    var randomize = r.Next(0, 2);

                    if (currentDirection == "a")
                    {
                        UserInteraction.StoryDialogue(" An irradiated bee stings you along the way. You have minor radiation poisoning.");
                        UserInteraction.PressEnter();
                        UserInteraction.StoryDialogue($"Your health before dmg: {MainCharacter.Health}");
                        MainCharacter.TakeDamage(r.Next(10, 20));
                        UserInteraction.StoryDialogue($"Your health after dmg: {MainCharacter.Health}");
                        UserInteraction.PressEnter();
                    }
                    else if (currentDirection == "b")
                    {
                        UserInteraction.StoryDialogue(" You fall off a ledge unexpectedly and break a leg. You are critically injured.");
                        UserInteraction.PressEnter();

                        UserInteraction.StoryDialogue($"Your health before dmg: {MainCharacter.Health}");
                        MainCharacter.TakeDamage(r.Next(30, 70));
                        UserInteraction.StoryDialogue($"Your health after dmg: {MainCharacter.Health}");
                        UserInteraction.PressEnter();
                    }
                    else if (currentDirection == "c")
                    {
                        if (randomize < 1)
                        {
                            UserInteraction.StoryDialogue(" You feel good about your choice of direction.");
                            UserInteraction.PressEnter();
                        }
                        else
                        {
                            UserInteraction.StoryDialogue("You come across a doctor in the wasteland offering to give you a serum to boost your dmg.\nAll he asks is you donate some blood.. for research..\nWill you donate blood for a dmg boost? (Type 'yes' or 'no'))");
                            var bloodDonation = UserInteraction.YesOrNo(Console.ReadLine().ToLower());
                            if(bloodDonation)
                            {
                                UserInteraction.StoryDialogue("You donate some blood for a dmg serum.");
                                Thread.Sleep(2000);
                                UserInteraction.StoryDialogue($" Your health before blood donation: {MainCharacter.Health}");
                                MainCharacter.TakeDamage(10);
                                UserInteraction.StoryDialogue($" Your health after blood donation: {MainCharacter.Health}\nYou take the dmg boost serum..");
                                Thread.Sleep(3000);
                                var newDmg = r.Next(20, 65);
                                mainCharacter.Weapon.DamageValue = newDmg;
                                UserInteraction.StoryDialogue("Your dmg has been increased!");
                                UserInteraction.PressEnter();
                                Console.Clear();
                            }
                            else
                            {
                                UserInteraction.StoryDialogue("You decide to keep your blood.");
                                UserInteraction.PressEnter();
                                Console.Clear();

                            }
                        }
                    }
                    else if (currentDirection == "d")
                    {
                        var drink = new Consumables()
                        {
                            Name = "Bottle of Dasun Water",
                            HealValue = r.Next(10, 20),
                        };

                        UserInteraction.StoryDialogue(" Walking along the road you see what appears to be some kind of packaging poking out from underneath a car door. \n " +
                            $"Moving it aside, you find a {drink.Name}. Nice!");
                        UserInteraction.PressEnter();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        UserInteraction.StoryDialogue($"{drink.Name} added to inventory.");
                        mainCharacter.MainInventory.Add(drink);
                        UserInteraction.PressEnter();
                    }

                    Console.Clear();

                    UserInteraction.StoryDialogue(" Approaching a clearing, you see what appears to be the outline of some kind of structure.\n" +
                        " As you start to get closer, you can see that it is an old abandoned shack.\n It doesn't doesn't look like anyone has been there in some time.\n" +
                        " Will you search it?");

                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    UserInteraction.StoryDialogue("(Type yes or no.)");
                    Console.ForegroundColor = ConsoleColor.Green;

                    bool willSearch = UserInteraction.YesOrNo(Console.ReadLine().ToLower());
                    Console.Clear();

                    if (willSearch)
                    {
                        if (randomize < 1)
                        {
                            Item snack1 = new Consumables()
                            {
                                Name = "Twonkies Snack Cake",
                                HealValue = r.Next(10, 30)
                            };

                            mainCharacter.MainInventory.Add(snack1);

                            UserInteraction.StoryDialogue($" You search the abandoned shack thoroughly. In one of the kitchen cabinets you find a {snack1.Name}.");
                            UserInteraction.PressEnter();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            UserInteraction.StoryDialogue($"{snack1.Name} added to inventory.");
                            Console.ForegroundColor = ConsoleColor.Green;
                            UserInteraction.PressEnter();
                            Console.Clear();
                        }
                        else
                        {
                            var scavenger = new Enemy();
                            scavenger.Health = 60;
                            scavenger.AttackDamage = r.Next(15, 40);
                            scavenger.Name = "Scavenger";
                            UserInteraction.StoryDialogue($"A {scavenger.Name} was already there searching!\n He opens fire after spotting you in the doorway, wounding you.");
                            UserInteraction.PressEnter();
                            Console.Clear();
                            while (MainCharacter.LifeCheck() && scavenger.Health > 0)
                            {
                                UserInteraction.StoryDialogue($"The {scavenger.Name} opens fire, hitting you in the side!");
                                Console.WriteLine();
                                UserInteraction.StoryDialogue($" Your health before dmg: {MainCharacter.Health}");
                                MainCharacter.TakeDamage(scavenger.AttackDamage);
                                UserInteraction.StoryDialogue($" Your health after dmg: {MainCharacter.Health}");
                                UserInteraction.GameOver();
                                UserInteraction.PressEnter();
                                if (fighterClass == "a")
                                {
                                    UserInteraction.StoryDialogue($"You return fire at the enemy, dealing damage.");
                                    UserInteraction.StoryDialogue($" {scavenger.Name}'s health before dmg: {scavenger.Health}");
                                    scavenger.Health = Combat.Fighting(mainCharacter.Weapon.DamageValue, scavenger.Health);
                                    UserInteraction.StoryDialogue($" {scavenger.Name}'s health after dmg: {scavenger.Health}");
                                    Console.WriteLine();
                                    UserInteraction.PressEnter();
                                    Console.Clear();
                                }
                                else if (fighterClass == "b")
                                {
                                    UserInteraction.StoryDialogue($"You take your chance while the {scavenger.Name} is reloading.. You charge him full force.\n Swinging with all your might.. You deal damage.");
                                    UserInteraction.StoryDialogue($" {scavenger.Name}'s health before dmg: {scavenger.Health}");
                                    scavenger.Health = Combat.Fighting(mainCharacter.Weapon.DamageValue, scavenger.Health);
                                    UserInteraction.StoryDialogue($" {scavenger.Name}'s health after dmg: {scavenger.Health}");
                                    Console.WriteLine();
                                    UserInteraction.PressEnter();
                                    Console.Clear();
                                }
                            }
                            UserInteraction.StoryDialogue($"You flee after killing the {scavenger.Name}. Danger could be around every corner.\nThis is a lesson you won't forget.");
                            UserInteraction.PressEnter();
                            Console.Clear();
                        }

                    }
                    else
                    {
                        UserInteraction.StoryDialogue(" Realizing that there may be danger inside, you decide to keep traveling.");
                        UserInteraction.PressEnter();
                        Console.Clear();
                    }




                    if (MainCharacter.Health < 50 && mainCharacter.MainInventory.Count >= 1)
                    {
                        UserInteraction.StoryDialogue(" Would you like to use a consumable and heal?");
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
                            Console.Clear();
                        }
                        else
                        {
                            UserInteraction.StoryDialogue("You continue on your journey..");
                            UserInteraction.PressEnter();
                            Console.Clear();
                        }

                    }



                    var monster = new Enemy()
                    {
                        Name = "Death Claw",
                        AttackDamage = r.Next(40, 70),
                    };


                    var badGuy = new Enemy()
                    {
                        Name = "Raider Gunner",
                        AttackDamage = r.Next(10, 30),
                        Health = 60
                    };


                    var otherBadGuy = new Enemy()
                    {
                        Name = "Super Mutant",
                        AttackDamage = r.Next(20, 40),
                        Health = 75
                    };


                    do
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        UserInteraction.StoryDialogue("You come to a crossroads.. which direction will you go?");
                        UserInteraction.StoryDialogue(" A: North\n B: East\n C: South\n D: West");
                        UserInteraction.StoryDialogue("(Type 'a', 'b', 'c', or 'd')");
                        Console.ForegroundColor = ConsoleColor.Green;

                        currentDirection = Console.ReadLine().ToLower();

                        UserInteraction.CheckDirection(currentDirection);
                        UserInteraction.PressEnter();
                        Console.Clear();

                    } while (currentDirection != "a" && currentDirection != "b" && currentDirection != "c" && currentDirection != "d");

                    Console.Clear();

                    if (currentDirection == "a")
                    {
                        UserInteraction.StoryDialogue($" Under a bridge, you fall victim a trap set by a {badGuy.Name}.. Will you fight or run?");

                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        UserInteraction.StoryDialogue($"(Type 'yes' to fight or 'no' to run.)");


                        bool fightOrRun = UserInteraction.YesOrNo(Console.ReadLine().ToLower());
                        UserInteraction.PressEnter();
                        Console.Clear();

                        if (fightOrRun)
                        {
                            while (MainCharacter.LifeCheck() && badGuy.Health > 0)
                            {
                                UserInteraction.StoryDialogue($"The {badGuy.Name} opens fire at you, hitting you in the side.\n The warm sting from the bullet sends a chill down your spine.");
                                Console.WriteLine();
                                UserInteraction.StoryDialogue($" Your health before dmg: {MainCharacter.Health}");
                                MainCharacter.TakeDamage(badGuy.AttackDamage);
                                UserInteraction.StoryDialogue($" Your health after dmg: {MainCharacter.Health}");
                                UserInteraction.GameOver();
                                UserInteraction.PressEnter();
                                if (fighterClass == "a")
                                {
                                    UserInteraction.StoryDialogue($"You return fire at the enemy, dealing damage.");
                                    UserInteraction.StoryDialogue($" {badGuy.Name}'s health before dmg: {badGuy.Health}");
                                    badGuy.Health = Combat.Fighting(mainCharacter.Weapon.DamageValue, badGuy.Health);
                                    UserInteraction.StoryDialogue($" {badGuy.Name}'s health after dmg: {badGuy.Health}");
                                    Console.WriteLine();
                                    UserInteraction.PressEnter();
                                    Console.Clear();
                                }
                                else if (fighterClass == "b")
                                {
                                    UserInteraction.StoryDialogue($"You take your chance while the {badGuy.Name} is reloading.. You charge him full force.\n Swinging with all your might.. You deal damage.");
                                    UserInteraction.StoryDialogue($" {badGuy.Name}'s health before dmg: {badGuy.Health}");
                                    badGuy.Health = Combat.Fighting(mainCharacter.Weapon.DamageValue, badGuy.Health);
                                    UserInteraction.StoryDialogue($" {badGuy.Name}'s health after dmg: {badGuy.Health}");
                                    Console.WriteLine();
                                    UserInteraction.PressEnter();
                                    Console.Clear();
                                }
                            }
                            UserInteraction.StoryDialogue($"You leave the {badGuy.Name} to his grave.");
                        }
                        else
                        {
                            UserInteraction.StoryDialogue(" You turn and run with your tail between your legs, taking a bullet to the ass in the process.");
                            MainCharacter.TakeDamage(10);
                            UserInteraction.GameOver();
                            UserInteraction.StoryDialogue($" Your Health - 10\n Your Health = {MainCharacter.Health}");
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
                        UserInteraction.StoryDialogue($" Your Health - {monster.AttackDamage}\n Your Health = {MainCharacter.Health}");
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
                        UserInteraction.PressEnter();
                        Console.Clear();

                        if (fightOrRun)
                        {
                            while (MainCharacter.LifeCheck() && otherBadGuy.Health > 0)
                            {
                                UserInteraction.StoryDialogue($" The {otherBadGuy.Name} opens fire at you, hitting you multiple times in your legs.\n The pain is agonizing.");
                                Console.WriteLine();
                                UserInteraction.StoryDialogue($" Your health before dmg: {MainCharacter.Health}");
                                MainCharacter.TakeDamage(otherBadGuy.AttackDamage);
                                UserInteraction.StoryDialogue($" Your health after dmg: {MainCharacter.Health}");
                                UserInteraction.GameOver();
                                UserInteraction.PressEnter();
                                if (fighterClass == "a")
                                {

                                    UserInteraction.StoryDialogue($" You return fire at the {otherBadGuy.Name}.. your bullets pierce his armor, wounding him.");
                                    Console.WriteLine();
                                    UserInteraction.StoryDialogue($" {otherBadGuy.Name}'s health before dmg: {otherBadGuy.Health}");
                                    otherBadGuy.Health = Combat.Fighting(mainCharacter.Weapon.DamageValue, otherBadGuy.Health);
                                    UserInteraction.StoryDialogue($" {otherBadGuy.Name}'s health after dmg: {otherBadGuy.Health}");
                                    Console.WriteLine();
                                    UserInteraction.PressEnter();
                                    Console.Clear();
                                }
                                else if (fighterClass == "b")
                                {
                                    UserInteraction.StoryDialogue($" You take your chance while the {otherBadGuy.Name} is reloading.. and you charge at him full force.\n You cut into his chest deeply, wounding him.");
                                    Console.WriteLine();
                                    UserInteraction.StoryDialogue($" {otherBadGuy.Name}'s health before dmg: {otherBadGuy.Health}");
                                    Combat.Fighting(mainCharacter.Weapon.DamageValue, otherBadGuy.Health);
                                    UserInteraction.StoryDialogue($" {otherBadGuy.Name}'s health after dmg: {otherBadGuy.Health}");
                                    Console.WriteLine();
                                    UserInteraction.PressEnter();
                                    Console.Clear();
                                }
                            }
                            UserInteraction.StoryDialogue($" You leave the {otherBadGuy.Name} to bleed out and perish.");
                            UserInteraction.PressEnter();
                            Console.Clear();
                        }
                        else
                        {
                            UserInteraction.StoryDialogue(" You turn and run with your tail between your legs, taking a bullet to the ass in the process.");
                            MainCharacter.TakeDamage(30);
                            UserInteraction.GameOver();
                            UserInteraction.StoryDialogue($" Your Health - 30\n Your Health = {MainCharacter.Health}");
                        }
                        UserInteraction.PressEnter();
                    }

                    Console.Clear();

                    if (mainCharacter.MainInventory.Count == 1 && MainCharacter.Health < 60)
                    {
                        UserInteraction.StoryDialogue(" You use a consumable, replenishing your health.");
                        MainCharacter.Heal(mainCharacter.MainInventory[0].HealValue);
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        UserInteraction.StoryDialogue($"You have consumed {mainCharacter.MainInventory[0].Name}");
                        mainCharacter.MainInventory.Remove(mainCharacter.MainInventory[0]);
                        UserInteraction.PressEnter();

                    }
                    else
                    {
                        UserInteraction.StoryDialogue(" Your health is too high to heal.");
                        UserInteraction.PressEnter();
                    }

                    Console.Clear();
                    UserInteraction.StoryDialogue($" Congratulations! You have survived with a score of {MainCharacter.Health}");
                    UserInteraction.PressEnter();
                    UserInteraction.StoryDialogue(" GAME OVER.");
                    Thread.Sleep(3000);
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.White;

                }
                else
                {
                    UserInteraction.StoryDialogue("Life is hard.\nGame over.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Environment.Exit(0);
                }
            }
        }
    }
}
