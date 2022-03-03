using AutoMapper;
using CateringPro.Application.Dtos;
using CateringPro.Application.UseCases.Ingredients.GetIngredients;
using CateringPro.WebApi.Presentation.ViewModels.Ingredients;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CateringPro.WebApi.Presentation.Presenters.Ingredients
{

    public class GetIngredientsPresenter : BasePresenter, IGetIngredientsOutputPort
    {

        #region - - - - - - Fields - - - - - -

        private readonly IMapper m_Mapper;

        #endregion Fields

        #region - - - - - - Constructors - - - - - -

        public GetIngredientsPresenter(IMapper mapper) : base(mapper)
            => this.m_Mapper = mapper ?? throw new System.ArgumentNullException(nameof(mapper));

        #endregion Constructors

        #region - - - - - - Methods - - - - - -

        public Task PresentIngredientsAsync(IQueryable<IngredientDto> ingredients, CancellationToken cancellationToken)
            => this.OkAsync(this.m_Mapper.ProjectTo<IngredientViewModel>(ingredients));

        #endregion Methods

    }

}
