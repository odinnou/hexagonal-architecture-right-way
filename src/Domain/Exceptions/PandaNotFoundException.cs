using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Domain.Exceptions
{
    [Serializable]
    public class PandaNotFoundException : Exception
    {
        public PandaNotFoundException(Guid pandaId) : base($"no panda found for id: {pandaId}") { }

        [ExcludeFromCodeCoverage]
        protected PandaNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
