
namespace UareUWindowsMSSQLCSharp
{
    partial class Pagos
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
            this.btnPago = new System.Windows.Forms.Button();
            this.lblPaquete = new System.Windows.Forms.Label();
            this.dgvClientes = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sexo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.edad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblCabeceraClientes = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbCliente = new System.Windows.Forms.TextBox();
            this.tbIdCliente = new System.Windows.Forms.TextBox();
            this.tbFrecuencia = new System.Windows.Forms.TextBox();
            this.lblFrecuencia = new System.Windows.Forms.Label();
            this.tbPrecio = new System.Windows.Forms.TextBox();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.tbGrupo = new System.Windows.Forms.TextBox();
            this.lblGrupo = new System.Windows.Forms.Label();
            this.dgvPaquetes = new System.Windows.Forms.DataGridView();
            this.idPaquete = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.frecuencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nroPersonas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbIdPaquete = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbMetodoPago = new System.Windows.Forms.ComboBox();
            this.tbDescripcion = new System.Windows.Forms.TextBox();
            this.lblfiltropornombre = new System.Windows.Forms.Label();
            this.tbBuscarCliente = new System.Windows.Forms.TextBox();
            this.tbNroPersonas = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaquetes)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPago
            // 
            this.btnPago.Enabled = false;
            this.btnPago.Location = new System.Drawing.Point(574, 511);
            this.btnPago.Name = "btnPago";
            this.btnPago.Size = new System.Drawing.Size(157, 78);
            this.btnPago.TabIndex = 0;
            this.btnPago.Text = "GUARDAR PAGO";
            this.btnPago.UseVisualStyleBackColor = true;
            this.btnPago.Click += new System.EventHandler(this.btnPago_Click);
            // 
            // lblPaquete
            // 
            this.lblPaquete.AutoSize = true;
            this.lblPaquete.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaquete.Location = new System.Drawing.Point(167, 5);
            this.lblPaquete.Name = "lblPaquete";
            this.lblPaquete.Size = new System.Drawing.Size(121, 24);
            this.lblPaquete.TabIndex = 1;
            this.lblPaquete.Text = "PAQUETES";
            // 
            // dgvClientes
            // 
            this.dgvClientes.AllowUserToAddRows = false;
            this.dgvClientes.AllowUserToDeleteRows = false;
            this.dgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.nombre,
            this.sexo,
            this.edad});
            this.dgvClientes.Location = new System.Drawing.Point(490, 69);
            this.dgvClientes.Name = "dgvClientes";
            this.dgvClientes.ReadOnly = true;
            this.dgvClientes.Size = new System.Drawing.Size(445, 373);
            this.dgvClientes.TabIndex = 3;
            this.dgvClientes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClientes_CellDoubleClick);
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // nombre
            // 
            this.nombre.FillWeight = 200F;
            this.nombre.HeaderText = "NOMBRE";
            this.nombre.MinimumWidth = 20;
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            this.nombre.Width = 200;
            // 
            // sexo
            // 
            this.sexo.HeaderText = "SEXO";
            this.sexo.Name = "sexo";
            this.sexo.ReadOnly = true;
            // 
            // edad
            // 
            this.edad.HeaderText = "EDAD";
            this.edad.Name = "edad";
            this.edad.ReadOnly = true;
            // 
            // lblCabeceraClientes
            // 
            this.lblCabeceraClientes.AutoSize = true;
            this.lblCabeceraClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCabeceraClientes.Location = new System.Drawing.Point(658, 8);
            this.lblCabeceraClientes.Name = "lblCabeceraClientes";
            this.lblCabeceraClientes.Size = new System.Drawing.Size(109, 24);
            this.lblCabeceraClientes.TabIndex = 4;
            this.lblCabeceraClientes.Text = "CLIENTES";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 511);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "CLIENTES";
            // 
            // tbCliente
            // 
            this.tbCliente.Location = new System.Drawing.Point(143, 441);
            this.tbCliente.Multiline = true;
            this.tbCliente.Name = "tbCliente";
            this.tbCliente.ReadOnly = true;
            this.tbCliente.Size = new System.Drawing.Size(267, 156);
            this.tbCliente.TabIndex = 6;
            // 
            // tbIdCliente
            // 
            this.tbIdCliente.Location = new System.Drawing.Point(37, 10);
            this.tbIdCliente.Name = "tbIdCliente";
            this.tbIdCliente.Size = new System.Drawing.Size(59, 20);
            this.tbIdCliente.TabIndex = 8;
            this.tbIdCliente.Visible = false;
            // 
            // tbFrecuencia
            // 
            this.tbFrecuencia.Location = new System.Drawing.Point(154, 319);
            this.tbFrecuencia.Name = "tbFrecuencia";
            this.tbFrecuencia.ReadOnly = true;
            this.tbFrecuencia.Size = new System.Drawing.Size(168, 20);
            this.tbFrecuencia.TabIndex = 10;
            // 
            // lblFrecuencia
            // 
            this.lblFrecuencia.AutoSize = true;
            this.lblFrecuencia.Location = new System.Drawing.Point(92, 319);
            this.lblFrecuencia.Name = "lblFrecuencia";
            this.lblFrecuencia.Size = new System.Drawing.Size(60, 13);
            this.lblFrecuencia.TabIndex = 9;
            this.lblFrecuencia.Text = "Frecuencia";
            // 
            // tbPrecio
            // 
            this.tbPrecio.Location = new System.Drawing.Point(154, 293);
            this.tbPrecio.Name = "tbPrecio";
            this.tbPrecio.ReadOnly = true;
            this.tbPrecio.Size = new System.Drawing.Size(98, 20);
            this.tbPrecio.TabIndex = 12;
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Location = new System.Drawing.Point(92, 293);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(37, 13);
            this.lblPrecio.TabIndex = 11;
            this.lblPrecio.Text = "Precio";
            // 
            // tbGrupo
            // 
            this.tbGrupo.Location = new System.Drawing.Point(154, 345);
            this.tbGrupo.Name = "tbGrupo";
            this.tbGrupo.ReadOnly = true;
            this.tbGrupo.Size = new System.Drawing.Size(168, 20);
            this.tbGrupo.TabIndex = 14;
            // 
            // lblGrupo
            // 
            this.lblGrupo.AutoSize = true;
            this.lblGrupo.Location = new System.Drawing.Point(92, 345);
            this.lblGrupo.Name = "lblGrupo";
            this.lblGrupo.Size = new System.Drawing.Size(36, 13);
            this.lblGrupo.TabIndex = 13;
            this.lblGrupo.Text = "Grupo";
            // 
            // dgvPaquetes
            // 
            this.dgvPaquetes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPaquetes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idPaquete,
            this.grupo,
            this.precio,
            this.frecuencia,
            this.descripcion,
            this.nroPersonas});
            this.dgvPaquetes.Location = new System.Drawing.Point(1, 36);
            this.dgvPaquetes.Name = "dgvPaquetes";
            this.dgvPaquetes.Size = new System.Drawing.Size(452, 233);
            this.dgvPaquetes.TabIndex = 15;
            this.dgvPaquetes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPaquetes_CellDoubleClick);
            // 
            // idPaquete
            // 
            this.idPaquete.HeaderText = "ID PAQUETE";
            this.idPaquete.Name = "idPaquete";
            this.idPaquete.Visible = false;
            // 
            // grupo
            // 
            this.grupo.HeaderText = "GRUPO";
            this.grupo.Name = "grupo";
            this.grupo.ReadOnly = true;
            // 
            // precio
            // 
            this.precio.HeaderText = "PRECIO";
            this.precio.Name = "precio";
            this.precio.ReadOnly = true;
            // 
            // frecuencia
            // 
            this.frecuencia.HeaderText = "FRECUENCIA";
            this.frecuencia.Name = "frecuencia";
            this.frecuencia.ReadOnly = true;
            // 
            // descripcion
            // 
            this.descripcion.HeaderText = "DESCRIPCION";
            this.descripcion.Name = "descripcion";
            this.descripcion.ReadOnly = true;
            // 
            // nroPersonas
            // 
            this.nroPersonas.HeaderText = "NRO PERSONAS";
            this.nroPersonas.Name = "nroPersonas";
            this.nroPersonas.ReadOnly = true;
            // 
            // tbIdPaquete
            // 
            this.tbIdPaquete.Location = new System.Drawing.Point(278, 293);
            this.tbIdPaquete.Name = "tbIdPaquete";
            this.tbIdPaquete.Size = new System.Drawing.Size(59, 20);
            this.tbIdPaquete.TabIndex = 16;
            this.tbIdPaquete.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(481, 474);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "METODO PAGO";
            // 
            // cbMetodoPago
            // 
            this.cbMetodoPago.FormattingEnabled = true;
            this.cbMetodoPago.Items.AddRange(new object[] {
            "EFECTIVO",
            "TARJETA DEBITO",
            "TARJETA CREDITO",
            "TRANSFERENCIA"});
            this.cbMetodoPago.Location = new System.Drawing.Point(574, 470);
            this.cbMetodoPago.Name = "cbMetodoPago";
            this.cbMetodoPago.Size = new System.Drawing.Size(267, 21);
            this.cbMetodoPago.TabIndex = 18;
            // 
            // tbDescripcion
            // 
            this.tbDescripcion.Location = new System.Drawing.Point(333, 9);
            this.tbDescripcion.Name = "tbDescripcion";
            this.tbDescripcion.Size = new System.Drawing.Size(59, 20);
            this.tbDescripcion.TabIndex = 19;
            this.tbDescripcion.Visible = false;
            // 
            // lblfiltropornombre
            // 
            this.lblfiltropornombre.AutoSize = true;
            this.lblfiltropornombre.Location = new System.Drawing.Point(495, 42);
            this.lblfiltropornombre.Name = "lblfiltropornombre";
            this.lblfiltropornombre.Size = new System.Drawing.Size(99, 13);
            this.lblfiltropornombre.TabIndex = 20;
            this.lblfiltropornombre.Text = "Buscar por nombre:";
            // 
            // tbBuscarCliente
            // 
            this.tbBuscarCliente.Location = new System.Drawing.Point(600, 40);
            this.tbBuscarCliente.Name = "tbBuscarCliente";
            this.tbBuscarCliente.Size = new System.Drawing.Size(335, 20);
            this.tbBuscarCliente.TabIndex = 21;
            this.tbBuscarCliente.TextChanged += new System.EventHandler(this.tbBuscarCliente_TextChanged);
            // 
            // tbNroPersonas
            // 
            this.tbNroPersonas.Location = new System.Drawing.Point(154, 371);
            this.tbNroPersonas.Name = "tbNroPersonas";
            this.tbNroPersonas.ReadOnly = true;
            this.tbNroPersonas.Size = new System.Drawing.Size(168, 20);
            this.tbNroPersonas.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(84, 371);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "NroPersonas";
            // 
            // Pagos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 615);
            this.Controls.Add(this.tbNroPersonas);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbBuscarCliente);
            this.Controls.Add(this.lblfiltropornombre);
            this.Controls.Add(this.tbDescripcion);
            this.Controls.Add(this.cbMetodoPago);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbIdPaquete);
            this.Controls.Add(this.dgvPaquetes);
            this.Controls.Add(this.tbGrupo);
            this.Controls.Add(this.lblGrupo);
            this.Controls.Add(this.tbPrecio);
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.tbFrecuencia);
            this.Controls.Add(this.lblFrecuencia);
            this.Controls.Add(this.tbIdCliente);
            this.Controls.Add(this.tbCliente);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblCabeceraClientes);
            this.Controls.Add(this.dgvClientes);
            this.Controls.Add(this.lblPaquete);
            this.Controls.Add(this.btnPago);
            this.Name = "Pagos";
            this.Text = "Pagos";
            this.Load += new System.EventHandler(this.Pagos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaquetes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPago;
        private System.Windows.Forms.Label lblPaquete;
        private System.Windows.Forms.DataGridView dgvClientes;
        private System.Windows.Forms.Label lblCabeceraClientes;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn sexo;
        private System.Windows.Forms.DataGridViewTextBoxColumn edad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbCliente;
        private System.Windows.Forms.TextBox tbIdCliente;
        private System.Windows.Forms.TextBox tbFrecuencia;
        private System.Windows.Forms.Label lblFrecuencia;
        private System.Windows.Forms.TextBox tbPrecio;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.TextBox tbGrupo;
        private System.Windows.Forms.Label lblGrupo;
        private System.Windows.Forms.DataGridView dgvPaquetes;
        private System.Windows.Forms.TextBox tbIdPaquete;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbMetodoPago;
        private System.Windows.Forms.TextBox tbDescripcion;
        private System.Windows.Forms.Label lblfiltropornombre;
        private System.Windows.Forms.TextBox tbBuscarCliente;
        private System.Windows.Forms.TextBox tbNroPersonas;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn idPaquete;
        private System.Windows.Forms.DataGridViewTextBoxColumn grupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn frecuencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn nroPersonas;
    }
}