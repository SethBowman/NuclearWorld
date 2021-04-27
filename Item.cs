using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuclearWorld
{
    public class Item
    {
        //Property
        public string Name { get; set; }
        public decimal Value { get; set; }
        public int HealValue { get; init; } = 0;
    }
}
