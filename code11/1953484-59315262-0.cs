csharp
public class FileEncoding
{
    const int DEFAULT_BUFFER_SIZE = 128 * 1024;
    /// <summary>
    /// Tries to detect the file encoding.
    /// </summary>
    /// <param name="inputStream">The input stream.</param>
    /// <param name="defaultIfNotDetected">The default encoding if none was detected.</param>
    /// <returns></returns>
    public static Encoding DetectFileEncoding(Stream inputStream, Encoding defaultIfNotDetected = null)
    {
        var det = new FileEncoding();
        det.Detect(inputStream);
        return det.Complete() ?? defaultIfNotDetected;
    }
    /// <summary>
    /// Tries to detect the file encoding.
    /// </summary>
    /// <param name="inputData">The input data.</param>
    /// <param name="start">The start.</param>
    /// <param name="count">The count.</param>
    /// <param name="defaultIfNotDetected">The default encoding if none was detected.</param>
    /// <returns></returns>
    public static Encoding DetectFileEncoding(byte[] inputData, int start, int count, Encoding defaultIfNotDetected = null)
    {
        var det = new FileEncoding();
        det.Detect(inputData, start, count);
        return det.Complete() ?? defaultIfNotDetected;
    }
    /// <summary>
    /// Detects if contains textual data.
    /// </summary>
    /// <param name="rawData">The raw data.</param>
    public static bool CheckForTextualData(byte[] rawData)
    {
        return CheckForTextualData(rawData, 0, rawData.Length);
    }
    /// <summary>
    /// Detects if contains textual data.
    /// </summary>
    /// <param name="rawData">The raw data.</param>
    /// <param name="start">The start.</param>
    /// <param name="count">The count.</param>
    public static bool CheckForTextualData(byte[] rawData, int start, int count)
    {
        if (rawData.Length < count || count < 4 || start + 1 >= count)
            return true;
        if (CheckForByteOrderMark(rawData, start))
        {
            return true;
        }
        int nullSequences = 0;
        int controlSequences = 0;
        for (var i = start + 1; i < count; i++)
        {
            if (rawData[i - 1] == 0 && rawData[i] == 0)
            {
                if (++nullSequences > 1)
                    break;
            }
            else if (rawData[i - 1] == 0 && rawData[i] < 10)
            {
                ++controlSequences;
            }
        }
        // is text if there is no null byte sequences or less than 10% of the buffer has control caracteres
        return nullSequences == 0 && (controlSequences <= (rawData.Length / 10));
    }
    /// <summary>
    /// Detects if data has bytes order mark to indicate its encoding for textual data.
    /// </summary>
    /// <param name="rawData">The raw data.</param>
    /// <param name="start">The start.</param>
    /// <returns></returns>
    private static bool CheckForByteOrderMark(byte[] rawData, int start = 0)
    {
        if (rawData.Length - start < 4)
            return false;
        if (rawData[start] == 0xef && rawData[start + 1] == 0xbb && rawData[start + 2] == 0xbf)
        {
            // Encoding.UTF8;
            return true;
        }
        else if (rawData[start] == 0xfe && rawData[start + 1] == 0xff)
        {
            // Encoding.Unicode;
            return true;
        }
        else if (rawData[start] == 0 && rawData[start + 1] == 0 && rawData[start + 2] == 0xfe && rawData[start + 3] == 0xff)
        {
            // Encoding.UTF32;
            return true;
        }
        else if (rawData[start] == 0x2b && rawData[start + 1] == 0x2f && rawData[start + 2] == 0x76)
        {
            // Encoding.UTF7;
            return true;
        }
        return false;
    }
    Ude.CharsetDetector ude = new Ude.CharsetDetector();
    bool _started = false;
    /// <summary>
    /// If the detection has reached a decision.
    /// </summary>
    /// <value>The done.</value>
    public bool Done { get; set; }
    /// <summary>
    /// Detected encoding name.
    /// </summary>
    public string EncodingName { get; set; }
    /// <summary>
    /// If the data contains textual data.
    /// </summary>
    public bool IsText { get; set; }
    /// <summary>
    /// If the file or data has any mark indicating encoding information (byte order mark).
    /// </summary>
    public bool HasByteOrderMark { get; set; }
    List<string> singleEncodings = new List<string>();
    /// <summary>
    /// Resets this instance.
    /// </summary>
    public void Reset()
    {
        _started = false;
        Done = false;
        HasByteOrderMark = false;
        singleEncodings.Clear();
        ude.Reset();
        EncodingName = null;
    }
    /// <summary>
    /// Detects the encoding of textual data of the specified input data.
    /// </summary>
    /// <param name="inputData">The input data.</param>
    /// <returns>Detected encoding name</returns>
    public string Detect(Stream inputData)
    {
        const int bufferSize = 16 * 1024;
        const int maxIterations = (20 * 1024 * 1024) / bufferSize;
        int i = 0;
        byte[] buffer = new byte[bufferSize];
        while (i++ < maxIterations)
        {
            int sz = inputData.Read(buffer, 0, (int)buffer.Length);
            if (sz <= 0)
            {
                break;
            }
            Detect(buffer, 0, sz);
            if (Done)
                break;
        }
        Complete();
        return EncodingName;
    }
    /// <summary>
    /// Detects the encoding of textual data of the specified input data.
    /// </summary>
    /// <param name="inputData">The input data.</param>
    /// <param name="start">The start.</param>
    /// <param name="count">The count.</param>
    /// <returns>Detected encoding name</returns>
    public string Detect(byte[] inputData, int start, int count)
    {
        if (Done)
            return EncodingName;
        if (!_started)
        {
            Reset();
            _started = true;
            if (!CheckForTextualData(inputData, start, count))
            {
                IsText = false;
                Done = true;
                return EncodingName;
            }
            HasByteOrderMark = CheckForByteOrderMark(inputData, start);
            IsText = true;
        }
        // execute charset detector                
        ude.Feed(inputData, start, count);
        ude.DataEnd();
        if (ude.IsDone() && !String.IsNullOrEmpty(ude.Charset))
        {
            Done = true;
            return EncodingName;
        }
        const int bufferSize = 4 * 1024;
        // singular buffer detection
        if (singleEncodings.Count < 2000)
        {
            var u = new Ude.CharsetDetector();
            int step = (count - start) < bufferSize ? (count - start) : bufferSize;
            for (var i = start; i < count; i += step)
            {
                u.Reset();
                if (i + step > count)
                    u.Feed(inputData, i, count - i);
                else
                    u.Feed(inputData, i, step);
                u.DataEnd();
                if (u.Confidence > 0.3 && !String.IsNullOrEmpty(u.Charset))
                    singleEncodings.Add(u.Charset);
            }
        }
        return EncodingName;
    }
    /// <summary>
    /// Finalize detection phase and gets detected encoding name.
    /// </summary>
    /// <returns></returns>
    public Encoding Complete()
    {
        Done = true;
        ude.DataEnd();
        if (ude.IsDone() && !String.IsNullOrEmpty(ude.Charset))
        {
            EncodingName = ude.Charset;
        }
        else if (singleEncodings.Count > 0)
        {
            // vote for best encoding
            EncodingName = singleEncodings.GroupBy(i => i)
                .OrderByDescending(i => i.Count() *
               (i.Key.StartsWith("UTF-32") ? 2 :
               i.Key.StartsWith("UTF-16") ? 1.8 :
               i.Key.StartsWith("UTF-8") ? 1.5 :
               i.Key.StartsWith("UTF-7") ? 1.3 :
               i.Key != ("ASCII") ? 1 : 0.2))
                .Select(i => i.Key).FirstOrDefault();
        }
        if (!String.IsNullOrEmpty(EncodingName))
            return Encoding.GetEncoding(EncodingName);
        return null;
    }
}
**Usage**
csharp
using (var _bookStream = await file.OpenStreamForReadAsync())
{
    var encoding = FileEncoding.DetectFileEncoding(_bookStream);
    _bookStream.Seek(0, SeekOrigin.Begin);
    var _bookReader = new StreamReader(_bookStream, encoding);
    var _bookContent = await _bookReader.ReadToEndAsync();
}
**Tips**
You may need to add extended character set support, add this in the constructor of `App.xaml.cs`
csharp
Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
Best regards.
