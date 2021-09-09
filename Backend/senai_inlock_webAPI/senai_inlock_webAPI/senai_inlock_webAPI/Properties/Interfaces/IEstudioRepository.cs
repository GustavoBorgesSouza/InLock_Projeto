using senai_inlock_webAPI.Properties.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_inlock_webAPI.Properties.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório EstudioRepository
    /// </summary>
    interface IEstudioRepository
    {
        /// <summary>
        /// Retorna todos os estudios
        /// </summary>
        /// <returns>Uma lista de estudios</returns>
        List<EstudioDomain> ListarTodos();

        /// <summary>
        /// Busca um estudio pelo id
        /// </summary>
        /// <param name="idProcurar">Id do estudio a ser procurado</param>
        /// <returns>Um objeto do tipo EstudioDomain</returns>
        EstudioDomain BuscarPorId(int idEstudio);

        /// <summary>
        /// Cadastra um novo Estudio
        /// </summary>
        /// <param name="novoEstudio">Objeto EstudioDomain que será cadastrado</param>
        void Cadastrar(EstudioDomain novoEstudio);

        /// <summary>
        /// Atualiza um Estudioo já existente
        /// </summary>
        /// <param name="estudioAtualizado">Objeto EstudioDomain que contém os atributos a serem atualizados</param>
        void Atualizar(int idEstudio,EstudioDomain estudioAtualizado);

        /// <summary>
        /// Deleta/exculi um estudio
        /// </summary>
        /// <param name="idDeletar">Id do estudio que será deletado</param>
        void Deletar(int idEstudio);
    }
}
