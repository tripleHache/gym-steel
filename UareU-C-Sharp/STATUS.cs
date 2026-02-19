using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UareUWindowsMSSQLCSharp
{
    public partial class STATUS : Form
    {
        private string cadenaConexion;
        public STATUS(int idCliente)
        {
            InitializeComponent();
            string archivoConfig = @"C:\conf_gympack\cadenasConexionSQL.txt";
            cadenaConexion = File.ReadAllText(archivoConfig);
            CargarEstatusCliente(idCliente);
        }

        public void CargarEstatusCliente(int idCliente)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand("Cliente_status_Individual", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.AddWithValue("@idCliente", idCliente);

                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            if (lector.Read())
                            {
                                string nombre = lector["Nombre"].ToString();
                                DateTime vigencia = Convert.ToDateTime(lector["Vigencia"]);

                                lblNombre.Text = "Cliente: " + nombre;
                                lblVigencia.Text = "Vence el: " + vigencia.ToString("dd/MM/yyyy");

                                // Lógica visual para el estatus
                                if (vigencia >= DateTime.Today)
                                {
                                    lblEstatus.Text = "ESTATUS: VIGENTE";
                                    lblEstatus.ForeColor = Color.Green;
                                }
                                else
                                {
                                    lblEstatus.Text = "ESTATUS: VENCIDO";
                                    lblEstatus.ForeColor = Color.Red;
                                }
                            }
                            else
                            {
                                MessageBox.Show("No se encontraron registros activos para este cliente.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar estatus: " + ex.Message);
            }
        }
    }
}
