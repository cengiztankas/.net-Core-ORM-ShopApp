// See https://aka.ms/new-console-template for more information
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("merhaba");
            //  InsertOneProduct();
             // InsertListProduct();
             GetAllData();
        }
        static void InsertOneProduct()  
        {
            
            using(var db=new ShopContext()){
                var product1= new Product{ Name="Samsung S5",Price=5000,CategoryId= 1 };
                db.Products.Add(product1);
                db.SaveChanges();

            }

        }
        static void InsertListProduct(){

            var Productslist=new List<Product>(){
             new Product() {Name="Samsung S6",Price=6000,CategoryId=1},
             new Product(){Name="Samsung S7",Price=7000,CategoryId=1 },
             new Product() {Name="Samsung S8", Price=8000,CategoryId=1},
             new Product() {Name="Samsung S9",Price=9000,CategoryId=1},
             new Product(){Name="Samsung S10",Price=10000,CategoryId=1 },
             new Product() {Name="Samsung S11", Price=11000,CategoryId=1}

            };
           

            using(var db=new ShopContext()){
                db.AddRange(Productslist);
                db.SaveChanges();
            }
        }
        static void GetAllData(){
           using( var db =new ShopContext()){
            var productlar=db.Products;
            foreach (var p in productlar)
            {
                Console.WriteLine($"Name:{p.Name} Price:{p.Price}");
            }
           }
        }

     
    }
   
     public class ShopContext: DbContext
    {  
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

     
         protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source=ShopApp.db");
            
     }

 public class Product
    { 
        public int Id { get; set; }
       
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int CategoryId { get; set; }

    }
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
   
