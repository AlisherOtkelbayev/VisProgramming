using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeatsApp
{
    public partial class Form1 : Form
    {
        private const decimal PRICE_A = 15m;
        private const decimal PRICE_B = 12m;
        private const decimal PRICE_C = 9m;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                int ticketsA = int.Parse(txtClassA.Text);
                int ticketsB = int.Parse(txtClassB.Text);
                int ticketsC = int.Parse(txtClassC.Text);
                decimal revenueA = ticketsA * PRICE_A;
                decimal revenueB = ticketsB * PRICE_B;
                decimal revenueC = ticketsC * PRICE_C;
                decimal totalRevenue = revenueA + revenueB + revenueC;
                txtRevenueA.Text = revenueA.ToString("C");
                txtRevenueB.Text = revenueB.ToString("C");
                txtRevenueC.Text = revenueC.ToString("C");
                txtTotal.Text = totalRevenue.ToString("C");
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid numeric values for tickets sold.",
                                "Invalid Input",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtClassA.Clear();
            txtClassB.Clear();
            txtClassC.Clear();
            txtRevenueA.Clear();
            txtRevenueB.Clear();
            txtRevenueC.Clear();
            txtTotal.Clear();
            txtClassA.Focus();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}