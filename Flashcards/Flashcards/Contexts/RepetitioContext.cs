using flashcards.Models.Db;
using flashcards.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace flashcards.Contexts
{
    public class RepetitioContext : IdentityDbContext<User, Role, string>
    {
        public RepetitioContext(DbContextOptions<RepetitioContext> options)
        : base(options) { }

        public DbSet<ClaimDb> Claims { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity => entity.Property(e => e.DisplayName).HasColumnName("DisplayName"));

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(bc => new { bc.UserId, bc.RoleId });
                entity.HasOne(e => e.User).WithMany(e => e.UsersRoles).HasForeignKey(e => e.UserId);
                entity.HasOne(e => e.Role).WithMany(e => e.UsersRoles).HasForeignKey(e => e.RoleId);
            });
        }

    }
}
