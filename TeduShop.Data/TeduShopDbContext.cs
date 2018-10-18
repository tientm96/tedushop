using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShop.Model.Models;

namespace TeduShop.Data
{
    public class TeduShopDbContext : DbContext
    {
        //constructor dùng từ khóa base để gọi đến constructor của lớp cha. trong DbContext có constructor là "public DbContext(string nameOrConnectionString)"
        // "TeduShopConnection" là keyname của connectionString trong file App.config và web.config
        public TeduShopDbContext() : base("TeduShopConnection")
        {
            //LazyLoading: khi ta load table cha thì nó không tự động include thêm table con.
            this.Configuration.LazyLoadingEnabled = false;
        }

        //Khai báo các tables đã tạo trong Models, thông qua đây sẽ general xuống database.
        //Tên bảng dưới bd sẽ là Footers, Menus tương ứng với model Footer, Menu trong EF.
        public DbSet<Footer> Footers { set; get; }
        public DbSet<Menu> Menus { set; get; }
        public DbSet<MenuGroup> MenuGroups { set; get; }
        public DbSet<Order> Orders { set; get; }
        public DbSet<OrderDetail> OrderDetails { set; get; }
        public DbSet<Page> Pages { set; get; }
        public DbSet<Post> Posts { set; get; }
        public DbSet<PostCategory> PostCategories { set; get; }
        public DbSet<PostTag> PostTags { set; get; }
        public DbSet<Product> Products { set; get; }

        public DbSet<ProductCategory> ProductCategories { set; get; }
        public DbSet<ProductTag> ProductTags { set; get; }
        public DbSet<Slide> Slides { set; get; }
        public DbSet<SupportOnline> SupportOnlines { set; get; }
        public DbSet<SystemConfig> SystemConfigs { set; get; }

        public DbSet<Tag> Tags { set; get; }

        public DbSet<VisitorStatistic> VisitorStatistics { set; get; }
        public DbSet<Error> Errors { set; get; }


        //override method of DbContext: method này sẽ chạy khi ta khởi tạo EF.
        protected override void OnModelCreating(DbModelBuilder builder)
        {
        }
    }
}
