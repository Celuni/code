class Options {
  [Option(SetName = "web")]
  public string WebUrl { get; set; }
  [Option(SetName = "web")]
  public int MaxLinks { get; set; }
  [Option(SetName = "ftp")]
  public string FtpUrl { get; set; }
  [Option(SetName = "ftp")]
  public int MaxFiles { get; set; }
  [Option]
  public bool Verbose { get; set; }
}
