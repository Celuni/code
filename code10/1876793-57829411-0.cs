C#
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using System;
using System.Collections.Generic;
public abstract class ValueEnumerableSerializerBase<TValue, TItem> : SerializerBase<TValue>, IBsonArraySerializer, IBsonSerializer
    where TValue : struct, IEnumerable<TItem>
{
    private readonly Lazy<IBsonSerializer<TItem>> _lazyItemSerializer;
    protected ValueEnumerableSerializerBase()
        : this(BsonSerializer.SerializerRegistry)
    {
    }
    protected ValueEnumerableSerializerBase(IBsonSerializer<TItem> itemSerializer)
    {
        if (itemSerializer == null)
            throw new ArgumentNullException(nameof(itemSerializer));
        _lazyItemSerializer = new Lazy<IBsonSerializer<TItem>>(() => itemSerializer);
    }
    protected ValueEnumerableSerializerBase(IBsonSerializerRegistry serializerRegistry)
    {
        if (serializerRegistry == null)
            throw new ArgumentNullException(nameof(serializerRegistry));
        _lazyItemSerializer = new Lazy<IBsonSerializer<TItem>>(() => serializerRegistry.GetSerializer<TItem>());
    }
    public IBsonSerializer<TItem> ItemSerializer => _lazyItemSerializer.Value;
    public override TValue Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
    {
        if (context == null)
            throw new ArgumentNullException(nameof(context));
        IBsonReader reader = context.Reader;
        BsonType currentBsonType = reader.GetCurrentBsonType();
        switch (currentBsonType)
        {
            case BsonType.Null:
            {
                reader.ReadNull();
                return default;
            }
            case BsonType.Array:
            {
                reader.ReadStartArray();
                object accumulator = CreateAccumulator();
                while (reader.ReadBsonType() != BsonType.EndOfDocument)
                {
                    TItem item = _lazyItemSerializer.Value.Deserialize(context);
                    AddItem(accumulator, item);
                }
                reader.ReadEndArray();
                return FinalizeResult(accumulator);
            }
            default:
            {
                throw CreateCannotDeserializeFromBsonTypeException(currentBsonType);
            }
        }
    }
    public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, TValue value)
    {
        if (context == null)
            throw new ArgumentNullException(nameof(context));
        IBsonWriter writer = context.Writer;
        if (value.Equals(default))
        {
            writer.WriteNull();
        }
        else
        {
            writer.WriteStartArray();
            foreach (TItem item in EnumerateItemsInSerializationOrder(value))
                _lazyItemSerializer.Value.Serialize(context, item);
            writer.WriteEndArray();
        }
    }
    public bool TryGetItemSerializationInfo(out BsonSerializationInfo serializationInfo)
    {
        IBsonSerializer<TItem> itemSerializer = _lazyItemSerializer.Value;
        serializationInfo = new BsonSerializationInfo(null, itemSerializer, itemSerializer.ValueType);
        return true;
    }
    protected abstract void AddItem(object accumulator, TItem item);
    protected abstract object CreateAccumulator();
    protected abstract IEnumerable<TItem> EnumerateItemsInSerializationOrder(TValue value);
    protected abstract TValue FinalizeResult(object accumulator);
}
From there, the implementation for `ImmutableArray<T>` is pretty straight-forward:
C#
using MongoDB.Bson.Serialization;
using System.Collections.Generic;
using System.Collections.Immutable;
public class ImmutableArraySerializer<T> : ValueEnumerableSerializerBase<ImmutableArray<T>, T>, IChildSerializerConfigurable
{
    public ImmutableArraySerializer()
    {
    }
    public ImmutableArraySerializer(IBsonSerializer<T> itemSerializer)
        : base(itemSerializer)
    {
    }
    public ImmutableArraySerializer(IBsonSerializerRegistry serializerRegistry)
        : base(serializerRegistry)
    {
    }
    public IBsonSerializer WithItemSerializer(IBsonSerializer<T> itemSerializer)
    {
        return new ImmutableArraySerializer<T>(itemSerializer);
    }
    protected override void AddItem(object accumulator, T item)
    {
        ((ImmutableArray<T>.Builder)accumulator).Add(item);
    }
    protected override object CreateAccumulator()
    {
        return ImmutableArray.CreateBuilder<T>();
    }
    protected override IEnumerable<T> EnumerateItemsInSerializationOrder(ImmutableArray<T> value)
    {
        return value;
    }
    protected override ImmutableArray<T> FinalizeResult(object accumulator)
    {
        return ((ImmutableArray<T>.Builder)accumulator).ToImmutable();
    }
    IBsonSerializer IChildSerializerConfigurable.ChildSerializer => ItemSerializer;
    IBsonSerializer IChildSerializerConfigurable.WithChildSerializer(IBsonSerializer childSerializer)
    {
        return new ImmutableArraySerializer<T>((IBsonSerializer<T>)childSerializer);
    }
}
