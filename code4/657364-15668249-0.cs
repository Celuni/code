                switch (osInfo.Version.Major)
                {
                    case 3:
                        Console.WriteLine("Windows NT 3.51");
                        break;
                    case 4:
                        Console.WriteLine("Windows NT 4.0");
                        break;
                    case 5:
                        if (osInfo.Version.Minor == 0)
                            Console.WriteLine("Windows 2000");
                        else
                            Console.WriteLine("Windows XP");
                        break;
                    case 6:
                         if(osInfo.Version.Minor == 0)
                            Console.WriteLine("Windows Vista");
                         else if(osInfo.Version.Minor == 1)
                             Console.WriteLine("Windows 7");
                         else if(osInfo.Version.Minor == 2)
                             Console.WriteLine("Windows 8")
                         break; 
                } break;
