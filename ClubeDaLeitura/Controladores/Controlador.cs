using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.Controladores
{
    class Controlador
    {
        private object[] registros = new object[100];
        public object[] Registros { get => SelecionarTodosRegistros(); }
        public void Cadastrar(int id, object obj)
        {
            int posicao;

            if (id == 0)
            {
                posicao = ObterPosicaoVaga();
            }
            else
            {
                posicao = ObterPosicaoOcupada(obj);
            }

            registros[posicao] = obj;


        }
        public bool ExcluirRegistro(object obj)
        {
            bool conseguiuExcluir = false;

            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i] != null && registros[i].Equals(obj))
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
        private int ObterPosicaoOcupada(object obj)
        {
            int posicao = 0;

            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i] != null && registros[i].Equals(obj))
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
        protected object[] SelecionarTodosRegistros()
        {
            object[] registrosAux = new object[QtdRegistrosCadastrados()];

            int i = 0;

            foreach (object r in registros)
            {
                if (r != null)
                    registrosAux[i++] = r;
            }

            return registrosAux;
        }
        public object SelecionarRegistroPorId(object obj)
        {
            object registro = null;

            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i] != null && registros[i].Equals(obj))
                {
                    registro = registros[i];

                    break;
                }
            }
            return registro;
        }

    }
}