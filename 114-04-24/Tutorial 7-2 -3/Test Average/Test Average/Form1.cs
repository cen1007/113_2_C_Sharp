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
        // Class-level variable to store test scores  
        private List<int> testScores = new List<int>();

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
            testScores.Clear(); // Clear the list before loading new scores  
            StreamReader inputFile;
            try
            {
                OpenFileDialog openFile = new OpenFileDialog(); // Declare OpenFileDialog  
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    inputFile = File.OpenText(openFile.FileName);
                    while (!inputFile.EndOfStream)
                    {
                        testScores.Add(Convert.ToInt32(inputFile.ReadLine()));
                    }
                    inputFile.Close();

                    double averageScore = Average(testScores);
                    int highestScore = Highest(testScores);
                    int lowestScore = Lowest(testScores);

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

        // Event handler for the "排序" button  
        private void sortButton_Click(object sender, EventArgs e)
        {
            sortedScoresListBox.Items.Clear(); // Clear the ListBox before adding new items  
            var sortedScores = testScores.OrderBy(score => score).ToList(); // Sort the scores  
            foreach (int score in sortedScores)
            {
                sortedScoresListBox.Items.Add(score);
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
