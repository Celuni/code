    class Test
    {
        Form1 _frm = null;
    
        public void _TestMethod(Form1 f)
        {
            _frm = f;
            _frm._MainPublicMethod("Test Message", "Test Text");
        }
    }
