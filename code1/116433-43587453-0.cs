                var stringTest = "\r Test\nThe Quick\r\n brown fox";
                Console.WriteLine("Original is:");
                Console.WriteLine(stringTest);
                Console.WriteLine("-------------");
                stringTest = stringTest.Trim().Replace("\r", string.Empty);
                stringTest = stringTest.Trim().Replace("\n", string.Empty);
                stringTest = stringTest.Replace(Environment.NewLine, string.Empty);
                Console.WriteLine("Output is : ");
                Console.WriteLine(stringTest);
                Console.ReadLine();
