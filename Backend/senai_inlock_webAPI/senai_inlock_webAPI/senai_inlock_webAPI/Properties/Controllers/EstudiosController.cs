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
    public class EstudiosController : Controller
    {
       private IEstudioRepository _estudioRepository { get; set; }

        public EstudiosController()
        {
            _estudioRepository = new EstudioRepository();
        }

        [HttpGet]
        // IActionResult = Resultado de uma ação
        // Get() = nome generico
        public IActionResult Get()
        {

            // Lista de Estúdios
            // se conectar com o Repositório.

            // Criar uma lista nomeada listaEstudios para receber os dados.
            List<EstudioDomain> listaEstudio = _estudioRepository.ListarTodos();


            // Retorna o status code 200(OK) com a lista estúdios no formato JSON
            return Ok(listaEstudio);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            EstudioDomain estudioBuscado = _estudioRepository.BuscarPorId(id);

            if (estudioBuscado == null)
            {
                return NotFound("Nenhum estúdio encontrado!");
            }

            return Ok(estudioBuscado);
        }


        [HttpPost]
        public IActionResult Post(EstudioDomain novoEstudio)
        {
            // Fazer a chamada para o método .Cadastrar();
            _estudioRepository.Cadastrar(novoEstudio);

            // Retorna Status Code 201 - Created.
            return StatusCode(201);

        }

        [HttpPut("{id}")]
        public IActionResult PutUrl(int id, EstudioDomain estudioAtualizado)
        {
            EstudioDomain estudioBuscado = _estudioRepository.BuscarPorId(id);

            if (estudioBuscado == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "Estúdio não encontrado!",
                        erro = true
                    });
            }

            try
            {
                _estudioRepository.Atualizar(id, estudioAtualizado);

                return NoContent();

            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _estudioRepository.Deletar(id);

            return StatusCode(204);
        }

    }
}
