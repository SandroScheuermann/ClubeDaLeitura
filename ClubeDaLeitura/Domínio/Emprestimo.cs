﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.Domínio
{
    class Emprestimo : Registro
    {
        Amiguinho amiguinho;
        Revista revista;
        DateTime dataEmprestimo, dataDevolucao;
        string status = "FECHADO";
        public DateTime DataEmprestimo { get => dataEmprestimo; }
        public string Status { get => status; set => status = value; }
        internal Revista Revista { get => revista; set => revista = value; }

        public Emprestimo(Amiguinho amiguinho, Revista revista, DateTime dataEmprestimo, DateTime dataDevolucao)
        {
            this.amiguinho = amiguinho;
            this.revista = revista;
            this.dataEmprestimo = dataEmprestimo;
            this.dataDevolucao = dataDevolucao;
            id = GeradorId.GerarIdEmprestimo();
            status = "ABERTO";
        }

        public override bool Validar()
        {
            bool valida = false;

            if (amiguinho == null)
                valida = false;
            else if (revista == null)
                valida = false;
            else if (dataEmprestimo > DateTime.Now || dataEmprestimo == null)
                valida = false;
            else if (dataDevolucao == null)
                valida = false;
            else
                valida = true;

            return valida;
        }
        public override string ToString()
        {
            return "\nAmiguinho : " + this.amiguinho.Nome + "\nRevista : " + this.revista.TipoColecao +
                "\nData de Empréstimo : " + dataEmprestimo.ToString("dd/MM/yyyy") + "\nData de devolução : " + dataDevolucao.ToString("dd/MM/yyyy")
                +"\nID : "+ Id +"\nStatus do empréstimo : " + status;
        }
    }
}
