using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace JunBatchCodeFirstApproachImpl.Filter
{
    public class globalexe : ExceptionFilterAttribute
    {
            public override void OnException(ExceptionContext context)
            {
                var controllerName = context.RouteData.Values["controller"]?.ToString();
                var actionName = context.RouteData.Values["action"]?.ToString();
                string exceptionMessage = context.Exception.Message;
                string innerMessage = context.Exception.InnerException?.Message ?? "No inner exception";
                string logDirPath = @"C:\Users\gurur\Source\Repos\CodeFirstApproachImpl\JunBatchCodeFirstApproachImpl";
                if (!Directory.Exists(logDirPath))
                    Directory.CreateDirectory(logDirPath);

                string logFilePath = Path.Combine(logDirPath, $"Log_{DateTime.Today:dd-MM-yyyy}.txt");

            string logEntry = $@"
                    
                    Log Created At: {DateTime.Now:dd-MM-yyyy hh:mm tt}
                    Controller:   {controllerName}
                    Action:        {actionName}
                    Message:    {exceptionMessage}
                    Inner Message:  {innerMessage}";
    

                File.AppendAllText(logFilePath, logEntry);

                context.Result = new RedirectResult("/Error/Index");
                context.ExceptionHandled = true;

                base.OnException(context);
            }
        }
    }
