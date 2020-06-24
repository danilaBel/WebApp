using Domain.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Infrastructure_
{
    public class ApplicationRoleManager : RoleManager<IdentityRole>
    {
        private readonly CancellationToken _cancel;
        public ApplicationRoleManager(IRoleStore<IdentityRole> store,
            IEnumerable<IRoleValidator<IdentityRole>> roleValidators,
            ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors,
            ILogger<RoleManager<IdentityRole>> logger,
            IHttpContextAccessor contextAccessor)
            : base(store, roleValidators, keyNormalizer, errors, logger)
        {
            _cancel = contextAccessor?.HttpContext?.RequestAborted ?? CancellationToken.None;
        }

        protected override CancellationToken CancellationToken => _cancel;
    }
}
