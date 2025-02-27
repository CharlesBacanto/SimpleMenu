namespace SimpleMenu.Models
{
    public class IngredientModel
    {
        public int id { get; set; }
        public string name { get; set; }

        public List<DishIngredientModel>? DishIngredient { get; set; }
    }
}
