using teste_innovea.Data.Entity;
using System.Collections.Generic;

namespace teste_innovea.Data.Repositories
{
    public interface IArticleRepository
    {
        public IEnumerable<Article> List();
    }
}