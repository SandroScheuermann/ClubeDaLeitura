﻿using ClubeDaLeitura.Controladores;
using ClubeDaLeitura.Domínio;
using System;

namespace ClubeDaLeitura.Telas
{
    class TelaCaixa : TelaBase<Caixa>
    {
        public TelaCaixa(Controlador<Caixa> controladorCaixa) : base(controladorCaixa, "Cadastro de Caixas\n") { }
        public override Caixa InserirNovoRegistro()
        {
            string etiqueta = "", cor = "", nCaixa = "";
            int nCaixaInt = 0;
            Console.Clear();

            while (true)
            {
                Console.WriteLine("\nDigite a cor da caixa : ");
                cor = Console.ReadLine();
                Console.Clear();

                if (!string.IsNullOrEmpty(cor)) break;

                Console.WriteLine("A cor da caixa é obrigatória!!!");
            }

            while (true)
            {
                Console.WriteLine("\nDigite a etiqueta da caixa : ");
                etiqueta = Console.ReadLine();
                Console.Clear();

                if (!string.IsNullOrEmpty(etiqueta)) break;

                Console.WriteLine("A etiqueta da caixa é obrigatória!!!");
            }

            while (true)
            {
                Console.WriteLine("\nDigite o número da caixa : ");
                nCaixa = Console.ReadLine();
                Console.Clear();

                if (int.TryParse(nCaixa, out nCaixaInt)) break;

                Console.WriteLine("O número da caixa é obrigatório!!! ");
            }

            return new Caixa(cor, etiqueta, nCaixaInt);
        }
    }
}