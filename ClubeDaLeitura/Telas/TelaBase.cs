using System;
using ClubeDaLeitura.Domínio;
using ClubeDaLeitura.Controladores;
using System.Collections.Generic;

namespace ClubeDaLeitura.Telas
{
    abstract class TelaBase <T> where T : Registro
    {
        protected Controlador<T> controlador;

        string titulo = "";
        public TelaBase(Controlador<T> controlador, string titulo)
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
            if (controlador.Registros.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("Não há registros cadastrados!!!");
            }
            else
            {
                VisualizarRegistros(controlador.Registros);

                Console.WriteLine("\nDigite o ID do registro que deseja excluir :");

                int idSelecionado = Convert.ToInt32(Console.ReadLine());

                bool conseguiuExcluir = controlador.ExcluirRegistro(idSelecionado);

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
        }
        public abstract T InserirNovoRegistro();
        public void EditarRegistro()
        {
            if (controlador.Registros.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("Não há registros cadastrados!!!");
            }
            else
            {
                VisualizarRegistros(controlador.Registros);

                Console.WriteLine("\nDigite o ID do registro que deseja editar :");

                int idSelecionado = Convert.ToInt32(Console.ReadLine());

                T registro = InserirNovoRegistro();
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
        }
        protected bool VisualizarRegistros(dynamic lista)
        {
            if (lista.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("Não há registros cadastrados!!!\n");
                return false;
            }
            else
            {
                for (int i = 0; i < lista.Count; i++)
                {
                    Console.WriteLine();
                    Console.WriteLine(lista[i]);
                }
                return true;
            }
        }
        public virtual void Menu()
        {
            switch (ObterOpcao())
            {
                case "1":
                    controlador.Cadastrar(InserirNovoRegistro()); break;

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
