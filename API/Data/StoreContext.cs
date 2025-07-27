using System;
using API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class StoreContext(DbContextOptions options) : IdentityDbContext<User>(options)
{
    public required DbSet<Product> Products { get; set; }
    public required DbSet<Basket> Baskets { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<IdentityRole>()
           .HasData(
            new IdentityRole { Id = "99fef3c2-3c12-4696-9e7f-b93e5c27a0e4", Name = "Member", NormalizedName = "MEMBER" },
            new IdentityRole { Id = "26572ddd-b858-4a7a-a862-9de6256e6cb7", Name = "Admin", NormalizedName = "ADMIN" }
        );
    }
}
