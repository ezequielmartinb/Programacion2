namespace Eventos
{
    partial class FrmAvisador
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
            lbl_Nombre = new Label();
            lbl_Apellido = new Label();
            lbl_NombreCompleto = new Label();
            txt_Nombre = new TextBox();
            txt_Apellido = new TextBox();
            btn_Crear = new Button();
            SuspendLayout();
            // 
            // lbl_Nombre
            // 
            lbl_Nombre.AutoSize = true;
            lbl_Nombre.Location = new Point(17, 65);
            lbl_Nombre.Name = "lbl_Nombre";
            lbl_Nombre.Size = new Size(51, 15);
            lbl_Nombre.TabIndex = 0;
            lbl_Nombre.Text = "Nombre";
            // 
            // lbl_Apellido
            // 
            lbl_Apellido.AutoSize = true;
            lbl_Apellido.Location = new Point(17, 105);
            lbl_Apellido.Name = "lbl_Apellido";
            lbl_Apellido.Size = new Size(51, 15);
            lbl_Apellido.TabIndex = 1;
            lbl_Apellido.Text = "Apellido";
            // 
            // lbl_NombreCompleto
            // 
            lbl_NombreCompleto.AutoSize = true;
            lbl_NombreCompleto.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_NombreCompleto.Location = new Point(87, 192);
            lbl_NombreCompleto.Name = "lbl_NombreCompleto";
            lbl_NombreCompleto.Size = new Size(0, 32);
            lbl_NombreCompleto.TabIndex = 2;
            // 
            // txt_Nombre
            // 
            txt_Nombre.Location = new Point(87, 57);
            txt_Nombre.Name = "txt_Nombre";
            txt_Nombre.Size = new Size(219, 23);
            txt_Nombre.TabIndex = 3;
            // 
            // txt_Apellido
            // 
            txt_Apellido.Location = new Point(87, 97);
            txt_Apellido.Name = "txt_Apellido";
            txt_Apellido.Size = new Size(219, 23);
            txt_Apellido.TabIndex = 4;
            // 
            // btn_Crear
            // 
            btn_Crear.Location = new Point(87, 146);
            btn_Crear.Name = "btn_Crear";
            btn_Crear.Size = new Size(219, 23);
            btn_Crear.TabIndex = 5;
            btn_Crear.Text = "button1";
            btn_Crear.UseVisualStyleBackColor = true;
            btn_Crear.Click += btn_Crear_Click;
            // 
            // FrmAvisador
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(351, 268);
            Controls.Add(btn_Crear);
            Controls.Add(txt_Apellido);
            Controls.Add(txt_Nombre);
            Controls.Add(lbl_NombreCompleto);
            Controls.Add(lbl_Apellido);
            Controls.Add(lbl_Nombre);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmAvisador";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "El Avisador";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_Nombre;
        private Label lbl_Apellido;
        private Label lbl_NombreCompleto;
        private TextBox txt_Nombre;
        private TextBox txt_Apellido;
        private Button btn_Crear;
    }
}
