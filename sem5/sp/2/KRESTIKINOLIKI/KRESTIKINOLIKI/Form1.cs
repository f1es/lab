using System.Windows.Forms.Design;

namespace KRESTIKINOLIKI
{
    public partial class Form1 : Form
    {
        char[] arr = new char[9];
        char turn = 'O';

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button6;
        private Button button5;
        private Button button4;
        private Button button9;
        private Button button8;
        private Button button7;
        private Label labelTurn;
        private Label labelWinner;


        public Form1()
        {
            Initialize();
            labelTurn.Text = "O";
        }

        public void NextTurn()
        {
            if (labelWinner.Text != "")
                labelWinner.Text = "";

            if (turn == 'O')
            {
                turn = 'X';
                labelTurn.Text = "X";
            }
            else
            {
                turn = 'O';
                labelTurn.Text = "O";
            }
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button.Text == "")
            {
                button.Text = turn.ToString();
                int buttonId = button.Name[button.Name.Length - 1] - 49;
                arr[buttonId] = turn;
                NextTurn();
            }
            CheckVictory();
        }

        public void CheckVictory()
        {
            if (arr[0] == 'X' && arr[1] == 'X' && arr[2] == 'X' || // x x x
                arr[3] == 'X' && arr[4] == 'X' && arr[5] == 'X' || // - - -
                arr[6] == 'X' && arr[7] == 'X' && arr[8] == 'X' || // - - -

                arr[0] == 'X' && arr[3] == 'X' && arr[6] == 'X' || // x - -
                arr[1] == 'X' && arr[4] == 'X' && arr[7] == 'X' || // x - -
                arr[2] == 'X' && arr[5] == 'X' && arr[8] == 'X' || // x - - 

                arr[0] == 'X' && arr[4] == 'X' && arr[8] == 'X' || // x - -
                arr[2] == 'X' && arr[4] == 'X' && arr[6] == 'X'    // - x -
                )                                                  // - - x
            {
                labelWinner.Text = "X Win";
                Reset();
            }


            if (arr[0] == 'O' && arr[1] == 'O' && arr[2] == 'O' || // o o o
                arr[3] == 'O' && arr[4] == 'O' && arr[5] == 'O' || // - - -
                arr[6] == 'O' && arr[7] == 'O' && arr[8] == 'O' || // - - -

                arr[0] == 'O' && arr[3] == 'O' && arr[6] == 'O' || // o - -
                arr[1] == 'O' && arr[4] == 'O' && arr[7] == 'O' || // o - -
                arr[2] == 'O' && arr[5] == 'O' && arr[8] == 'O' || // o - - 

                arr[0] == 'O' && arr[4] == 'O' && arr[8] == 'O' || // o - -
                arr[2] == 'O' && arr[4] == 'O' && arr[6] == 'O'    // - o -
                )                                                  // - - o
            {
                labelWinner.Text = "O Win";
                Reset();
            }

            if (CheckDraw())
            {
                labelWinner.Text = "Draw";
                Reset();
            }
        }

        public bool CheckDraw()
        {
            foreach (char c in arr)
            {
                if (c == '-')
                    return false;
            }
            return true;
        }

        public void Reset()
        {
            ResetArray();
            
            button1.Text = "";
            button2.Text = "";
            button3.Text = "";
            button4.Text = "";
            button5.Text = "";
            button6.Text = "";
            button7.Text = "";
            button8.Text = "";
            button9.Text = "";
        }

        public void ResetArray()
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = '-';
            }
        }

        private void Initialize()
        {
            button1 = new Button()
            {
                Location = new Point(15 + (75 * 0), 15 + (75 * 0)),
                Name = "button1",
                Size = new Size(75, 75),
            }; 
            button2 = new Button()
            {
                Location = new Point(15 + (75 * 1), 15 + (75 * 0)),
                Name = "button2",
                Size = new Size(75, 75),
            };
            button3 = new Button()
            {
                Location = new Point(15 + (75 * 2), 15 + (75 * 0)),
                Name = "button3",
                Size = new Size(75, 75),
            };
            button4 = new Button()
            {
                Location = new Point(15 + (75 * 0), 15 + (75 * 1)),
                Name = "button4",
                Size = new Size(75, 75),
            };
            button5 = new Button()
            {
                Location = new Point(15 + (75 * 1), 15 + (75 * 1)),
                Name = "button5",
                Size = new Size(75, 75),
            };
            button6 = new Button()
            {
                Location = new Point(15 + (75 * 2), 15 + (75 * 1)),
                Name = "button6",
                Size = new Size(75, 75)
            };
            button7 = new Button()
            {
                Location = new Point(15 + (75 * 0), 15 + (75 * 2)),
                Name = "button7",
                Size = new Size(75, 75)
            };
            button8 = new Button()
            {
                Location = new Point(15 + (75 * 1), 15 + (75 * 2)),
                Name = "button8",
                Size = new Size(75, 75)
            };
            button9 = new Button() 
            {
                Location = new Point(15 + (75 * 2), 15 + (75 * 2)),
                Name = "button9",
                Size = new Size(75, 75)
            };
            labelTurn = new Label()
            {
                Location = new Point(15, 250),
                Name = "labelTurn",
                Size = new Size(30, 30)
            };
            labelWinner = new Label()
            {
                AutoSize = true,
                //Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point),
                Location = new Point(15, 270),
                Name = "labelWinner",
                Size = new Size(30, 30)
            };

            button1.Click += ButtonClick;
            button2.Click += ButtonClick;
            button3.Click += ButtonClick;
            button4.Click += ButtonClick;
            button5.Click += ButtonClick;
            button6.Click += ButtonClick;
            button7.Click += ButtonClick;
            button8.Click += ButtonClick;
            button9.Click += ButtonClick;

            Controls.Add(labelWinner);
            Controls.Add(labelTurn);
            Controls.Add(button9);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Text = "CROSS&ZERO";

            MaximumSize = new Size(270, 340);
            MinimumSize = new Size(270, 340);
            ResetArray();
        }

    }
}