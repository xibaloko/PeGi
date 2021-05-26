using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class ResumoService
    {
        /*
         *  SELECT L.Descricao, L.Valor, T.TipoLancamento, L.DataLancamento
            FROM Lancamentos L
            INNER JOIN TipoLancamento T
            ON T.IdTipoLancamento = L.fk_TipoLancamento_IdTipoLancamento
            WHERE L.DataLancamento BETWEEN CONVERT(DATETIME, '2021-05-15', 121) AND CONVERT(DATETIME, '2021-05-23', 121)
            AND L.fk_Conta_IdConta = 15
            ORDER BY L.DataLancamento
        *
        */
    }
}
