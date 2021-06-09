using System.Collections.Generic;
using ClubeDaLeitura.Domínio;

namespace ClubeDaLeitura.Controladores
{
    class Controlador<T> where T : Registro
    {
        private List<T> registros = new List<T>();
        internal List<T> Registros { get => registros;}
        public void Editar(int id, T registro)
        {
            registros[registros.FindIndex(x => x.Id == id)] = registro;
        }
        public void Cadastrar(T registro)
        {
            registros.Add(registro);
        }
        public bool ExcluirRegistro(int id)
        {
            bool conseguiuExcluir = false;

            if (registros.Exists(x => x.Id == id))
            {
                registros.RemoveAt(registros.FindIndex(x => x.Id == id));
                conseguiuExcluir = true;
            }
            return conseguiuExcluir;
        }
    }
}