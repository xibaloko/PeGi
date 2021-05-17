using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class LoginService
    {
        public bool ValidarUsuario(string usuario, string senha)
        {
            DBSession session = new DBSession();

            string query = $"SELECT U.Login, U.Senha FROM Usuario U WHERE (1=1) AND U.Ativo = 1 AND U.Login ='{usuario}' AND U.Senha = '{senha}'";

            Query executar = session.CreateQuery(query);
            IDataReader reader = executar.ExecuteQuery();

            using (reader)
            {
                if (reader.Read())
                {
                    if (!string.IsNullOrEmpty(reader["Login"].ToString()))
                        return true;
                }
                return false;
            }
        }
    }
}
