        [TestClass]
        public class UnitTest1
        {
            private TestContext testContextInstance;
            /// <summary>
            ///Gets or sets the test context which provides
            ///information about and functionality for the current test run.
            ///</summary>
            public TestContext TestContext
            {
                get
                {
                    return testContextInstance;
                }
                set
                {
                    testContextInstance = value;
                }
            }
    
            [TestMethod]
            public void TestMethod1()
            {
                TestContext.WriteLine("Message...");
            }
        }
