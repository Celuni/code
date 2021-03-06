        [TestMethod]
        public void TestUnityConfiguration()
        {
            var container = new UnityContainer();
            //This part is copied from your Unity configuration.
            container.RegisterType(typeof(IDataExtractionService<>), typeof(DataExtractionService<>));
            container.RegisterType(typeof(IDataExtractor<DataSet>), typeof(DataSetExtractor));
            var x = container.Resolve<IDataExtractionService<string>>();
            Assert.IsInstanceOfType(x, typeof(DataExtractionService<string>));
            var y = container.Resolve<IDataExtractor<DataSet>>();
            Assert.IsInstanceOfType(y, typeof(DataSetExtractor));
        }
