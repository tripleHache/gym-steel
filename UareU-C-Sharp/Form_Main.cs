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
                enrollForm.ShowDialog();
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
            try
            {
                // Crear la conexión
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    // Abrir la conexión
                    conexion.Open();

                    // Crear el comando SQL

                    string consulta = "INSERT INTO Clientes (Nombre,Sexo,Edad,Huella) VALUES('" + tbNombre.Text + "', '" + cbSexo.SelectedItem + "', " + tbEdad.Text + ", '" + tbHuella.Text + "')";
                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {

                        int filasAfectadas = comando.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            MessageBox.Show("CLIENTE GUARDADO CORRECTAMENTE.");
                            tbNombre.Text = "";
                            tbHuella.Text = "";
                            tbEdad.Text = "";
                            cbSexo.SelectedIndex = 0;
                            load_dgvClientes();
                        }
                        else
                        {
                            MessageBox.Show("ERROR AL GUARDAR CLIENTE.");
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

        private void Form_Main_Load(object sender, EventArgs e)
        {

        }
    }
}
