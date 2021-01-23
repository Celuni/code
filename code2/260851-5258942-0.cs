    public class CustomerMap : IAutoMappingOverride<Customer>
    {
        public void Override(AutoMapping<Customer> mapping) {
            mapping.Not.LazyLoad();
            mapping.Id(x => x.Id, "CustomerID")
                .GeneratedBy.Assigned();
            mapping.HasMany(hm => hm.Orders).KeyColumn("CustomerID");
        }
    }
