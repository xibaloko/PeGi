using Business.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class DespesasService
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

        public void LancarDespesa(int idConta, string descricao, string valor, string dataLancamento)
        {
            DBSession session = new DBSession();

            string query = $"INSERT INTO Lancamentos (Descricao, Valor, DataLancamento, fk_Conta_IdConta, fk_TipoLancamento_IdTipoLancamento) " +
                           $"VALUES('{descricao}', {valor}, CONVERT(DATETIME, '{dataLancamento}', 121), {idConta}, 2)";

            Query executar = session.CreateQuery(query);
            executar.ExecuteNonQuery();
        }

        public List<Lancamento> ExibirLancamentos(int idConta)
        {
            DBSession session = new DBSession();

            string query = $"SELECT L.IdLancamento, L.Descricao, L.Valor, L.DataLancamento " +
                           $"FROM Lancamentos L " +
                           $"WHERE L.fk_Conta_IdConta = {idConta} " +
                           $"AND L.fk_TipoLancamento_IdTipoLancamento = 2 " +
                           $"AND DATEDIFF(day, L.DataLancamento , GETDATE()) < 30";

            Query executar = session.CreateQuery(query);
            IDataReader reader = executar.ExecuteQuery();

            List<Lancamento> lancamentos = new List<Lancamento>();

            while (reader.Read())
            {
                Lancamento despesa = new Lancamento()
                {
                    IdLancamento = int.Parse(reader["IdLancamento"].ToString()),
                    Descricao = reader["Descricao"].ToString(),
                    Valor = decimal.Parse(reader["Valor"].ToString()),
                    DataLancamento = DateTime.Parse(reader["DataLancamento"].ToString())
                };

                lancamentos.Add(despesa);
            };

            return lancamentos;
        }

        public void ExcluirLancamento(int idLancamento)
        {
            DBSession session = new DBSession();

            string query = $"DELETE FROM Lancamentos " +
                           $"WHERE IdLancamento = {idLancamento}";

            Query executar = session.CreateQuery(query);
            executar.ExecuteNonQuery();
        }
    }
}
