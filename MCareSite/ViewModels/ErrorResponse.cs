using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Localization;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace NajmetAlraqee.Site.ViewModels
{
    public class ErrorViewModel
    {             
        public bool Status { get; set; }
        public string Message { get; set; }
        public List<ValidationError> Errors { get; set; }
        
        public ErrorViewModel(ModelStateDictionary modelState, string errorMessage)
        {
            Message = errorMessage;
            Status = false;
            Errors = modelState.Keys
                    .SelectMany(key => modelState[key].Errors.Select(x => new ValidationError(key, x.ErrorMessage)))
                    .ToList();
        }

        public ErrorViewModel(IEnumerable<IdentityError> errors, string errorMessage)
        {
            Message = errorMessage;
            Status = false;
            Errors = errors.Select(error => new ValidationError(error.Code, error.Description))
                  .ToList();
        }

        public ErrorViewModel(string message, string field, string error)
        {
            Message = message;
            Status = false;
            Errors = new[] { new ValidationError(field, error)}.ToList();
        }
    }

    public class ValidationError
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Field { get; set; }
        public string Message { get; set; }

        public ValidationError(string field, string message)
        {
            Field = field != string.Empty ? field : null;
            Message = message;
        }
    }
}
