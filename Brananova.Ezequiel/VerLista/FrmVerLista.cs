using AgregarVehiculo;
using ClassLibrary;
using ClassLibrary.Clases;
using ClassLibrary.Login;
using ClassLibrary.Utilidades;
using System.Windows.Forms;

namespace VerLista
{
    public partial class FrmVerLista : Form
    {
        Estacionamiento estacionamiento;
        Vehiculo vehiculoSeleccionado;
        int indiceVehiculoSeleccionado;
        public FrmVerLista()
        {
            InitializeComponent();
            this.estacionamiento = new Estacionamiento();
            this.indiceVehiculoSeleccionado = -1;
        }
        public FrmVerLista(Estacionamiento estacionamiento, Usuario usuario)
        {
            InitializeComponent();
            this.estacionamiento = estacionamiento;
            if (usuario.Rol == ERol.Supervisor)
            {
                this.btnEliminar.Enabled = false;
            }
            else if (usuario.Rol == ERol.Empleado)
            {
                this.btnEliminar.Enabled = false;
                this.btnModificar.Enabled = false;
                this.btnGuardarLista.Enabled = false;
                this.btnAbrirLista.Enabled = false;

            }
            this.dtgvListaVehiculos.DataSource = estacionamiento.ListadoDeVehiculos;
            this.dtgvListaVehiculos.ReadOnly = true;
            this.dtgvListaVehiculos.Update();
        }
        private void btnVolverAlMenuPrincipal_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void dtgvListaVehiculos_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 1:
                    this.estacionamiento.ListadoDeVehiculos.Sort(Vehiculo.OrdenarPorHoraIngreso);
                    break;
                case 2:
                    this.estacionamiento.ListadoDeVehiculos.Sort(Vehiculo.OrdenarPorHoraEgreso);
                    break;
                case 3:
                    this.estacionamiento.ListadoDeVehiculos.Sort(Vehiculo.OrdenarPorPatente);
                    break;
                case 4:
                    this.estacionamiento.ListadoDeVehiculos.Sort(Vehiculo.OrdenarPorMarca);
                    break;
            }
            dtgvListaVehiculos.Refresh();
        }

        private void dtgvListaVehiculos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (estacionamiento.ListadoDeVehiculos.Count > 0)
            {
                foreach (Vehiculo vehiculo in estacionamiento.ListadoDeVehiculos)
                {
                    if (vehiculo == estacionamiento.ListadoDeVehiculos[e.RowIndex])
                    {
                        this.vehiculoSeleccionado = vehiculo;
                        this.indiceVehiculoSeleccionado = e.RowIndex;
                        MessageBox.Show($"Seleccionó el vehiculo: \n {this.vehiculoSeleccionado.ToString()}");
                    }
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (this.vehiculoSeleccionado is not null)
            {
                FrmAgregarVehiculo frmAgregarVehiculo = new FrmAgregarVehiculo(this.estacionamiento, "Modificar vehiculo", "Modificar", indiceVehiculoSeleccionado);
                frmAgregarVehiculo.ShowDialog();
            }
            else
            {
                MessageBox.Show("ERROR. Antes de modificar, se deben cargar datos a la lista", "No hay datos cargados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (this.vehiculoSeleccionado is not null && this.estacionamiento - this.vehiculoSeleccionado)
            {
                this.vehiculoSeleccionado.HoraEgreso = DateTime.Now;
                this.estacionamiento.Ganancias += this.vehiculoSeleccionado.CargoEstacionamiento();
                MessageBox.Show($"El vehiculo {vehiculoSeleccionado.ToString()} fue eliminado de la lista correctamente, " +
                    $"la capacidad del estacionamiento es de {this.estacionamiento.CapacidadEstacionamiento} y " +
                    $"la Ganancia acumulada es de {this.estacionamiento.Ganancias}");
                this.Close();
            }
            else
            {
                MessageBox.Show("ERROR. Antes de eliminar, se deben cargar datos a la lista", "No hay datos cargados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAbrirLista_Click(object sender, EventArgs e)
        {
            try
            {
                using (this.opfdAbrirLista = new OpenFileDialog())
                {
                    if (opfdAbrirLista.ShowDialog() == DialogResult.OK)
                    {
                        JsonSerializadorYDeseralizador<Estacionamiento> jsonSerializadorYDeseralizador = new JsonSerializadorYDeseralizador<Estacionamiento>();
                        jsonSerializadorYDeseralizador.Deserializar(opfdAbrirLista.FileName, out this.estacionamiento);
                        MessageBox.Show($"Lista abierta en la ruta {opfdAbrirLista.FileName}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        private void btnGuardarLista_Click(object sender, EventArgs e)
        {
            try
            {
                using (this.sfdGuardarLista = new SaveFileDialog())
                {
                    if (sfdGuardarLista.ShowDialog() == DialogResult.OK)
                    {
                        JsonSerializadorYDeseralizador<Estacionamiento> jsonSerializadorYDeseralizador = new JsonSerializadorYDeseralizador<Estacionamiento>();
                        jsonSerializadorYDeseralizador.Serializar(sfdGuardarLista.FileName, this.estacionamiento);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERROR {ex.Message}");
            }
        }
    }
}
