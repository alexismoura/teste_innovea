using System;
using System.Collections.Generic;
using System.Text;
using teste_innovea.Data.Shared;

namespace teste_innovea.Data.Entity
{
    public class Root : EntityBase
	{
        public int Id { get; set; }
		public string Guid { get; set; }
		public string GuidLicaoDia { get; set; }
		public string Questao { get; set; }
		public string Passagem { get; set; }
		public string Resposta { get; set; }
    }
}
