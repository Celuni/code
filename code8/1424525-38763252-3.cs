        public abstract class Result { }
        public class ResultA : Result { }
        public class ResultB : Result { }
        public abstract class King
        {
            public abstract Result Function ();
        }
        public class KingA : King
        {
            public override Result Function () => new ResultA ();
        }
        public class KingB : King
        {
            public override Result Function () => new ResultB ();
        }
