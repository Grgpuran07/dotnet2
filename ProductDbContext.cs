using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace dotnet2
{
    public class ProductDbContext : DbContext
    {
        public DbSet<Product> Products{get;set;}
        public ProductDbContext(DbContextOptions<ProductDbContext> dbContextOptions) : base (dbContextOptions){
            try{
            //    var dataBaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
             var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
             if(databaseCreator!=null){

               //Create database if can not connect
                if(!databaseCreator.CanConnect()){
                    databaseCreator.Create();
                }
                //create tables if tables not exist
                if(!databaseCreator.HasTables()){
                    databaseCreator.CreateTables();
                }
             }
            }
            catch(Exception ex){
                Console.WriteLine(ex.Message);
            }
        }
    }
}