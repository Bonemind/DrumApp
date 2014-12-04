namespace DrumApp
{
    partial class MainForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnStartMetronome = new System.Windows.Forms.Button();
            this.btnStopMetronome = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnReset);
            this.groupBox1.Controls.Add(this.btnStopMetronome);
            this.groupBox1.Controls.Add(this.btnStartMetronome);
            this.groupBox1.Location = new System.Drawing.Point(35, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(334, 52);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Metronome";
            // 
            // btnStartMetronome
            // 
            this.btnStartMetronome.Location = new System.Drawing.Point(6, 19);
            this.btnStartMetronome.Name = "btnStartMetronome";
            this.btnStartMetronome.Size = new System.Drawing.Size(75, 23);
            this.btnStartMetronome.TabIndex = 0;
            this.btnStartMetronome.Text = "Start";
            this.btnStartMetronome.UseVisualStyleBackColor = true;
            this.btnStartMetronome.Click += new System.EventHandler(this.btnStartMetronome_Click);
            // 
            // btnStopMetronome
            // 
            this.btnStopMetronome.Location = new System.Drawing.Point(228, 19);
            this.btnStopMetronome.Name = "btnStopMetronome";
            this.btnStopMetronome.Size = new System.Drawing.Size(75, 23);
            this.btnStopMetronome.TabIndex = 1;
            this.btnStopMetronome.Text = "Stop";
            this.btnStopMetronome.UseVisualStyleBackColor = true;
            this.btnStopMetronome.Click += new System.EventHandler(this.btnStopMetronome_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(116, 19);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 1;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 440);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnStopMetronome;
        private System.Windows.Forms.Button btnStartMetronome;
        private System.Windows.Forms.Button btnReset;
    }
}