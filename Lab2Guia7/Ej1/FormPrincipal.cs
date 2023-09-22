using Ej1.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ej1
{
    public partial class FormPrincipal : Form
    {
        Sistema sistema = new Sistema();

        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            /*listado con fallos*/
            List<string> lista = new List<string>
            {
                "dni; Apellido, Nombre; telefono; email; monto",
                "25.655.458;Gales Ernestina ;343 - 62775; ernestina.g @gmail.com; 323,2",
                "40 675 458;Herrera, Agustina; (343)6274575; agustina.s@gmail.com; 9000,2",
                "256-4n5A8;Lorenzo, Jorgelina; 1161116127; jorgel - ina@gmail.com;  3232,2",
                "256458;Bushman, Jorleina; 1161117a7127; jorgelina@gmail.com; null",
                "2506458;Menfis, Marciano Laureado; 11611177127; @gmail.com;",
                "2706458;Yamamoto, Pedro ;11611177127 ; yama.que.yama@gmail.com;234.234",
                "2106458;Mimoto, Mariano; 11611177127 ; mariano@;234.234",
                "3406454;Artigas, José Gervasio; 11611177127 ; mariano@;234.234",
                "4446452;Roca, Julio Argentino; 11611177127 ; roca@;",
                "3506452;Perón, Juand Domingo; 11611177127 ; juanito@;234.234"
            };


            /*listado sin con fallos
            List<string> lista = new List<string>
            {
                "dni; Apellido, Nombre; telefono; email; monto",
                "25.655.458;Gales Ernestina ;343 - 6425775; ernestina.g@gmail.com; 323,2",
                "40 675 458;Herrera, Agustina; (343)6274575; agustina.s@gmail.com; 9000,2",
                "2506458;Lorenzo, Jorgelina; 1161116127; jorgelina@gmail.com;  3232,2",
                "2564058;Bushman, Jorgelina; 1161117127; jorgelinab@gmail.com; 1253,88",
                "2506458;Menfis, Marciano Laureado; 1161117127; marcianito@gmail.com;9934,234",
                "2706458;Yamamoto, Pedro ;1161117727 ; yama.que.yama@gmail.com;234,234",
                "2106458;Mimoto, Mariano; 1161177127 ; mariano@gmail.com;234,234",
                "3406454;Artigas, José Gervasio; 1161177127 ; mariano@yahoo.com.ar;234,234",
                "4446452;Roca, Julio Argentino; 1161177127 ; roca@yahoo.com.ar; 2934,234",
                "3506452;Perón, Juand Domingo; 1161177127 ; juanito@frp.org;234,234"
            };
             */

            try
            {
                sistema.ImportarInfractores(lista);

                for (int n = 0; n < sistema.CantidadInfractores; n++)
                    listBox1.Items.Add(sistema.VerInfractor(n));
            }
            catch (Exception ex)
            {
                listBox1.Items.Add(ex.Message);
                if(ex.InnerException!=null)
                    listBox1.Items.Add("\t"+ex.InnerException.Message);

            }
        }
    }
}
