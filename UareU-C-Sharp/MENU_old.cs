using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DPUruNet;

namespace UareUWindowsMSSQLCSharp
{
    public partial class MENU : Form
    {
        public MENU()
        {
            InitializeComponent();
        }

        private void hUELLAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Launch VerifyForm
            Verify verify = new Verify();
            verify._sender = this;
            verify.Show();
        }

        private void cLIENTESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Main regClientes = new Form_Main();
            regClientes.ShowDialog();
        }

        private void pAGOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void MENU_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void sALIRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cAPTURARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pagos objPagos = new Pagos();
            objPagos.ShowDialog();
        }

        private void cORTEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Corte objCorte = new Corte();
            objCorte.ShowDialog();
        }

        private void rEPORTEADORToolStripMenuItem_Click(object sender, EventArgs e)
        {
            REPORTEADOR objReporteador = new REPORTEADOR();
            objReporteador.ShowDialog();
        }
    }
}
