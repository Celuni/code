            public static void mudarSpawn_1(GtaPlayer player, string coordenadas)
            {
                char[] delimiterChars = { ' ', ',' };
                string text = coordenadas;
                string[] words = text.Split(delimiterChars);
                float x = new float();
                float y = new float();
                float z = new float();
                try
                {
                    x = float.Parse(words[0], System.Globalization.CultureInfo.InvariantCulture);
                    y = float.Parse(words[1], System.Globalization.CultureInfo.InvariantCulture);
                    z = float.Parse(words[1], System.Globalization.CultureInfo.InvariantCulture);
                }
                catch (Exception e)
                {
                    player.SendClientMessage(Color.DarkOrange, "Os valores de x,y e z não foram inseridos de forma correcta, apenas podes usar numeros");
                    player.SendClientMessage(Color.DarkOrange, "Ex: /mudarspawn3 6321.6 , 96321.38 , 66322.2 ou /mudarspawn3 6321.6 96321.38 66322.2");
                }
    
                MSGameMysql.mudarspawn1(x, y, z);
                player.SendClientMessage(Color.AliceBlue, "Acabaste de mudar o spawn 1 para: x='" + x + "' y='" + y + "' z='" + z + "'");
    
    
            }
