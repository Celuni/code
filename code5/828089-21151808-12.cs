     private void List_OnSizeChanged(object sender, SizeChangedEventArgs e)
     {
            var list = sender as ListViewBase;
            if (list == null || list.Items == null)
            {
                return;
            }
            var n = list.Items.Count;
            var containingFixedGrid = FindVisualParent<Grid>(list);  // this is an attempt to get the first container that is bounded by the actual height of the UI, in my case and the general case it is probably going to be a grid, but you may need to update this to whatever element makes sense; you can also use a named element
            if (containingFixedGrid == null || containingFixedGrid.ActualHeight > this.ActualHeight)
            {
                return;
            }
            var gen = list.ItemContainerGenerator;
            if (gen != null)
            {
                var adjustOffset = 2;  // small adjustment needed for alignment, adjust for your needs
                var height = 0.0;
                DependencyObject o;
                for (var i = 0; i < n && (o = gen.ContainerFromIndex(i)) != null; i++)
                {
                    var item = o as FrameworkElement;
                    if (item != null)
                    {
                        // calculate the offset of this item to its containing grid
                        var t = item.TransformToVisual(containingFixedGrid) as MatrixTransform;
                        if (t != null && t.Matrix.OffsetY + item.ActualHeight < containingFixedGrid.ActualHeight)
                        {
                            height += item.ActualHeight + adjustOffset;
                        }
                    }
                }
                // set height, unsub and resub to listeners otherwise endless layout cycle
                if (height > 0)
                {
                    list.SizeChanged -= List_OnSizeChanged;
                    list.Height = height;
                    list.SizeChanged += List_OnSizeChanged;
                }
            }
        }
        public static T FindVisualParent<T>(DependencyObject element) where T : DependencyObject
        {
            var parent = element; 
            while (parent != null)
            {
                T type = parent as T; if (type != null)
                {
                    return type;
                }
                parent = VisualTreeHelper.GetParent(parent) as UIElement;
            } 
            return null;
        }
