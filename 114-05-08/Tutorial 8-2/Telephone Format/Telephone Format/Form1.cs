using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Telephone_Format
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // IsValidNumber 方法接受一個字串作為參數，
        // 並檢查該字串是否包含 10 個數字。
        // 如果字串包含 10 個數字，則回傳 true；
        // 否則回傳 false。
        private bool IsValidNumber(string str)
        {
            const int VALID_LENGTH = 10;
            // 檢查字串長度是否為 10。
            if (str.Length == VALID_LENGTH)
            {
               for (int i = 0; i < str.Length; i++)
                {
                    // 檢查字串中的每個字元是否為數字。
                    if (!char.IsDigit(str[i]))
                    {
                        return false; // 如果有非數字字元，則回傳 false。
                    }
                }
                return true; // 如果所有字元都是數字，則回傳 true。
            }
            return false;
            // 如果字串長度不是 10，則回傳 false。
        }

        // TelephoneFormat 方法接受一個字串參數（以引用方式傳遞），
        // 並將該字串格式化為電話號碼的形式。
        // 格式化後的電話號碼通常為 (XX) XXXX-XXXX。
        private void TelephoneFormat(ref string str)
        {
            // 確保字串長度為 10。
            //if (str.Length == 10)
            //{
                // 插入括號和連字符以格式化字串。
                //str = $"({str.Substring(0, 2)}) {str.Substring(2, 4)}-{str.Substring(6, 4)}";
            //}
            str = str.Insert(0, "(");// 在字串的開頭插入左括號。
            str = str.Insert(3, ") ");// 在字串的第 3 個位置插入右括號和空格。
            str = str.Insert(9, "-");// 在字串的第 9 個位置插入連字符。
        }

        // 當使用者按下「格式化」按鈕時觸發此事件。
        // 該方法會檢查輸入的字串是否有效，
        // 如果有效，則將其格式化為電話號碼並顯示；
        // 如果無效，則顯示錯誤訊息。
        private void formatButton_Click(object sender, EventArgs e)
        {
            string intput = numberTextBox.Text;
            // 檢查輸入的字串是否有效。
            if (IsValidNumber(intput))
            {
                // 如果有效，則格式化並顯示電話號碼。
                TelephoneFormat(ref intput);
                MessageBox.Show("格式化後的電話號碼為：" + intput);
            }

            else
            {
                // 如果無效，則顯示錯誤訊息。
                MessageBox.Show("請輸入有效的 10 位數字。");
            }
        }

        // 當使用者按下「退出」按鈕時觸發此事件。
        // 該方法會關閉目前的表單，結束應用程式。
        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉表單。
            this.Close();
        }
    }
}
