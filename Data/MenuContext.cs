using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using Menu.Models;


namespace Menu.Data
{
    public class MenuContext : DbContext // menucontext class inherits dbcontext
    {
        public MenuContext(DbContextOptions<MenuContext> options) : base(options)//instructor
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DishIngredient>().HasKey(di => new
            {
                di.DishId,
                di.IngredientId,

            });
            modelBuilder.Entity<DishIngredient>().HasOne(d => d.Dish).WithMany(di => di.DishIngredients).HasForeignKey(d => d.DishId);//one dish has many dish ingredients with foreign key dish id
            modelBuilder.Entity<DishIngredient>().HasOne(I => I.Ingredient).WithMany(di => di.DishIngredients).HasForeignKey(i => i.IngredientId); //one ingredient has many dish ingredients with foreign key ingredient id 

            //adding data to models

            modelBuilder.Entity<Dish>().HasData(
                new Dish { Id=1, Name = "Margherita", Price=7.50, ImageUrl= "/Images/image1.jpg" }
                );
            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient { Id=1, Name="Tomato Sauce"},
                 new Ingredient { Id = 2, Name = "Mozzarella" }
                );
            modelBuilder.Entity<DishIngredient>().HasData(
                new DishIngredient { DishId=1, IngredientId=1},
                  new DishIngredient { DishId = 1, IngredientId =2}
                );
            base.OnModelCreating(modelBuilder);
        }
        //dbset instances for each model we are creating
        public DbSet<Dish>Dishes { get; set; }
        public DbSet<Ingredient>Ingredients { get; set; }
        public DbSet<DishIngredient>DishIngredients { get; set; }    
    }
}
