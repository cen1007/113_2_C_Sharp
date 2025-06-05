using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Program7_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // 使用 List<string> 儲存隊伍名稱
        List<string> team = new List<string>();

        // 使用 List<string> 儲存世界大賽冠軍隊伍
        List<string> winner = new List<string>();

        // 使用 List<int> 儲存冠軍年份
        List<int> years = new List<int>();
        private string teamFilePath = "";
        private string winnerFilePath = "";

        // 表單載入事件，初始化資料
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                // 提示選擇球隊名稱檔案
                MessageBox.Show("請先選擇球隊資料檔案", "提示");
                readTeams();

                // 提示選擇冠軍隊伍檔案
                MessageBox.Show("再選擇世界大賽冠軍資料檔案", "提示");
                readWinner();

                // 顯示資料到 ListBox
                DisplayListBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"程式執行時發生錯誤：{ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void readTeams()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "文字檔案 (*.txt)|*.txt",
                Title = "選擇球隊名稱檔案"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                teamFilePath = openFileDialog.FileName;
                team.Clear();
                using (StreamReader inputFile = File.OpenText(openFileDialog.FileName))
                {
                    while (!inputFile.EndOfStream)
                    {
                        string line = inputFile.ReadLine();
                        team.Add(line);
                    }
                }
            }
            else
            {
                throw new Exception("未選擇球隊名稱檔案，程式將結束。");
            }
        }

        private void readWinner()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "文字檔案 (*.txt)|*.txt",
                Title = "選擇冠軍隊伍檔案"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                winnerFilePath = openFileDialog.FileName;
                winner.Clear();
                years.Clear();

                using (StreamReader inputFile = File.OpenText(openFileDialog.FileName))
                {
                    int year = 1903;
                    while (!inputFile.EndOfStream)
                    {
                        string line = inputFile.ReadLine();
                        winner.Add(line);
                        years.Add(year);
                        year++;

                        if (year == 1904 || year == 1994)
                            year++; // 跳過沒有比賽的年份
                    }
                }
            }
            else
            {
                throw new Exception("未選擇冠軍隊伍檔案，程式將結束。");
            }
        }

        // 顯示格式化結果到 ListBox
        private void DisplayListBox()
        {
            listBox1.Items.Clear();
            listBox1.Items.Add("請選擇下列其中一支隊伍：");

            foreach (string t in team)
            {
                listBox1.Items.Add(t);
            }           
        }
        // 顯示選擇隊伍的冠軍年份到 label1  
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > 0 && listBox1.SelectedIndex <= team.Count)
            {
                string selectedTeam = listBox1.SelectedItem.ToString();
                var championshipYears = years.Where((y, i) => i < winner.Count && winner[i] == selectedTeam).ToList();

                if (championshipYears.Count > 0)
                {
                    label1.Text = $"{selectedTeam} 在以下年份獲得 MLB 冠軍：{string.Join("、", championshipYears)}";
                }
                else
                {
                    label1.Text = $"{selectedTeam} 未曾獲得 MLB 冠軍。";
                }
            }
            else
            {
                label1.Text = "請選擇一支隊伍。";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Click += buttonAdd_Click;

        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            // 1. 輸入年份
            string inputYear = Microsoft.VisualBasic.Interaction.InputBox("請輸入冠軍年份（2011以上）：", "新增冠軍年份");
            if (!int.TryParse(inputYear, out int year) || year <= 2010)
            {
                MessageBox.Show("請輸入2011年以後的正確年份！", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 2. 輸入隊伍名稱
            string inputTeam = Microsoft.VisualBasic.Interaction.InputBox("請輸入冠軍隊伍名稱：", "新增冠軍隊伍");
            if (string.IsNullOrWhiteSpace(inputTeam))
            {
                MessageBox.Show("隊伍名稱不可空白！", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 3. 檢查是否已存在該年份
            if (years.Contains(year))
            {
                MessageBox.Show("該年份已存在冠軍資料！", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 4. 新增隊伍到 team（若尚未存在）
            if (!team.Contains(inputTeam))
                team.Add(inputTeam);

            // 5. 新增冠軍資料
            years.Add(year);
            winner.Add(inputTeam);

            // 6. 依年份排序
            var combined = years.Zip(winner, (y, w) => new { Year = y, Winner = w })
                                .OrderBy(x => x.Year)
                                .ToList();
            years = combined.Select(x => x.Year).ToList();
            winner = combined.Select(x => x.Winner).ToList();

            // 7. 重新顯示 ListBox
            DisplayListBox();
        }
    }
}
        
