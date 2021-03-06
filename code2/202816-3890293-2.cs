    [XmlRoot(ElementName="response")]
    public class Response()
    {
      [XmlElement(ElementName="result")]
      private string ResultInternal { get; set; }
      [XmlIgnore()]
      public bool Result{
        get{
          return this.ResultInternal == "Success";
        }
        set{
          this.ResultInternal = value ? "Success" : "Failed";
        }
      }
    }
