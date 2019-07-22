using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ORM框架之EntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            Product product1;
            using(EntityContext db = new EntityContext())
            {
                //var product = new Product() { Name = "电磁炉1", Description = "电器" };
                //db.Set<Product>().Add(product);//添加元素

                //product1 = db.Set<Product>().Find(1);//根据主键查找
                //db.Set<Product>().Remove(product1);//删除元素
                
                int count = db.Set<Product>().Count();
                db.SaveChanges();
            }

            Console.ReadKey();
        }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class EntityContext : DbContext
    {
        public EntityContext()
            : base("name=DBConnectionString")
        {

        }

        public DbSet<Product> Product { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //不使用modelBuilder.Configurations.AddFromAssembly方法则需要逐个添加,如果数量多的话比较麻烦
            //modelBuilder.Configurations.Add(new OneToMany.Map.ProductMap());
            //此方法可以将当前程序集下所有继承了ComplexTypeConfiguration、EntityTypeConfiguration类型的类添加到注册器
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }

    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            ToTable("Product"); //指定表明
            HasKey(p => p.Id);  //指定主键
            //指定Name字段在数据库中列名为DBName、长度500、非空,其他的话可以自己试下
            Property(p => p.Name).HasColumnName("DBName").HasMaxLength(500).IsRequired();
        }
    }
}
