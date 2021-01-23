    public static class DisallowSpecialCharactersTextboxBehavior
    {
        public static DependencyProperty DisallowSpecialCharactersProperty =
            DependencyProperty.RegisterAttached("DisallowSpecialCharacters", typeof(bool), typeof(DisallowSpecialCharactersTextboxBehavior), new PropertyMetadata(DisallowSpecialCharactersChanged));
    
        public static void SetDisallowSpecialCharacters(TextBox textBox, bool disallow)
        {
            textBox.SetValue(DisallowSpecialCharactersProperty, disallow);
        }
    
        public static bool GetDisallowSpecialCharacters(TextBox textBox)
        {
            return (bool)textBox.GetValue(DisallowSpecialCharactersProperty);
        }
    
        private static void DisallowSpecialCharactersChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            var tb = dependencyObject as TextBox;
            if (tb != null)
            {
    
                if ((bool)e.NewValue)
                {
                    tb.PreviewTextInput += tb_PreviewTextInput;
                    tb.AddHandler(DataObject.PastingEvent, new DataObjectPastingEventHandler(tb_Pasting));
                }
                else
                {
                    tb.PreviewTextInput -= tb_PreviewTextInput;
                    tb.RemoveHandler(DataObject.PastingEvent, new DataObjectPastingEventHandler(tb_Pasting));
                }
    
            }
        }
    
        private static void tb_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            var pastedText = e.DataObject.GetData(typeof(string)) as string;
    
            Path.GetInvalidFileNameChars().ToList().ForEach(c =>
                {
                    if (pastedText.Contains(c))
                    {
                        e.CancelCommand();
                    }
    
                });
        }
    
        private static void tb_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (Path.GetInvalidFileNameChars().ToList().ConvertAll(x => x.ToString()).Contains(e.Text))
            {
                e.Handled = true;
            }
    
        }
    }
