﻿namespace SampleProject.API.BaseMiddlewares;

public class GlobalExceptionHandleMiddleware(RequestDelegate next)
{
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {

        }
        /*catch (NotAuthorizedException)
        {
            await HandleException((int)HttpStatusCode.Unauthorized, context, Messages.UserNotAuthorized);
        }
        catch (DbException e)
        {
            await HandleException((int)HttpStatusCode.InternalServerError, context, e.Message);
        }
        catch (ValidationException e)
        {
            var errors = e.Errors.Select(x => x.ErrorMessage).ToArray();
            await HandleException((int)HttpStatusCode.BadRequest, context, errors);
        }
        catch (Exception ex)
        {
            await HandleException((int)HttpStatusCode.InternalServerError, context, ex.Message + ex.InnerException?.Message);
            //await HandleException((int)HttpStatusCode.InternalServerError, context, Messages.ServerErrorOccured);
        }*/
    }

    private async Task HandleException(int statusCode, HttpContext context, params string[] message)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = statusCode;
        //var result = Result.Error(message);
        //await context.Response.WriteAsync(JsonConvert.SerializeObject(result));
    }
}