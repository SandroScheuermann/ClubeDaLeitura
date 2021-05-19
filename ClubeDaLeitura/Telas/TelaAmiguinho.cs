using ClubeDaLeitura.Controladores;
using ClubeDaLeitura.Domínio;
using System;

namespace ClubeDaLeitura.Telas
{
    class TelaAmiguinho : TelaBase
    {
        Controlador controladorAmiguinho;
        public TelaAmiguinho(Controlador controladorAmiguinho) : base(controladorAmiguinho, "Cadastro de Amiguinhos\n")
        {
            this.controladorAmiguinho = controladorAmiguinho;
        }
        public override Registro InserirNovoRegistro()
        {
            string nome = "", nomeResponsavel = "", telefone = "", localidade = "";

            Console.Clear();

            while (true)
            {
                Console.WriteLine("\nDigite o nome do amiguinho : ");
                nome = Console.ReadLine();
                Console.Clear();

                if (!string.IsNullOrEmpty(nome)) break;

                Console.WriteLine("O nome do amiguinho é obrigatório!!!");
            }

            while (true)
            {
                Console.WriteLine("\nDigite o nome do responsável : ");
                nomeResponsavel = Console.ReadLine();
                Console.Clear();

                if (!string.IsNullOrEmpty(nomeResponsavel)) break;

                Console.WriteLine("O nome do responsável é obrigatório!!!");
            }

            while (true)
            {
                Console.WriteLine("\nDigite o número de telefone : ");
                telefone = Console.ReadLine();
                Console.Clear();

                if (!string.IsNullOrEmpty(telefone)) break;

                Console.WriteLine("O número do telefone obrigatório!!! ");
            }

            while (true)
            {
                Console.WriteLine("\nDigite a localidade do amiguinho : ");
                localidade = Console.ReadLine();
                Console.Clear();

                if (!string.IsNullOrEmpty(localidade)) break;

                Console.WriteLine("A localidade do amiguinho é obrigatória!!!");
            }
            Amiguinho amiguinho = new Amiguinho(nome, nomeResponsavel, telefone, localidade);
            return amiguinho;
        }
    }
}