using System;
using System.Windows.Forms;


namespace PresentacionGUI
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            textContraseña.PasswordChar = '*';
        }

        private void labelLogin_Click(object sender, EventArgs e)
        {

        }

        private void labelContraseña_Click(object sender, EventArgs e)
        {

        }

        public void Ingresar()
        {
            if (textUsuario.Text == "admin" && textContraseña.Text == "12345")
            {
                RegistroUsuario formulario = new RegistroUsuario();
                formulario.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Usuario O Contraseña Incorrecta");
                textUsuario.Text = "";
                textContraseña.Text = "";
                textUsuario.Focus();
            }
        }

        private void btIngresar_Click(object sender, EventArgs e)
        {
            Ingresar(); 
        }

        private void btCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void textUsuario_KeyPress(object sender, KeyPressEventArgs e)
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
                Ingresar();
            }
        }

        private void textContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Ingresar();
            }
        }
    }
}
