using Entidades.Final;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp
{
    ///Agregar manejo de excepciones en TODOS los lugares críticos!!!

    public delegate void DelegadoThreadConParam(object param);

    public partial class FrmPrincipal : Form
    {
        protected Task hilo;
        protected CancellationTokenSource cts;
        private event DelegadoThreadConParam ActualizarListadoUsuarioOn;

        public FrmPrincipal()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            this.Text = "Cambiar por su apellido y nombre";
            MessageBox.Show(this.Text);
        }

        ///
        /// CRUD
        ///
        private void listadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmListado frm = new FrmListado();
            frm.StartPosition = FormStartPosition.CenterScreen;

            frm.Show(this);
        }

        ///
        /// VER LOG
        ///
        private void verLogToolStripMenuItem_Click(object sender, EventArgs e)
        {

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Archivos log (*.log)|*.log|Todos los archivos(*.*)|*.*";
            ofd.Title = "Abrir archivo de usuarios";
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            ofd.DefaultExt = "usuarios";
            DialogResult rta = ofd.ShowDialog(this);///Reemplazar por la llamada al método correspondiente del OpenFileDialog
            if (rta == DialogResult.OK)
            {
                /// Mostrar en txtUsuariosLog.Text el contenido del archivo .log
                string path = ofd.FileName;
                if (File.Exists(path))
                {
                    StreamReader sr = new StreamReader(path);
                    string texto = sr.ReadToEnd();
                    this.txtUsuariosLog.Text = texto;
                }

            }
            else
            {
                MessageBox.Show("No se muestra .log");
            }
        }

        ///
        /// DESERIALIZAR JSON
        ///
        private void deserializarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Entidades.Final.Usuario> listado = null;
            string path = Directory.GetCurrentDirectory(); /// Reemplazar por el path correspondiente
            path = Path.Join(path, $"{Path.DirectorySeparatorChar}usuarios_repetidos.json");

            bool todoOK = Manejadora.DeserializarJSON(path, out listado); /// Reemplazar por la llamada al método correspondiente de Manejadora

            if (todoOK)
            {
                this.txtUsuariosLog.Clear();
                foreach (Usuario usuario in listado)
                {
                    this.txtUsuariosLog.Text += $"{usuario.ToString()}\n";
                }
                /// Mostrar en txtUsuariosLog.Text el contenido de la deserialización.
            }
            else
            {
                MessageBox.Show("NO se pudo deserializar a JSON");
            }

        }

        ///
        /// TASK
        ///
        private void taskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.cts = new CancellationTokenSource();
            ///Se inicia el hilo.          
            this.hilo = new Task(() => ActualizarListadoUsuarios(this.lstUsuarios));
            /// inicializar tarea
            hilo.Start();

            ///Se desasocia al manejador de eventos.
            this.taskToolStripMenuItem.Click -= new EventHandler(this.taskToolStripMenuItem_Click);

        }


        ///PARA ACTUALIZAR LISTADO DESDE BD EN HILO
        public void ActualizarListadoUsuarios(object param)
        {
            /// Implementar...
            List<Usuario> listaUsuarios = ADO.ObtenerTodos();
            CancellationToken cancellationToken = this.cts.Token;

            if (param is ListBox listBox)
            {
                this.hilo = Task.Run(() =>
                {
                    while (!cancellationToken.IsCancellationRequested)
                    {
                        listBox.Invoke(new Action(() =>
                        {
                            listBox.Items.Clear();
                            foreach (Usuario usuario in listaUsuarios)
                            {
                                listBox.Items.Add(usuario.ToString());
                            }
                            listBox.BackColor = System.Drawing.Color.Black;
                            listBox.ForeColor = System.Drawing.Color.White;
                        }));

                        Thread.Sleep(1500);

                        listBox.Invoke(new Action(() =>
                        {
                            listBox.BackColor = System.Drawing.Color.White;
                            listBox.ForeColor = System.Drawing.Color.Black;
                        }
                        ));

                        Thread.Sleep(1500);
                    }
                }, cancellationToken);
            }
        }

        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            ///CANCELAR HILO
            if (this.cts != null && this.cts.IsCancellationRequested)
            {
                this.cts.Cancel();
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }
    }
}
