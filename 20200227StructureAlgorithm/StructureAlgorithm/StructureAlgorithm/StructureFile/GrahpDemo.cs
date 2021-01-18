using System;

namespace StructureAlgorithm.StructureFile
{
    public class GrahpDemo
    {
        //图中所能包含的点上限
        private const int MaxVerNumber = 5;      
        //顶点数组
        private Vertex[] Vertices;
        //邻接矩阵  adjacency matrix
        public int[,] AdjMatrix;        
        //顶点数
        public int VertCount = 0;
        //边数
        public int ArcCount = 0;


        public GrahpDemo()
        {
            //初始顶点数组
            Vertices = new Vertex[MaxVerNumber];
            // 邻接矩阵
            AdjMatrix = new int[MaxVerNumber, MaxVerNumber];                        

            //将代表邻接矩阵的表全初始化为0
            for (int i = 0; i <= MaxVerNumber; i++)
            {
                for (int j = 0; j < MaxVerNumber; j++)
                {
                    AdjMatrix[i, j] = 0;
                }
            }
        }

        public void DemoTest()
        {
            AddVertex("a");
            AddVertex("b");
            AddVertex("c");
            AddVertex("d");
            AddVertex("e");

            AddEdge("a", "b",1);
            AddEdge("a", "e",1);
            AddEdge("b", "c",1);
            AddEdge("b", "d",1);
            AddEdge("c", "d",1);
            AddEdge("c", "e",1);


        }

        //向图中添加节点
        public  void AddVertex(string v)
        {
            Vertices[VertCount] = new Vertex(v);
            VertCount++;
        }

        public int FindVertex(string ver)
        {
            for (int i = 0; i < VertCount; i++)
            {
                if (Vertices[i].Data == ver)
                    return i;
            }
            return -1;
        }

        //向图中添加有向边
        public void AddEdge(string vertex1, string vertex2,int weight)
        {
            var i = FindVertex(vertex1);
            var j = FindVertex(vertex2);
            if(i >-1 && j > -1)
            {
                AdjMatrix[i, j] = weight;
                AdjMatrix[j, i] = weight;  //设置对称边的权值 无向图
            }
        }

        //public void AddEdge(int vertex1, int vertex2)
        //{
        //    AdjMatrix[vertex1, vertex2] = 1;
        //    //adjmatrix[vertex2, vertex1] = 1;
        //}

        //向图中添加有向边 带权
        public void AddEdge(int vertex1, int vertex2,int weigth)
        {
            AdjMatrix[vertex1, vertex2] = weigth;
            //adjmatrix[vertex2, vertex1] = 1;
        }

        //显示点
        public void DisplayVert(int vertexPosition)
        {
            Console.WriteLine(Vertices[vertexPosition] + " ");
        }

        //寻找图中没有后继节点的点
        //具体表现为邻接矩阵中某一列全为0
        //此时返回行号，如果找不到返回-1
        private int FindNoSuccessor()
        {
            bool isEdge;
            //循环行
            for (int i = 0; i < VertCount; i++)
            {
                isEdge = false;
                //循环列，有一个1就跳出循环
                for (int j = 0; j < VertCount; j++)
                {
                    if (AdjMatrix[i, j] == 1)
                    {
                        isEdge = true;
                        break;
                    }
                }
                if (!isEdge)
                {
                    return i;
                }
            }
            return -1;

        }


    }
     
    public class Vertex
    {
        public string Data;
        public bool IsVisited;
        public Vertex(string Vertexdata)
        {
            Data = Vertexdata;
        }
    }




}
