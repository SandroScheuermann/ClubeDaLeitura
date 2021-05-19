using System.Collections.Generic;
using ClubeDaLeitura.Domínio;

namespace ClubeDaLeitura.Controladores
{
    class Controlador
    {
        private List<Registro> registros = new List<Registro>();
        internal List<Registro> Registros { get => registros;}
        public void Editar(int id, Registro registro)
        {
            registros[registros.FindIndex(x => x.Id == id)] = registro;
        }
        public void Cadastrar(Registro registro)
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