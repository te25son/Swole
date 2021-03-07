using System.Collections.Generic;

namespace Swole.Mutations.Payloads
{
    public class PayloadBase<T> : Payload
        where T : class
    {
        protected PayloadBase(T entity)
        {
            Entity = entity;
        }

        protected PayloadBase(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }

        public T? Entity { get; }
    }
}
