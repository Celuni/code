        Microsoft.Office.Interop.Word.Selection wordSelection = app.ActiveWindow.Selection;
        wordSelection.HomeKey(WdUnits.wdStory);
        Find fnd = wordSelection.Find;
        fnd.ClearFormatting();
        fnd.Replacement.ClearFormatting();
        fnd.Forward = true;
        fnd.Wrap = Microsoft.Office.Interop.Word.WdFindWrap.wdFindContinue;
        fnd.Text = "";
        fnd.Replacement.Text = "";
        fnd.set_Style("Instructions");
        fnd.Execute(Replace: WdReplace.wdReplaceAll);
