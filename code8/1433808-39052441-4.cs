            Dictionary<string, object> a = new Dictionary<string, object>();
            Dictionary<string, object> b = new Dictionary<string, object>();
            Dictionary<string, object> c = new Dictionary<string, object>();
            Dictionary<string, object> d = new Dictionary<string, object>();
            Dictionary<string, object> h = new Dictionary<string, object>();
            Dictionary<string, object> f = new Dictionary<string, object>();
            Dictionary<string, object> g = new Dictionary<string, object>();
            object[] arrayOfObjects = {"This","is","an","array","of","objects"};
            object w, v, x, y, z;
            w = "string w";
            v = "string v";
            x = "string x";
            y = "string y";
            z = "string z";
            h.Add("h2", arrayOfObjects);
            h.Add("h1", y);
            d.Add("d2", h);
            d.Add("d1", x);
            c.Add("c1", w);
            b.Add("b1", c);
            b.Add("b2", v);
            b.Add("b3", d);
            a.Add("a1", b);
            a.Add("a2", z);
            treeView1.Nodes.AddRange(RecurseTree(a));
