// See https://aka.ms/new-console-template for more information
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Wellcome My App... this is a application which is .net core-Entity Framework-ORM");
            //  InsertOneProduct();
             // InsertListProduct();
            //  GetAllProduct();
            //  UpdateProdcut();
            //   UpdateById();
            // UpdateById2(3,100);
            // deleteProduct(13);
           // deleteProduct2(20);
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
      
        static void GetAllProduct(){
           using( var db =new ShopContext()){
            var productlar=db.Products;
            foreach (var p in productlar)
            {
                Console.WriteLine($"Name:{p.Name} Price:{p.Price}");
            }
           }
        }
        
        static void UpdateProduct(){
            using(var db=new ShopContext()){
                var myproduct=db.Products.Where(p=>p.CategoryId==0).ToList();
                if ( myproduct!=null)
                {
                    foreach (var p in myproduct)
                    {
                        //  p.Price*=0.5m; 
                        p.Price+=10;
                    }
                  
                    db.SaveChanges();
                    Console.WriteLine("Prdoucts are updated");
                }
            }
        }
        static void UpdateById(){
            using(var db =new ShopContext()){
                var entity=new Product () {Id=1};
                db.Products.Attach(entity);
                entity.Price=0.1m;
                db.SaveChanges();
                Console.WriteLine("product is updated");
            }
        }
        static void UpdateById2(int productId,int productPrice){
            using(var db=new ShopContext()){
                var p=db.Products.Where(c=>c.Id==productId).FirstOrDefault();
                
                p.Price=productPrice;
                Console.WriteLine($"{p.Name} is updated ");
              
                db.SaveChanges();
                
            }
        }    

        static void deleteProduct(int id){
            using(var db=new ShopContext()) {
                var entity=new Product(){Id=id};
                db.Entry(entity).State=EntityState.Deleted;
                db.SaveChanges();
                Console.WriteLine("the product is deleted");
            }
        }
        static void deleteProduct2(int id){
            using(var db=new ShopContext()){
                var p=db.Products.Where(c=>c.Id==id).FirstOrDefault();
                db.Products.Remove(p);
                db.SaveChanges();
                Console.WriteLine("the product 2 is deleted");
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
   
