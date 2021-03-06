    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace testscores
    {
        class Program
        {
            static int[] score = new int[5];
            //Get Values     
            private static int GetValues()
            {
                string inValue;
                
                int total = 0;
    
                for (int i = 0; i < score.Length; i++)
                {
                    Console.Write("Enter Value {0}: ", i + 1);
                    inValue = Console.ReadLine();
                    score[i] = Convert.ToInt32(inValue);
                }
    
                for (int i = 0; i < score.Length; i++)
                {
                    total += score[i];
                }
                return total;
            }
    
            //FIND AVERAGE
            private static double FindAverage()
            {
                double total = GetValues();
                double average = total / 5.0;
                return average;
            }
    
            //Show
            static void Show(double average)
            {
                Console.WriteLine("The values are:");
                for (int i = 0; i < score.Length; i++)
                {
                    Console.WriteLine(string.Format("The {0} value you entered was {1}", i + 1, score[i]));
                }
                Console.WriteLine("The average is: {0}", average);
            }
            //Main
            static void Main()
            {
                double avg = FindAverage();
                Show(avg);
                Console.ReadKey();
            }
        }
    }
