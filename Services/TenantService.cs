using System.Security.Claims;

namespace EFCoreMultiTenancy.Services;

public class TenantService(IHttpContextAccessor httpContextAccessor) : ITenantService
{
    public string GetTenantId()
    {
        return httpContextAccessor.HttpContext?.User?.FindFirstValue("tenantId") ?? string.Empty;
    }
}
