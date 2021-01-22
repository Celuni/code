            string parseOne = "1";
            int? resultOne;
            bool successOne = parseOne.TryParseStruct<int>(out resultOne);
            Assert.IsTrue(successOne);
            Assert.AreEqual(1, resultOne);
            string parseEmpty = string.Empty;
            int? resultEmpty;
            bool successEmpty = parseEmpty.TryParseStruct<int>(out resultEmpty);
            Assert.IsTrue(successEmpty);
            Assert.IsFalse(resultEmpty.HasValue);
            string parseNull = null;
            int? resultNull;
            bool successNull = parseNull.TryParseStruct<int>(out resultNull);
            Assert.IsTrue(successNull);
            Assert.IsFalse(resultNull.HasValue);
            string parseInvalid = "FooBar";
            int? resultInvalid;
            bool successInvalid = parseInvalid.TryParseStruct<int>(out resultInvalid);
            Assert.IsFalse(successInvalid);
