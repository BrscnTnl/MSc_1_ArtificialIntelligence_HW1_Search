using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1_1_20151014
{
    
    class PuzzleGenerator
    {
        /// <summary>
        /// Used in Shuffle(T).
        /// </summary>
        static Random _random = new Random();
        private int[,] Matrix;
        private List<int> MatrixArray = new List<int>();
        private int _sideLenght;

        public PuzzleGenerator()
        {
            _sideLenght = 3;
        }
        public int[,] Generate(int sideLenght = 3)
        {
            _sideLenght = sideLenght;
            Matrix = new int[sideLenght, sideLenght];

            for (int i = 0; i < sideLenght * sideLenght; i++)
            {
                MatrixArray.Add(i);
            }

            Matrix = GenerateMatrix(Shuffle(MatrixArray));
           
            //Matrix = new int[,] { {6,5,4 },{1,0,8 },{2,7,3 } };
            return Matrix;
        }

        #region Private Functions

        /// <summary>
        /// Shuffle the array.
        /// </summary>
        private List<int> Shuffle(List<int> array)
        {
            int n = array.Count;
            for (int i = 0; i < n; i++)
            {
                // NextDouble returns a random number between 0 and 1.
                // ... It is equivalent to Math.random() in Java.
                int r = i + (int)(_random.NextDouble() * (n - i));
                int t = array[r];
                array[r] = array[i];
                array[i] = t;
            }

            return array;
        }

        /// <summary>
        /// Generate final Matrix
        /// </summary>
        private int[,] GenerateMatrix(List<int> ShuffledList)
        {
            for (int x = 0; x < _sideLenght; x++)
            {
                for (int y = 0; y < _sideLenght; y++)
                {
                    Matrix[x, y] = ShuffledList.First();
                    ShuffledList.RemoveAt(0);
                }
            }
            return Matrix;
        }

        #endregion
    }
}
