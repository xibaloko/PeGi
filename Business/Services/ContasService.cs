using Business.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class ContasService
    {
        public void CriarConta(string nomeConta, string saldo, int idUsuario, int idTipoConta)
        {
            DBSession session = new DBSession();

            string query = $"INSERT INTO Conta (NomeConta, Saldo, fk_Usuario_IdUsuario, fk_TipoConta_IdTipoConta)" +
                           $"VALUES ('{nomeConta}', {saldo}, {idUsuario}, {idTipoConta})";

            Query executar = session.CreateQuery(query);
            executar.ExecuteNonQuery();
        }

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
                    Saldo = double.Parse(reader["Saldo"].ToString()),
                    TipoConta = reader["TipoConta"].ToString()
                };

                contas.Add(conta);
            };

            return contas;
        } 


    }
}
