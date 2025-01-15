using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMIApp
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
                double weight = double.Parse(txtWeight.Text);
                double height = double.Parse(txtHeight.Text) / 100;
                double bmi = weight / (height * height);

                string status;
                if (bmi < 18.5)
                {
                    status = "underweight";
                }
                else if (bmi <= 25)
                {
                    status = "optimal weight";
                }
                else
                {
                    status = "overweight";
                }
                lblBMI.Text = $"BMI: {bmi:F2}";
                lblStatus.Text = $"Status: {status}";
            }
            catch (FormatException)
            {
                MessageBox.Show(
                    "Please enter valid numeric values for weight and height.",
                    "Invalid Input",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}