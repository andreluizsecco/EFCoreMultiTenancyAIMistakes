using System.Linq.Expressions;
using EFCoreMultiTenancy.Models;
using EFCoreMultiTenancy.Services;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMultiTenancy.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options, ITenantService tenantService) : DbContext(options)
{
    public DbSet<Product> Products => Set<Product>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            var tenantIdProp = entityType.ClrType.GetProperty("TenantId");
            if (tenantIdProp is null || tenantIdProp.PropertyType != typeof(string))
                continue;

            var parameter = Expression.Parameter(entityType.ClrType, "e");
            var property = Expression.Property(parameter, tenantIdProp);
            var getTenantId = Expression.Call(
                Expression.Constant(tenantService),
                typeof(ITenantService).GetMethod(nameof(ITenantService.GetTenantId))!);
            var body = Expression.Equal(property, getTenantId);
            var lambda = Expression.Lambda(body, parameter);

            modelBuilder.Entity(entityType.ClrType).HasQueryFilter(lambda);
        }
    }
}
