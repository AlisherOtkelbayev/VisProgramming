using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NumberGuessApp
{
    public partial class Form1 : Form
    {
        private Random _random = new Random();
        private int _targetNumber;
        private int _guessCount;

        public Form1()
        {
            InitializeComponent();
            StartNewGame();
        }

        private void StartNewGame()
        {
            _targetNumber = _random.Next(1, 101);
            _guessCount = 0;

            lblResult.Text = "";
            txtGuess.Clear();
            txtGuess.Focus();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            _guessCount++;
            if (int.TryParse(txtGuess.Text, out int userGuess))
            {
                if (userGuess > _targetNumber)
                {
                    lblResult.Text = "Too high, try again.";
                }
                else if (userGuess < _targetNumber)
                {
                    lblResult.Text = "Too low, try again.";
                }
                else
                {
                    MessageBox.Show(
                        $"Correct! You guessed it in {_guessCount} tries.",
                        "You Win!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    StartNewGame();
                    return;
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid number.",
                                "Invalid Input",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            txtGuess.Clear();
            txtGuess.Focus();
        }
    }
}
