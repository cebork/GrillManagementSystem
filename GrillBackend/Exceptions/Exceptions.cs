namespace GrillBackend.Exceptions
{

    [Serializable]
    public class GrillNotExistException : Exception
    {
        public GrillNotExistException() { }
        public GrillNotExistException(string message) : base(message) { }
        public GrillNotExistException(string message, Exception inner) : base(message, inner) { }
        protected GrillNotExistException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

    [Serializable]
    public class GrillMemeberNotExistException : Exception
    {
        public GrillMemeberNotExistException() { }
        public GrillMemeberNotExistException(string message) : base(message) { }
        public GrillMemeberNotExistException(string message, Exception inner) : base(message, inner) { }
        protected GrillMemeberNotExistException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }


    [Serializable]
    public class GrillMemberAlreadyExistsException : Exception
    {
        public GrillMemberAlreadyExistsException() { }
        public GrillMemberAlreadyExistsException(string message) : base(message) { }
        public GrillMemberAlreadyExistsException(string message, Exception inner) : base(message, inner) { }
        protected GrillMemberAlreadyExistsException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }


    [Serializable]
    public class NoFoodException : Exception
    {
        public NoFoodException() { }
        public NoFoodException(string message) : base(message) { }
        public NoFoodException(string message, Exception inner) : base(message, inner) { }
        protected NoFoodException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

    [Serializable]
    public class GrillOverflowException : Exception
    {
        public GrillOverflowException() { }
        public GrillOverflowException(string message) : base(message) { }
        public GrillOverflowException(string message, Exception inner) : base(message, inner) { }
        protected GrillOverflowException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }


    [Serializable]
    public class MealOrMemberNotSelectedException : Exception
    {
        public MealOrMemberNotSelectedException() { }
        public MealOrMemberNotSelectedException(string message) : base(message) { }
        public MealOrMemberNotSelectedException(string message, Exception inner) : base(message, inner) { }
        protected MealOrMemberNotSelectedException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }


    [Serializable]
    public class WrongInputsException : Exception
    {
        public WrongInputsException() { }
        public WrongInputsException(string message) : base(message) { }
        public WrongInputsException(string message, Exception inner) : base(message, inner) { }
        protected WrongInputsException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
