using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HW1_1_20151014.Algorithms.Utils;

namespace HW1_1_20151014.Algorithms
{
     class Item
    {
        public int[,] CurrentState;
        public int[,] PreviousState;
        public Direction FromDirection;
        public List<Item> NextStates;
        public int Level = 0;
        public bool isExpanded;
    }

    

}
