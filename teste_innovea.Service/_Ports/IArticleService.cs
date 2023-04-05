using teste_innovea.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using teste_innovea.Service.Dto;

namespace teste_innovea.Service._Ports
{
    public interface IArticleService
    {
        public List<Article> ListarArticles();
        public Task<ArticleDto> GetArticle(string guidCategory);
    }
}
