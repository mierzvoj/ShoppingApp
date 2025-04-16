using Mango.Web.Utility;

namespace Mango.Web.Models;

public class RequestDTO
{
    public SD.ApiType ApiType {get; set;} = SD.ApiType.GET;
    public string Url { get; set; } = string.Empty;
    public object? Data { get; set; } = null;
    public string AccessToken { get; set; } = string.Empty;
}