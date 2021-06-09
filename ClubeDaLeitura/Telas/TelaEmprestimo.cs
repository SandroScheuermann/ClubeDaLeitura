using ClubeDaLeitura.Controladores;
using ClubeDaLeitura.Domínio;
using System;

namespace ClubeDaLeitura.Telas
{
    class TelaEmprestimo : TelaBase<Emprestimo>
    {
        Controlador<Amiguinho> controladorAmiguinho;
        Controlador<Revista> controladorRevista;
        public TelaEmprestimo(Controlador<Emprestimo> controladorEmprestimo, Controlador<Amiguinho> controladorAmiguinho, Controlador<Revista> controladorRevista) : base(controladorEmprestimo, "Cadastro de Empréstimos\n")
        {
            this.controladorAmiguinho = controladorAmiguinho;
            this.controladorRevista = controladorRevista;
        }
        public override Emprestimo InserirNovoRegistro()
        {
            Amiguinho amiguinho;
            Revista revista;
            DateTime dataDevolucaoDate;
            string idAmiguinho, idRevista, dataDevolucao;
            int idAmiguinhoInt, idRevistaInt;
            Console.Clear();

            if (controladorAmiguinho.Registros.Count == 0 || controladorRevista.Registros.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("Não há AMIGUINHOS ou REVISTAS registradas!!!");
                return null;
            }
            else
            {
                while (true)
                {
                    Console.WriteLine("\nDigite o ID do amiguinho que quer fazer um empréstimo : ");
                    VisualizarRegistros(controladorAmiguinho.Registros);
                    idAmiguinho = Console.ReadLine();
                    Console.Clear();

                    if (int.TryParse(idAmiguinho, out idAmiguinhoInt))
                    {
                        amiguinho = controladorAmiguinho.Registros.Find(x => x.Id == idAmiguinhoInt);
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
                        revista = controladorRevista.Registros.Find(x => x.Id == idRevistaInt);

                        if (revista.Alugado)
                        {
                            Console.WriteLine("Revista já alugada!!!");
                            continue;
                        }

                        revista.Alugado = true;
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
        protected override string ObterOpcao()
        {
            Console.WriteLine("Controle de Empréstimos");

            Console.WriteLine("Digite 1 para inserir novo empréstimo");
            Console.WriteLine("Digite 2 para visualizar empréstimos em aberto");
            Console.WriteLine("Digite 3 para visualizar empréstimos abertos no mês");
            Console.WriteLine("Digite 4 para devolver um empréstimo");
            Console.WriteLine("Digite S para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }
        public override void Menu()
        {
            switch (ObterOpcao())
            {
                case "1": controlador.Cadastrar(InserirNovoRegistro()); break;

                case "2": VisualizaDiario(); break;

                case "3": VisualizaMes(); break;

                case "4": FechaEmprestimo(); break;

                default:
                    break;
            }
        }
        private void VisualizaMes()
        {
            int mesInt;
            string mes;

            Console.Clear();

            if (controlador.Registros.Count == 0)
            {
                Console.WriteLine("Não há empréstimos registrados!!");
            }
            else
            {
                while (true)
                {
                    Console.WriteLine("Digite o mês (mm) que deseja visualizar : ");
                    mes = Console.ReadLine();

                    if (int.TryParse(mes, out mesInt) && mesInt >= 1 && mesInt <= 12)
                    {
                        Console.Clear();
                        break;
                    }
                    Console.Clear();
                    Console.WriteLine("Digite um mês (mm) válido !!!\n");
                }
                Console.WriteLine("Empréstimos realizados no mês : " + mes);
                Console.WriteLine("------------------------------------------------------------");


                foreach (Emprestimo emprestimo in controlador.Registros)
                {
                    if (emprestimo.DataEmprestimo.Month.Equals(mesInt))
                    {
                        Console.WriteLine(emprestimo.ToString());

                        Console.WriteLine("\n------------------------------------------------------------");
                    }
                }
            }
        }
        private bool VisualizaDiario()
        {
            if (controlador.Registros.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("Não há empréstimos registrados!!");
                return false;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Empréstimos em aberto : ");
                Console.WriteLine("------------------------------------------------------------");

                foreach (Emprestimo emprestimo in controlador.Registros)
                {
                    if (emprestimo.Status.Equals("ABERTO"))
                    {
                        Console.WriteLine(emprestimo.ToString());

                        Console.WriteLine("\n------------------------------------------------------------");
                    }
                }
                return true;
            }
        }
        private void FechaEmprestimo()
        {
            if (VisualizaDiario())
            {
                Console.WriteLine("\nDigite o ID do empréstimo que deseja fechar : ");

                int idSelecionado = Convert.ToInt32(Console.ReadLine());

                if (controlador.Registros.Find(x => x.Id == idSelecionado) != null)
                {
                    Emprestimo emprestimo = (Emprestimo)controlador.Registros.Find(x => x.Id == idSelecionado);
                    Revista revista = (Revista)controladorRevista.Registros.Find(x => x.Id == emprestimo.Revista.Id);
                    revista.Alugado = false;
                    emprestimo.Status = "FECHADO";
                    Console.WriteLine("Empréstimo fechado com sucesso!!!\n");
                }
                else
                {
                    Console.WriteLine("Falha ao fechar empréstimo!!!");
                }
            }
        }
    }
}
