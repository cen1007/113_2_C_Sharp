using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cell_Phone_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // GetPhoneData 方法會接收一個 CellPhone 物件作為參數。
        // 此方法會將使用者在表單上輸入的資料指派給該物件的屬性。
        private void GetPhoneData(CellPhone phone)
        {
            decimal price;

            phone.Brand = brandTextBox.Text; // 將品牌從文本框指派給物件的 Brand 屬性
            phone.Model = modelTextBox.Text; // 將型號從文本框指派給物件的 Model 屬性

            // 嘗試將價格從文本框轉換為十進位數字，並指派給物件的 Price 屬性。
            if (decimal.TryParse(priceTextBox.Text, out price))
            {
                phone.Price = price; // 如果轉換成功，將價格指派給物件的 Price 屬性
            }
            else
            {
                MessageBox.Show("請輸入有效的價格。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                priceTextBox.Clear();
            }
        }

        // 當使用者按下「建立物件」按鈕時執行此事件處理常式。
        private void createObjectButton_Click(object sender, EventArgs e)
        {
            CellPhone myPhone = new CellPhone(); // 建立一個新的 CellPhone 物件
            GetPhoneData(myPhone); // 呼叫 GetPhoneData 方法，將表單上的資料指派給 myPhone 物件
            
            // 將 myPhone 物件的資料顯示在標籤中。
            brandLabel.Text = myPhone.Brand;
            modelLabel.Text = myPhone.Model;
            priceLabel.Text = myPhone.Price.ToString("C"); // 將價格格式化為貨幣格式
        }

        // 當使用者按下「離開」按鈕時執行此事件處理常式，會關閉表單並結束程式。
        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉表單，結束應用程式。
            this.Close();
        }
    }
}
