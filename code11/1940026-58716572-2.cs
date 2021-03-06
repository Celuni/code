foreach ( var gizmo in _context.Gizmos )
  foreach (var widget in gizmo.Widgets.ToList() )
    if ( widget.Id == myId )
      gizmo.Widgets.Remove(widget);
The ToList() is to avoid index conflict when removing.
Fastest alternative:
    for ( int indexGizmo = 0; indexGizmo < _context.Gizmos.Count(); indexGizmo++ )
    {
      var gizmo = _context.Gizmos[indexGizmo];
      for ( int indexWidget = gizmo.Widgets.Count() - 1; indexWidget >= 0; indexWidget-- )
      {
        var widget = gizmo.Widgets[indexWidget];
        if ( widget.Id == myId )
          gizmo.Widgets.Remove(widget);
      }
    }
Using Linq and a lopp on the result to remove items:
    var list = from gizmo in _context.Gizmos
               from widget in gizmo.Widgets
               where widget.Id == myId
               select new { gizmo, widget };
    foreach ( var item in list )
      item.gizmo.Widgets.Remove(item.widget);
