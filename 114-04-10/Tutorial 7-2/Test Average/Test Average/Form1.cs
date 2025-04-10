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

        // The Average method accepts an int array argument
        // and returns the Average of the values in the array.
        private   Average(   )
        {
            int total = 0;
            foreach (int score in)
        }

        // The Highest method accepts an int array argument
        // and returns the highest value in that array.
        private   Highest(    )
        {
           
        }

        // The Lowest method accepts an int array argument
        // and returns the lowest value in that array.
        private  Lowest(   )
        {
           
        }

        private void getScoresButton_Click(object sender, EventArgs e)
        {
            const int SIZE = 48;
            int[] testScores = new int[SIZE];
            int index = 0;
            int highestScore = 0;
            int lowestScore = 0;
            double averageScore = 0.0;
            StreamReader inputFile;
            try
            {
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    inputFile = File.OpenText(openFile.FileName);
                    while (!inputFile.EndOfStream && index <SIZE)
                    {
                        testScores[index] = Convert.ToInt32(inputFile.ReadLine());
                        index++;
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
