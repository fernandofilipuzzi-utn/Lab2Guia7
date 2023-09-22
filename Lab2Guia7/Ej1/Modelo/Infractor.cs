using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej1.Modelo
{
    class Infractor :IComparable
    {
        public int Dni { get; set; }

        public string ApellidoYNombre { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public double Monto { get; set; }

        public int CompareTo(object obj)
        {
            int valor = -1;
            Infractor infractor = obj as Infractor;
            if (infractor!=null)
                valor = this.Dni.CompareTo(infractor.Dni);
            return valor;
        }

        public override string ToString()
        {
            return $"{Dni};{Telefono};{Email};{Monto:f2}";
        }
    }
}
