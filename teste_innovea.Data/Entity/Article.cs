using System;
using System.Collections.Generic;
using System.Text;
using teste_innovea.Data.Shared;

namespace teste_innovea.Data.Entity
{
    public class Article : EntityBase
	{
        public int id { get; set; }
        public Source source { get; set; }
        public string author { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string url { get; set; }
        public string urlToImage { get; set; }
        public DateTime publishedAt { get; set; }
        public string content { get; set; }
    }
}
