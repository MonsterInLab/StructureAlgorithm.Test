using System;
using System.Collections.Generic;
using System.Text;

namespace StructureAlgorithm.StructureFile
{
    public class AVLTreeDemo
    {
        public static void Show()
        {
            int[] arr = { 3, 2, 1, 4, 5, 6, 7, 16, 15, 14, 13, 12, 11, 10, 8, 9 };

            int i;
            AVLTree tree = new AVLTree();

            // Console.WriteLine("*********依次添加");
            for (i = 0; i < arr.Length; i++)
            {
                tree.Insert(arr[i]);
            }

            Console.WriteLine("*********前序遍历");
            tree.PreTraversal();
            Console.WriteLine();

            Console.WriteLine("*********中序遍历");
            tree.SequentialTraversal();
            Console.WriteLine();


            Console.WriteLine("*********后序遍历");
            tree.PostTraversal();
            Console.WriteLine();

           
            tree.Remove(7);
            Console.WriteLine("*********删除：7");
            Console.WriteLine("*********前序遍历");
            tree.PreTraversal();
            Console.WriteLine();

            Console.WriteLine("*********中序遍历");
            tree.SequentialTraversal();
            Console.WriteLine();
          
        }


    }

    public class AVLTree {

        public Node Root; 

        public AVLTree()
        {

        }

        public Node Min(Node node)
        {
            if(node == null)
            {
                return null;
            }
            else if(node.Left == null)
            {
                return node;
            }
            else
            {
                return Min(node.Left);
            }
        }

        private Node Max(Node node)
        {
            if (node == null)
            {
                return null;
            }
            else if (node.Right == null)
            {
                return node;
            }
            else
            {
                return Max(node.Right);
            }
        }

        #region 高度
        private int NodeHeight(Node node)
        {
            if(node != null)
            {
                return node.Hieght;
            }
            return 0;
        }

        public int TreeHeight()
        {
            return Root.Hieght;
        }
        #endregion

        #region private
        private int ChooseMax(int a,int b)
        {
            if (a > b)
                return a;
            else
                return b;
        }

        private void ReplaceNode(Node src, Node tar)
        {
            tar.Value = src.Value;
        }


        #endregion

        #region 4种旋转
        private Node LeftLeftRotation(Node k1)
        {
            Node k2 = k1.Left; // k2是k1的左子树

            k1.Left = k2.Right;  // k2的右子树 变为k1的左子树
            k2.Right = k1;   //k1 变为 k2的右子树

            k1.Hieght = ChooseMax(NodeHeight(k1.Left), NodeHeight(k1.Right)) + 1;
            k2.Hieght = ChooseMax(NodeHeight(k2.Left),k1.Hieght) + 1;

            return k2;
        }

        private Node RightRightRotation(Node k1)
        {
            Node k2 = k1.Right; // k2是k1的左子树

            k1.Right = k2.Left; 
            k2.Left = k1;  

            k1.Hieght = ChooseMax(NodeHeight(k1.Left), NodeHeight(k1.Right)) + 1;
            k2.Hieght = ChooseMax(NodeHeight(k2.Left), k1.Hieght) + 1;

            return k2;
        }


        private Node LeftRightRotation(Node k1)
        {
            k1.Left = RightRightRotation(k1.Left);
            return LeftLeftRotation(k1);
        }

        private Node RightLeftRotation(Node k1)
        {
            k1.Right = LeftLeftRotation(k1.Right);
            return RightRightRotation(k1);
        }

        #endregion

        #region 插入

        public void Insert(int value)
        {
            this.Root = Insert(this.Root, value);
        }

        private Node Insert(Node node,int value)
        {
            if (node == null) return new Node(value);

            if(node.CompareTo(value) == 0)
            {
                node.Value = value;
            }
            else if(node.CompareTo(value) < 0)
            {// 如过key比当前节点小，则去找左子树
                node.Left = Insert(node.Left, value);
                if(Math.Abs(NodeHeight(node.Left) - NodeHeight(node.Right)) == 2)
                {//高度差等于2表示已经不平衡
                    if(node.Left.CompareTo(value) < 0)
                    { //左左型
                        node = LeftLeftRotation(node);

                    }
                    else
                    {
                        node = LeftRightRotation(node);
                    }
                }

            }
            else
            {
                node.Right = Insert(node.Right, value);
                if(Math.Abs(NodeHeight(node.Right) - NodeHeight(node.Left)) == 2)
                {
                    if (node.Right.CompareTo(value) > 0)
                    {// 右右型
                        node = RightRightRotation(node);
                    }
                    else
                    {
                        //右左型
                        node = RightLeftRotation(node);
                    }
                }
            }

            node.Hieght = ChooseMax(NodeHeight(node.Left), NodeHeight(node.Right))+1;

            return node;
        }

        #endregion

        #region 删除 

        public void Remove(int value)
        {
            Node z = Search(Root, value);
            if(z != null)
            {
                Root = Remove(Root, z);
            }
        }

        private Node Remove(Node node,Node target)
        {
            if (node == null || target == null) return node;
            int compare = node.CompareTo(target.Value);

            if(compare < 0)
            { // 待删除key  比根小，继续往左子树查找
                node.Left = Remove(node.Left, target);
                if(Math.Abs(NodeHeight(node.Right) - NodeHeight(node.Left)) == 2)
                {// 如果删除后失去平衡
                    if(NodeHeight(node.Right.Left) <= NodeHeight(node.Right.Right))
                    {
                        node = RightRightRotation(node);
                    }
                    else
                    {
                        node = RightLeftRotation(node);
                    }
                }
            }
            else if(compare > 0)
            {// 待删除key  比根大，继续往右子树查找
                node.Right = Remove(node.Right, target);
                if (Math.Abs(NodeHeight(node.Left) - NodeHeight(node.Right)) == 2)
                {// 如果删除后失去平衡
                    if (NodeHeight(node.Left.Right) <= NodeHeight(node.Left.Left))
                    {
                        node = LeftLeftRotation(node);
                    }
                    else
                    {
                        node = LeftRightRotation(node);
                    }
                }
            }
            else
            {
                // node.value == target.value, delete this node
                if(node.Left == null)
                {//如果node的左子树为空，  那么删除node后，新的根就是node.right
                    return node.Right;
                }
                else if (node.Right == null)
                {// 如果node的右子树为空，那么删除node后，新的根就是node.left
                    return node.Left;
                }
                else
                { // 如果node既有左子树，又有右子树
                    if (NodeHeight(node.Left) > NodeHeight(node.Right))
                    {//如果左子树比右子树深
                        Node predecessor = Max(node.Left);//找node的前继结点predecessor
                        ReplaceNode(predecessor, node);//predecessor替换node
                        node.Left = Remove(node.Left, predecessor);//再把原来的predecessor删掉
                    }
                    else
                    {//如果右子树比左子树深(一样深的话无所谓了)
                        Node successor = Min(node.Right);//找node的后继结点successor
                        ReplaceNode(successor, node);//successor替换node
                        node.Right = Remove(node.Right, successor);//再把原来的successor删掉
                    }
                }
            }
            return node;
        }

        #endregion

        #region 查找
        public Node Search(Node root,int value)
        {
            if(root == null)
            {
                return null;
            }
            if(root.CompareTo(value) == 0)
            {
                return root;
            }
            else if(root.CompareTo(value) < 0)
            {
               return Search(root.Left,value);
            }
            else
            {
                return Search(root.Right, value);
            }
        }

        #endregion
        #region 遍历
        public void PreTraversal()
        {
            PreTraversal(Root);
        }

        public void SequentialTraversal()
        {
            SequentialTraversal(Root);
        }

        public void PostTraversal()
        {
            PostTraversal(Root);
        }


        // 先序遍历
        public void PreTraversal(Node root)
        {
           if(root != null)
            {
                Console.Write(root.Value + " ");
                PreTraversal(root.Left);
                PreTraversal(root.Right);
            }     
        }

        //中序遍历
        public void SequentialTraversal(Node root)
        {
            if (root != null)
            {
                SequentialTraversal(root.Left);
                Console.Write(root.Value + " ");
                SequentialTraversal(root.Right);
            }
        }

        //后序遍历
        public void PostTraversal(Node root)
        {
            if (root != null)
            {
                PostTraversal(root.Left);
                SequentialTraversal(root.Right);
                Console.Write(root.Value + " ");
            }
        }

        #endregion

    }

    public class Node : IComparable
    {
        public int Value;
        public int Hieght; //节点的高度
        public Node Left;
        public Node Right;

        public Node(int value)
        {
            Value = value;
            Left = null;
            Right = null;
            Hieght = 1;
        }


        public int CompareTo(object value)
        {
            int.TryParse(value.ToString(), out int targetValue);
            if(targetValue > this.Value)
            {
                return 1;
            }
            else if(targetValue < this.Value)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }


        //前序遍历
        public void ShowPreTraversal()
        {
            Console.Write(Value + " ");
            Left?.ShowPreTraversal();
            Right?.ShowPreTraversal();
        }

        //中序遍历
        public void ShowSequentialTraversal()
        {
          
            Left?.ShowSequentialTraversal();
            Console.Write(Value + " ");
            Right?.ShowSequentialTraversal();
        }

        //后序遍历
        public void ShowPostTraversal()
        {

            Left?.ShowPostTraversal();
            Right?.ShowPostTraversal();
            Console.Write(Value + " ");
        }
    }
}
