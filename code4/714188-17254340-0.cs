    void Main()
    {
      XmlDocument v = new XmlDocument();
      v.LoadXml(@"<server>
    <Version date=""06/05/2013"">2.5.4</Version>
    <Lastfix path=""\"">Now reading basic config files! Read the README file!</Lastfix>
    <Version date=""07/05/2013"">2.5.3</Version>
    <Lastfix path=""\wServer\ClientProcessor.cs"">Fixed character creation bugs (related to mysql, download and import the new struct.sql file under db!)</Lastfix>
    <Version date=""06/05/2013"">2.5.0</Version>
    <Lastfix path=""\"">BIG stability fix, register fix, buy gold fix</Lastfix>
    <Version date=""02/05/2013"">2.4.1</Version>
    <Lastfix path=""\wServer\realm\entities\player\Player.UseItem.cs"">Almost finished dungeon keys!</Lastfix>
    <Version date=""30/04/2013"">2.3.1</Version>
    <Lastfix path=""\wServer\realm\entities\player\Player.UseItem.cs"">Dungeon keys now working!</Lastfix>
    <Version date=""30/04/2013"">2.3.0</Version>
    <Lastfix path=""\wServer\realm\entities\player\Player.Chat.cs"">Added /who, /tell, /server commands!</Lastfix>
    </server>");
      
      var result = v.SelectSingleNode("server").ChildNodes.OfType<XmlNode>().Aggregate(
         new List<item>(),
         (list, node) => {
          if (node.Name == "Version")
          {
            list.Add(new item { version = node.Attributes["date"].Value, lastfix = "" });
            return list;
          }
          else
          {
            list.Last().lastfix = node.InnerText;
            return list;
          }
        });
         
      result.Dump();
    }
    
    public class item {
      public string version { get; set; }
      public string lastfix { get; set; }
    }
    
