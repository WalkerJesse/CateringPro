using CateringPro.Application.Services;
using CateringPro.Domain.Enumerations;
using System.Collections.Generic;

namespace CateringPro.Application.UseCases.Recipes.CreateRecipe
{

    public class CreateRecipeRequest : IUseCaseRequest<CreateRecipeResponse>
    {

        #region - - - - - - Properties - - - - - -

        public List<RecipeIngredientDto> Ingredients { get; set; }

        public string Name { get; set; }

        #endregion Properties

    }

    public class RecipeIngredientDto
    {

        #region - - - - - - Properties - - - - - -

        public long IngredientID { get; set; }

        public int Measurement { get; set; }

        public MeasurementType MeasurementType { get; set; }

        #endregion Properties

    }

}
