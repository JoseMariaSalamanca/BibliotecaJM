using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BibliotecaJM
{
    public partial class FM_LogIn : FM_Modelo
    {
        String key = null;
        int nFallos=0;
        public FM_LogIn()
        {
            InitializeComponent();
        }

        private void bAcceder_Click(object sender, EventArgs e)
        {
            DS_Usuarios.usuariosDataTable usu = new DS_Usuarios.usuariosDataTable();
            DS_UsuariosTableAdapters.usuariosTableAdapter taUsuarios = new DS_UsuariosTableAdapters.usuariosTableAdapter();
            taUsuarios.FillByAutentificacion(usu, tbUsuario.Text, tbContrasenna.Text);
            if (usu.Rows.Count != 1)
            {
                nFallos++;
                MessageBox.Show("Usuario o contraseña incorrectas. \n Numero de intentos restantes:" + (3 - nFallos));
                tbUsuario.Clear();
                tbContrasenna.Clear();
                if (nFallos >= 3)
                {
                    MessageBox.Show("Ha excedido el numero de intentos de inicio de sesión.");
                    Application.Exit();
                }
            }
            else
                Console.WriteLine(usu.Rows[0].ToString());
            this.Close();
        }

        private void FM_LogIn_FormClosing(object sender, FormClosingEventArgs e)
        {

            Application.Exit();
        }

        private void tbUsuario_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
