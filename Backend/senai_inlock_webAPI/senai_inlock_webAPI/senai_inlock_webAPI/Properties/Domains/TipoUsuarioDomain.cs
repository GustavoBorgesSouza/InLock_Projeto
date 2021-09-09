using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai_inlock_webAPI.Properties.Domains
{
    /// <summary>
    /// Classe que representa a entidade TipoUsuario do banco
    /// </summary>
    public class TipoUsuarioDomain
    {
        public int idTipoUsuario { get; set; }

        [Required(ErrorMessage ="informe o titulo do tipoUsuario")]
        [StringLength(25)]
        public string titulo { get; set; }
    }
}
