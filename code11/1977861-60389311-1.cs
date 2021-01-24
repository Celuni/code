    [assembly: ExportRenderer(typeof(MyLabel), typeof(MyLabelRenderer))]
    namespace LabelDemo.Droid
    {
     public class MyLabelRenderer : ViewRenderer<MyLabel, TextView>
    {
      TextView textView;
    public MyLabelRenderer(Context context) : base(context)
    {
    }
    protected override void OnElementChanged(ElementChangedEventArgs<MyLabel> e)
    {
        base.OnElementChanged(e);
        var label = (MyLabel)Element;
        if (label == null)
            return;
        if (Control == null)
        {
            textView = new TextView(this.Context);
        }
        textView.Enabled = true;
        textView.Focusable = true;
        textView.LongClickable = true;
        textView.SetTextIsSelectable(true);
        // Initial properties Set
        textView.Text = label.Text;
        textView.SetTextColor(label.TextColor.ToAndroid());
        switch (label.FontAttributes)
        {
            case FontAttributes.None:
                textView.SetTypeface(null, Android.Graphics.TypefaceStyle.Normal);
                break;
            case FontAttributes.Bold:
                textView.SetTypeface(null, Android.Graphics.TypefaceStyle.Bold);
                break;
            case FontAttributes.Italic:
                textView.SetTypeface(null, Android.Graphics.TypefaceStyle.Italic);
                break;
            default:
                textView.SetTypeface(null, Android.Graphics.TypefaceStyle.Normal);
                break;
        }
        textView.TextSize = (float)label.FontSize;
        SetNativeControl(textView);
     }
    protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        base.OnElementPropertyChanged(sender, e);
        if (e.PropertyName == MyLabel.TextProperty.PropertyName)
        {
            if (Control != null && Element != null && !string.IsNullOrWhiteSpace(Element.Text))
            {
                textView.Text = Element.Text;
            }
        }
        else if (e.PropertyName == MyLabel.TextColorProperty.PropertyName)
        {
            if (Control != null && Element != null)
            {
                textView.SetTextColor(Element.TextColor.ToAndroid());
            }
        }
        else if (e.PropertyName == MyLabel.FontAttributesProperty.PropertyName
                    || e.PropertyName == MyLabel.FontSizeProperty.PropertyName)
        {
            if (Control != null && Element != null)
            {
                switch (Element.FontAttributes)
                {
                    case FontAttributes.None:
                        textView.SetTypeface(null, Android.Graphics.TypefaceStyle.Normal);
                        break;
                    case FontAttributes.Bold:
                        textView.SetTypeface(null, Android.Graphics.TypefaceStyle.Bold);
                        break;
                    case FontAttributes.Italic:
                        textView.SetTypeface(null, Android.Graphics.TypefaceStyle.Italic);
                        break;
                    default:
                        textView.SetTypeface(null, Android.Graphics.TypefaceStyle.Normal);
                        break;
                }
                textView.TextSize = (float)Element.FontSize;
            }
        }
    }
    }
    }
