using System;

namespace ClubeDaLeitura.Domínio
{
    abstract class Registro
    {
        protected int id;
        protected int Id { get => id; }
        public abstract bool Validar();


    }
}