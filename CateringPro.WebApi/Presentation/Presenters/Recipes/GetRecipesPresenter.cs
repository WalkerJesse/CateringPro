using AutoMapper;
using AutoMapper.QueryableExtensions;
using CateringPro.Application.Dtos;
using CateringPro.Application.UseCases.Recipes.GetRecipes;
using CateringPro.WebApi.Presentation.ViewModels.Recipes;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CateringPro.WebApi.Presentation.Presenters.Recipes
{

    public class GetRecipesPresenter : BasePresenter, IGetRecipesOutputPort
    {

        #region - - - - - - Fields - - - - - -

        private readonly IMapper m_Mapper;

        #endregion Fields

        #region - - - - - - Constructors - - - - - -

        public GetRecipesPresenter(IMapper mapper) : base(mapper)
            => this.m_Mapper = mapper ?? throw new System.ArgumentNullException(nameof(mapper));

        #endregion Constructors

        #region - - - - - - Methods - - - - - -

        public Task PresentRecipesAsync(IQueryable<RecipeDto> recipes, CancellationToken cancellationToken)
            => this.OkAsync(recipes.ProjectTo<RecipeViewModel>(this.m_Mapper.ConfigurationProvider));

        #endregion Methods

    }

}
