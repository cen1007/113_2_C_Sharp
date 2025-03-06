using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Program5_14
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StreamReader inputFile;
            int sum = 0;
            int count = 0;
            int temp;

            try
            { 
                inputFile = File.OpenText("NUMBERS.txt");
                while (!inputFile.EndOfStream)
                {
                    count++; //資料比數+1
                    temp = int.Parse(inputFile.ReadLine());//將讀到的資料轉換為整數
                    sum += temp;//將讀到的資料加到sum變數中
                    listBox1.Items.Add(temp);
                }
                listBox1.Items.Add("總共有" + count + "個數字" + sum);
                listBox1.Items.Add("總和為" + sum);
                inputFile.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
        }
    }
}
