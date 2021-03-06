	private async Task SendTestEmail(CancellationToken token)
	{
		// Prepare message, client, and form with cancel button
		using (Message message = ...)
		{
			SmtpClient client = ...
			CancelSendForm form = ...
			// Try to send the mail
			var ctsDialog = CancellationTokenSource.CreateLinkedTokenSource(token);
			var ctsSend = CancellationTokenSource.CreateLinkedTokenSource(token);
			var dialogTask = form.ShowDialogAsync(ctsDialog);
			var emailTask = client.SendMailExAsync(message, ctsSend);
			var task = await Task.WhenAny(dialogTask, emailTask);
			if (task == emailTask)
			{
				ctsDialog.Cancel();
			}
			else
			{
				ctsSend.Cancel();
			}
			await Task.WhenAll(dialogTask, emailTask);
		}   
	}
	public static class SmtpClientEx
	{
		public static async Task SendMailExAsync(
            SmtpClient @this, MailMessage message, 
            CancellationToken token = default(CancellationToken))
		{
			using (token.Register(() => 
                @this.SendAsyncCancel(), useSynchronizationContext: false))
			{
				await @this.SendMailAsync(message);
			}
		}
	}
