using CateringPro.WebApi.Interface.Ingredients.Commands;
using CateringPro.WebApi.Interface.Ingredients.Queries;
using CateringPro.WebApi.Interface.Ingredients.ViewModels;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CateringPro.WebApi.Consumer
{

    public class IngredientsApi
    {

        #region - - - - - - Fields - - - - - -

        private readonly HttpClient m_HttpClient;

        #endregion Fields

        #region - - - - - - Constructors - - - - - -

        public IngredientsApi(HttpClient httpClient)
        {
            this.m_HttpClient = httpClient ?? throw new System.ArgumentNullException(nameof(httpClient));
        }

        #endregion Constructors

        #region - - - - - - Methods - - - - - -

        public async Task<ApiResponse<IngredientViewModel>> AddIngredientAsync(CreateIngredientCommand command, CancellationToken cancellationToken)
        {
            var _HttpContent = new StringContent(JsonConvert.SerializeObject(command), Encoding.UTF8, "application/json");
            var _Response = await this.m_HttpClient.PostAsync("api/Ingredients/", _HttpContent, cancellationToken);
            var _ResponseContent = await _Response.Content.ReadAsStringAsync();

            if (_Response.StatusCode == HttpStatusCode.BadRequest)
                return new ApiResponse<IngredientViewModel>() { ValidationFailure = JsonConvert.DeserializeObject<ValidationFailureResponse>(_ResponseContent) };

            return new ApiResponse<IngredientViewModel>() { Response = JsonConvert.DeserializeObject<IngredientViewModel>(_ResponseContent) };
        }

        public async Task<ApiResponse<IngredientsViewModel>> GetIngredientsAsync(GetIngredientsQuery query, CancellationToken cancellationToken)
        {
            var _Response = await this.m_HttpClient.GetAsync("api/Ingredients/", cancellationToken);
            var _ResponseContent = await _Response.Content.ReadAsStringAsync();

            if (_Response.StatusCode == HttpStatusCode.BadRequest)
                return new ApiResponse<IngredientsViewModel>() { ValidationFailure = JsonConvert.DeserializeObject<ValidationFailureResponse>(_ResponseContent) };

            return new ApiResponse<IngredientsViewModel>() { Response = JsonConvert.DeserializeObject<IngredientsViewModel>(_ResponseContent) };
        }

        public async Task<ApiResponse<object>> UpdateIngredientAsync(UpdateIngredientCommand command, long IngredientID, CancellationToken cancellationToken)
        {
            var _HttpContent = new StringContent(JsonConvert.SerializeObject(command), Encoding.UTF8, "application/json");
            var _Response = await this.m_HttpClient.PostAsync($"/api/Ingredients/{IngredientID}", _HttpContent, cancellationToken);
            var _ResponseContent = await _Response.Content.ReadAsStringAsync();

            if (_Response.StatusCode == HttpStatusCode.BadRequest)
                return new ApiResponse<object>() { ValidationFailure = JsonConvert.DeserializeObject<ValidationFailureResponse>(_ResponseContent) };

            return new ApiResponse<object>();
        }

        #endregion Methods

    }

}
