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
    public partial class MEMBRESIAS : Form
    {
        private string cadenaConexion;
        int idSeleccionado = 0;
        public MEMBRESIAS()
        {
            InitializeComponent();
            string archivoConfig = @"C:\conf_gympack\cadenasConexionSQL.txt";
            cadenaConexion = File.ReadAllText(archivoConfig);
            CargarDatos();
        }
        private void CargarDatos()
        {
            using (SqlConnection con = new SqlConnection(cadenaConexion))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Paquetes", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvMembresia.DataSource = dt;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(cadenaConexion))
            {
                string query = "INSERT INTO Paquetes (Descripcion, Frecuencia, Precio, Grupo, NroPersonas) VALUES (@desc, @frec, @prec, @grup, @NroPersonas)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@desc", tbNombre.Text);
                cmd.Parameters.AddWithValue("@frec", cbFrecuencia.Text);
                cmd.Parameters.AddWithValue("@prec", Convert.ToDecimal(tbPrecio.Text));
                cmd.Parameters.AddWithValue("@grup", cbGrupo.Text);
                cmd.Parameters.AddWithValue("@NroPersonas", (int)nudPersonas.Value);

                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Paquete guardado con éxito.");
                CargarDatos();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado > 0)
            {
                using (SqlConnection con = new SqlConnection(cadenaConexion))
                {
                    string query = "DELETE FROM Paquetes WHERE idPaquete = @id";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", idSeleccionado);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    CargarDatos();
                    LimpiarCampos();
                }
            }
        }
        private void LimpiarCampos() {
            tbNombre.Clear();
            tbPrecio.Text = "0.00";
            if (cbGrupo.Items.Count > 0)
            {
                cbGrupo.SelectedIndex = -1; // Sin selección
            }
            if (cbFrecuencia.Items.Count > 0)
            {
                cbFrecuencia.SelectedIndex = -1; // Sin selección
            }
            idSeleccionado = 0;
            tbNombre.Focus();
            nudPersonas.Value = 1;
            foreach (DataGridViewRow row in dgvMembresia.Rows)
            {
                row.DefaultCellStyle.BackColor = Color.White;
            }
        }

        private void dgvMembresia_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificamos que el click sea en un renglón válido y no en el encabezado
            if (e.RowIndex >= 0)
            {
                // 1. Efecto Visual: Pintar de amarillo
                // Primero regresamos todas las filas a su color original (Blanco/Default)
                foreach (DataGridViewRow row in dgvMembresia.Rows)
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                }

                // Pintamos la fila seleccionada
                dgvMembresia.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Yellow;

                // 2. Mapeo de datos a los campos
                DataGridViewRow fila = dgvMembresia.Rows[e.RowIndex];

                // Guardamos el ID para futuras acciones (Update/Delete)
                idSeleccionado = Convert.ToInt32(fila.Cells["idPaquete"].Value);

                // Pasamos los valores a los controles
                tbNombre.Text = fila.Cells["Descripcion"].Value.ToString();
                cbFrecuencia.Text = fila.Cells["Frecuencia"].Value.ToString();
                tbPrecio.Text = fila.Cells["Precio"].Value.ToString();
                cbGrupo.Text = fila.Cells["Grupo"].Value.ToString();
                nudPersonas.Value = Convert.ToDecimal(fila.Cells["NroPersonas"].Value);
                // Opcional: Cambiar el foco al primer campo para editar rápido
                tbNombre.Focus();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            // Verificamos que realmente haya un registro seleccionado
            if (idSeleccionado == 0)
            {
                MessageBox.Show("Por favor, seleccione un paquete de la lista haciendo doble clic.");
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(cadenaConexion))
                {
                    // Query con UPDATE incluyendo el nuevo campo NroPersonas
                    string query = @"UPDATE Paquetes 
                            SET Descripcion = @desc, 
                                Frecuencia = @frec, 
                                Precio = @prec, 
                                Grupo = @grup, 
                                NroPersonas = @nro 
                            WHERE idPaquete = @id";

                    SqlCommand cmd = new SqlCommand(query, con);

                    // Parámetros
                    cmd.Parameters.AddWithValue("@desc", tbNombre.Text);
                    cmd.Parameters.AddWithValue("@frec", cbFrecuencia.Text);
                    cmd.Parameters.AddWithValue("@prec", Convert.ToDecimal(tbPrecio.Text));
                    cmd.Parameters.AddWithValue("@grup", cbGrupo.Text);
                    cmd.Parameters.AddWithValue("@nro", (int)nudPersonas.Value);
                    cmd.Parameters.AddWithValue("@id", idSeleccionado);

                    con.Open();
                    int filasAfectadas = cmd.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show("Registro actualizado correctamente.");
                        CargarDatos();    // Refresca el Grid
                        LimpiarCampos();  // Limpia y quita el color amarillo
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar: " + ex.Message);
            }
        }
    }
}
