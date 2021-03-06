    oWord.Selection.HeaderFooter.Shapes.AddTextEffect(
        Microsoft.Office.Core.MsoPresetTextEffect.msoTextEffect1,
        "Leseexemplar",
        "Calibri",
        1F,
        Office.MsoTriState.msoFalse,
        Office.MsoTriState.msoFalse, 0, 0).Select();
    Word.ShapeRange oShapeRange =
        oWord.Selection.ShapeRange;
    oShapeRange.Name = cLeseexemplar + oSection.Index;
	oShapeRange.Rotation = 315;
	oShapeRange.LockAspectRatio = Office.MsoTriState.msoTrue;
	oShapeRange.Height = oWord.CentimetersToPoints(4.51F);
	oShapeRange.Width = oWord.CentimetersToPoints(18.05F);
	oShapeRange.WrapFormat.AllowOverlap = -1;
	oShapeRange.WrapFormat.Side = Word.WdWrapSideType.wdWrapBoth;
	oShapeRange.WrapFormat.Type = Word.WdWrapType.wdWrapNone;
	oShapeRange.RelativeHorizontalPosition = Word.WdRelativeHorizontalPosition.wdRelativeHorizontalPositionMargin;
	oShapeRange.RelativeVerticalPosition = Word.WdRelativeVerticalPosition.wdRelativeVerticalPositionMargin;
	oShapeRange.Left = (float)Word.WdShapePosition.wdShapeCenter;
	oShapeRange.Top = (float)Word.WdShapePosition.wdShapeCenter;
	oShapeRange.TextEffect.NormalizedHeight = Office.MsoTriState.msoFalse;
	oShapeRange.Line.Visible = Office.MsoTriState.msoFalse;
	oShapeRange.Fill.Visible = Office.MsoTriState.msoTrue;
	oShapeRange.Fill.Solid();
	oShapeRange.Fill.ForeColor.RGB = (Int32)Word.WdColor.wdColorGray375;
	oShapeRange.Fill.Transparency = 0.5F;
	oWord.ActiveWindow.ActivePane.View.SeekView = Word.WdSeekView.wdSeekMainDocument;
