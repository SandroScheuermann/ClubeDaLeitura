using System;
using ClubeDaLeitura.Domínio;

namespace ClubeDaLeitura.Controladores
{
    class Controlador
    {
        private Registro[] registros = new Registro[100];
        public Registro[] Registros { get => SelecionarTodosRegistros(); }

        public void Editar(int id, Registro registro)
        {
            int posicao = ObterPosicaoOcupada(registro);
            registros[posicao] = registro;

        }
        public void Cadastrar(int id, Registro registro)
        {
            int posicao = ObterPosicaoVaga();          
            registros[posicao] = registro;
        }
        public bool ExcluirRegistro(Registro registro)
        {
            bool conseguiuExcluir = false;

            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i] != null && registros[i].Equals(registro))
                {
                    registros[i] = null;
                    conseguiuExcluir = true;
                    break;
                }
            }
            return conseguiuExcluir;
        }
        private int ObterPosicaoVaga()
        {
            int posicao = 0;

            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i] == null)
                {
                    posicao = i;
                    break;
                }
            }
            return posicao;
        }
        private int ObterPosicaoOcupada(Registro registro)
        {
            int posicao = 0;

            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i] != null && registros[i].Equals(registro))
                {
                    posicao = i;
                    break;
                }
            }
            return posicao;
        }
        protected int QtdRegistrosCadastrados()
        {
            int numeroRegistrosCadastrados = 0;

            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i] != null)
                {
                    numeroRegistrosCadastrados++;
                }
            }

            return numeroRegistrosCadastrados;
        }
        private Registro[] SelecionarTodosRegistros()
        {
            Registro[] registrosAux = new Registro[QtdRegistrosCadastrados()];

            int i = 0;

            foreach (Registro r in registros)
            {
                if (r != null)
                    registrosAux[i++] = r;
            }

            return registrosAux;
        }
        public Registro SelecionarRegistroPorId(int id)
        {
            Registro registro = null;

            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i] != null && registros[i].Id == id)
                {
                    registro = registros[i];
                    break;
                }
            }
            return registro;
        }
    }
}