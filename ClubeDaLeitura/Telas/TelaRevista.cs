﻿using ClubeDaLeitura.Controladores;
using ClubeDaLeitura.Domínio;
using System;
using System.Collections.Generic;

namespace ClubeDaLeitura.Telas
{
    class TelaRevista : TelaBase<Revista>
    {
        private Controlador<Caixa> controladorCaixa;
        public TelaRevista(Controlador<Revista> controladorRevista, Controlador<Caixa> controladorCaixa) : base(controladorRevista, "Cadastro de Revistas\n") { this.controladorCaixa = controladorCaixa; }
        public override Revista InserirNovoRegistro()
        {
            string tipoColecao = "", nEdicao = "", anoRevista = "", idCaixa = "";
            int nEdicaoInt = 0, anoRevistaInt = 0, idCaixaInt = 0;
            Caixa caixa;
            Console.Clear();

            if (controladorCaixa.Registros.Count == 0)
            {
                Console.WriteLine("Não há CAIXAS cadastradas para a revista!!!\n");
                return null;
            }
            else
            {
                while (true)
                {
                    Console.WriteLine("\nDigite o tipo de coleção da revista : ");
                    tipoColecao = Console.ReadLine();
                    Console.Clear();

                    if (!string.IsNullOrEmpty(tipoColecao)) break;

                    Console.WriteLine("O tipo de coleção é obrigatório!!!");

                }
                while (true)
                {
                    Console.WriteLine("\nDigite o número de edição da revista : ");
                    nEdicao = Console.ReadLine();
                    Console.Clear();

                    if (int.TryParse(nEdicao, out nEdicaoInt)) break;

                    Console.WriteLine("O número de edição é obrigatório!!!");
                }
                while (true)
                {
                    Console.WriteLine("\nDigite o ano da revista : ");
                    anoRevista = Console.ReadLine();
                    Console.Clear();

                    if (int.TryParse(anoRevista, out anoRevistaInt)) break;

                    Console.WriteLine("O ano da revista é obrigatório!!!");

                }
                while (true)
                {
                    Console.WriteLine("\nDigite o ID da caixa em que a revista está : ");
                    VisualizarRegistros(controladorCaixa.Registros);
                    idCaixa = Console.ReadLine();
                    Console.Clear();

                    if (int.TryParse(idCaixa, out idCaixaInt))
                    {
                        caixa = (Caixa)controladorCaixa.Registros.Find(x => x.Id == idCaixaInt);
                        break;
                    }

                    Console.WriteLine("Digite um ID correto!!!");
                }

                Revista revista = new Revista(tipoColecao, nEdicaoInt, anoRevistaInt, caixa);
                return revista;
            }
        }

    }
}
