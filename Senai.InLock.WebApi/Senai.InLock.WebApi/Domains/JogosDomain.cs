using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Domains
{
    public class JogosDomain
    {
        public int IdJogo { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public DateTime DataLancamento { get; set; }

        public double Valor { get; set; }

        public int IdEstudio { get; set; }

        public EstudiosDomain Estudio { get; set; }
    }
}
