    public class ViewModel : INotifyPropertyChanged
    {
      public ViewModel()
      {
        this.DataTable = new DataTable();
      }
    
      private void InitGridFromXML(string xmlPath)
      {
        var xmlEntities = XElement.Load(xmlPath).Elements().ToList();
        this.DataTable.Columns.AddRange(
          xmlEntities
            .FirstOrDefault()?
            .Elements()
            .Select(node => new DataColumn(node.Name.LocalName))
            .ToArray());
        foreach (XElement xElement in xmlEntities)
        {
          this.DataTable.Rows.Add(
            xElement.Elements()
              .Select(node => node.Value)
              .ToArray());
        }
      }
      private DataTable dataTable;  
      public DataTable DataTable
      {
        get => this.dataTable;
        set
        {
          this.dataTable = value; 
          OnPropertyChanged();
        }
      }
      public event PropertyChangedEventHandler PropertyChanged;
      protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
      {
        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
      }
    }
