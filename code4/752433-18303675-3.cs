    ResultsListBox.ItemsSource = from song in band.Descendants("song")
                                 select new Song {
                                                  Name = song.Attribute("name").Value,
                                                  Sum = song.Attribute("sum").Value,
                                                  Number = song.Attribute("number").Value
                                                 };
