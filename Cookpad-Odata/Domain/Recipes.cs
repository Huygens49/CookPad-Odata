using System;
using System.Collections.Generic;

namespace Cookpad_Odata.Domain
{
    public partial class Recipes
    {
        public Recipes()
        {
            RecipesIngredients = new HashSet<RecipesIngredients>();
        }

        public int RecipeId { get; set; }
        public string RecipeName { get; set; }
        public DateTime? Deleted { get; set; }

        public virtual ICollection<RecipesIngredients> RecipesIngredients { get; set; }
    }
}
