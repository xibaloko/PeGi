using Business.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class ReceitasService
    {
        public List<DDListConta> CarregaListaContas(int idUsuario)
        {
            DBSession session = new DBSession();

            string query = $"SELECT C.IdConta, C.NomeConta " +
                           $"FROM Conta C " +
                           $"WHERE C.fk_Usuario_IdUsuario = {idUsuario}";

            Query executar = session.CreateQuery(query);
            IDataReader reader = executar.ExecuteQuery();

            List<DDListConta> contas = new List<DDListConta>();

            while (reader.Read())
            {
                DDListConta conta = new DDListConta()
                {
                    IdConta = int.Parse(reader["IdConta"].ToString()),
                    NomeConta= reader["NomeConta"].ToString()
                };

                contas.Add(conta);
            };

            return contas;
        }
    }
}
