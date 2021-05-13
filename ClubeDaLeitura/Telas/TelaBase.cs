using System;
using ClubeDaLeitura.Domínio;
using ClubeDaLeitura.Controladores;

namespace ClubeDaLeitura.Telas
{
    abstract class TelaBase
    {
        protected Controlador controlador;

        string titulo = "";
        public TelaBase(Controlador controlador, string titulo)
        {
            Console.Clear();
            this.controlador = controlador;
            this.titulo = titulo;
        }
        protected virtual string ObterOpcao()
        {
            Console.WriteLine(titulo);

            Console.WriteLine("Digite 1 para inserir novo registro");
            Console.WriteLine("Digite 2 para visualizar registros");
            Console.WriteLine("Digite 3 para editar um registro");
            Console.WriteLine("Digite 4 para excluir um registro");

            Console.WriteLine("Digite S para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }
        public void ExcluirRegistro()
        {
            VisualizarRegistros(controlador.Registros);

            Console.WriteLine("\nDigite o ID do registro que deseja excluir :");

            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            bool conseguiuExcluir = controlador.ExcluirRegistro(controlador.SelecionarRegistroPorId(idSelecionado));

            if (conseguiuExcluir)
            {
                Console.WriteLine("\nRegistro excluído com sucesso!");
            }
            else
            {
                Console.WriteLine("\nFalha ao tentar excluir o registro");
                ExcluirRegistro();
            }

        }
        public abstract Registro InserirNovoRegistro();
        public void EditarRegistro()
        {
            VisualizarRegistros(controlador.Registros);

            Console.WriteLine("\nDigite o ID do registro que deseja editar :");

            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            Registro registro = InserirNovoRegistro();
            controlador.Editar(idSelecionado, registro);


            if (registro.Validar())
            {
                Console.Clear();
                Console.WriteLine("Registro editado com sucesso!!!");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Falha ao editar registro!!!");
            }
        }
        protected bool VisualizarRegistros(Registro[] array)
        {
            if (array.Length == 0)
            {
                Console.Clear();
                Console.WriteLine("Não há registros cadastrados!!!\n");
                return false;
            }
            else
            {
                for (int i = 0; i < array.Length; i++)
                {
                    Console.WriteLine();
                    Console.WriteLine(array[i]);
                }
                return true;
            }
        }
        public virtual void Menu()
        {
            switch (ObterOpcao())
            {
                case "1":
                    controlador.Cadastrar(0, InserirNovoRegistro()); break;

                case "2":
                    Console.Clear();
                    VisualizarRegistros(controlador.Registros); break;

                case "3":
                    EditarRegistro(); break;

                case "4":
                    ExcluirRegistro(); break;

                default:
                    break;
            }
        }
    }
}
