using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cell_Phone_Inventory
{
    public partial class Form1 : Form
    {
        // 用來儲存 CellPhone 物件的清單
        List<CellPhone> phoneList = new List<CellPhone>();

        public Form1()
        {
            InitializeComponent();
        }

       
        /// GetPhoneData 方法接收一個 CellPhone 物件作為參數，
        /// 並將使用者輸入的資料指派給該物件的屬性。        
        /// <param name="phone">要填入資料的 CellPhone 物件</param>
        private void GetPhoneData(CellPhone phone)
        {
            // 暫存價格的變數
            decimal price;

            // 取得手機品牌，並指派給物件的 Brand 屬性
            phone.Brand = brandTextBox.Text;

            // 取得手機型號，並指派給物件的 Model 屬性
            phone.Model = modelTextBox.Text;

            // 取得手機價格，並指派給物件的 Price 屬性
            if (decimal.TryParse(priceTextBox.Text, out price))
            {
                phone.Price = price;
            }
            else
            {
                // 顯示錯誤訊息，提示價格輸入無效
                MessageBox.Show("價格無效，請輸入正確的數值");
            }
        }

        
        /// 新增手機按鈕的事件處理函式        
        private void addPhoneButton_Click(object sender, EventArgs e)
        {
            CellPhone myPhone = new CellPhone(); // 建立新的 CellPhone 物件

            GetPhoneData(myPhone); // 呼叫 GetPhoneData 方法填入資料

            phoneList.Add(myPhone); // 將新的手機物件加入清單

            //將新增手機的品牌與型號組合成字串，並加入ListBox中
            phoneListBox.Items.Add(myPhone.Brand + "" + myPhone.Model);

            // 清空輸入欄位
            brandTextBox.Clear();
            modelTextBox.Clear();
            priceTextBox.Clear();

            // 將焦點設回品牌輸入欄位
            brandTextBox.Focus();
        }


        /// 手機清單選取變更事件的處理函式       
        private void phoneListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = phoneListBox.SelectedIndex; // 取得選取的索引

            MessageBox.Show(phoneList[index].Price.ToString("C")); // 顯示選取手機的詳細資訊
        }

      
        /// 離開按鈕的事件處理函式，關閉表單        
        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉視窗表單
            this.Close();
        }
    }
}
