namespace MultiTenancy.Interfaces;

public interface ITenantOwner
{
    Guid TenantId { get; set; }
}
