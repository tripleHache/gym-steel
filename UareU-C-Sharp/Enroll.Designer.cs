namespace UareUWindowsMSSQLCSharp
{
    partial class Enroll
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
            this.messagelbl = new System.Windows.Forms.Label();
            this.enrollPicBox = new System.Windows.Forms.PictureBox();
            this.sacwebmp = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.enrollPicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // messagelbl
            // 
            this.messagelbl.AutoSize = true;
            this.messagelbl.Location = new System.Drawing.Point(102, 9);
            this.messagelbl.Name = "messagelbl";
            this.messagelbl.Size = new System.Drawing.Size(182, 13);
            this.messagelbl.TabIndex = 3;
            this.messagelbl.Text = "PORFAVOR ESCANEA TU HUELLA";
            // 
            // enrollPicBox
            // 
            this.enrollPicBox.Location = new System.Drawing.Point(29, 34);
            this.enrollPicBox.Name = "enrollPicBox";
            this.enrollPicBox.Size = new System.Drawing.Size(307, 388);
            this.enrollPicBox.TabIndex = 4;
            this.enrollPicBox.TabStop = false;
            // 
            // sacwebmp
            // 
            this.sacwebmp.Location = new System.Drawing.Point(105, 446);
            this.sacwebmp.Name = "sacwebmp";
            this.sacwebmp.Size = new System.Drawing.Size(148, 50);
            this.sacwebmp.TabIndex = 5;
            this.sacwebmp.Text = "GUARDAR HUELLA";
            this.sacwebmp.UseVisualStyleBackColor = true;
            this.sacwebmp.Click += new System.EventHandler(this.sacwebmp_Click);
            // 
            // Enroll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 534);
            this.Controls.Add(this.sacwebmp);
            this.Controls.Add(this.enrollPicBox);
            this.Controls.Add(this.messagelbl);
            this.Name = "Enroll";
            this.Text = "Enroll";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Enroll_FormClosed);
            this.Load += new System.EventHandler(this.Enroll_Load);
            ((System.ComponentModel.ISupportInitialize)(this.enrollPicBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label messagelbl;
        private System.Windows.Forms.PictureBox enrollPicBox;
        private System.Windows.Forms.Button sacwebmp;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}