using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;

namespace benchmark
{
    public class Program
    {
        public static void Main(string[] args) 
        {
            // Use BenchmarkRunner.Run to Benchmark your code
            var summary = BenchmarkRunner.Run<Test>();
        }
    }

    // We are using .Net Core we are adding the CoreJobAttribute here.
    
    public class Test
    {
        private static Random random = new Random();
        private List<int> list;

        int[] myArray;
        Dictionary<int, int> myDictionary;
        List<int> mylist;
        List<string> directions;



        public static List<int> RandomIntList(int length)
        {
            int Min = 1;
            int Max = 10;
            return Enumerable
                .Repeat(0, length)
                .Select(i => random.Next(Min, Max))
                .ToList();
        }

        public static List<string> RandomStringList(int length)
        {
            int Min = 0;
            int Max = 3;
            String[] direction = { "E", "W", "N", "S"};
            return Enumerable
                .Repeat(0, length)
                .Select(i => direction[random.Next(Min, Max)])
                .ToList();
        }

        [Params(10, 100)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            list = RandomIntList(N);
            directions = RandomStringList(N);
        }

        [Benchmark]
        public void Foreach()
        {
            int total = 0;
            foreach (int i in list)
            {
                total += i;
            }

        }

        [Benchmark]
        public void While()
        {
            int total = 0;
            int i = 0;
            while (i < list.Count)
            {
                total += list[i++];
            }

        }


        [Benchmark]
        public void For()
        {
            int total = 0;
            for (int i = 0; i < list.Count; i++)
            {
                total += list[i];
            }
        }

        [Benchmark]
        public void IF()
        {
            
            foreach(string dir in directions)
            {
                if(dir == "EAST")
                    Console.WriteLine(dir);
                else if(dir == "WEST")
                    Console.WriteLine(dir);
                else if(dir == "North")
                    Console.WriteLine(dir);
                else if(dir == "South")
                    Console.WriteLine(dir );
                else Console.WriteLine("Wrong Data");

            }
            
        }

        [Benchmark]
        public void SWITCH()
        {

            foreach (string dir in directions)
            {
                switch (dir)
                {
                    case "EAST":
                        Console.WriteLine(dir);
                        break;
                    case "WEST":
                        Console.WriteLine(dir);
                        break;
                    case "NORTH":
                        Console.WriteLine(dir);
                        break;
                    case "SOUTH":
                        Console.WriteLine(dir);
                        break;
                    default:
                        Console.WriteLine("Wrong Data");
                        break;

                }
            }

        }


    }
}