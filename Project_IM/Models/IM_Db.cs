using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Project_IM.Models
{
    public partial class IM_Db : DbContext
    {
        public IM_Db()
            : base("name=IM_Db")
        {
        }

        public virtual DbSet<Place_name> Place_name { get; set; }
        public virtual DbSet<Video> Video { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Place_name>()
                .Property(e => e.地點名稱)
                .IsUnicode(false);

            modelBuilder.Entity<Place_name>()
                .HasMany(e => e.Video)
                .WithRequired(e => e.Place_name)
                .HasForeignKey(e => e.結束地點)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Place_name>()
                .HasMany(e => e.Video1)
                .WithRequired(e => e.Place_name1)
                .HasForeignKey(e => e.開始地點)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Video>()
                .Property(e => e.影片網址)
                .IsUnicode(false);

            modelBuilder.Entity<Video>()
                .Property(e => e.路徑地圖)
                .IsUnicode(false);
        }
    }
}
