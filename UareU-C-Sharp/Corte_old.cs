using iTextSharp.text;
using iTextSharp.text.pdf;
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
    public partial class Corte : Form
    {
        public Corte()
        {
            InitializeComponent();
            string archivoConfig = @"C:\conf_gympack\cadenasConexionSQL.txt";
            cadenaConexion = File.ReadAllText(archivoConfig);
            DateTime fechaActual = DateTime.Now;
            dtpFecha.Value = fechaActual;
        }
        static string cadenaConexion;

        private void cargarcorte(string Fecha)
        {
            dgvCorte.Rows.Clear();
            try
            {
                // Crear la conexión
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    // Abrir la conexión
                    conexion.Open();

                    // Crear el comando SQL
                    string consulta = "EXEC sp_CORTE '"+ Fecha + "';";
                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        // Ejecutar la consulta y obtener el lector de datos
                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                DataGridViewRow nuevaFila = new DataGridViewRow();
                                nuevaFila.CreateCells(dgvCorte);
                                nuevaFila.Cells[0].Value = lector["ID_Pago"].ToString();
                                nuevaFila.Cells[1].Value = lector["Nombre"].ToString();
                                nuevaFila.Cells[2].Value = lector["DIARIO"].ToString();
                                nuevaFila.Cells[3].Value = lector["SEMANAL"].ToString();
                                nuevaFila.Cells[4].Value = lector["MENSUAL"].ToString();
                                nuevaFila.Cells[5].Value = lector["SEMESTRAL"].ToString();
                                dgvCorte.Rows.Add(nuevaFila);
                                tbDiario.Text = (Convert.ToDouble(tbDiario.Text)+Convert.ToDouble(lector["DIARIO"].ToString())).ToString();
                                tbSemanal.Text = (Convert.ToDouble(tbSemanal.Text) + Convert.ToDouble(lector["SEMANAL"].ToString())).ToString();
                                tbMensual.Text = (Convert.ToDouble(tbMensual.Text) + Convert.ToDouble(lector["MENSUAL"].ToString())).ToString();
                                tbSemestral.Text = (Convert.ToDouble(tbSemestral.Text) + Convert.ToDouble(lector["SEMESTRAL"].ToString())).ToString();
                            }
                            tbTotal.Text = (Convert.ToDouble(tbDiario.Text) + Convert.ToDouble(tbSemanal.Text)+ Convert.ToDouble(tbMensual.Text)+ Convert.ToDouble(tbSemestral.Text)).ToString();
                            tbTotalGeneral.Text = (Convert.ToDouble(tbTotal.Text) + Convert.ToDouble(tbSaldoInicial.Text)).ToString();
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
            DateTime fecha = dtpFecha.Value;
            string s_fecha = fecha.ToString("yyyy-MM-dd");
            cargarcorte(s_fecha);
        }

        private void tbSaldoInicial_TextChanged(object sender, EventArgs e)
        {
            if (tbSaldoInicial.Text != "")
            {
                string newText = "";
                foreach (char c in tbSaldoInicial.Text)
                {
                    if (char.IsDigit(c))
                    {
                        newText += c;
                    }
                }
                tbSaldoInicial.Text = newText;
            }
        }

        public void GeneratePdfFromDataGridView(DataGridView dataGridView, string filePath)
        {
            Document pdfDoc = new Document();
            float tamañocabecera = 16;

            try
            {
                PdfWriter.GetInstance(pdfDoc, new FileStream(filePath, FileMode.Create));
                pdfDoc.Open();

                DateTime fecha = dtpFecha.Value;
                string s_fecha = fecha.ToString("yyyy-MM-dd");
                // Agregar un título
                pdfDoc.Add(new Paragraph("INGRESOS DEL DIA: "+ s_fecha+"\n")
                {
                    Font = FontFactory.GetFont("Arial", tamañocabecera,BaseColor.BLACK)
                });

                pdfDoc.Add(new Paragraph("               "));
                pdfDoc.Add(new Paragraph("               "));

                // Crear tabla basada en el DataGridView
                PdfPTable pdfTable = new PdfPTable(dataGridView.Columns.Count);

                // Agregar encabezados
                foreach (DataGridViewColumn column in dataGridView.Columns)
                {
                    pdfTable.AddCell(new Phrase(column.HeaderText));
                }

                // Agregar filas
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    if (!row.IsNewRow) // Ignorar la última fila (si es nueva)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            pdfTable.AddCell(new Phrase(cell.Value?.ToString() ?? string.Empty));
                        }
                    }
                }

                pdfDoc.Add(pdfTable);

                pdfDoc.Add(new Paragraph("               "));
                pdfDoc.Add(new Paragraph("               "));
                pdfDoc.Add(new Paragraph("TOTAL DIARIO: "+tbDiario.Text));
                pdfDoc.Add(new Paragraph("TOTAL SEMANAL: "+tbSemanal.Text));
                pdfDoc.Add(new Paragraph("TOTAL MENSUAL: "+tbMensual.Text));
                pdfDoc.Add(new Paragraph("TOTAL SEMESTRAL: "+tbSemestral.Text));
                pdfDoc.Add(new Paragraph("SALDO INICIAL EN CAJA: " + tbSaldoInicial.Text));
                pdfDoc.Add(new Paragraph("               "));
                
                pdfDoc.Add(new Paragraph("SALDO TOTAL: " + tbTotalGeneral.Text)
                {
                    Font = FontFactory.GetFont("Arial",tamañocabecera, BaseColor.BLACK)
                });
            }
            catch (DocumentException de)
            {
                MessageBox.Show(de.Message);
            }
            catch (IOException ioEx)
            {
                MessageBox.Show(ioEx.Message);
            }
            finally
            {
                pdfDoc.Close();
            }
        }

        private string GenerateRandomFileName()
        {
            // Genera un GUID para asegurar la unicidad
            string uniqueId = Guid.NewGuid().ToString();

            // Obtiene la fecha y hora actuales
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            // Crea el nombre de archivo
            string fileName = $"PDF_{timestamp}_{uniqueId}.pdf";

            return fileName;
        }
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            string name = GenerateRandomFileName();
            string filePath = "C:/conf_gympack/pdf_corte/"+name; // Cambia la ruta según sea necesario
            GeneratePdfFromDataGridView(dgvCorte, filePath);
            //MessageBox.Show("PDF generado correctamente en " + filePath);
            System.Diagnostics.Process.Start(filePath);
        }
    }
}
