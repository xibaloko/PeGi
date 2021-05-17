using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class CadastroService
    {
        public bool UsuarioJaExiste(string username)
        {
            DBSession session = new DBSession();

            string query = $"SELECT U.Login FROM Usuario U WHERE U.Login ='{username}'";

            Query executar = session.CreateQuery(query);
            IDataReader reader = executar.ExecuteQuery();

            using (reader)
            {
                if (reader.Read()) return true;

                return false;
            }
        }
        public void CadastrarNovoUsuario(string nome, string sobrenome, string email, string username, string senha)
        {
            DBSession session = new DBSession();

            string query = $"INSERT INTO Usuario (Nome, Sobrenome, Email, Login, Senha, Ativo)" +
                           $"VALUES ('{nome}', '{sobrenome}', '{email}', '{username}', '{senha}', 1)";

            Query executar = session.CreateQuery(query);
            executar.ExecuteNonQuery();
        }
    }
}
