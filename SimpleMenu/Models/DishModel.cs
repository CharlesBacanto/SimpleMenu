namespace SimpleMenu.Models
{
    public class DishModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string imgUrl { get; set; }
        public double price { get; set; }

        public List<DishIngredientModel>? DishIngredient { get; set; }

    }
}
