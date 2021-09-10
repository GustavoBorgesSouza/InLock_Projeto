using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai_inlock_webAPI.Properties.Domains
{
    /// <summary>
    /// Classe que define a entidade usuario do banco
    /// </summary>
    public class UsuarioDomain
    {
        public int idUsuario { get; set; }

        public int idTipoUsuario { get; set; }

        [Required(ErrorMessage = "informe o email")]
        [StringLength(256)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a senha")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "O campo senha precisa ter no mínimo 4 caracteres e no máximo 20")]
        public string Senha { get; set; }

        public TipoUsuarioDomain TipoUsuario { get; set; }
    }
}
