    private bool entering = true;
    private Point _previousPoint;
    private bool _speedUp;
    private bool _slowDown;
    private double _speedMod = 2;
    private double _slowMod = .5;
    private void OnMouseMove(object sender, MouseEventArgs e)
    {
        Point curr = new Point(System.Windows.Forms.Cursor.Position.X, System.Windows.Forms.Cursor.Position.Y);
        if (entering)
        {
            _previousPoint = curr;
            entering = false;
        }
        if (_previousPoint == curr)
            return; // The mouse hasn't really moved
        Vector delta = curr - _previousPoint;
        if (_slowDown && !_speedUp)
            delta *= _slowMod;
        else if (_speedUp && !_slowDown)
            delta *= _speedMod;
        else
        {
            _previousPoint = curr;
            return; //no modifiers... lets not do anything
        }
        Point newPoint = _previousPoint + delta;
        _previousPoint = newPoint;
        //Set the point
        System.Windows.Forms.Cursor.Position = new System.Drawing.Point((int)newPoint.X, (int)newPoint.Y);
    }
