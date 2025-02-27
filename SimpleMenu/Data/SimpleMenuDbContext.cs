using Microsoft.EntityFrameworkCore;
using SimpleMenu.Models;

namespace SimpleMenu.Data
{
    public class SimpleMenuDbContext:DbContext
    {
        public DbSet<DishModel> TblDish { get; set; }
        public DbSet<IngredientModel> TblIngredient { get; set; }
        public DbSet<DishIngredientModel> TblDishIngredient { get; set; }

        public SimpleMenuDbContext(DbContextOptions<SimpleMenuDbContext>options): base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DishIngredientModel>().HasKey(di => new
            {
                di.dishId,
                di.ingredientId
            });
            modelBuilder.Entity<DishIngredientModel>().HasOne(d => d.Dish).WithMany(di => di.DishIngredient).HasForeignKey(d=> d.dishId);
            modelBuilder.Entity<DishIngredientModel>().HasOne(i => i.Ingredient).WithMany(di => di.DishIngredient).HasForeignKey(i => i.ingredientId);

            modelBuilder.Entity<DishModel>().HasData(
                new DishModel { id=1, name="Pizza", price=699, imgUrl= "https://i.pinimg.com/736x/6a/88/32/6a8832d29a911b320f9c68af86f8e134.jpg" }
                );
            modelBuilder.Entity<IngredientModel>().HasData(
                new IngredientModel {id =1, name="Tomato Sauce"},
                new IngredientModel {id =2, name=" Mozarella Cheese"},
                new IngredientModel {id =3, name="Pepperoni"}
                );

            modelBuilder.Entity<DishIngredientModel>().HasData(
                new DishIngredientModel { dishId = 1, ingredientId = 1 },
                new DishIngredientModel { dishId = 1, ingredientId = 2 },
                new DishIngredientModel { dishId = 1, ingredientId = 3 }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
