using System;
using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        
        public DbSet<Value> Values { get; set; }
        public DbSet<Activity> Activities { get; set; }

        public DbSet<ToDo> Todos { get; set; }
        public DbSet<PageTag> PageTags { get; set; }
		public DbSet<SitePage> SitePages { get; set; }
		public DbSet<PageCategory> PageCategorys { get; set; }
		//##ModelDbSet##

        protected override void OnModelCreating(ModelBuilder builder)
        {            
              base.OnModelCreating(builder);     

            //   builder
            //     .Entity<PageTagSitePage>()
            //         .HasKey( sp => new {  sp.PageTagId, sp.SitePageId } );

            //     builder.Entity<PageTagSitePage>()
            //         .HasOne( tg => tg.PageTag)
            //         .WithMany( tg => tg.SitePages)
            //         .HasForeignKey(tg => tg.PageTagId);

            //     builder.Entity<PageTagSitePage>()
            //         .HasOne( sp => sp.SitePage)
            //         .WithMany( sp => sp.PageTag)
            //         .HasForeignKey(sp => sp.SitePageId);     
            
                                             
        }
    }
}



