
namespace UareUWindowsMSSQLCSharp
{
    partial class MEMBRESIAS
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
            this.lblNombre = new System.Windows.Forms.Label();
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.lblFrecuencia = new System.Windows.Forms.Label();
            this.cbFrecuencia = new System.Windows.Forms.ComboBox();
            this.tbPrecio = new System.Windows.Forms.TextBox();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.lblNroPersonas = new System.Windows.Forms.Label();
            this.nudPersonas = new System.Windows.Forms.NumericUpDown();
            this.cbGrupo = new System.Windows.Forms.ComboBox();
            this.lblGrupo = new System.Windows.Forms.Label();
            this.dgvMembresia = new System.Windows.Forms.DataGridView();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudPersonas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembresia)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(51, 45);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(88, 13);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "NOMBRE/DESC";
            // 
            // tbNombre
            // 
            this.tbNombre.Location = new System.Drawing.Point(152, 38);
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.Size = new System.Drawing.Size(435, 20);
            this.tbNombre.TabIndex = 1;
            // 
            // lblFrecuencia
            // 
            this.lblFrecuencia.AutoSize = true;
            this.lblFrecuencia.Location = new System.Drawing.Point(51, 86);
            this.lblFrecuencia.Name = "lblFrecuencia";
            this.lblFrecuencia.Size = new System.Drawing.Size(75, 13);
            this.lblFrecuencia.TabIndex = 2;
            this.lblFrecuencia.Text = "FRECUENCIA";
            // 
            // cbFrecuencia
            // 
            this.cbFrecuencia.FormattingEnabled = true;
            this.cbFrecuencia.Items.AddRange(new object[] {
            "DIARIO",
            "SEMANAL",
            "MENSUAL",
            "BIMESTRAL",
            "TRIMESTRAL",
            "SEMESTRAL",
            "ANUAL"});
            this.cbFrecuencia.Location = new System.Drawing.Point(152, 78);
            this.cbFrecuencia.Name = "cbFrecuencia";
            this.cbFrecuencia.Size = new System.Drawing.Size(153, 21);
            this.cbFrecuencia.TabIndex = 3;
            // 
            // tbPrecio
            // 
            this.tbPrecio.Location = new System.Drawing.Point(152, 124);
            this.tbPrecio.Name = "tbPrecio";
            this.tbPrecio.Size = new System.Drawing.Size(201, 20);
            this.tbPrecio.TabIndex = 7;
            this.tbPrecio.Text = "0.00";
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Location = new System.Drawing.Point(51, 131);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(47, 13);
            this.lblPrecio.TabIndex = 4;
            this.lblPrecio.Text = "PRECIO";
            // 
            // lblNroPersonas
            // 
            this.lblNroPersonas.AutoSize = true;
            this.lblNroPersonas.Location = new System.Drawing.Point(372, 125);
            this.lblNroPersonas.Name = "lblNroPersonas";
            this.lblNroPersonas.Size = new System.Drawing.Size(93, 13);
            this.lblNroPersonas.TabIndex = 6;
            this.lblNroPersonas.Text = "NRO PERSONAS";
            // 
            // nudPersonas
            // 
            this.nudPersonas.Location = new System.Drawing.Point(473, 118);
            this.nudPersonas.Name = "nudPersonas";
            this.nudPersonas.Size = new System.Drawing.Size(114, 20);
            this.nudPersonas.TabIndex = 9;
            this.nudPersonas.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cbGrupo
            // 
            this.cbGrupo.FormattingEnabled = true;
            this.cbGrupo.Items.AddRange(new object[] {
            "GENERAL",
            "MAMA",
            "ESTUDIANTE",
            "DAMAS"});
            this.cbGrupo.Location = new System.Drawing.Point(438, 78);
            this.cbGrupo.Name = "cbGrupo";
            this.cbGrupo.Size = new System.Drawing.Size(149, 21);
            this.cbGrupo.TabIndex = 5;
            // 
            // lblGrupo
            // 
            this.lblGrupo.AutoSize = true;
            this.lblGrupo.Location = new System.Drawing.Point(373, 86);
            this.lblGrupo.Name = "lblGrupo";
            this.lblGrupo.Size = new System.Drawing.Size(46, 13);
            this.lblGrupo.TabIndex = 9;
            this.lblGrupo.Text = "GRUPO";
            // 
            // dgvMembresia
            // 
            this.dgvMembresia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMembresia.Location = new System.Drawing.Point(12, 178);
            this.dgvMembresia.Name = "dgvMembresia";
            this.dgvMembresia.Size = new System.Drawing.Size(622, 382);
            this.dgvMembresia.TabIndex = 11;
            this.dgvMembresia.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMembresia_CellDoubleClick);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(90, 579);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(84, 33);
            this.btnGuardar.TabIndex = 11;
            this.btnGuardar.Text = "GUARDAR";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(351, 579);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(84, 33);
            this.btnEliminar.TabIndex = 15;
            this.btnEliminar.Text = "ELIMINAR";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(220, 579);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(84, 33);
            this.btnActualizar.TabIndex = 13;
            this.btnActualizar.Text = "MODIFICAR";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // MEMBRESIAS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 624);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.dgvMembresia);
            this.Controls.Add(this.cbGrupo);
            this.Controls.Add(this.lblGrupo);
            this.Controls.Add(this.nudPersonas);
            this.Controls.Add(this.lblNroPersonas);
            this.Controls.Add(this.tbPrecio);
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.cbFrecuencia);
            this.Controls.Add(this.lblFrecuencia);
            this.Controls.Add(this.tbNombre);
            this.Controls.Add(this.lblNombre);
            this.Name = "MEMBRESIAS";
            this.Text = "MEMBRESIAS";
            ((System.ComponentModel.ISupportInitialize)(this.nudPersonas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembresia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox tbNombre;
        private System.Windows.Forms.Label lblFrecuencia;
        private System.Windows.Forms.ComboBox cbFrecuencia;
        private System.Windows.Forms.TextBox tbPrecio;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Label lblNroPersonas;
        private System.Windows.Forms.NumericUpDown nudPersonas;
        private System.Windows.Forms.ComboBox cbGrupo;
        private System.Windows.Forms.Label lblGrupo;
        private System.Windows.Forms.DataGridView dgvMembresia;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnActualizar;
    }
}