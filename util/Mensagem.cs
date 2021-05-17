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

        }
    }
}