namespace MultiTenancy.Interfaces;

public interface IUserContext
{
    Guid GetTenantId();
}
