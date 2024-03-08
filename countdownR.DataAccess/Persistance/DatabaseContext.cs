using countdownR.Core.Common;
using countdownR.Core.Entities;
using countdownR.DataAccess.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace countdownR.DataAccess.Persistance;
public class DatabaseContext: IdentityDbContext<ApplicationUser>
{
    public DatabaseContext(DbContextOptions options): base(options)
    {
        
    }

    DbSet<Countdown> Countdowns { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }

    //public new async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new  CancellationToken())
    //{
    //    foreach(var entry in ChangeTracker.Entries<IAuditedEntity>())
    //    {
    //        switch(entry.State)
    //        {
    //            case EntityState.Added:
    //                entry.Entity.CreatedBy = 
    //        }
    //    }
    //}
}
