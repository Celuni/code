    public static class MockQueryableExtensions {
        /// <summary>
        /// Converts a generic <seealso cref="System.Collections.Generic.IEnumerable&lt;T&gt;"/>  to a <see cref="Moq.Mock"/> implementation of Quarable list 
        /// </summary>
        public static Mock<T> AsQuaryableMock<T, TItem>(this Mock<T> quaryableMock, IEnumerable<TItem> list)
            where T : class,IEnumerable<TItem> {
            var queryableList = list.AsQueryable();
            quaryableMock.As<IQueryable<TItem>>().Setup(x => x.Provider).Returns(queryableList.Provider);
            quaryableMock.As<IQueryable<TItem>>().Setup(x => x.Expression).Returns(queryableList.Expression);
            quaryableMock.As<IQueryable<TItem>>().Setup(x => x.ElementType).Returns(queryableList.ElementType);
            quaryableMock.As<IQueryable<TItem>>().Setup(x => x.GetEnumerator()).Returns(queryableList.GetEnumerator());
            return quaryableMock;
        }
    }
