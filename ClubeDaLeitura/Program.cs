using System;
using ClubeDaLeitura.Telas;

namespace ClubeDaLeitura
{
    class Program
    {
        static void Main(string[] args)
        {
            TelaPrincipal telaPrincipal = new TelaPrincipal();

            while (true)
            {
                TelaBase telaSelecionada = telaPrincipal.ObterTela();

                if (telaSelecionada == null)
                    break;

                telaSelecionada.Menu();
            }
        }
    }
}
