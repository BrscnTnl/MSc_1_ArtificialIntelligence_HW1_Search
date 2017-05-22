using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1_1_20151014.Algorithms
{
    class DFS
    {
        int GlobalLevel = 0;
        List<BFSItem> QueueList = new List<BFSItem>();
        public List<BFSItem> Solve(int[,] Matrix, int sideLenght)
        {

            int NodeCount = 1;

            QueueList.AddRange(BFSFabric(Matrix));

            //foreach(BFSItem _BFSItem in QueueList)
            for (int i = 0; i < NodeCount; i++)
            {
                BFSItem _BFSItem = QueueList.ElementAt(i);

                if (_BFSItem.Matrix.isComplete(sideLenght))
                {
                    _BFSItem.isExpanded = true;
                    _BFSItem.isComplete = true;
                    _BFSItem.isChecked = true;
                    break;
                }
                else
                {
                    _BFSItem.isComplete = false;
                    _BFSItem.isChecked = true;

                    if (QueueList.Where(x => !x.isChecked).ToList().Count == 0 && GlobalLevel < 10000)
                    {
                        GlobalLevel++;
                        foreach (BFSItem item in QueueList.Where(x => !x.isExpanded).ToList())
                        {
                            item.isExpanded = true;
                            QueueList.AddRange(BFSFabric(item.Matrix.GetNeighbourCombinationsForDFS(sideLenght), GlobalLevel, item.ID, sideLenght));
                        }
                        NodeCount = QueueList.Count;
                    }
                }

            }


            return QueueList;
        }

        //public List<BFSItem> BFSFabric(List<int[,]> Queue,int level, List<int[,]> QueueListParent, int sideLenght)
        public List<BFSItem> BFSFabric(List<int[,]> Queue, int level, string Parent, int _sideLenght)
        {
            List<BFSItem> QueueListTemp = new List<BFSItem>();
            bool isEqual = true;
            //bool isEqual = true;
            foreach (int[,] _Matrix in Queue)
            {

                foreach (BFSItem item in QueueList)
                {
                    for (int i = 0; i < _sideLenght; i++)
                    {
                        for (int j = 0; j < _sideLenght; j++)
                        {
                            if (!item.Matrix[i, j].Equals(_Matrix[i, j]))
                            {
                                isEqual = false;
                            }
                        }
                    }
                }


                if (!isEqual)
                    QueueListTemp.Add(
                        new BFSItem()
                        {
                            Level = level,
                            isComplete = false,
                            isExpanded = false,
                            isChecked = false,
                            Matrix = _Matrix,
                            ID = Guid.NewGuid().ToString(),
                            parentID = Parent
                        }
                        );
            }

            return QueueListTemp;
        }
        public List<BFSItem> BFSFabric(int[,] Queue)
        {
            List<BFSItem> QueueList = new List<BFSItem>();
            QueueList.Add(
                    new BFSItem()
                    {
                        Level = 0,
                        isComplete = false,
                        isExpanded = false,
                        isChecked = false,
                        Matrix = Queue,
                        parentID = Guid.NewGuid().ToString(),
                        ID = Guid.NewGuid().ToString()
                    }
                    );

            return QueueList;
        }
    }
}
