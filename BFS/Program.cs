﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFS
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("for PatternFinder 1 , Graph 2 , ATMFinder 3");
            var input = Console.ReadLine();
            if (input == "1")
            {
                var v = 6;
                var patt = new PatternFinder(v);
                var str = "BBABBNBBMBBOBBABBZNOZBBABBBBBMBBBBBA";
                for (int i = 0; i < str.Length; i++)
                {
                    patt.AddEdge(i / v, i % v, str[i]);
                }
                Console.WriteLine(patt.Print());
                Console.WriteLine(patt.FindPath("AMAZON"));


            }
            if (input == "2")
            {
                GraphRunner();
            }
            if (input == "3")
            {
                var finder = new ATMFinder();
                var random = new Random();
                var t = random.Next(1, 1000);
                while (t > 0)
                {
                    t--;
                    finder.AddNode(random.Next(1, 10000), random.Next(1, 10000));
                }
                var location = new ATMFinder.Node { x = random.Next(1, 10000), y = random.Next(1, 10000) };
                var res = finder.FindNearest(location);
                Console.WriteLine($"For Location({location.x} , {location.y}) amount ATM {res.x},{res.y} is the closest one amount {finder.GetNodeCount}");
            }
            Console.Read();
        }

        private static void GraphRunner()
        {
            if (1 == 1)
            {
                var file = @"C:\Users\mmohebi\Documents\Visual Studio 2015\Projects\Algorithm\BFS\BFS\InputDSJ.txt";
                var read = File.ReadLines(file).GetEnumerator();
                read.MoveNext();
                var t = Convert.ToInt32(read.Current);
                while (t > 0)
                {
                    t--;
                    read.MoveNext();
                    var str = read.Current;
                    var n = Convert.ToInt32(str.Split(' ')[0]);
                    var m = Convert.ToInt32(str.Split(' ')[1]);
                    var g = new Graph(n);

                    for (int i = 0; i < m; i++)
                    {
                        read.MoveNext();
                        str = read.Current;
                        //for shortest path simple bts
                        //g.AddEdge(Convert.ToInt32(str.Split(' ')[0]), Convert.ToInt32(str.Split(' ')[1]));
                        g.AddEdge(Convert.ToInt32(str.Split(' ')[0]), Convert.ToInt32(str.Split(' ')[1]), Convert.ToInt32(str.Split(' ')[2]));
                    }
                    read.MoveNext();
                    var s = Convert.ToInt32(read.Current);
                    //g.BFS(s).ForEach(x => Console.Write(x.name + " "));
                    //Console.WriteLine();
                    g.Print(s);
                }


            }
            else if (1 == 2)
            {
                var g = new Graph(7);
                g.AddEdge(1, 2);
                g.AddEdge(1, 3);
                g.AddEdge(1, 7);
                g.AddEdge(2, 4);
                g.AddEdge(3, 5);
                g.AddEdge(4, 5);
                g.AddEdge(4, 6);
                var list = g.BFS(1);
                g.Print(1);


            }
            else
            {
                var t = Convert.ToInt32(Console.ReadLine());
                while (t > 0)
                {
                    t--;
                    var str = Console.ReadLine();
                    var n = Convert.ToInt32(str.Split(' ')[0]);
                    var m = Convert.ToInt32(str.Split(' ')[1]);
                    var g = new Graph(n);
                    for (int i = 0; i < m; i++)
                    {
                        str = Console.ReadLine();
                        g.AddEdge(Convert.ToInt32(str.Split(' ')[0]), Convert.ToInt32(str.Split(' ')[1]));
                    }
                    g.Print(Convert.ToInt32(Console.ReadLine()));


                }
            }
        }
    }

    public class ATMFinder
    {
        bool _init = false;
        private void init()
        {
            if(!_init)
            {
                xSorted = Nodes.OrderBy(x => x.x).ToArray();
                ySorted = Nodes.OrderBy(x => x.y).ToArray();
                _init = true;
            }
        }
        public class Node { public int x; public int y;}
        public class Result { public Node node; public double distance; }
        List<Node> Nodes = new List<Node>();
        Node[] xSorted;
        Node[] ySorted;
        public int GetNodeCount { get { return Nodes.Count; } }

        public void AddNode(int x, int y)
        {
            Nodes.Add(new Node { x = x, y = y });
            

        }
        
        

        public Node FindNearestBruteForce(Node Location)
        {
            
            var min = double.MaxValue;
            Node res = null;
            var distance = Nodes.Select(ATM => new Result { node = ATM, distance = Math.Sqrt(Math.Abs(Location.x - ATM.x) ^ 2 + Math.Abs(Location.y - ATM.y) ^ 2) });
            distance.ToList().ForEach(x => { if (x.distance < min) { res = x.node; min = x.distance; } });
            return res;

        }
        public Node FindNearest(Node location , int radius)
        {
            var count = GetNodeCount;
            var pivot = count / 2;
            bool found = false;
            while(!found )
            {
                if()
            }
            
            
        }
    }

    public class Graph
    {
        int V;
        List<Edge> adj;
        public class Edge { public int v; public int w; public int cost; }
        public class Node { public int name; public Node parent; public int distanc; }
        public void AddEdge(int v, int w)
        {
            adj.Add(new Edge { v = v, w = w });
        }
        public void AddEdge(int v, int w, int c)
        {
            adj.Add(new Edge { v = v, w = w, cost = c });
        }
        public Graph(int v)
        {
            V = v + 1;
            adj = new List<Edge>();
        }
        public List<Node> BFS(int s)
        {
            var res = new List<Node>();
            var visited = new bool[V];
            Queue<Node> queue = new Queue<Node>();
            visited[s] = true;
            queue.Enqueue(new Node { name = s, parent = null, distanc = 0 });
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                s = node.name;
                res.Add(node);
                foreach (var item in adj.Where(x => (x.v == s || x.w == s)))
                {
                    var val = item.v == s ? item.w : item.v;
                    if (!visited[val])
                    {
                        visited[val] = true;
                        queue.Enqueue(new Node { name = val, parent = res.Where(x => x.name == s).First() });
                    }
                }
            }
            return res;
        }
        public List<Node> DJK(int s)
        {
            var res = new List<Node>();
            var visited = new bool[V];
            Queue<Node> queue = new Queue<Node>();
            visited[s] = true;
            queue.Enqueue(new Node { name = s, parent = null, distanc = 0 });
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                s = node.name;
                res.Add(node);
                foreach (var item in adj.Where(x => (x.v == s || x.w == s)))
                {
                    var val = item.v == s ? item.w : item.v;
                    if (!visited[val])
                    {


                        visited[val] = true;
                        queue.Enqueue(new Node { name = val, parent = res.Where(x => x.name == s).First() });
                    }
                }
            }
            return res;
        }
        public List<Node> BFSDirected(int s)
        {
            var res = new List<Node>();
            var visited = new bool[V];
            Queue<Node> queue = new Queue<Node>();
            visited[s] = true;
            queue.Enqueue(new Node { name = s, parent = null, distanc = 0 });
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                s = node.name;
                res.Add(node);
                foreach (var item in adj.Where(x => x.v == s))
                {
                    var val = item.w;
                    if (!visited[val])
                    {
                        visited[val] = true;
                        queue.Enqueue(new Node { name = val, parent = res.Where(x => x.name == s).First() });
                    }
                }
            }
            return res;
        }
        public void BFSWeight(int s, List<Node> list)
        {
            list.Where(x => x.parent.name == s).ToList().ForEach(x => x.distanc += 1);
            list.Where(x => x.distanc == 0).ToList().ForEach(x => x.distanc = x.parent.distanc + 1);
        }
        public void Print(int s)
        {
            var list = BFS(s);
            BFSWeight(s, list.Where(x => x.name != s).ToList());

            for (int i = 1; i < V; i++)
            {
                if (i == s)
                    continue;
                var item = list.Where(x => x.name == i).FirstOrDefault();
                if (item == null)
                    Console.Write("-1 ");
                else
                    Console.Write(item.distanc * 6 + " ");

            }
            Console.WriteLine(Environment.NewLine);
        }
    }

    public class PatternFinder
    {
        int V;
        char[,] matrix;
        public class Node { public char value; public int i; public int j; }
        public PatternFinder(int v)
        {
            V = v;
            matrix = new char[v, v];
        }
        public void AddEdge(int i, int j, char value)
        {
            matrix[i, j] = value;
        }
        public List<Node> Adj(int i, int j)
        {
            var list = new List<Node> { };
            if (j + 1 < V)
                list.Add(new Node { value = matrix[i, j + 1], i = i, j = j + 1 });
            if (j - 1 >= 0)
                list.Add(new Node { value = matrix[i, j - 1], i = i, j = j - 1 });
            if (i + 1 < V)
                list.Add(new Node { value = matrix[i + 1, j], i = i + 1, j = j });
            if (i - 1 >= 0)
                list.Add(new Node { value = matrix[i - 1, j], i = i - 1, j = j });
            return list;
        }

        public int FindPath(string pattern)
        {
            bool[,] visited = new bool[V, V];
            int counter = 0;
            int index = 0;
            var stack = new Stack<Node>();
            FindChar(pattern[index++]).ForEach(x => stack.Push(x));
            while (stack.Count != 0)
            {
                var s = stack.Pop();
                visited[s.i, s.j] = true;
                var adj = Adj(s.i, s.j).Where(x => !visited[x.i, x.j] && x.value == pattern[index]).ToList();
                if (adj.Count > 0)
                {
                    adj.ForEach(x => stack.Push(x));

                    if (index + 1 < pattern.Length)
                        index++;
                    else
                    {
                        counter++;
                        visited = new bool[V, V];
                        index = 1;
                    }

                }

            }
            return counter;

        }
        public List<Node> FindChar(char c)
        {
            var list = new List<Node>();
            for (int i = 0; i < V; i++)
            {
                for (int j = 0; j < V; j++)
                {
                    if (matrix[i, j] == c)
                        list.Add(new Node { value = matrix[i, j], i = i, j = j });
                }
            }
            return list;
        }

        public string Print()
        {
            var str = new StringBuilder();
            for (int i = 0; i < V; i++)
            {
                for (int j = 0; j < V; j++)
                {
                    str.Append(matrix[i, j]);
                }
                str.AppendLine();
            }
            return str.ToString();
        }
    }
}