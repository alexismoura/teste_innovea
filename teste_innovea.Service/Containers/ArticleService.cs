using teste_innovea.Data.Entity;
using teste_innovea.Data.Repositories;
using teste_innovea.Service._Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Runtime;
using System.Threading.Tasks;
using teste_innovea.Service.Dto;

namespace teste_innovea.Service.Containers
{
    public class ArticleService : IArticleService
    {
        IArticleRepository ArticleRepository;
        public HttpClient httpClient;
        protected string _apiKey;

        public ArticleService(IArticleRepository _ArticleRepository)
        {
            ArticleRepository = _ArticleRepository;
        }

        public async Task<ArticleDto>  GetArticle(string subject)
        {
            var url = "https://newsapi.org/v2/everything?q=";
            url += $"{subject}&from=2023-03-04&to=2023-03-07&sortBy=popularity&apiKey=486da448794443a28fce4a10ca259458";
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64; rv:44.0) Gecko/20100101 Firefox/44.0");
            httpClient.DefaultRequestHeaders.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
            httpClient.BaseAddress = new System.Uri(url);

            var responseMessage = await httpClient.GetAsync(url);
            var content = await responseMessage.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ArticleDto>(content);
            return result;
        }

        public List<Article> ListarArticles()
        {
            var result =  ArticleRepository.List();
            if (result != null)
            {
                result.Reverse();
                return result.ToList();
            }
            else
                return new List<Article>();
        }

    }
}
