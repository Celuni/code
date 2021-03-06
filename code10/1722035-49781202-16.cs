    private void numericUpDown1_KeyDown(object sender, KeyEventArgs e)
        {
            KeysConverter kc = new KeysConverter();
            char c = char.ToLower(kc.ConvertToString(e.KeyValue)[0]);
            Boolean ctrl = e.Control;
            Boolean alt = e.Alt;
            Boolean shift = e.Shift;
            int keyPadStart = (int)Keys.NumPad0;
            int keyPadEnd = (int)Keys.NumPad9;
            if (e.KeyValue >= keyPadStart && e.KeyValue <= keyPadEnd)
            {
                //send to numeric updown. 
                return;
            }
            
            if (char.IsLetter(c) && !alt)
            {
                if (shift) c = char.ToUpper(c);
                
                //Check, if its valid for si prefixes.
                if (this.siSelector1.TrySelect(c))
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
            //not working: if (ctrl && alt && c=='m')
            if (ctrl && alt && e.KeyValue==77)
            {
                //Check, if its valid for si prefixes.
                if (this.siSelector1.TrySelect('µ'))
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
        }
