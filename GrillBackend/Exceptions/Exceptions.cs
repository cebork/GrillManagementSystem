using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}
