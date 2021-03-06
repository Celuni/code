    using System.Windows.Forms;
    public class MyButton : Button
    {
        protected override void OnMouseDown(MouseEventArgs e)
        {
            SetPushed(true);
            base.OnMouseDown(e);
            Invalidate();
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            SetPushed(false);
            base.OnMouseUp(e);
            Invalidate();
        }
        private void SetPushed(bool value)
        {
            var setFlag = typeof(ButtonBase).GetMethod("SetFlag", 
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.NonPublic);
            if(setFlag != null)
            {
                setFlag.Invoke(this, new object[] { 2, value });
                setFlag.Invoke(this, new object[] { 4, value });
            }
        }
    }
