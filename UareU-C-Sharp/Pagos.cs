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
    public partial class Pagos : Form
    {
        Dictionary<int, string> clientesSeleccionados = new Dictionary<int, string>();
        int limitePersonasPaquete = 0;
        public Pagos()
        {
            InitializeComponent();
            string archivoConfig = @"C:\conf_gympack\cadenasConexionSQL.txt";
            cadenaConexion = File.ReadAllText(archivoConfig);
            load_dgvClientes();
            load_dgvPaquetes();
            cbMetodoPago.SelectedIndex = 0;
            cbMetodoPago.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        //static string cadenaConexion = @"Data Source=DESKTOP-KUBF2IC\SQLEXPRESS;Initial Catalog=Gimnasio;Integrated Security=True";
        static string cadenaConexion;
        bool boolCliente = false;
        bool boolPaquete = false;


        private bool InsertarPago(decimal monto, int metodoPago, string concepto, int idPaquete, int idCliente)
        {
            bool regreso = false;
            using (SqlConnection connection = new SqlConnection(cadenaConexion))
            {
                string query = "INSERT INTO Pagos (Fecha_Pago, Monto, Metodo_Pago, Concepto, idPaquete, idCliente) " +
                              "VALUES (GETDATE(), @Monto, @MetodoPago, @Concepto, @idPaquete, @idCliente)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    //command.Parameters.AddWithValue("@FechaPago", fechaPago);
                    decimal dMonto = Convert.ToDecimal(monto) / limitePersonasPaquete;
                    command.Parameters.AddWithValue("@Monto", dMonto);
                    command.Parameters.AddWithValue("@MetodoPago", metodoPago);
                    command.Parameters.AddWithValue("@Concepto", concepto);
                    command.Parameters.AddWithValue("@idPaquete", idPaquete);
                    command.Parameters.AddWithValue("@idCliente", idCliente);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            regreso = true;
                            //MessageBox.Show("PAGO INSERTADO CORRECTAMENTE.");
                            //LimpiarPantalla();
                        }
                        else
                        {
                            regreso = false;
                            //MessageBox.Show("Error al insertar el pago.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
            return regreso;
        }

        public void LimpiarPantalla()
        {
            tbCliente.Clear();
            tbIdCliente.Clear();
            tbIdPaquete.Clear();
            tbFrecuencia.Clear();
            tbDescripcion.Clear();
            tbGrupo.Clear();
            tbPrecio.Clear();
            tbBuscarCliente.Clear();
            cbMetodoPago.SelectedIndex = 0;
            btnPago.Enabled = false;
            clientesSeleccionados.Clear();
            load_dgvClientes();
            load_dgvPaquetes();
        }

        public void load_dgvClientes(string filtro = "")
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
                    string consulta = "select idCliente,Nombre,Sexo,Edad from Clientes where Activo = 1";
                    if (!string.IsNullOrEmpty(filtro))
                    {
                        consulta += " AND Nombre LIKE @filtro ";
                    }
                    consulta += " ORDER BY Nombre ASC;";
                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        if (!string.IsNullOrEmpty(filtro))
                        {
                            // El % permite buscar cualquier coincidencia (al inicio, medio o fin)
                            comando.Parameters.AddWithValue("@filtro", "%" + filtro + "%");
                        }
                        // Ejecutar la consulta y obtener el lector de datos
                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                int idActual = Convert.ToInt32(lector["idCliente"]);
                                string nombreActual = lector["Nombre"].ToString();

                                int rowIndex = dgvClientes.Rows.Add(
                                    idActual,
                                    nombreActual,
                                    lector["Sexo"].ToString(),
                                    lector["Edad"].ToString()
                                );

                                // SI EL ID ESTÁ EN EL DICCIONARIO, LO PINTAMOS DE AMARILLO
                                if (clientesSeleccionados.ContainsKey(idActual))
                                {
                                    dgvClientes.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Yellow;
                                }
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

        public void load_dgvPaquetes()
        {
            dgvPaquetes.Rows.Clear();
            try
            {
                // Crear la conexión
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    // Abrir la conexión
                    conexion.Open();

                    // Crear el comando SQL
                    string consulta = "select idPaquete,Grupo,Precio,Frecuencia,Descripcion,NroPersonas FROM Paquetes ORDER BY idPaquete ASC;";
                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        // Ejecutar la consulta y obtener el lector de datos
                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                DataGridViewRow nuevaFila = new DataGridViewRow();
                                nuevaFila.CreateCells(dgvPaquetes);
                                nuevaFila.Cells[0].Value = lector["idPaquete"].ToString();
                                nuevaFila.Cells[1].Value = lector["Grupo"].ToString();
                                nuevaFila.Cells[2].Value = lector["Precio"].ToString();
                                nuevaFila.Cells[3].Value = lector["Frecuencia"].ToString();
                                nuevaFila.Cells[4].Value = lector["Descripcion"].ToString();
                                nuevaFila.Cells[5].Value = lector["NroPersonas"].ToString();
                                dgvPaquetes.Rows.Add(nuevaFila);
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

        private void Pagos_Load(object sender, EventArgs e)
        {
            
        }

        private void dgvClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar si se hizo doble clic en una celda (no en un encabezado)
            if (e.RowIndex >= 0)
            {
                if (!boolPaquete)
                {
                    MessageBox.Show("Primero debe seleccionar un paquete.");
                    return;
                }

                int idCliente = Convert.ToInt32(dgvClientes.Rows[e.RowIndex].Cells[0].Value);
                string NombreCliente = dgvClientes.Rows[e.RowIndex].Cells[1].Value.ToString();
                boolCliente = true;

                if (clientesSeleccionados.ContainsKey(idCliente))
                {
                    clientesSeleccionados.Remove(idCliente);
                    dgvClientes.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                }
                else
                {
                    // Validamos si aún hay cupo según el paquete
                    if (clientesSeleccionados.Count < limitePersonasPaquete)
                    {
                        clientesSeleccionados.Add(idCliente, NombreCliente);
                        dgvClientes.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Yellow;
                    }
                    else
                    {
                        MessageBox.Show($"Este paquete solo permite {limitePersonasPaquete} persona(s).");
                    }
                }
                tbCliente.Text = string.Join(Environment.NewLine, clientesSeleccionados.Values);

                // Habilitar botón si la lista está completa
                boolCliente = (clientesSeleccionados.Count == limitePersonasPaquete);
                btnPago.Enabled = (boolPaquete && boolCliente);
            }
        }

        private void dgvPaquetes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar si se hizo doble clic en una celda (no en un encabezado)
            if (e.RowIndex >= 0)
            {
                int idPaquete = Convert.ToInt32(dgvPaquetes.Rows[e.RowIndex].Cells[0].Value);
                string Grupo = dgvPaquetes.Rows[e.RowIndex].Cells[1].Value.ToString();
                string Precio = dgvPaquetes.Rows[e.RowIndex].Cells[2].Value.ToString();
                string Frecuancia = dgvPaquetes.Rows[e.RowIndex].Cells[3].Value.ToString();
                string Descripcion = dgvPaquetes.Rows[e.RowIndex].Cells[4].Value.ToString();
                string NroClientes = dgvPaquetes.Rows[e.RowIndex].Cells[5].Value.ToString();
                tbIdPaquete.Text = idPaquete.ToString();
                tbGrupo.Text = Grupo;
                tbPrecio.Text = Precio;
                tbFrecuencia.Text = Frecuancia;
                tbDescripcion.Text = Descripcion;
                tbNroPersonas.Text = NroClientes;
                boolPaquete = true;
                if (boolPaquete && boolCliente)
                {
                    btnPago.Enabled = true;
                }

                limitePersonasPaquete = Convert.ToInt32(dgvPaquetes.Rows[e.RowIndex].Cells["NroPersonas"].Value);
                foreach (DataGridViewRow row in dgvClientes.Rows) row.DefaultCellStyle.BackColor = Color.White;
                boolPaquete = true;
                MessageBox.Show($"Paquete seleccionado. Debe elegir {limitePersonasPaquete} cliente(s).");
                //ActualizarEstadoBotonPago();
            }
        }

        private void btnPago_Click(object sender, EventArgs e)
        {
            bool rInsert = false;
            int i_metodoPago = 0;
            string s_metodoPago = cbMetodoPago.SelectedItem.ToString();
            switch (s_metodoPago)
            {
                case "EFECTIVO":
                    i_metodoPago = 1;
                    break;
                case "TARJETA CREDITO":
                    i_metodoPago = 2;
                    break;
                case "TARJETA DEBITO":
                    i_metodoPago = 3;
                    break;
                case "TRANSFERENCIA":
                    i_metodoPago = 4;
                    break;
                default:
                    i_metodoPago = 0;
                    break;
            }

            try
            {
                foreach (KeyValuePair<int, string> cliente in clientesSeleccionados)
                {
                    //string ConceptoPago = "Cliente:" + tbCliente.Text + "|ID Paquete:" + tbIdPaquete.Text + "|FREC:" + tbFrecuencia.Text + "|Precio:" + tbPrecio.Text + "|Grupo:" + tbGrupo.Text + "|Descripcion Paquete:" + tbDescripcion.Text;
                    //InsertarPago(Convert.ToDecimal(tbPrecio.Text), i_metodoPago, ConceptoPago, Convert.ToInt32(tbIdPaquete.Text), Convert.ToInt32(tbIdCliente.Text));
                    int idIndividual = cliente.Key;
                    string nombreIndividual = cliente.Value;

                    // Ahora el concepto lleva el nombre específico de este cliente en el ciclo
                    string ConceptoPago = "Cliente:" + nombreIndividual +
                                         "|ID Paquete:" + tbIdPaquete.Text +
                                         "|FREC:" + tbFrecuencia.Text +
                                         "|Precio:" + tbPrecio.Text +
                                         "|Grupo:" + tbGrupo.Text +
                                         "|Descripcion Paquete:" + tbDescripcion.Text;

                    rInsert = InsertarPago(Convert.ToDecimal(tbPrecio.Text), i_metodoPago, ConceptoPago,
                                 Convert.ToInt32(tbIdPaquete.Text), idIndividual);
                    if (!rInsert)
                    {
                        rInsert = false;
                        break;
                    }

                }
                if(rInsert)
                    MessageBox.Show("TODOS LOS PAGOS FUERON REGISTRADOS.");
                else
                    MessageBox.Show("OCURRIO UN ERROR EL REGISTRAR LOS PAGOS.");
                LimpiarPantalla();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al procesar el pago grupal: " + ex.Message);
            }
        }

        private void tbBuscarCliente_TextChanged(object sender, EventArgs e)
        {
            load_dgvClientes(tbBuscarCliente.Text);
        }
    }
}
