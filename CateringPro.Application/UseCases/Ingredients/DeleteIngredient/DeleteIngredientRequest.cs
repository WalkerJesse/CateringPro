using CateringPro.Application.Services;

namespace CateringPro.Application.UseCases.Ingredients.DeleteIngredient
{

    public class DeleteIngredientRequest : IUseCaseRequest<DeleteIngredientResponse>
    {

        #region - - - - - - Properties - - - - - -

        public long IngredientID { get; set; }

        #endregion Properties

    }

}
