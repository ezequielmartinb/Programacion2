using ClassLibrary;
using ClassLibrary.Clases;
using System.Runtime.CompilerServices;

namespace AgregarVehiculo
{
    public partial class FrmAgregarVehiculo : Form
    {
        Estacionamiento estacionamiento;
        int indice;
        public FrmAgregarVehiculo()
        {
            InitializeComponent();
            this.estacionamiento = new Estacionamiento();
        }
        public FrmAgregarVehiculo(Estacionamiento estacionamiento)
        {
            InitializeComponent();
            this.estacionamiento = estacionamiento;
            
        }
        public FrmAgregarVehiculo(Estacionamiento estacionamiento, string titulo, string btnTexto, int indice)
        {
            InitializeComponent();
            this.estacionamiento = estacionamiento;
            this.btnAgregar.Text = btnTexto;
            this.Text = titulo;
            this.indice = indice;

            if (this.estacionamiento.ListadoDeVehiculos[indice] is Auto)
            {

                this.txtPatente.Text = this.estacionamiento.ListadoDeVehiculos[indice].Patente;
                this.txtMarca.Text = this.estacionamiento.ListadoDeVehiculos[indice].Marca;
                this.txtValorHora.Text = (((Auto)this.estacionamiento.ListadoDeVehiculos[indice]).ValorHora).ToString();
            }
            else if (this.estacionamiento.ListadoDeVehiculos[indice] is Moto)
            {
                this.txtPatente.Text = this.estacionamiento.ListadoDeVehiculos[indice].Patente;
                this.txtMarca.Text = this.estacionamiento.ListadoDeVehiculos[indice].Marca;
                this.txtValorHora.Text = (((Moto)this.estacionamiento.ListadoDeVehiculos[indice]).ValorHora).ToString();
            }
            else
            {
                this.txtPatente.Text = this.estacionamiento.ListadoDeVehiculos[indice].Patente;
                this.txtMarca.Text = this.estacionamiento.ListadoDeVehiculos[indice].Marca;
                this.txtValorHora.Text = (((Camion)this.estacionamiento.ListadoDeVehiculos[indice]).ValorHora).ToString();
            }

        }
        private void FrmAgregarVehiculo_Load(object sender, EventArgs e)
        {
            this.lblETipo.Text = "Tipo de auto";
            this.cmbTipoVehiculo.DataSource = Enum.GetValues(typeof(EVehiculo));
            this.cmbETipo.DataSource = Enum.GetValues(typeof(ETipoAuto));
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (this.btnAgregar.Text == "Agregar")
            {
                if (float.TryParse(this.txtValorHora.Text, out float valorHora) && Vehiculo.ValidarPatente(this.txtPatente.Text) && Vehiculo.ValidarMarca(this.txtMarca.Text))
                {
                    switch (this.cmbTipoVehiculo.SelectedIndex)
                    {
                        case (int)EVehiculo.Auto:
                            Auto auto = new Auto(this.txtPatente.Text, this.txtMarca.Text, DateTime.Now, valorHora, (ETipoAuto)(this.cmbETipo.SelectedIndex));
                            if (this.estacionamiento + auto)
                            {
                                MessageBox.Show($"El auto fue cargado con exito y la capacidad del estacionamiento es de {this.estacionamiento.CapacidadEstacionamiento}");
                                this.DialogResult = DialogResult.OK;
                            }
                            else if (estacionamiento == auto)
                            {
                                MessageBox.Show($"El auto NO fue cargado");
                            }
                            break;
                        case (int)EVehiculo.Moto:
                            Moto moto = new Moto(this.txtPatente.Text, this.txtMarca.Text, DateTime.Now, valorHora, (ETipoMoto)(this.cmbETipo.SelectedIndex));
                            if (this.estacionamiento + moto)
                            {
                                MessageBox.Show($"La moto fue cargado con exito y la capacidad del estacionamiento es de {this.estacionamiento.CapacidadEstacionamiento}");
                                this.DialogResult = DialogResult.OK;
                            }
                            else
                            {
                                MessageBox.Show("La moto NO fue cargado");
                            }
                            break;
                        case (int)EVehiculo.Camion:
                            Camion camion = new Camion(this.txtPatente.Text, this.txtMarca.Text, DateTime.Now, valorHora, (ETipoCamion)(this.cmbETipo.SelectedIndex));
                            if (this.estacionamiento + camion)
                            {
                                MessageBox.Show($"El camión fue cargado con exito y la capacidad del estacionamiento es de {this.estacionamiento.CapacidadEstacionamiento}");
                                this.DialogResult = DialogResult.OK;
                            }
                            else
                            {
                                MessageBox.Show("El camión NO fue cargado");
                            }
                            break;
                    }
                }
                else if (Vehiculo.ValidarPatente(this.txtPatente.Text) == false)
                {
                    MessageBox.Show("Patente ingresada invalida", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (Vehiculo.ValidarMarca(this.txtMarca.Text) == false)
                {
                    MessageBox.Show("Marca ingresada invalida", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (float.TryParse(this.txtValorHora.Text, out valorHora) == false)
                {
                    MessageBox.Show("Valor hora ingresado invalido", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (btnAgregar.Text == "Modificar")
            {
                if (float.TryParse(this.txtValorHora.Text, out float valorHora) && Vehiculo.ValidarPatente(this.txtPatente.Text) && Vehiculo.ValidarMarca(this.txtMarca.Text))
                {
                    switch (this.cmbTipoVehiculo.SelectedIndex)
                    {
                        case (int)EVehiculo.Auto:
                            Auto auto = new Auto(this.txtPatente.Text, this.txtMarca.Text, DateTime.Now, valorHora, (ETipoAuto)(this.cmbETipo.SelectedIndex));
                            this.estacionamiento.ListadoDeVehiculos[indice] = auto;
                            break;
                        case (int)EVehiculo.Moto:
                            Moto moto = new Moto(this.txtPatente.Text, this.txtMarca.Text, DateTime.Now, valorHora, (ETipoMoto)(this.cmbETipo.SelectedIndex));
                            this.estacionamiento.ListadoDeVehiculos[indice] = moto;
                            break;
                        case (int)EVehiculo.Camion:
                            Camion camion = new Camion(this.txtPatente.Text, this.txtMarca.Text, DateTime.Now, valorHora, (ETipoCamion)(this.cmbETipo.SelectedIndex));
                            this.estacionamiento.ListadoDeVehiculos[indice] = camion;
                            break;
                    }
                    this.DialogResult = DialogResult.OK;
                }
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro que desea salir de este formulario y volver al menu principal?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void cmbTipoVehiculo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.cmbTipoVehiculo.SelectedIndex)
            {
                case (int)EVehiculo.Auto:
                    this.lblETipo.Text = "Tipo de auto";
                    this.cmbETipo.DataSource = Enum.GetValues(typeof(ETipoAuto));
                    break;
                case (int)EVehiculo.Moto:
                    this.lblETipo.Text = "Tipo de moto";
                    this.cmbETipo.DataSource = Enum.GetValues(typeof(ETipoMoto));
                    break;
                case (int)EVehiculo.Camion:
                    this.lblETipo.Text = "Tipo de camión";
                    this.cmbETipo.DataSource = Enum.GetValues(typeof(ETipoCamion));
                    break;
            }
        }
    }
}