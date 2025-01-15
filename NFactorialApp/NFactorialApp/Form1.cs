using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NFactorialApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                int number = int.Parse(txtNumber.Text);
                if (number < 0)
                {
                    MessageBox.Show("Please enter a nonnegative integer (0 or greater).");
                    return;
                }
                long factorial = 1;
                for (int i = 1; i <= number; i++)
                {
                    factorial *= i;
                }
                lblResult.Text = $"{number}! = {factorial}";
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid integer.", "Invalid Input",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}