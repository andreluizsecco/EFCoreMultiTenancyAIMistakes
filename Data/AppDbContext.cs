using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MultiTenancy.Interfaces;
using MultiTenancy.Models;

namespace MultiTenancy.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options, IUserContext userContext) : DbContext(options)
{
    public DbSet<Product> Products => Set<Product>();

    // EF Core replaces the captured DbContext constant with the current instance at query time,
    // so this property is re-evaluated per query against the actual executing context instance.
    public Guid CurrentTenantId => userContext.GetTenantId();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (!typeof(ITenantOwner).IsAssignableFrom(entityType.ClrType))
                continue;

            var parameter = Expression.Parameter(entityType.ClrType, "e");
            var entityTenantId = Expression.Property(parameter, nameof(ITenantOwner.TenantId));

            var contextConstant = Expression.Constant(this);
            var contextTenantId = Expression.Property(contextConstant, nameof(CurrentTenantId));

            var filter = Expression.Lambda(Expression.Equal(entityTenantId, contextTenantId), parameter);
            modelBuilder.Entity(entityType.ClrType).HasQueryFilter(filter);
        }
    }
}
