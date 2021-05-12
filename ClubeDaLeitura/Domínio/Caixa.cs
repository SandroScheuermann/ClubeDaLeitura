using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.Domínio
{
    class Caixa : Registro
    {
        string cor = "", etiqueta ="";
        int numeroCaixa;
        public Caixa(string cor, string etiqueta, int numeroCaixa)
        {
            this.cor = cor;
            this.etiqueta = etiqueta;
            this.numeroCaixa = numeroCaixa;
        }
        public Caixa()
        {
            id = GeradorId.GerarIdCaixa();
        }
        public Caixa(int idSelecionado)
        {
            id = idSelecionado;
        }
        public int NumeroCaixa { get => numeroCaixa;}
        public override bool Validar()
        {
            bool valida = false;

            if (string.IsNullOrEmpty(cor))
                valida = false;
            else if (string.IsNullOrEmpty(etiqueta))
                valida = false;
            else if (NumeroCaixa<=0)
                valida = false;
            else
                valida = true;

            return valida;
        }
        public override string ToString()
        {
            return "\nID : " + this.id + "\nCor : " + this.cor + "\nEtiqueta : " + this.etiqueta + "\nNumero da Caixa : " + this.NumeroCaixa;
        }

    }
}
