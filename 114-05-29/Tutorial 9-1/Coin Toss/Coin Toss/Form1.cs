using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coin_Toss
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void tossButton_Click(object sender, EventArgs e)
        {
            Coin myCoin = new Coin(); // 建立一個新的 Coin 物件
            outputListBox.Items.Clear(); // 清空列表框

            //模擬擲硬幣五次，並將結果顯示在列表框中
            for (int i = 0; i < 5; i++)
            {
                myCoin.Toss(); // 擲硬幣
                outputListBox.Items.Add(myCoin.GetSideUp()); // 將結果加入列表框
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            //  關閉表單
            this.Close();
        }
    }
}
