         public static Container GetAllTypesInContainer<t>(this Container bw, Action<List<t>> Callback)
        {
            var list = new List<t>();            
            list= bw.GetChildren().OfType<t>().ToList();
            Callback(list);
            return bw;
        }
