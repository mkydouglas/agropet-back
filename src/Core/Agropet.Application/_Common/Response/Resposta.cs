using System.Text.Json.Serialization;

namespace Agropet.Application.Common.Response;

public class Resposta
{
    public Resposta(int statusCode, object? data = null)
    {
        StatusCode = statusCode;
        Data = data;
    }

    public Resposta(int statusCode, bool success, string message, object? data = null)
    {
        StatusCode = statusCode;
        Success = success;
        Message = message;
        Data = data;
    }

    [JsonIgnore]
    public int StatusCode { get; set; }
    public bool Success { get; set; } = true;
    public string Message { get; set; } = "Operação realizada com sucesso.";
    public object? Data { get; set; }
}
