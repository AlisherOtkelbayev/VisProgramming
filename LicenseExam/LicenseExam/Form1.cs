using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LicenseExam
{
    public partial class Form1 : Form
    {
        private readonly char[] CorrectAnswers = {
            'B', 'D', 'A', 'A', 'C',
            'A', 'B', 'B', 'C', 'D',
            'B', 'C', 'D', 'D', 'C',
            'C', 'C', 'B', 'D', 'A'
        };
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                Filter = "Text Files (*.txt)|*.txt",
                Title = "Select the Student Answers File"
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;

                try
                {
                    char[] studentAnswers = File.ReadAllLines(filePath)
                                                 .Select(line => line.Trim().ToUpper()[0])
                                                 .ToArray();
                    if (studentAnswers.Length != 20)
                    {
                        MessageBox.Show("The file must contain exactly 20 answers.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    GradeExam(studentAnswers);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void GradeExam(char[] studentAnswers)
        {
            int correctCount = 0;
            int incorrectCount = 0;
            var incorrectQuestions = new System.Collections.Generic.List<int>();

            for (int i = 0; i < CorrectAnswers.Length; i++)
            {
                if (studentAnswers[i] == CorrectAnswers[i])
                {
                    correctCount++;
                }
                else
                {
                    incorrectCount++;
                    incorrectQuestions.Add(i + 1);
                }
            }
            bool passed = correctCount >= 15;
            lblResult.Text = $"{(passed ? "Pass" : "Fail")}\n" +
                             $"Correct answers: {correctCount}\n" +
                             $"Incorrect answers: {incorrectCount}\n";

            if (incorrectQuestions.Count > 0)
            {
                lblResult.Text += "Questions answered incorrectly: " +
                                  string.Join(", ", incorrectQuestions);
            }
        }
    }
}
