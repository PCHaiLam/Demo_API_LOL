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
        private readonly string apiChampionsUrl = "https://ddragon.leagueoflegends.com/cdn/14.23.1/data/vi_VN/champion.json";

        public async Task<ActionResult> Index()
        {
            var championsList = await GetChampionsListFromApi();

            ViewBag.Champions = championsList;
            return View();
        }
        //hàm lấy danh sách tướng tướng
        public async Task<List<dynamic>> GetChampionsListFromApi()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiChampionsUrl);
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
        
        //Detail
        public async Task<ActionResult> Detail(string id)
        {
            var champion = await GetChampionFromIdWithAPI(id);

            ViewBag.Champion = champion;
            return View();
        }
        // Hàm lấy data từ API
        public async Task<dynamic> GetChampionFromIdWithAPI(string id)
        {
            string apiChampionUrl = "https://ddragon.leagueoflegends.com/cdn/14.23.1/data/vi_VN/champion/" + id + ".json";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiChampionUrl);
                    response.EnsureSuccessStatusCode();

                    var responseData = await response.Content.ReadAsStringAsync();

                    var data = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(responseData);

                    if (data.ContainsKey("data") && data["data"].ContainsKey(id))
                    {
                        return data["data"][id];
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
