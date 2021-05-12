using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.Domínio
{
    class Amiguinho : Registro
    {
        string nome = "", nomeResponsavel = "", telefone = "", localidade = "";
        bool pegouLivro = false;
        public Amiguinho(string nome, string nomeResponsavel, string telefone, string localidade)
        {
            this.nome = nome;
            this.nomeResponsavel = nomeResponsavel;
            this.telefone = telefone;
            this.localidade = localidade;
        }
        public Amiguinho()
        {
            id = GeradorId.GerarIdAmiguinho();
        }
        public Amiguinho(int idSelecionado)
        {
            id = idSelecionado;
        }
        public string Nome { get => nome; }
        public override bool Validar()
        {
            bool valida = false;

            if (string.IsNullOrEmpty(nome))
                valida = false;
            else if (string.IsNullOrEmpty(nomeResponsavel))
                valida = false;
            else if (string.IsNullOrEmpty(telefone))
                valida = false;
            else if (string.IsNullOrEmpty(localidade))
                valida = false;
            else
                valida = true;

            return valida;
        }
        public override string ToString()
        {
            return "ID : " + id + "\nNome : " + this.nome + "\nNome do responsável : " + this.nomeResponsavel + "\nTelefone : " + this.telefone + "\nLocalidade : " + this.localidade;
        }
    }
}