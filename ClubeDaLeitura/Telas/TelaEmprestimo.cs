using ClubeDaLeitura.Controladores;
using ClubeDaLeitura.Domínio;
using System;

namespace ClubeDaLeitura.Telas
{
    class TelaEmprestimo : TelaBase
    {
        Controlador controladorAmiguinho;
        Controlador controladorRevista;

        public TelaEmprestimo(Controlador controladorEmprestimo, Controlador controladorAmiguinho, Controlador controladorRevista) : base(controladorEmprestimo, "Cadastro de Empréstimos\n")
        {
            this.controladorAmiguinho = controladorAmiguinho;
            this.controladorRevista = controladorRevista;

        }
        public override Registro InserirNovoRegistro()
        {            
            Amiguinho amiguinho;
            Revista revista;
            DateTime dataDevolucaoDate;
            string idAmiguinho,idRevista, dataDevolucao;
            int idAmiguinhoInt,idRevistaInt;
            Console.Clear();

            while (true)
            {
                Console.WriteLine("\nDigite o ID do amiguinho que quer fazer um empréstimo : ");
                VisualizarRegistros(controladorAmiguinho.Registros);
                idAmiguinho = Console.ReadLine();
                Console.Clear();

                if (int.TryParse(idAmiguinho, out idAmiguinhoInt))
                {
                    amiguinho = (Amiguinho)controladorAmiguinho.SelecionarRegistroPorId(idAmiguinhoInt);
                    break;
                }

                Console.WriteLine("Digite um ID correto!!!");
            }
            while (true)
            {
                Console.WriteLine("\nDigite o ID da revista que foi emprestada : ");
                VisualizarRegistros(controladorRevista.Registros);
                idRevista = Console.ReadLine();
                Console.Clear();

                if (int.TryParse(idRevista, out idRevistaInt))
                {
                    revista = (Revista)controladorRevista.SelecionarRegistroPorId(idRevistaInt);
                    break;
                }

                Console.WriteLine("Digite um ID correto!!!");
            }
            while (true)
            {
                Console.WriteLine("\nDigite a data de devolução : ");

                dataDevolucao = Console.ReadLine();

                if (DateTime.TryParse(dataDevolucao, out dataDevolucaoDate)) { break; }

                Console.WriteLine("Digite uma data correta!!!");
            }
            
            return new Emprestimo(amiguinho, revista, DateTime.Now, dataDevolucaoDate);

        }
    }
}
