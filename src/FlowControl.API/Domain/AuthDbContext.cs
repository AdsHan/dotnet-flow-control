using FlowControl.API.Domain.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace FlowControl.API.Domain;

public class AuthDbContext : IdentityDbContext<UserModel>
{

    public AuthDbContext()
    {

    }

    public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}

