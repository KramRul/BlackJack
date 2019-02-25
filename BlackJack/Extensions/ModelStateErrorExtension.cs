using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;

namespace BlackJack.WEB.Extensions
{
    public static class ModelStateErrorExtension
    {
        public static string GetFirstErrorFromModelState(this ModelStateDictionary modelState)
        {
            var errorMessage = modelState.Values.SelectMany(v => v.Errors)
                      .Select(v => v.ErrorMessage).FirstOrDefault();
            return errorMessage;
        }
    }
}