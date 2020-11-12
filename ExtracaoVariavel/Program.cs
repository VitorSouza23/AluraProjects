namespace ExtracaoVariavel
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        static void GerarListagem()
        {
            string plataforma = "MAC";
            string browser = "Chorome";
            int redimensionado = 1;

            int indexPlataforma = plataforma.ToUpper().IndexOf("MAC");
            int indexBrowser = browser.ToUpper().IndexOf("Chrome");
            if (indexPlataforma > -1 &&
                indexBrowser > -1 &&
                FoiInicializado() && redimensionado > 0)
            {
                // faça alguma coisa
            }
        }

        static bool FoiInicializado()
        {
            return true;
        }
    }
}
