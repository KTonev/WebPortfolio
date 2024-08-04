using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebPortfolio.Models;

namespace WebPortfolio.Data
{
    public class WebPortfolioContext : DbContext
    {
       
        public DbSet<WebPortfolio.Models.Contacts> Contacts { get; set; }

        public DbSet<WebPortfolio.Models.Feedback> Feedback { get; set; }

        public WebPortfolioContext(DbContextOptions options) : base(options) 
        { 

        }
    }
}
