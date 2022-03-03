using AutoMapper;
using CateringPro.Application.UseCases.Recipes.CreateRecipe;
using CateringPro.WebApi.Presentation.ViewModels.Recipes;
using System.Threading;
using System.Threading.Tasks;

namespace CateringPro.WebApi.Presentation.Presenters.Recipes
{

    public class CreateRecipePresenter : BasePresenter, ICreateRecipeOutputPort
    {

        #region - - - - - - Fields - - - - - -

        private readonly IMapper m_Mapper;

        #endregion Fields

        #region - - - - - - Constructors - - - - - -

        public CreateRecipePresenter(IMapper mapper) : base(mapper)
            => this.m_Mapper = mapper ?? throw new System.ArgumentNullException(nameof(mapper));

        #endregion Constructors

        #region - - - - - - Methods - - - - - -

        public Task PresentRecipeAsync(CreatedRecipeDto Recipe, CancellationToken cancellationToken)
        {
            this.PresentedSuccessfully = true;
            return this.CreatedAsync(() => this.m_Mapper.Map<RecipeViewModel>(Recipe));
        }

        #endregion Methods

    }

}
