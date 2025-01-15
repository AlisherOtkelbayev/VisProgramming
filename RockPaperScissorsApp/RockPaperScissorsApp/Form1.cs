using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RockPaperScissorsApp
{
    public partial class Form1 : Form
    {
        private Random _random = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnRock_Click(object sender, EventArgs e)
        {
            PlayGame("Rock");
        }

        private void btnPaper_Click(object sender, EventArgs e)
        {
            PlayGame("Paper");
        }

        private void btnScissors_Click(object sender, EventArgs e)
        {
            PlayGame("Scissors");
        }
        private void PlayGame(string playerChoice)
        {
            string computerChoice = GetComputerChoice();
            string result = DetermineWinner(playerChoice, computerChoice);
            lblPlayerChoice.Text = $"Player: {playerChoice}";
            ShowComputerChoiceImage(computerChoice);
            lblResult.Text = result;
        }

        private string GetComputerChoice()
        {
            int choice = _random.Next(1, 4); 
            switch (choice)
            {
                case 1:
                    return "Rock";
                case 2:
                    return "Paper";
                case 3:
                    return "Scissors";
                default:
                    throw new InvalidOperationException("Invalid random number generated.");
            }

        }

        private string DetermineWinner(string playerChoice, string computerChoice)
        {
            if (playerChoice == computerChoice)
            {
                return "It's a tie! Play again.";
            }
            else if ((playerChoice == "Rock" && computerChoice == "Scissors") ||
                     (playerChoice == "Scissors" && computerChoice == "Paper") ||
                     (playerChoice == "Paper" && computerChoice == "Rock"))
            {
                return "You win!";
            }
            else
            {
                return "Computer wins!";
            }
        }

        private void ShowComputerChoiceImage(string computerChoice)
        {
            switch (computerChoice)
            {
                case "Rock":
                    picComputerChoice.Image = Properties.Resources.rockimage;
                    break;
                case "Paper":
                    picComputerChoice.Image = Properties.Resources.paperimage;
                    break;
                case "Scissors":
                    picComputerChoice.Image = Properties.Resources.scissorsimage;
                    break;
                default:
                    picComputerChoice.Image = null;
                    break;
            }
        }
    }
}