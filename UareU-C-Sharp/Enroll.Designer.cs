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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.enrollPicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
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
            this.enrollPicBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.enrollPicBox.Location = new System.Drawing.Point(29, 61);
            this.enrollPicBox.Name = "enrollPicBox";
            this.enrollPicBox.Size = new System.Drawing.Size(307, 388);
            this.enrollPicBox.TabIndex = 4;
            this.enrollPicBox.TabStop = false;
            // 
            // sacwebmp
            // 
            this.sacwebmp.Location = new System.Drawing.Point(105, 464);
            this.sacwebmp.Name = "sacwebmp";
            this.sacwebmp.Size = new System.Drawing.Size(148, 50);
            this.sacwebmp.TabIndex = 5;
            this.sacwebmp.Text = "GUARDAR HUELLA";
            this.sacwebmp.UseVisualStyleBackColor = true;
            this.sacwebmp.Visible = false;
            this.sacwebmp.Click += new System.EventHandler(this.sacwebmp_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(342, 61);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(307, 388);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(655, 61);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(307, 388);
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(968, 61);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(307, 388);
            this.pictureBox3.TabIndex = 8;
            this.pictureBox3.TabStop = false;
            // 
            // Enroll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1316, 534);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.sacwebmp);
            this.Controls.Add(this.enrollPicBox);
            this.Controls.Add(this.messagelbl);
            this.Name = "Enroll";
            this.Text = "Enroll";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Enroll_FormClosed);
            this.Load += new System.EventHandler(this.Enroll_Load);
            this.Shown += new System.EventHandler(this.Enroll_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.enrollPicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label messagelbl;
        private System.Windows.Forms.PictureBox enrollPicBox;
        private System.Windows.Forms.Button sacwebmp;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}