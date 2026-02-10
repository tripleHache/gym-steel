using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UareUWindowsMSSQLCSharp
{
    public partial class LOGIN : Form
    {
        public LOGIN()
        {
            InitializeComponent();
            string archivoConfig = @"C:\conf_gympack\cadenasConexionSQL.txt";
            cadenaConexion = File.ReadAllText(archivoConfig);
        }
        string cadenaConexion;
        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            login();
        }

        private void login()
        {

            try
            {
                // Crear la conexión
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    // Abrir la conexión
                    conexion.Open();

                    // Crear el comando SQL
                    string consulta = "SELECT pass FROM Usuarios WHERE nombre = '" + tbUsuario.Text + "'";
                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        // Ejecutar la consulta y obtener el lector de datos
                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                string contrasena = lector.GetString(0);

                                if (contrasena == tbContrasena.Text)
                                {
                                    this.Hide();
                                    MENU objMenu = new MENU();
                                    objMenu.ShowDialog();

                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al consultar la base de datos: " + ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void tbContrasena_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                login();
            }
        }
    }
}
