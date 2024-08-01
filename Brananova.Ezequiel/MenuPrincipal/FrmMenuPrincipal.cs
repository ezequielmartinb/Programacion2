using AgregarVehiculo;
using ClassLibrary;
using ClassLibrary.Login;
using VerLista;
using VerRegistroUsuario;

namespace MenuPrincipal
{
    public partial class FrmMenuPrincipal : Form
    {
        Estacionamiento estacionamiento;
        Usuario usuario;
        Form frm;

        public FrmMenuPrincipal()
        {
            InitializeComponent();
            this.estacionamiento = new Estacionamiento("Estacionamiento UTN");
        }
        public FrmMenuPrincipal(Usuario usuario, DateTime fecha, Form form)
        {
            InitializeComponent();
            this.frm = form;
            this.usuario = usuario;
            this.estacionamiento = new Estacionamiento("Estacionamiento UTN");
            this.lblBienvenida.Text = $"Bienvenido {usuario.Apellido}, {usuario.Nombre}";
            this.lblFecha.Text = fecha.ToString("dd/MM/yyyy");
            if (usuario.Rol == ERol.Supervisor)
            {
                this.btnHistorialRegistros.Visible = false;
            }
            else if (usuario.Rol == ERol.Empleado)
            {
                this.btnAgregarVehiculo.Enabled = false;
                this.btnHistorialRegistros.Visible = false;
            }
        }
        private void FrmMenuPrincipal_Load(object sender, EventArgs e)
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            CancellationToken token = cancellationTokenSource.Token;
            Task task = new Task(() => IniciarHora(token, this.lblHora));
            task.Start();
        }
        private void btnAgregarVehiculo_Click(object sender, EventArgs e)
        {
            FrmAgregarVehiculo frmAgregarVehiculo = new FrmAgregarVehiculo(this.estacionamiento);
            frmAgregarVehiculo.ShowDialog();
            if (frmAgregarVehiculo.DialogResult == DialogResult.OK)
            {
                frmAgregarVehiculo.Close();
                this.Show();
            }
        }
        private void btnHistorialRegistros_Click(object sender, EventArgs e)
        {
            List<string> ingresosUsuarios = Autenticacion.DeserializarIngresoUsuarios();
            FrmRegistroUsuarios frmRegistroUsuarios = new FrmRegistroUsuarios(ingresosUsuarios);
            frmRegistroUsuarios.ShowDialog();
            if (frmRegistroUsuarios.DialogResult == DialogResult.OK)
            {
                frmRegistroUsuarios.Close();
                this.Show();
            }
            //MessageBox.Show(Autenticacion.DeserializarIngresoUsuarios(), "Listado de usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnVerListaDeVehiculos_Click(object sender, EventArgs e)
        {
            FrmVerLista frmVerLista = new FrmVerLista(this.estacionamiento, this.usuario);
            frmVerLista.ShowDialog();
        }
        private void ActualizarHora(string fecha, Label label)
        {
            if (this.lblHora.InvokeRequired)
            {
                Action<string, Label> callback = new Action<string, Label>(ActualizarHora);
                object[] args = { RetornarHora(DateTime.Now), label };
                this.BeginInvoke(callback, args);
            }
            else
            {
                this.lblHora.Text = RetornarHora(DateTime.Now);
            }
        }
        private void IniciarHora(CancellationToken token, Label label)
        {
            do
            {
                ActualizarHora(RetornarHora(DateTime.Now), label);
                Thread.Sleep(1);
            } while (!token.IsCancellationRequested);
        }
        private string RetornarHora(DateTime dateTime)
        {
            return DateTime.Now.ToString("HH:mm:ss");
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            if (this.frm != null)
            {
                this.frm.Show();
                this.Close();
            }
        }
    }
}
