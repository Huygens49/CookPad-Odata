using System;
using System.Collections.Generic;

namespace Cookpad_Odata.Domain
{
    public partial class Ingredients
    {
        public Ingredients()
        {
            RecipesIngredients = new HashSet<RecipesIngredients>();
            ShoppingList = new HashSet<ShoppingList>();
        }

        public int IngredientId { get; set; }
        public string IngredientName { get; set; }
        public string UnitOfMeasure { get; set; }
        public DateTime? Deleted { get; set; }
        public decimal CurrentQuantity { get; set; }

        public virtual ICollection<RecipesIngredients> RecipesIngredients { get; set; }
        public virtual ICollection<ShoppingList> ShoppingList { get; set; }
    }
}
