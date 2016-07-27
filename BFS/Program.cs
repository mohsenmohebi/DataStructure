using System;
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

            Console.WriteLine("for PatternFinder 1 , Graph 2 , ATMFinder 3 , QuickSort 4 , PrintArray 5 , PrintNoOverlapping 6, transpose matrix 7");
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
                var res = finder.FindNearestBruteForce(location);
                Console.WriteLine($"For Location({location.x} , {location.y}) amount ATM {res.x},{res.y} is the closest one amount {finder.GetNodeCount}");
            }
            if (input == "4")
            {
                var sort = new QuickSort<int>(9);
                sort.Add(0, 7);
                sort.Add(1, 2);
                sort.Add(2, 3);
                sort.Add(3, 6);
                sort.Add(4, 5);
                sort.Add(5, 9);
                sort.Add(6, 8);
                sort.Add(7, 9);
                sort.Add(8, 7);
                var sorted = sort.Sort();
                Console.WriteLine();
                sorted.ToList().ForEach(x => Console.Write(x + " "));

            }
            if (input == "5")
                TwoDimentionalArryReader.RunTest(5);
            if (input == "6")
                PrintNonOverLapping.RunTest(4);
            if (input == "7")
                TransposeMatrix.RunTest();
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
            if (!_init)
            {
                xSorted = Nodes.OrderBy(x => x.x).ToArray();
                ySorted = Nodes.OrderBy(x => x.y).ToArray();
                _init = true;
            }
        }
        public class Node { public int x; public int y; }
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
        public Node FindNearest(Node location, int radius)
        {
            var count = GetNodeCount;
            var pivot = count / 2;
            bool found = false;
            while (!found)
            {
                break;
            }
            return new Node { };

        }
    }

    public class TransposeMatrix
    {
        public static void RunTest()
        {
            var matrix = new int[4, 4];
            var obj = new TransposeMatrix();
            obj.printAsign(matrix , true);
            obj.transpose(matrix);
            obj.printAsign(matrix, false);

        }
        private void transpose(int[,] matrix)
        {
            int n = (int) Math.Sqrt(matrix.Length) - 1;
            for (int counter = 0; counter < n; counter++)
            {
                int tmp1, tmp2;
                tmp1 = matrix[counter, n];
                matrix[counter, n] = matrix[0, counter];
                tmp2 = matrix[n, n - counter];
                matrix[n, n - counter] = tmp1;
                tmp1 = matrix[n-counter, 0];
                matrix[n-counter, 0] = tmp2;
                matrix[0, counter] = tmp1;
                printAsign(matrix, false);
            }
        }
        private void printAsign(int[,] matrix, bool asign)
        {
            var n = Math.Sqrt(matrix.Length);
            var counter = 0;
            Console.WriteLine("[");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (asign)
                        matrix[i, j] = ++counter;
                    Console.Write(matrix[i, j] +   (matrix.Length.ToString().Length > 1 && matrix[i, j].ToString().Length == 1 ?   "  " : " "));

                }
                Console.WriteLine();
            }
            Console.WriteLine("]");
        }
    }

    public class PrintNonOverLapping
    {
        public PrintNonOverLapping(int n)
        {
            this.N = n;
            this.A = new int[n];
            for (int i = 0; i < n; i++)
            {
                A[i] = i + 1;
            }

        }
        public void Print()
        {
            Print(0, N);

        }

        private void Print(int start, int n)
        {
            for (int i = start; i < start + n; i++)
            {
                var s = i + 1;
                PrintPartition(0, start);
                PrintPartition(start, s);
                PrintPartition(s, N - s);
                Console.WriteLine();
            }
            Print(start + 1, N - start - 1);
        }

        public static void RunTest(int n)
        {
            var obj = new PrintNonOverLapping(n);
            obj.Print();
        }

        public void PrintPartition(int start, int count)
        {
            if (count == 0) return;
            Console.Write("(");
            for (int i = start; i < start + count; i++)
            {
                Console.Write(A[i] + " ");
            }
            Console.Write(")");
        }



        public int[] A { get; private set; }
        public int N { get; private set; }
    }

    public class TwoDimentionalArryReader
    {
        public TwoDimentionalArryReader(int n)
        {
            this.N = n;
            this.A = new int[n, n];
        }
        public void Add(int i, int j, int val)
        {
            A[i, j] = val;
        }

        public int[] getArray()
        {
            var arr = new int[N * N];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (i % 2 == 0)
                        arr[j + i * N] = A[i, j];
                    else
                        arr[(i + 1) * N - j - 1] = A[i, j];
                }
            }
            return arr;
        }
        public void printArray()
        {

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write(A[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        public static void RunTest(int n)
        {
            var obj = new TwoDimentionalArryReader(n);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    obj.Add(i, j, i * n + j + 1);
                }
            }
            obj.printArray();

            var arr = obj.getArray();
            Console.WriteLine();
            arr.ToList().ForEach(x => Console.Write(x + " "));


        }

        public int[,] A { get; private set; }
        public int N { get; private set; }
    }

    public class QuickSort<T> where T : IComparable
    {
        T[] list;
        public QuickSort(int size)
        {
            list = new T[size];
        }
        public void Add(int index, T t)
        {
            list[index] = t;
        }
        public T[] Sort()
        {
            if (list.Length <= 1)
                return list;
            Sort(list, 0, list.Length - 1);
            return list;
        }

        private void Sort(T[] list, int low, int high)
        {
            if (high - low <= 0) //fewer than 2 items 
            {
                return;
            }
            int splitPoint = split(list, low, high);
            Sort(list, low, splitPoint - 1);
            Sort(list, splitPoint + 1, high);

        }

        private int split(T[] list, int low, int high)
        {
            int left = low + 1;
            int right = high;
            T pivot = list[low];

            while (true)
            {
                while (left <= right)
                {
                    if (list[left].CompareTo(pivot) < 0)
                    {
                        left++;
                    }
                    else
                    {
                        break;
                    }
                }
                while (right >= left)
                {
                    if (list[right].CompareTo(pivot) < 0)
                    {
                        break;
                    }
                    else
                    {
                        right--;
                    }
                }
                if (left >= right)
                {
                    break;
                }
                T temp = list[left];
                list[left] = list[right];
                list[right] = temp;
                left++;
                right--;
            }

            list[low] = list[left - 1];
            list[left - 1] = pivot;
            return left - 1;
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
