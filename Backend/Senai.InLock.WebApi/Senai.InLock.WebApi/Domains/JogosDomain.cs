using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Domains
{
    public class JogosDomain
    {
        public int IdJogo { get; set; }

        [Required(ErrorMessage = "Nome do jogo é obrigatório")]
        public string Nome { get; set; }

        public string Descricao { get; set; }

        [Required(ErrorMessage = "Data de lançamento é obrigatório")]
        public DateTime DataLancamento { get; set; }

        [Required(ErrorMessage = "Valor é obrigatório")]
        public double Valor { get; set; }

        [Required(ErrorMessage = "IdEstudio é obrigatório")]
        public int IdEstudio { get; set; }

        public EstudiosDomain Estudio { get; set; }
    }
}
