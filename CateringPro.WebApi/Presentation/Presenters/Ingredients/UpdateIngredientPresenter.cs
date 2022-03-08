using AutoMapper;
using CateringPro.Application.Dtos;
using CateringPro.Application.UseCases.Ingredients.UpdateIngredient;
using CateringPro.Domain.Entities;
using CateringPro.WebApi.Presentation.ViewModels.Ingredients;
using System.Threading;
using System.Threading.Tasks;

namespace CateringPro.WebApi.Presentation.Presenters.Ingredients
{

    public class UpdateIngredientPresenter : BasePresenter, IUpdateIngredientOutputPort
    {

        #region - - - - - - Fields - - - - - -

        private readonly IMapper m_Mapper;

        #endregion Fields

        #region - - - - - - Constructors - - - - - -

        public UpdateIngredientPresenter(IMapper mapper) : base(mapper)
            => this.m_Mapper = mapper ?? throw new System.ArgumentNullException(nameof(mapper));

        #endregion Constructors

        #region - - - - - - Methods - - - - - -

        public Task PresentIngredientAsync(IngredientDto ingredient, CancellationToken cancellationToken)
        {
            this.PresentedSuccessfully = true;
            return this.OkAsync(this.m_Mapper.Map<IngredientViewModel>(ingredient));
        }

        public Task PresentIngredientNotFound(long ingredientID, CancellationToken cancellationToken)
            => this.NotFoundRouteAsync(nameof(Ingredient), ingredientID);

        #endregion Methods

    }

}
