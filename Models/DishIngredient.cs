namespace Menu.Models
{
    //connects dish to ingredients coz a dish can have many ingredients and vice versa
    public class DishIngredient
    {
        public int DishId { get; set; }
        public Dish Dish { get; set; }//property
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }//property

    }
}
