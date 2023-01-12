using JWT_Authentication.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TRACKIT_BACKEND_API.Dtos;

public class ApiHitResponse<T>
{
    private readonly T _value;
    private string _message;
    private string _status;

    public ApiHitResponse(T value,string message, string status)
    {
        _value = value;
        this._message = message;
        _status = status;
    }

    public IActionResult ExecuteResultAsync(Object data)
    {
        var value = new ApiResponse<Object>
        {
            Message = _message,
            StatusCode = _status,
            Data = data
        };
        var settings = new JsonSerializerSettings
        {
            Formatting = Formatting.Indented,
            NullValueHandling = NullValueHandling.Ignore
        };
        return JsonResult(value, settings);
    }
}