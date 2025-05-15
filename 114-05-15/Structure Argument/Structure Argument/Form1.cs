using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Structure_Argument
{
    // 定義汽車(Automobile)結構，包含廠牌、年份與里程數欄位
    struct Automobile
    {
        public string make;    // 汽車廠牌
        public int year;       // 汽車年份
        public double mileage; // 汽車里程數
    }

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // DisplayAuto 方法接受一個 Automobile 結構物件作為參數，
        // 並顯示該物件的所有欄位資訊於訊息方塊中。
        private void DisplayAuto(Automobile auto)
        {
            MessageBox.Show(
                auto.year + " 年 " + auto.make +
                "，里程數：" + auto.mileage + " 英里。"
            );
        }

        // 當使用者按下 auto1Button（顯示汽車 #1）時執行此事件處理函式
        // 1. 建立一個 Automobile 結構的實例（sportsCar）
        // 2. 指定廠牌、年份與里程數
        // 3. 呼叫 DisplayAuto 方法顯示該汽車資訊
        private void auto1Button_Click(object sender, EventArgs e)
        {
            Automobile sportsCar = new Automobile();
            sportsCar.make = "Chevy Corvette"; // 指定廠牌
            sportsCar.year = 1970;             // 指定年份
            sportsCar.mileage = 50000.0;       // 指定里程數

            DisplayAuto(sportsCar);            // 顯示汽車資訊
        }

        // 當使用者按下 auto2Button（顯示汽車 #2）時執行此事件處理函式
        // 1. 建立一個 Automobile 結構的實例（pickupTruck）
        // 2. 指定廠牌、年份與里程數
        // 3. 呼叫 DisplayAuto 方法顯示該汽車資訊
        private void auto2Button_Click(object sender, EventArgs e)
        {
            Automobile pickupTruck = new Automobile();
            pickupTruck.make = "Ford Ranger";  // 指定廠牌
            pickupTruck.year = 1985;           // 指定年份
            pickupTruck.mileage = 75000.0;     // 指定里程數

            DisplayAuto(pickupTruck);          // 顯示汽車資訊
        }

        // 當使用者按下 auto3Button（顯示汽車 #3）時執行此事件處理函式
        // 1. 建立一個 Automobile 結構的實例（sedan）
        // 2. 指定廠牌、年份與里程數
        // 3. 呼叫 DisplayAuto 方法顯示該汽車資訊
        private void auto3Button_Click(object sender, EventArgs e)
        {
            Automobile sedan = new Automobile();
            sedan.make = "Honda Accord";       // 指定廠牌
            sedan.year = 2000;                 // 指定年份
            sedan.mileage = 80000.0;           // 指定里程數

            DisplayAuto(sedan);                // 顯示汽車資訊
        }
    }
}
