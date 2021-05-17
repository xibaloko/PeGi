using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace PeGi.util
{
    public class Mensagem
    {
        public enum TipoMensagem
        {
            Alerta = 1,
            Sucesso = 2,
            Erro = 3
        }

        public static void ExibirMensagem(Page page, TipoMensagem tipo, string titulo, string msg)
        {
            switch (tipo)
            {
                case TipoMensagem.Alerta:
                    msg = $"Atenção! \\n\\n {msg}";
                    break;
                case TipoMensagem.Sucesso:
                    msg = $"Sucesso! \\n\\n {msg}";
                    break;
                case TipoMensagem.Erro:
                    msg = $"Erro! \\n\\n {msg}";
                    break;
            }

            string script = $"alert('{msg}');";

            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "Alert", script, true);
        }
    }
}