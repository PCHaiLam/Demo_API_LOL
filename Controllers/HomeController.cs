using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace Demo_API_LOL.Controllers
{
    public class HomeController : Controller
    {
        private readonly string apiUrl = "https://ddragon.leagueoflegends.com/cdn/14.23.1/data/vi_VN/champion.json";

        public async Task<ActionResult> Index()
        {
            var jsonContent = await GetJsonFromApi();
            var championsList = await GetChampionsListFromApi();

            ViewBag.Champions = championsList;
            ViewBag.JsonContent = jsonContent;

            return View();
        }
        // Hàm lấy data từ API
        public async Task<string> GetJsonFromApi()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    response.EnsureSuccessStatusCode();

                    var responseData = await response.Content.ReadAsStringAsync();

                    var data = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(responseData);

                    if(data.ContainsKey("data"))
                    {
                        var champions = JsonConvert.SerializeObject(data["data"], Formatting.Indented);
                        return champions;
                    }

                    return null;
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = ex.Message;
                    return null;
                }
            }
        }
        //hàm lấy thông tin chi tiết của 1 tướng
        public async Task<List<dynamic>> GetChampionsListFromApi()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    response.EnsureSuccessStatusCode();

                    var responseData = await response.Content.ReadAsStringAsync();

                    var data = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(responseData);

                    if (data.ContainsKey("data"))
                    {
                        var champions = data["data"];
                        var championsDetail = new List<dynamic>();

                        foreach (var champion in champions)
                        {
                            championsDetail.Add(champion.Value);
                        }

                        return championsDetail;
                    }

                    return null;
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = ex.Message;
                    return null;
                }
            }
        }
    }
}
