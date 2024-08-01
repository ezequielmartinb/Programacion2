namespace AgregarVehiculo
{
    partial class FrmAgregarVehiculo
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnAgregar = new Button();
            btnCancelar = new Button();
            cmbTipoVehiculo = new ComboBox();
            lblTipoVehiculo = new Label();
            txtPatente = new TextBox();
            lblPatente = new Label();
            cmbETipo = new ComboBox();
            lblETipo = new Label();
            txtMarca = new TextBox();
            lblMarca = new Label();
            txtValorHora = new TextBox();
            lblValorHora = new Label();
            gpbDatosVehiculo = new GroupBox();
            gpbDatosVehiculo.SuspendLayout();
            SuspendLayout();
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(76, 323);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 23);
            btnAgregar.TabIndex = 1;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(157, 323);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 2;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // cmbTipoVehiculo
            // 
            cmbTipoVehiculo.FormattingEnabled = true;
            cmbTipoVehiculo.Location = new Point(6, 46);
            cmbTipoVehiculo.Name = "cmbTipoVehiculo";
            cmbTipoVehiculo.Size = new Size(236, 23);
            cmbTipoVehiculo.TabIndex = 0;
            cmbTipoVehiculo.SelectedIndexChanged += cmbTipoVehiculo_SelectedIndexChanged;
            // 
            // lblTipoVehiculo
            // 
            lblTipoVehiculo.AutoSize = true;
            lblTipoVehiculo.Location = new Point(6, 28);
            lblTipoVehiculo.Name = "lblTipoVehiculo";
            lblTipoVehiculo.Size = new Size(94, 15);
            lblTipoVehiculo.TabIndex = 1;
            lblTipoVehiculo.Text = "Tipo de Vehiculo";
            // 
            // txtPatente
            // 
            txtPatente.Location = new Point(6, 90);
            txtPatente.Name = "txtPatente";
            txtPatente.Size = new Size(237, 23);
            txtPatente.TabIndex = 2;
            // 
            // lblPatente
            // 
            lblPatente.AutoSize = true;
            lblPatente.Location = new Point(6, 72);
            lblPatente.Name = "lblPatente";
            lblPatente.Size = new Size(47, 15);
            lblPatente.TabIndex = 3;
            lblPatente.Text = "Patente";
            // 
            // cmbETipo
            // 
            cmbETipo.FormattingEnabled = true;
            cmbETipo.Location = new Point(6, 178);
            cmbETipo.Name = "cmbETipo";
            cmbETipo.Size = new Size(237, 23);
            cmbETipo.TabIndex = 7;
            // 
            // lblETipo
            // 
            lblETipo.AutoSize = true;
            lblETipo.Location = new Point(6, 160);
            lblETipo.Name = "lblETipo";
            lblETipo.Size = new Size(32, 15);
            lblETipo.TabIndex = 5;
            lblETipo.Text = "label";
            // 
            // txtMarca
            // 
            txtMarca.Location = new Point(6, 134);
            txtMarca.Name = "txtMarca";
            txtMarca.Size = new Size(236, 23);
            txtMarca.TabIndex = 6;
            // 
            // lblMarca
            // 
            lblMarca.AutoSize = true;
            lblMarca.Location = new Point(6, 116);
            lblMarca.Name = "lblMarca";
            lblMarca.Size = new Size(40, 15);
            lblMarca.TabIndex = 7;
            lblMarca.Text = "Marca";
            // 
            // txtValorHora
            // 
            txtValorHora.Location = new Point(6, 222);
            txtValorHora.Name = "txtValorHora";
            txtValorHora.Size = new Size(238, 23);
            txtValorHora.TabIndex = 8;
            // 
            // lblValorHora
            // 
            lblValorHora.AutoSize = true;
            lblValorHora.Location = new Point(6, 204);
            lblValorHora.Name = "lblValorHora";
            lblValorHora.Size = new Size(60, 15);
            lblValorHora.TabIndex = 9;
            lblValorHora.Text = "Valor hora";
            // 
            // gpbDatosVehiculo
            // 
            gpbDatosVehiculo.Controls.Add(lblValorHora);
            gpbDatosVehiculo.Controls.Add(txtValorHora);
            gpbDatosVehiculo.Controls.Add(lblMarca);
            gpbDatosVehiculo.Controls.Add(txtMarca);
            gpbDatosVehiculo.Controls.Add(lblETipo);
            gpbDatosVehiculo.Controls.Add(cmbETipo);
            gpbDatosVehiculo.Controls.Add(lblPatente);
            gpbDatosVehiculo.Controls.Add(txtPatente);
            gpbDatosVehiculo.Controls.Add(lblTipoVehiculo);
            gpbDatosVehiculo.Controls.Add(cmbTipoVehiculo);
            gpbDatosVehiculo.Location = new Point(29, 57);
            gpbDatosVehiculo.Name = "gpbDatosVehiculo";
            gpbDatosVehiculo.Size = new Size(254, 260);
            gpbDatosVehiculo.TabIndex = 0;
            gpbDatosVehiculo.TabStop = false;
            gpbDatosVehiculo.Text = "Datos vehiculo";
            // 
            // FrmAgregarVehiculo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(316, 406);
            Controls.Add(btnCancelar);
            Controls.Add(btnAgregar);
            Controls.Add(gpbDatosVehiculo);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmAgregarVehiculo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Agregar vehiculo";
            Load += FrmAgregarVehiculo_Load;
            gpbDatosVehiculo.ResumeLayout(false);
            gpbDatosVehiculo.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button btnAgregar;
        private Button btnCancelar;
        private ComboBox cmbTipoVehiculo;
        private Label lblTipoVehiculo;
        private TextBox txtPatente;
        private Label lblPatente;
        private ComboBox cmbETipo;
        private Label lblETipo;
        private TextBox txtMarca;
        private Label lblMarca;
        private TextBox txtValorHora;
        private Label lblValorHora;
        private GroupBox gpbDatosVehiculo;
    }
}
