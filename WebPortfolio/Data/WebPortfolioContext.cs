using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebPortfolio.Models;

namespace WebPortfolio.Data
{
    public class WebPortfolioContext : IdentityDbContext<IdentityUser>
    {
        public WebPortfolioContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<WebPortfolio.Models.Contacts> Contacts { get; set; }

        public DbSet<WebPortfolio.Models.Feedback> Feedback { get; set; }

    }
}
