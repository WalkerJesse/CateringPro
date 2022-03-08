using AutoMapper;
using CateringPro.Application.UseCases.Ingredients.CreateIngredient;
using CateringPro.WebApi.Presentation.ViewModels.Ingredients;
using System.Threading;
using System.Threading.Tasks;

namespace CateringPro.WebApi.Presentation.Presenters.Ingredients
{

    public class CreateIngredientPresenter : BasePresenter, ICreateIngredientOutputPort
    {

        #region - - - - - - Fields - - - - - -

        private readonly IMapper m_Mapper;

        #endregion Fields

        #region - - - - - - Constructors - - - - - -

        public CreateIngredientPresenter(IMapper mapper) : base(mapper)
            => this.m_Mapper = mapper ?? throw new System.ArgumentNullException(nameof(mapper));

        #endregion Constructors

        #region - - - - - - Methods - - - - - -

        public Task PresentIngredientAsync(CreatedIngredientDto ingredient, CancellationToken cancellationToken)
        {
            this.PresentedSuccessfully = true;
            return this.CreatedAsync(() => this.m_Mapper.Map<IngredientViewModel>(ingredient));
        }

        #endregion Methods

    }

}
