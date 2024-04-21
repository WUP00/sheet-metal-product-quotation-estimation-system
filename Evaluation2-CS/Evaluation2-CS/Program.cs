using System.IO;
using System.Collections.Generic;
using System;

namespace Evaluation2_CS
{
    class Program
    {
        public static void Main()
        {
            string filePath = @"C:\Users\Pei L in Wu\Downloads\成本計算.csv";
            StreamReader reader = new StreamReader(filePath);
            var lines = new List<string[]>();
            int Row = 0;
            int Col = 0;
            while (!reader.EndOfStream)
            {
                string[] Line = reader.ReadLine().Split(',');
                lines.Add(Line);
                Row++;
                //Console.WriteLine(Row);
                Col = Line.Length;
            }
            var data = lines.ToArray();
            //var row = data.GetLength(0);//列
            //var col = data.GetLength(1);//行
            //Console.WriteLine(data);

            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Col; j++)
                {
                    Console.Write($"{data[i][j]}\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine("-------------");
            int a = 0, b = 0, c = 0;//方法&厚度&材質
            float n = 0;//長度(mm)
            float m = 0;//所要花費的價錢
            int flag = 1;//停止鈕
            while (flag==1) 
            {
                Console.WriteLine("使用方法? 焊接一(1)焊接二(2)雷切(3)");
                a = Convert.ToInt32(Console.ReadLine());//方式                
                
                switch (a) 
                {
                    case 1:
                        Console.WriteLine("板材厚度? <3mm(1) 3-6mm(2) 6-8mm(3) 8-12mm(4) 12mm以上(5)");
                        b = Convert.ToInt32(Console.ReadLine());
                        while (b > 5 || b < 1)
                        {
                            Console.WriteLine("無此厚度選項 請重選");
                            b = Convert.ToInt32(Console.ReadLine());
                        }
                        Console.WriteLine("選擇材質? 黑鐵(1) 白鐵(2) 鋁(3)");
                        c = Convert.ToInt32(Console.ReadLine());
                        while (c > 3 || c < 1)
                        {
                            Console.WriteLine("無此材質選項 請重選");
                            c = Convert.ToInt32(Console.ReadLine());
                        }
                        Console.WriteLine("輸入所要焊接之長度(mm)?");
                        n = float.Parse(Console.ReadLine());
                        m += n / float.Parse(data[b][4]) * float.Parse(data[b][c]);
                        break;

                    case 2:
                        Console.WriteLine("板材厚度? <3mm(1) 3-6mm(2) 6-8mm(3) 8-12mm(4) 12mm以上(5)");
                        b = Convert.ToInt32(Console.ReadLine());
                        while (b > 5 || b < 1)
                        {
                            Console.WriteLine("無此厚度選項 請重選");
                            b = Convert.ToInt32(Console.ReadLine());
                        }
                        Console.WriteLine("選擇材質? 黑鐵(1) 白鐵(2) 鋁(3)");
                        c = Convert.ToInt32(Console.ReadLine());
                        while (c > 3 || c < 1)
                        {
                            Console.WriteLine("無此材質選項 請重選");
                            c = Convert.ToInt32(Console.ReadLine());
                        }
                        Console.WriteLine("輸入所要焊接之長度(mm)?");
                        n = float.Parse(Console.ReadLine());
                        m += n / float.Parse(data[b + 7][4]) * float.Parse(data[b + 7][c]);
                        break;

                    case 3:
                        Console.WriteLine("板材厚度? <3mm(1) 4-6mm(2) 8-10mm(3) 12mm以上(4)");
                        b = Convert.ToInt32(Console.ReadLine());
                        while (b > 4 || b < 1)
                        {
                            Console.WriteLine("無此厚度選項 請重選");
                            b = Convert.ToInt32(Console.ReadLine());
                        }
                        if (b > 2) 
                        {
                            Console.WriteLine("選擇材質? 黑鐵(1) 白鐵(2)");
                            c = Convert.ToInt32(Console.ReadLine());
                            while (c > 2 || c < 1)
                            {
                                Console.WriteLine("無此材質選項 請重選");
                                c = Convert.ToInt32(Console.ReadLine());
                            }
                            Console.WriteLine("輸入所要雷切之長度(mm)?");
                            n = float.Parse(Console.ReadLine());
                            m += n / float.Parse(data[b + 14][4]) * float.Parse(data[b + 14][c]);
                        }else
                        {
                            Console.WriteLine("選擇材質? 黑鐵(1) 白鐵(2) 鋁(3)");
                            c = Convert.ToInt32(Console.ReadLine());
                            while (c > 3 || c < 1)
                            {
                                Console.WriteLine("無此材質選項 請重選");
                                c = Convert.ToInt32(Console.ReadLine());
                            }
                            Console.WriteLine("輸入所要雷切之長度(mm)?");
                            n = float.Parse(Console.ReadLine());
                            m += n / float.Parse(data[b + 14][4]) * float.Parse(data[b + 14][c]);
                        }                        
                        break;
                    default:
                        Console.WriteLine("格式錯誤");
                        break;

                }
                Console.WriteLine("-------------");
                Console.WriteLine("目前花費為 {0} 元", m);
                Console.WriteLine("-------------");
                Console.WriteLine("是否繼續運算? YES(1)/NO(0)");
                flag = Convert.ToInt32(Console.ReadLine());

            }
            Console.WriteLine("-------------");
            Console.WriteLine("總花費為 {0} 元", m);

        }
    }
}