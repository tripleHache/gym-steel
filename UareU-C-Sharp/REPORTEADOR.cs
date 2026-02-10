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
    public partial class REPORTEADOR : Form
    {
        public REPORTEADOR()
        {
            InitializeComponent();
            string archivoConfig = @"C:\conf_gympack\cadenasConexionSQL.txt";
            cadenaConexion = File.ReadAllText(archivoConfig);
        }
        
        string cadenaConexion;
        //private string cadenaConexion = @"Data Source=DESKTOP-KUBF2IC\SQLEXPRESS;Initial Catalog=Gimnasio;Integrated Security=True";

        private void REPORTEADOR_Load(object sender, EventArgs e)
        {
            //cargarHISTORICO_dgvClientes();
        }

        public void cargarHISTORICO_dgvClientes()
        {
            dgvClientes.Rows.Clear();
            try
            {
                // Crear la conexión
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    // Abrir la conexión
                    conexion.Open();

                    // Crear el comando SQL
                    string consulta = "SELECT A.ID_Pago,A.Monto,B.Nombre,C.Descripcion,A.Fecha_Pago FROM Pagos AS A INNER JOIN Clientes AS B ON A.idCliente = B.idCliente INNER JOIN Paquetes AS C ON A.idPaquete = C.idPaquete ORDER BY A.Fecha_Pago DESC;";
                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        // Ejecutar la consulta y obtener el lector de datos
                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                DataGridViewRow nuevaFila = new DataGridViewRow();
                                nuevaFila.CreateCells(dgvClientes);
                                nuevaFila.Cells[0].Value = lector["ID_Pago"].ToString();
                                nuevaFila.Cells[1].Value = lector["Monto"].ToString();
                                nuevaFila.Cells[2].Value = lector["Nombre"].ToString();
                                nuevaFila.Cells[3].Value = lector["Descripcion"].ToString();
                                nuevaFila.Cells[4].Value = lector["Fecha_Pago"].ToString();
                                dgvClientes.Rows.Add(nuevaFila);
                            }
                        }
                    }
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al consultar la base de datos: " + ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        public void cargarFECHAS_dgvClientes()
        {
            dgvClientes.Rows.Clear();
            try
            {
                // Crear la conexión
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    // Abrir la conexión
                    conexion.Open();

                    DateTime desde = dtpDesde.Value;
                    string s_desde = desde.ToString("yyyy-MM-dd");

                    DateTime hasta = dtpHasta.Value;
                    string s_hasta = hasta.ToString("yyyy-MM-dd");

                    // Crear el comando SQL
                    string consulta = "SELECT A.ID_Pago,A.Monto,B.Nombre,C.Descripcion,A.Fecha_Pago FROM Pagos AS A INNER JOIN Clientes AS B ON A.idCliente = B.idCliente INNER JOIN Paquetes AS C ON A.idPaquete = C.idPaquete WHERE A.Fecha_Pago BETWEEN '"+ s_desde + "' AND '" + s_hasta + "' ORDER BY A.Fecha_Pago DESC;";
                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        // Ejecutar la consulta y obtener el lector de datos
                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                DataGridViewRow nuevaFila = new DataGridViewRow();
                                nuevaFila.CreateCells(dgvClientes);
                                nuevaFila.Cells[0].Value = lector["ID_Pago"].ToString();
                                nuevaFila.Cells[1].Value = lector["Monto"].ToString();
                                nuevaFila.Cells[2].Value = lector["Nombre"].ToString();
                                nuevaFila.Cells[3].Value = lector["Descripcion"].ToString();
                                nuevaFila.Cells[4].Value = lector["Fecha_Pago"].ToString();
                                dgvClientes.Rows.Add(nuevaFila);
                            }
                        }
                    }
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al consultar la base de datos: " + ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        public void cargarFECHA_dgvClientes()
        {
            dgvClientes.Rows.Clear();
            try
            {
                // Crear la conexión
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    // Abrir la conexión
                    conexion.Open();

                    DateTime fecha = dtpFecha.Value;
                    string s_fecha = fecha.ToString("yyyy-MM-dd");

                    // Crear el comando SQL
                    string consulta = "SELECT A.ID_Pago,A.Monto,B.Nombre,C.Descripcion,A.Fecha_Pago FROM Pagos AS A INNER JOIN Clientes AS B ON A.idCliente = B.idCliente INNER JOIN Paquetes AS C ON A.idPaquete = C.idPaquete WHERE CAST(A.Fecha_Pago AS DATE) = '" + s_fecha + "' ORDER BY A.Fecha_Pago DESC;";
                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        // Ejecutar la consulta y obtener el lector de datos
                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                DataGridViewRow nuevaFila = new DataGridViewRow();
                                nuevaFila.CreateCells(dgvClientes);
                                nuevaFila.Cells[0].Value = lector["ID_Pago"].ToString();
                                nuevaFila.Cells[1].Value = lector["Monto"].ToString();
                                nuevaFila.Cells[2].Value = lector["Nombre"].ToString();
                                nuevaFila.Cells[3].Value = lector["Descripcion"].ToString();
                                nuevaFila.Cells[4].Value = lector["Fecha_Pago"].ToString();
                                dgvClientes.Rows.Add(nuevaFila);
                            }
                        }
                    }
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al consultar la base de datos: " + ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (rbFechas.Checked)
            {
                dtpDesde.Enabled = true;
                dtpHasta.Enabled = true;
                dtpFecha.Enabled = false;
            }
        }

        private void rbHistorico_CheckedChanged(object sender, EventArgs e)
        {
            if (rbHistorico.Checked)
            {
                dtpDesde.Enabled = false;
                dtpHasta.Enabled = false;
                dtpFecha.Enabled = false;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (rbHistorico.Checked)
            {
                cargarHISTORICO_dgvClientes();
            }
            else if (rbFechas.Checked)
            {
                cargarFECHAS_dgvClientes();
            }
            else if (rbFecha.Checked)
            {
                cargarFECHA_dgvClientes();
            }

        }

        private void rbFecha_CheckedChanged(object sender, EventArgs e)
        {
            if (rbFecha.Checked)
            {
                dtpFecha.Enabled = true;
                dtpDesde.Enabled = false;
                dtpHasta.Enabled = false;
            }
        }
    }
}
