	public void Recognize(Bitmap bitmap)
	{
		bitmap.Save("temp.png", ImageFormat.Png);
		var startInfo = new ProcessStartInfo("tesseract.exe", "temp.png temp hocr");
		startInfo.WindowStyle = ProcessWindowStyle.Hidden;
		var process = Process.Start(startInfo);
		process.WaitForExit();
		GetWords(File.ReadAllText("temp.html"));
		
		// Futher actions with words
	}
	public Dictionary<Rectangle, string> GetWords(string tesseractHtml)
	{
		var xml = XDocument.Parse(tesseractHtml);
		var rectsWords = new Dictionary<System.Drawing.Rectangle, string>();
		var ocr_words = xml.Descendants("span").Where(element => element.Attribute("class").Value == "ocr_word").ToList();
		foreach (var ocr_word in ocr_words)
		{
			var strs = ocr_word.Attribute("title").Value.Split(' ');
			int left = int.Parse(strs[1]);
			int top = int.Parse(strs[2]);
			int width = int.Parse(strs[3]) - left + 1;
			int height = int.Parse(strs[4]) - top + 1;
			rectsWords.Add(new Rectangle(left, top, width, height), ocr_word.Value);
		}
		return rectsWords;
	}
