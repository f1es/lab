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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // CompressButton
            // 
            this.CompressButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.CompressButton.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CompressButton.Location = new System.Drawing.Point(23, 21);
            this.CompressButton.Name = "CompressButton";
            this.CompressButton.Size = new System.Drawing.Size(184, 77);
            this.CompressButton.TabIndex = 0;
            this.CompressButton.Text = "Compress";
            this.CompressButton.UseVisualStyleBackColor = false;
            this.CompressButton.Click += new System.EventHandler(this.CompressButton_Click);
            // 
            // PathLabel
            // 
            this.PathLabel.AutoSize = true;
            this.PathLabel.BackColor = System.Drawing.Color.Transparent;
            this.PathLabel.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PathLabel.Location = new System.Drawing.Point(84, 204);
            this.PathLabel.Name = "PathLabel";
            this.PathLabel.Size = new System.Drawing.Size(73, 18);
            this.PathLabel.TabIndex = 1;
            this.PathLabel.Text = "Select Path";
            // 
            // SPButton
            // 
            this.SPButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.SPButton.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SPButton.Location = new System.Drawing.Point(23, 113);
            this.SPButton.Name = "SPButton";
            this.SPButton.Size = new System.Drawing.Size(184, 77);
            this.SPButton.TabIndex = 2;
            this.SPButton.Text = "Select Path";
            this.SPButton.UseVisualStyleBackColor = false;
            this.SPButton.Click += new System.EventHandler(this.SPButton_Click);
            // 
            // DecompressButton
            // 
            this.DecompressButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.DecompressButton.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DecompressButton.Location = new System.Drawing.Point(222, 21);
            this.DecompressButton.Name = "DecompressButton";
            this.DecompressButton.Size = new System.Drawing.Size(184, 77);
            this.DecompressButton.TabIndex = 3;
            this.DecompressButton.Text = "Decompress";
            this.DecompressButton.UseVisualStyleBackColor = false;
            this.DecompressButton.Click += new System.EventHandler(this.DecompressButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(21, 204);
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
            this.pictureBox1.Location = new System.Drawing.Point(311, 151);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(101, 109);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // Output
            // 
            this.Output.AutoSize = true;
            this.Output.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Output.Location = new System.Drawing.Point(222, 113);
            this.Output.Name = "Output";
            this.Output.Size = new System.Drawing.Size(128, 20);
            this.Output.TabIndex = 6;
            this.Output.Text = "Huffman archiver";
            // 
            // HuffmanArchiver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 281);
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
    }
}