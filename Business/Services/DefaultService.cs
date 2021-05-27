using Business.Models;
using System.Collections.Generic;
using System.Data;

namespace Business.Services
{
    public class DefaultService
    {
        public List<Conta> ExibirContas(int idUsuario)
        {
            DBSession session = new DBSession();

            string query = $"SELECT C.NomeConta, C.Saldo, T.TipoConta " +
                           $"FROM Conta C " +
                           $"INNER JOIN TipoConta T " +
                           $"ON C.fk_TipoConta_IdTipoConta = T.IdTipoConta " +
                           $"WHERE C.fk_Usuario_IdUsuario = {idUsuario};";

            Query executar = session.CreateQuery(query);
            IDataReader reader = executar.ExecuteQuery();

            List<Conta> contas = new List<Conta>();

            while (reader.Read())
            {
                Conta conta = new Conta()
                {
                    NomeConta = reader["NomeConta"].ToString(),
                    Saldo = decimal.Parse(reader["Saldo"].ToString()),
                    TipoConta = reader["TipoConta"].ToString()
                };

                contas.Add(conta);
            };

            return contas;
        }
    }
}
