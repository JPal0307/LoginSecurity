using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Models
{
    public class SecurityContext : DbContext
    {
        public SecurityContext(DbContextOptions<SecurityContext> options) : base(options)
        {
        }
        public DbSet<SecurityModel> Contacts { get; set; }
        public DbSet<MovieModel> Movies { get; set; }
    }

}
