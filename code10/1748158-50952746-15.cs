    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    
    namespace WpfApp2.Behaviors
    {
    	public class TextBoxExtensions
    	{
    		public static readonly DependencyProperty WatermarkProperty = DependencyProperty.RegisterAttached(
    			"Watermark",
    			typeof(string),
    			typeof(TextBoxExtensions),
    			new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender, OnWatermarkTextChanged)
    		);
    
    		private static void OnWatermarkTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    		{
    			var tb = d as TextBox;
    
    			if (tb != null)
    			{
    				var textChangedHandler = new TextChangedEventHandler((s, ea) => ShowOrHideWatermark(s as TextBox));
    				var focusChangedHandler = new DependencyPropertyChangedEventHandler((s, ea) => ShowOrHideWatermark(s as TextBox));
    				var sizeChangedHandler = new SizeChangedEventHandler((s, ea) => ShowOrHideWatermark(s as TextBox));
    
    				if (string.IsNullOrEmpty(e.OldValue as string))
    				{
    					tb.TextChanged += textChangedHandler;
    					tb.IsKeyboardFocusedChanged += focusChangedHandler;
    					// We need SizeChanged events because the Background brush is sized according to the control size
    					tb.SizeChanged += sizeChangedHandler;
    				}
    
    				if (string.IsNullOrEmpty(e.NewValue as string))
    				{
    					tb.TextChanged -= textChangedHandler;
    					tb.IsKeyboardFocusedChanged -= focusChangedHandler;
    					tb.SizeChanged -= sizeChangedHandler;
    				}
    
    				ShowOrHideWatermark(tb);
    			}
    		}
    
    		public static string GetWatermark(DependencyObject element)
    		{
    			return (string)element.GetValue(WatermarkProperty);
    		}
    
    		public static void SetWatermark(DependencyObject element, string value)
    		{
    			element.SetValue(WatermarkProperty, value);
    		}
    
    		private static void ShowOrHideWatermark(TextBox tb)
    		{
    			// Restore TextBox background to style/theme value
    			tb.ClearValue(TextBox.BackgroundProperty);
    			if (string.IsNullOrEmpty(tb.Text) && !tb.IsKeyboardFocused)
    			{
    				var wm = GetWatermark(tb);
    				if (!string.IsNullOrEmpty(wm))
    				{
    					tb.Background = CreateTextBrush(wm, tb);
    				}
    			}
    		}
    
    		private static Brush CreateTextBrush(string text, TextBox tb)
    		{
    			Grid g = new Grid
    			{
    				Background = tb.Background,
    				Width = tb.ActualWidth,
    				Height = tb.ActualHeight
    			};
    
    			g.Children.Add(new Label
    			{
    				Padding = new Thickness(2,0,0,0),
    				FontSize = tb.FontSize,
    				FontFamily = tb.FontFamily,
    				Foreground = Brushes.LightGray,
    				Content = text
    			});
    
    			VisualBrush vb = new VisualBrush
    			{
    				Visual = g,
    				Stretch = Stretch.None,
    				AlignmentX = AlignmentX.Left,
    				AlignmentY = AlignmentY.Center,
    			};
    
    			return vb;
    		}
    	}
    }
