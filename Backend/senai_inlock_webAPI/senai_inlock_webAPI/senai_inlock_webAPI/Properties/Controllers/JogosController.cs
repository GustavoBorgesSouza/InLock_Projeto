using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_inlock_webAPI.Properties.Domains;
using senai_inlock_webAPI.Properties.Interfaces;
using senai_inlock_webAPI.Properties.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_inlock_webAPI.Properties.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        private IJogoRepository _JogoRepository { get; set;  }

        public JogosController()
        {
            _JogoRepository = new JogoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<JogoDomain> ListaJogos = _JogoRepository.ListarTodos();

                return Ok(ListaJogos);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                JogoDomain jogobuscado = _JogoRepository.BuscarPorId(id);

                if (jogobuscado != null)
                {
                    return Ok(jogobuscado);
                }
                return NotFound("Jogo não encontrado");
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPost]
        public IActionResult Post(JogoDomain novoJogo)
        {
            try
            {
                _JogoRepository.Cadastrar(novoJogo);

                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _JogoRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPut]
        public IActionResult Put(JogoDomain JogoAtualizar)
        {
            JogoDomain JogoBuscado = _JogoRepository.BuscarPorId(JogoAtualizar.idJogo);

            if (JogoBuscado != null)
            {
                try
                {
                    _JogoRepository.Atualizar(JogoAtualizar);
                    return NoContent();
                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }

            return NotFound(new
            {
                mensagem = "Jogo não encontrado",
                Coderro = true
            });
        }
    }
}
