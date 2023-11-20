namespace pognali
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            trackBar1 = new TrackBar();
            trackBar2 = new TrackBar();
            trackBar3 = new TrackBar();
            labelRed = new Label();
            labelGreen = new Label();
            labelBlue = new Label();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar3).BeginInit();
            SuspendLayout();
            // 
            // trackBar1
            // 
            trackBar1.Location = new Point(12, 12);
            trackBar1.Maximum = 255;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(104, 45);
            trackBar1.TabIndex = 0;
            trackBar1.Value = 1;
            // 
            // trackBar2
            // 
            trackBar2.Location = new Point(12, 63);
            trackBar2.Maximum = 255;
            trackBar2.Name = "trackBar2";
            trackBar2.Size = new Size(104, 45);
            trackBar2.TabIndex = 1;
            // 
            // trackBar3
            // 
            trackBar3.Location = new Point(12, 114);
            trackBar3.Maximum = 255;
            trackBar3.Name = "trackBar3";
            trackBar3.Size = new Size(104, 45);
            trackBar3.TabIndex = 2;
            // 
            // labelRed
            // 
            labelRed.AutoSize = true;
            labelRed.ForeColor = SystemColors.Control;
            labelRed.Location = new Point(134, 21);
            labelRed.Name = "labelRed";
            labelRed.Size = new Size(28, 15);
            labelRed.TabIndex = 3;
            labelRed.Text = "RED";
            // 
            // labelGreen
            // 
            labelGreen.AutoSize = true;
            labelGreen.ForeColor = SystemColors.Control;
            labelGreen.Location = new Point(134, 72);
            labelGreen.Name = "labelGreen";
            labelGreen.Size = new Size(43, 15);
            labelGreen.TabIndex = 4;
            labelGreen.Text = "GREEN";
            // 
            // labelBlue
            // 
            labelBlue.AutoSize = true;
            labelBlue.ForeColor = SystemColors.Control;
            labelBlue.Location = new Point(137, 116);
            labelBlue.Name = "labelBlue";
            labelBlue.Size = new Size(34, 15);
            labelBlue.TabIndex = 5;
            labelBlue.Text = "BLUE";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.AppWorkspace;
            ClientSize = new Size(800, 450);
            Controls.Add(labelBlue);
            Controls.Add(labelGreen);
            Controls.Add(labelRed);
            Controls.Add(trackBar3);
            Controls.Add(trackBar2);
            Controls.Add(trackBar1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TrackBar trackBar1;
        private TrackBar trackBar2;
        private TrackBar trackBar3;
        private Label labelRed;
        private Label labelGreen;
        private Label labelBlue;
    }
}