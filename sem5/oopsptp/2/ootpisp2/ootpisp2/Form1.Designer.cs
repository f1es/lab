namespace ootpisp2
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
            OutputBox = new TextBox();
            AddButton = new Button();
            InputName = new TextBox();
            Label = new Label();
            AcceptInputButton = new Button();
            InputYear = new TextBox();
            InputCountry = new TextBox();
            InputRating = new TextBox();
            InputType = new TextBox();
            OutputLabel = new Label();
            EditButton = new Button();
            SeeFilmsButton = new Button();
            AcceptIdButton = new Button();
            DeleteButton = new Button();
            SelectFilmButton = new Button();
            CurrentIdLabel = new Label();
            AcceptEditButton = new Button();
            SuspendLayout();
            // 
            // OutputBox
            // 
            OutputBox.Location = new Point(428, 12);
            OutputBox.Multiline = true;
            OutputBox.Name = "OutputBox";
            OutputBox.ReadOnly = true;
            OutputBox.ScrollBars = ScrollBars.Vertical;
            OutputBox.Size = new Size(595, 598);
            OutputBox.TabIndex = 0;
            // 
            // AddButton
            // 
            AddButton.Location = new Point(22, 21);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(129, 51);
            AddButton.TabIndex = 1;
            AddButton.Text = "Добавить фильм";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddButtonClick;
            // 
            // InputName
            // 
            InputName.Location = new Point(192, 21);
            InputName.Name = "InputName";
            InputName.Size = new Size(168, 23);
            InputName.TabIndex = 2;
            // 
            // Label
            // 
            Label.AutoSize = true;
            Label.Location = new Point(363, 23);
            Label.Name = "Label";
            Label.Size = new Size(59, 135);
            Label.TabIndex = 3;
            Label.Text = "Название\r\n\r\nГод\r\n\r\nСтрана\r\n\r\nРейтинг\r\n\r\nЖанр\r\n";
            // 
            // AcceptInputButton
            // 
            AcceptInputButton.Location = new Point(192, 172);
            AcceptInputButton.Name = "AcceptInputButton";
            AcceptInputButton.Size = new Size(168, 23);
            AcceptInputButton.TabIndex = 4;
            AcceptInputButton.Text = "Подтвердить";
            AcceptInputButton.UseVisualStyleBackColor = true;
            AcceptInputButton.Click += AcceptInputButtonClick;
            // 
            // InputYear
            // 
            InputYear.Location = new Point(192, 51);
            InputYear.Name = "InputYear";
            InputYear.Size = new Size(168, 23);
            InputYear.TabIndex = 5;
            // 
            // InputCountry
            // 
            InputCountry.Location = new Point(192, 79);
            InputCountry.Name = "InputCountry";
            InputCountry.Size = new Size(168, 23);
            InputCountry.TabIndex = 6;
            // 
            // InputRating
            // 
            InputRating.Location = new Point(192, 108);
            InputRating.Name = "InputRating";
            InputRating.Size = new Size(168, 23);
            InputRating.TabIndex = 7;
            // 
            // InputType
            // 
            InputType.Location = new Point(192, 137);
            InputType.Name = "InputType";
            InputType.Size = new Size(168, 23);
            InputType.TabIndex = 8;
            // 
            // OutputLabel
            // 
            OutputLabel.AutoSize = true;
            OutputLabel.Location = new Point(192, 218);
            OutputLabel.Name = "OutputLabel";
            OutputLabel.Size = new Size(16, 15);
            OutputLabel.TabIndex = 9;
            OutputLabel.Text = "...";
            // 
            // EditButton
            // 
            EditButton.Location = new Point(22, 93);
            EditButton.Name = "EditButton";
            EditButton.Size = new Size(129, 51);
            EditButton.TabIndex = 1;
            EditButton.Text = "Редактировать фильм";
            EditButton.UseVisualStyleBackColor = true;
            EditButton.Click += EditButtonClick;
            // 
            // SeeFilmsButton
            // 
            SeeFilmsButton.Location = new Point(22, 161);
            SeeFilmsButton.Name = "SeeFilmsButton";
            SeeFilmsButton.Size = new Size(129, 51);
            SeeFilmsButton.TabIndex = 10;
            SeeFilmsButton.Text = "Просмотреть фильмы";
            SeeFilmsButton.UseVisualStyleBackColor = true;
            SeeFilmsButton.Click += SeeFilmsButtonClick;
            // 
            // AcceptIdButton
            // 
            AcceptIdButton.Location = new Point(192, 50);
            AcceptIdButton.Name = "AcceptIdButton";
            AcceptIdButton.Size = new Size(168, 23);
            AcceptIdButton.TabIndex = 4;
            AcceptIdButton.Text = "Подтвердить";
            AcceptIdButton.UseVisualStyleBackColor = true;
            AcceptIdButton.Click += AcceptIdButtonClick;
            // 
            // DeleteButton
            // 
            DeleteButton.Location = new Point(22, 233);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(129, 51);
            DeleteButton.TabIndex = 11;
            DeleteButton.Text = "Удалить фильм";
            DeleteButton.UseVisualStyleBackColor = true;
            DeleteButton.Click += DeleteButtonClick;
            // 
            // SelectFilmButton
            // 
            SelectFilmButton.Location = new Point(22, 306);
            SelectFilmButton.Name = "SelectFilmButton";
            SelectFilmButton.Size = new Size(129, 51);
            SelectFilmButton.TabIndex = 13;
            SelectFilmButton.Text = "Выбрать фильм";
            SelectFilmButton.UseVisualStyleBackColor = true;
            SelectFilmButton.Click += SelectFilmButtonClick;
            // 
            // CurrentIdLabel
            // 
            CurrentIdLabel.AutoSize = true;
            CurrentIdLabel.Location = new Point(192, 251);
            CurrentIdLabel.Name = "CurrentIdLabel";
            CurrentIdLabel.Size = new Size(18, 15);
            CurrentIdLabel.TabIndex = 14;
            CurrentIdLabel.Text = "-1";
            // 
            // AcceptEditButton
            // 
            AcceptEditButton.Location = new Point(192, 172);
            AcceptEditButton.Name = "AcceptEditButton";
            AcceptEditButton.Size = new Size(168, 23);
            AcceptEditButton.TabIndex = 15;
            AcceptEditButton.Text = "Подтвердить изменение";
            AcceptEditButton.UseVisualStyleBackColor = true;
            AcceptEditButton.Click += AcceptEditButtonClick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1039, 622);
            Controls.Add(AcceptEditButton);
            Controls.Add(CurrentIdLabel);
            Controls.Add(SelectFilmButton);
            Controls.Add(DeleteButton);
            Controls.Add(SeeFilmsButton);
            Controls.Add(OutputLabel);
            Controls.Add(InputType);
            Controls.Add(InputRating);
            Controls.Add(InputCountry);
            Controls.Add(InputYear);
            Controls.Add(AcceptIdButton);
            Controls.Add(AcceptInputButton);
            Controls.Add(Label);
            Controls.Add(InputName);
            Controls.Add(EditButton);
            Controls.Add(AddButton);
            Controls.Add(OutputBox);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox OutputBox;
        private Button AddButton;
        private TextBox InputName;
        private Label Label;
        private Button AcceptInputButton;
        private TextBox InputYear;
        private TextBox InputCountry;
        private TextBox InputRating;
        private TextBox InputType;
        private Label OutputLabel;
        private Button EditButton;
        private Button SeeFilmsButton;
        private Button AcceptIdButton;
        private Button DeleteButton;
        private Button SelectFilmButton;
        private Label CurrentIdLabel;
        private Button AcceptEditButton;
    }
}