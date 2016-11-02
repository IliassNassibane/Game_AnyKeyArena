using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventurez2
{
    // @desc: Een class voor de potion item
    // @author: Iliass Nassibane
    // @date: 10-8-2016
    // @update: - name prop toegevoegd.
    public class potionItem
    {
        string name = "Elixer of life";
        int healthregen;

        public potionItem()
        {
            Random rnd = new Random();
            int randomNumb = rnd.Next(20, 41);
            this.healthregen = randomNumb;
        }
    }
    
    // @desc: De daadwerkelijke game.
    // @author: Iliass Nassibane.
    // @date: 16-08-2016.
    class Program
    {
        public static void gameLoop()
        {
            // @desc: Battle specifieke eigenschappen.
            Random rand = new Random();
            int youHit = rand.Next(0, 6); // wordt gebruikt om te kunnen bepalen wanneer je de vijand hebt geraakt of gemist. 1/5 kans om te missen.
            Random rand2 = new Random();
            int enemyEnc = rand2.Next(1, 4); // bepaalt welke vijand (ratwarrior, zubat of goblin) je tegenkomt.
            object enemy = new object(); // een placeholder vóór de selectie van de vijand.
            int encounters = 1; // de hoeveelheid encounters die de speler heeft gehad.
            int maxRandEnc = 6; // staat voor de maximum aantal random encounters die de speler door moet voordat hij met de draak moet vechten.
            string enemyName = ""; // wordt ingesteld na de switch.
            int enemyAtt = 0; // Staat voor de aanval van de geselecteerde vijand, wordt ingesteld na de switch.
            int enemyHlth = 0; // Staat voor het aantal levenspunten van de geselecteerde vijand, wordt ingesteld na de switch.
            int dmgToPlayer = 0; // variabel die bijhoudt hoeveel damage de speler heeft ontvangen.
            int dmgToEnemy = 0; // variabel die bijhoudt hoeveel damage de vijand heeft ontvangen.

            // @desc: Speler specifieke eigenschappen.
            //bool busy = false; // staat voor de staat waarin de speler gedurende de spel zich in bevind. False = niet in combat, True = in combat.
            bool beating = true;
            int play1Health = 50;
            Random rand3 = new Random();
            int play1Attack = rand3.Next(8, 15);

            // @desc: Begin van de encounter loop.
            // @author: Iliass Nassibane.
            // @date: 16-08-2016.
            do
            {
                // @desc: narration, voor iedere gevecht.
                Console.WriteLine("");
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine("|        Status: " + play1Health + " HP!          |");
                Console.WriteLine("|        You are wandering the dungeon...         |");
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine("");
                Console.ReadKey();

                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine("|          You have encountered an enemy!         |");
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine(" ");
                Console.ReadKey();

                // @desc: Selecteert de tegenstander.
                // @author: Iliass Nassibane.
                // @date: 16-08-2016.
                if (encounters != maxRandEnc)
                {
                    // @desc: Eerst wordt de tegenstander gekozen van de selectie van Ratwarrior, Zubat en Goblin.
                    for (int i = 1; i < maxRandEnc; i++)
                    {
                        switch (enemyEnc)
                        {
                            case 1:
                                TextAdventurez2.ClassEnemy enc1rat = new ClassEnemy("rat");
                                enemy = enc1rat; // Set the enemy prop naar die van de ClassEnemy class met een Rat warrior instelling.
                                enemyName = enc1rat.name;
                                enemyAtt = enc1rat.attack;
                                enemyHlth = enc1rat.health;
                                enc1rat.randCry(); // weergeeft een kreet die ingesteld staat op de geselecteerde type vijand.
                                break;
                            case 2:
                                TextAdventurez2.ClassEnemy enc2bat = new ClassEnemy("bat");
                                enemy = enc2bat;
                                enemyName = enc2bat.name;
                                enemyAtt = enc2bat.attack;
                                enemyHlth = enc2bat.health;
                                enc2bat.randCry();
                                break;
                            case 3:
                                TextAdventurez2.ClassEnemy enc3gob = new ClassEnemy("goblin");
                                enemy = enc3gob;
                                enemyName = enc3gob.name;
                                enemyAtt = enc3gob.attack;
                                enemyHlth = enc3gob.health;
                                enc3gob.randCry();
                                break;
                        }
                        //encounters += 1;
                        break;
                    }
                }
                // @desc:  Als de maximale aantal aan encounters is behaald dan wordt de Boss opgevoerd.
                else
                {
                    TextAdventurez2.ClassEnemy encBoss = new ClassEnemy("Dragon");
                    enemy = encBoss;
                    enemyName = encBoss.name;
                    enemyAtt = encBoss.attack;
                    enemyHlth = encBoss.health;
                    encBoss.randCry();
                }
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine("|        A wild " + enemyName + " appears!        |");
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine("");
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine("|               Let the battle begin!             |");
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine("Press any key to proceed...>>");
                Console.ReadKey();
                // Resultaat: een encounter die is assigned aan de enemy variable en wordt meegenomen naar de gevecht routine.
                beating = true;

                // @desc: Start het gevecht.
                // @source, inspired by: https://www.codecademy.com/courses/javascript-beginner-en-mrTNH-6VIZ9/0/1?curriculum_id=506324b3a7dffd00020bf661
                // @author: Iliass Nassibane.
                // @date: 16-08-2016.
                // @update: 17-08-2016.
                while (beating)
                {
                    Console.WriteLine("You swung your magnificent sword at the enemy!");
                    // busy = true; // Set busy to true, omdat het gevechtproces is begonnen.
                    if (youHit != 1)
                    {
                        // @desc: Als de speler de vijand raakt, wordt vervolgens bekeken of de 
                        // aantal in damage gevalideerd wordt voor een crit.
                        Console.WriteLine("And it was good!");
                        if (play1Attack > 13)
                        {
                            Console.WriteLine("Critical damage!! You did " + play1Attack + " damage!");
                            play1Attack = rand3.Next(8, 15);
                        }
                        else
                        {
                            Console.WriteLine("You did " + play1Attack + " damage!");
                        }
                        dmgToEnemy += play1Attack;
                        play1Attack = rand3.Next(8, 15);

                        // @desc: Dit valideert of de vijand dood gaat door de verkregen damage.
                        if (dmgToEnemy >= enemyHlth)
                        {
                            Console.WriteLine("Congratulations! You killed the " + enemyName + "!");
                            Console.WriteLine("Press any key to proceed...>>");
                            Console.ReadKey();
                            beating = false;
                            encounters += 1;
                            play1Health -= dmgToPlayer;
                            dmgToEnemy = 0;
                            dmgToPlayer = 0;
                            enemyAtt = 0; // clumsy fix: tegen de "attack after death"-bug.
                            enemyEnc = rand2.Next(1, 4);
                            break;
                        }
                        /*
                        else
                        {
                            youHit = rand.Next(0, 6);
                        }
                        */
                    }
                    else
                    {
                        Console.WriteLine("You missed the enemy!");
                    }
                    Console.WriteLine("Proceed...>>");
                    Console.ReadKey();
                    Console.WriteLine("");

                    if (dmgToEnemy >= enemyHlth)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("The enemy attacks you!");
                        youHit = rand.Next(0, 6);

                        if (youHit != 1)
                        {
                            if (!(dmgToEnemy >= enemyHlth))
                            {
                                Console.WriteLine("And you got hit!");
                                Console.WriteLine("You received " + enemyAtt + " damage!");
                                Console.WriteLine("Proceed...>>");

                                dmgToPlayer += enemyAtt;

                                if (dmgToPlayer >= play1Health)
                                {
                                    Console.WriteLine("");
                                    Console.WriteLine("Oh no!" + enemyName + " killed you!");
                                    Console.WriteLine("Press any key to proceed...>>");
                                    Console.WriteLine("");
                                    Console.ReadKey();

                                    Console.WriteLine("---------------------------------------------------");
                                    Console.WriteLine("|                    Game over!                   |");
                                    Console.WriteLine("---------------------------------------------------");
                                    Console.WriteLine("Press any key to proceed...>>");
                                    Console.WriteLine("");
                                    Console.ReadKey();
                                    beating = false;
                                    play1Health = 0; // dummy bug fix.
                                    break;
                                }
                                else
                                {
                                    youHit = rand.Next(0, 6);
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("And it missed!");
                        }
                        // encounters += 1;
                    }

                    Console.WriteLine("");
                    Console.ReadKey();
                    Console.WriteLine("");
                }

                /*
                if (encounters >= maxRandEnc && enemyName == fin)
                {
                    Console.WriteLine("---------------------------------------------------");
                    Console.WriteLine("| Congratulations! You have survived the dungeon! |");
                    Console.WriteLine("---------------------------------------------------");
                    Console.WriteLine("Press any key to proceed...>>");
                    Console.ReadKey();
                }*/
            } while (!(play1Health <= 0));

            TextAdventurez2.ClassEnemy finalEnc = new ClassEnemy("Dragon");
            string fin = finalEnc.name;
            if (encounters >= maxRandEnc && enemyName == fin && !(play1Health <= 0))
            {
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine("| Congratulations! You have survived the dungeon! |");
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine("Press any key to proceed...>>");
                Console.ReadKey();
            }
        }

        // @desc: Hoofdproces voor de game.
        // @author: Iliass Nassibane
        // @date: 10-8-2016
        static void Main(string[] args)
        {
            // @desc: Endcredits
            // @author: Iliass Nassibane
            // @date: 10-8-2016
            Console.WriteLine("       --------------------------------------");
            Console.WriteLine("       |           TextAdventuwz:           |");
            Console.WriteLine("       |      Enter the any key Arena!      |");
            Console.WriteLine("       --------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Press any key to proceed...>>");
            Console.ReadKey();

            // @desc: Maingame Loop.
            Program.gameLoop();

            // @desc: Endcredits
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("|      Een originele spel van Iliass Nassibane,   |");
            Console.WriteLine("|             Bedankt voor het spelen!            |");
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Press any key to end the game...");
            Console.ReadKey();
        }
    }
}