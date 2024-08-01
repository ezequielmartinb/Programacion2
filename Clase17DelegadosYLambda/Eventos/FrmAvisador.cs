using ClassLibrary;
using System.Runtime.CompilerServices;

namespace Eventos
{
    public partial class FrmAvisador : Form
    {
        private Persona persona;
        public FrmAvisador()
        {
            InitializeComponent();
            this.btn_Crear.Text = "Crear";
        }
        static void NotificarCambio(string cambio)
        {
            MessageBox.Show(cambio);
        }
        private void btn_Crear_Click(object sender, EventArgs e)
        {
            if (this.persona == null && !String.IsNullOrEmpty(txt_Nombre.Text) && !String.IsNullOrEmpty(txt_Apellido.Text))
            {
                this.persona = new Persona();
                this.persona.Nombre = this.txt_Nombre.Text;
                this.persona.Apellido = this.txt_Apellido.Text;
                this.btn_Crear.Text = "Actualizar";
                this.persona.EventoString += NotificarCambio;
                this.lbl_NombreCompleto.Text = this.persona.Mostrar();
            }
            else if (this.persona != null && !String.IsNullOrEmpty(txt_Nombre.Text) && !String.IsNullOrEmpty(txt_Apellido.Text))
            {
                this.persona.Nombre = this.txt_Nombre.Text;
                this.persona.Apellido = this.txt_Apellido.Text;
                this.lbl_NombreCompleto.Text = this.persona.Mostrar();
            }
            else
            {
                NotificarCambio("Datos invalidos");
            }
        }
    }
}
