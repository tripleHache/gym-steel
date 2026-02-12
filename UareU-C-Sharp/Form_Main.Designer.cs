namespace UareUWindowsMSSQLCSharp
{
    partial class Form_Main
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
            this.enrollbtn = new System.Windows.Forms.Button();
            this.verifybtn = new System.Windows.Forms.Button();
            this.readerNotFoundlbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbEdad = new System.Windows.Forms.TextBox();
            this.tbHuella = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dgvClientes = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sexo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.edad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.huella = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbSexo = new System.Windows.Forms.ComboBox();
            this.tbidCliente = new System.Windows.Forms.TextBox();
            this.btnEliminar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // enrollbtn
            // 
            this.enrollbtn.Location = new System.Drawing.Point(701, 139);
            this.enrollbtn.Name = "enrollbtn";
            this.enrollbtn.Size = new System.Drawing.Size(233, 23);
            this.enrollbtn.TabIndex = 4;
            this.enrollbtn.Text = "CAPTURAR HUELLA";
            this.enrollbtn.UseVisualStyleBackColor = true;
            this.enrollbtn.Click += new System.EventHandler(this.enrollbtn_Click);
            // 
            // verifybtn
            // 
            this.verifybtn.Location = new System.Drawing.Point(703, 291);
            this.verifybtn.Name = "verifybtn";
            this.verifybtn.Size = new System.Drawing.Size(75, 23);
            this.verifybtn.TabIndex = 50;
            this.verifybtn.Text = "Verify";
            this.verifybtn.UseVisualStyleBackColor = true;
            this.verifybtn.Visible = false;
            // 
            // readerNotFoundlbl
            // 
            this.readerNotFoundlbl.AutoSize = true;
            this.readerNotFoundlbl.Location = new System.Drawing.Point(554, 164);
            this.readerNotFoundlbl.Name = "readerNotFoundlbl";
            this.readerNotFoundlbl.Size = new System.Drawing.Size(240, 13);
            this.readerNotFoundlbl.TabIndex = 3;
            this.readerNotFoundlbl.Text = "Reader is not connected. Please connect reader.";
            this.readerNotFoundlbl.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(554, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "NOMBRE";
            // 
            // tbNombre
            // 
            this.tbNombre.Location = new System.Drawing.Point(616, 57);
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.Size = new System.Drawing.Size(444, 20);
            this.tbNombre.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(654, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "EDAD";
            // 
            // tbEdad
            // 
            this.tbEdad.Location = new System.Drawing.Point(716, 95);
            this.tbEdad.MaxLength = 99;
            this.tbEdad.Name = "tbEdad";
            this.tbEdad.Size = new System.Drawing.Size(79, 20);
            this.tbEdad.TabIndex = 2;
            // 
            // tbHuella
            // 
            this.tbHuella.Location = new System.Drawing.Point(629, 120);
            this.tbHuella.Name = "tbHuella";
            this.tbHuella.ReadOnly = true;
            this.tbHuella.Size = new System.Drawing.Size(373, 20);
            this.tbHuella.TabIndex = 9;
            this.tbHuella.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(829, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "SEXO";
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(606, 205);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(188, 51);
            this.button1.TabIndex = 5;
            this.button1.Text = "GUARDAR CLIENTE";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvClientes
            // 
            this.dgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.nombre,
            this.sexo,
            this.edad,
            this.huella});
            this.dgvClientes.Location = new System.Drawing.Point(4, 6);
            this.dgvClientes.Name = "dgvClientes";
            this.dgvClientes.Size = new System.Drawing.Size(547, 344);
            this.dgvClientes.TabIndex = 100;
            this.dgvClientes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClientes_CellDoubleClick);
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // nombre
            // 
            this.nombre.HeaderText = "NOMBRE";
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
            // huella
            // 
            this.huella.HeaderText = "HUELLA";
            this.huella.Name = "huella";
            this.huella.ReadOnly = true;
            this.huella.Visible = false;
            // 
            // cbSexo
            // 
            this.cbSexo.FormattingEnabled = true;
            this.cbSexo.Items.AddRange(new object[] {
            "M",
            "F"});
            this.cbSexo.Location = new System.Drawing.Point(882, 94);
            this.cbSexo.Name = "cbSexo";
            this.cbSexo.Size = new System.Drawing.Size(121, 21);
            this.cbSexo.TabIndex = 3;
            // 
            // tbidCliente
            // 
            this.tbidCliente.Location = new System.Drawing.Point(616, 21);
            this.tbidCliente.MaxLength = 99;
            this.tbidCliente.Name = "tbidCliente";
            this.tbidCliente.Size = new System.Drawing.Size(79, 20);
            this.tbidCliente.TabIndex = 101;
            this.tbidCliente.Visible = false;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Enabled = false;
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.Red;
            this.btnEliminar.Location = new System.Drawing.Point(847, 205);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(188, 51);
            this.btnEliminar.TabIndex = 102;
            this.btnEliminar.Text = "ELIMINAR CLIENTE";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 362);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.tbidCliente);
            this.Controls.Add(this.cbSexo);
            this.Controls.Add(this.dgvClientes);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbHuella);
            this.Controls.Add(this.tbEdad);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbNombre);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.readerNotFoundlbl);
            this.Controls.Add(this.verifybtn);
            this.Controls.Add(this.enrollbtn);
            this.Name = "Form_Main";
            this.Text = "Main";
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button enrollbtn;
        private System.Windows.Forms.Button verifybtn;
        private System.Windows.Forms.Label readerNotFoundlbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbEdad;
        private System.Windows.Forms.TextBox tbHuella;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgvClientes;
        private System.Windows.Forms.ComboBox cbSexo;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn sexo;
        private System.Windows.Forms.DataGridViewTextBoxColumn edad;
        private System.Windows.Forms.DataGridViewTextBoxColumn huella;
        private System.Windows.Forms.TextBox tbidCliente;
        private System.Windows.Forms.Button btnEliminar;
    }
}

