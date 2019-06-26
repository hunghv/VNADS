using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace VNADS.Models
{
    public class ApplicationUser : IdentityBuilder
    {
        public ApplicationUser(Type user, IServiceCollection services) : base(user, services)
        {
        }

        public ApplicationUser(Type user, Type role, IServiceCollection services) : base(user, role, services)
        {
        }
    }
}
