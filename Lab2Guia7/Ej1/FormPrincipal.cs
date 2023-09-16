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
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            List<string> lista = new List<string>
            {
                 "dni; telefono; email; monto",
                "25.655.458; 343 - 62775; ernestina.m @gmail.com; 323,2",
                "40 675 458; (343)6274575; agustina.s@gmail.com; 9000,2",
                "256-4n5A8; 1161116127; jorgel - ina@gmail.com;  3232,2",
                "256458; 1161117a7127; jorgelina@gmail.com; null",
                "2506458; 11611177127; @gmail.com;",
                "2706458; 11611177127 ; mariano.campos@gmail.com;234.234",
                "2106458; 11611177127 ; mariano@;234.234",
                "3406454; 11611177127 ; mariano@;234.234",
                "4446452; 11611177127 ; mariano@",
                " 3506452; 11611177127 ; mariano@;234.234"
            };

            List<Infractor> infractores = new List<Infractor>();
            try
            {
                for (int linea = 1; linea < lista.Count; linea++)
                {
                    string[] campos = lista[linea].Split(';');

                    string dni = campos[0];
                    string telefono = campos[1];
                    string email = campos[2];

                    dni = Validator.NormalizarYValidarDNI(dni);
                    telefono = Validator.NormalizarYValidarTelefono(telefono);
                    email = Validator.NormalizarYValidarEmail(email);

                    infractores.Add( new Infractor{
                                        Dni = Convert.ToInt32(dni),
                                        Telefono = telefono,
                                        Email = email
                                    });
                }

            }
            catch (Exception ex)
            {
                listBox1.Items.Add(ex.Message);
            }
        }
    }
}
