using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DPUruNet;
using System.Data.SqlClient;
using System.IO;

namespace UareUWindowsMSSQLCSharp
{
    public partial class Form_Main : Form
    {
        private Reader reader;
        private string xmlHuellaFinal = string.Empty;
        private string cadenaConexion;
        public Reader GetReader
        {
            get
            {
                return reader;
            }

        }
        public Form_Main()
        {
            InitializeComponent();
            string archivoConfig = @"C:\conf_gympack\cadenasConexionSQL.txt";
            cadenaConexion = File.ReadAllText(archivoConfig);
            CheckReaderPluggedin();
            load_dgvClientes();
            cbSexo.SelectedIndex = 0;
            cbSexo.DropDownStyle = ComboBoxStyle.DropDownList;

            if (UsuarioSesion.Rol == 2)
            {
                btnEliminar.Visible = false;
            }
        }

        private void CheckReaderPluggedin()
        {
            ReaderCollection rc = ReaderCollection.GetReaders();
            //If reader count is zero, inform user
            if (rc.Count == 0)
            {
                readerNotFoundlbl.Visible = true;
            }
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
                    string consulta = "select * from Clientes where Activo = 1";
                    if (!string.IsNullOrEmpty(filtro))
                    {
                        consulta += " AND Nombre LIKE @filtro";
                    }
                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        if (!string.IsNullOrEmpty(filtro))
                        {
                            comando.Parameters.AddWithValue("@filtro", "%" + filtro + "%");
                        }
                        // Ejecutar la consulta y obtener el lector de datos
                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                DataGridViewRow nuevaFila = new DataGridViewRow();
                                nuevaFila.CreateCells(dgvClientes);
                                nuevaFila.Cells[0].Value = lector["idCliente"].ToString();
                                nuevaFila.Cells[1].Value = lector["Nombre"].ToString();
                                nuevaFila.Cells[2].Value = lector["Sexo"].ToString();
                                nuevaFila.Cells[3].Value = lector["Edad"].ToString();
                                nuevaFila.Cells[4].Value = lector["Huella"].ToString();
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "GUARDAR CLIENTE")
            {
                GuardarCliente();
            }
            else
            {
                modificarCliente(Convert.ToInt32(tbidCliente.Text));
            }
        }
        private void GuardarCliente()
        {
            if (string.IsNullOrEmpty(xmlHuellaFinal))
            {
                MessageBox.Show("Por favor, capture la huella del socio antes de guardar.");
                return;
            }

            try
            {

                // Crear la conexión
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    // Abrir la conexión
                    conexion.Open();
                    string sql = "INSERT INTO Clientes (Nombre,Sexo,Edad,Huella,HuellaXml) VALUES(@nombre,@sexo,@edad,@huella,@huellaXml)";
                    SqlCommand cmd = new SqlCommand(sql, conexion);
                    cmd.Parameters.AddWithValue("@nombre", tbNombre.Text);
                    cmd.Parameters.AddWithValue("@edad", tbEdad.Text);
                    cmd.Parameters.AddWithValue("@sexo", cbSexo.SelectedItem);
                    cmd.Parameters.AddWithValue("@huella", tbHuella.Text);
                    cmd.Parameters.AddWithValue("@huellaXml", xmlHuellaFinal);

                    int filasAfectadas = cmd.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show("CLIENTE GUARDADO CORRECTAMENTE.");
                        LimpiarCampos();
                        //load_dgvClientes();
                    }
                    else
                    {
                        MessageBox.Show("ERROR AL GUARDAR CLIENTE.");
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
        private void modificarCliente(int idCliente)
        {
            if (string.IsNullOrEmpty(xmlHuellaFinal))
            {
                MessageBox.Show("Por favor, capture la huella del socio antes de modificar.");
                return;
            }

            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    // Abrir la conexión
                    conexion.Open();
                    string sql = "UPDATE Clientes SET Nombre = @nombre,Sexo = @sexo,Edad = @edad, Huella = @huella, HuellaXml = @huellaXml WHERE idCliente = @idcliente;";
                    SqlCommand cmd = new SqlCommand(sql, conexion);
                    cmd.Parameters.AddWithValue("@idcliente", idCliente);
                    cmd.Parameters.AddWithValue("@nombre", tbNombre.Text);
                    cmd.Parameters.AddWithValue("@edad", tbEdad.Text);
                    cmd.Parameters.AddWithValue("@sexo", cbSexo.SelectedItem);
                    cmd.Parameters.AddWithValue("@huella", tbHuella.Text);
                    cmd.Parameters.AddWithValue("@huellaXml", xmlHuellaFinal);

                    int filasAfectadas = cmd.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show("CLIENTE MODIFICADO CORRECTAMENTE.");
                        LimpiarCampos();
                        //load_dgvClientes();
                    }
                    else
                    {
                        MessageBox.Show("ERROR AL MODIFICAR CLIENTE.");
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
        private void dgvClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificamos que el clic sea en una fila y no en el encabezado (índice -1)
            if (e.RowIndex >= 0)
            {
                foreach (DataGridViewRow r in dgvClientes.Rows)
                {
                    r.DefaultCellStyle.BackColor = Color.White; // O Color.Empty para usar el default
                }
                // Obtener la fila completa
                DataGridViewRow row = dgvClientes.Rows[e.RowIndex];
                // Pintar de amarillo
                row.DefaultCellStyle.BackColor = Color.Yellow;
                // Extraer los datos por nombre de columna o por índice
                string id = row.Cells["id"].Value.ToString();
                string nombre = row.Cells["nombre"].Value.ToString();
                string sexo = row.Cells["sexo"].Value.ToString();
                string edad = row.Cells["edad"].Value.ToString();
                string huella = row.Cells["huella"].Value.ToString();

                // Ejemplo: Mostrar los datos o pasarlos a otro formulario
                tbidCliente.Text = id;
                tbNombre.Text = nombre;
                if (sexo == "M")
                {
                    cbSexo.SelectedIndex = 0;
                }
                else if (sexo == "F")
                {
                    cbSexo.SelectedIndex = 1;
                }
                tbEdad.Text = edad;
                button1.Text = "MODIFICAR CLIENTE";
                button1.Enabled = true;
                btnEliminar.Enabled = true;
                tbHuella.Text = huella;
            }
        }
        private void eliminarCliente(int idCliente)
        {
            DialogResult result = MessageBox.Show("¿Desea dar de baja a este cliente? Se mantendrá en el historial pero no podrá ingresar.",
                "Confirmar Baja", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                    {
                        conexion.Open();
                        // Cambiamos el DELETE por un UPDATE de la columna Activo
                        string sql = "UPDATE Clientes SET Activo = 0 WHERE idCliente = @idcliente;";

                        using (SqlCommand cmd = new SqlCommand(sql, conexion))
                        {
                            cmd.Parameters.AddWithValue("@idcliente", idCliente);

                            if (cmd.ExecuteNonQuery() > 0)
                            {
                                MessageBox.Show("CLIENTE DADO DE BAJA EXITOSAMENTE.");
                                LimpiarCampos();
                                //load_dgvClientes(); // Refresca la lista
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al procesar la baja: " + ex.Message);
                }
            }
        }
        private void LimpiarCampos()
        {
            // Vacía los cuadros de texto
            tbidCliente.Clear();
            tbNombre.Clear();
            tbEdad.Clear();
            tbHuella.Clear();
            tbBuscar.Clear();
            // Regresa el combo de sexo a la primera opción (por defecto "M")
            cbSexo.SelectedIndex = 0;

            // Resetea la variable donde se guarda la huella capturada
            xmlHuellaFinal = string.Empty;

            // Muy importante: Regresa el texto del botón a su estado original
            button1.Text = "GUARDAR CLIENTE";
            button1.Enabled = false;
            btnEliminar.Enabled = false;

            // Opcional: Quitar colores de selección en el DataGridView
            dgvClientes.ClearSelection();
            load_dgvClientes();
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbidCliente.Text))
            {
                eliminarCliente(Convert.ToInt32(tbidCliente.Text));
            }
            else
            {
                MessageBox.Show("Seleccione un cliente de la lista primero.");
            }
        }

        private void enrollbtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbNombre.Text) && !string.IsNullOrEmpty(tbEdad.Text))
            {
                // Launch EnrollForm
                string nombre_archivo_huella = tbNombre.Text.Replace(" ", "") + "_" + tbEdad.Text.Replace(" ", "") + "_" + cbSexo.SelectedValue;
                Enroll enrollForm = new Enroll(nombre_archivo_huella);
                enrollForm._sender = this;
                //enrollForm.ShowDialog();
                if (enrollForm.ShowDialog() == DialogResult.OK)
                {
                    xmlHuellaFinal = Fmd.SerializeXml(enrollForm.EnrollmentFmdResult);
                }
                tbHuella.Text = @"C:\conf_gympack\huella\" + nombre_archivo_huella + ".bmp";
                button1.Enabled = true;
            }
            else
            {
                MessageBox.Show("Es necesario que capture todos los datos del usuario");
            }
        }

        private void tbBuscar_TextChanged(object sender, EventArgs e)
        {
            load_dgvClientes(tbBuscar.Text);
        }
    }
}
