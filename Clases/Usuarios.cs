using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Taller2.Clases
{
    internal class Usuarios
    {
        public void mostrarUsuarios(DataGridView tablaUsuarios)
        {
            try
            {
                string query = "SELECT * FROM usuarios;";
                ConexionSql objetoConexion = new ConexionSql();
                tablaUsuarios.DataSource = null;
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, objetoConexion.establecerConexion());
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                tablaUsuarios.DataSource = dt;
                objetoConexion.cerrarConexion();
            }
            catch (Exception ex) 
            {
                MessageBox.Show("No se mostraron los datos de la base de datos. Error: " + ex.ToString());
            }
        }

        public void agregarUsuario(TextBox nombre, TextBox usuario, ComboBox tipoUsuario, TextBox password, TextBox confirmar)
        {
            try
            {
                string query = "INSERT INTO usuarios (nombre, usuario, contrasena, tipo_usuario, confirmar) VALUES " +
                "('" + nombre.Text + "', '" + usuario.Text + "', '" + password.Text + "', '" + tipoUsuario.Text + "', '" + confirmar.Text + "');";
                ConexionSql objetoConexion = new ConexionSql();
                MySqlCommand myCommand = new MySqlCommand(query, objetoConexion.establecerConexion());
                MySqlDataReader reader = myCommand.ExecuteReader();
                MessageBox.Show("¡Registros guardados exitosamente!");
                while (reader.Read()) { }
                objetoConexion.cerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar los registros. Error: " + ex.ToString());
            }
        }

        public void seleccionarUsuario(DataGridView tablaUsuarios, TextBox id, TextBox nombre, TextBox usuario, 
            ComboBox tipoUsuario, TextBox password, TextBox confirmar)
        {
            try
            {
                id.Text = tablaUsuarios.CurrentRow.Cells[0].Value.ToString();
                nombre.Text = tablaUsuarios.CurrentRow.Cells[1].Value.ToString();
                usuario.Text = tablaUsuarios.CurrentRow.Cells[2].Value.ToString();
                password.Text = tablaUsuarios.CurrentRow.Cells[3].Value.ToString();
                tipoUsuario.Text = tablaUsuarios.CurrentRow.Cells[4].Value.ToString();
                confirmar.Text = tablaUsuarios.CurrentRow.Cells[5].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo seleccionar los registros de la base de datos. Error: " + ex.ToString());
            }
        }

        public void modificarUsuario(TextBox id,TextBox nombre, TextBox usuario, ComboBox tipoUsuario, TextBox password, TextBox confirmar)
        {
            try
            {
                string query = "UPDATE usuarios SET nombre='"+nombre.Text+"', usuario='"+usuario.Text+"', contrasena='"+password.Text+
                    "', tipo_usuario='"+tipoUsuario.Text+"', confirmar='"+confirmar.Text+"' WHERE id='"+id.Text+"';";
                ConexionSql objetoConexion = new ConexionSql();
                MySqlCommand myCommand = new MySqlCommand(query, objetoConexion.establecerConexion());
                MySqlDataReader reader = myCommand.ExecuteReader();
                MessageBox.Show("¡Registros modificados exitosamente!");
                while (reader.Read()) { }
                objetoConexion.cerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo modificar los registros. Error: " + ex.ToString());
            }
        }

        public void eliminarUsuario(TextBox id)
        {
            try
            {
                string query = "DELETE FROM usuarios WHERE id='"+id.Text+"';";
                ConexionSql objetoConexion = new ConexionSql();
                MySqlCommand myCommand = new MySqlCommand(query, objetoConexion.establecerConexion());
                MySqlDataReader reader = myCommand.ExecuteReader();
                MessageBox.Show("¡Usuario eliminado exitosamente!");
                while (reader.Read()) { }
                objetoConexion.cerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo eliiminar el usuario. Error: " + ex.ToString());
            }
        }
    }
}
