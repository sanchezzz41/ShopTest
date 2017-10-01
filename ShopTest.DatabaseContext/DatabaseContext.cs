using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShopTest.Domain.Entities;

namespace ShopTest.Database
{
    /// <summary>
    /// Контекст базы данных
    /// </summary>
    public class DatabaseContext : IdentityDbContext<User,IdentityRole,string>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> opt) : base(opt)
        {
         
        }

        #region Список таблиц

        /// <summary>
        /// Список заказов
        /// </summary>
        public DbSet<Order> Orders { get; set; }

        /// <summary>
        /// Список продуктов
        /// </summary>
        public DbSet<Product> Products { get; set; }

        /// <summary>
        ///  Список складов
        /// </summary>
        public DbSet<Storage> Storages { get; set; }

        ///// <summary>
        ///// Список ролей
        ///// </summary>
        //public DbSet<Role> Roles { get; set; }

        /// <summary>
        /// Список заказов-продуктов
        /// </summary>
        public DbSet<OrderProduct> OrderProducts { get; set; }

        /// <summary>
        /// Список продуктов-складов
        /// </summary>
        public DbSet<ProductStorage> ProductStorages { get; set; }

        #endregion


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderProduct>().HasKey(x => new {x.IdOrder, x.IdProduct});
            modelBuilder.Entity<ProductStorage>().HasKey(x => new {x.IdProduct, x.IdStorage});
            base.OnModelCreating(modelBuilder);

        }
    }
}
