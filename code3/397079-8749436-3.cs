	private static SubmitFileResult Submit(FileInfo file)
	{
		try
		{
			var submissionResult = ComplexSubmitFileMethod();
			return new SubmitFileResult { Result = submissionResult };
		}
		catch (Exception ex)
		{
			return new SubmitFileResult {Exception = ex, Result = "ERROR"};
		}
	}
