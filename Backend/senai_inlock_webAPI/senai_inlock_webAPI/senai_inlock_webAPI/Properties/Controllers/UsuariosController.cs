using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai_inlock_webAPI.Properties.Domains;
using senai_inlock_webAPI.Properties.Interfaces;
using senai_inlock_webAPI.Properties.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace senai_inlock_webAPI.Properties.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository _UsuarioRepository { get; set; }

        public UsuariosController()
        {
            _UsuarioRepository = new UsuarioRepository();
        }

        [HttpPost("Login")]
        public IActionResult Login(UsuarioDomain login)
        {
            UsuarioDomain usuarioBuscado = _UsuarioRepository.BuscarPorEmailSenha(login.Email, login.Senha);

            if (usuarioBuscado != null)
            {
                //return Ok(usuarioBuscado);

                var minhasclaims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.idUsuario.ToString()),
                    new Claim(ClaimTypes.Role, usuarioBuscado.idTipoUsuario.ToString()),
                    new Claim("Claim Personalizada", "Oi")
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Autenticacao_ChaveInLock"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var MeuToken = new JwtSecurityToken(
                    issuer: "Inlock.webAPI",
                    audience: "Inlock.webAPI",
                    claims: minhasclaims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(MeuToken)
                });
            }

            return NotFound("Email ou senha inválidos");
        }
    }
}
