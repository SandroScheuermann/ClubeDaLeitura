using System;
using ClubeDaLeitura.Domínio;
using ClubeDaLeitura.Controladores;

namespace ClubeDaLeitura.Telas
{
    abstract class TelaBase
    {
        protected Controlador controlador;
        public TelaBase(Controlador controlador)
        {
            this.controlador = controlador;
        }
        public string ObterOpcao()
        {
            Console.WriteLine("Digite 1 para inserir novo registro");
            Console.WriteLine("Digite 2 para visualizar registros");
            Console.WriteLine("Digite 3 para editar um registro");
            Console.WriteLine("Digite 4 para excluir um registro");

            Console.WriteLine("Digite S para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }
        protected bool VisualizarRegistros(Object[] array)
        {
            if (array.Length == 0)
            {
                Console.WriteLine("Não há registros cadastrados!!!");
                return false;
            }
            else
            {
                for (int i = 0; i < array.Length; i++)
                {
                    Console.WriteLine(array[i]);
                }
                return true;
            }
        }
        public void ExcluirRegistro()
        {
            VisualizarRegistros(controlador.Registros);

            Console.WriteLine("\nDigite o ID do registro que deseja excluir :");

            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            bool conseguiuExcluir = controlador.ExcluirRegistro(controlador.Registros[idSelecionado]);

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

            if (registro.Validar())
            {
                Console.Clear();
                Console.WriteLine("Registro editada com sucesso!!!");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Falha ao editar registro!!!");
            }
        }
    }
}