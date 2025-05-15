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

namespace CSV_Reader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 當使用者點擊「取得分數」按鈕時觸發此事件處理函式。
        /// 此方法會顯示檔案選擇對話方塊，讓使用者選擇要開啟的CSV檔案，
        /// 並嘗試以唯讀方式開啟該檔案。如果過程中發生例外，則顯示錯誤訊息。
        /// </summary>
        private void getScoresButton_Click(object sender, EventArgs e)
        {
            try
            {
                StreamReader inputFile;
                string line; // 儲存讀取的每一行資料
                int count = 0; // 計數器，用於計算行數
                int total = 0; // 總分數，用於計算總和
                double average; // 平均分數

                char[] delimiter = { ',' }; // 定義分隔符號為逗號

                // 顯示檔案選擇對話方塊，讓使用者選擇CSV檔案
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    // 以唯讀方式開啟使用者所選擇的檔案
                    inputFile = File.OpenText(openFile.FileName);

                    while (!inputFile.EndOfStream)
                    {
                        // 讀取檔案中的每一行資料
                        line = inputFile.ReadLine();
                        line = line.Trim(); // 去除行首行尾的空白字元
                        string[]  tokens = line.Split(delimiter); // 以逗號分隔行資料
                        total = 0; // 重置總分數為0
                        for (int i=0; i < tokens.Length; i++)
                        {
                            // 將分隔後的字串轉換為整數，並累加到總分數中
                            total += int.Parse(tokens[i]);
                        }
                        average = (double)total / (tokens.Length); // 計算平均分數
                        averagesListBox.Items.Add("第" + (++count) + "位同學的平均分數為: " + average.ToString("F2")); // 將結果顯示在列表框中
                    }
                }
                else
                {
                    // 如果使用者未選擇檔案，則顯示錯誤訊息並結束方法
                    MessageBox.Show("未選擇檔案");
                  
                }
            }
            catch (Exception ex)
            {
                // 發生例外時，顯示錯誤訊息視窗，內容包含例外訊息
                MessageBox.Show("錯誤：" + ex.Message);
            }
        }

        /// <summary>
        /// 當使用者點擊「離開」按鈕時觸發此事件處理函式。
        /// 此方法會關閉目前的表單，結束應用程式。
        /// </summary>
        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉目前的表單，結束應用程式
            this.Close();
        }
    }
}
