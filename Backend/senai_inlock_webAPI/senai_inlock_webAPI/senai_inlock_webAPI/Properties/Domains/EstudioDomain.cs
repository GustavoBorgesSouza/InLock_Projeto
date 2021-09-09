using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai_inlock_webAPI.Properties.Domains
{
    /// <summary>
    /// Classse que define a entidade estudio do banco
    /// </summary>
    public class EstudioDomain
    {
        public int idEstudio { get; set; }

        [Required(ErrorMessage ="Informe o nome do estudio")]
        [StringLength(50)]
        public string nomeEstudio { get; set; }

    }
}
