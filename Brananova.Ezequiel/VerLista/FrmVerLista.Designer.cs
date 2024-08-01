namespace VerLista
{
    partial class FrmVerLista
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
            dtgvListaVehiculos = new DataGridView();
            btnVolverAlMenuPrincipal = new Button();
            btnModificar = new Button();
            opfdAbrirLista = new OpenFileDialog();
            btnEliminar = new Button();
            sfdGuardarLista = new SaveFileDialog();
            btnGuardarLista = new Button();
            btnAbrirLista = new Button();
            ((System.ComponentModel.ISupportInitialize)dtgvListaVehiculos).BeginInit();
            SuspendLayout();
            // 
            // dtgvListaVehiculos
            // 
            dtgvListaVehiculos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgvListaVehiculos.Location = new Point(12, 12);
            dtgvListaVehiculos.Name = "dtgvListaVehiculos";
            dtgvListaVehiculos.Size = new Size(629, 426);
            dtgvListaVehiculos.TabIndex = 0;
            dtgvListaVehiculos.CellClick += dtgvListaVehiculos_CellClick;
            dtgvListaVehiculos.ColumnHeaderMouseClick += dtgvListaVehiculos_ColumnHeaderMouseClick;
            // 
            // btnVolverAlMenuPrincipal
            // 
            btnVolverAlMenuPrincipal.Location = new Point(647, 393);
            btnVolverAlMenuPrincipal.Name = "btnVolverAlMenuPrincipal";
            btnVolverAlMenuPrincipal.Size = new Size(102, 45);
            btnVolverAlMenuPrincipal.TabIndex = 1;
            btnVolverAlMenuPrincipal.Text = "Volver al menú principal";
            btnVolverAlMenuPrincipal.UseVisualStyleBackColor = true;
            btnVolverAlMenuPrincipal.Click += btnVolverAlMenuPrincipal_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(647, 114);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(102, 45);
            btnModificar.TabIndex = 2;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // opfdAbrirLista
            // 
            opfdAbrirLista.FileName = "openFileDialog1";
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(647, 165);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(102, 45);
            btnEliminar.TabIndex = 3;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnGuardarLista
            // 
            btnGuardarLista.Location = new Point(647, 63);
            btnGuardarLista.Name = "btnGuardarLista";
            btnGuardarLista.Size = new Size(102, 45);
            btnGuardarLista.TabIndex = 4;
            btnGuardarLista.Text = "Guardar";
            btnGuardarLista.UseVisualStyleBackColor = true;
            btnGuardarLista.Click += btnGuardarLista_Click;
            // 
            // btnAbrirLista
            // 
            btnAbrirLista.Location = new Point(647, 12);
            btnAbrirLista.Name = "btnAbrirLista";
            btnAbrirLista.Size = new Size(102, 45);
            btnAbrirLista.TabIndex = 5;
            btnAbrirLista.Text = "Abrir";
            btnAbrirLista.UseVisualStyleBackColor = true;
            btnAbrirLista.Click += btnAbrirLista_Click;
            // 
            // FrmVerLista
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnAbrirLista);
            Controls.Add(btnGuardarLista);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btnVolverAlMenuPrincipal);
            Controls.Add(dtgvListaVehiculos);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "FrmVerLista";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Lista de vehiculos";
            ((System.ComponentModel.ISupportInitialize)dtgvListaVehiculos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dtgvListaVehiculos;
        private Button btnVolverAlMenuPrincipal;
        private Button btnModificar;
        private OpenFileDialog opfdAbrirLista;
        private Button btnEliminar;
        private SaveFileDialog sfdGuardarLista;
        private Button btnGuardarLista;
        private Button btnAbrirLista;
    }
}
