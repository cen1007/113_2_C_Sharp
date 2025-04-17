using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Test_Average
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // The Average method accepts a List<int> argument
        // and returns the average of the values in the list.
        private double Average(List<int> scores)
        {
            int total = 0;
            foreach (int score in scores)
            {
                total += score;
            }
            return (double)total / scores.Count;
        }

        // The Highest method accepts a List<int> argument
        // and returns the highest value in that list.
        private int Highest(List<int> scores)
        {
            return scores.Max();
        }

        // The Lowest method accepts a List<int> argument
        // and returns the lowest value in that list.
        private int Lowest(List<int> scores)
        {
            return scores.Min();
        }

        private void getScoresButton_Click(object sender, EventArgs e)
        {
            List<int> testScores = new List<int>();
            int highestScore = 0;
            int lowestScore = 0;
            double averageScore = 0.0;
            StreamReader inputFile;
            try
            {
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    inputFile = File.OpenText(openFile.FileName);
                    while (!inputFile.EndOfStream)
                    {
                        testScores.Add(Convert.ToInt32(inputFile.ReadLine()));
                    }
                    inputFile.Close();

                    averageScore = Average(testScores);
                    highestScore = Highest(testScores);
                    lowestScore = Lowest(testScores);

                    averageScoreLabel.Text = averageScore.ToString("n2");
                    highestScoreLabel.Text = highestScore.ToString();
                    lowScoreLabel.Text = lowestScore.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // Close the form.
            this.Close();
        }
    }
}
