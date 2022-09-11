using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ApiLogin.Attributes
{
  [AttributeUsage(validOn: AttributeTargets.Class)]
  public class ApiKeyAttribute : Attribute, IAsyncActionFilter
  {
    private const string ApiKeyName = "ApiKey";

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
      if (!context.HttpContext.Request.Headers.TryGetValue(ApiKeyName, out var extractedApiKeyName))
      {
        context.Result = new ContentResult()
        {
          StatusCode = 401,
          Content = "Informe a chave da Api"
        };
        return;
      }
      var AppSettings = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
      var ApiKey = AppSettings.GetValue<string>(ApiKeyName);
      if (!ApiKey.Equals(extractedApiKeyName))
      {
        context.Result = new ContentResult()
        {
          StatusCode = 401,
          Content = "Não Autorizado"
        };
        return;
      }
      await next();
    }
  }
}