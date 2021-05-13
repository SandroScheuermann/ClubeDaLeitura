using ClubeDaLeitura.Domínio;
using ClubeDaLeitura.Controladores;
using System;

namespace ClubeDaLeitura.Telas
{
    class TelaPrincipal
    {
        private readonly Controlador controlador = new Controlador();
        private readonly Controlador controladorAmiguinho = new Controlador();
        private readonly Controlador controladorCaixa = new Controlador();
        private readonly Controlador controladorRevista = new Controlador();
        private readonly Controlador controladorEmprestimo = new Controlador();
        public TelaBase ObterTela()
        {
            TelaBase telaSelecionada = null;
            string opcao;

            Console.WriteLine("\nDigite 1 para a tela de Amiguinhos");
            Console.WriteLine("Digite 2 para a tela de Caixas");
            Console.WriteLine("Digite 3 para a tela de Revistas");
            Console.WriteLine("Digite 4 para a tela de Empréstimos");
            Console.WriteLine("Digite S para Sair");

            opcao = Console.ReadLine();
            Console.Clear();

            if (opcao == "1")
                telaSelecionada = new TelaAmiguinho(controladorAmiguinho);

            else if (opcao == "2")
                telaSelecionada = new TelaCaixa(controladorCaixa);

            else if (opcao == "3")
                telaSelecionada = new TelaRevista(controladorRevista, controladorCaixa);

            else if (opcao == "4")
                telaSelecionada = new TelaEmprestimo(controladorEmprestimo, controladorAmiguinho, controladorRevista);

            return telaSelecionada;
        }

    }
}
