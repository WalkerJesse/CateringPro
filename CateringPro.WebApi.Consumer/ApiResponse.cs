using System.Collections.Generic;

namespace CateringPro.WebApi.Consumer
{

    public class ApiResponse<TResponse>
    {

        #region - - - - - - Properties - - - - - -

        public TResponse Response { get; set; }

        public ValidationFailureResponse ValidationFailure { get; set; }

        #endregion Properties

    }

    public class ValidationFailureResponse
    {

        #region - - - - - - Properties - - - - - -

        public string Detail { get; set; }

        public IDictionary<string, string[]> Errors { get; set; }

        public IDictionary<string, object> Extensions { get; set; }

        public string Instance { get; set; }

        public int? Status { get; set; }

        public string Title { get; set; }

        public string Type { get; set; }

        #endregion Properties

    }

}
