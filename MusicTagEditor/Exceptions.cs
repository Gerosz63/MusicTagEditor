using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTagEditor
{

    [Serializable]
    public class EmptyListException : Exception
    {
        public EmptyListException() { }
        public EmptyListException(string message) : base(message) { }
        public EmptyListException(string message, Exception inner) : base(message, inner) { }
        protected EmptyListException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

    [Serializable]
    public class ElementNotincludedException : Exception
    {
        public ElementNotincludedException() { }
        public ElementNotincludedException(string message) : base(message) { }
        public ElementNotincludedException(string message, Exception inner) : base(message, inner) { }
        protected ElementNotincludedException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }


    [Serializable]
    public class SimilarValueException : Exception
    {
        public SimilarValueException() { }
        public SimilarValueException(string message) : base(message) { }
        public SimilarValueException(string message, Exception inner) : base(message, inner) { }
        protected SimilarValueException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

    [Serializable]
    public class SameValueException : Exception
    {
        public SameValueException() { }
        public SameValueException(string message) : base(message) { }
        public SameValueException(string message, Exception inner) : base(message, inner) { }
        protected SameValueException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
