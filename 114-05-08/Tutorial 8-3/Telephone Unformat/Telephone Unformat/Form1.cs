using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Telephone_Unformat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // IsValidFormat 方法接受一個字串參數，並判斷該字串是否符合美國電話號碼的格式。
        // 格式要求如下：(XX)XXXX-XXXX
        // - 必須以左括號 '(' 開始，接著是兩個數字，然後是右括號 ')'。
        // - 接著是四個數字，然後是連字號 '-'，最後是四個數字。
        // 如果字串符合上述格式，則方法返回 true；否則返回 false。
        private bool IsValidFormat(string str)
        {
            // 檢查字串是否為空或長度不符合格式
            if (str.Length == 13 &&
                str[0] == '(' &&
                str[3] == ')' &&
                str[8] == '-')
            {
                string areaCode = str.Substring(1, 2); // 取得區域碼
                string firstPart = str.Substring(4, 4); // 取得前四位數
                string secondPart = str.Substring(9, 4); // 取得後四位數
                // 確保括號內和破折號分隔的部分都是數字
                if (IsAllDigits(areaCode) &&
                IsAllDigits(firstPart) &&
                IsAllDigits(secondPart))
                {
                    return true;
                }
                return false;
            }                     
            return false;
        }
 
        private bool IsAllDigits(string str)
        {
            // 檢查字串是否為數字
            foreach (char c in str)
            {
                if (!char.IsDigit(c))
                    return false;
            }
            return true;
        }


        // Unformat 方法接受一個字串參數（以引用方式傳遞），該字串假設為格式化的電話號碼。
        // 格式為：(XX)XXXX-XXXX
        // 此方法的功能是移除字串中的括號 '(' 和 ')' 以及連字號 '-'，將其轉換為純數字的格式。
        // 例如，輸入 "(12)3456-7890" 將被轉換為 "1234567890"。
        private void Unformat(ref string str)
        {
            // 移除括號 '(' 和 ')' 以及連字號 '-'
            str = str.Remove(0, 1); // 移除 '('
            str = str.Remove(2, 1); // 移除 ')'
            str = str.Remove(6, 1); // 移除 '-'
        }

        // unformatButton_Click 方法是當使用者按下「去格式化」按鈕時觸發的事件處理程式。
        // 此方法會從 numberTextBox 控制項中取得使用者輸入的電話號碼，並進行處理。
        private void unformatButton_Click(object sender, EventArgs e)
        {
            string intput = numberTextBox.Text; // 取得使用者輸入的電話號碼

            if (IsValidFormat(intput))
            {
                Unformat(ref intput); // 去格式化電話號碼
                MessageBox.Show("去格式化後的電話號碼為：" + intput, "結果", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("請輸入有效的電話號碼格式：(XX)XXXX-XXXX", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // 清空輸入框
                numberTextBox.Text = string.Empty;
                // 清空輸入框的焦點
                numberTextBox.Focus();
            }


        }

        // exitButton_Click 方法是當使用者按下「離開」按鈕時觸發的事件處理程式。
        // 此方法的功能是關閉目前的表單，結束應用程式。
        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉表單。
            this.Close();
        }
    }
}
