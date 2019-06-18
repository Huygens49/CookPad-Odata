using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cookpad_Odata.Domain;
using Cookpad_Odata.Services;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;

namespace Cookpad_Odata.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipeService recipeService;

        public RecipesController(IRecipeService recipeService)
        {
            this.recipeService = recipeService;
        }

        [HttpGet]
        [EnableQuery]
        public ActionResult<IEnumerable<Recipes>> GetAllRecipes()
        {
            return recipeService.GetAllRecipes();
        }
    }
}
