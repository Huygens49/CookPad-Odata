using System;
using System.Collections.Generic;

namespace Cookpad_Odata.Domain
{
    public partial class ShoppingList
    {
        public int ShoppingListId { get; set; }
        public int? IngredientId { get; set; }
        public decimal? Quantity { get; set; }

        public virtual Ingredients Ingredient { get; set; }
    }
}
