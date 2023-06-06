using BLL;
using Entity;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection.Metadata;
using System.Windows.Forms;
using System.Xml.Linq;

namespace PresentacionGUI
{
    public partial class RegistroUsuario : Form
    {
        public RegistroUsuario()
        {
            InitializeComponent(); 
            var connectionString = ConfigConnection.connectionString;
            PersonaServicio = new PersonaServicio(connectionString);
            ParqueaderoServicio = new ParqueaderoServicio(connectionString);
            VehiculoServicio = new VehiculoServicio(connectionString);
        }

        ParqueaderoServicio ParqueaderoServicio;
        PersonaServicio PersonaServicio;
        VehiculoServicio VehiculoServicio;

        private void RegistroUsuario_Load(object sender, EventArgs e)
        {

        }

        private void btAtras_Click(object sender, EventArgs e)
        {
            Login login1 = new Login();
            login1.Show();
            this.Hide();
        }

        private void btRegistros_Click(object sender, EventArgs e)
        {
            ReporteSistemas reporte = new ReporteSistemas();
            List<Parqueadero> parqueadero = ParqueaderoServicio.Consultar();
            if (parqueadero.Count > 0)
            {
                reporte.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("No hay registros en el sistema", "Error");
            }
        }

        private void brRegistrar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textNombre.Text) || String.IsNullOrWhiteSpace(textApellido.Text) || String.IsNullOrWhiteSpace(cbCargo.Text) || String.IsNullOrWhiteSpace(cbParqueadero.Text) || String.IsNullOrWhiteSpace(cbVehiculo.Text))
            {
                MessageBox.Show("Campo Vacio... Agrega Un Valor");
            }
            else
            {
                if (textPlaca.Enabled == true && String.IsNullOrWhiteSpace(textPlaca.Text)) 
                {
                    MessageBox.Show("Campo Vacio... Agrega Un Valor");
                }
                else
                {
                    List<int> numerosGenerados = new List<int>();
                    Random rnd = new Random();
                    int numeroGenerado;
                    do
                    {
                        numeroGenerado = rnd.Next(1, 20); 
                    }
                    while (numerosGenerados.Contains(numeroGenerado));

                    // Agregar el número generado a la lista de números generados
                    numerosGenerados.Add(numeroGenerado);

                    // Utiliza el número generado en tu aplicación
                    string ticket = "     ------------------------------ " +
                                       "\n   | ---------- TICKET ---------- |" +
                                       "\n     ------------------------------ " +
                                     "\n\n    NOMBRE            : " + textNombre.Text +
                                       "\n    PLACA                : " + textPlaca.Text +
                                       "\n    PARQUEADERO : " + cbParqueadero.SelectedItem.ToString() +
                                       "\n    PUESTO              : " + numeroGenerado;
                    MessageBox.Show(ticket);

                    ConvertirPDF(ticket);
                    Persona persona = new Persona()
                    {
                        Nombre = textNombre.Text,
                        Apellido = textApellido.Text,
                        Cargo = cbCargo.SelectedItem.ToString(),
                        Placa = textPlaca.Text
                    };

                    Vehiculo vehiculo = new Vehiculo()
                    {
                        Placa = textPlaca.Text,
                        Modelo = textModelo.Text,
                        TipoVehiculo = cbVehiculo.SelectedItem.ToString(),
                        Lugar = cbParqueadero.SelectedItem.ToString(),
                        HoraLlegada = DateTime.Now
                    };


                    VehiculoServicio.Guardar(vehiculo);
                    PersonaServicio.Guardar(persona);
                    
                    textNombre.Text = "";
                    textApellido.Text = "";
                    cbCargo.Text = "";
                    cbParqueadero.Text = "";
                    cbVehiculo.Text = "";
                    textPlaca.Text = "";
                    textModelo.Text = "";
                }
            }
        }

        private void cbVehiculo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbVehiculo.Text == "Bicicleta")
            {
                textPlaca.Enabled = false;
                textPlaca.Text = "Null";
            }
            else
            {
                textPlaca.Enabled = true;
                textPlaca.Text = "";
            }
        }

        private void ConvertirPDF(string contenido)
        {
            iTextSharp.text.Document document = new iTextSharp.text.Document();

            string idTicket = textPlaca.Text;
            string rutaArchivoPDF = $"Ticket-{idTicket}.pdf";

            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(rutaArchivoPDF, FileMode.Create));

            document.Open();

            Paragraph paragraph = new Paragraph(contenido);
            document.Add(paragraph);

            document.Close();

        }

        private void btRetirar_Click(object sender, EventArgs e)
        {
            List<Vehiculo> parqueaderos = VehiculoServicio.Consultar();
            RetirarVehiculo retirar = new RetirarVehiculo();
            if (parqueaderos.Count > 0)
            {
                retirar.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("No hay registros en el sistema", "Error");
            }

        }

        private void textNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void textNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Obtener el carácter presionado
            char ch = e.KeyChar;

            // Permitir la tecla "Backspace" y la tecla "Delete"
            if (ch == 8 || ch == 32)
            {
                e.Handled = false;
                return;
            }
            // Verificar si el carácter es una letra
            if (!Char.IsLetter(ch))
            {
                e.Handled = true;
            }
            // Verifica en enter para agregar
            if (e.KeyChar == (char)Keys.Enter)
            {
                textNombre.Text = "";
                textNombre.Focus();
            }
        }

        private void textApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Obtener el carácter presionado
            char ch = e.KeyChar;

            // Permitir la tecla "Backspace" y la tecla "Delete"
            if (ch == 8 || ch == 32)
            {
                e.Handled = false;
                return;
            }
            // Verificar si el carácter es una letra
            if (!Char.IsLetter(ch))
            {
                e.Handled = true;
            }
            // Verifica en enter para agregar
            if (e.KeyChar == (char)Keys.Enter)
            {
                textApellido.Text = "";
                textApellido.Focus();
            }
        }
    }
}
