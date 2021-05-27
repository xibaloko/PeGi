namespace PeGi.util
{
    public static class UsoGeral
    {
        public static bool CampoNaoDecimal(string valor)
        {
            if (!decimal.TryParse(valor, out decimal result))
            {
                return true;
            }

            int numChars = valor.Length;

            if (numChars < 4)
            {
                return true;
            }

            if (valor.Substring(numChars - 3, 1) != ".")
            {
                return true;
            }

            return false;
        }
    }
}