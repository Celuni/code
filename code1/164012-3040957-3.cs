var baseQuery = ctx.WorkOrder.Where(w =&gt; w.WorkDate &gt;= StartDt && w.WorkDate &lt;= EndDt);
IEnumerable&lt;WorkOrder&gt; query1;
if (showApprovedOnly)
{
  query1 = baseQuery.Where(w =&gt; w.IsApproved);
}
//more filters on query1
...
IEnumerable&lt;WorkOrder&gt; query2;
if (/*something*/)
  query2 = baseQuery.Where(w =&gt; w.SomeThing);
