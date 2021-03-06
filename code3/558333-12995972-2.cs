    using Microsoft.Office.Interop.Word;
            namespace ConsoleApplication1
            {
                class Program
                {
                    static void Main(string[] args)
                    {
                        Application application = new Application();
                        application.Visible = false;
                        
                        Document document = application.Documents.Open(@"C:\file.docx", Type.Missing, true);
                        // Loop through all words in the document.
                        int count = document.Words.Count;
                        for (int i = 1; i <= count; i++)
                        {
                            string text = document.Words[i].Text; //you can validate if string.IsNullOrEmpty....
                            string fontName = document.Words[i].Font.Name;
                            string bold = document.Words[i].Font.Bold.ToString();
                            string fontSize = document.Words[i].Font.Size.ToString();
                            Console.WriteLine("Word {0} = {1} -- Font:{2}, Size: {3}, Bold:{4}", i, text, fontName, fontSize, bold);
                        }
                        
                        application.Quit();
                        Console.ReadLine();
                       }
                }
            }
