using System;
using System.Windows.Forms;

namespace MinesweeperGUI
{
    public partial class Form3 : Form
    {
        private int currentScore;

        public string PlayerName { get; private set; }

        // Constructor that accepts the score as a parameter
        public Form3(int score)
        
        {
            InitializeComponent();
            SetupUI();
            currentScore = score;
            PlayerName = string.Empty; // Initialize PlayerName to an empty string
        }

        private void InitializeUI()
        {
            // Add a button to show Form4
            Button showForm4Button = new Button
            {
                Text = "Show Form4",
                Location = new Point(50, 50),
                Width = 100,
                Height = 30
            };
            showForm4Button.Click += ShowForm4Button_Click;
            Controls.Add(showForm4Button);
        }

        private void ShowForm4Button_Click(object sender, EventArgs e)
        {
            ShowForm4();
        }

        private void ShowForm4()
        {
            if (!string.IsNullOrWhiteSpace(PlayerName))
            {
                Form4 form4 = new Form4(PlayerName, currentScore); // Pass the required parameters
                form4.ShowDialog(); // Show Form4 as a dialog
            }
            else
            {
                MessageBox.Show("Please enter a valid name before proceeding.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void SetupUI()
        {
            this.Text = "Winner's Name";
            this.Size = new System.Drawing.Size(300, 150);
            this.StartPosition = FormStartPosition.CenterScreen;

            Label label1 = new Label();
            label1.Text = "Enter your name:";
            label1.Location = new Point(10, 20);
            label1.AutoSize = true;
            this.Controls.Add(label1);

          

            Button btnSubmit = new Button();
            btnSubmit.Text = "Submit";
            btnSubmit.Location = new Point(10, 80);
            btnSubmit.Click += new EventHandler(btnSubmit_Click);
            this.Controls.Add(btnSubmit);
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtName.Text))
            {
                PlayerName = txtName.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();

                string playerName = txtName.Text;
                int playerScore = currentScore;

                Form4 form4 = new Form4(playerName, playerScore);
                form4.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please enter a valid name.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
