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

            /*listado con fallos
            List<string> lista = new List<string>
            {
                 "dni; telefono; email; monto",
                "25.655.458; 343 - 62775; ernestina.m @gmail.com; 323,2",
                "40 675 458; (343)6274575; agustina.s@gmail.com; 9000,2",
                "256-4n5A8; 1161116127; jorgel - ina@gmail.com;  3232,2",
                "256458; 1161117a7127; jorgelina@gmail.com; null",
                "2506458; 11611177127; @gmail.com",
                "2706458; 11611177127 ; mariano.campos@gmail.com;234,234",
                "2106458; 11611177127 ; mariano@;9240,234",
                "3406454; 11611177127 ; mariano@;2340,234",
                "4446452; 11611177127 ; mariano@",
                " 3506452; 11611177127 ; mariano@;234.234"
            };
            */

            /*listado sin con fallos*/
            List<string> lista = new List<string>
            {
                "dni; telefono; email; monto",//cabecera
                "25.655.458; 343-4627725; ernestina.m@gmail.com; 323,2",
                "40 675 458;(343)6274575; agustina.s@gmail.com; 9000,2",
                "22256458; 11-61116127; jorgelina.green@gmail.com;  3232,2",
                "1256458; 11-61177127; alejandra.dim@gmail.com; 272,2",
                "21064008; 11-51317121 ; ivana.campos@gmail.com;342,23",
                "2706458; 1161277121 ; mariano.campos@gmail.com;234,234",
                "4106458; 11-61114627 ; mario.nieves@hotmail.com;234,234",
                "3406454; 11-61541121 ; claudiosch@hotmail.com;234,234",
                "4446452; 11-61117127 ; chiguan@yahoo.com.ar;234,234",
                " 3506452; 11-61467127 ; mariano@chat.com.ar;234,234"
            };

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
