namespace VerRegistroUsuario
{
    public partial class FrmRegistroUsuarios : Form
    {
        public FrmRegistroUsuarios()
        {
            InitializeComponent();
        }
        public FrmRegistroUsuarios(List<string> usuarios)
        {
            InitializeComponent();            
            this.listBoxUsuarios.DataSource = usuarios;
        }

        private void btnVolverAlMenuPrincipal_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
