using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Taller2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Clases.Usuarios objetoUsuarios = new Clases.Usuarios();
            objetoUsuarios.mostrarUsuarios(dgvTotalUsuarios);
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Clases.Usuarios objetoUsuarios = new Clases.Usuarios();
            objetoUsuarios.agregarUsuario(txtNombre, txtUsuario, cbTipoUsuario, txtContraseña, txtConfirmar);
            objetoUsuarios.mostrarUsuarios(dgvTotalUsuarios);
        }

        private void dgvTotalUsuarios_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Clases.Usuarios objetoUsuarios = new Clases.Usuarios();
            objetoUsuarios.seleccionarUsuario(dgvTotalUsuarios, txtID, txtNombre, txtUsuario, cbTipoUsuario, txtContraseña, txtConfirmar);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Clases.Usuarios objetoUsuarios = new Clases.Usuarios();
            objetoUsuarios.modificarUsuario(txtID, txtNombre, txtUsuario, cbTipoUsuario, txtContraseña, txtConfirmar);
            objetoUsuarios.mostrarUsuarios(dgvTotalUsuarios);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Clases.Usuarios objetoUsuarios = new Clases.Usuarios();
            objetoUsuarios.eliminarUsuario(txtID);
            objetoUsuarios.mostrarUsuarios(dgvTotalUsuarios);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtID.Clear();
            txtNombre.Clear();
            txtUsuario.Clear();
            txtContraseña.Clear();
            txtConfirmar.Clear();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
