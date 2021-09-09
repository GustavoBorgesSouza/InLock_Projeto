using senai_inlock_webAPI.Properties.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_inlock_webAPI.Properties.Interfaces
{/// <summary>
 /// Interface responsável pelo repositório JogoRepository
 /// </summary>
    interface IJogoRepository
    {
        /// <summary>
        /// Retorna todos os Jogos
        /// </summary>
        /// <returns>Uma lista de Jogos</returns>
        List<JogoDomain> ListarTodos();

        /// <summary>
        /// Busca um Jogo pelo id
        /// </summary>
        /// <param name="idProcurar">Id do Jogo a ser procurado</param>
        /// <returns>Um objeto do tipo JogoDomain</returns>
        JogoDomain BuscarPorId(int idProcurar);

        /// <summary>
        /// Cadastra um novo Jogo
        /// </summary>
        /// <param name="novoJogo">Objeto JogoDomain que será cadastrado</param>
        void Cadastrar(JogoDomain novoJogo);

        /// <summary>
        /// Atualiza um Jogoo já existente
        /// </summary>
        /// <param name="JogoAtualizado">Objeto JogoDomain que contém os atributos a serem atualizados</param>
        void Atualizar(JogoDomain JogoAtualizado);

        /// <summary>
        /// Deleta/exculi um Jogo
        /// </summary>
        /// <param name="idDeletar">Id do Jogo que será deletado</param>
        void Deletar(int idDeletar);
    }
}
