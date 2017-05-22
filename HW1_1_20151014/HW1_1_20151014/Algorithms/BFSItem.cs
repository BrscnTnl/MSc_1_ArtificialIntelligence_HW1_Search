using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1_1_20151014.Algorithms
{
    public class BFSItem
    {
        public bool isComplete = false;
        public bool isExpanded = false;
        public bool isChecked = false;
        public int[,] Matrix;
        public int Level = 0;
        public string parentID;
        public string ID;
        public int Cost;
    }
}
