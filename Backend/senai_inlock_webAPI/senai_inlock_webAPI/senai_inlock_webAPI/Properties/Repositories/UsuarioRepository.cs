using senai_inlock_webAPI.Properties.Domains;
using senai_inlock_webAPI.Properties.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_inlock_webAPI.Properties.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
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

        public UsuarioDomain BuscarPorEmailSenha(string email, string senha)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelect = "SELECT idUsuario, email, U.idTipoUsuario, titulo FROM Usuario U INNER JOIN TipoUsuario T ON T.idTipoUsuario = U.idTipoUsuario WHERE email = @email AND senha = @senha;";

                using (SqlCommand cmd = new SqlCommand (querySelect, con))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@senha", senha);

                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        UsuarioDomain usuarioBuscado = new UsuarioDomain()
                        {
                            idUsuario = Convert.ToInt32(rdr[0]),
                            Email = rdr[1].ToString(),
                            idTipoUsuario = Convert.ToInt32(rdr[2]),
                            TipoUsuario = new TipoUsuarioDomain()
                            {
                                titulo = rdr[3].ToString()
                            }
                        };

                        return usuarioBuscado;
                    }

                    return null;
                }
            }


        }
    }
}
