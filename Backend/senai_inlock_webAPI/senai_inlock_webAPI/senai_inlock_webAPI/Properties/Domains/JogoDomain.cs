using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai_inlock_webAPI.Properties.Domains
{
    /// <summary>
    /// Classe que referencia a entidade jogo do banco
    /// </summary>
    public class JogoDomain
    {
        public int idJogo { get; set; }

        public int idEstudio { get; set; }

        [Required(ErrorMessage ="informe o nome do jogo")]
        [StringLength(40)]
        public string nomeJogo { get; set; }

        [Required(ErrorMessage ="Informe a descrição do jogo")]
        [StringLength(260)]
        public string descricao { get; set; }

        [Required(ErrorMessage ="informe a data de lançamento do jogo")]
        public DateTime dataLancamento { get; set; }

        [Required(ErrorMessage ="informe o valor do jogo")]
        public int valor { get; set; }

        public EstudioDomain estudio { get; set;  }
    }
}
