using Business.Models;
using System.Collections.Generic;
using System.Data;

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

        public void AlterarConta(int idConta, string nomeConta, int idTipoConta)
        {
            DBSession session = new DBSession();

            string query = $"UPDATE Conta " +
                           $"SET NomeConta = '{nomeConta}', fk_TipoConta_IdTipoConta = {idTipoConta} " +
                           $"WHERE IdConta = {idConta};";

            Query executar = session.CreateQuery(query);
            executar.ExecuteNonQuery();
        }

        public void DeletarConta(int idConta, int idUsuario)
        {
            DBSession session = new DBSession();

            string query = $"SELECT L.IdLancamento " +
                           $"FROM Lancamentos L " +
                           $"WHERE L.fk_Conta_IdConta = {idConta}";

            Query executar = session.CreateQuery(query);
            IDataReader reader = executar.ExecuteQuery();

            string queryDeletar;

            using (reader)
            {
                if (reader.Read())
                {
                    queryDeletar = $"DELETE FROM Lancamentos " +
                                   $"WHERE fk_Conta_IdConta = {idConta}; " +
                                   $"DELETE FROM Conta " +
                                   $"WHERE fk_Usuario_IdUsuario = {idUsuario} " +
                                   $"AND IdConta = {idConta};";
                }
                else
                {
                    queryDeletar = $"DELETE FROM Conta " +
                                   $"WHERE fk_Usuario_IdUsuario = {idUsuario} " +
                                   $"AND IdConta = {idConta};";
                }
            }

            Query deletar = session.CreateQuery(queryDeletar);
            deletar.ExecuteNonQuery();
        }

        public List<Conta> ExibirContas(int idUsuario)
        {
            DBSession session = new DBSession();

            string query = $"SELECT C.IdConta, C.NomeConta, C.Saldo, T.TipoConta " +
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
                    IdConta = int.Parse(reader["IdConta"].ToString()),
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
