     private static void Main(string[] args)
        {
            // PrintSeries(7, 13);
            PrintSeries(2, 8);
            Console.WriteLine("=" + sum);
            System.Console.ReadKey();
        }
        private static int sum = 0;
        private static int PrintSeries(int number, int number2)
        {
            if (number < 1)
            {
                number = 1;
            }
            if (number2 <= number)
            {
              if (number % 2 == 0)
                {
                    return number;
                }
                return number + number % 2;
            }
            else
            {
                int num = PrintSeries(number, number2 - 2);
                Console.Write("+" + num);
                sum += num;
                return num += 2;
            }
        }
