namespace SimpleMenu.Models
{
    public class DishIngredientModel
    {
        public int dishId { get; set; }
        public DishModel Dish { get; set; }

        public int ingredientId { get; set; }
        public IngredientModel Ingredient { get; set; }

    }
}
