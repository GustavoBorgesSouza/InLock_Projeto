using senai_inlock_webAPI.Properties.Domains;
using senai_inlock_webAPI.Properties.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_inlock_webAPI.Properties.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        //Conecta pelo windows de casa do borges
        /// <summary>
        /// String de conexão que recebe os parâmetros
        /// Data Source = Nome do Servidor
        /// initial  catalog = Nome do banco de dados
        /// user id= sa; pwd= Senai@132 = Faz a autenticação com o SQL SERVER, passando login e senha
        /// integrated security = Faz a autenticação com o usuário do sistema(windows)
        /// </summary>
        private string stringConexao = "Data Source=localhost\\SQLEXPRESS01; initial catalog=inlock_games_manha; integrated security=true";

        /// <summary>
        /// Conecta pelo pc do rezende
        /// </summary>
        //private string stringConexao = @"Data Source=DESKTOP-5BM5L8P\SQLEXPRESS; initial catalog=inlock_games_manha; user id=sa; pwd=Senai@132;";

        public void Atualizar(JogoDomain JogoAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdate = "UPDATE Jogo Set idEstudio = @novoEstudio, nomeJogo = @novoNome, descricao = @novaDescricao, dataLancamento = @novaDataL, valor = @novoValor WHERE idJogo = @ID;";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryUpdate,con))
                {
                    cmd.Parameters.AddWithValue("@novoEstudio", JogoAtualizado.idEstudio);
                    cmd.Parameters.AddWithValue("@novoNome", JogoAtualizado.nomeJogo);
                    cmd.Parameters.AddWithValue("@novaDescricao", JogoAtualizado.descricao);
                    cmd.Parameters.AddWithValue("@novaDataL", JogoAtualizado.dataLancamento);
                    cmd.Parameters.AddWithValue("@novoValor", JogoAtualizado.valor);

                    cmd.Parameters.AddWithValue("@ID", JogoAtualizado.idJogo);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public JogoDomain BuscarPorId(int idProcurar)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectbyId = "SELECT idJogo, nomeEstudio, nomeJogo, descricao, dataLancamento, valor FROM Jogo LEFT JOIN Estudio ON Jogo.idEstudio = Estudio.idEstudio WHERE idJogo = @ID;";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectbyId, con))
                {
                    cmd.Parameters.AddWithValue("@ID", idProcurar);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        JogoDomain jogoBuscado = new JogoDomain()
                        {
                            idJogo = Convert.ToInt32(rdr[0]),
                            estudio = new EstudioDomain()
                            {
                                nomeEstudio = rdr[1].ToString()
                            },
                            nomeJogo = rdr[2].ToString(),
                            descricao = rdr[3].ToString(),
                            dataLancamento = Convert.ToDateTime(rdr[4]),
                            valor = Convert.ToInt32(rdr[5])
                        };

                        return jogoBuscado;
                    }
                }
            }

            return null;
        }

        public void Cadastrar(JogoDomain novoJogo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = @"INSERT INTO Jogo(idEstudio,nomeJogo,descricao,dataLancamento,valor)
                VALUES(@novoEstudio, @novoNome, @novaDescricao, @novaDataL, @novoValor)";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@novoEstudio", novoJogo.idEstudio);
                    cmd.Parameters.AddWithValue("@novoNome", novoJogo.nomeJogo);
                    cmd.Parameters.AddWithValue("@novaDescricao", novoJogo.descricao);
                    cmd.Parameters.AddWithValue("@novaDataL", novoJogo.dataLancamento);
                    cmd.Parameters.AddWithValue("@novoValor", novoJogo.valor);

                    cmd.ExecuteNonQuery();
                };
            }
        }

        public void Deletar(int idDeletar)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM Jogo WHERE idJogo = @idJogo;";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@idJogo", idDeletar);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<JogoDomain> ListarTodos()
        {
            List<JogoDomain> ListaJogos = new List<JogoDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT idJogo, nomeEstudio, nomeJogo, descricao, dataLancamento, valor FROM Jogo LEFT JOIN Estudio ON Jogo.idEstudio = Estudio.idEstudio;";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        JogoDomain jogo = new JogoDomain()
                        {
                            idJogo = Convert.ToInt32(rdr[0]),
                            estudio = new EstudioDomain()
                            {
                                nomeEstudio = rdr[1].ToString()
                            },
                            nomeJogo = rdr[2].ToString(),
                            descricao = rdr[3].ToString(),
                            dataLancamento = Convert.ToDateTime(rdr[4]),
                            valor = Convert.ToInt32(rdr[5])
                        };

                        ListaJogos.Add(jogo);
                    }
                }

                return ListaJogos;
            }
        }
    }
}
