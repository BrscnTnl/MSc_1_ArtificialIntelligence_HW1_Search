using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1_1_20151014.Algorithms
{
    static class Utils
    {
        public static int[,] Swapper( int[,] Matrix, int x, int y, int a, int b)
        {
            int Temp;
            int[,] originalValues = (int[,])Matrix.Clone();
            Temp = originalValues[x, y];
            originalValues[x, y] = originalValues[a, b];
            originalValues[a, b] = Temp;

            return originalValues;
        }

        
        public static List<int[,]> GetNeighbourCombinationsForBFS(this int[,] Matrix, int sideLenght)
        {
            Item nextSteps = new Item();
            List<int[,]> Neighbours = new List<int[,]>();

            for (int i = 0; i < sideLenght; i++)
            {
                for (int j = 0; j < sideLenght; j++)
                {
                    if (Matrix[i, j] == 0)
                    {
                        // Considering Clock-wise
                        if (i == 0)
                        {
                            //Up-Left Corner
                            if (j == 0)
                            {
                                Neighbours.Add(Swapper(Matrix,i, j, i, j + 1));
                                Neighbours.Add(Swapper(Matrix,i, j, i + 1, j));
                            }

                            //Up-Right Corner
                            else if (j == (sideLenght - 1))
                            {
                                Neighbours.Add(Swapper(Matrix,i, j, i + 1, j));
                                Neighbours.Add(Swapper(Matrix,i, j, i, j - 1));
                            }

                            //First line but not corners
                            else if (j != 0 || j != (sideLenght - 1))
                            {
                                Neighbours.Add(Swapper(Matrix,i, j, i, j + 1));
                                Neighbours.Add(Swapper(Matrix,i, j, i + 1, j));
                                Neighbours.Add(Swapper(Matrix,i, j, i, j - 1));
                            }
                        }

                        else if(i == (sideLenght - 1))
                        {
                            //Down-Left Corner
                            if (j == 0)
                            {
                                Neighbours.Add(Swapper(Matrix,i, j, i - 1, j));
                                Neighbours.Add(Swapper(Matrix,i, j, i, j + 1));
                            }

                            //Down-Right Corner
                            else if (j == (sideLenght - 1))
                            {
                                Neighbours.Add(Swapper(Matrix,i, j, i, j - 1));
                                Neighbours.Add(Swapper(Matrix,i, j, i - 1, j));
                            }

                            //Last line but not corners
                            else if (j != 0 || j != (sideLenght - 1))
                            {
                                Neighbours.Add(Swapper(Matrix,i, j, i, j + 1));
                                Neighbours.Add(Swapper(Matrix,i, j, i, j - 1));
                                Neighbours.Add(Swapper(Matrix,i, j, i - 1, j));
                            }
                        }


                        else if (i != 0 || i != (sideLenght - 1))
                        {
                            //Most Left
                            if (j == 0)
                            {
                                Neighbours.Add(Swapper(Matrix,i, j, i - 1, j));
                                Neighbours.Add(Swapper(Matrix,i, j, i, j + 1));
                                Neighbours.Add(Swapper(Matrix,i, j, i + 1, j));
                            }

                            //Most Right
                            else if (j == (sideLenght - 1))
                            {
                                Neighbours.Add(Swapper(Matrix,i, j, i + 1, j));
                                Neighbours.Add(Swapper(Matrix,i, j, i, j - 1));
                                Neighbours.Add(Swapper(Matrix,i, j, i - 1, j));
                            }

                            //Rest of Square
                            else if (j != 0 || j != (sideLenght - 1))
                            {
                                Neighbours.Add(Swapper(Matrix,i, j, i - 1, j));
                                Neighbours.Add(Swapper(Matrix,i, j, i, j + 1));
                                Neighbours.Add(Swapper(Matrix,i, j, i + 1, j));
                                Neighbours.Add(Swapper(Matrix,i, j, i, j - 1));
                            }
                        }
                    }

                }
            }

            return Neighbours;
        }


        public static List<int[,]> GetNeighbourCombinationsForDFS(this int[,] Matrix, int sideLenght)
        {
            Item nextSteps = new Item();
            List<int[,]> Neighbours = new List<int[,]>();

            for (int i = 0; i < sideLenght; i++)
            {
                for (int j = 0; j < sideLenght; j++)
                {
                    if (Matrix[i, j] == 0)
                    {
                        // Considering Clock-wise
                        if (i == 0)
                        {
                            //Up-Left Corner
                            if (j == 0)
                            {
                                Neighbours.Add(Swapper(Matrix, i, j, i, j + 1));
                                
                            }

                            //Up-Right Corner
                            else if (j == (sideLenght - 1))
                            {
                                Neighbours.Add(Swapper(Matrix, i, j, i + 1, j));
                                
                            }

                            //First line but not corners
                            else if (j != 0 || j != (sideLenght - 1))
                            {
                                Neighbours.Add(Swapper(Matrix, i, j, i, j + 1));
                                
                            }
                        }

                        else if (i == (sideLenght - 1))
                        {
                            //Down-Left Corner
                            if (j == 0)
                            {
                                Neighbours.Add(Swapper(Matrix, i, j, i - 1, j));
                                
                            }

                            //Down-Right Corner
                            else if (j == (sideLenght - 1))
                            {
                                Neighbours.Add(Swapper(Matrix, i, j, i, j - 1));
                                
                            }

                            //Last line but not corners
                            else if (j != 0 || j != (sideLenght - 1))
                            {
                                Neighbours.Add(Swapper(Matrix, i, j, i, j + 1));
                                
                            }
                        }


                        else if (i != 0 || i != (sideLenght - 1))
                        {
                            //Most Left
                            if (j == 0)
                            {
                                Neighbours.Add(Swapper(Matrix, i, j, i - 1, j));
                                
                            }

                            //Most Right
                            else if (j == (sideLenght - 1))
                            {
                                Neighbours.Add(Swapper(Matrix, i, j, i + 1, j));
                                
                            }

                            //Rest of Square
                            else if (j != 0 || j != (sideLenght - 1))
                            {
                                Neighbours.Add(Swapper(Matrix, i, j, i - 1, j));
                                
                            }
                        }
                    }

                }
            }

            return Neighbours;
        }
        public static bool isComplete(this int[,] Matrix,int sideLenght)
        {
            int temp = 0;
            for (int i = 0; i < sideLenght; i++)
            {
                for (int j = 0; j < sideLenght; j++)
                {
                    if (Matrix[i, j] != temp)
                    {
                        return false;
                    }
                    temp++;
                }
            }
            return true;
        }

        public enum Direction
        {
            North=1,
            East=2,
            South=3,
            West=4
        };

        public static Item ItemFabric(Direction fromDirection, int[,] previousState,int[,] currentState)
        {
            return new Item()
            {
                PreviousState = previousState,
                FromDirection = fromDirection,
                CurrentState = currentState,
                NextStates = null
            };
        }

        public static int GetCost(this int[,] Matrix, int sideLenght)
        {
            int temp = 0;
            for (int i = 0; i < sideLenght; i++)
            {
                for (int j = 0; j < sideLenght; j++)
                {
                    temp += Math.Abs(Matrix[i, j] - ((i * sideLenght) + j));
                }
            }
            return temp;

        }
    }
}
