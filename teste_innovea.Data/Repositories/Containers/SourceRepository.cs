using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using teste_innovea.Data.Entity;
using teste_innovea.Data.Shared;

namespace teste_innovea.Data.Repositories
{
    public class SourceRepository : RepositoryBase<Source>, ISourceRepository
    {
        public SourceRepository(teste_innoveaDbContext context) : base(context)
        {
        }

        #region Metodos sincronos
        public IEnumerable<Source> List()
        {
            return _dbSet.ToList();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
        #endregion
    }
}
