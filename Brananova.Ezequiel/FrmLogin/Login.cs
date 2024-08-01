using ClassLibrary.Login;
using MenuPrincipal;
using System.Data;
using System.Runtime.CompilerServices;

namespace FrmLogin
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            foreach (Usuario item in Autenticacion.ListaDeUsuarios)
            {
                if (txtMail.Text == item.Mail && txtPassword.Text == item.Password && ValidarInformacionIngresada(txtMail.Text, txtPassword.Text))
                {
                    FrmMenuPrincipal menuPrincipal = new FrmMenuPrincipal(item, DateTime.Now, this);
                    try
                    {
                        Autenticacion.SerializarIngresoUsuarios(item.Nombre, item.Apellido);
                        menuPrincipal.Show();
                        this.LimpiarTxt();
                        this.Hide();
                        this.DialogResult = DialogResult.OK;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            if (this.DialogResult == DialogResult.Cancel)
            {
                MessageBox.Show("Usuario y contraseña invalidos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LimpiarTxt();
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private static bool ValidarInformacionIngresada(string user, string pass)
        {
            return !string.IsNullOrEmpty(user) && !string.IsNullOrEmpty(pass);
        }
        public void LimpiarTxt()
        {
            this.txtMail.Text = string.Empty;
            this.txtPassword.Text = string.Empty;
        }
    }
}
