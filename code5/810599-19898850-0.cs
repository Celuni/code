    using System;
    using System.Xml;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text;
    public static class XmlUtils {
    public static IEnumerable<String> GetOnlyTextValues(XmlNode node) {
        var values = node.ChildNodes.Cast<XmlNode>().Aggregate(
            new List<String>(),
            (xs, x) => { if (x.NodeType == XmlNodeType.Text) { xs.Add(x.Value); } return xs; }
        );
        return values;
    }
    public static String GetOnlyTextValuesJoined(XmlNode node) {
        var values = GetOnlyTextValues(node);
        var text = String.Join(",", values.ToArray());
        return text;
    }
    }
