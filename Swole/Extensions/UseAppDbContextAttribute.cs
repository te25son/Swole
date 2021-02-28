using HotChocolate.Types;
using HotChocolate.Types.Descriptors;
using Swole.Data;
using System.Reflection;

namespace Swole.Extensions
{
    public class UseAppDbContextAttribute : ObjectFieldDescriptorAttribute
    {
        public override void OnConfigure(IDescriptorContext context, IObjectFieldDescriptor descriptor, MemberInfo member)
        {
            descriptor.UseDbContext<AppDbContext>();
        }
    }
}
