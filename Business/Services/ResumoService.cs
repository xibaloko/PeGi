using Business.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace Business.Services
{
    public class ResumoService
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
                    NomeConta = reader["NomeConta"].ToString()
                };

                contas.Add(conta);
            };

            return contas;
        }

        public List<Resumo> ExibirResumo(int idConta, string dataInicio, string dataFinal)
        {
            DBSession session = new DBSession();

            string query = $"SELECT L.Descricao, L.Valor, T.TipoLancamento, L.DataLancamento " +
                           $"FROM Lancamentos L " +
                           $"INNER JOIN TipoLancamento T " +
                           $"ON T.IdTipoLancamento = L.fk_TipoLancamento_IdTipoLancamento " +
                           $"WHERE L.DataLancamento BETWEEN CONVERT(DATETIME, '{dataInicio}', 121) AND CONVERT(DATETIME, '{dataFinal}', 121) " +
                           $"AND L.fk_Conta_IdConta = {idConta} " +
                           $"ORDER BY L.DataLancamento";

            Query executar = session.CreateQuery(query);
            IDataReader reader = executar.ExecuteQuery();

            List<Resumo> resumo = new List<Resumo>();

            while (reader.Read())
            {
                Resumo itemResumo = new Resumo()
                {

                    Descricao = reader["Descricao"].ToString(),
                    TipoLancamento = reader["TipoLancamento"].ToString(),
                    DataLancamento = DateTime.Parse(reader["DataLancamento"].ToString()),
                    Valor = decimal.Parse(reader["Valor"].ToString())
                };

                resumo.Add(itemResumo);
            };

            return resumo;
        }

        public decimal RetornarSaldoConta(int idUsuario, int idConta)
        {
            DBSession session = new DBSession();

            string query = $"SELECT C.Saldo " +
                           $"FROM Conta C " +
                           $"WHERE C.fk_Usuario_IdUsuario = {idUsuario} " +
                           $"AND C.IdConta = {idConta};";

            Query executar = session.CreateQuery(query);
            IDataReader reader = executar.ExecuteQuery();

            decimal saldo = 0;

            while (reader.Read())
            {
                saldo = decimal.Parse(reader["Saldo"].ToString());
            };

            return saldo;
        }
    }
}
