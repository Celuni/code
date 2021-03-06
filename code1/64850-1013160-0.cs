        private List<MyItem> items = new List<MyItem> {
            new MyItem {Id = 0, Name = "Hello"},
            new MyItem {Id = 1, Name = "World"},
            new MyItem {Id = 2, Name = "Foo"},
            new MyItem {Id = 3, Name = "Bar"},
            new MyItem {Id = 4, Name = "Scott"},
            new MyItem {Id = 5, Name = "Tiger"},
        };
        private BindingSource bs;
        private void Form1_Load(object sender, EventArgs e)
        {
            bs = new BindingSource(items, string.Empty);
            dataGridView1.DataSource = bs;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int position = bs.Position;
            if (position == 0) return;  // already at top
            
            MyItem current = (MyItem)bs.Current;
            bs.Remove(current);
            position--;
            bs.Insert(position, current);
            bs.Position = position;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            int position = bs.Position;
            if (position == bs.Count -1) return;  // already at bottom
            MyItem current = (MyItem)bs.Current;
            bs.Remove(current);
            position++;
            bs.Insert(position, current);
            bs.Position = position;
        }
        public class MyItem
        {
            public int Id { get; set; }
            public String Name { get; set; }
        }
