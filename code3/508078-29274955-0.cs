    using System;
    using System.IO;
    using SharpSvn;
    using SharpSvn.UI;
    class SvnDumpFileToRepository
    {
        static void Main(string[] args)
        {
            Uri uri = null;
            if (args.Length < 2
                || !Uri.TryCreate(args[0], UriKind.Absolute, out uri))
            {
                Console.Error.WriteLine("Usage: SvnDumpFileToRepository URL PATH");
            }
            using (SvnRepositoryClient repos = new SvnRepositoryClient())
            {
                repos.CreateRepository(args[1]);
            }
            Uri reposUri = SvnTools.LocalPathToUri(args[1], true);
            using (SvnClient client = new SvnClient())
            using (SvnClient client2 = new SvnClient())
            {
                SvnUI.Bind(client, new SvnUIBindArgs());
                string fileName = SvnTools.GetFileName(uri);
                bool create = true;
                client.FileVersions(uri,
                    delegate(object sender, SvnFileVersionEventArgs e)
                    {
                        Console.Write("Copying {0} in r{1}", fileName, e.Revision);
                        using (MemoryStream ms = new MemoryStream())
                        {
                            e.WriteTo(ms); // Write full text to memory stream
                            ms.Position = 0;
                            // And now use 'svnmucc' to update repository
                            client2.RepositoryOperation(reposUri,
                                new SvnRepositoryOperationArgs { LogMessage = e.LogMessage },
                                delegate(SvnMultiCommandClient mucc)
                                {
                                    if (create)
                                    {
                                        mucc.CreateFile(fileName, ms);
                                        create = false;
                                    }
                                    else
                                        mucc.UpdateFile(fileName, ms);
                                });
                        }
                    });
            }
        }
    }
