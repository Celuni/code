    // this interface is public, and it allows everyone to read the Id
    public interface IMetadataColumns
    {
        int Id { get; }
    }
    
    // this one is writeable, but it's internal
    internal interface IMetadataColumnsWritable : IMetadataColumns
    {
        // we need to use 'new' here, but this doesn't mean
        // you will end up with two getters
        new int Id { get; set; }
    }
    
    // internal implementation is writeable, but you can pass it 
    // to other assemblies through the readonly IMetadataColumns 
    // interface
    internal class MetadataColumns : IMetadataColumnsWritable
    {
        public int Id { get; set; }
    }
