using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CraftAtHome.Models
{
    public class ArticleContext: DbContext
    {
       // public ArticleContext(DbContextOptions<ArticleContext> options) : base(options) { }


        protected override void OnConfiguring(DbContextOptionsBuilder options) {

            options.UseNpgsql("User ID = tomodengenzlrm; Password = b3fd9a98ca18e0f621cdc758174b47c4019db09218861ab0b70e533663cc5618; Server = ec2-54-166-167-192.compute-1.amazonaws.com; Port = 5432; Database = d3laqvdldg1r5s; Pooling = true; sslmode = Require; Trust Server Certificate = true");
        }



        public DbSet<Usuario> Usuario { get; set; }
       

    }
}
