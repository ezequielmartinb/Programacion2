namespace MenuPrincipal
{
    partial class FrmMenuPrincipal
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
            lblBienvenida = new Label();
            lblFecha = new Label();
            btnAgregarVehiculo = new Button();
            btnVerListaDeVehiculos = new Button();
            btnHistorialRegistros = new Button();
            lblHora = new Label();
            btnCerrarSesion = new Button();
            SuspendLayout();
            // 
            // lblBienvenida
            // 
            lblBienvenida.AutoSize = true;
            lblBienvenida.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBienvenida.Location = new Point(32, 11);
            lblBienvenida.Name = "lblBienvenida";
            lblBienvenida.Size = new Size(72, 30);
            lblBienvenida.TabIndex = 0;
            lblBienvenida.Text = "label1";
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            lblFecha.Location = new Point(340, 11);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(72, 30);
            lblFecha.TabIndex = 1;
            lblFecha.Text = "label2";
            // 
            // btnAgregarVehiculo
            // 
            btnAgregarVehiculo.Location = new Point(32, 81);
            btnAgregarVehiculo.Name = "btnAgregarVehiculo";
            btnAgregarVehiculo.Size = new Size(161, 51);
            btnAgregarVehiculo.TabIndex = 2;
            btnAgregarVehiculo.Text = "Agregar vehiculo";
            btnAgregarVehiculo.UseVisualStyleBackColor = true;
            btnAgregarVehiculo.Click += btnAgregarVehiculo_Click;
            // 
            // btnVerListaDeVehiculos
            // 
            btnVerListaDeVehiculos.Location = new Point(32, 138);
            btnVerListaDeVehiculos.Name = "btnVerListaDeVehiculos";
            btnVerListaDeVehiculos.Size = new Size(161, 51);
            btnVerListaDeVehiculos.TabIndex = 3;
            btnVerListaDeVehiculos.Text = "Ver lista de vehiculos";
            btnVerListaDeVehiculos.UseVisualStyleBackColor = true;
            btnVerListaDeVehiculos.Click += btnVerListaDeVehiculos_Click;
            // 
            // btnHistorialRegistros
            // 
            btnHistorialRegistros.Location = new Point(32, 195);
            btnHistorialRegistros.Name = "btnHistorialRegistros";
            btnHistorialRegistros.Size = new Size(161, 51);
            btnHistorialRegistros.TabIndex = 5;
            btnHistorialRegistros.Text = "Ver historial de registros";
            btnHistorialRegistros.UseVisualStyleBackColor = true;
            btnHistorialRegistros.Click += btnHistorialRegistros_Click;
            // 
            // lblHora
            // 
            lblHora.AutoSize = true;
            lblHora.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHora.Location = new Point(340, 41);
            lblHora.Name = "lblHora";
            lblHora.Size = new Size(72, 30);
            lblHora.TabIndex = 6;
            lblHora.Text = "label1";
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.Location = new Point(340, 256);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(94, 25);
            btnCerrarSesion.TabIndex = 7;
            btnCerrarSesion.Text = "Cerrar sesión";
            btnCerrarSesion.UseVisualStyleBackColor = true;
            btnCerrarSesion.Click += btnCerrarSesion_Click;
            // 
            // FrmMenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(486, 293);
            Controls.Add(btnCerrarSesion);
            Controls.Add(lblHora);
            Controls.Add(btnHistorialRegistros);
            Controls.Add(btnVerListaDeVehiculos);
            Controls.Add(btnAgregarVehiculo);
            Controls.Add(lblFecha);
            Controls.Add(lblBienvenida);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "FrmMenuPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Menú principal";
            Load += FrmMenuPrincipal_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblBienvenida;
        private Label lblFecha;
        private Button btnAgregarVehiculo;
        private Button btnVerListaDeVehiculos;
        private Button btnHistorialRegistros;
        private Label lblHora;
        private Button btnCerrarSesion;
    }
}
