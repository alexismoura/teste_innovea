using System;
using System.Collections.Generic;
using System.Text;
using teste_innovea.Data.Entity;

namespace teste_innovea.Service.Dto
{
    public class ArticleDto
    {
        public int totalResults { get; set; }
        public string status { get; set; }
        public List<Article> articles { get; set; }
    }

}
