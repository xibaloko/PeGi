using Business.Models;
using System.Data;

namespace Business.Services
{
    public class LoginService
    {
        public Usuario ValidarUsuario(string usuario, string senha)
        {
            DBSession session = new DBSession();

            string query = $"SELECT U.Login, U.Senha, U.IdUsuario, U.Nome, U.Sobrenome FROM Usuario U WHERE U.Ativo = 1 AND U.Login ='{usuario}' AND U.Senha = '{senha}'";

            Query executar = session.CreateQuery(query);
            IDataReader reader = executar.ExecuteQuery();

            using (reader)
            {
                if (reader.Read())
                {
                    if (!string.IsNullOrEmpty(reader["Login"].ToString()))
                    {
                        Usuario user = new Usuario()
                        {
                            IdUsuario = int.Parse(reader["IdUsuario"].ToString()),
                            Login = reader["Login"].ToString(),
                            Nome = reader["Nome"].ToString(),
                            Sobrenome = reader["Sobrenome"].ToString()
                        };

                        return user;
                    }
                        
                }
                return null;
            }
        }
    }
}
