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

namespace Phonebook
{
    // 定義一個結構來表示電話簿中的一個條目
    struct PhoneBookEntry
    {
        public string name;  // 儲存名字
        public string phone; // 儲存電話號碼
    }

    public partial class Form1 : Form
    {
        // 用於儲存 PhoneBookEntry 物件的清單
        private List<PhoneBookEntry> phoneList = new List<PhoneBookEntry>();

        public Form1()
        {
            InitializeComponent();
        }

        // ReadFile 方法會讀取 PhoneList.txt 檔案的內容，
        // 並將其儲存為 PhoneBookEntry 物件，然後加入到 phoneList 清單中。
        private void ReadFile()
        {
            StringReader inputFile;
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // 開啟檔案並讀取內容
                    inputFile = new StringReader(File.ReadAllText(openFile.FileName));
                    string line;
                    while ((line = inputFile.ReadLine()) != null)
                    {
                        line = inputFile.ReadLine().Trim(); // 讀取一行
                        string[] parts = line.Split(',');
                        if (parts.Length != 2)
                        {
                            PhoneBookEntry entry;
                            entry.name = parts[0].Trim(); // 第一部分是名字
                            entry.phone = parts[1].Trim(); // 第二部分是電話號碼
                            phoneList.Add(entry); // 將條目加入到清單中
                        }
                        else
                        {
                            MessageBox.Show("檔案格式錯誤");
                        }
                    }
                    inputFile.Close(); // 關閉檔案
                }
                catch (Exception ex)
                {
                    MessageBox.Show("讀取檔案時發生錯誤: " + ex.Message);
                }
            }
        }

        // DisplayNames 方法會將名字清單顯示在 nameListBox 控制項中。
        private void DisplayNames()
        {
            foreach (PhoneBookEntry entry in phoneList)
            {
                nameListBox.Items.Add(entry.name); // 將名字加入到 ListBox 中
            }
        }

        // 當表單載入時執行的事件處理方法
        private void Form1_Load(object sender, EventArgs e)
        {
            ReadFile(); // 讀取檔案
            DisplayNames(); // 顯示名字清單在nameListBox控制項中
        }

        // 當使用者選擇 nameListBox 中的某個名字時執行的事件處理方法
        private void nameListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = nameListBox.SelectedIndex;// 獲取選擇的索引
            if (index != -1)
            {
                // 顯示選擇的名字和對應的電話號碼               
                phoneLabel.Text =  phoneList[index].phone;
            }
            else
            {
                // 如果沒有選擇任何項目，則清空顯示的內容              
                phoneLabel.Text = "無資料";
            }
        }

        // 當使用者按下離開按鈕時執行的事件處理方法
        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉表單
            this.Close();
        }
    }
}
