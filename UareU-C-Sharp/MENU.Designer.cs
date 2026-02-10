
namespace UareUWindowsMSSQLCSharp
{
    partial class MENU
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cLIENTESToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hUELLAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pAGOSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sALIRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cAPTURARToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cORTEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rEPORTEADORToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cLIENTESToolStripMenuItem,
            this.hUELLAToolStripMenuItem,
            this.pAGOSToolStripMenuItem,
            this.rEPORTEADORToolStripMenuItem,
            this.sALIRToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cLIENTESToolStripMenuItem
            // 
            this.cLIENTESToolStripMenuItem.Name = "cLIENTESToolStripMenuItem";
            this.cLIENTESToolStripMenuItem.Size = new System.Drawing.Size(141, 20);
            this.cLIENTESToolStripMenuItem.Text = "REGISTRO DE CLIENTES";
            this.cLIENTESToolStripMenuItem.Click += new System.EventHandler(this.cLIENTESToolStripMenuItem_Click);
            // 
            // hUELLAToolStripMenuItem
            // 
            this.hUELLAToolStripMenuItem.Name = "hUELLAToolStripMenuItem";
            this.hUELLAToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.hUELLAToolStripMenuItem.Text = "HUELLA";
            this.hUELLAToolStripMenuItem.Click += new System.EventHandler(this.hUELLAToolStripMenuItem_Click);
            // 
            // pAGOSToolStripMenuItem
            // 
            this.pAGOSToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cAPTURARToolStripMenuItem,
            this.cORTEToolStripMenuItem});
            this.pAGOSToolStripMenuItem.Name = "pAGOSToolStripMenuItem";
            this.pAGOSToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.pAGOSToolStripMenuItem.Text = "PAGOS";
            this.pAGOSToolStripMenuItem.Click += new System.EventHandler(this.pAGOSToolStripMenuItem_Click);
            // 
            // sALIRToolStripMenuItem
            // 
            this.sALIRToolStripMenuItem.Name = "sALIRToolStripMenuItem";
            this.sALIRToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.sALIRToolStripMenuItem.Text = "SALIR";
            this.sALIRToolStripMenuItem.Click += new System.EventHandler(this.sALIRToolStripMenuItem_Click);
            // 
            // cAPTURARToolStripMenuItem
            // 
            this.cAPTURARToolStripMenuItem.Name = "cAPTURARToolStripMenuItem";
            this.cAPTURARToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cAPTURARToolStripMenuItem.Text = "CAPTURA";
            this.cAPTURARToolStripMenuItem.Click += new System.EventHandler(this.cAPTURARToolStripMenuItem_Click);
            // 
            // cORTEToolStripMenuItem
            // 
            this.cORTEToolStripMenuItem.Name = "cORTEToolStripMenuItem";
            this.cORTEToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cORTEToolStripMenuItem.Text = "CORTE";
            this.cORTEToolStripMenuItem.Click += new System.EventHandler(this.cORTEToolStripMenuItem_Click);
            // 
            // rEPORTEADORToolStripMenuItem
            // 
            this.rEPORTEADORToolStripMenuItem.Name = "rEPORTEADORToolStripMenuItem";
            this.rEPORTEADORToolStripMenuItem.Size = new System.Drawing.Size(98, 20);
            this.rEPORTEADORToolStripMenuItem.Text = "REPORTEADOR";
            this.rEPORTEADORToolStripMenuItem.Click += new System.EventHandler(this.rEPORTEADORToolStripMenuItem_Click);
            // 
            // MENU
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MENU";
            this.Text = "MENU";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MENU_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cLIENTESToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hUELLAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pAGOSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sALIRToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cAPTURARToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cORTEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rEPORTEADORToolStripMenuItem;
    }
}