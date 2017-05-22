using HW1_1_20151014.Algorithms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW1_1_20151014
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


        }
        int _sideLenght;
        string text;
        private void button1_Click(object sender, EventArgs e)
        {
            
            for (int i = 0; i < 10; i++)
            {
                //BFS Breadth = new BFS();
                //DFS Depth = new DFS();
                UCS Uniform = new UCS();
                PuzzleGenerator pzzlGnrtr = new PuzzleGenerator();
                _sideLenght = (int)numericUpDown1.Value;
                Stopwatch stopwatch = Stopwatch.StartNew();
                //text += ToStr(Breadth.Solve(pzzlGnrtr.Generate((int)numericUpDown1.Value), (int)numericUpDown1.Value));
                //text += ToStr(Depth.Solve(pzzlGnrtr.Generate((int)numericUpDown1.Value), (int)numericUpDown1.Value));
                text += ToStr(Uniform.Solve(pzzlGnrtr.Generate((int)numericUpDown1.Value), (int)numericUpDown1.Value));
                stopwatch.Stop();
                text += "UCS - Geçen Süre : " + stopwatch.ElapsedMilliseconds + " Milisaniye\n";
            }
            
            textBox1.Text = text;

            string path = "D:\\Yüksek Lisans\\Artificial Intelligence\\HW\\1\\Output\\" + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + ".txt";
            System.IO.StreamWriter file = new System.IO.StreamWriter(path);
            file.WriteLine(text);
            file.WriteLine();
            file.Close();
        }
        public string ToStr(int[,] Matrix)
        {
            StringBuilder abc = new StringBuilder();
            for (int i = 0; i < _sideLenght; i++)
            {
                for (int k = 0; k < _sideLenght; k++)
                {
                    if(Matrix[i, k]<10)
                        abc.Append(Matrix[i, k] + "  ");
                    else
                        abc.Append(Matrix[i, k] + " ");
                }
                abc.AppendLine();
            }
            abc.AppendLine();
            abc.Append("Size : " + sizeof(int) * _sideLenght * _sideLenght + " byte");
            
            return abc.ToString();
        }

        public string ToStr(List<int[,]> Queue)
        {
            StringBuilder abc = new StringBuilder();
            foreach (int[,] Matrix in Queue)
            {
                for (int i = 0; i < _sideLenght; i++)
                {
                    for (int k = 0; k < _sideLenght; k++)
                    {
                        if (Matrix[i, k] < 10)
                            abc.Append(Matrix[i, k] + "  ");
                        else
                            abc.Append(Matrix[i, k] + " ");
                    }
                    abc.AppendLine();
                }

                abc.AppendLine(); abc.AppendLine();
            }
            abc.AppendLine();
            abc.Append("Size : " + sizeof(int) * _sideLenght * _sideLenght * Queue.Count + " byte");
            return abc.ToString();
        }

        public string ToStr(List<BFSItem> Queue)
        {
            StringBuilder abc = new StringBuilder();
            //foreach (BFSItem Matrix in Queue)
            //{
            //    abc.Append("Level : " + Matrix.Level + ", ID : " + Matrix.ID + ", Parent ID : " + Matrix.parentID);
            //    abc.AppendLine();
            //    for (int i = 0; i < _sideLenght; i++)
            //    {
            //        for (int k = 0; k < _sideLenght; k++)
            //        {
            //            if (Matrix.Matrix[i, k] < 10)
            //                abc.Append(Matrix.Matrix[i, k] + "  ");
            //            else
            //                abc.Append(Matrix.Matrix[i, k] + " ");
            //        }
            //        abc.AppendLine();
            //    }

            //    abc.AppendLine(); abc.AppendLine();
            //}
            abc.AppendLine();
            abc.AppendLine("Size : " + sizeof(int) * _sideLenght * _sideLenght * Queue.Count + " byte");
            abc.AppendLine("Node Count : " + Queue.Count);
            abc.AppendLine("Max Level : " + Queue.Max(x=> x.Level));
            abc.AppendLine("Is Complete : " + (Queue.Where(x => x.isComplete).ToList().Count > 0 ? "Yes" : "No"));
            
            return abc.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            



            
            //System.IO.File.WriteAllText(path, text);
        }
    }
}
