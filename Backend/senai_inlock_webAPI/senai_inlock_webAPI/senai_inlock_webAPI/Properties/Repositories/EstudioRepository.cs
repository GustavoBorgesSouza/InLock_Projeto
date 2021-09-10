using senai_inlock_webAPI.Properties.Domains;
using senai_inlock_webAPI.Properties.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_inlock_webAPI.Properties.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        private string stringConexao = @"Data Source=DESKTOP-5BM5L8P\SQLEXPRESS; initial catalog=inlock_games_manha; user id=sa; pwd=Senai@132;";
        public void Atualizar(int idEstudio, EstudioDomain estudioAtualizado)
        {
            if (estudioAtualizado.nomeEstudio != null)
            {
                using (SqlConnection con = new SqlConnection(stringConexao))
                {
                    string queryUpdateBody = "UPDATE Estudio SET nomeEstudio = @novoNome WHERE idEstudio = @idEstudio;";

                    using (SqlCommand cmd = new SqlCommand(queryUpdateBody, con))
                    {
                        cmd.Parameters.AddWithValue("@idEstudio", idEstudio);
                        cmd.Parameters.AddWithValue("@novoNome", estudioAtualizado.nomeEstudio);
                       
                        con.Open();

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public EstudioDomain BuscarPorId(int idEstudio)
        {
            EstudioDomain buscarEstudio = new EstudioDomain();
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySearchById = "SELECT idEstudio, nomeEstudio FROM Estudio WHERE idEstudio= @idEstudio;";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySearchById, con))
                {
                    cmd.Parameters.AddWithValue("@idEstudio", idEstudio);
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        buscarEstudio.idEstudio = Convert.ToInt32(rdr[0]);
                        buscarEstudio.nomeEstudio = rdr[1].ToString();
             
                    }
                    return (buscarEstudio);
                }
            }
        }

        public void Cadastrar(EstudioDomain novoEstudio)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query que será executada

                string queryInsert = "INSERT INTO Estudio (nomeEstudio) VALUES (@nomeEstudio)";

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    // Passa o valor do parâmetro @nomeEstudio
                    cmd.Parameters.AddWithValue("@nomeEstudio", novoEstudio.nomeEstudio);
     
                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa a query
                    cmd.ExecuteNonQuery();

                }
            }
        }

        public void Deletar(int idEstudio)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM Estudio WHERE idEstudio = @id";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@id", idEstudio);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<EstudioDomain> ListarTodos()
        {
            List<EstudioDomain> listaEstudios = new List<EstudioDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT * FROM Estudio;";

                // Abre a conexão com o banco de dados, como se fosse no ssms "Conectar"
                con.Open();

                // Declarando SqlDataReader rdr percorrer a tabela do nosso banco de dados
                SqlDataReader rdr;

                // Declara SqlCommand passando a query que será executada e a conexão com parâmetros.
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {

                    // executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    // Enquanto houver registros para serem lidos no rdr, o laço se repete.
                    while (rdr.Read())
                    {
                        // instancia um objeto estudio do tipo EstudioDomain
                        EstudioDomain estudio = new EstudioDomain()
                        {

                            idEstudio = Convert.ToInt32(rdr[0]),

                            nomeEstudio = rdr[1].ToString(),

                        };

                        // Adiciona o objeto estudio criado a lista listaEstudios
                        listaEstudios.Add(estudio);

                    }
                }
            };
            return listaEstudios;
        }
    }
}

