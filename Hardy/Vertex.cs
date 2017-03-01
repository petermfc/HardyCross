using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Hardy
{
    [Serializable]
    public class Vertex<T>
    {
        private int index;
        public int Index { get { return index; } set { this.index = value; } }
        private T data;
        public T Data { get { return data; } set { this.data = value; } }
    }

    [Serializable]
    public class Graph<T>
    {
        public int nodeNumber = 0;
        private List<Vertex<T>> vertices;
        public List<Vertex<T>> Vertices
        {
            get
            {
                return this.vertices;
            }
        }

        List<List<Edge<T>>> edges;
        public List<List<Edge<T>>> Edges
        {
            get
            {
                return this.edges;
            }
        }

        public Graph()
        {
            vertices = new List<Vertex<T>>();
            edges = new List<List<Edge<T>>>();
        }

        public int[][] AsListOfEdges()
        {
            List<int[]> res = new List<int[]>();
            for(int i = 0; i < Vertices.Count; i++)
            {
                for(int j = 0; j < Vertices.Count; j++)
                {
                    if(edges[i][j].Value)
                    {
                        int[] e = { i + 1, j + 1 };
                        res.Add(e);
                    }
                }
            }
            return res.ToArray();
        }

        public void Add(Vertex<T> vertex)
        {
            ++nodeNumber;
            vertex.Index = nodeNumber;
            vertices.Add(vertex);
            edges.Add(new List<Edge<T>>(Convert.ToInt32(nodeNumber)));
            for (int i = 0; i < edges.Count; i++) //do not process last column
            {
                List<Edge<T>> oldLst = edges[i];
                edges[i] = Enumerable.Repeat(new Edge<T>(), edges.Count - oldLst.Count).ToList();
                edges[i].InsertRange(0, oldLst);
            }
        }

        public void Remove(Vertex<T> vertex)
        {
            int index = Vertices.IndexOf(vertex);
            foreach (var lst in Edges)
                lst.RemoveAt(index);
            Edges.RemoveAt(index);
            for (int i = index; i < vertices.Count; i++)
                vertices[i].Index--;
            nodeNumber--;
            Vertices.Remove(vertex);
        }

        public void AddEdge(Vertex<T> v1, Vertex<T> v2)
        {
            bool ccw = false;
            if (v1.Index < v2.Index)
                ccw = false;
            else
                ccw = true;
            edges[v1.Index-1][v2.Index-1] = edges[v2.Index - 1][v1.Index - 1] = new Edge<T> { Beginning = v1, End = v2,  Value = true, Length = 0, DrawReversed = ccw };
        }

        public void RemoveEdge(Vertex<T> v1, Vertex<T> v2)
        {
            edges[v1.Index - 1][v2.Index - 1] = edges[v2.Index - 1][v1.Index - 1] = new Edge<T>() { Value = false, Length = 0 };
        }

        public bool isConnected(Vertex<T> v1, Vertex<T> v2)
        {
            if (edges[v1.Index - 1][v2.Index - 1].Value)
                return true;
            else return false;
        }

        public List<Vertex<T>> GetAdjacentVerticesTo(Vertex<T> v)
        {
            List<Vertex<T>> lstResult = new List<Vertex<T>>();
            List<Edge<T>> lstEdges = edges[v.Index - 1];
            for (int i = 0; i < lstEdges.Count(); i++)
            {
                Edge<T> e = lstEdges[i];
                if (e.Value)
                    lstResult.Add(Vertices.Where(vert => vert.Index == i + 1).First());
            }
            return lstResult;
        }

        public string PrintNeighborhoodMatrix()
        {
            StringBuilder sb = new StringBuilder();

            foreach(List<Edge<T>> el in edges)
            {
                foreach(Edge<T> e in el)
                {
                    string s = e.Value ? "1" : "0";
                    sb.Append(s + " ");
                }
                sb.AppendLine();
            }

            return sb.ToString();
        }

        public Graph<T> Clone()
        {
            if (!typeof(T).IsSerializable)
            {
                throw new ArgumentException("The type must be serializable.", "source");
            }

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new MemoryStream();
            using (stream)
            {
                formatter.Serialize(stream, this);
                stream.Seek(0, SeekOrigin.Begin);
                return (Graph<T>)formatter.Deserialize(stream);
            }
        }
    }

    [Serializable]
    public class Edge<T>
    {
        public bool Value;
        public decimal Length;
        public decimal PipeLoss;
        public decimal C;
        public decimal Diameter;
        public decimal Qstart;
        public decimal Qend;
        public bool IsLocked;
        public bool DrawReversed;
        public int Sign = 1;
        public Vertex<T> Beginning;
        public Vertex<T> End;
    }
}

//thanks to http://stackoverflow.com/users/1911064/axel-kemper
//from http://stackoverflow.com/a/14115627
namespace akCyclesInUndirectedGraphs
{
    class CyclesHelper
    {
        //  Graph modelled as list of edges
        static int[][] graph;

        static List<int[]> cycles = new List<int[]>();

        public static void SetGraph(int[][] graph)
        {
            CyclesHelper.graph = graph;
        }

        public static List<string> demo()
        {
            List<string> ret = new List<string>();
            for (int i = 0; i < graph.GetLength(0); i++)
                for (int j = 0; j < 2/*graph.GetLength(1)*/; j++)
                {
                    findNewCycles(new int[] { graph[i][j] });
                }

            foreach (int[] cy in cycles)
            {
                string s = "" + cy[0];

                for (int i = 1; i < cy.Length; i++)
                    s += "," + cy[i];

                ret.Add(s);
            }

            return ret;
        }

        static void findNewCycles(int[] path)
        {
            int n = path[0];
            int x;
            int[] sub = new int[path.Length + 1];

            for (int i = 0; i < graph.GetLength(0); i++)
                for (int y = 0; y <= 1; y++)
                    if (graph[i][y] == n)
                    //  edge referes to our current node
                    {
                        x = graph[i][(y + 1) % 2];
                        if (!visited(x, path))
                        //  neighbor node not on path yet
                        {
                            sub[0] = x;
                            Array.Copy(path, 0, sub, 1, path.Length);
                            //  explore extended path
                            findNewCycles(sub);
                        }
                        else if ((path.Length > 2) && (x == path[path.Length - 1]))
                        //  cycle found
                        {
                            int[] p = normalize(path);
                            int[] inv = invert(p);
                            if (isNew(p) && isNew(inv))
                                cycles.Add(p);
                        }
                    }
        }

        static bool equals(int[] a, int[] b)
        {
            bool ret = (a[0] == b[0]) && (a.Length == b.Length);

            for (int i = 1; ret && (i < a.Length); i++)
                if (a[i] != b[i])
                {
                    ret = false;
                }

            return ret;
        }

        static int[] invert(int[] path)
        {
            int[] p = new int[path.Length];

            for (int i = 0; i < path.Length; i++)
                p[i] = path[path.Length - 1 - i];

            return normalize(p);
        }

        //  rotate cycle path such that it begins with the smallest node
        static int[] normalize(int[] path)
        {
            int[] p = new int[path.Length];
            int x = smallest(path);
            int n;

            Array.Copy(path, 0, p, 0, path.Length);

            while (p[0] != x)
            {
                n = p[0];
                Array.Copy(p, 1, p, 0, p.Length - 1);
                p[p.Length - 1] = n;
            }

            return p;
        }

        static bool isNew(int[] path)
        {
            bool ret = true;

            foreach (int[] p in cycles)
                if (equals(p, path))
                {
                    ret = false;
                    break;
                }

            return ret;
        }

        static int smallest(int[] path)
        {
            int min = path[0];

            foreach (int p in path)
                if (p < min)
                    min = p;

            return min;
        }

        static bool visited(int n, int[] path)
        {
            bool ret = false;

            foreach (int p in path)
                if (p == n)
                {
                    ret = true;
                    break;
                }

            return ret;
        }
    }
}