using teste_innovea.Data.Entity;
using teste_innovea.Data.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace teste_innovea.Data.Repositories
{
    public interface ISourceRepository : IRepositoryBase<Source>
    {
        public IEnumerable<Source> List();
    }
}
