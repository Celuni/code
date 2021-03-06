    private static bool CheckHeaders(string folderPath, int headersCount)
    {
        var enumerators = Directory.EnumerateFiles(folderPath)
            .Select(f => File.ReadLines(f).GetEnumerator())
            .ToArray();
        using (var disposable = new DisposableEnumerable(enumerators))
        {
            for (int i = 0; i < headersCount; i++)
            {
                foreach (var e in enumerators)
                {
                    if (!e.MoveNext()) return false;
                }
                var values = enumerators.Select(e => e.Current);
                if (values.Distinct().Count() > 1) return false;
            }
            return true;
        }
    }
