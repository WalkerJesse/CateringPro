using CateringPro.Application.Services;

namespace CateringPro.Application.UseCases.Ingredients.DeleteIngredient
{

    public class DeleteIngredientRequest : IUseCaseRequest<DeleteIngredientResponse>
    {

        #region - - - - - - Properties - - - - - -

        public long ID { get; set; }

        #endregion Properties

    }

}
