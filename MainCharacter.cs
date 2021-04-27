using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuclearWorld
{
    public class MainCharacter
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public string FighterClass { get; set; }
        public List<Item> MainInventory { get; set; } = new List<Item>();






        public static int Heal(int health, int heals)
        {
            if (heals > health)
            {
                return 100;
            }
            else
            {
                return health + heals;
            }
        }





    }
}
