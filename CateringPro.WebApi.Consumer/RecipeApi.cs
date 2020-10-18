using CateringPro.WebApi.Interface.Recipes.Commands;
using CateringPro.WebApi.Interface.Recipes.Queries;
using CateringPro.WebApi.Interface.Recipes.ViewModels;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CateringPro.WebApi.Consumer
{

    public class RecipesApi
    {

        #region - - - - - - Fields - - - - - -

        private readonly HttpClient m_HttpClient;

        #endregion Fields

        #region - - - - - - Constructors - - - - - -

        public RecipesApi(HttpClient httpClient)
        {
            this.m_HttpClient = httpClient ?? throw new System.ArgumentNullException(nameof(httpClient));
        }

        #endregion Constructors

        #region - - - - - - Methods - - - - - -

        public async Task<ApiResponse<RecipeViewModel>> AddRecipeAsync(CreateRecipeCommand command, CancellationToken cancellationToken)
        {
            var _HttpContent = new StringContent(JsonConvert.SerializeObject(command), Encoding.UTF8, "application/json");
            var _Response = await this.m_HttpClient.PostAsync("api/Recipes/", _HttpContent, cancellationToken);
            var _ResponseContent = await _Response.Content.ReadAsStringAsync();

            if (_Response.StatusCode == HttpStatusCode.BadRequest)
                return new ApiResponse<RecipeViewModel>() { ValidationFailure = JsonConvert.DeserializeObject<ValidationFailureResponse>(_ResponseContent) };

            return new ApiResponse<RecipeViewModel>() { Response = JsonConvert.DeserializeObject<RecipeViewModel>(_ResponseContent) };
        }

        public async Task<ApiResponse<RecipesViewModel>> GetRecipesAsync(GetRecipesQuery query, CancellationToken cancellationToken)
        {
            var _Response = await this.m_HttpClient.GetAsync("api/Recipes/", cancellationToken);
            var _ResponseContent = await _Response.Content.ReadAsStringAsync();

            if (_Response.StatusCode == HttpStatusCode.BadRequest)
                return new ApiResponse<RecipesViewModel>() { ValidationFailure = JsonConvert.DeserializeObject<ValidationFailureResponse>(_ResponseContent) };

            return new ApiResponse<RecipesViewModel>() { Response = JsonConvert.DeserializeObject<RecipesViewModel>(_ResponseContent) };
        }

        #endregion Methods

    }

}
