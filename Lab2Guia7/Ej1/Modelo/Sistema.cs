using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej1.Modelo
{
    class Sistema
    {
        List<Infractor> infractores = new List<Infractor>();

        public int CantidadInfractores
        {
            get
            {
                return infractores.Count;
            }
        }

        public Infractor VerInfractor(int idx)
        {
            return infractores[idx];
        }

        public void ImportarInfractores(List<string> lista)
        {
            List<Infractor> importados = new List<Infractor>();

            for (int linea = 1; linea < lista.Count; linea++)
            {
                string[] campos = lista[linea].Split(';');

                string dni = campos[0];
                string apellidoYNombre = campos[1];
                string telefono = campos[2];
                string email = campos[3];
                string monto = campos[4];

                try
                {
                    dni = Validator.NormalizarYValidarDNI(dni);
                    apellidoYNombre = Validator.NormalizarYValidarApellidoYNombre(apellidoYNombre);
                    telefono = Validator.NormalizarYValidarTelefono(telefono);
                    email = Validator.NormalizarYValidarEmail(email);
                    monto = Validator.NormalizarYValidarDecimal(monto);

                    importados.Add(new Infractor
                    {
                        Dni = Convert.ToInt32(dni),
                        ApellidoYNombre=apellidoYNombre,
                        Telefono = telefono,
                        Email = email,
                        Monto = Convert.ToDouble(monto)
                    }); ;
                } 
                catch (Exception ex)
                {
                    throw new Exception($"Error en línea {linea+1}", ex);
                }
            }

            foreach (Infractor reg in importados)
            {
                //conviene trabajar con un sortedlist
                infractores.Sort();
                int idx = infractores.BinarySearch(reg);

                if (idx > -1)
                {
                    infractores[idx].Monto += reg.Monto;
                    infractores[idx].Telefono = reg.Telefono;
                }
                else
                {
                    infractores.Add(reg);
                }
            }

        }
    }
}
