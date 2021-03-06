    <Window x:Class="ImageDemo.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
            xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
            xmlns:local="clr-namespace:ImageDemo"
            mc:Ignorable="d"
            Title="MainWindow" Height="350" Width="525" >
    	<Window.DataContext>
    		<local:ImageEditor x:Name="editor" FileName="C:\test.png"/>
    	</Window.DataContext>
    
    	<DockPanel>
    		<Menu DockPanel.Dock="Top" >
    			<ComboBox SelectedValue="{Binding DefaultDrawingAttributes.Color, ElementName=inkCanvas}">
    				<Color>White</Color>
    				<Color>Black</Color>
    				<Color>Yellow</Color>
    				<Color>Red</Color>
    				<Color>Cyan</Color>
    				<Color>SpringGreen</Color>
    				<ComboBox.ItemTemplate>
    					<DataTemplate>
    						<Rectangle Width="15" Height="15">
    							<Rectangle.Fill>
    								<SolidColorBrush Color="{Binding Mode=OneWay}" />
    							</Rectangle.Fill>
    						</Rectangle>
    					</DataTemplate>
    				</ComboBox.ItemTemplate>
    			</ComboBox>
    			<MenuItem Command="ApplicationCommands.Save" />
    			<MenuItem Command="ApplicationCommands.Undo" />
    		</Menu>
    			<Grid HorizontalAlignment="Left" VerticalAlignment="Top" ScrollViewer.HorizontalScrollBarVisibility="Auto" ScrollViewer.VerticalScrollBarVisibility="Auto">
    				<Image Source="{Binding ImageFrame}" Stretch="None"/>
    				<InkCanvas x:Name="inkCanvas" Background="Transparent" >
    					<InkCanvas.DefaultDrawingAttributes>
    						<DrawingAttributes x:Name="DrawSetting" />
    					</InkCanvas.DefaultDrawingAttributes>
    				</InkCanvas>
    			</Grid>
    	</DockPanel>
    </Window>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			CommandBindings.Add(new CommandBinding(ApplicationCommands.Save, execSave, hasChanged));
			CommandBindings.Add(new CommandBinding(ApplicationCommands.Undo, execUndo, hasChanged));
			editor.Load();
		}
		private void hasChanged(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = inkCanvas.Strokes.Count > 0;
			e.Handled = true;
		}
		private void execUndo(object sender, ExecutedRoutedEventArgs e)
		{
			inkCanvas.Strokes.Remove(inkCanvas.Strokes.Last());
			e.Handled = true;
		}
		private void execSave(object sender, ExecutedRoutedEventArgs e)
		{
			DrawingVisual drawingVisual = new DrawingVisual();
			DrawingContext drawingContext = drawingVisual.RenderOpen();
			drawingContext.DrawImage(editor.ImageFrame, new Rect(0,0, editor.ImageFrame.Width,editor.ImageFrame.Height));
			foreach (var item in inkCanvas.Strokes)
			{
				item.Draw(drawingContext);
			}
			drawingContext.Close();
			inkCanvas.Strokes.Clear();
			var width = editor.ImageFrame.Width;
			var height = editor.ImageFrame.Height;
			var bitmap = new RenderTargetBitmap((int)width, (int)height, 96, 96, PixelFormats.Pbgra32);
			bitmap.Render(drawingVisual);
			editor.ImageFrame = bitmap;
			editor.Save();
			e.Handled = true;
		}
	}
