using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cookpad_Odata.Domain;
using Microsoft.EntityFrameworkCore;

namespace Cookpad_Odata.Services.Implementations
{
    public class RecipeService : IRecipeService
    {
        private readonly CookpadContext context;

        public RecipeService(CookpadContext context)
        {
            this.context = context;
        }

        public List<Recipes> GetAllRecipes()
        {
            return context.Recipes.Include(r => r.RecipesIngredients).ToList();
        }
    }
}
