        IDictionary<int, IEnumerable<string>> MergeArrays2(
            IEnumerable<int> idCollection,
            params IEnumerable<string>[] valueCollections)
        {
            var values = valueCollections.ToList();
            return idCollection.Select(
                (id, index) => new { Key = id, Value = values[index] })
                .ToDictionary(x => x.Key, x => x.Value);
        }
