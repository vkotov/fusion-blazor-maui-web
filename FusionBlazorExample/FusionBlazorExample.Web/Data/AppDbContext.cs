using ActualLab.Fusion.Authentication.Services;
using ActualLab.Fusion.EntityFramework.Operations;
using ActualLab.Fusion.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace FusionBlazorExample.Web.Data
{
    public class AppDbContext(DbContextOptions options) : DbContextBase(options)
    {
        //TODO: Add application data model

        // ActualLab.Fusion.EntityFramework tables
        public DbSet<DbUser<string>> Users { get; protected set; } = null!;
        public DbSet<DbUserIdentity<string>> UserIdentities { get; protected set; } = null!;
        public DbSet<DbSessionInfo<string>> Sessions { get; protected set; } = null!;

        // ActualLab.Fusion.EntityFramework.Operations tables
        public DbSet<DbOperation> Operations { get; protected set; } = null!;
        public DbSet<DbEvent> Events { get; protected set; } = null!;
    }
}
