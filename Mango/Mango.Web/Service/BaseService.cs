using System.Diagnostics;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using Mango.Web.Models;
using Mango.Web.Service.IService;
using Mango.Web.Utility;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Newtonsoft.Json;

namespace Mango.Web.Service;

public class BaseService : IBaseService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public BaseService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<ResponseDTO?> SendAsync(RequestDTO requestDto)
    {
        HttpClient client = _httpClientFactory.CreateClient("MangoAPI");
        HttpRequestMessage message = new();
        message.Headers.Add("Accept", "application/json");
        message.RequestUri = new Uri(requestDto.Url);
        if (requestDto.Data != null)
        {
            message.Content = new StringContent(JsonConvert.SerializeObject(requestDto.Data), Encoding.UTF8,
                "application/json");
        }

        HttpResponseMessage? apiResponse = null;
        switch (requestDto.ApiType)
        {
            case ApiType.POST:
                message.Method = HttpMethod.Post;
                break;
            case ApiType.PUT:
                message.Method = HttpMethod.Put;
                break;
            case ApiType.DELETE:
                message.Method = HttpMethod.Delete;
                break;
            default:
                message.Method = HttpMethod.Get;
                break;
        }

        apiResponse = await client.SendAsync(message);
        switch (apiResponse.StatusCode)
        {
            case HttpStatusCode.NotFound:
            {
                return new ResponseDTO { IsSuccess = false };
            }

            case HttpStatusCode.Forbidden:
            {
                return new ResponseDTO { IsSuccess = false };
            }

            case HttpStatusCode.Unauthorized:
            {
                return new ResponseDTO { IsSuccess = false };
            }

            case HttpStatusCode.InternalServerError:
            {
                return new ResponseDTO { IsSuccess = false };
            }

            default:
                var apiContent = await apiResponse.Content.ReadAsStringAsync();
                var apiResponseDTO = JsonConvert.DeserializeObject<ResponseDTO>(apiContent);
                
                return apiResponseDTO;
        }
    }
}