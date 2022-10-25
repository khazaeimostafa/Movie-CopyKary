using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace MoviesAPI.Helpers
{
    public class TypeBinder<T> : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var propertyName = bindingContext.ModelName;
            var value = bindingContext.ValueProvider.GetValue(propertyName);

            if (value == ValueProviderResult.None)
            {
                return Task.CompletedTask;
            }
            else
            {
                try
                {
                    var desrilizedValue =
                        JsonConvert.DeserializeObject(value.FirstValue);
                    bindingContext.Result =
                        ModelBindingResult.Success(desrilizedValue);
                }
                catch
                {
                    bindingContext
                        .ModelState
                        .TryAddModelError(propertyName,
                        "The given value is not of the correct type");
                }
            }

            return Task.CompletedTask;
        }
    }
}
