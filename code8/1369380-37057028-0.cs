    Button button2 = new Button();
                    button2.Text = "buy";
                      button2.ID = ddr[2].ToString();
                    button2.Style[" border-style"] = "solid";
                    button2.Style["background-color"] = "#063a83";
                    button2.Style[" border-width"] = "3px";
                    button2.Style[" color"] = "White";
                    button2.Style[" font-family"] = "Tahoma";
                    button2.Style[" border-color"] = "Gray";
                    button2.Style[" border-radius"] = "10px";
                    button2.Style[" background-image"] = "url(../images/products/zoom2.png)";
                    button2.Style[" background-repeat"] = "no-repeat";
                    button2.Style[" padding"] = "10px";
                    button2.Style["Cursor"] = "pointer";
                   button2.Click += new System.EventHandler(detail_Click);
                    Panelproduct.Controls.Add(button2);
