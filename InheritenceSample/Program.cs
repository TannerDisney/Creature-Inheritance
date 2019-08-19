using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritenceSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Player p1 = new Player("Link");
            p1.Attack = 100;
            p1.Health = 25.5;
            p1.Stamina = 15.5;
            p1.Race = "Elf";

            Item potion = new Item()
            {
                ItemId = 1000,
                Name = "Small Healing Potion",
                MonetaryValue = 25
            };

            Item sword = new Item()
            {
                ItemId = 5000,
                Name = "Greatsword",
                MonetaryValue = 1000
            };


            Enemy e1 = new Enemy("Ganon");
            e1.EnemyId = 1;
            e1.Defence = 100;
            // 5.5 hours to respawn
            e1.RespawnRate = new TimeSpan(5, 30, 0);
            e1.ItemDrops.Add(potion);
            e1.ItemDrops.Add(sword);

            Creature c = new Player("Zelda");
            // How can we set stamina when we know the creature is a player
            //c.Stamina = 5;
            c.Race = "Human";

            /*
                DisplayCreature(p1);
                DisplayCreature(e1);
                DisplayCreature(c);
            */
            List<Creature> allCreatures = new List<Creature>()
            {
                p1, e1, c
            };

            foreach (Creature entity in allCreatures)
            {
                DisplayCreature(entity);
            }   

            Console.ReadKey();
            
        }

        private static void DisplayCreature(Creature c)
        {
            if (c is Enemy)
            {
                Enemy currEnemy = c as Enemy;
                Console.WriteLine("Enemy: " + currEnemy.Name);
                Console.WriteLine("Hidden Stats...\n");
            }
            else
            {
                Console.WriteLine(c.GetDisplayText("\n") + "\n");
            }
        }
    }
}
