using JWT_Authentication.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TRACKIT_BACKEND_API.Dtos;

public class ApiHitResponse<T> : IActionResult
{
    private readonly T _value;
    private string _message;

    public ApiHitResponse(T value,string message)
    {
        _value = value;
        this._message = message;
    }

    public async Task ExecuteResultAsync(ActionContext context)
    {
        var response = context.HttpContext.Response;
        response.ContentType = "application/json";
        var responseData = new ApiResponse<T>
        {
            Message = this._message,
            StatusCode = response.StatusCode.ToString(),
            Data = this._value
        };
        await response.WriteAsync(JsonConvert.SerializeObject(responseData));
    }
}