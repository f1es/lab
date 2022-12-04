namespace HuffmanArchive
{
    partial class HuffmanArchiver
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HuffmanArchiver));
            this.CompressButton = new System.Windows.Forms.Button();
            this.PathLabel = new System.Windows.Forms.Label();
            this.SPButton = new System.Windows.Forms.Button();
            this.DecompressButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Output = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.InfoBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // CompressButton
            // 
            this.CompressButton.BackColor = System.Drawing.SystemColors.Control;
            this.CompressButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CompressButton.BackgroundImage")));
            this.CompressButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CompressButton.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CompressButton.Location = new System.Drawing.Point(18, 8);
            this.CompressButton.Name = "CompressButton";
            this.CompressButton.Size = new System.Drawing.Size(60, 60);
            this.CompressButton.TabIndex = 0;
            this.CompressButton.UseVisualStyleBackColor = false;
            this.CompressButton.Click += new System.EventHandler(this.CompressButton_Click);
            // 
            // PathLabel
            // 
            this.PathLabel.AutoSize = true;
            this.PathLabel.BackColor = System.Drawing.Color.Transparent;
            this.PathLabel.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PathLabel.Location = new System.Drawing.Point(17, 82);
            this.PathLabel.Name = "PathLabel";
            this.PathLabel.Size = new System.Drawing.Size(73, 18);
            this.PathLabel.TabIndex = 1;
            this.PathLabel.Text = "Select Path";
            // 
            // SPButton
            // 
            this.SPButton.BackColor = System.Drawing.SystemColors.Control;
            this.SPButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SPButton.BackgroundImage")));
            this.SPButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SPButton.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SPButton.Location = new System.Drawing.Point(150, 8);
            this.SPButton.Name = "SPButton";
            this.SPButton.Size = new System.Drawing.Size(60, 60);
            this.SPButton.TabIndex = 2;
            this.SPButton.UseVisualStyleBackColor = false;
            this.SPButton.Click += new System.EventHandler(this.SPButton_Click);
            // 
            // DecompressButton
            // 
            this.DecompressButton.BackColor = System.Drawing.SystemColors.Control;
            this.DecompressButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("DecompressButton.BackgroundImage")));
            this.DecompressButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DecompressButton.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DecompressButton.Location = new System.Drawing.Point(84, 8);
            this.DecompressButton.Name = "DecompressButton";
            this.DecompressButton.Size = new System.Drawing.Size(60, 60);
            this.DecompressButton.TabIndex = 3;
            this.DecompressButton.UseVisualStyleBackColor = false;
            this.DecompressButton.Click += new System.EventHandler(this.DecompressButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(144, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "File Path :";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(234, 84);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(178, 176);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // Output
            // 
            this.Output.AutoSize = true;
            this.Output.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Output.Location = new System.Drawing.Point(17, 68);
            this.Output.Name = "Output";
            this.Output.Size = new System.Drawing.Size(107, 17);
            this.Output.TabIndex = 6;
            this.Output.Text = "Huffman archiver";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Franklin Gothic Heavy", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(234, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 81);
            this.label2.TabIndex = 7;
            this.label2.Text = ".HUF";
            // 
            // InfoBox
            // 
            this.InfoBox.Location = new System.Drawing.Point(20, 153);
            this.InfoBox.Multiline = true;
            this.InfoBox.Name = "InfoBox";
            this.InfoBox.Size = new System.Drawing.Size(190, 107);
            this.InfoBox.TabIndex = 8;
            // 
            // HuffmanArchiver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(424, 281);
            this.Controls.Add(this.InfoBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Output);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DecompressButton);
            this.Controls.Add(this.SPButton);
            this.Controls.Add(this.PathLabel);
            this.Controls.Add(this.CompressButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(440, 320);
            this.MinimumSize = new System.Drawing.Size(440, 320);
            this.Name = "HuffmanArchiver";
            this.Text = "HuffmanArchiver";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button CompressButton;
        private Label PathLabel;
        private Button SPButton;
        private Button DecompressButton;
        private Label label1;
        private PictureBox pictureBox1;
        private Label Output;
        private Label label2;
        private TextBox InfoBox;
    }
}