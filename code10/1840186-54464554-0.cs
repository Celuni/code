    private asyc void OpenForm(object sender, ItemClickEventArgs e) {
        var testForm = new MyForm();
        ...
        testForm.Enabled = true;
    
        var source = new TaskCompletionSource<DialogResult>();
    
        EventHandler handler = null;
        handler = (s, args) => {
            testForm.FormClosed -= handler;
            var  form = (MyForm)s;
            source.SetResult(form.DialogResult);
        }
        testForm.FormClosed += handler;
        testForm.Show();
        var dialogOk = await source.Task;
        if(dialogOk) {
           //do some stuff 1
        }
    }
