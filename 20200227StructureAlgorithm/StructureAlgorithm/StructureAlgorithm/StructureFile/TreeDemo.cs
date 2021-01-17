using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace StructureAlgorithm.StructureFile
{
    public class TreeDemo
    {

        public static void Show()
        {
            Expression<Func<int, int, int, int>> expression = (i, m, n) => i * 3 + m + 2 + n / 4;

            CustomBinarySearchTree tree1 = new CustomBinarySearchTree();
            tree1.Insert(10);
            tree1.SequentialTranversal();
            Console.WriteLine();
            tree1.Insert(5);
            tree1.SequentialTranversal();
            Console.WriteLine();
            tree1.Insert(1);
            tree1.SequentialTranversal();
            Console.WriteLine();

            tree1.Insert(8);
            tree1.SequentialTranversal();
            Console.WriteLine();
            tree1.Insert(20);
            tree1.SequentialTranversal();
            Console.WriteLine();
            tree1.Insert(28);
            tree1.SequentialTranversal();
            Console.WriteLine();
            tree1.Insert(12);
            tree1.SequentialTranversal();
            Console.WriteLine();
            tree1.Insert(6);
            tree1.SequentialTranversal();
            Console.WriteLine();
            tree1.Insert(7);
            tree1.SequentialTranversal();
            Console.WriteLine();
            tree1.Insert(25);
            tree1.SequentialTranversal();
            Console.WriteLine();

            Console.WriteLine(tree1.Min());
            Console.WriteLine(tree1.Max());
            Console.WriteLine(tree1.Find(25).iData);



        }


        private class CustomTreeNode
        {
            public int iData { get; set; }
            public CustomTreeNode Left { get; set; }
            public CustomTreeNode Right { get; set; }

            public void Show()
            {
                //中序遍历
                this.Left?.Show();
                Console.WriteLine(this.iData + " ");
                this.Right?.Show();

                //先序遍历
                Console.WriteLine(this.iData + " ");
                this.Left?.Show();
                this.Right?.Show();


                //后序遍历
                this.Left?.Show();
                this.Right?.Show();
                Console.WriteLine(this.iData + " ");


            }
        }

        /// <summary>
        /// 自定义二元查找树
        /// </summary>
        private class CustomBinarySearchTree
        {
            private CustomTreeNode _Root;

            public CustomBinarySearchTree()
            {
            }

            public CustomBinarySearchTree(CustomTreeNode rootNode)
            {
                this._Root = rootNode;
            }

            public int Min()
            {
                CustomTreeNode current = this._Root;
                while (current.Left != null)
                {
                    current = current.Left;
                }
                return current.iData;
            }
            public int Max()
            {
                CustomTreeNode current = this._Root;
                while (current.Right != null)
                {
                    current = current.Right;
                }
                return current.iData;
            }

            public CustomTreeNode Find(int i)
            {
                CustomTreeNode current = this._Root;
                while (current != null)
                {
                    if (i == current.iData)
                    {
                        return current;
                    }
                    else if (i > current.iData)
                    {
                        current = current.Right;
                    }
                    else
                    {
                        current = current.Right;
                    }
                }
                return null;
            }


            public void Insert(int i)
            {
                CustomTreeNode newNode = new CustomTreeNode();
                newNode.iData = i;
                if (_Root == null)
                {
                    _Root = newNode;
                }
                else
                {
                    CustomTreeNode current = this._Root;
                    CustomTreeNode parent;
                    while (true)
                    {
                        parent = current;
                        if (i < current.iData)
                        {
                            current = current.Left; // 下一个循环， 跟左边节点比较
                            if (current == null)
                            {
                                parent.Left = newNode;
                                break;
                            }
                        }
                        else
                        {
                            current = current.Right; // 下一个循环， 跟右边节点比较
                            if (current == null)
                            {
                                parent.Right = newNode;
                                break;
                            }
                        }

                    }
                }

            }

            /// <summary>
            /// 中序遍历
            /// </summary>
            public void SequentialTranversal()
            {
                this._Root.Show();
            }



        }

        /// <summary>
        /// 构造一个哈夫曼树
        /// 哈夫曼算法
        /// </summary>
        public class HuffumanTree
        {

            public void CreateTree()
            {

              //  List<int> values = new List<int>() { 7, 19, 2, 6, 32, 3, 21, 10 };
                List<int> values = new List<int>() { 5, 29, 7, 8, 14, 23, 3, 11 };
                int weightCount = values.Count;

                int m = weightCount * 2 - 1;

                List<HuffumanNode> nodes = new List<HuffumanNode>();
                for (int i = 0; i < weightCount; i++)
                {
                    HuffumanNode node = new HuffumanNode();
                    node.Weigth = values[i];
                    node.Parent = 0;
                    node.LeftChild = 0;
                    node.RightChild = 0;
                    node.ID = i + 1;

                    nodes.Add(node);
                }
  
                // set tree
                // 2n-1
                //1.选取连个最小的
                //8
                for (int i = weightCount; i < m; i++)
                {
                    // find two min node
                   var node = SelectNewNode(nodes,i);

                    if(node != null)
                    {
                        Console.WriteLine($"{node.ID}:{node.Weigth}");
                        nodes.Add(node);
                    }
                    
                }
                for (int i = 0; i < m; i++)
                {
                    var node = nodes[i];
                    Console.WriteLine($"ID:{node.ID} {node.Weigth} {node.Parent} {node.LeftChild} {node.RightChild}");
                }

            }

            public HuffumanNode SelectNewNode(List<HuffumanNode> nodes,int i)
            {
                var currentNode = new HuffumanNode();

                var temp = nodes;
                nodes = nodes.Where(t=> t.Parent == 0).OrderBy(t=> t.Weigth).ThenBy(t=> t.ID).ToList();
                if(nodes.Count == 0) //结束，构造最后一个节点,
                {
                    nodes = nodes.Where(t => t.Parent != 0).OrderByDescending(t => t.ID).ToList();
                    if(nodes.Count >= 2)
                    {
                        var node1 = nodes[0];
                        var node2 = nodes[1];
                        currentNode.ID = i + 1;
                        currentNode.Weigth = node1.Weigth + node2.Weigth;
                        currentNode.LeftChild = node1.ID;
                        currentNode.RightChild = node2.ID;
                        currentNode.Parent = 0;

                        node1.Parent = currentNode.ID;
                        node2.Parent = currentNode.ID;
                        return currentNode;
                    }
                    else
                    {
                        return default;
                    }
                }
                if(nodes.Count == 1)
                {
                    var node1 = nodes[0];

                    currentNode.ID = i+1;
                    currentNode.Weigth = node1.Weigth ;
                    currentNode.LeftChild = node1.ID;
                    currentNode.RightChild = 0;
                    currentNode.Parent = 0;

                    node1.Parent = currentNode.ID;
                }
                if(nodes.Count >= 2)
                {
                    var node1 = nodes[0];
                    var node2 = nodes[1];
                    currentNode.ID = i+1;
                    currentNode.Weigth = node1.Weigth + node2.Weigth;
                    currentNode.LeftChild = node1.ID;
                    currentNode.RightChild = node2.ID;
                    currentNode.Parent = 0;

                    node1.Parent = currentNode.ID;
                    node2.Parent = currentNode.ID;
                }


                return currentNode;
            }
        }
 
        public class HuffumanNode
        {
            public int ID { get; set; }
            public int Weigth { get; set; }
            public int Parent { get; set; }
            public int LeftChild { get; set; }
            public int RightChild { get; set; }
        }
    }
}
