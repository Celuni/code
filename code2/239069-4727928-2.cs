	Setter setter = new Setter();
	setter.Property = ListViewItem.TemplateProperty;
	ControlTemplate template = new ControlTemplate(typeof(ListViewItem));
	var grid = new FrameworkElementFactory(typeof(Grid));
	var border = new FrameworkElementFactory(typeof(Border));
	border.SetValue(Border.BackgroundProperty, Brushes.White);
	border.SetValue(Border.NameProperty, "mask");
	border.SetValue(Border.CornerRadiusProperty, new CornerRadius(15));
	grid.AppendChild(border);
	var stackPanel = new FrameworkElementFactory(typeof(StackPanel));
	stackPanel.SetValue(StackPanel.BackgroundProperty, Brushes.Beige);
	var visualBrush = new FrameworkElementFactory(typeof(VisualBrush));
	visualBrush.SetBinding(VisualBrush.VisualProperty, new Binding() { ElementName = "mask" });
	stackPanel.SetValue(StackPanel.OpacityMaskProperty, visualBrush);
	var gridViewRowPresenter = new FrameworkElementFactory(typeof(GridViewRowPresenter));
	gridViewRowPresenter.SetValue(GridViewRowPresenter.ContentProperty, new TemplateBindingExtension(GridViewRowPresenter.ContentProperty));
	gridViewRowPresenter.SetValue(GridViewRowPresenter.ColumnsProperty, new TemplateBindingExtension(GridView.ColumnCollectionProperty));
	stackPanel.AppendChild(gridViewRowPresenter);
	var textBlock = new FrameworkElementFactory(typeof(TextBlock));
	textBlock.SetValue(TextBlock.BackgroundProperty, Brushes.LightBlue);
	textBlock.SetBinding(TextBlock.TextProperty, new Binding("News"));
	stackPanel.AppendChild(textBlock);
	grid.AppendChild(stackPanel);
	template.VisualTree = grid;
	setter.Value = template;
