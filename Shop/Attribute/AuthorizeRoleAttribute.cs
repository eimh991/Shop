using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Shop.Enum;

namespace Shop.Attribute
{
    public class AuthorizeRoleAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private readonly UserRole _role;

        public AuthorizeRoleAttribute(UserRole role)
        {
            _role = role;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;

            if (!user.Identity.IsAuthenticated)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            var roleClaim = user.FindFirst("UserRole")?.Value;

            if (UserRole.TryParse<UserRole>(roleClaim, out var userRole) && userRole == _role)
            {
                return;
            }

            context.Result = new ForbidResult(); 
        }
    }
}
