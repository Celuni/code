            for (int index = 0; index < ListaDados.ItemsSource.Count; index++)
            {
                var items = ListaDados.ItemsSource.ToArray();
                Envolvido envolvido = items[index];
                for (int i = 0; i < ListaDados.ItemsSource.OfType<object>().Count(); i++)
                {
                    var suspid = Convert.FromBase64String(envolvido.SUSPID);
                    var ivnome = Convert.FromBase64String(envolvido.IVNOME);
                }
            }
