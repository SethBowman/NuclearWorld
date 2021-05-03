using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuclearWorld
{
    public class Combat
    {
        public static int Fighting(int attack, int health)
        {
            if (health <= 0)
            {
                return 0;
            }
            else
            {
                return attack - health;
            }
        }

    }
}
