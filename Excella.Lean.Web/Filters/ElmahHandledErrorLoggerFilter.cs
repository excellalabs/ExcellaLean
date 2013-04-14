namespace Excella.Lean.Web.Filters
{
    using System;
    using System.Web.Http.Filters;

    using Elmah;

    [AttributeUsage(AttributeTargets.Class)]
    public sealed class ElmahHandledErrorLoggerFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnException(actionExecutedContext);

            ErrorSignal.FromCurrentContext().Raise(actionExecutedContext.Exception);
        }
    }
}
