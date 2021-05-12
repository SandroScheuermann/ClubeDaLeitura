using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.Domínio
{
    class Revista : Registro
    {
        string tipoColecao = "";
        int nEdicao,anoRevista;
        Caixa caixa;
        public Revista(string tipoColecao, int nEdicao, int anoRevista, Caixa caixa)
        {
            this.tipoColecao = tipoColecao;
            this.nEdicao = nEdicao;
            this.anoRevista = anoRevista;
            this.caixa = caixa;
        }
        public Revista()
        {
            id = GeradorId.GerarIdRevista();
        }
        public Revista(int idSelecionado)
        {
            id = idSelecionado;
        }
        public string TipoColecao { get => tipoColecao;}
        public override bool Validar()
        {
            bool valida = false;

            if (string.IsNullOrEmpty(TipoColecao))
                valida = false;
            else if (nEdicao < 0)
                valida = false;
            else if (anoRevista <= 0)
                valida = false;
            else if (caixa == null)
                valida = false;
            else
                valida = true;  

            return valida;
        }
        public override string ToString()
        {
            return "\nID : "+ id +"\nTipo de coleção : " + this.tipoColecao + "\nNúmero de edição : " + this.nEdicao + "\nAno da revista : " +
                this.anoRevista + "\nCaixa da revista : " + this.anoRevista;
        }

    }
}
