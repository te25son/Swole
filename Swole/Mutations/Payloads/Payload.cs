using System.Collections.Generic;

namespace Swole.Mutations.Payloads
{
    public abstract class Payload
    {
        protected Payload(IReadOnlyList<UserError>? errors) => Errors = errors;

        public IReadOnlyList<UserError>? Errors { get; }
    }
}
