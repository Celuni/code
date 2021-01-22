    string aliSpReqs = String.Empty;
    foreach (var item in dc.TaskRelations.Where(tableRaletions => 
                      tableRaletions.TaskId == taskID 
                      && tableRaletions.RelTypeId == 13))
    {
        aliSpReqs += item.RefAliSpReq.shortdesc + "; ";
    }
    return aliSpReqs.Substring(0, aliSpReqs.Length - 2);
