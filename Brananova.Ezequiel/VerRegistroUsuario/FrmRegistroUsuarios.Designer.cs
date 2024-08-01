namespace VerRegistroUsuario
{
    partial class FrmRegistroUsuarios
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
            listBoxUsuarios = new ListBox();
            btnVolverAlMenuPrincipal = new Button();
            SuspendLayout();
            // 
            // listBoxUsuarios
            // 
            listBoxUsuarios.FormattingEnabled = true;
            listBoxUsuarios.ItemHeight = 15;
            listBoxUsuarios.Location = new Point(12, 12);
            listBoxUsuarios.Name = "listBoxUsuarios";
            listBoxUsuarios.Size = new Size(227, 394);
            listBoxUsuarios.TabIndex = 0;
            // 
            // btnVolverAlMenuPrincipal
            // 
            btnVolverAlMenuPrincipal.Location = new Point(245, 365);
            btnVolverAlMenuPrincipal.Name = "btnVolverAlMenuPrincipal";
            btnVolverAlMenuPrincipal.Size = new Size(108, 41);
            btnVolverAlMenuPrincipal.TabIndex = 1;
            btnVolverAlMenuPrincipal.Text = "Volver al menú principal";
            btnVolverAlMenuPrincipal.UseVisualStyleBackColor = true;
            btnVolverAlMenuPrincipal.Click += btnVolverAlMenuPrincipal_Click;
            // 
            // FrmRegistroUsuarios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(386, 427);
            Controls.Add(btnVolverAlMenuPrincipal);
            Controls.Add(listBoxUsuarios);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmRegistroUsuarios";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registro de usuarios";
            ResumeLayout(false);
        }

        #endregion

        private ListBox listBoxUsuarios;
        private Button btnVolverAlMenuPrincipal;
    }
}
