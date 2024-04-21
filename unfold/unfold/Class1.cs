using System.IO;
using System.Collections.Generic;
using System;
using System.Xml;
using System.Linq;
using System.Text.RegularExpressions;
using System.Globalization;

namespace Class
{
    class grapg
    {
        private int vertices;
        private List<int>[] adj;
        public grapg(int v)
        {
            vertices = v;
            adj = new List<int>[v];
            for (int i = 0; i < v; i++)
            {
                adj[i] = new List<int>();
            }
        }

        public void addedge(int c, int v)
        {
            adj[c].Add(v);
        }

        public int[] DFS(int v)//返回int
        {
            bool[] visited = new bool[vertices];
            Stack<int> stack = new Stack<int>();
            visited[v] = true;
            stack.Push(v);
            int[] tree = new int[999];
            int index = 0;
            while (stack.Count != 0)
            {
                v = stack.Pop();
                foreach (int i in adj[v])
                {
                    if (!visited[i])
                    {
                        visited[i] = true;
                        stack.Push(i);
                    }
                }
                tree[index] = v;
                index++;
            }
            return tree;
        }

        public int[] BFS(int v)//返回int
        {
            bool[] visited = new bool[vertices];
            Queue<int> queue = new Queue<int>();
            visited[v] = true;
            queue.Enqueue(v);
            int[] tree = new int[999];
            int index = 0;
            while (queue.Count != 0)
            {
                v = queue.Dequeue();
                foreach (int i in adj[v])
                {
                    if (!visited[i])
                    {
                        visited[i] = true;
                        queue.Enqueue(i);
                    }
                }
                tree[index] = v;
                index++;
            }
            return tree;
        }
    }

    class Program
    {
        public class Coordinate
        {
            public Double X { get; set; }
            public Double Y { get; set; }
            public Double Z { get; set; }
            //public Double Slide { get; set; }
        }

        public class Aj_dot
        {
            public int Surface_fir { get; set; }
            public int Surface_sec { get; set; }
            public int Dot { get; set; }
        }

        public class Surface_2D
        {
            public Double X { get; set; }
            public Double Y { get; set; }
        }

        public class Surface_3Dto2D
        {
            public Double X { get; set; }
            public Double Y { get; set; }
        }

        public static void Main()
        {
            Console.WriteLine("請輸入總共有幾個子物體？");
            int a = Convert.ToInt32(Console.ReadLine());//幾個子物體
            var O_list = new List<int>();
            var f_list = new List<int>();
            List<Coordinate> Coordinate_C = new List<Coordinate>();
            var P_Count = new List<int>();
            for (int i = 0; i < a; i++)
            {
                Console.WriteLine("請輸入子物體" + (i + 1) + "總共有幾個面？");
                int b = Convert.ToInt32(Console.ReadLine());
                O_list.Add(b);
                int index = 0;
                Console.WriteLine("請輸入子物體" + (i + 1) + "包含哪些面？(用空格分開)");
                string faces = Console.ReadLine();
                string[] faces2 = faces.Split(' ');
                for (int j = 0; j < b; j++)
                {
                    int face = int.Parse(faces2[j]);
                    f_list.Add(face);
                }
                for (int m = 0; m < O_list[i]; m++)
                {
                    if (i == 0)
                    {
                        Console.WriteLine("請輸入子物體" + (i + 1) + "，編號" + f_list[m] + "的面有幾個點？");
                        int c = Convert.ToInt32(Console.ReadLine());
                        P_Count.Add(c);

                        for (int k = 0; k < c; k++)
                        {
                            Console.WriteLine("輸入點" + (k + 1) + "的X Y Z？(用空格分開)");
                            String xyz = Console.ReadLine();
                            string[] xyz2 = xyz.Split(' ');
                            Double x = Double.Parse(xyz2[0]);
                            Double y = Double.Parse(xyz2[1]);
                            Double z = Double.Parse(xyz2[2]);

                            //Double x = Double.Parse(Console.ReadLine());
                            //Double y = Double.Parse(Console.ReadLine());
                            //Double z = Double.Parse(Console.ReadLine());
                            Coordinate_C.Add(new Coordinate() { X = x, Y = y, Z = z });
                        }
                        /*
                        for (int l = 0; l < c; l++)
                        {
                            if (l == c - 1)
                            {
                                Console.WriteLine("輸入點" + (l + 1) + "跟1之間的長度？");
                                String longth = Console.ReadLine();
                                Double slide = Convert.ToDouble(longth);
                                Coordinate_C.Add(new Coordinate() { Slide = slide });
                            }
                            else
                            {
                                Console.WriteLine("輸入點" + (l + 1) + "跟" + (l + 2) + "之間的長度？");
                                String longth = Console.ReadLine();
                                Double slide = Convert.ToDouble(longth);
                                Coordinate_C.Add(new Coordinate() { Slide = slide });
                            }
                        }*/
                    }
                    else
                    {
                        index = O_list[i];
                        Console.WriteLine("請輸入子物體" + (i + 1) + "，編號" + f_list[index + m - 1] + "的面有幾個點？");
                        int c = Convert.ToInt32(Console.ReadLine());
                        P_Count.Add(c);

                        for (int k = 0; k < c; k++)
                        {
                            Console.WriteLine("輸入點" + (k + 1) + "的XYZ？(用空格分開)");
                            String xyz = Console.ReadLine();
                            string[] xyz2 = xyz.Split(' ');
                            Double x = Double.Parse(xyz2[0]);
                            Double y = Double.Parse(xyz2[1]);
                            Double z = Double.Parse(xyz2[2]);

                            //Double x = Double.Parse(Console.ReadLine());
                            //Double y = Double.Parse(Console.ReadLine());
                            //Double z = Double.Parse(Console.ReadLine());
                            Coordinate_C.Add(new Coordinate() { X = x, Y = y, Z = z });
                        }
                        /*
                        for (int l = 0; l < c; l++)
                        {
                            if (l == c - 1)
                            {
                                Console.WriteLine("輸入點" + (l + 1) + "跟1之間的長度？");
                                String longth = Console.ReadLine();
                                Double slide = Convert.ToDouble(longth);
                                Coordinate_C.Add(new Coordinate() { Slide = slide });
                            }
                            else
                            {
                                Console.WriteLine("輸入點" + (l + 1) + "跟" + (l + 2) + "之間的長度？");
                                String longth = Console.ReadLine();
                                Double slide = Convert.ToDouble(longth);
                                Coordinate_C.Add(new Coordinate() { Slide = slide });
                            }
                        }*/
                    }
                }
            }
            Console.WriteLine("共{0}個子物體", a);
            int w = 0;
            for (int i = 0; i < a; i++)
            {
                Console.WriteLine("第{0}個子物體", i + 1);
                if (i == 0)
                {
                    for (int k = 0; k < O_list[i]; k++)
                    {
                        Console.WriteLine("第{0}個面", f_list[k]);
                        for (int j = 0; j < P_Count[k]; j++)
                        {
                            Console.WriteLine("{0}\tX={1},Y={2},Z={3}", j + 1, Coordinate_C[w].X, Coordinate_C[w].Y, Coordinate_C[w].Z);
                            w++;
                        }
                    }
                }
                else
                {
                    int O_count = 0;
                    for (int o = 0; o < i; o++)
                    {
                        O_count += O_list[o];
                    }
                    for (int k = O_count; k < O_list[i] + O_count; k++)
                    {
                        Console.WriteLine("第{0}個面", f_list[k-1]);
                        for (int j = 0; j < P_Count[k - 1]; j++)
                        {
                            Console.WriteLine("{0}\tX={1},Y={2},Z={3}", j + 1, Coordinate_C[w].X, Coordinate_C[w].Y, Coordinate_C[w].Z);
                            w++;
                        }
                    }
                }
            }
            foreach (int i in O_list)
            {
                Console.WriteLine(i);
            }
            foreach (int n in f_list)
            {
                Console.Write(n);
            }
            int samePoint = 0;
            var same_dot = new List<int>();
            for (int i = 0; i < a; i++)
            {
                int place = 0;
                int place_2 = 0;
                if (i == 0)
                {
                    for (int k = 0; k < O_list[i]; k++)
                    {
                        for (int l = 0; l < O_list[i]; l++)
                        {
                            if (k == l)
                            {
                                same_dot.Add(samePoint);
                                continue;
                            }
                            else
                            {
                                if (k == 0)
                                {
                                    place = 0;
                                }
                                else
                                {
                                    for (int j = 0; j < k; j++)
                                    {
                                        place += P_Count[j];
                                    }
                                }
                                if (l == 0)
                                {
                                    place_2 = 0;
                                }
                                else
                                {
                                    for (int o = 0; o < l; o++)
                                    {
                                        place_2 += P_Count[o];
                                    }
                                }
                                for (int m = place; m < place + P_Count[k]; m++)
                                {
                                    for (int n = place_2; n < place_2 + P_Count[l]; n++)
                                    {
                                        if (Coordinate_C[m].X == Coordinate_C[n].X)
                                        {
                                            if (Coordinate_C[m].Y == Coordinate_C[n].Y)
                                            {
                                                if (Coordinate_C[m].Z == Coordinate_C[n].Z)
                                                {
                                                    samePoint += 1;
                                                }
                                            }
                                        }
                                    }
                                }
                                same_dot.Add(samePoint);
                                samePoint = 0;
                                place = 0;
                                place_2 = 0;
                            }
                        }
                    }
                }
                else
                {
                    int O_count = 0;
                    for (int o = 0; o < i; o++)
                    {
                        O_count += O_list[o];
                    }
                    for (int k = O_count; k < O_count + O_list[i]; k++)
                    {
                        for (int l = O_count; l < O_count + O_list[i]; l++)
                        {
                            if (k == l)
                            {
                                same_dot.Add(samePoint);
                                continue;
                            }
                            else
                            {
                                for (int j = 0; j < k - 1; j++)
                                {
                                    place += P_Count[j];
                                }
                                for (int o = 0; o < l - 1; o++)
                                {
                                    place_2 += P_Count[o];
                                }
                                
                                for (int m = place; m < place + P_Count[k - 1]; m++)
                                {
                                    for (int n = place_2; n < place_2 + P_Count[l - 1]; n++)
                                    {
                                        if (Coordinate_C[m].X == Coordinate_C[n].X)
                                        {
                                            if (Coordinate_C[m].Y == Coordinate_C[n].Y)
                                            {
                                                if (Coordinate_C[m].Z == Coordinate_C[n].Z)
                                                {
                                                    samePoint += 1;
                                                }
                                            }
                                        }
                                    }
                                }
                                same_dot.Add(samePoint);
                                samePoint = 0;
                                place = 0;
                                place_2 = 0;
                            }
                        }
                    }
                }
            }
            int count = 0;
            int count_2 = 0;
            for (int i = 0; i < a; i++)
            {
                if (i == 0)
                {
                    Console.WriteLine("第{0}個子物體", i + 1);
                    for (int j = 0; j < O_list[i]; j++)
                    {
                        for (int k = 0; k < O_list[i]; k++)
                        {
                            Console.WriteLine("面{0}與面{1}的相鄰點數量\t{2}", j + 1, k + 1, same_dot[count]);
                            count += 1;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("第{0}個子物體", i + 1);
                    int O_count = 0;
                    for (int l = 0; l < i; l++)
                    {
                        O_count += O_list[l];
                        count_2 += Convert.ToInt32(Math.Pow(O_list[l] , 2));
                    }
                    for (int k = O_count; k < O_list[i] + O_count; k++)
                    {
                        for (int j = O_count; j < O_list[i] + O_count; j++)
                        {
                            Console.WriteLine("面{0}與面{1}的相鄰點數量\t{2}", k + 1, j + 1, same_dot[count_2]);
                            count_2 += 1;
                        }
                    }
                }
                count_2 = 0;
            }
            Console.WriteLine(same_dot.Count);
            Console.WriteLine(count);
            var S_surface = new List<int>();
            var S_surface_temp = new List<int>();
            //int temp_surface;
            int surface_index = 0;
            for (int i = 0; i < a; i++)
            {
                if (i == 0)
                {
                    for (int j = 0; j < O_list[i]; j++)
                    {
                        for (int k = 0; k < O_list[i]; k++)//更改面
                        {
                            if (j == k)
                            {
                                surface_index += 1;
                                continue;
                            }
                            else
                            {
                                if (same_dot[surface_index] == 2)
                                {
                                    S_surface.Add(k);
                                    surface_index += 1;
                                }
                                else if (same_dot[surface_index] < 2)//***
                                {
                                    S_surface_temp.Add(k);
                                    surface_index += 1;
                                }
                            }
                        }
                        if (S_surface_temp.Count > 0)//目前為了要輸出所有的面給BFS/DFS所以只好全部丟再一起
                        {
                            for (int l = 0; l < S_surface_temp.Count; l++)
                            {
                                S_surface.Add(S_surface_temp[l]);
                            }
                            S_surface_temp.Clear();
                        }
                    }
                }
                else
                {
                    int O_count = 0;
                    for (int l = 0; l < i; l++)
                    {
                        O_count += O_list[l];
                    }
                    for (int j = O_count; j < O_list[i] + O_count; j++)
                    {
                        for (int k = O_count; k < O_list[i] + O_count; k++)//更改面
                        {
                            if (j == k)
                            {
                                surface_index += 1;
                                continue;
                            }
                            else
                            {
                                if (same_dot[surface_index] == 2)
                                {
                                    S_surface.Add(k);
                                    surface_index += 1;
                                }
                                else if (same_dot[surface_index] < 2)//***
                                {
                                    S_surface_temp.Add(k);
                                    surface_index += 1;
                                }
                            }
                        }
                        if (S_surface_temp.Count > 0)
                        {
                            for (int l = 0; l < S_surface_temp.Count; l++)
                            {
                                S_surface.Add(S_surface_temp[l]);
                            }
                            S_surface_temp.Clear();
                        }
                    }
                }
            }
            Console.WriteLine("總共{0}個點", surface_index);
            foreach (int i in S_surface)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("總共{0}個點", S_surface.Count);
            int count_3 = 0;
            for (int i = 0; i < a; i++)
            {
                Console.WriteLine("第{0}個子物體", i + 1);
                if (i == 0)
                {
                    for (int j = 0; j < O_list[i]; j++)
                    {
                        for (int k = 0; k < O_list[i] - 1; k++)
                        {
                            Console.WriteLine("跟{0}相鄰的面有{1}", j + 1, S_surface[count_3] + 1);
                            count_3 += 1;
                        }
                    }
                }
                else
                {
                    int O_count = 0;
                    for (int l = 0; l < i; l++)
                    {
                        O_count += O_list[l];
                    }
                    for (int j = O_count; j < O_list[i] + O_count; j++)
                    {
                        for (int k = O_count; k < O_list[i] + O_count - 1; k++)
                        {
                            Console.WriteLine("跟{0}相鄰的面有{1}", j + 1, S_surface[count_3] + 1);
                            count_3 += 1;
                        }
                    }
                }
            }
            int count_4 = 0;
            var BFS_surface = new List<int>();
            var DFS_surface = new List<int>();
            for (int i = 0; i < a; i++)
            {
                grapg g = new grapg(999);//陣列裡的空間
                int[] tree = new int[O_list[i]];//BFS
                int[] tree_2 = new int[O_list[i]];//DFS
                if (i == 0)
                {
                    for (int j = 0; j < O_list[i]; j++)
                    {
                        for (int k = 0; k < O_list[i] - 1; k++)
                        {
                            g.addedge(f_list[j] - 1, S_surface[count_4]);
                            count_4 += 1;
                        }
                    }
                    for (int j = 0; j < O_list[i]; j++)
                    {
                        int radius = f_list[j] - 1;
                        tree = g.BFS(radius);
                        for (int k = 0; k < O_list[i]; k++)
                        {
                            BFS_surface.Add(tree[k]);
                        }
                        tree_2 = g.DFS(radius);
                        for (int l = 0; l < O_list[i]; l++)
                        {
                            DFS_surface.Add(tree_2[l]);
                        }
                    }
                }
                else
                {
                    int O_count = 0;
                    for (int l = 0; l < i; l++)
                    {
                        O_count += O_list[l];
                    }
                    for (int j = O_count; j < O_list[i] + O_count; j++)
                    {
                        for (int k = O_count; k < O_list[i] + O_count - 1; k++)
                        {
                            g.addedge(f_list[j] - 1, S_surface[count_4]);
                            count_4 += 1;
                        }
                    }
                    for (int j = O_count; j < O_list[i] + O_count; j++)
                    {
                        int radius = f_list[j] - 1;
                        tree = g.BFS(radius);
                        for (int k = 0; k < O_list[i]; k++)
                        {
                            BFS_surface.Add(tree[k]);
                        }
                        tree_2 = g.DFS(radius);
                        for (int l = 0; l < O_list[i]; l++)
                        {
                            DFS_surface.Add(tree_2[l]);
                        }
                    }
                }
            }
            Console.WriteLine("與各個面相鄰的點總共有{0}個點", count_4);
            int count_5 = 0;
            for (int i = 0; i < a; i++)
            {
                Console.WriteLine("B F S");
                Console.WriteLine("第{0}個子物體", i + 1);
                Console.WriteLine("\n");
                if (i == 0)
                {
                    for (int j = 0; j < O_list[i]; j++)
                    {
                        Console.WriteLine("第{0}種\t", j + 1);
                        for (int k = 0; k < O_list[i]; k++)
                        {
                            Console.Write(BFS_surface[count_5] + 1);
                            count_5 += 1;
                        }
                        Console.WriteLine("\n");
                    }
                }
                else
                {
                    int O_count = 0;
                    for (int l = 0; l < i; l++)
                    {
                        O_count += O_list[l];
                    }
                    for (int j = O_count; j < O_list[i] + O_count; j++)
                    {
                        Console.WriteLine("第{0}種\t", j + 1);
                        for (int k = O_count; k < O_list[i] + O_count; k++)
                        {
                            Console.Write(BFS_surface[count_5] + 1);
                            count_5 += 1;
                        }
                        Console.WriteLine("\n");
                    }
                }
            }
            int count_6 = 0;
            for (int i = 0; i < a; i++)
            {
                Console.WriteLine("D F S");
                Console.WriteLine("第{0}個子物體", i + 1);
                Console.WriteLine("\n");
                if (i == 0)
                {
                    for (int j = 0; j < O_list[i]; j++)
                    {
                        Console.WriteLine("第{0}種\t", j + 1);
                        for (int k = 0; k < O_list[i]; k++)
                        {
                            Console.Write(DFS_surface[count_6] + 1);
                            count_6 += 1;
                        }
                        Console.WriteLine("\n");
                    }
                }
                else
                {
                    int O_count = 0;
                    for (int l = 0; l < i; l++)
                    {
                        O_count += O_list[l];
                    }
                    for (int j = O_count; j < O_list[i] + O_count; j++)
                    {
                        Console.WriteLine("第{0}種\t", j + 1);
                        for (int k = O_count; k < O_list[i] + O_count; k++)
                        {
                            Console.Write(DFS_surface[count_6] + 1);
                            count_6 += 1;
                        }
                        Console.WriteLine("\n");
                    }
                }
            }

            List<Aj_dot> Aj_dots = new List<Aj_dot>();
            int count_7 = 0;
            int count_8 = 1;//1~4
            for (int i = 0; i < a; i++)
            {
                int place_3 = 0;
                int place_4 = 0;
                if (i == 0)
                {
                    for (int j = 0; j < O_list[i]; j++)
                    {
                        for (int k = 0; k < O_list[i]; k++)//更改面
                        {
                            if (j == k)
                            {
                                count_7 += 1;
                                continue;
                            }
                            else
                            {
                                if (same_dot[count_7] == 2)
                                {
                                    if (j == 0)//判斷j面
                                    {
                                        place_3 = 0;
                                    }
                                    else
                                    {
                                        for (int l = 0; l < j; l++)
                                        {
                                            place_3 += P_Count[l];
                                        }
                                    }
                                    if (k == 0)//判斷k面
                                    {
                                        place_4 = 0;
                                    }
                                    else
                                    {
                                        for (int m = 0; m < k; m++)
                                        {
                                            place_4 += P_Count[m];
                                        }
                                    }
                                    for (int n = place_3; n < place_3 + P_Count[j]; n++)
                                    {
                                        for (int o = place_4; o < place_4 + P_Count[k]; o++)
                                        {
                                            if (Coordinate_C[n].X == Coordinate_C[o].X)
                                            {
                                                if (Coordinate_C[n].Y == Coordinate_C[o].Y)
                                                {
                                                    if (Coordinate_C[n].Z == Coordinate_C[o].Z)
                                                    {
                                                        Aj_dots.Add(new Aj_dot() { Surface_fir = j, Surface_sec = k, Dot = count_8 });
                                                    }
                                                }
                                            }
                                        }
                                        count_8 += 1;
                                    }
                                    place_3 = 0;
                                    place_4 = 0;
                                    count_8 = 1;
                                    count_7 += 1;
                                }
                                else if (same_dot[count_7] < 2)//***
                                {
                                    count_7 += 1;
                                    continue;
                                }
                            }
                        }
                    }
                }
                else
                {
                    int O_count = 0;
                    for (int l = 0; l < i; l++)
                    {
                        O_count += O_list[l];
                    }
                    for (int j = O_count; j < O_list[i] + O_count; j++)
                    {
                        for (int k = O_count; k < O_list[i] + O_count; k++)//更改面
                        {
                            if (j == k)
                            {
                                count_7 += 1;
                                continue;
                            }
                            else
                            {
                                if (same_dot[count_7] == 2)
                                {
                                    for (int l = 0; l < j; l++)
                                    {
                                        place_3 += P_Count[l];
                                    }
                                    for (int m = 0; m < k; m++)
                                    {
                                        place_4 += P_Count[m];
                                    }

                                    for (int n = place_3; n < place_3 + P_Count[j]; n++)
                                    {
                                        for (int o = place_4; o < place_4 + P_Count[k]; o++)
                                        {
                                            if (Coordinate_C[n].X == Coordinate_C[o].X)
                                            {
                                                if (Coordinate_C[n].Y == Coordinate_C[o].Y)
                                                {
                                                    if (Coordinate_C[n].Z == Coordinate_C[o].Z)
                                                    {
                                                        Aj_dots.Add(new Aj_dot() { Surface_fir = j, Surface_sec = k, Dot = count_8 });
                                                    }
                                                }
                                            }
                                        }
                                        count_8 += 1;
                                    }
                                    place_3 = 0;
                                    place_4 = 0;
                                    count_8 = 1;
                                    count_7 += 1;
                                }
                                else if (same_dot[count_7] < 2)//***
                                {
                                    count_7 += 1;
                                    continue;
                                }
                            }
                        }
                    }
                }
            }
            Console.WriteLine("轉換2D前所需的參數，判斷上下左右");
            int q = 0;
            Console.WriteLine("所有面相鄰的狀況");
            for (int j = 0; j < Aj_dots.Count; j++)
            {
                Console.WriteLine("Surface_fir={0},Surface_sec={1},相同的點位置={2}\r\n", Aj_dots[q].Surface_fir + 1, Aj_dots[q].Surface_sec + 1, Aj_dots[q].Dot);
                q++;
            }

            List<Surface_3Dto2D> Surface_3Dto2Ds = new List<Surface_3Dto2D>();
            int p = 0;
            Double Sub_dis = 0.0;
            int All_count = 0;
            for (int i = 0; i < O_list.Count; i++)
            {
                All_count += O_list[i];
            }
            for (int k = 0; k < All_count; k++)
            {
                if(P_Count[k] == 3)//3個點
                {
                    for(int l = 0;l < P_Count[k]; l++)
                    {
                        if(l == 0)
                        {
                            Surface_3Dto2Ds.Add(new Surface_3Dto2D() { X = Coordinate_C[p].X, Y = Coordinate_C[p].Y });
                        }
                        else
                        {
                            if(l % 3 == 1)
                            {
                                Sub_dis = Math.Pow(Math.Pow(Coordinate_C[p].X - Coordinate_C[p - 1].X,2) + Math.Pow(Coordinate_C[p].Y - Coordinate_C[p - 1].Y,2) +  Math.Pow(Coordinate_C[p].Z - Coordinate_C[p - 1].Z,2),0.5);
                                Surface_3Dto2Ds.Add(new Surface_3Dto2D() { X = Coordinate_C[p].X + Sub_dis, Y = Coordinate_C[p].Y });
                            }
                            else if(l % 3 ==2)
                            {
                                Sub_dis = Math.Pow(Math.Pow(Coordinate_C[p].X - Coordinate_C[p - 2].X, 2) + Math.Pow(Coordinate_C[p].Y - Coordinate_C[p - 2].Y, 2) + Math.Pow(Coordinate_C[p].Z - Coordinate_C[p - 2].Z, 2), 0.5);
                                Surface_3Dto2Ds.Add(new Surface_3Dto2D() { X = Coordinate_C[p].X , Y = Coordinate_C[p].Y + Sub_dis });
                            }
                        }
                        p += 1;
                    }
                }
                else if(P_Count[k] == 4)//4個點
                {
                    for (int l = 0; l < P_Count[k]; l++)
                    {
                        if (l == 0)
                        {    
                            Surface_3Dto2Ds.Add(new Surface_3Dto2D() { X = Coordinate_C[p].X, Y = Coordinate_C[p].Y });
                        }
                        else
                        {
                            if (l % 4 == 1)
                            {
                                Sub_dis = Math.Pow(Math.Pow(Coordinate_C[p].X - Coordinate_C[p - 1].X, 2) + Math.Pow(Coordinate_C[p].Y - Coordinate_C[p - 1].Y, 2) + Math.Pow(Coordinate_C[p].Z - Coordinate_C[p - 1].Z, 2), 0.5);
                                Surface_3Dto2Ds.Add(new Surface_3Dto2D() { X = Coordinate_C[p].X + Sub_dis, Y = Coordinate_C[p].Y });
                            }
                            else if (l % 4 == 2)
                            {
                                Sub_dis = Math.Pow(Math.Pow(Coordinate_C[p].X - Coordinate_C[p - 2].X, 2) + Math.Pow(Coordinate_C[p].Y - Coordinate_C[p - 2].Y, 2) + Math.Pow(Coordinate_C[p].Z - Coordinate_C[p - 2].Z, 2), 0.5);
                                Surface_3Dto2Ds.Add(new Surface_3Dto2D() { X = Coordinate_C[p].X + Sub_dis, Y = Coordinate_C[p].Y + Sub_dis });
                            }
                            else if (l % 4 == 3)
                            {
                                Sub_dis = Math.Pow(Math.Pow(Coordinate_C[p].X - Coordinate_C[p - 3].X, 2) + Math.Pow(Coordinate_C[p].Y - Coordinate_C[p - 3].Y, 2) + Math.Pow(Coordinate_C[p].Z - Coordinate_C[p - 3].Z, 2), 0.5);
                                Surface_3Dto2Ds.Add(new Surface_3Dto2D() { X = Coordinate_C[p].X, Y = Coordinate_C[p].Y + Sub_dis });
                            }
                        }
                        p += 1;
                    }
                }         
            }
            int index_2 = 0;
            for (int i = 0; i < a; i++)
            {
                Console.WriteLine("第{0}個子物體", i + 1);
                if (i == 0)
                {
                    for (int k = 0; k < O_list[i]; k++)
                    {
                        Console.WriteLine("(2D)第{0}個面", f_list[k]);
                        for (int j = 0; j < P_Count[k]; j++)
                        {
                            Console.WriteLine("{0}\tX={1},Y={2}", j + 1, Surface_3Dto2Ds[index_2].X, Surface_3Dto2Ds[index_2].Y);
                            index_2++;
                        }
                    }
                }
                else
                {
                    int O_count = 0;
                    for (int o = 0; o < i; o++)
                    {
                        O_count += O_list[o];
                    }
                    for (int k = O_count; k < O_list[i] + O_count; k++)
                    {
                        Console.WriteLine("(2D)第{0}個面", f_list[k]);
                        for (int j = 0; j < P_Count[k]; j++)
                        {
                            Console.WriteLine("{0}\tX={1},Y={2}", j + 1, Surface_3Dto2Ds[index_2].X, Surface_3Dto2Ds[index_2].Y);
                            index_2++;
                        }
                    }
                }
            }

            int place_5 = 0;
            int place_6 = 0;
            int index_3 = 0;//紀錄BFS
            int index_4 = 0;//紀錄DFS
            var temp_surface_2 = new List<int>();
            var result = new List<int>();
            List<Surface_2D> Surface_2Ds = new List<Surface_2D>();
            /*
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < 1; j++)//更改
                {
                    temp_surface_2.Clear();
                    for (int k = 0; k < O_list[i]; k++)
                    {
                        temp_surface_2.Add(DFS_surface[index_3] + 1);
                        index_3 += 1;
                    }
                    for(int l = 0; l < O_list[i]; l++)
                    {
                        if (l == 0)
                        {
                            for (int m = 0; m < temp_surface_2[l]; m++)
                            {
                                place_5 += P_Count[m];
                            }
                            for(int n = 0; n < place_5; n++)
                            {
                                Surface_2Ds.Add(new Surface_2D() { X = Surface_3Dto2Ds[n].X, Y = Surface_3Dto2Ds[n].Y });
                            }
                        }
                        else
                        {
                            for (int m = 0; m < temp_surface_2[l] - 1; m++)
                            {
                                place_6 += P_Count[m];
                            }
                            result.Clear();
                            result = Enumerable.Range(0, Aj_dots.Count)
                                    .Where(i => Aj_dots[i].Surface_fir == (temp_surface_2[l - 1] - 1) && Aj_dots[i].Surface_sec == (temp_surface_2[l] - 1))
                                    .ToList();
                            if(P_Count[l] == 3)
                            {
                                
                                if (Aj_dots[result[0]].Dot == 1)
                                {
                                    if(Aj_dots[result[1]].Dot == 2)
                                    {
                                        int place_7 = place_6;
                                        int place_8 = place_6;
                                        Double max = Surface_3Dto2Ds[place_6].Y;
                                        Double min = Surface_3Dto2Ds[place_6].Y;
                                        for (int n = place_6; n < place_6 + P_Count[l]; n++)//忽略負的
                                        {
                                            if (max < Surface_3Dto2Ds[n].Y)
                                            {
                                                max = Surface_3Dto2Ds[n].Y;
                                                place_7 = n;
                                            }
                                        }
                                        for (int n = place_6; n < place_6 + P_Count[l]; n++)//忽略負的
                                        {
                                            if (min > Surface_3Dto2Ds[n].Y)
                                            {
                                                min = Surface_3Dto2Ds[n].Y;
                                                place_8 = n;
                                            }
                                        }
                                        for (int o = place_6; o < place_6 + P_Count[l]; o++)
                                        {
                                            if (o == place_7)
                                            {
                                                Surface_2Ds.Add(new Surface_2D() { X = Surface_2Ds[place_7 - place_6].X + Math.Abs(Surface_3Dto2Ds[place_7].X - Surface_3Dto2Ds[place_7 - 1].X), Y = Surface_2Ds[place_7 - place_6].Y - Math.Abs(Surface_3Dto2Ds[place_7].Y - Surface_3Dto2Ds[place_7 - 1].Y) });
                                            }
                                        }
                                        for (int s = place_6; s < place_6 + P_Count[l]; s++)
                                        {
                                            if (s == place_8)
                                            {
                                                continue;
                                            }
                                            else
                                            {
                                                Surface_2Ds.Add(new Surface_2D() { X = Surface_2Ds[place_6 - (s % P_Count[l])].X, Y = Surface_2Ds[place_6 - (s % P_Count[l])].Y });
                                            }
                                        }
                                        place_6 = 0;
                                    }
                                    if(Aj_dots[result[1]].Dot == 3)
                                    {
                                        int place_7 = place_6;
                                        int place_8 = place_6;
                                        Double max = Surface_3Dto2Ds[place_6].X;
                                        Double min = Surface_3Dto2Ds[place_6].X;
                                        for (int n = place_6; n < place_6 + P_Count[l]; n++)//忽略負的
                                        {
                                            if (max < Surface_3Dto2Ds[n].X)
                                            {
                                                max = Surface_3Dto2Ds[n].X;
                                                place_7 = n;
                                            }
                                        }
                                        for (int n = place_6; n < place_6 + P_Count[l]; n++)//忽略負的
                                        {
                                            if (min > Surface_3Dto2Ds[n].X)
                                            {
                                                min = Surface_3Dto2Ds[n].X;
                                                place_8 = n;
                                            }
                                        }
                                        for (int o = place_6; o < place_6 + P_Count[l]; o++)
                                        {
                                            if (o == place_7)
                                            {
                                                Surface_2Ds.Add(new Surface_2D() { X = Surface_2Ds[place_7 - place_6].X - Math.Abs(Surface_3Dto2Ds[place_7].X - Surface_3Dto2Ds[place_7 - 1].X), Y = Surface_2Ds[place_7 - place_6].Y + Math.Abs(Surface_3Dto2Ds[place_7].Y - Surface_3Dto2Ds[place_7 - 1].Y) });
                                            }
                                        }
                                        for (int s = place_6; s < place_6 + P_Count[l]; s++)
                                        {
                                            if (s == place_8)
                                            {
                                                continue;
                                            }
                                            else
                                            {
                                                Surface_2Ds.Add(new Surface_2D() { X = Surface_2Ds[place_6 - (s % P_Count[l])].X, Y = Surface_2Ds[place_6 - (s % P_Count[l])].Y });
                                            }
                                        }
                                        place_6 = 0;
                                    }
                                }
                                if(Aj_dots[result[0]].Dot == 2)
                                {
                                    if(Aj_dots[result[1]].Dot == 3)
                                    {
                                        int place_7 = place_6;
                                        int place_8 = place_6;
                                        Double max = Surface_3Dto2Ds[place_6].X;
                                        Double min = Surface_3Dto2Ds[place_6].X; 
                                        for (int n = place_6; n < place_6 + P_Count[l]; n++)//忽略負的
                                        {
                                            if (max < Surface_3Dto2Ds[n].X)
                                            {
                                                max = Surface_3Dto2Ds[n].X;
                                                place_7 = n;
                                            }
                                        }
                                        for (int n = place_6; n < place_6 + P_Count[l]; n++)//忽略負的
                                        {
                                            if (min > Surface_3Dto2Ds[n].X)
                                            {
                                                min = Surface_3Dto2Ds[n].X;
                                                place_8 = n;
                                            }
                                        }
                                        for (int o = place_6; o < place_6 + P_Count[l]; o++)
                                        {
                                            if(o == place_7)
                                            {
                                                Surface_2Ds.Add(new Surface_2D() { X = Surface_2Ds[place_7 - P_Count[l]].X + Math.Abs(Surface_3Dto2Ds[place_7].X - Surface_3Dto2Ds[place_7 - 1].X), Y = Surface_2Ds[place_7 - P_Count[l]].Y + Math.Abs(Surface_3Dto2Ds[place_7].Y - Surface_3Dto2Ds[place_7 - 1].Y) });
                                            }
                                        }
                                        for (int s = place_6; s < place_6 + P_Count[l]; s++)
                                        {
                                            if (s == place_8)
                                            {
                                                continue;
                                            }
                                            else
                                            {
                                                Surface_2Ds.Add(new Surface_2D() { X = Surface_2Ds[place_6 - (s % P_Count[l])].X, Y = Surface_2Ds[place_6 - (s % P_Count[l])].Y });
                                            }
                                        }
                                        place_6 = 0;
                                    }
                                }
                            }
                            
                        }
                        place_5 = 0;
                    }
                }
            }
        
            Console.WriteLine(Surface_2Ds.Count);
            Console.WriteLine(temp_surface_2.Count);
            
            int index_10 = 0;
            Console.WriteLine(place_5);
            Console.WriteLine(place_6);
            for (int s = 0; s < Surface_2Ds.Count; s++)
            {
                Console.WriteLine("X={0},Y={1}", Surface_2Ds[index_10].X, Surface_2Ds[index_10].Y);
                index_10 += 1;
            }*/
            

            

            
        }
    }
}