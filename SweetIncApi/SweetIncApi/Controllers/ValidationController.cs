using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace SweetIncApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValidationController : ControllerBase
    {
        private static readonly string validationUrl = "http://127.0.0.1:5000/api/validate";

        //public static async Task<bool> Validate(HttpRequest request, List<string> pageScopes)
        //{
        //    try
        //    {
        //        request.Headers.TryGetValue("fe-access-token", out var token);

        //        var client = new HttpClient();
        //        client.BaseAddress = new Uri(validationUrl);
        //        client.DefaultRequestHeaders.Add("x-access-token", token.ToString());

        //        var response = await client.PostAsJsonAsync("", new
        //        {
        //            scope = pageScopes
        //        });
        //        var jsonResponseString = await response.Content.ReadAsStringAsync();

        //        JObject jsonResponse = JObject.Parse(jsonResponseString);


        //        return (bool)jsonResponse["isPassed"];
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

    }
}
