    using System;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Media;
    
    namespace MyProject.Extensions
    {
        public class ImageInScrollView : DependencyObject
        {
            public static readonly DependencyProperty HandlerEnabledProperty =
                DependencyProperty.RegisterAttached("HandlerEnabled", typeof(bool), typeof(Image), new PropertyMetadata(false, OnHandlerEnabledChanged));
            public static void SetHandlerEnabled(DependencyObject obj, object value)
            {
                obj.SetValue(HandlerEnabledProperty, value);
            }
            public static object GetHandlerEnabled(DependencyObject obj)
            {
                return obj.GetValue(HandlerEnabledProperty);
            }
            private static void OnHandlerEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                Image image = (d as Image);
                bool HandlerEnabled;
                bool.TryParse(e.NewValue.ToString(), out HandlerEnabled);
                if (HandlerEnabled)
                {
                    image.ImageOpened -= ImageOpenedInScrollViewer;
                    image.ImageOpened += ImageOpenedInScrollViewer;
    
                    image.Stretch = Stretch.Uniform;
                }
                else
                {
                    image.ImageOpened -= ImageOpenedInScrollViewer;
                }
            }
    
            private static void ImageOpenedInScrollViewer(object sender, Windows.UI.Xaml.RoutedEventArgs e)
            {
                Image image = sender as Image;
    
                ScrollViewer parentScrollView = GetParentScrollView(image.Parent as FrameworkElement);
                if(parentScrollView == null)
                {
                    return;
                }
                parentScrollView.IsScrollInertiaEnabled = true;
    
                if (parentScrollView.ViewportWidth < image.ActualWidth)
                {
                    parentScrollView.MinZoomFactor = (float)(parentScrollView.ViewportWidth / image.ActualWidth);
                    parentScrollView.ChangeView(parentScrollView.HorizontalOffset, parentScrollView.VerticalOffset, parentScrollView.MinZoomFactor);
                }
                else if (parentScrollView.ViewportHeight < image.ActualHeight)
                {
                    parentScrollView.MinZoomFactor = (float)(parentScrollView.ViewportHeight / image.ActualHeight);
                    parentScrollView.ChangeView(parentScrollView.HorizontalOffset, parentScrollView.VerticalOffset, parentScrollView.MinZoomFactor);
                }
                else
                {
                    if(image.ActualHeight > image.ActualWidth)
                    {
                        image.Width = image.ActualWidth;
                    }
                    else
                    {
                        image.Height = image.ActualHeight;
                    }
                    parentScrollView.MinZoomFactor = 1;
                }
            }
    
            private static ScrollViewer GetParentScrollView(FrameworkElement parent)
            {
                ScrollViewer parentScrollView;
                while ((parentScrollView = parent as ScrollViewer) == null)
                {
                    parent = parent.Parent as FrameworkElement;
                    if (parent == null)
                    {
                        //could not find parent ScrollViewer
                        return null;
                    }
                }
                return parentScrollView;
            }
        }
    }
        
