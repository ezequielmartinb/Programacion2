using Entidades;

namespace Vista
{
    public partial class FrmVista : Form
    {
        Persona personaSeleccionada;
        public FrmVista()
        {
            InitializeComponent();
            personaSeleccionada = new Persona("", "");
        }

        private void btnLeer_Click(object sender, EventArgs e)
        {
            PersonaDAO personaDAO = new PersonaDAO();
            RefrescarListBox(this.lstPersonas, personaDAO);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            PersonaDAO personaDAO = new PersonaDAO();
            if (txtNombre.Text != null && this.txtApellido.Text != null)
            {
                Persona personaIngresada = new Persona(this.txtNombre.Text, this.txtApellido.Text);
                if (personaDAO.Guardar(personaIngresada))
                {
                    MessageBox.Show("La persona fue guardada con exito", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefrescarListBox(this.lstPersonas, personaDAO);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            PersonaDAO personaDAO = new PersonaDAO();
            if (personaSeleccionada is not null && personaDAO.Eliminar(personaSeleccionada))
            {
                Persona p1 = personaDAO.LeerPorId(personaSeleccionada.Id);
                MessageBox.Show("La persona fue eliminada con exito", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefrescarListBox(this.lstPersonas, personaDAO);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            PersonaDAO personaDAO = new PersonaDAO();
            Persona personaModificada = new Persona(personaSeleccionada.Id, txtNombre.Text, txtApellido.Text);
            if (personaSeleccionada is not null && personaDAO.Modificar(personaModificada))
            {
                MessageBox.Show("La persona fue modificada con exito", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            RefrescarListBox(this.lstPersonas, personaDAO);
        }

        private void lstPersonas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstPersonas.Items.Count > 0 && lstPersonas.SelectedItem != null)
            {
                personaSeleccionada = lstPersonas.SelectedItem as Persona;
                if (personaSeleccionada != null)
                {
                    this.txtApellido.Text = personaSeleccionada.Apellido;
                    this.txtNombre.Text = personaSeleccionada.Nombre;
                }
            }
        }
        private void RefrescarListBox(ListBox listBox, PersonaDAO personaDAO)
        {
            List<Persona> persona = personaDAO.Leer();
            listBox.DataSource = persona;
            listBox.Refresh();
        }
    }
}
