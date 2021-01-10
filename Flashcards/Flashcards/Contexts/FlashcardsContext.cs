using flashcards.Models.Db;
using flashcards.Models.Identity;
using Flashcards.Models.Db;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace flashcards.Contexts
{
    public class FlashcardsContext : IdentityDbContext<User, Role, Guid, IdentityUserClaim<Guid>, UserRole, IdentityUserLogin<Guid>, IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>
    {
        public FlashcardsContext(DbContextOptions<FlashcardsContext> options)
        : base(options) { }

        public DbSet<ClaimDb> Claims { get; set; }
        public DbSet<Flashcard> Flashcards { get; set; }
        public DbSet<Answer> Answers { get; set; }

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

            modelBuilder.Entity<Flashcard>(entity => entity.ToTable("Flashcards"));

            modelBuilder.Entity<Answer>(entity => entity.ToTable("Answers"));
        }

    }
}
