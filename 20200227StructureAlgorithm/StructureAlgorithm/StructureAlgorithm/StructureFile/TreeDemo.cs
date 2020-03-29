using System;
using System.Collections.Generic;
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
                this.Left?.Show();
                Console.WriteLine(this.iData + " ");
                this.Right?.Show();

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
                while(current.Left != null)
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
                    if(i== current.iData)
                    {
                        return current;
                    }
                    else if(i > current.iData)
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
                        if(i < current.iData)
                        {
                            current = current.Left; // 下一个循环， 跟左边节点比较
                            if(current == null)
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
    }
}
