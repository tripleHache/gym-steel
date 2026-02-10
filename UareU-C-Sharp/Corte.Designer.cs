
namespace UareUWindowsMSSQLCSharp
{
    partial class Corte
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.dgvCorte = new System.Windows.Forms.DataGridView();
            this.lblsaldoInicial = new System.Windows.Forms.Label();
            this.tbSaldoInicial = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tbDiario = new System.Windows.Forms.TextBox();
            this.lblIngresoEfectivo = new System.Windows.Forms.Label();
            this.tbSemanal = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbSemestral = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbMensual = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbTotalGeneral = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbTotal = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.idpago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.semana = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mensual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.semestral = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_pago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCorte)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "FECHA";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(109, 32);
            this.dtpFecha.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.dtpFecha.MinDate = new System.DateTime(2024, 1, 1, 0, 0, 0, 0);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(200, 20);
            this.dtpFecha.TabIndex = 1;
            // 
            // dgvCorte
            // 
            this.dgvCorte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCorte.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idpago,
            this.cliente,
            this.diario,
            this.semana,
            this.mensual,
            this.semestral,
            this.fecha_pago});
            this.dgvCorte.Location = new System.Drawing.Point(25, 90);
            this.dgvCorte.Name = "dgvCorte";
            this.dgvCorte.Size = new System.Drawing.Size(957, 506);
            this.dgvCorte.TabIndex = 2;
            // 
            // lblsaldoInicial
            // 
            this.lblsaldoInicial.AutoSize = true;
            this.lblsaldoInicial.Location = new System.Drawing.Point(338, 36);
            this.lblsaldoInicial.Name = "lblsaldoInicial";
            this.lblsaldoInicial.Size = new System.Drawing.Size(83, 13);
            this.lblsaldoInicial.TabIndex = 4;
            this.lblsaldoInicial.Text = "SALDO INICIAL";
            // 
            // tbSaldoInicial
            // 
            this.tbSaldoInicial.Location = new System.Drawing.Point(437, 32);
            this.tbSaldoInicial.Name = "tbSaldoInicial";
            this.tbSaldoInicial.Size = new System.Drawing.Size(100, 20);
            this.tbSaldoInicial.TabIndex = 5;
            this.tbSaldoInicial.Text = "0";
            this.tbSaldoInicial.TextChanged += new System.EventHandler(this.tbSaldoInicial_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(723, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(195, 59);
            this.button1.TabIndex = 7;
            this.button1.Text = "Cargar Corte";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbDiario
            // 
            this.tbDiario.Enabled = false;
            this.tbDiario.Location = new System.Drawing.Point(197, 624);
            this.tbDiario.Name = "tbDiario";
            this.tbDiario.Size = new System.Drawing.Size(100, 20);
            this.tbDiario.TabIndex = 9;
            this.tbDiario.Text = "0";
            // 
            // lblIngresoEfectivo
            // 
            this.lblIngresoEfectivo.AutoSize = true;
            this.lblIngresoEfectivo.Location = new System.Drawing.Point(61, 624);
            this.lblIngresoEfectivo.Name = "lblIngresoEfectivo";
            this.lblIngresoEfectivo.Size = new System.Drawing.Size(82, 13);
            this.lblIngresoEfectivo.TabIndex = 8;
            this.lblIngresoEfectivo.Text = "TOTAL DIARIO";
            // 
            // tbSemanal
            // 
            this.tbSemanal.Enabled = false;
            this.tbSemanal.Location = new System.Drawing.Point(197, 655);
            this.tbSemanal.Name = "tbSemanal";
            this.tbSemanal.Size = new System.Drawing.Size(100, 20);
            this.tbSemanal.TabIndex = 11;
            this.tbSemanal.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 655);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "TOTAL SEMANAL";
            // 
            // tbSemestral
            // 
            this.tbSemestral.Enabled = false;
            this.tbSemestral.Location = new System.Drawing.Point(197, 719);
            this.tbSemestral.Name = "tbSemestral";
            this.tbSemestral.Size = new System.Drawing.Size(100, 20);
            this.tbSemestral.TabIndex = 15;
            this.tbSemestral.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(61, 719);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "TOTAL SEMESTRAL";
            // 
            // tbMensual
            // 
            this.tbMensual.Enabled = false;
            this.tbMensual.Location = new System.Drawing.Point(197, 688);
            this.tbMensual.Name = "tbMensual";
            this.tbMensual.Size = new System.Drawing.Size(100, 20);
            this.tbMensual.TabIndex = 13;
            this.tbMensual.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(61, 688);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "TOTAL MENSUAL";
            // 
            // tbTotalGeneral
            // 
            this.tbTotalGeneral.Enabled = false;
            this.tbTotalGeneral.Location = new System.Drawing.Point(582, 681);
            this.tbTotalGeneral.Name = "tbTotalGeneral";
            this.tbTotalGeneral.Size = new System.Drawing.Size(100, 20);
            this.tbTotalGeneral.TabIndex = 17;
            this.tbTotalGeneral.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(422, 681);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 20);
            this.label2.TabIndex = 16;
            this.label2.Text = "TOTAL GENERAL";
            // 
            // tbTotal
            // 
            this.tbTotal.Enabled = false;
            this.tbTotal.Location = new System.Drawing.Point(195, 747);
            this.tbTotal.Name = "tbTotal";
            this.tbTotal.Size = new System.Drawing.Size(100, 20);
            this.tbTotal.TabIndex = 19;
            this.tbTotal.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(61, 747);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 20);
            this.label6.TabIndex = 18;
            this.label6.Text = "TOTAL";
            // 
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(787, 666);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(182, 73);
            this.btnImprimir.TabIndex = 20;
            this.btnImprimir.Text = "IMPRIMIR";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // idpago
            // 
            this.idpago.HeaderText = "ID PAGO";
            this.idpago.Name = "idpago";
            this.idpago.ReadOnly = true;
            // 
            // cliente
            // 
            this.cliente.HeaderText = "CLIENTE";
            this.cliente.Name = "cliente";
            this.cliente.ReadOnly = true;
            this.cliente.Width = 300;
            // 
            // diario
            // 
            this.diario.HeaderText = "DIARIO";
            this.diario.Name = "diario";
            this.diario.ReadOnly = true;
            // 
            // semana
            // 
            this.semana.HeaderText = "SEMANA";
            this.semana.Name = "semana";
            this.semana.ReadOnly = true;
            // 
            // mensual
            // 
            this.mensual.HeaderText = "MENSUAL";
            this.mensual.Name = "mensual";
            this.mensual.ReadOnly = true;
            // 
            // semestral
            // 
            this.semestral.HeaderText = "SEMESTRAL";
            this.semestral.Name = "semestral";
            this.semestral.ReadOnly = true;
            // 
            // fecha_pago
            // 
            this.fecha_pago.HeaderText = "FECHA PAGO";
            this.fecha_pago.Name = "fecha_pago";
            this.fecha_pago.ReadOnly = true;
            // 
            // Corte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 786);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.tbTotal);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbTotalGeneral);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbSemestral);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbMensual);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbSemanal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbDiario);
            this.Controls.Add(this.lblIngresoEfectivo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbSaldoInicial);
            this.Controls.Add(this.lblsaldoInicial);
            this.Controls.Add(this.dgvCorte);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.label1);
            this.Name = "Corte";
            this.Text = "Corte";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCorte)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.DataGridView dgvCorte;
        private System.Windows.Forms.Label lblsaldoInicial;
        private System.Windows.Forms.TextBox tbSaldoInicial;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbDiario;
        private System.Windows.Forms.Label lblIngresoEfectivo;
        private System.Windows.Forms.TextBox tbSemanal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbSemestral;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbMensual;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbTotalGeneral;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbTotal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.DataGridViewTextBoxColumn idpago;
        private System.Windows.Forms.DataGridViewTextBoxColumn cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn diario;
        private System.Windows.Forms.DataGridViewTextBoxColumn semana;
        private System.Windows.Forms.DataGridViewTextBoxColumn mensual;
        private System.Windows.Forms.DataGridViewTextBoxColumn semestral;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_pago;
    }
}