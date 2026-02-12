using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using DPUruNet;
using System.Data.SqlClient;
using System.IO;

namespace UareUWindowsMSSQLCSharp
{
    public partial class Form_Main : Form
    {
        private Reader reader;
        private string xmlHuellaFinal = string.Empty;
        //private string cadenaConexion = @"Data Source=DESKTOP-KUBF2IC\SQLEXPRESS;Initial Catalog=Gimnasio;Integrated Security=True";
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
            //Load all users from database to use in identify function. This data being
            //considerably large we would want to load this once at the statrtup of 
            //application
            // HelperFunctions.LoadAllUsers();
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
            }
            else
            {
                MessageBox.Show("Es necesario que capture todos los datos del usuario");
            }
        }

        private void verifybtn_Click(object sender, EventArgs e)
        {
            //Launch VerifyForm
            //Verify verify = new Verify();
            //verify._sender = this;
            //verify.ShowDialog();
        }

        public void load_dgvClientes()
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
                    string consulta = "select * from Clientes;";
                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
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
                        tbNombre.Text = "";
                        tbHuella.Text = "";
                        tbEdad.Text = "";
                        cbSexo.SelectedIndex = 0;
                        xmlHuellaFinal = string.Empty;
                        load_dgvClientes();
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
                        tbNombre.Text = "";
                        tbHuella.Text = "";
                        tbEdad.Text = "";
                        cbSexo.SelectedIndex = 0;
                        xmlHuellaFinal = string.Empty;
                        load_dgvClientes();
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
                tbHuella.Text = huella;
            }
        }
    }
}
