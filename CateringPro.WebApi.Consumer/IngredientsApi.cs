using CateringPro.WebApi.Interface.Models.Ingredients.CreateIngredient;
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

        public async Task<ApiResponse<CreateIngredientViewModel>> AddIngredientAsync(CreateIngredientCommand command, CancellationToken cancellationToken)
        {
            var _HttpContent = new StringContent(JsonConvert.SerializeObject(command), Encoding.UTF8, "application/json");
            var _Response = await this.m_HttpClient.PostAsync("api/Ingredients/", _HttpContent, cancellationToken);
            var _ResponseContent = await _Response.Content.ReadAsStringAsync();

            if (_Response.StatusCode == HttpStatusCode.BadRequest)
                return new ApiResponse<CreateIngredientViewModel>() { ValidationFailure = JsonConvert.DeserializeObject<ValidationFailureResponse>(_ResponseContent) };

            return new ApiResponse<CreateIngredientViewModel>() { Response = JsonConvert.DeserializeObject<CreateIngredientViewModel>(_ResponseContent) };
        }

        #endregion Methods

    }

}
