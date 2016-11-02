using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventurez2
{
    // @desc: Een enum voor de definitie van de vijanden.
    // @author: Iliass Nassibane
    // @date: 16-8-2016
    enum enemyInstance
    {
        RatWarrior,
        Zubat,
        Goblin,
        Dragon
    }

    // @desc: Een class voor de vijanden: RatWarrior, Zubat, Goblin en Drake. 
    // De vijanden worden in de constructor gedefinieerd.
    // @author: Iliass Nassibane
    // @date: 16-8-2016
    class ClassEnemy
    {
        public string name;
        public int health;
        public int attack;
        public enemyInstance type; // is een enum dat gebruikt gaat worden voor de RandCry() en RandDeathCry() methods.

        // @desc: Een constructor voor het instellen van de instance voor de enemy obj.
        public ClassEnemy(string Name)
        {
            string newName = Name.ToLower();

            switch(newName)
            {
                case "rat":
                    this.name = "RatWarrior";
                    this.health = 5;
                    this.attack = 2;
                    this.type = enemyInstance.RatWarrior;
                    break;
                case "bat":
                    this.name = "Zubat";
                    this.health = 15;
                    this.attack = 5;
                    this.type = enemyInstance.Zubat;
                    break;
                case "goblin":
                    this.name = "Goblin";
                    this.health = 30;
                    this.attack = 6;
                    this.type = enemyInstance.Goblin;
                    break;
                case "dragon":
                    this.name = "Elder Drake";
                    this.health = 30;
                    this.attack = 7;
                    this.type = enemyInstance.Dragon;
                    break;
            }
        }

        public void randCry()
        {
            enemyInstance param = this.type;
            Random rnd = new Random();
            int randomCreateNmbr = rnd.Next(1, 4);

            switch(param)
            {
                case enemyInstance.RatWarrior:
                    switch (randomCreateNmbr)
                    {
                        case 1:
                            Console.WriteLine("You will feel the pain!");
                            break;
                        case 2:
                            Console.WriteLine("Don't run away, my legs are too short!");
                            break;
                        case 3:
                            Console.WriteLine("I like wearing short pants, they feel comfy!");
                            break;
                    }
                    break;
                case enemyInstance.Zubat:
                    switch (randomCreateNmbr)
                    {
                        case 1:
                            Console.WriteLine("Zubat! Zuuuuuuuubat!");
                            break;
                        case 2:
                            Console.WriteLine("Quite right, my good sir! Let us engage in a duel!");
                            break;
                        case 3:
                            Console.WriteLine("EEEEEEEEEEEEEEP!");
                            break;
                    }
                    break;
                case enemyInstance.Goblin:
                    switch (randomCreateNmbr)
                    {
                        case 1:
                            Console.WriteLine("Dirty human!");
                            break;
                        case 2:
                            Console.WriteLine("Come over here, I have something to show you!");
                            break;
                        case 3:
                            Console.WriteLine("I like wearing women's clothing! I like wearing women's clothing!");
                            break;
                    }
                    break;
                case enemyInstance.Dragon:
                    switch (randomCreateNmbr)
                    {
                        case 1:
                            Console.WriteLine("Puny human! I will fry you like a hot pocket");
                            break;
                        case 2:
                            Console.WriteLine("A delicious meal before I go to my slumber!");
                            break;
                        case 3:
                            Console.WriteLine("My oh my, I did not know humans could be that ugly?");
                            break;
                    }
                    break;
            }
        }

        public void randDeathCry()
        {
            enemyInstance param = this.type;
            Random rnd = new Random();
            int randomCreateNmbr = rnd.Next(1, 4);

            switch (param)
            {
                case enemyInstance.RatWarrior:
                    switch (randomCreateNmbr)
                    {
                        case 1:
                            Console.WriteLine("Here is where I die?");
                            break;
                        case 2:
                            Console.WriteLine("I hate you, big guy!");
                            break;
                        case 3:
                            Console.WriteLine("sticks and stones may break my bones, but you have killed me!");
                            break;
                    }
                    break;
                case enemyInstance.Zubat:
                    switch (randomCreateNmbr)
                    {
                        case 1:
                            Console.WriteLine("Zugh....!");
                            break;
                        case 2:
                            Console.WriteLine("UGH!");
                            break;
                        case 3:
                            Console.WriteLine("KRAAAAAAAAAAACK!");
                            break;
                    }
                    break;
                case enemyInstance.Goblin:
                    switch (randomCreateNmbr)
                    {
                        case 1:
                            Console.WriteLine("Here is where I die?");
                            break;
                        case 2:
                            Console.WriteLine("I hate you, big guy!");
                            break;
                        case 3:
                            Console.WriteLine("sticks and stones may break my bones, but you have killed me!");
                            break;
                    }
                    break;
                case enemyInstance.Dragon:
                    switch (randomCreateNmbr)
                    {
                        case 1:
                            Console.WriteLine("How is this possible?!");
                            break;
                        case 2:
                            Console.WriteLine("By the seven ponies of friendship....UGH");
                            break;
                        case 3:
                            Console.WriteLine("ROAAAAAAAAAAAAAAAAAAAAAAAAAAAAAOWRGH!");
                            break;
                    }
                    break;
            }
        }
    }
}
