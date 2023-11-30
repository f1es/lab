namespace RegisterApp
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(37, 72);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(223, 37);
            this.button1.TabIndex = 0;
            this.button1.Text = "Перевести текст в нижний регистр";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.LowerRegisterButtonClick);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(37, 124);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(223, 37);
            this.button2.TabIndex = 1;
            this.button2.Text = "Перевести текст в верхний регистр";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.UpperRegisterButtonClick);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(37, 178);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(223, 37);
            this.button3.TabIndex = 2;
            this.button3.Text = "Просмотреть бефер обмена";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.CheckClipboardButtonClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(37, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 34);
            this.label1.TabIndex = 3;
            this.label1.Text = "Скопируйте текст в буфер обмена и \r\nвыберите необходимую операцию";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(304, 241);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.MaximumSize = new System.Drawing.Size(320, 280);
            this.MinimumSize = new System.Drawing.Size(320, 280);
            this.Name = "Form1";
            this.Text = "Register Changer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Label label1;
    }
}