using System;
using System.Collections.Generic;

namespace Cookpad_Odata.Domain
{
    public partial class RecipesIngredients
    {
        public int RecipeIngredientId { get; set; }
        public int RecipeId { get; set; }
        public int IngredientId { get; set; }
        public DateTime? Deleted { get; set; }
        public decimal Quantity { get; set; }

        public virtual Ingredients Ingredient { get; set; }
        public virtual Recipes Recipe { get; set; }
    }
}
