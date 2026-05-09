using MultiTenancy.Interfaces;

namespace MultiTenancy.Services;

public class UserContext(IHttpContextAccessor httpContextAccessor) : IUserContext
{
    public Guid GetTenantId()
    {
        var claim = httpContextAccessor.HttpContext?.User.FindFirst("tenantId");
        return claim is not null && Guid.TryParse(claim.Value, out var tenantId)
            ? tenantId
            : Guid.Empty;
    }
}
