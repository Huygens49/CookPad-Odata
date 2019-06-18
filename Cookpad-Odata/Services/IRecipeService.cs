using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cookpad_Odata.Domain;

namespace Cookpad_Odata.Services
{
    public interface IRecipeService
    {
        List<Recipes> GetAllRecipes();
    }
}
