using System;
using System.Collections.Generic;
using System.Text;

namespace StructureAlgorithm.StructureFile
{
    public class LinkedListDemo
    {
        public static void Show()
        {
             CustomStack<string> stack = new CustomStack<string>();
            foreach (var item in "A-B-C-D-E-F-G".Split("-"))
            {
                stack.Push(item);
            }

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(stack.Pop());
                Console.WriteLine(stack.Peek());
               // Console.WriteLine(stack.Pop());
            }



            #region LinkedList
            LinkedList<string> link = new LinkedList<string>();
            LinkedListNode<string> node1 = new LinkedListNode<string>("E1");
            LinkedListNode<string> node2 = new LinkedListNode<string>("E2");
            LinkedListNode<string> node3 = new LinkedListNode<string>("E3");
            LinkedListNode<string> node4 = new LinkedListNode<string>("E4");


            link.AddFirst(node1);
            link.AddAfter(node1, node2);
            link.AddAfter(node2, node3);
            link.AddAfter(node3, node4);

            //3.计算包含的数量
            Console.WriteLine(link.Count);

            //4.显示
            LinkedListNode<string> current = link.First;
            while(current != null)
            {
                Console.WriteLine(current.Value);
                current = current.Next;
            }

            //5.查找
            LinkedListNode<string> temp = link.Find("jiajia2");
            if (temp != null)
            {
                Console.WriteLine("找到这个节点" + temp.Value);
            }

            //6.定位最后节点
            temp = link.Last;
            Console.WriteLine("最后这个节点" + temp.Value);

            //7.一些删除操作
            link.RemoveFirst();
            link.Remove("jiajia2");
            link.Clear();
            #endregion

        }


        private class CustomNode<T>
        {
            public T Element;
            public CustomNode<T> NextNode;


            public CustomNode()
            {
                Element = default(T);
                NextNode = null;
            }

            public CustomNode(T theElement)
            {
                Element = theElement;
                NextNode = null;
            }
        }

        /// <summary>
        /// 单向链表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        private class CustomLinkList<T>
        {
            private CustomNode<T> _CurrentHeader;

            public CustomLinkList()
            {
                this._CurrentHeader = new CustomNode<T>(default(T));
            }
            public CustomLinkList(CustomNode<T> header)
            {
                this._CurrentHeader = header;
                
            }

            public void Add(T t)
            {
                CustomNode<T> node = new CustomNode<T>(t);
                node.NextNode = _CurrentHeader;
                _CurrentHeader = node;
            }

            public T Get()
            {
                T t = _CurrentHeader.Element;
                return t;
            }

            public T GetAndRemove()
            {
                T t = _CurrentHeader.Element;
                CustomNode<T> node = _CurrentHeader.NextNode;
                _CurrentHeader = node;
                return t;
            }
        }


        private class CustomStack<T>
        {
            private CustomLinkList<T> _Container = new CustomLinkList<T>();

            public void Push(T t)
            {
                this._Container.Add(t);
            }

            public T Pop()
            {
                return this._Container.GetAndRemove();
            }

            public T Peek()
            {
                return this._Container.Get();
            }


        }





    }
}
