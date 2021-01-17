using StructureAlgorithm.AlgorithmFile;
using StructureAlgorithm.StructureFile;
using System;
using static StructureAlgorithm.StructureFile.TreeDemo;

namespace StructureAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {

            //BasicSearchDemo.Show();

            //BasicSortDemo.Show();

            // LinkedListDemo.Show();
            //TreeDemo.Show();

            //AdvancedSortDemo.Show();

            //  AVLTreeDemo.Show();


            //GraphDemo.Show();

            DijkstraDemo.Show();

            //哈夫曼树
            new HuffumanTree().CreateTree();
        }
    }
}
